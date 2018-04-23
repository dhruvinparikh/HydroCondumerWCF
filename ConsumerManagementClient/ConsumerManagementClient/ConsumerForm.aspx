<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsumerForm.aspx.cs" Inherits="ConsumerManagementClient.ConsumerForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consumer Form</title>
    <style>
        .lbl {
            text-align: right;
        }
    </style>
</head>
<body>
    <div style="text-align: center;">
        <form id="form1" runat="server">
            <div>
                <asp:Label ID="lblUsername" runat="server" Text="Label"></asp:Label>

            </div>
            <div style="float: right; margin-right: 80px; width: 200px;">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Logout</asp:LinkButton>
            </div>
            <br />
            <br />
            <div style="padding-bottom: 50px; width: 300px; margin: 0 auto;">
                <div style="float: left; padding-left: 50px;">
                    <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
                        <Items>
                            <asp:MenuItem Text="Search" Value="Search">
                                <asp:MenuItem Text="ConsumerID" NavigateUrl="~/SearchByConsumerID.aspx" Value="ConsumerID"></asp:MenuItem>
                                <asp:MenuItem Text="Name/City" NavigateUrl="~/SearchByNameCity.aspx" Value="Name/City"></asp:MenuItem>
                            </asp:MenuItem>
                        </Items>
                    </asp:Menu>
                </div>
                <div style="float: left; padding-left: 50px;">
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
            <div style="width: 400px; margin: 0 auto;">
                <asp:Table ID="Table1" runat="server">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell />
                        <asp:TableHeaderCell />
                        <asp:TableHeaderCell>
                            <div style="padding-bottom: 20px;">
                                <asp:Label ID="Label1" runat="server" Text="ConsumerForm" />
                            </div>
                        </asp:TableHeaderCell><asp:TableHeaderCell />
                        <asp:TableHeaderCell />
                    </asp:TableHeaderRow>
                    <asp:TableRow>
                        <asp:TableCell CssClass="lbl">
                            <asp:Label ID="Label2" runat="server" Text="ConsumerID" />
                        </asp:TableCell><asp:TableCell />
                        <asp:TableCell>
                            <asp:TextBox ID="tbConsumerID" runat="server" />
                        </asp:TableCell><asp:TableCell />
                        <asp:TableCell>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell CssClass="lbl">
                            <asp:Label ID="Label4" runat="server" Text="First Name" />
                        </asp:TableCell><asp:TableCell />
                        <asp:TableCell>
                            <asp:TextBox ID="tbFirstName" runat="server" />
                        </asp:TableCell><asp:TableCell />
                        <asp:TableCell>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell CssClass="lbl">
                            <asp:Label ID="Label5" runat="server" Text="Last Name" />
                        </asp:TableCell><asp:TableCell />
                        <asp:TableCell>
                            <asp:TextBox ID="tbLastName" runat="server" />
                        </asp:TableCell><asp:TableCell />
                        <asp:TableCell>
                            
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell CssClass="lbl">
                            <asp:Label ID="Label6" runat="server" Text="City" />
                        </asp:TableCell><asp:TableCell />
                        <asp:TableCell>
                            <asp:TextBox ID="tbCity" runat="server" />
                        </asp:TableCell><asp:TableCell />
                        <asp:TableCell>
                            
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell CssClass="lbl">
                            <asp:Label ID="Label7" runat="server" Text="Bill Amount" />
                        </asp:TableCell><asp:TableCell />
                        <asp:TableCell>
                            <asp:TextBox ID="tbBillAmount" runat="server" />
                        </asp:TableCell><asp:TableCell />
                        <asp:TableCell>
                            
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell CssClass="lbl">
                            <asp:Label ID="Label8" runat="server" Text="Due Date" />
                        </asp:TableCell><asp:TableCell />
                        <asp:TableCell>
                            <asp:TextBox ID="tbDueDate" TextMode="Date" runat="server" />
                        </asp:TableCell><asp:TableCell />
                        <asp:TableCell>
                        
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableFooterRow>
                        <asp:TableHeaderCell />
                        <asp:TableHeaderCell>
                            <div style="padding-top: 30px;">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" />
                            </div>
                        </asp:TableHeaderCell><asp:TableHeaderCell />
                        <asp:TableHeaderCell>
                            <div style="padding-top: 30px;">
                                <asp:Button ID="btnReset" runat="server" Text="Reset" />
                            </div>
                        </asp:TableHeaderCell><asp:TableHeaderCell />
                    </asp:TableFooterRow>
                </asp:Table>
            </div>
        </form>
        <asp:Label ID="lblResult" runat="server"></asp:Label><br />
        <asp:Label ID="lblConsumerId" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblFirstName" runat="server" Text="" /><br />
        <asp:Label ID="lblLastName" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblCity" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblBillAmount" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblDueDate" runat="server" Text=""></asp:Label><br />
    </div>
</body>
</html>
