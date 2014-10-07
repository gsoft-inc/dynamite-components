<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LanguageSwitcher.ascx.cs" Inherits="GSoft.Dynamite.Multilingualism.SP.CONTROLTEMPLATES.GSoft.Dynamite.Multilingualism.LanguageSwitcher" %>

<script type="text/javascript">
    if (typeof Dynamite !== 'undefined' && typeof Dynamite.Multilingualism !== 'undefined') {
        Dynamite.Multilingualism.initialize("#language-swtcher-control");
    }
</script>

<asp:PlaceHolder ID="Placeholder" runat="server" Visible="<%# this.LanguageToggleService.IsVisible %>">
    <a id="language-toggle-control" title="<%= this.LabelText %>" class="ms-promotedActionButton" style="display: inline-block;" href="<%= this.LabelUrl %>"><span class="ms-promotedActionButton-text"><%= this.LabelText %></span></a>
</asp:PlaceHolder>
