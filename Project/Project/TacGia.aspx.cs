using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class TacGia : System.Web.UI.Page
{

    string con = @"Data Source=DESKTOP-00I6SNN\SQLEXPRESS;Initial Catalog=DuyTan_Library;Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        string q;
        if (Request.QueryString["tacgia"] == null)
            q = "select * from Tacgia ORDER BY NEWID()";
        else
        {
            string tacgia = Request.QueryString["tacgia"];
            q = "select * from SanPham where TacGia like N'%" + tacgia + "%'";
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
        string id_Tacgia = ((ImageButton)sender).CommandArgument;
        Response.Redirect("ChitietTacGia.aspx?tacgia=" + id_Tacgia);
    }
}