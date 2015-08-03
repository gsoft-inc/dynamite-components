# ----------------------------------------
# PUB 02: VIEW ITEM DETAILS
# ----------------------------------------
param([string]$LogFolderPath)

$UserStory = "PUB02"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

# ============================================= #
# =========  SEARCH RESULT SOURCES   ========== #
# ============================================= #
# TODO: Setup-ResultSources activates a CrossSitePublishingCMS feature, which makes little to no sense.
# Figure out a way to refactor this into a CommonCMS feature or do these setup steps only as part of
# your plugin project.
#$values = @{"Step: " = "#1 Create Search Result Sources"}
#New-HeaderDrawing -Values $Values

#$Script = $CommandDirectory + '\Setup-ResultSources.ps1'
#& $Script -Force

# ==================================== #
# =========  PAGE LAYOUTS   ========== #
# ==================================== #

$values = @{"Step: " = "#1 Create Page Layouts"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-PageLayouts.ps1'
& $Script -Force

# ==================================== #
# ========  PAGE INSTANCES   ========= #
# ==================================== #
# TODO: Setup-Pages activates a CrossSitePublishingCMS feature, which makes little to no sense.
# Figure out a way to refactor this into a CommonCMS feature or do these setup steps only as part of
# your plugin project.
#$values = @{"Step: " = "#3 Create Page Instances"}
#New-HeaderDrawing -Values $Values

#$Script = $CommandDirectory + '\Setup-Pages.ps1'
#& $Script -Force

# ==================================== #
# =======  DISPLAY TEMPLATES ========= #
# ==================================== #
# TODO: Setup-DisplayTemplates activates a CrossSitePublishingCMS feature, which makes little to no sense.
# Figure out a way to refactor this into a CommonCMS feature or do these setup steps only as part of
# your plugin project.
#$values = @{"Step: " = "#4 Create Display Templates"}
#New-HeaderDrawing -Values $Values

#$Script = $CommandDirectory + '\Setup-DisplayTemplates.ps1'
#& $Script