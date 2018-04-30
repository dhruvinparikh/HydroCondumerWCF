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
    public partial class DueDate : System.Web.UI.Page
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
            lblError.ForeColor = System.Drawing.Color.Red;
        }

        protected void duedateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<ConsumerManagementService.Consumer> list = null;
                switch (duedateList.SelectedItem.Value)
                {
                    case "0":
                        list = client.getDefaulter(DateTime.Now.Date).ToList();
                        break;
                    case "1":
                        list = client.getRegular(DateTime.Now.Date).ToList();
                        break;
                }
                consumerList.DataSource = list;
                consumerList.DataBind();
            }
            catch (FaultException<ConsumerManagementService.ConsumerFault> obj)
            { 
                lblError.Text = obj.Detail.Error+" : "+obj.Detail.Details;
                consumerList.DataSource = null;
                consumerList.DataBind();
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

        protected void HyperLink1_Unload(object sender, EventArgs e)
        {
            //Session["operation"] = "add";
        }

        protected void consumerList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session["operation"] = "edit";
            Session["consumerId"] = consumerList.Rows[e.NewEditIndex].Cells[3].Text;
            Response.Redirect("ConsumerForm.aspx");
        }

        protected void consumerList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["consumerId"] = consumerList.Rows[e.RowIndex].Cells[3].Text;
            Response.Redirect("DeleteConsumerForm.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}