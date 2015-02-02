<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BootstrapClientScripts.ascx.cs" Inherits="GSoft.Dynamite.Design.SP.CONTROLTEMPLATES.GSoft.Dynamite.Design.Bootstrap.BootstrapClientScripts" %>

<SharePoint:ScriptLink ID="JQueryScriptLink" Language="javascript" Name="~sitecollection/_layouts/15/GSoft.Dynamite.Design.Bootstrap/JS/jquery-1.11.2.min.js" Localizable="false" OnDemand="false" runat="server"/>
<SharePoint:ScriptLink ID="BootstrapScriptLink" Language="javascript" Name="~sitecollection/_layouts/15/GSoft.Dynamite.Design.Bootstrap/JS/bootstrap.js" Localizable="false" OnDemand="false" runat="server"/>
<SharePoint:ScriptLink ID="BootstrapCustomScriptLink" Language="javascript" Name="~sitecollection/_layouts/15/GSoft.Dynamite.Design.Bootstrap/JS/bootstrap-custom.js" Localizable="false" OnDemand="false" runat="server"/>
<SharePoint:ScriptLink ID="ModernizrScriptLink" Language="javascript" Name="~sitecollection/_layouts/15/GSoft.Dynamite.Design.Bootstrap/JS/modernizr.2.6.2.custom.min.js" Localizable="false" OnDemand="false" runat="server"/>
<SharePoint:ScriptLink ID="RespondScriptLink" Language="javascript" Name="~sitecollection/_layouts/15/GSoft.Dynamite.Design.Bootstrap/JS/respond.min.js" Localizable="false" OnDemand="false" runat="server"/>
