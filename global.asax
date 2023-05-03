<%@ Application Language="C#" Inherits="System.Web.HttpApplication" %>
protected void Application_BeginRequest(Object sender, EventArgs e)
{
    if (Context.Response.StatusCode == 404)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.RedirectToRoute("Default",
            new { controller = "Home", action = "Index" });
        HttpContext.Current.Response.End();
    }
}