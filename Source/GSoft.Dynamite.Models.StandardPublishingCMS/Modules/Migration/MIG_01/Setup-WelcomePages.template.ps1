# In some edge cases, a web's URL will clash with a taxonomy friendly URL (i.e. the web URL
# and friendly URL will be exactly the same and we'll get redirected to a useless default.aspx
# welcome page instead of our friendly URL's target page).
# In those cases, we want to get rid of the useless default.aspx page and replace
# the web's WelcomePage with the physical URL of the publishing page which has
# the taxonomy navigation term associated with it (because we want that page to be
# the actual destination of any visitor which hits the web URL).

function Strip-Accents {
    param (
        [String] $stringToStrip
    )

    $normalized = $stringToStrip.Normalize([Text.NormalizationForm]::FormD)
    $sb = New-Object Text.StringBuilder
    $normalized.ToCharArray() | ForEach-Object { 
        if( [Globalization.CharUnicodeInfo]::GetUnicodeCategory($_) -ne [Globalization.UnicodeCategory]::NonSpacingMark) {
            [void]$sb.Append($_)
        }
    }
    $afterStrip = $sb.ToString()

    return $afterStrip
}

$site = Get-SPSite "[[DSP_PortalPublishingSiteUrl]]"

$site.AllWebs | ForEach-Object {
    $currentWeb = $_
    $webUrl = $_.Url

    if ($webUrl -ne $site.RootWeb.Url) {
        $webWelcomePageUrl = $currentWeb.RootFolder.WelcomePage
        Write-Host "Looking on web $webUrl for welcome page $webWelcomePageUrl..."

        $serverRelativeWelcomePageUrl = [Microsoft.SharePoint.Utilities.SPUtility]::ConcatUrls($webUrl, $webWelcomePageUrl)
        $welcomePageListItem = $_.GetListItem($serverRelativeWelcomePageUrl);

        $navigationFieldValue = $null
        if ($welcomePageListItem -ne $null) {
            $navigationFieldValue = $welcomePageListItem["Navigation"];
        }

        if ($navigationFieldValue -eq $null) {
            # We're dealing with a default.aspx page which we need to remove (but beforehand we need to find our correct welcome page)
            $webUrlFragment = $webUrl.Replace($_.ParentWeb.Url, "")

            $pagesLibrary = $_.Lists["Pages"]

            $items = $pagesLibrary.Items | Where-Object { !$_.Name.StartsWith("default") }

            $items | ForEach-Object {
                # Logic: let's find the publishing page which has a navigation term associated with it
                # with a friendly URL that matches the current web parent-relative URL.
                $navTermsPointingToPage = [Microsoft.SharePoint.Publishing.Navigation.TaxonomyNavigation]::GetFriendlyUrlsForListItem($_, $true);
                $itemUrl = $_.Url

                $navTermsPointingToPage | ForEach-Object {
                    $fragment = $_.FriendlyUrlSegment

                    # Gotta normalize the friendly URL fragment to remove accents so that we can support matches
                    # between "with-accents" friendly URLs and "without-accents" web relative URLs.
                    $fragmentWithoutAccents = Strip-Accents $fragment

                    # Write-Warning "Comparing FriendlyURL fragment '$fragmentWithoutAccents' (with accents='$fragment') with web URL=$webUrlFragment..."

                    if (![string]::IsNullOrEmpty($fragment) -and $webUrlFragment.Contains($fragmentWithoutAccents)) {                    
                        Write-Host "Found match: " -ForegroundColor Yellow -NoNewline
                        Write-Host "Page at $itemUrl with friendly URL fragment $fragment. Setting this item as new welcome page for web... " -NoNewLine
                        $webRootFolder = $currentWeb.RootFolder;
                        $webRootFolder.WelcomePage = $itemUrl
                        $webRootFolder.Update()
                        Write-Host "done!" -ForegroundColor Green

                        $oldWelcomeUrl = $welcomePageListItem.Url
                        Write-Host "Deleting old default page at $oldWelcomeUrl... " -NoNewLine
                        $welcomePageListItem.Delete()    
                        Write-Host "done!" -ForegroundColor Green
                    }
                }
            }
        }
        else {
            $asString = $navigationFieldValue.ToString();
            Write-Warning "Current welcome page has Navigation value $asString. Skipping..."
        }
    } else {
        Write-Host "Skipping root web..."
    }
};

