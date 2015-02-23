using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.SessionState;
using Autofac;
using GSoft.Dynamite.Extensions;
using GSoft.Dynamite.Logging;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace GSoft.Dynamite.Publishing.SP.Layouts.Handlers
{
    /// <summary>
    /// HttpHandler to clear the application and session cache
    /// </summary>
    public class DynamiteEmailService : IHttpHandler
    {
        private ILogger logger;

        #region IHttpHandler Members

        /// <summary>
        /// Gets a value indicating whether another request can use the <see cref="T:System.Web.IHttpHandler"/> instance.
        /// </summary>
        /// <value></value>
        /// <returns>true if the <see cref="T:System.Web.IHttpHandler"/> instance is reusable; otherwise, false.
        /// </returns>
        public bool IsReusable
        {
            get { return false; }
        }

        /// <summary>
        /// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler"/> interface.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpContext"/> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
        public void ProcessRequest(HttpContext context)
        {
            this.logger = PublishingContainerProxy.Current.Resolve<ILogger>();

            try
            {
                // Gets the parameters
                var subject = context.Request["subject"].ToString();
                var body = context.Request["content"].ToString();
                var emailTo = context.Request["emailTo"].ToString();

                // Sends the email with elevated privileges
                ElevationExtensions.RunAsSystem(
                    SPContext.Current.Web, 
                    (elevatedWeb) =>
                {
                    SPUtility.SendEmail(elevatedWeb, true, false, emailTo, subject, body);
                });

                // empty JSON object in response to prevent it from exploding the jQuery.ajax call handling
                context.Response.ContentType = "application/json";
                context.Response.Write("{}");
            }
            catch (Exception ex)
            {
                // Make sure the exception keeps bubbling up with full stack trace
                this.logger.Exception(ex);
                throw;
            }
        }
        #endregion
    }
}