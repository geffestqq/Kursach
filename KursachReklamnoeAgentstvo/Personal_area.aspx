<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personal_area.aspx.cs" Inherits="KursachReklamnoeAgentstvo.Personal_area" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Preloader.css" rel="stylesheet" />
</head>
<body>
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
            <center>
            <asp:Label runat="server" ID="lb_Info" Text="Личный кабинет"></asp:Label>
            <p>
                <asp:Label runat="server" ID="Label1" Text=""></asp:Label>
                <p>

                    <asp:Label runat="server" ID="lbl_Login" Text="Ваш логин:"></asp:Label>
                    <asp:Label runat="server" ID="lbl_Login_user" Text=""></asp:Label>
                    <p>
                    <asp:Label runat="server" ID="lbl_Password" Text="Ваш пароль:"></asp:Label>
                    <asp:Label runat="server" ID="lbl_Password_User" Text=""></asp:Label>
                    <p>
                    <asp:Label runat="server" ID="lbl_New_Password" Text="Укажите новый пароль:"></asp:Label>
                    <asp:TextBox runat="server" ID="New_Passwrd"></asp:TextBox>
                        <p>
                    <asp:Label runat="server" ID="lbl_Confirm_Password" Text="Повторите пароль:"></asp:Label>
                    <asp:TextBox runat="server" ID="tb_Confir_Password"></asp:TextBox>
                            <p>
                    <asp:Button runat="server" ID="Update" Text="Изменить пароль" OnClick="Update_Click" />


                    <asp:Button  runat="server" Text="Назад" OnClick="Unnamed1_Click" ></asp:Button>
            </center>
        </div>
    </form>
</body>
</html>
