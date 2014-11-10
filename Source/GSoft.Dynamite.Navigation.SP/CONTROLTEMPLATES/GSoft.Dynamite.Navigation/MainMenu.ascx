﻿<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.ascx.cs" Inherits="GSoft.Dynamite.Navigation.SP.CONTROLTEMPLATES.GSoft.Dynamite.Navigation.MainMenu" %>

<SharePoint:ScriptLink ID="GSoftDynamiteNavigationMainMenuJS" Language="javascript" Name="~sitecollection/_layouts/15/GSoft.Dynamite.Navigation.SP/JS/GSoft.Dynamite.Navigation.js" Localizable="false" OnDemand="false" runat="server" />
<SharePoint:CssRegistration ID="GSoftDynamiteNavigationMainMenuCSS" Name="~sitecollection/_layouts/15/GSoft.Dynamite.Navigation.SP/CSS/GSoft.Dynamite.Navigation.css" After="Core4.css" runat="server" />

<nav class="main-menu" id="main-menu">
    <ul data-bind="template: { name: 'menu-level-template1', foreach: Nodes }" class="main-menu-level-1"></ul>
</nav>

<script>
    Portal.MainMenu.initialize(<%=this.MenuJSON%>);
</script>
<script type="text/html" id="menu-level-template1">
    <li data-bind="css: LevelClass">
        <a data-bind="text: Title, css: LevelClass, attr: { href: Url }"></a>
    </li>
    <div data-bind="css: NextLevelClass">
        <ul data-bind="css: NextLevelClass, template: { name: 'menu-level-template2', foreach: ChildNodes }"></ul>
    </div>
</script>

<script type="text/html" id="menu-level-template2">
    <li data-bind="css: LevelClass">
        <a data-bind="text: Title, css: LevelClass, attr: { href: Url }"></a>
    </li>
</script>

