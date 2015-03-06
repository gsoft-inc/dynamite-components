<%@ Page Language="C#" Inherits="Microsoft.SharePoint.Publishing.PublishingLayoutPage,Microsoft.SharePoint.Publishing,Version=15.0.0.0,Culture=neutral,PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePointWebControls" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="PublishingWebControls" Namespace="Microsoft.SharePoint.Publishing.WebControls" Assembly="Microsoft.SharePoint.Publishing, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="PublishingNavigation" Namespace="Microsoft.SharePoint.Publishing.Navigation" Assembly="Microsoft.SharePoint.Publishing, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register tagprefix="SearchWebControls" namespace="Microsoft.Office.Server.Search.WebControls" assembly="Microsoft.Office.Server.Search, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content contentplaceholderid="PlaceHolderAdditionalPageHead" runat="server">
	<SharePointWebControls:CssRegistration name="<% $SPUrl:~sitecollection/Style Library/~language/Themable/Core Styles/pagelayouts15.css %>" runat="server"/>
	<PublishingWebControls:EditModePanel runat="server">
		<!-- Styles for edit mode only-->
		<SharePointWebControls:CssRegistration name="<% $SPUrl:~sitecollection/Style Library/~language/Themable/Core Styles/editmode15.css %>"
			After="<% $SPUrl:~sitecollection/Style Library/~language/Themable/Core Styles/pagelayouts15.css %>" runat="server"/>
	</PublishingWebControls:EditModePanel>
	<SharePointWebControls:FieldValue id="PageStylesField" FieldName="HeaderStyleDefinitions" runat="server"/>
</asp:Content>
<asp:Content contentplaceholderid="PlaceHolderPageTitle" runat="server">
	<SearchWebControls:CatalogItemReuseWebPart runat="server" ID="CatalogItemTitle" NumberOfItems="1" UseSharedDataProvider="true" QueryGroupName="SingleItem" SelectedPropertiesJson="['Title']" />
</asp:Content>
<asp:Content contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	<SearchWebControls:CatalogItemReuseWebPart runat="server" ID="CatalogItemTitleInTitleArea" NumberOfItems="1" UseSharedDataProvider="true" QueryGroupName="SingleItem" SelectedPropertiesJson="['Title']" />
</asp:Content>
<asp:Content contentplaceholderid="PlaceHolderTitleBreadcrumb" runat="server"> 
	<SharePointWebControls:ListSiteMapPath runat="server" SiteMapProviders="CurrentNavigationSwitchableProvider" RenderCurrentNodeAsLink="false" PathSeparator="" CssClass="s4-breadcrumb" NodeStyle-CssClass="s4-breadcrumbNode" CurrentNodeStyle-CssClass="s4-breadcrumbCurrentNode" RootNodeStyle-CssClass="s4-breadcrumbRootNode" NodeImageOffsetX=0 NodeImageOffsetY=289 NodeImageWidth=16 NodeImageHeight=16 NodeImageUrl="/_layouts/15/images/fgimg.png?rev=23" HideInteriorRootNodes="true" SkipLinkText=""/>
</asp:Content>
<asp:Content contentplaceholderid="PlaceHolderMain" runat="server">
    <div class="row row-tabs">
        <div class="row row-tabs-nav">
	    <WebPartPages:WebPartZone runat="server" Title="<%$Resources:cms,WebPartZoneTitle_Header%>" ID="Header"><ZoneTemplate></ZoneTemplate></WebPartPages:WebPartZone>
	    </div>
        <div class="row one-column content-wrap">
	        <section id="section-1">
	    	        <WebPartPages:WebPartZone runat="server" Title="Section 1" ID="Section1"><ZoneTemplate></ZoneTemplate></WebPartPages:WebPartZone>
	        </section>
            <section id="section-2">
	    	        <WebPartPages:WebPartZone runat="server" Title="Section 2" ID="Section2"><ZoneTemplate></ZoneTemplate></WebPartPages:WebPartZone>
	        </section>
            <section id="section-3">
	    	        <WebPartPages:WebPartZone runat="server" Title="Section 3" ID="Section3"><ZoneTemplate></ZoneTemplate></WebPartPages:WebPartZone>
	        </section>
        </div>
    </div>
    <div class="row one-column">
	    <WebPartPages:WebPartZone runat="server" Title="Main" ID="Main"><ZoneTemplate></ZoneTemplate></WebPartPages:WebPartZone>
    </div>
</asp:Content>

