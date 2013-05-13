<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
    }
        
    void Application_Error(object sender, EventArgs e) 
    {
        Response.Write("<b>A server error has occured</b><br />");
        Response.Write("Please try again later. If the error persists, contact the administrator.");
        //Server.ClearError();
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
    }

    protected void Application_OnEndRequest()
    {
       /* Response.Write("<div class=\"bottom\"><hr />This page was served at " +
            DateTime.Now.ToString());
        */
    }
       
</script>
