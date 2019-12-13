using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class dangnhap : System.Web.UI.Page
{
    string con = @"Data Source=DESKTOP-00I6SNN\SQLEXPRESS;Initial Catalog=DuyTan_Library;Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;      
    }

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        string ten = this.Login1.UserName;
        string mk = this.Login1.Password;
        string sql = "select * from khachhang where username='"+ ten + "' and password ='" + mk + "'";
        DataTable table = new DataTable();
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(table);
        }
        catch (SqlException err)
        {
            Response.Write("<b>Error</b>" + err.Message + "<p/>");
        }
        if (table.Rows.Count != 0)
        {          
            Response.Cookies["username"].Value = ten;
            Response.Redirect("Trangchu.aspx?");
           
        }
        else this.Login1.FailureText = "Tên đăng nhập hay mật khẩu không đúng!";
    }

   
    
}