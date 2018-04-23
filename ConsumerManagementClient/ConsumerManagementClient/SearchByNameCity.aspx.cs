using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumerManagementClient
{
    public partial class SearchByNameCity : System.Web.UI.Page
    {
        ConsumerManagementService.ConsumerManagementServiceClient client = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblUsername.Text = "Hello " + Session["username"];
                if(Session["username"].ToString() == "")
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

            btnSearch.Click += new System.EventHandler(this.btn_Clicked);
            lblError.ForeColor = System.Drawing.Color.Red;
        }

        private void btn_Clicked(object sender, EventArgs e)
        {
            if (sender == btnSearch)
            {
                consumerlist.DataSource = null;
                consumerlist.DataBind();
                try
                {
                    lblError.Text = "";
                    List<ConsumerManagementService.Consumer> list = null;
                    switch (searchByList.SelectedItem.Value)
                    {
                        case "0":
                            list = client.getConsumerFirstNameLike(tbName.Text).ToList();
                            break;
                        case "1":
                            list = client.getConsumerLastLike(tbName.Text).ToList();
                            break;
                        case "2":
                            list = client.getConsumerCityLike(tbName.Text).ToList();
                            break;
                    }
                    consumerlist.DataSource = list;
                    consumerlist.DataBind();

                }
                catch (FaultException<ConsumerManagementService.ConsumerFault> obj)
                {
                    lblError.Text = obj.Detail.Error + " : " + obj.Detail.Details;
                }
            }
        }

        protected void HyperLink1_Unload(object sender, EventArgs e)
        {
            //Session["operation"] = "add";
        }

        protected void consumerlist_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session["operation"] = "edit";
            Session["consumerId"] = consumerlist.Rows[e.NewEditIndex].Cells[3].Text;
            Response.Redirect("ConsumerForm.aspx");
        }

        protected void consumerlist_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["consumerId"] = consumerlist.Rows[e.RowIndex].Cells[3].Text;
            Response.Redirect("DeleteConsumerForm.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}