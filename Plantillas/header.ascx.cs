﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Web.Services;
using System.Collections.Generic;

public partial class Plantillas_WebUserControl : System.Web.UI.UserControl
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(Boolean)Session["logged"])
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            asignarCve();
        }
    }

    protected void asignarCve()
    {
        txtIdUsuario.Text = Session["cve"].ToString();
    }
      
}
