<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChildNodes.ascx.cs" Inherits="GSoft.Dynamite.Portal.SP.Publishing.WebParts.ChildNodes.ChildNodes" %>

<div id="<%=this.UniquePerRequestId %>" class="child-nodes">
    <div class="nodes" data-bind="foreach: Nodes">
        <div class="item">
            <a data-bind="attr: {href: Url, title: Title}">
                <div class="title item-block">
                    <div class="inside">
                        <h3 data-bind="text: Title"></h3>
                        <div class="icon icon-arrow-teal"></div>
                    </div>
                </div>
            </a>
        </div>
    </div>
</div>

<script>
    var childNodesParams = {};
    childNodesParams.ParentElementId = '<%=this.UniquePerRequestId %>';
    childNodesParams.RawChildNodes = <%=this.NodesJSON %>;
    GSoft.Dynamite.Portal.ChildNodes.initialize(childNodesParams);
</script>
