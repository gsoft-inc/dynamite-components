<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.ascx.cs" Inherits="GSoft.Dynamite.Portal.SP.Publishing.CONTROLTEMPLATES.GSoft.Dynamite.Portal.MainMenu" %>

<div class="main-menu" id="main-menu">
    <ul data-bind="template: { name: 'menu-level-template', foreach: Nodes }" class="menu-level-1"></ul>
</div>

<script>
    Portal.MainMenu.initialize(<%=this.MenuJSON%>, <%=this.NumberOfFlatLevel%>);
</script>
<script type="text/html" id="menu-level-template1">
    <li data-bind="css: LevelClass">
        <a data-bind="text: Title, css: LevelClass, attr: {href: Url}"></a>
        <ul data-bind="css: NextLevelClass, template: { name: 'menu-level-template', foreach: ChildNodes }"></ul>
    </li>
</script>
<script type="text/html" id="menu-level-template">
    <li data-bind="css: LevelClass">
        <a data-bind="text: Title, css: LevelClass, attr: {href: Url}"></a>
        <!-- ko if: $root.NumberOfFlatLevel() <= Level() && ChildNodes().length > 0 -->
        <ul data-bind="css: NextLevelClass, template: { name: 'menu-level-template', foreach: ChildNodes }"></ul>
        <!-- /ko -->
    </li>
    <!-- ko if: $root.NumberOfFlatLevel() > Level() && ChildNodes().length > 0 -->
    <ul data-bind="css: NextLevelClass, template: { name: 'menu-level-template', foreach: ChildNodes }"></ul>
    <!-- /ko -->
</script>
