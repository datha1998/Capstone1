using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class GioHang3 : System.Web.UI.Page
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
            string ten = Request.Cookies["username"].Value;
            string q = "select donhang.id_sanpham, TenSanPham,GiaSP,soluong,"
             + "soluong*GiaSP as thanhtien from donhang,SanPham,khachhang "
             + " where SanPham.id_SanPham = donhang.id_SanPham "
             + "AND donhang.username = khachhang.username "
             + "AND donhang.username ='"+ten+"'";
            SqlDataAdapter da = new SqlDataAdapter(q, stncon);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.GridView1.DataSource = dt; this.GridView1.DataBind();
            //Tính tổng thành tiền: duyệt dataTable
            double tong = 0;
            foreach (DataRow row in dt.Rows)
            {
                double thanhtien = Convert.ToDouble(row["thanhtien"]);
                tong = tong + thanhtien;
            }
            this.Label1.Text = "Tổng thành tiền: " + tong + " đồng";
        }

        catch (SqlException ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["username"] == null) return;
        string ten = Request.Cookies["username"].Value;
        foreach (GridViewRow row in this.GridView1.Rows)
        {
            if (((CheckBox)row.FindControl("CheckBox1")).Checked)
            {
                string mahang =
                ((HiddenField)row.FindControl("HiddenField1")).Value;
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
            }
        }
        this.docDL();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["uername"] == null) return;
        string ten = Request.Cookies["username"].Value;
        foreach (GridViewRow row in this.GridView1.Rows)
        {
            if (((CheckBox)row.FindControl("CheckBox1")).Checked)
            {
                string mahang = ((HiddenField)row.FindControl("HiddenField1")).Value;
                string soluong = ((TextBox)row.FindControl("TextBox1")).Text;
                string sql = "update donhang set soluong = " + soluong
                + " where id_sanpham ='" + mahang
                + "' and username ='" + ten + "'";
                SqlConnection con = new SqlConnection(stncon);
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand(sql, con);
                    command.ExecuteNonQuery();
                }
                catch (SqlException err) { Response.Write(err.Message); }
                finally { con.Close(); }
            }
        }
        this.docDL();
    }
}