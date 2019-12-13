using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TimSach : System.Web.UI.Page
{
    string con = @"Data Source=DESKTOP-00I6SNN\SQLEXPRESS;Initial Catalog=DuyTan_Library;Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {
        string q;
        if (Request.QueryString["timsach"] == null)
            q = "select * from SanPham ORDER BY NEWID() ";

        else
        {
            string timsach = Request.QueryString["timsach"];
            q = "select * from SanPham where TenSanPham like N'%" + timsach + "%' or TacGia like N'%" + timsach + "%'";
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        Button mua = (Button)sender;
        string mahang = mua.CommandArgument.ToString();
        DataListItem item = (DataListItem)mua.Parent;
        string soluong = ((DropDownList)item.FindControl("ddlSoLuong")).Text;
        if (Request.Cookies["username"] == null) return;
        string ten = Request.Cookies["username"].Value;
        SqlConnection connect = new SqlConnection(con);
        connect.Open();
        string query = "select * from donhang "
        + "where username ='" + ten + "' and id_sanpham='" + mahang + "'";
        SqlCommand command = new SqlCommand(query, connect);
        SqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            reader.Close();
            command = new SqlCommand(
            "update donhang set soluong=soluong+" + soluong
            + " where username='" + ten + "' and id_sanpham='" + mahang + "'", connect);
        }
        else
        {
            reader.Close();
            command = new SqlCommand("insert into donhang "
            + "(username,id_sanpham,soluong) values('"
            + ten + "', '" + mahang + "'," + soluong + ")", connect);
        }

        command.ExecuteNonQuery();
        connect.Close();
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Server.Transfer("GioHang3.aspx");
    }
}