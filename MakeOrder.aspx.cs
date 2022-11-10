using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

namespace Wildberries_Courier
{
    public partial class MakeOrder : Page
    {
        private SqlConnection sqlConnection = null;
        protected async void Page_Load(object sender, EventArgs e)
        {
            
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            HttpCookie login = Request.Cookies["login"];

            HttpCookie sign = Request.Cookies["sign"];

            if (login == null && sign == null) Response.Redirect("Default.aspx");

            if (login == null && sign == null)
            {
                String script = "alert('Такой логин уже есть')";

                ClientScript.RegisterClientScriptBlock(this.GetType(), "MessageBox", script, true);
            }
        }
        protected async void Button1_Click(object sender, EventArgs e)
        {
            bool VseSuper = false;
            Dictionary<string, string> db = new Dictionary<string, string>();

            SqlCommand getUsersCredCmd = new SqlCommand("SELECT [SecondName], [Code] FROM [Order]", sqlConnection);

            SqlDataReader sqlReader = null;

            try
            {
                sqlReader = await getUsersCredCmd.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    db.Add(Convert.ToString(sqlReader["SecondName"]), Convert.ToString(sqlReader["Code"]));
                }
            }
            catch
            {

            }
            finally
            {
                if (sqlReader != null) sqlReader.Close();
            }

            if (TextBox4.Text == db[TextBox2.Text])
            {
                HttpCookie secondname = new HttpCookie("secondname", TextBox1.Text);

                HttpCookie code = new HttpCookie("code", SignGenerator.GetSign(TextBox1.Text + "bytepp"));

                Response.Cookies.Add(secondname);

                Response.Cookies.Add(code);

            }

            if (!db.Keys.Contains(TextBox3.Text))
            {
                SqlCommand regUser = new SqlCommand("INSERT INTO [Data] (Address, NumberPhone)VALUES(@Address, @NumberPhone)", sqlConnection);
                regUser.Parameters.AddWithValue("Address", TextBox3.Text);
                regUser.Parameters.AddWithValue("NumberPhone", TextBox5.Text);

                await regUser.ExecuteNonQueryAsync();
                VseSuper = true;
            }
            if (VseSuper == true) Response.Redirect("OrderDone.aspx", false);

            //SqlCommand getUser = new SqlCommand("SELECT [SecondName], [Code] FROM [Empl]", sqlConnection);
            /* MailAddress fromMailAddress = new MailAddress("testforsendingtext123@gmail.com", "Danya");
             MailAddress toMailAddress = new MailAddress("testforsendingtext123@gmail.com", "Danil");

             using (MailMessage mailMessage = new MailMessage(fromMailAddress, toMailAddress))
             using (SmtpClient smtpClient = new SmtpClient())
             {
                 mailMessage.Subject = "Текст";
                 mailMessage.Body = "Основной текст";

                 smtpClient.Host = "smpt.gmail.com";
                 smtpClient.Port = 587;
                 smtpClient.EnableSsl = true;
                 smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                 smtpClient.UseDefaultCredentials = false;
                 smtpClient.Credentials = new NetworkCredential(fromMailAddress.Address, "qywter1423");

                 smtpClient.Send(mailMessage);
             }*/
        }



    }
}
