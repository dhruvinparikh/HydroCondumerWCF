using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumerManagementClient
{
    public partial class DeleteConsumerForm : System.Web.UI.Page
    {
        ConsumerManagementService.ConsumerManagementServiceClient client = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblUsername.Text = "Hello " + Session["username"];
                if (Session["username"].ToString() == "")
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx");
            }
            client = (ConsumerManagementService.ConsumerManagementServiceClient)
                Session["client"];

            btnYes.Click += new System.EventHandler(this.btn_Clicked);
            btnNo.Click += new System.EventHandler(this.btn_Clicked);
            List<ConsumerManagementService.Consumer> list = client.getConsumerID(Session["consumerId"].ToString()).ToList();
            lblConsumerId.Text = list[0].ConsumerID.ToString();
            lblFirstName.Text = list[0].FirstName;
            lblLastName.Text = list[0].LastName;
            lblCity.Text = list[0].City;
            lblBillAmount.Text = list[0].BillAmount.ToString();
            lblDueDate.Text = list[0].DueDate.ToString();
        }

        private void btn_Clicked(object sender, EventArgs e)
        {
            if(sender == btnYes)
            {
                try
                {
                    int i = client.deleteID(lblConsumerId.Text);
                    Table1.Rows.Clear();
                    lblResult.ForeColor = System.Drawing.Color.Blue;
                    lblResult.Text = i + " row deleted";
                }
                catch (SocketException)
                {
                    Session.Abandon();
                    Response.Redirect("Login.aspx");
                }
            }
            else if(sender == btnNo)
            {
                try
                {
                    Response.Redirect("SearchByConsumerID.aspx");
                }
                catch (SocketException obj)
                {
                    Session.Abandon();
                    Response.Redirect("Login.aspx");
                }
                catch (WebException obj)
                {
                    Session.Abandon();
                    Response.Redirect("Login.aspx");
                }
                catch (EndpointNotFoundException obj)
                {
                    Session.Abandon();
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}