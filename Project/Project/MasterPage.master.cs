using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
    string con= @"Data Source=DESKTOP-00I6SNN\SQLEXPRESS;Initial Catalog=DuyTan_Library;Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Page.IsPostBack) return;
        try
        {
            string q = "select * from Loai";
            SqlDataAdapter da = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.DataList1.DataSource = dt;
            this.DataList1.DataBind();

            if (Request.Cookies["username"] == null)
            {
                lblLogin.Text = "Đăng Nhập";
                lblLogout.Text = "";
            }
            else
            {
                string ten = Request.Cookies["username"].Value;
                lblUser.Text = "Xin chao :" + ten;
                lblGioHang.Text = "Giỏ Hàng  ";
                lblLogout.Text = "Đăng xuất  ";
                lblLogin.Text = "";
            }
        }
        catch (SqlException ex)
        {
            Response.Write(ex.Message);
        }

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string id_loai= ((LinkButton)sender).CommandArgument;
        Response.Redirect("Sanpham.aspx?idloai="+ id_loai);
    }

    protected void btn_timkiem_Click(object sender, EventArgs e)
    {
        string q;
            string timsach = txtTimKiem.Text;
            q = "select * from SanPham where TacGia like N'%" + timsach + "%'";
        

        try
        {
            SqlDataAdapter da = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response.Redirect("TimSach.aspx?timsach=" + timsach);
        }
        catch (SqlException ex)
        {
            Response.Write(ex.Message);
        }
    }
}
