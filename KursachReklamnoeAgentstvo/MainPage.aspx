<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="KursachReklamnoeAgentstvo.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="StyleSheet2.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<link href="PreloaderGif.css" rel="stylesheet" />
<body background ="17113.jpg" >
    <form id="form1" runat="server">  
        
        <div class="loader">
	<div class="loader_inner"></div>
          
</div>
        <script>
            window.onload = function () {
                document.body.classList.add('loaded_hiding');
                window.setTimeout(function () {
                    document.body.classList.add('loaded');
                    document.body.classList.remove('loaded_hiding');
                }, 5000);
            }
</script>


          



 <div class="headear-slider">

        <div class="sl_ctr">
                  <div class="sldr">
                    <a href="#"><img src="images/1.jpg" alt="Жопа" /></a>
                    <a href="#"><img src="images/7.jpg" alt="Жопа"></a>
                    <a href="#"><img src="images/3.jpg" alt="Жопа"></a>
                    <a href="#"><img src="images/4.jpg" alt="Жопа"></a>
                    <a href="#"><img src="images/5.jpg" alt="Жопа"></a>
                    <a href="#"><img src="images/6.jpg" alt="Жопа"></a>         
            </div>
          <div class="prv_b"></div>
          <div class="nxt_b"></div>              
         </div>
   </div>

    <script async defer src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>
    <script async defer src="main.js"></script>

        

<div class="hamburger-menu">
    
  <input id="menu__toggle" type="checkbox" />
  <label class="menu__btn" for="menu__toggle">
  <span></span>
  </label>
  <ul class="menu__box">
     <center>
        <li><asp:Button runat="server" ID="Button1" class="menu__item" Text="Админ" OnClick="Button1_Click" BorderWidth="0px"/></li>
        <li><asp:Button runat="server" ID="Button2" class="menu__item" Text="Чек" OnClick="Button2_Click" BorderWidth="0px" /></li>
        <li><asp:Button runat="server" ID="Button3" class="menu__item" Text="Должность" OnClick="Button3_Click" BorderWidth="0px"/></li>
        <li><asp:Button runat="server" ID="Button4" class="menu__item" Text="Прайс лист" OnClick="Button4_Click" BorderWidth="0px" /></li>
        <li><asp:Button runat="server" ID="Button5" class="menu__item" Text="Реклама" OnClick="Button5_Click" BorderWidth="0px" /></li>
        <li><asp:Button runat="server" ID="Button7" class="menu__item" Text="Собеседование" OnClick="Button7_Click" BorderWidth="0px"/></li>
        <li><asp:Button runat="server" ID="Button8" class="menu__item" Text="Сотрудник" OnClick="Button8_Click" BorderWidth="0px"/></li>
        <li><asp:Button runat="server" ID="Button9" class="menu__item" Text="Статус" OnClick="Button9_Click" BorderWidth="0px" /></li>
        <li><asp:Button runat="server" ID="Button10" class="menu__item" Text="Заказ" OnClick="Button10_Click" BorderWidth="0px" /></li>
        <li><asp:Button runat="server" ID="Button11" class="menu__item" Text="Клиент" OnClick="Button11_Click" BorderWidth="0px"/></li>
        <li><asp:Button runat="server" ID="Button13" class="menu__item" Text="Личный кабинет" OnClick="Button13_Click" BorderWidth="0px"/></li>
        <li><asp:Button runat="server" ID="Button14" class="menu__item" Text="Обратная связь" OnClick="Button14_Click" BorderWidth="0px" /></li> 
        <li><asp:Button runat="server" ID="Button15" class="menu__item" Text="О нас" OnClick="Button15_Click" BorderWidth="0px" /></li> 
        <li><asp:Button runat="server" ID="Button16" class="menu__item" Text="История" OnClick="Button16_Click" BorderWidth="0px" /></li> 
    </center>
  </ul>
    <br />
</div>      
        <center>
            <asp:Label ID="Label1" runat="server" Text="Для каждого клиента мы продумываем" Font-Size="24pt" ForeColor="White"></asp:Label>
            <br />
            <br />
            <p style="color:white">&nbsp;Тексты объявлений
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp; Ключевые слова&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Минус-фразы&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Турбо-страницу
 </p>
  <p style="color:white">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; по которым будут чаще&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; чтобы обратиться именно&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; для релевантных показов&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   на которую будут переходить<br>
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   переходить на сайт.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;  к вашей аудитории&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; и экономии бюджета&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; клиенты, если у вас нет сайта </p>
           

           
        </center>
</form>
</body>
</html>
