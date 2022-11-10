<%@ Page Title="Заполнение формы." Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MakeOrder.aspx.cs" Inherits="Wildberries_Courier.MakeOrder" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Здесь Вам необходимо записать свои данные, чтобы мы могли передать их курьеру.</h3>
    <p>Просим Вас проверять корректность заполнения формы.</p>
    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
               <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:Label ID="Label1" runat="server" Text=" Имя"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <a> </a>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label2" runat="server" Text=" Фамилия"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

        <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <a> </a>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label3" runat="server" Text=" Адрес"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <a> </a>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
        <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label5" runat="server" Text=" Номер телефона"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <a> </a>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

        <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label4" runat="server" Text=" Код"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
        <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <a> </a>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

        <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="Button1" runat="server" Text="Доставить" OnClick="Button1_Click"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
