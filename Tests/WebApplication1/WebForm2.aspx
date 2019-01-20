<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Логин<asp:TextBox ID="LoginEmail" runat="server"></asp:TextBox>
            <br />
            <br />
            Пароль<asp:TextBox ID="LoginPassword" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Войти" Width="154px" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
