<%@ Page Title="Login" Language="C#" MasterPageFile="~/Bakery.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BakeryBillingSystem.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div style="width:420px;margin:30px auto;padding:30px;background:#fff;border-radius:12px;box-shadow:0 6px 20px rgba(0,0,0,.15);">

    <h2>🔐 Login</h2>

    <table style="width:100%;">

        <tr>
            <td><b>Username</b></td>
        </tr>

        <tr>
            <td>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td style="padding-top:15px;"><b>Password</b></td>
        </tr>

        <tr>
            <td>
                <asp:TextBox ID="txtPassword"
                    runat="server"
                    TextMode="Password">
                </asp:TextBox>
            </td>
        </tr>

        <tr>
            <td style="padding-top:25px;text-align:center;">

                <asp:Button
                    ID="btnLogin"
                    runat="server"
                    Text="Login"
                    Width="160"
                    OnClick="btnLogin_Click" />

            </td>
        </tr>

        <tr>
            <td style="padding-top:15px;text-align:center;">

                <asp:Label
                    ID="lblMessage"
                    runat="server">
                </asp:Label>

            </td>
        </tr>

    </table>

</div>

</asp:Content>