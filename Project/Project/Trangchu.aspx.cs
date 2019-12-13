using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class Trangchu : System.Web.UI.Page
{ 
    protected void Page_Load(object sender, EventArgs e)
    {      
        
    }



    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string id_sanpham = ((ImageButton)sender).CommandArgument;
        Response.Redirect("Chitiet.aspx?idsanpham=" + id_sanpham);
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string id_sanpham = ((LinkButton)sender).CommandArgument;
        Response.Redirect("Chitiet.aspx?idsanpham=" + id_sanpham);
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        string id_sanpham = ((LinkButton)sender).CommandArgument;
        Response.Redirect("Chitiet.aspx?idsanpham=" + id_sanpham);
    }
}