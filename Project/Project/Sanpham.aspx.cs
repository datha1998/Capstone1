using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Sanpham : System.Web.UI.Page
{
    string con = @"Data Source=DESKTOP-00I6SNN\SQLEXPRESS;Initial Catalog=DuyTan_Library;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        string q;
        if (Request.QueryString["idloai"] == null)
         q = "select * from SanPham ORDER BY NEWID()";
        else
        {           
            string id_loai = Request.QueryString["idloai"];
            q = "select * from SanPham where id_loai = '" + id_loai + "'";
        }
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.DataList2.DataSource = dt;
            this.DataList2.DataBind();
        }
        catch (SqlException ex)
        {
            Response.Write(ex.Message);
        }
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