using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class GioHang : System.Web.UI.Page
{
    string con = @"Data Source=DESKTOP-00I6SNN\SQLEXPRESS;Initial Catalog=DuyTan_Library;Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string q = "select donhang.id_sanpham,TenSanPham,GiaSP,soluong,"
            + "soluong*GiaSP as thanhtien from donhang,SanPham "
            + " where SanPham.id_SanPham = donhang.id_SanPham";
            SqlDataAdapter da = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
            //Tính tổng thành tiền: duyệt dataTable
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
}
