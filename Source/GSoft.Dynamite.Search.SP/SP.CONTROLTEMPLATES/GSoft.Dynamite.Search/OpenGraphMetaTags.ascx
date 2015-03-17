﻿<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenGraphMetaTags.ascx.cs" Inherits="GSoft.Dynamite.Search.SP.SP.CONTROLTEMPLATES.GSoft.Dynamite.Search.OpenGraphMetaTags" %>
<meta property="og:site_name" content="<%= SPContext.Current.Web.Title %>" />
<meta property="og:type" content="website" />
<asp:PlaceHolder runat="server" ID="OpenGraph"></asp:PlaceHolder>
