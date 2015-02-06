#########################################
INTRODUCTION
#########################################
You've installed the cross-site publishing CMS model NuGet package!  Now... what does this thing do exactly?  Here's the lowdown:
The model is defined by the combination of different modules. These modules are installed by PowerShell scripts which are located under the "Modules" folder.  
Which module to install and in which order is up to the "Install-Model.ps1" script.  Some modules activate features which in turn, call the implementation of the
different contracts.  These contracts can be your own implementation of the "vanilla" implementation of the model.

The installation is done from a published deployment folder.  This folder is created with the "Publish-DeploymentFolder.ps1" script and combines the NuGet contents
(..\..\Libraries\GSoft.Dynamite.CrossSitePublishingCMS.*) and your scripts project on which this package is installed.

#########################################
CONFIGURATION
#########################################
(TODO) Tokens
(TODO) Contract implementations
(TODO) Different scenarios

#########################################
INSTALLATION
#########################################
1. Ensure you have your Tokens.*.ps1 file created and configured
2. Execute the "Publish-DeploymentFolder.ps1" to create the deployment folder at the root of the working folder
(TODO)