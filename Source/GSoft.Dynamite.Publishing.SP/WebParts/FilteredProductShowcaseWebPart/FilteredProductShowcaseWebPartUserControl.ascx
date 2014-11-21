<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilteredProductShowcaseWebPartUserControl.ascx.cs" Inherits="GSoft.Dynamite.Publishing.SP.WebParts.FilteredProductShowcaseWebPart.FilteredProductShowcaseWebPartUserControl" %>

<script type="text/javascript">
    // Launch the search
    GSoft.Dynamite.FilteredProductShowcase.Initialize("<%=this.SearchQuery%>", "<%=this.SelectProperties%>", '<%=this.FilterDefinitions%>', "<%=this.ItemKnockoutTemplate%>", "<%=this.ItemJavaScriptViewModel%>");
</script>

<div class="showcase clearfix">
    <div class="section filters-header"></div>
    <div class="section filters-container">
        <div class="full-width">
            <h2 data-bind="text: FiltersTitle"></h2>
            <div class="filters clearfix" data-bind="foreach: Filters">
                <div class="filter" data-bind="template: { name: function () { return $data.TemplateName; }, data: $data }">
                </div>
            </div>
            <div class="filter-reset-container full-width clearfix">
                <div class="filter-reset" data-bind="click: ResetFilters">
                    <span class="filter-reset-button"></span>
                    <span class="filter-reset-label" data-bind="text: FiltersResetLabel"></span>
                </div>
            </div>
        </div>
    </div>
    <div class="section filters-footer"></div>
    <div class="section items-header"></div>
    <div class="section items-container">
        <div class="full-width clearfix">
            <ul data-bind="foreach: { data: FilteredItems }">
                <li data-bind="template: { name: function () { return $root.ItemKnockoutTemplate; }, data: $data }"></li>
            </ul>
        </div>
    </div>
    <div class="section items-footer"></div>
</div>
