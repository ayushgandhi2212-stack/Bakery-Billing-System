<%@ Page Title="Billing" Language="C#" MasterPageFile="~/Bakery.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="BakeryBillingSystem.Billing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="billing-card">

    <h2>🧾 Bakery Billing</h2>

    <table class="billing-table">

        <tr>
            <td><b>👤 Customer Name</b></td>
            <td>
                <asp:TextBox
                    ID="txtCustomer"
                    runat="server"
                    CssClass="textbox">
                </asp:TextBox>
            </td>
        </tr>

        <tr>
            <td><b>🍰 Product</b></td>
            <td>

                <asp:DropDownList
                    ID="ddlProduct"
                    runat="server"
                    CssClass="textbox"
                    AutoPostBack="true"
                    OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">

                </asp:DropDownList>

            </td>
        </tr>

        <tr>
            <td><b>💰 Price (₹)</b></td>
            <td>

                <asp:TextBox
                    ID="txtPrice"
                    runat="server"
                    CssClass="textbox"
                    ReadOnly="true">
                </asp:TextBox>

            </td>
        </tr>

        <tr>
            <td><b>📦 Quantity</b></td>
            <td>

                <asp:TextBox
                    ID="txtQty"
                    runat="server"
                    CssClass="textbox">
                </asp:TextBox>

            </td>
        </tr>

    </table>

    <div class="button-area">

        <asp:Button
            ID="btnCalculate"
            runat="server"
            Text="🧮 Calculate Total"
            CssClass="btn-primary"
            OnClick="btnCalculate_Click" />

        <asp:Button
            ID="btnSaveBill"
            runat="server"
            Text="💾 Save Bill"
            CssClass="btn-success"
            OnClick="btnSaveBill_Click" />

    </div>

    <div class="total-box">

        <h3>Total Amount</h3>

        <div class="amount">

            <asp:Label
                ID="lblTotal"
                runat="server">
            </asp:Label>

        </div>

    </div>

    <center>

        <asp:Label
            ID="lblStatus"
            runat="server"
            CssClass="success">
        </asp:Label>

    </center>

</div>

</asp:Content>