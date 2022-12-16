using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _111_1HW4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection o_Conn = new SqlConnection(
            ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString
            );


            o_Conn.Open();
            SqlDataAdapter o_A = new SqlDataAdapter("Select * from Users", o_Conn);
            DataSet o_D = new DataSet();
            o_A.Fill(o_D, "ds_Res");
            gd_View.DataSource = o_D;
            gd_View.DataBind();
            o_Conn.Close();
        }

        protected void btn_Insert_Click(object sender, EventArgs e)
        {
            SqlConnection o_Conn = new SqlConnection(
            ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString
            );

            o_Conn.Open();

            SqlDataAdapter o_A = new SqlDataAdapter("Select * from Users", o_Conn);
            DataSet o_D = new DataSet();
            o_A.Fill(o_D, "ds_Res");
            gd_View.DataSource = o_D;
            gd_View.DataBind();

            SqlCommand o_a = new SqlCommand("Insert into Users (Name, Birthday)" +
                "values(@Name, @Datetime)", o_Conn);
            o_a.Parameters.Add("@Name", SqlDbType.NVarChar, 50);
            o_a.Parameters["@Name"].Value = "阿貓阿狗";
            o_a.Parameters.Add("@Datetime", SqlDbType.DateTime);
            o_a.Parameters["@Datetime"].Value = "2000/10/10";
            o_A.InsertCommand = o_a;
            o_a.ExecuteNonQuery();

            o_Conn.Close();
        }
    }
}