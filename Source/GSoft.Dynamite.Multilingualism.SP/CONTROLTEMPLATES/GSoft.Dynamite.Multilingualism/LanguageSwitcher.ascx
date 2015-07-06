<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LanguageSwitcher.ascx.cs" Inherits="GSoft.Dynamite.Multilingualism.SP.CONTROLTEMPLATES.GSoft.Dynamite.Multilingualism.LanguageSwitcher" %>

<script type="text/javascript">
    if (typeof Dynamite !== 'undefined' && typeof Dynamite.Multilingualism !== 'undefined') {
        Dynamite.Multilingualism.AppendUrlHashToLanguageSwitcher(".language-switcher");
    }
</script>

<asp:PlaceHolder ID="Placeholder" runat="server">
    <asp:Repeater ID="LabelsRepeater" runat="server">
        <ItemTemplate>
            <a class="ms-promotedActionButton language-switcher-link <%# DataBinder.Eval(Container.DataItem, "LinkCssClass") %>" title="<%# DataBinder.Eval(Container.DataItem, "Title") %>" href="<%# DataBinder.Eval(Container.DataItem, "Url") %>">
                <span style="height:16px;width:16px;position:relative;display:inline-block;overflow:hidden;" class="s4-clust ms-promotedActionButton-icon">
                    <img src="/_layouts/15/images/spcommon.png?rev=23" alt="Follow" style="position: absolute; left: -177px; top: -174px;">
                </span>
                <span class="ms-promotedActionButton-text language-switcher-label <%# DataBinder.Eval(Container.DataItem, "CssClass") %>"><%# DataBinder.Eval(Container.DataItem, "Title") %></span>
            </a>
        </ItemTemplate>
    </asp:Repeater>
</asp:PlaceHolder>
