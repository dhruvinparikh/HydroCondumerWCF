<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ConsumerManagementClient.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hydro Consumer Management</title>
</head>
<body style="background: #555;">
    <div style="max-width: 600px; margin: auto; margin-top:300px; background: white; padding: 10px;">
    <form id="form1" runat="server">
        <div style="width:400px;text-align:center;margin-left:150px;">
            <asp:Table ID="Table1" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell />
                    <asp:TableHeaderCell><div style="padding-bottom:10px;">Login Form</div></asp:TableHeaderCell>
                    <asp:TableHeaderCell />
                    <asp:TableHeaderCell />
                    <asp:TableHeaderCell />
                </asp:TableHeaderRow>
                <asp:TableRow />
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label1" runat="server" Text="Label">Username : </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell />
                    <asp:TableCell>
                        <asp:TextBox ID="tbUsername" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell />
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell />
                    <asp:TableCell />
                    <asp:TableCell />
                    <asp:TableCell />
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label2" runat="server" Text="Label">Password : </asp:Label>
                    </asp:TableCell><asp:TableCell />
                    <asp:TableCell>
                        <asp:TextBox ID="tbPassword" TextMode="Password" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell />
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell />
                    <asp:TableCell />
                    <asp:TableCell>
                        <!-- <div style="padding-top:10px;padding-bottom:10px;">
                        <asp:HyperLink ID="linkChangePassword" NavigateUrl="#" runat="server">Change Password?</asp:HyperLink>
                        </div> -->
                    </asp:TableCell>
                    <asp:TableCell>
                        </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>                   
                    <asp:TableCell>
                        <asp:Button ID="btnLogin" runat="server" Text="Login" />
                    </asp:TableCell>
                    <asp:TableCell />
                    <asp:TableCell>
                        <asp:Button ID="btnReset" runat="server" Text="Reset" />
                    </asp:TableCell>
                    <asp:TableCell>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            </div>
        </form>
        <div style="text-align:center;padding-top:20px;">
        <asp:Label ID="lblError" runat="server" Text="">
                        </asp:Label></div>
    </div>
</body>
</html>
