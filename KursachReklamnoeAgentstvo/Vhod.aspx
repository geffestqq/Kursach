<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vhod.aspx.cs" Inherits="KursachReklamnoeAgentstvo.Vhod" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />
    <link href="StyleSheet3.css" rel="stylesheet" />
    <link href="enjoyhint-master/enjoyhint.css" rel="stylesheet" />
</head>

<body BackGround="3.jpg">
    <form id="form1" runat="server">
        <center> 
            <br />
             <asp:Label ID ="lblTitle" runat ="server" Text ="Вход" Font-Names="Bauhaus 93" Font-Size="16pt" ForeColor="White"></asp:Label>
            <br>
            <br>
            <asp:Label ID ="lblLogin" runat ="server" Text ="Логин: " ForeColor="White"></asp:Label>
            <br>
            <asp:TextBox ID ="tbLogin"  CssClass="textboxingg1" runat ="server"></asp:TextBox>
            <br>
            <br>
            <asp:Label ID ="lblPassword" runat ="server" Text ="Пароль:" ForeColor="White"></asp:Label>
            <br>
            <asp:TextBox ID ="tbPassword" runat ="server"  CssClass="textboxingg2"  TextMode ="Password"></asp:TextBox>
            <br>
            <br>
            <asp:Button ID ="btEnter" runat ="server" CssClass="button23" Text ="Войти" 
                 OnClick="btEnter_Click" />
            <asp:Button ID ="btEnter0" runat ="server" CssClass="button23" Text ="Регистрация" OnClick="btEnter0_Click" 
                  />
        </center> 
        <script  src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
        
        <script src="enjoyhint-master/enjoyhint.js"></script>
       
        <script src="test.js"></script>
    </form>
</body>
</html>
