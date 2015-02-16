<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactFormWebPartUserControl.ascx.cs" Inherits="GSoft.Dynamite.Publishing.SP.WebParts.ContactFormWebPart.ContactFormWebPartUserControl" %>
<script type="text/javascript" src="../../../../_layouts/15/GSoft.Dynamite.Publishing/Js/jquery.validate.min.js"></script>
<script type="text/javascript" src="../../../../_layouts/15/GSoft.Dynamite.Publishing/Js/jquery.noty.packaged.min.js"></script>
<div class="contact-form">
    <div class="contact-form form-header"></div>
    <div class="contact-form form-body">
            <div data-bind="template: { name: function () { return $root.Form.TemplateName; }, data: $root.Form }"></div>
            <span id="form-submit" class="form-submit">Send your message</span>
    </div>
    <div class="contact-form form-footer">
        <div class="contact-form email-body" style="display: none" data-bind="template: { name: function () { return $root.EmailTemplate; }, data: $data }"></div>
    </div>
</div>
<script type="text/javascript">
    GSoft.Dynamite.ContactForm.Initialize("<%=this.EmailAddress%>", "<%=this.ContactFormTemplate%>", "<%=this.JavaScriptViewModel%>");
</script>
