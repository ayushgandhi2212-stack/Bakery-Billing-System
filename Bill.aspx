<%@ Page Title="Invoice" Language="C#" MasterPageFile="~/Bakery.Master" AutoEventWireup="true" CodeBehind="Bill.aspx.cs" Inherits="BakeryBillingSystem.Bill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="invoice-card">

    <div class="invoice-header">

        <h1>🍰 Sweet Crumbs Bakery</h1>

        <p>Bakery Billing Invoice</p>

    </div>

    <hr />

    <table class="invoice-table">

        <tr>

            <td><b>🧾 Bill Number</b></td>

            <td>
                <asp:Label ID="lblBillId" runat="server"></asp:Label>
            </td>

        </tr>

        <tr>

            <td><b>👤 Customer Name</b></td>

            <td>
                <asp:Label ID="lblCustomer" runat="server"></asp:Label>
            </td>

        </tr>

        <tr>

            <td><b>📅 Bill Date</b></td>

            <td>
                <asp:Label ID="lblDate" runat="server"></asp:Label>
            </td>

        </tr>

        <tr>

            <td><b>💰 Total Amount</b></td>

            <td>

                <asp:Label
                    ID="lblAmount"
                    runat="server"
                    CssClass="invoice-amount">
                </asp:Label>

            </td>

        </tr>

    </table>

    <hr />

    <div class="thankyou">

        ❤️ Thank You for Visiting Sweet Crumbs Bakery ❤️

        <br /><br />

        We hope to serve you again!

    </div>

    <br />

    <center>

        <asp:Button
            ID="btnPrint"
            runat="server"
            Text="🖨 Print Invoice"
            CssClass="btn-primary"
            OnClientClick="window.print(); return false;" />

    </center>

</div>

</asp:Content>