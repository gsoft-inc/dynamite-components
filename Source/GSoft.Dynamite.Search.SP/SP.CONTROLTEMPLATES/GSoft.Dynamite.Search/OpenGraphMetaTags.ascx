<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="GSoft" Namespace="GSoft.Dynamite.Search.Core.Controls" Assembly="GSoft.Dynamite.Search.Core, Version=15.0.0.0, Culture=neutral, PublicKeyToken=1e3bb3fbc94d83df" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenGraphMetaTags.ascx.cs" Inherits="GSoft.Dynamite.Search.SP.SP.CONTROLTEMPLATES.GSoft.Dynamite.Search.SocialMetaTags" %>
<%@ Register TagPrefix="cc1" Namespace="Microsoft.Office.Server.Search.WebControls" Assembly="Microsoft.Office.Server.Search, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<meta property="og:site_name" />
<GSoft:TemplatedControlWrapper ID="OpenGraphTitle" runat="server">
    <Control>      
<Control type="Microsoft.Office.Server.Search.WebControls.CatalogItemReuseWebPart" assembly="Microsoft.Office.Server.Search, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" NumberOfItems="1"  UseSharedDataProvider="True"  QueryGroupName="SingleItem" SelectedPropertiesJson="[&quot;Title&quot;]" />
    </Control>
    <contenttemplate><meta property="og:title" content="$Value$"/></contenttemplate>
</GSoft:TemplatedControlWrapper>
<GSoft:ImageElementControlWrapper ID="OpenGraphImage" runat="server">
    <Control>      
<Control type="Microsoft.Office.Server.Search.WebControls.CatalogItemReuseWebPart" assembly="Microsoft.Office.Server.Search, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" NumberOfItems="1"  UseSharedDataProvider="True"  QueryGroupName="SingleItem" SelectedPropertiesJson="[&quot;PublishingImage&quot;]" />
    </Control>
    <contenttemplate><meta property="og:image" content="$Url$"/></contenttemplate>
</GSoft:ImageElementControlWrapper>
<GSoft:UrlElementControlWrapper ID="OpenGraphUrl" runat="server">
    <Control>      
<Control type="Microsoft.Office.Server.Search.WebControls.CatalogItemReuseWebPart" assembly="Microsoft.Office.Server.Search, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" NumberOfItems="1"  UseSharedDataProvider="True"  QueryGroupName="SingleItem" SelectedPropertiesJson="[&quot;Path&quot;]" />
    </Control>
    <contenttemplate><meta property="og:url" content="$Value$"/></contenttemplate>
</GSoft:UrlElementControlWrapper>
<GSoft:TemplatedControlWrapper ID="OpenGraphDescription" runat="server">
    <Control>      
        <Control type="Microsoft.Office.Server.Search.WebControls.CatalogItemReuseWebPart" assembly="Microsoft.Office.Server.Search, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" NumberOfItems="1"  UseSharedDataProvider="True"  QueryGroupName="SingleItem" SelectedPropertiesJson="[&quot;SeoMetaDescriptionOWSTEXT&quot;]"/>
    </Control>
    <contenttemplate>
        <meta property="og:description" content="$Value$"/>
    </contenttemplate>
</GSoft:TemplatedControlWrapper>
<meta property="og:type" content="website" />
