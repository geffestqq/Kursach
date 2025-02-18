﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ONAS.aspx.cs" Inherits="KursachReklamnoeAgentstvo.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="preload.css" rel="stylesheet" />
</head>
<body background ="onas.jpg">
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
                 <asp:Label ID="Label1" runat="server" Text="Контакты сервиса:" Font-Size="25pt" ForeColor="#000099"></asp:Label>
                 <br />
            <asp:Label ID="Label3" runat="server" Text="8(977)-640-06-01" Font-Size="20pt" ForeColor="White"></asp:Label>
                 <br />
            <asp:Label ID="Label4" runat="server" Text="Москва, Булатниковский проезд" Font-Size="20pt" ForeColor="White"></asp:Label>
                 <br />
            <asp:Label ID="Label5" runat="server" Text="Д10 Б" Font-Size="20pt" ForeColor="White"></asp:Label>
                 <br />
            <asp:Label ID="Label6" runat="server" Text="Время работы: 9:00 - 20:00 (ПН - ПТ)" Font-Size="20pt" ForeColor="White"></asp:Label>
                 <br />
                 <br />

            <asp:Label ID="Label2" runat="server" Text="Наше местоположение" Font-Size="20pt" ForeColor="White"></asp:Label>
                </center>
        </div>
        <div>
         <center>      
             <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d18115.07594371845!2d38.24845975246456!3d55.42108760613715!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x414a9124db965b15%3A0xb8bc2350f7badf5!2z0JHRgNC-0L3QvdC40YbRiywg0JzQvtGB0LrQvtCy0YHQutCw0Y8g0L7QsdC7Lg!5e0!3m2!1sru!2sru!4v1589891836245!5m2!1sru!2sru" width="600" height="450" frameborder="0" style="border:0;" allowfullscreen="" aria-hidden="false" tabindex="0"></iframe>
       
    </center>
            <center>    
                    <a href="MainPage.aspx" style="color:aliceblue">Вернуться на главную</a>
                </center> 
        </div>
    </form>
</body>
</html>
