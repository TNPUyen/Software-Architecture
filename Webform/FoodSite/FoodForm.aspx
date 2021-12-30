<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FoodForm.aspx.cs" Inherits="FoodSite.FoodForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>FOOD LIST</h1>
        <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"/><br /><br />
        <asp:GridView ID="gvFoodList" runat="server" AutoGenerateSelectButton="true" OnSelectedIndexChanged="gvFoodList_SelectedIndexChanged"></asp:GridView><br />
        <h3>FOOD DETAILS</h3>
        <table>
            <tr>
                <td>Id</td>
                <td><asp:TextBox ID="txtId" runat="server" Width="390px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Name</td>
                <td><asp:TextBox ID="txtName" runat="server" Width="390px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="auto-style1">Type</td>
                <td class="auto-style1"><asp:TextBox ID="txtType" runat="server" Width="390px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Description</td>
                <td><asp:TextBox ID="txtDes" runat="server" Width="390px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Price</td>
                <td><asp:TextBox ID="txtPrice" runat="server" Width="390px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Amount</td>
                <td><asp:TextBox ID="txtAmount" runat="server" Width="390px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Status</td>
                <td><asp:TextBox ID="txtStatus" runat="server" Width="390px"></asp:TextBox></td>
            </tr>
        </table>
        <p/>
        <asp:Button ID="btnAdd" runat="server" Text="ADD NEW" OnClick="btnAdd_Click" />
        <asp:Button ID="btnUpdate" runat="server" Text="UPDATE" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="DELETE" OnClick="btnDelete_Click" OnClientClick="return confirm('ARE YOU SURE?');"/>
    </form>
</body>
</html>
