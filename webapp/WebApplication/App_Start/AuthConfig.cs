
using System.Web;
using K9.Base.DataAccessLayer.Database;

namespace K9.WebApplication
{
    public class AuthConfig
	{
		public static void InitialiseWebSecurity()
		{
			DatabaseInitialiser<Db>.InitialiseWebsecurity();
		}

	    public static void SetXframeOptions()
	    {
	        HttpContext.Current.Response.Headers.Add("X-Frame-Options", "https://shubhraartist.wixsite.com");
	    }
	}
}