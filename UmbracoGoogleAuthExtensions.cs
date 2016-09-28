using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Umbraco.Web.Security.Identity;
using Microsoft.Owin.Security.Google;
using Constants = Umbraco.Core.Constants;

namespace UmbracoApp
{
    public static class UmbracoGoogleAuthExtensions
    {
        ///  <summary>
        ///  Configure google sign-in
        ///  </summary>
        ///  <param name="app"></param>
        ///  <param name="clientId"></param>
        ///  <param name="clientSecret"></param>
        /// <param name="caption"></param>
        /// <param name="style"></param>
        /// <param name="icon"></param>
        /// <remarks>
        ///  
        ///  Nuget installation:
        ///      Microsoft.Owin.Security.Google
        /// 
        ///  Google account documentation for ASP.Net Identity can be found:
        ///  
        ///  http://www.asp.net/web-api/overview/security/external-authentication-services#GOOGLE
        ///  
        ///  Google apps can be created here:
        ///  
        ///  https://developers.google.com/accounts/docs/OpenIDConnect#getcredentials
        ///  
        ///  </remarks>
        public static void ConfigureBackOfficeGoogleAuth(this IAppBuilder app, string clientId, string clientSecret,
            string caption = "Google", string style = "btn-google-plus", string icon = "fa-google-plus")
        {
            var googleOptions = new GoogleOAuth2AuthenticationOptions
            {
                ClientId = clientId,
                ClientSecret = clientSecret, 
                //In order to allow using different google providers on the front-end vs the back office,
                // these settings are very important to make them distinguished from one another.
                SignInAsAuthenticationType = Constants.Security.BackOfficeExternalAuthenticationType,
                //  By default this is '/signin-google', you will need to change that default value in your
                //  Google developer settings for your web-app in the "REDIRECT URIS" setting
                CallbackPath = new PathString("/umbraco-google-signin")
            };
            googleOptions.ForUmbracoBackOffice(style, icon);
            googleOptions.Caption = caption;

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ExternalCookie
            }); // Active

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie); //passive
            app.SetDefaultSignInAsAuthenticationType(DefaultAuthenticationTypes.ExternalCookie);

            app.UseGoogleAuthentication(googleOptions);   
        }

    }
        
}