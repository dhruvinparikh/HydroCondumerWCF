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
    public partial class ConsumerForm : System.Web.UI.Page
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

            lblConsumerId.ForeColor = System.Drawing.Color.Red;
            lblFirstName.ForeColor = System.Drawing.Color.Red;
            lblLastName.ForeColor = System.Drawing.Color.Red;
            lblCity.ForeColor = System.Drawing.Color.Red;
            lblBillAmount.ForeColor = System.Drawing.Color.Red;
            lblDueDate.ForeColor = System.Drawing.Color.Red;

            btnAdd.Click += new EventHandler(this.btn_Click);
            btnReset.Click += new EventHandler(this.btn_Click);

            if (Session["operation"] != null && Session["operation"].Equals("edit"))
            {
                List<ConsumerManagementService.Consumer> list = client.getConsumerID(Session["consumerId"].ToString()).ToList();
                tbConsumerID.Text = list[0].ConsumerID.ToString();
                tbConsumerID.Enabled = false;
                tbFirstName.Text = list[0].FirstName;
                tbLastName.Text = list[0].LastName;
                tbCity.Text = list[0].City;
                tbBillAmount.Text = list[0].BillAmount.ToString();
                tbDueDate.Text = list[0].DueDate.ToString("yyyy-MM-dd");
                btnAdd.Text = "Update";
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (sender == btnAdd)
            {
                try
                {
                    ConsumerManagementService.Consumer consumer = new ConsumerManagementService.Consumer();
                    consumer.ConsumerID = Convert.ToInt64(tbConsumerID.Text);
                    consumer.FirstName = tbFirstName.Text;
                    consumer.LastName = tbLastName.Text;
                    consumer.City = tbCity.Text;
                    consumer.BillAmount = Convert.ToDouble(tbBillAmount.Text);
                    consumer.DueDate = Convert.ToDateTime(tbDueDate.Text);
                    lblResult.ForeColor = System.Drawing.Color.Blue;
                    if (Session["operation"] != null && Session["operation"].Equals("edit"))
                    {

                        int i = client.updateConsumer(consumer);
                        lblResult.ForeColor = System.Drawing.Color.Blue;
                        lblResult.Text = i + " Record updated Successfully";
                    }
                    else
                    {

                        int c = client.add(consumer);
                        lblResult.ForeColor = System.Drawing.Color.Blue;
                        lblResult.Text = c + " Record added Successfully";
                    }
                    clearControls();
                }
                catch (FaultException<ConsumerManagementService.ConsumerFault> obj)
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = obj.Detail.Error + " : " + obj.Detail.Details;
                    lblConsumerId.Text = obj.Detail.consumerID;
                    lblFirstName.Text = obj.Detail.firstName;
                    lblLastName.Text = obj.Detail.lastName;
                    lblCity.Text = obj.Detail.city;
                    lblBillAmount.Text = obj.Detail.billAmount;
                    lblDueDate.Text = obj.Detail.dueDate;
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
                catch (Exception obj)
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = obj.Message + " : " + "Invalid field/s found";
                }

            }
            else if (sender == btnReset)
            {
                clearControls();
                lblResult.Text = "";
            }
        }

        private void clearControls()
        {

            tbConsumerID.Text = "";
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbCity.Text = "";
            tbBillAmount.Text = "";
            tbDueDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblConsumerId.Text = "";
            lblFirstName.Text = "";
            lblLastName.Text = "";
            lblBillAmount.Text = "";
            lblCity.Text = "";
            lblDueDate.Text = "";
            tbConsumerID.Enabled = true;
            btnAdd.Text = "Add";
            Session["operation"] = "add";
        }

        protected void lblResult_Unload(object sender, EventArgs e)
        {
            //Session["operation"] = "add";
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}