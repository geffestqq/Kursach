<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registr.aspx.cs" Inherits="KursachReklamnoeAgentstvo.Registr" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="StyleSheet3.css" rel="stylesheet" />
    <link href="Preloader.css" rel="stylesheet" />
</head>
<body BackGround="3.jpg">
    <form id="form1" runat="server">

        
           <div class="preloader">
  <svg class="preloader__image" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512">
    <path fill="currentColor"
      d="M304 48c0 26.51-21.49 48-48 48s-48-21.49-48-48 21.49-48 48-48 48 21.49 48 48zm-48 368c-26.51 0-48 21.49-48 48s21.49 48 48 48 48-21.49 48-48-21.49-48-48-48zm208-208c-26.51 0-48 21.49-48 48s21.49 48 48 48 48-21.49 48-48-21.49-48-48-48zM96 256c0-26.51-21.49-48-48-48S0 229.49 0 256s21.49 48 48 48 48-21.49 48-48zm12.922 99.078c-26.51 0-48 21.49-48 48s21.49 48 48 48 48-21.49 48-48c0-26.509-21.491-48-48-48zm294.156 0c-26.51 0-48 21.49-48 48s21.49 48 48 48 48-21.49 48-48c0-26.509-21.49-48-48-48zM108.922 60.922c-26.51 0-48 21.49-48 48s21.49 48 48 48 48-21.49 48-48-21.491-48-48-48z">
    </path>
  </svg>
</div>
        <script>
            window.onload = function () {
                document.body.classList.add('loaded_hiding');
                window.setTimeout(function () {
                    document.body.classList.add('loaded');
                    document.body.classList.remove('loaded_hiding');
                }, 500);
            }
</script>

        <div>

        </div>
        <center>
        <asp:Label ID="Label1" runat="server" Text="Логин"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Пароль"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Подтверждение пароля"></asp:Label>
            <br />
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox3" runat="server" Visible="False">1</asp:TextBox>
        <br />
        <asp:Button ID="Button2" runat="server" CssClass="button23" Text="Зарегистрировать" 
                OnClick="Button2_Click" />
            </center>
    </form>
</body>
</html>
