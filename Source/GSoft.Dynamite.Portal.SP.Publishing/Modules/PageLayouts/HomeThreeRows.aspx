<%@ Page language="C#"   Inherits="Microsoft.SharePoint.Publishing.PublishingLayoutPage,Microsoft.SharePoint.Publishing,Version=15.0.0.0,Culture=neutral,PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="WebControls" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="PublishingWebControls" Namespace="Microsoft.SharePoint.Publishing.WebControls" Assembly="Microsoft.SharePoint.Publishing, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="PublishingNavigation" Namespace="Microsoft.SharePoint.Publishing.Navigation" Assembly="Microsoft.SharePoint.Publishing, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register tagprefix="spsswc" namespace="Microsoft.Office.Server.Search.WebControls" assembly="Microsoft.Office.Server.Search, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ContentPlaceholderID="PlaceHolderAdditionalPageHead" runat="server">
    <WebControls:CssRegistration ID="CssRegistration1" name="<% $SPUrl:~sitecollection/Style Library/~language/Themable/Core Styles/pagelayouts15.css %>" runat="server"/>
    <PublishingWebControls:EditModePanel ID="EditModePanel1" runat="server">
        <!-- Styles for edit mode only-->
        <WebControls:CssRegistration ID="CssRegistration2" name="<% $SPUrl:~sitecollection/Style Library/~language/Themable/Core Styles/editmode15.css %>"
            After="<% $SPUrl:~sitecollection/Style Library/~language/Themable/Core Styles/pagelayouts15.css %>" runat="server"/>
    </PublishingWebControls:EditModePanel>
    <WebControls:FieldValue id="PageStylesField" FieldName="HeaderStyleDefinitions" runat="server"/>
</asp:Content>
<asp:Content ContentPlaceholderID="PlaceHolderPageTitle" runat="server">
    <spsswc:CatalogItemReuseWebPart runat="server" ID="CatalogItemTitle" NumberOfItems="1" UseSharedDataProvider="true" QueryGroupName="Default" SelectedPropertiesJson="['Title']" />
</asp:Content>
<asp:Content ContentPlaceholderID="PlaceHolderPageTitleInTitleArea" runat="server">
    <spsswc:CatalogItemReuseWebPart runat="server" ID="CatalogItemTitleInTitleArea" NumberOfItems="1" UseSharedDataProvider="true" QueryGroupName="Default" SelectedPropertiesJson="['Title']" />
</asp:Content>
<asp:Content ContentPlaceholderID="PlaceHolderMain" runat="server">
    <div class="page-layout-home-3rows">
        <div class="row">
            <div class="col-big">
                <WebPartPages:WebPartZone runat="server" Title="Main column - Row 1" ID="Main1">
                    <ZoneTemplate>
                    </ZoneTemplate>
                </WebPartPages:WebPartZone>
            </div>
            <div class="col-small">
                <WebPartPages:WebPartZone runat="server" Title="Right side column - Row 1" ID="RightSide1">
                    <ZoneTemplate>
                    </ZoneTemplate>
                </WebPartPages:WebPartZone>
            </div>     
        </div>
        <div class="row">
            <div class="col-big">
                <WebPartPages:WebPartZone runat="server" Title="Main column - Row 2" ID="Main2">
                    <ZoneTemplate>
                    </ZoneTemplate>
                </WebPartPages:WebPartZone>
            </div>
            <div class="col-small">
                <WebPartPages:WebPartZone runat="server" Title="Right side column - Row 2" ID="RightSide2">
                    <ZoneTemplate>
                    </ZoneTemplate>
                </WebPartPages:WebPartZone>
            </div>     
        </div>
        <div class="row">
            <div class="col-big">
                <WebPartPages:WebPartZone runat="server" Title="Main column - Row 3" ID="Main3">
                    <ZoneTemplate>
                    </ZoneTemplate>
                </WebPartPages:WebPartZone>
            </div>
            <div class="col-small">
                <WebPartPages:WebPartZone runat="server" Title="Right side column - Row 3" ID="RightSide3">
                    <ZoneTemplate>
                    </ZoneTemplate>
                </WebPartPages:WebPartZone>
            </div>     
        </div>
    </div>
</asp:Content>
