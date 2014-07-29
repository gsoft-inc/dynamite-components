﻿#
# Module 'Dynamite.PowerShell.Toolkit'
# Generated by: GSoft, Team Dynamite.
# Generated on: 10/24/2013
# > GSoft & Dynamite : http://www.gsoft.com
# > Dynamite Github : https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit
# > Documentation : https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit/wiki
#

<#
	.SYNOPSIS
		Commandlet to set Faceted navigation configuration in the term store

	.DESCRIPTION
		This cmdlet allow you to configure faceted navigation configuration for the taxonomy term store. 
		You can pass a XML file as parameter to automatically create the correct settings.

    --------------------------------------------------------------------------------------
    Module 'Dynamite.PowerShell.Toolkit'
    by: GSoft, Team Dynamite.
    > GSoft & Dynamite : http://www.gsoft.com
    > Dynamite Github : https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit
    > Documentation : https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit/wiki
    --------------------------------------------------------------------------------------
		
	.PARAMETER XmlPath
		Path to the XML file that contains the term driven configuration. The schema for the XML is as follow:

        NOTE: All labels must be specified with the same web culture
		
		<Configuration>
	        <Web Name="http://<site_name>">
		        <List Name="MyList">
			        <Workflow 	Name="Approbation de contenu"
						        TemplateID="8ad4d8f0-93a7-4941-9657-cf3706f0040c" <!-- Approbation - SharePoint 2010 -->
						        TaskListName="Tâches de flux de travail"
						        HistoryListName="Historique des flux de travail"
						        AllowManual="true"
						        AutoStartCreate="true"
						        AutoStartChange="true">
						        <Settings>
							        <Assignee>
								        <DisplayName>Approvers</DisplayName>
								        <AccountId>Approvers</AccountId>		
								        <AccountType>SharePointGroup</AccountType>
							        <ExpandGroups>true</ExpandGroups>
							        <NotificationMessage>Mon messages</NotificationMessage>
							        <DueDateforAllTasks>true</DueDateforAllTasks>
							        <DurationforSerialTasks></DurationforSerialTasks>
							        <DurationUnits>Day</DurationUnits>
							        <CancelonRejection>true</CancelonRejection>
							        <CancelonChange>false</CancelonChange>
							        <EnableContentApproval>true</EnableContentApproval>
						        </Settings>
			        </Workflow>
		        </List>
	        </Web>
        </Configuration>
		
	.EXAMPLE
		PS C:\> New-DSPListWorkflows -XmlPath "C:\Workflow.xml"

    
  .LINK
    GSoft, Team Dynamite on Github
    > https://github.com/GSoft-SharePoint
    
    Dynamite PowerShell Toolkit on Github
    > https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit
    
    Documentation
    > https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit/wiki
    
#>
function Set-DSPListWorkflows()
{
	[CmdletBinding()]
	param
	(
		[Parameter(ParameterSetName="Default", Mandatory=$true, Position=0)]
		[string]$XmlPath,

        [Parameter(ParameterSetName="OverWrite", Mandatory=$false, Position=1)]
        [Parameter(ParameterSetName="Default")]
		[switch]$OverWrite,

        [Parameter(ParameterSetName="Delete", Mandatory=$false, Position=1)]
        [Parameter(ParameterSetName="Default")]
		[switch]$Delete
	)
	
	# Get the Xml content and start looping throught Site Collections and generate the structure
	$Config = [xml](Get-Content $XmlPath)
	
	# Get the term web
	$web = Get-SPWeb $Config.Configuration.Web.Name
	
    $Config.Configuration.Web.List | Foreach-Object{

        # Get the list
        $list = $web.Lists[$_.Name]

        $_.Workflow | Foreach-Object{

            if ($Delete)
            {               
               Remove-DSPListWorklow $list $_.TemplateID
            }
            else
            {
               Add-DSPListWorklow $list $_ $OverWrite
            } 
        }    
    }  	
}

