﻿using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using GSoft.Dynamite.Publishing.Contracts.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace GSoft.Dynamite.Publishing.SP.WebParts.ContactFormWebPart
{
    [ToolboxItemAttribute(false)]
    public class ContactFormWebPart : WebPart, IContactFormWebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string AscxPath = @"~/_CONTROLTEMPLATES/15/GSoft.Dynamite.Publishing.SP.WebParts/ContactFormWebPart/ContactFormWebPartUserControl.ascx";

        /// <summary>
        /// The email address to send contact form info
        /// </summary>
        [Personalizable(PersonalizationScope.Shared), WebBrowsable(true), WebDisplayName("Email address"), WebDescription(""), Category("Contact Form Configuration")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// The name of the template to use for the contact form
        /// </summary>
        [Personalizable(PersonalizationScope.Shared), WebBrowsable(true), WebDisplayName("Contact Form Template"), WebDescription(""), Category("Contact Form Configuration")]
        public string ContactFormTemplate { get; set; }

        protected override void CreateChildControls()
        {
            var ContactFormControl = Page.LoadControl(AscxPath) as ContactFormWebPartUserControl;

            if (ContactFormControl != null)
            {
                ContactFormControl.EmailAddress = this.EmailAddress;
                ContactFormControl.ContactFormTemplate = this.ContactFormTemplate;

                this.Controls.Add(ContactFormControl);
            }
        }
    }
}