<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteConsumerForm.aspx.cs" Inherits="ConsumerManagementClient.DeleteConsumerForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Consumer Form</title>
    <style>
        .lbl{
            text-align:right;
        }
    </style>
</head>
<body>
    <div style="text-align:center;">
    <form id="form1" runat="server">
       <div>
            <asp:Label ID="lblUsername" runat="server" Text="Label"></asp:Label>
             
        </div>
        <div style="float:right;margin-right:80px; width:200px;">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Logout</asp:LinkButton>
        </div>
        <br />
        <br />
        <div style="padding-bottom: 50px;width:300px; margin:0 auto;" >
            <div style="float: left; padding-left:50px;">
                <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
                    <Items>
                        <asp:MenuItem Text="Search" Value="Search">
                            <asp:MenuItem Text="ConsumerID" NavigateUrl="~/SearchByConsumerID.aspx" Value="ConsumerID"></asp:MenuItem>
                            <asp:MenuItem Text="Name/City" NavigateUrl="~/SearchByNameCity.aspx" Value="Name/City"></asp:MenuItem>
                        </asp:MenuItem>
                    </Items>
                </asp:Menu>
            </div>
            <div style="float: left;padding-left:50px;">
                <asp:Menu ID="Menu2" runat="server" Orientation="Horizontal">
                    <Items>
                        <asp:MenuItem Text="Filter" Value="Filter">
                            <asp:MenuItem Text="DueDate" NavigateUrl="~/DueDate.aspx" Value="ConsumerID"></asp:MenuItem>
                            <asp:MenuItem Text="BillAmount" NavigateUrl="~/BillAmount.aspx" Value="BillAmount"></asp:MenuItem>
                        </asp:MenuItem>
                    </Items>
                </asp:Menu>
            </div>
        </div>
        <br />
        <br />
        <div style="width:400px; margin:0 auto;">
            <asp:Table ID="Table1" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell />
                    <asp:TableHeaderCell />
                    <asp:TableHeaderCell>
                        <div style="padding-bottom:20px;">
                        <asp:Label ID="Label1" runat="server" Text="Do you want to delete this record?" />
                        </div>
                    </asp:TableHeaderCell><asp:TableHeaderCell />
                    <asp:TableHeaderCell />
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="lbl">
                        <div style="padding-bottom:5px;">
                        <asp:Label ID="Label2" runat="server" Text="ConsumerID" />
                        </div>
                    </asp:TableCell><asp:TableCell />
                    <asp:TableCell />
                    <asp:TableCell>
                        <div style="padding-bottom:5px;">
                        <asp:Label ID="lblConsumerId" runat="server" Text=""></asp:Label>
                        </div>
                    </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell CssClass="lbl">
                        <div style="padding-bottom:5px;">
                        <asp:Label ID="Label4" runat="server" Text="First Name" />
                        </div>
                    </asp:TableCell><asp:TableCell /><asp:TableCell />
                    <asp:TableCell>
                        <div style="padding-bottom:5px;">
                        <asp:Label ID="lblFirstName" runat="server" Text=""></asp:Label>
                        </div>
                    </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell CssClass="lbl">
                        <div style="padding-bottom:5px;">
                        <asp:Label ID="Label5" runat="server" Text="Last Name" />
                        </div>
                    </asp:TableCell><asp:TableCell />
                    <asp:TableCell />
                    <asp:TableCell>
                        <div style="padding-bottom:5px;">
                        <asp:Label ID="lblLastName" runat="server" Text=""></asp:Label>
                        </div>
                    </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell CssClass="lbl">
                        <div style="padding-bottom:5px;">
                        <asp:Label ID="Label6" runat="server" Text="City" />
                        </div>
                    </asp:TableCell><asp:TableCell />
                    <asp:TableCell />
                    <asp:TableCell >
                        <div style="padding-bottom:5px;">
                        <asp:Label ID="lblCity" runat="server" Text=""></asp:Label>
                        </div>
                    </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell CssClass="lbl">
                        <div style="padding-bottom:5px;">
                        <asp:Label ID="Label7" runat="server" Text="Bill Amount" />
                        </div>
                    </asp:TableCell><asp:TableCell />
                    <asp:TableCell />
                    <asp:TableCell>
                        <div style="padding-bottom:5px;">
                        <asp:Label ID="lblBillAmount" runat="server" Text=""></asp:Label>
                        </div>
                    </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell CssClass="lbl">
                        <div style="padding-bottom:5px;">
                        <asp:Label ID="Label8" runat="server" Text="Due Date" />
                        </div>
                    </asp:TableCell><asp:TableCell />
                    <asp:TableCell />
                    <asp:TableCell>
                        <div style="padding-bottom:5px;">
                        <asp:Label ID="lblDueDate" runat="server" Text=""></asp:Label>
                        </div>
                    </asp:TableCell></asp:TableRow><asp:TableFooterRow>
                    <asp:TableHeaderCell />
                    <asp:TableHeaderCell>
                        <div style="padding-top:25px;">
                        <asp:Button ID="btnYes" runat="server" Text="Yes" />
                        </div>
                    </asp:TableHeaderCell><asp:TableHeaderCell />
                    <asp:TableHeaderCell>
                        <div style="padding-top:25px;">
                        <asp:Button ID="btnNo" runat="server" Text="No" />
                        </div>
                    </asp:TableHeaderCell><asp:TableHeaderCell />
                </asp:TableFooterRow>
            </asp:Table>
        </div>
    </form>
    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
    </div>
</body>
</html>
