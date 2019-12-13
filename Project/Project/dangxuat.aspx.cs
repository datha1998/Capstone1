using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dangxuat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookies = new HttpCookie("username");
        cookies.Expires = DateTime.Now.AddDays(-1);
        Response.Cookies.Add(cookies);
        Response.Redirect("Trangchu.aspx");
    }
}