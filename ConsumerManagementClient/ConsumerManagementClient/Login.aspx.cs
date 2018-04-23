using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumerManagementClient
{
    public partial class Login : System.Web.UI.Page
    {
        ConsumerManagementService.ConsumerManagementServiceClient client = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            client = new ConsumerManagementService.ConsumerManagementServiceClient();

            btnLogin.Click += new System.EventHandler(this.btn_Clicked);
            btnReset.Click += new System.EventHandler(this.btn_Clicked);
            lblError.ForeColor = System.Drawing.Color.Red;
        }

        private void btn_Clicked(object sender, EventArgs e)
        {
            if (sender == btnLogin)
            {
                ConsumerManagementService.Login login = new ConsumerManagementService.Login();
                login.Username = tbUsername.Text;
                login.Password = tbPassword.Text;

                try
                {
                    client.authenticate(login);
                    Session["username"] = login.Username;
                    Session["client"] = client;
                    Response.Redirect("SearchByConsumerID.aspx");
                }
                catch (FaultException<ConsumerManagementService.ConsumerFault> obj)
                {
                    lblError.Text = obj.Detail.Error + " : " + obj.Detail.Details;
                }
            }
            else if (sender == btnReset)
            {
                ClearControls();
            }
        }

        private void ClearControls()
        {
            tbUsername.Text = "";
            tbPassword.Text = "";
            lblError.Text = "";
        }
    }
}