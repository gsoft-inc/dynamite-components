# ----------------------------------------
# NAV_01: BROWSE INTRANET
# ----------------------------------------

param([string]$LogFolderPath, [switch]$Force)

$UserStory = "NAV01"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

# ******************************************
# Local utility methods
# ******************************************

function Prompt-ForOverwriteKeywordsTermGroup {
    $title = "Overwrite Keywords term group"
    $message = "Term Store: would you like to overwrite the contents of the Keywords term group?"
    $yes = New-Object System.Management.Automation.Host.ChoiceDescription "&Yes", "Overwrites the contents of the Keywords term group."
    $no = New-Object System.Management.Automation.Host.ChoiceDescription "&No", "Retains the current state of the Keywords term group."
    $options = [System.Management.Automation.Host.ChoiceDescription[]]($yes, $no)

    $choice = 0
    if ($ConfirmPreference -ne "None") {
        $choice = $host.ui.PromptForChoice($title, $message, $options, 0)
    }

    switch ($choice)
    {
        0 # Yes
        {
            return $true
        }
        1 # No
        {
            return $false
        }
    }
}

function Check-KeywordsTermGroupExists {
    $TermStoreName = "[[DSP_TermStoreName]]"
    $DefaultKeywordsTermGroup = "[[DSP_DEFAULT_PortalKeywordsTermGroup]]"
    $CustomKeywordsTermGroup = "[[DSP_CUSTOM_PortalKeywordsTermGroup]]"

    $KeywordsTermGroup = $DefaultKeywordsTermGroup

    if(![string]::IsNullOrEmpty($CustomKeywordsTermGroup))
    {
	    $KeywordsTermGroup = $CustomKeywordsTermGroup
    }

    $site = Get-SPSite "[[DSP_PortalPublishingHostNamePath]]"
    if($site -eq $null)
    {
	    return $false
    }

    $taxonomySession = $site | Get-DSPTaxonomySession
    if($taxonomySession -eq $null)
    {
	    return $false
    }

    $termStore = $null
    if (![string]::IsNullOrEmpty($TermStoreName) -and !$TermStoreName.StartsWith("[[")) {
        $termStore = $taxonomySession | Get-DSPTermStore -Name $TermStoreName
    } else {
        $termStore = $taxonomySession | Get-DSPTermStore -Default
    }
    if($termStore)
    {
        return $termStore.Groups[$KeywordsTermGroup] -ne $null
    }
    else
    {  
        return $false
    }
}

# =============================== #
# =========   TERMGROUPS   ========== #
# =============================== #
$values = @{"Step: " = "#1 Export Current Term Groups"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Export-TermGroups.ps1'
& $Script

# Check if we want to import Keywords term group
$ImportTermGroups = $false
if ($Force)
{
    $overwriteKeywordsTermGroup = Prompt-ForOverwriteKeywordsTermGroup
    if ($overwriteKeywordsTermGroup)
    {
        $ImportTermGroups = $true

        $values = @{"Step: " = "#2 Remove Term Groups"}
        New-HeaderDrawing -Values $Values

        $Script = $CommandDirectory + '\Remove-TermGroups.ps1'
        & $Script 
    }
    else
    {
        $ImportTermGroups = $false
        Write-Warning "Skipping term set init..."
    }
}
else # No Force
{
    if (Check-KeywordsTermGroupExists)
    {
        Write-Warning "The term group already exists in the term store. Please specify the -Force switch on Install-Model if you want to get the option to overwrite the term store contents. Skipping term set init..."
        $ImportTermGroups = $false
    }
    else 
    {
        # Import for the first time
        $ImportTermGroups = $true
    }
}

if ($ImportTermGroups)
{
    $values = @{"Step: " = "#3 Import Term Groups"}
    New-HeaderDrawing -Values $Values

    $Script = $CommandDirectory + '\Import-TermGroups.ps1'
    & $Script 
}

# =========================================== #
# =========   METADATA NAVIGATION   ========== #
# =========================================== #

$values = @{"Step: " = "#4 Configure taxonomy metadata navigation"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ManagedNavigation.ps1'
& $Script