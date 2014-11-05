<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilteredProductShowcaseWebPartUserControl.ascx.cs" Inherits="GSoft.Dynamite.Publishing.SP.WebParts.FilteredProductShowcaseWebPart.FilteredProductShowcaseWebPartUserControl" %>

<script type="text/javascript">

    window.Dynamite = window.Dynamite || {};

    (function (FilteredProductShowcase, $, undefined) {

        // Private properties
        var searchRestApi = "";

        // Public properties
        FilteredProductShowcase.SearchQuery = <%=this.SearchQuery%>;
        FilteredProductShowcase.SelectProperties = <%=this.SelectPropertiesSerialized%>;
        FilteredProductShowcase.FilterDefinitions = <%=this.FilterDefinitionsSerialized%>;
        FilteredProductShowcase.Items = null;
        FilteredProductShowcase.FilteredItems = null;
        FilteredProductShowcase.Filters = null;

        FilteredProductShowcase.ExecuteSearchQuery = function () {

        };

        FilteredProductShowcase.ResetFilters = function () {

        }

    }(Dynamite.FilteredProductShowcase = Dynamite.FilteredProductShowcase || {}, jq110));
</script>
