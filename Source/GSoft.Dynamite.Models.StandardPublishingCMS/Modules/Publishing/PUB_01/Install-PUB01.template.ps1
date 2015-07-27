# ----------------------------------------
# PUB 01: CREATE, UPDATE AND DELETE AN ITEM
# ----------------------------------------
# 
param([string]$LogFolderPath,[bool]$Force=$false,[bool]$IgnoreWebs=$false)

$UserStory = "PUB01"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

# ******************************************
# Local utility methods
# ******************************************

function Prompt-ForOverwriteNavigationTermGroup {
    $title = "Overwrite Navigation term group"
    $message = "Term Store: would you like to overwrite the contents of the Navigation term group?"
    $yes = New-Object System.Management.Automation.Host.ChoiceDescription "&Yes", "Overwrites the contents of the Navigation term group."
    $no = New-Object System.Management.Automation.Host.ChoiceDescription "&No", "Retains the current state of the Navigation term group."
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

function Check-NavigationTermGroupExists {
    $TermStoreName = "[[DSP_TermStoreName]]"
    $DefaultNavigationtermGroup = "[[DSP_DEFAULT_PortalNavigationTermGroup]]"
    $CustomNavigationTermGroup = "[[DSP_CUSTOM_PortalNavigationTermGroup]]"

    $NavigationTermGroup = $DefaultNavigationtermGroup

    if(![string]::IsNullOrEmpty($CustomNavigationTermGroup))
    {
	    $NavigationTermGroup = $CustomNavigationTermGroup
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
        return $termStore.Groups[$NavigationTermGroup] -ne $null
    }
    else
    {  
        return $false
    }
}

# =========================================== #
# =========   CREATE STRUCTURE ============== #
# =========================================== #

$values = @{"Step: " = "#1 Setup Sites"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Sites.ps1'
& $Script -Force:$Force -IgnoreWebs:$IgnoreWebs

$values = @{"Step: " = "#2 Setup Webs"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Webs.ps1'
& $Script -IgnoreWebs:$IgnoreWebs

$values = @{"Step: " = "#3 Setup Permissions"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Permissions.ps1'
& $Script

# =========================================== #
# =========   CATEGORIZE CONTENTS =========== #
# =========================================== #

$values = @{"Step: " = "#4 Export Current Term Groups"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Export-TermGroups.ps1'
& $Script

# Check if we want to import term groups
$ImportTermGroups = $false
if ($Force)
{
    $overwriteNavigationTermGroup = Prompt-ForOverwriteNavigationTermGroup
    if ($overwriteNavigationTermGroup)
    {
        $ImportTermGroups = $true

        $values = @{"Step: " = "#5 Remove Term Groups"}
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
    if (Check-NavigationTermGroupExists)
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
    $values = @{"Step: " = "#6 Import Term Groups"}
    New-HeaderDrawing -Values $Values

    $Script = $CommandDirectory + '\Import-TermGroups.ps1'
    & $Script
}
$values = @{"Step: " = "#7 Setup Columns"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Fields.ps1'
& $Script

$values = @{"Step: " = "#8 Setup Content Types"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ContentTypes.ps1'
& $Script 

$values = @{"Step: " = "#9 Setup Pages Library"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Lists.ps1'
& $Script 

# =========================================== #
# =========   METADATA FILTERING   ========== #
# =========================================== #

$values = @{"Step: " = "#10 Configure metadata navigation for pages librairies"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-MetadataFiltering.ps1'
& $Script