function Add-DSPListWorklow()
{
	[CmdletBinding()]
	param
	(
		[Parameter(Mandatory=$true, Position=0)]
		[Microsoft.SharePoint.SPList]$SPList,

		[Parameter(Mandatory=$true, Position=1)]
		$WorkflowConfig,

    	[Parameter(Mandatory=$false, Position=2)]
		$Overwrite=$false
	)

    $SPWeb = $SPList.ParentWeb

    # Get general parameters
    $ListTitle = $SPList.Title
    $WorkflowName = $WorkflowConfig.Name
    $WorkflowTemplateId = $WorkflowConfig.TemplateID
    $WorkflowTaskList = $WorkflowConfig.TaskListName
    $WorkflowHistoryList = $WorkflowConfig.HistoryListName
    $WorkflowAllowManual = $WorkflowConfig.AllowManual
    $WorkflowAutoStartCreate = $WorkflowConfig.AutoStartCreate
    $WorkflowAutoStartChange = $WorkflowConfig.AutoStartChange

    # Get Workflow Settings parameters
    $AssigneeDisplayName = $WorkflowConfig.Settings.Assignee.DisplayName
    $AssigneeAccountId = $WorkflowConfig.Settings.Assignee.AccountId
    $AssigneeAccountType = $WorkflowConfig.Settings.Assignee.AccountType
    $AssignmentType = $WorkflowConfig.Settings.AssignmentType
    $ExpandGroups = $WorkflowConfig.Settings.ExpandGroups
    $NotificationMessage = $WorkflowConfig.Settings.NotificationMessage
    $DueDateforAllTasks = $WorkflowConfig.Settings.DueDateforAllTasks
    $DurationforSerialTasks = $WorkflowConfig.Settings.DurationforSerialTasks
    $DurationUnits = $WorkflowConfig.Settings.DurationUnits
    $CancelonRejection = $WorkflowConfig.Settings.CancelonRejection
    $CancelonChange = $WorkflowConfig.Settings.CancelonChange
    $EnableContentApproval = $WorkflowConfig.Settings.EnableContentApproval

    Write-Verbose "Creating Workflow $WorkflowName on $ListTitle"

    # Get the workflow template by its Id    
    $WorkflowTemplate = $SPWeb.WorkflowTemplates.GetTemplateByBaseId($WorkflowTemplateId);

    # Try to get workflow history and task list 

    $TaskList = $SPWeb.Lists[$WorkflowTaskList];

    $HistoryList = $SPWeb.Lists[$WorkflowHistoryList];

    if ($HistoryList -eq $null)
    {
        # Get the "Workflow History" list template
        $SPListTemplate =$SPWeb.ListTemplates | Where-Object {$_.Type_Client -eq 140}
        $SPWeb.Lists.Add($WorkflowHistoryList, "", $SPListTemplate);
        $HistoryList = $SPWeb.Lists[$WorkflowHistoryList];
    }

    # Check if the list is already bind with the worklfow

    $workflowAssociation  = $SPList.WorkflowAssociations.GetAssociationByBaseID($WorkflowTemplateId);
  
    if($workflowAssociation -ne $null -and $Overwrite)
    {
        Remove-DSPListWorklow $SPList $WorkflowTemplateId
    }

    # Create the Workflow association by using Workflow Template, Task List and History List
    $Association=[Microsoft.SharePoint.Workflow.SPWorkflowAssociation]::CreateListAssociation($WorkflowTemplate, $WorkflowName, $TaskList, $HistoryList);

    # Enable automatic workflow start when news created or changed and disable manual start option

    $Association.AllowManual = $WorkflowAllowManual;
    $Association.AutoStartChange = $WorkflowAutoStartChange;
    $Association.AutoStartCreate = $WorkflowAutoStartCreate;

    # Provide Association Data which includes as below

    #             1. Approvers SharePoint group for list of approvers.

    #             2. Serial order Workflow.

    #             3. Specify the notification message while sending notifications to approvers.

    #             4. Automatically reject the document if it is rejected by any participant.

    #             5. Update the approval status after the workflow is completed (use this workflow to control content approval).

    $approvalAssociationData = "

    <dfs:myFields xmlns:xsd='http://www.w3.org/2001/XMLSchema'

        xmlns:dms='http://schemas.microsoft.com/office/2009/documentManagement/types'

        xmlns:dfs='http://schemas.microsoft.com/office/infopath/2003/dataFormSolution'

        xmlns:q='http://schemas.microsoft.com/office/infopath/2009/WSSList/queryFields'

        xmlns:d='http://schemas.microsoft.com/office/infopath/2009/WSSList/dataFields'

        xmlns:ma='http://schemas.microsoft.com/office/2009/metadata/properties/metaAttributes'

        xmlns:pc='http://schemas.microsoft.com/office/infopath/2007/PartnerControls'

        xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>

        <dfs:queryFields></dfs:queryFields>

        <dfs:dataFields>

            <d:SharePointListItem_RW>

                <d:Approvers>

                    <d:Assignment>

                        <d:Assignee>

                            <pc:Person>

                                <pc:DisplayName>"+ $AssigneeDisplayName +"</pc:DisplayName>

                                <pc:AccountId>"+ $AssigneeAccountId +"</pc:AccountId>

                                <pc:AccountType>"+ $AssigneeAccountType +"</pc:AccountType>

                            </pc:Person>

                        </d:Assignee>

                        <d:Stage xsi:nil='true' />

                        <d:AssignmentType>"+ $AssignmentType +"</d:AssignmentType>

                    </d:Assignment>

                </d:Approvers>

                <d:ExpandGroups>"+ $ExpandGroups +"</d:ExpandGroups>

                <d:NotificationMessage>"+ $NotificationMessage +".</d:NotificationMessage>

                <d:DueDateforAllTasks xsi:nil='true' />

                <d:DurationforSerialTasks xsi:nil='true' />

                <d:DurationUnits>"+ $DurationUnits +"</d:DurationUnits><d:CC />

                <d:CancelonRejection>"+ $CancelonRejection +"</d:CancelonRejection>

                <d:CancelonChange>"+ $CancelonChange +"</d:CancelonChange>

                <d:EnableContentApproval>"+ $EnableContentApproval +"</d:EnableContentApproval>

            </d:SharePointListItem_RW>

        </dfs:dataFields>

    </dfs:myFields>";

               
    $Association.AssociationData = $approvalAssociationData

    # Associate the approval workflow to the list
    $Workflow = $SPList.WorkflowAssociations.Add($Association);

    Write-Verbose "Workflow has been attached successfully."

    $SPList.Update();
}


function Remove-DSPListWorklow()
{
	[CmdletBinding()]
	param
	(
		[Parameter(Mandatory=$true, Position=0)]
		[Microsoft.SharePoint.SPList]$SPList,

		[Parameter(Mandatory=$true, Position=1)]
		$WorkflowTemplateId
	)

    $workflowAssociation  = $SPList.WorkflowAssociations.GetAssociationByBaseID($WorkflowTemplateId);
  
    if($workflowAssociation  -ne $null)
    {
        #  Remove workflow association to list
        $SPList.RemoveWorkflowAssociation($workflowAssociation);
        $SPList.Update();

        Write-Verbose  "Workflow association removed Successfully."

    }
    else
    {
        Write-Verbose  "Workflow association could not be found."
    }
}
