<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Login.aspx.cs" Inherits="Reporting_System.WebForm1" %>


<asp:Content ID="cnLogin" ContentPlaceHolderID="cphBody" runat="server">
    <div>
        <div id="errMessage" runat="server"></div>
        <table border="0">
            <tr>
                <td>Select Role</td>
                <td>
                    <asp:DropDownList ID="dlRole" runat="server">
                        <asp:ListItem Value="0">-----Select Role-----</asp:ListItem>

                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvRole" runat="server" ErrorMessage="Required! Please enter." InitialValue="0" ControlToValidate="dlRole"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>UserName</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Required! Please enter." ControlToValidate="txtName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="txtPwd" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPwd" runat="server" ControlToValidate="txtPwd" ErrorMessage="Required! Please enter."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>

                <td>
                    <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>

    </div>


</asp:Content>
