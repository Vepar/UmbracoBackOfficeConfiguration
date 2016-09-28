using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Umbraco.Core;
using Umbraco.Core.Security;
using Umbraco.Web;
using Umbraco.Web.Security.Identity;
using Umbraco.IdentityExtensions;
using UmbracoApp;
using System.Configuration;
using Umbraco.Core.Logging;

//To use this startup class, change the appSetting value in the web.config called 
// "owin:appStartup" to be "UmbracoStandardOwinStartup"

[assembly: OwinStartup("UmbracoStandardOwinStartup", typeof(UmbracoStandardOwinStartup))]

namespace UmbracoApp
{
    /// <summary>
    /// The standard way to configure OWIN for Umbraco
    /// </summary>
    /// <remarks>
    /// The startup type is specified in appSettings under owin:appStartup - change it to "StandardUmbracoStartup" to use this class
    /// </remarks>
    public class UmbracoStandardOwinStartup : UmbracoDefaultOwinStartup
    {
        public override void Configuration(IAppBuilder app)
        {
            //ensure the default options are configured
            base.Configuration(app);


            //app.ConfigureBackOfficeGoogleAuth(
            //    "YOUR_CLIENT_ID",
            //    "YOUR_CLIENT_SECRET");

            // Test configuration
            // Adam Z.'s info
            //app.ConfigureBackOfficeGoogleAuth(
            //    "799603648346-ph3vsfsvs1d9rrucj2m7ft4cgmd821ah.apps.googleusercontent.com",
            //    "XEC362xl09jWBvle1K9Fpd4z");
            // David S.'s info
            //app.ConfigureBackOfficeGoogleAuth(
            //    "37648119734-0se2t87m4pjd74kdrj8l45kra1vvk1at.apps.googleusercontent.com",
            //    "qruBMiUJ1f6WZx3Cq4hi4ZJn");

            // Porchlight configuration
            var googleConsumerKey = ConfigurationManager.AppSettings["googleConsumerKey"]; ;
            var googleConsumerSecret = ConfigurationManager.AppSettings["googleConsumerSecret"];
            app.ConfigureBackOfficeGoogleAuth(googleConsumerKey, googleConsumerSecret);
        }
    }
}
