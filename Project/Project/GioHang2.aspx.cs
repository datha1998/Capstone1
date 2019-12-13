using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class GioHang2 : System.Web.UI.Page
{
    string stncon = @"Data Source=DESKTOP-00I6SNN\SQLEXPRESS;Initial Catalog=DuyTan_Library;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        if (Request.Cookies["username"] == null) return;
        this.docDL();
    }
    private void docDL()
    {
        try
        {
            string q = "select donhang.id_sanpham, TenSanPham,GiaSP,soluong,"
            + "soluong*GiaSP as thanhtien from donhang,SanPham "
            + " where SanPham.id_SanPham = donhang.id_SanPham";
            SqlDataAdapter da = new SqlDataAdapter(q, stncon);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
            //Tính tổng thành tiền: duyệt DataTable
            double tong = 0;
            foreach (DataRow row in dt.Rows)
            {
                double thanhtien = Convert.ToDouble(row["thanhtien"]);
                tong = tong + thanhtien;
            }
            /*for (int i = 0; i < dt.Rows.Count; i++) {
            double thanhtien = double.Parse(dt.Rows[i]["thanhtien"]);
            tong = tong + thanhtien;
            }*/
            this.Label1.Text = "Tổng thành tiền: " + tong + " đồng";
        }
        catch (SqlException ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["username"] == null) return;
        string ten = Request.Cookies["username"].Value;
        string mahang = ((LinkButton)sender).CommandArgument;
        string sql = "delete from donhang where id_sanpham ='"
        + mahang + "' and username ='" + ten + "'";
        SqlConnection con = new SqlConnection(stncon);
        try
        {
            con.Open();
            SqlCommand command = new SqlCommand(sql, con);
            command.ExecuteNonQuery();

        }
        catch (SqlException err) { Response.Write(err.Message); }
        finally { con.Close(); }
        this.docDL();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["username"] == null) return;
        Button sua = (Button)sender;
        string mahang = sua.CommandArgument;
        GridViewRow item = (GridViewRow)sua.Parent.Parent;
        string soluong = ((TextBox)item.FindControl("TextBox1")).Text;
        string ten = Request.Cookies["username"].Value;
        SqlConnection con = new SqlConnection(stncon);
        String sql = "update donhang set soluong=" + soluong
        + " where username='" + ten + "' and id_sanpham='" + mahang + "'";
        try
        {
            con.Open();
            SqlCommand command = new SqlCommand(sql, con);
            command.ExecuteNonQuery();
        }
        catch (SqlException err) { Response.Write(err.Message); }
        finally
        {
            con.Close();
        }
        this.docDL();
    }

}