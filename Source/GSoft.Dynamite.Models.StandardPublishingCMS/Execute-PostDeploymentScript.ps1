# -----------------------------------------
# Custom Script
#
# This function gets all the scripts in the PostDeployment folder and executes them one by one
# -----------------------------------------

# If the path exists
if (Test-Path PostDeployment) {
   #Defines the post deployment script steps. (the custom scripts in the PostDeployement folder)
   #Example;
   #./PostDeployment/Example.ps1
}