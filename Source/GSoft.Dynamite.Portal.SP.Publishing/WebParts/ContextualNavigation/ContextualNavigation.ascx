<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContextualNavigation.ascx.cs" Inherits="GSoft.Dynamite.Portal.SP.Publishing.WebParts.ContextualNavigation.ContextualNavigation" %>

<nav id="<%=this.UniquePerRequestId %>" class="sidemenu">
    <span class="parent left-nav-link">
        <a data-bind="attr: {href: ParentUrl, title: ParentTitle},text: ParentTitle"></a>
    </span>
    <ul data-bind="foreach:Nodes">
        <li data-bind="css: IsCurrentNode == true || IsNodeInCurrentBranch == true ? 'left-nav-link active' : 'left-nav-link' ">
            <div data-bind="css: IsCurrentNode == true || IsNodeInCurrentBranch == true ? 'icon icon-thin-arrow-dark-blue' : ''"></div>
            <a data-bind="attr: {href: Url, title: Title}, text: Title"></a>
        </li>
    </ul>
</nav>

<script>
    var sideMenuParams = {};
    sideMenuParams.ParentElementId = '<%=this.UniquePerRequestId %>';
    sideMenuParams.RawChildNodes = <%=this.NodesJSON %>;
    sideMenuParams.SearchPages = '<%=this.SearchPages%>';
    GSoft.Dynamite.Portal.SideMenu.initialize(sideMenuParams);
</script>
