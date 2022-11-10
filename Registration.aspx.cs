using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wildberries_Courier
{
    public partial class Registration : System.Web.UI.Page
    {
        private SqlConnection sqlConnection = null;
        protected async void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

        }
        protected async void Button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> db = new Dictionary<string, string>();

            SqlCommand getUsersCredCmd = new SqlCommand("SELECT [Login], [Password] FROM [Users]", sqlConnection);

            SqlDataReader sqlReader = null;

            try
            {
                sqlReader = await getUsersCredCmd.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    db.Add(Convert.ToString(sqlReader["Login"]), Convert.ToString(sqlReader["Password"]));
                }
            }
            catch
            {

            }
            finally
            {
                if (sqlReader != null) sqlReader.Close();
            }

            if (!db.Keys.Contains(TextBox1.Text))
            {
                SqlCommand regUser = new SqlCommand("INSERT INTO [Users] (Login, Password)VALUES(@Login, @Password)", sqlConnection);
                SqlCommand regUser1 = new SqlCommand("INSERT INTO [Order] (FirstName, SecondName)VALUES(@FirstName, @SecondName)", sqlConnection);
                regUser.Parameters.AddWithValue("Login", TextBox1.Text);
                regUser.Parameters.AddWithValue("Password", TextBox2.Text);
                regUser1.Parameters.AddWithValue("FirstName", TextBox3.Text);
                regUser1.Parameters.AddWithValue("SecondName", TextBox4.Text);

                Response.Redirect("Login.aspx", false);

                await regUser.ExecuteNonQueryAsync();
                await regUser1.ExecuteNonQueryAsync();
            }
            else
            {
                String script = "alert('Такой логин уже есть')";

                ClientScript.RegisterClientScriptBlock(this.GetType(), "MessageBox", script, true);
            }
            Random rnd = new Random();
            int num = rnd.Next(100, 999);
            SqlCommand regUser2 = new SqlCommand("INSERT INTO [Order] (Code)VALUES(@Code)", sqlConnection);
            regUser2.Parameters.AddWithValue("Code", Convert.ToString(num));
            await regUser2.ExecuteNonQueryAsync();     
        }
        protected void Page_Unload(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }
    }
}