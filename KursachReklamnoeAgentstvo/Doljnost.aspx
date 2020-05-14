<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Doljnost.aspx.cs" Inherits="KursachReklamnoeAgentstvo.Dpljnost" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="StyleSheet3.css" rel="stylesheet" />
    <link href="Preloader.css" rel="stylesheet" />
</head>
<body BackGround="Back.jpg">
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
          <asp:SqlDataSource ID="sdsDoljnost" runat ="server"></asp:SqlDataSource>
        <div>
            <div>
             <Center>
             <asp:GridView ID ="gvDoljnost" runat ="server" AllowSorting ="true" 
                     Font-Size ="16"  Font-Names ="Arial" 
                     OnRowDataBound="gvDoljnost_RowDataBound" 
                     OnSelectedIndexChanged="gvDoljnost_SelectedIndexChanged" 
                     OnSorting="gvDoljnost_Sorting" BackColor="#CCFF33"    >
                
                   <RowStyle CssClass="grid-view-main-normal" />
                   <HeaderStyle CssClass="grid-view-main-header" />
                    
                   <AlternatingRowStyle CssClass="grid-view-main-alternate" />
                 <Columns>
                  
                        <asp:CommandField ShowSelectButton ="true" />
                    </Columns>
                   </asp:GridView>
            </Center>
            </div>
            <left>
                <br />
                <br />
                <asp:Label ID ="Label1" runat="server" CssClass="Texting" Text ="Поиск:" ForeColor="White"></asp:Label>   
                      <asp:TextBox ID="TextBox2" runat="server" CssClass="textboxing" ></asp:TextBox>
                      <asp:Button ID="Button1" runat="server" Height="37px" 
                 style="margin-left: 369px; margin-top: 9px" Text="Найти" CssClass="button23" Width="92px" 
                 OnClick="Button1_Click" class="new_btn" />
             <asp:Button ID="Button2" runat="server" Height="37px" CssClass="button23"
                 style="margin-left: 9px; margin-top: 9px" Text="Фильтрация" Width="107px" 
                 OnClick="Button2_Click" />
             <asp:Button ID="Button7" runat="server" Height="37px" CssClass="button23"
                 style="margin-left: 9px; margin-top: 9px" Text="Word" Width="107px" OnClick="Button7_Click" 
                 />
             <asp:Button ID="Button8" runat="server" Height="37px" CssClass="button23"
                 style="margin-left: 9px; margin-top: 9px" Text="Excel" Width="107px" OnClick="Button8_Click" 
                 />
             <asp:Button ID="Button9" runat="server" Height="37px" CssClass="button23"
                 style="margin-left: 9px; margin-top: 9px" Text="PDF" Width="107px" 
                 />
                      <br />
                <br />
                     <asp:Label ID ="Label2" runat="server" CssClass="Texting" 
                 Text ="Название:" Font-Size="24pt" ForeColor="White"></asp:Label>   
                    
                     <asp:TextBox ID="TextBox3" runat="server" Height="31px" 
                 style="margin-left: 6px" Width="351px"></asp:TextBox>
                    
                     <br />
                     <asp:Label ID ="Label3" runat="server" CssClass="Texting" 
                 Text ="Зарплата:" Font-Size="24pt" ForeColor="White"></asp:Label>   
                     
             <asp:TextBox ID="TextBox4" runat="server" Height="31px" 
                 style="margin-left: 6px" Width="336px"></asp:TextBox>
             <br />
             
             <br />
                <center>
             <asp:Button ID="Button3" runat="server" Height="37px" OnClick="Button3_Click" 
                  Text="Добавить" CssClass="button23" Width="92px" />
             <asp:Button ID="Button4" runat="server" Height="37px" 
                   Text="Изменить" CssClass="button23" Width="95px" 
                 OnClick="Button4_Click" />
             <asp:Button ID="Button5" runat="server" Height="37px" 
                  Text="Удалить" CssClass="button23" Width="92px" 
                 OnClick="Button5_Click" />
             <asp:Button ID="Button6" runat="server" Height="37px" 
                 Text="Отмена" CssClass="button23" Width="92px" 
                 OnClick="Button6_Click" />
                    </center>
             <br />
            </left>
             <center>    
                    <a href="MainPage.aspx" style="color:white">Вернуться на главную</a>
                </center>     
        </div>       
    </form>


                   <div class="preloader">
  <svg class="preloader__image" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512">
    <path fill="currentColor"
      d="M304 48c0 26.51-21.49 48-48 48s-48-21.49-48-48 21.49-48 48-48 48 21.49 48 48zm-48 368c-26.51 0-48 21.49-48 48s21.49 48 48 48 48-21.49 48-48-21.49-48-48-48zm208-208c-26.51 0-48 21.49-48 48s21.49 48 48 48 48-21.49 48-48-21.49-48-48-48zM96 256c0-26.51-21.49-48-48-48S0 229.49 0 256s21.49 48 48 48 48-21.49 48-48zm12.922 99.078c-26.51 0-48 21.49-48 48s21.49 48 48 48 48-21.49 48-48c0-26.509-21.491-48-48-48zm294.156 0c-26.51 0-48 21.49-48 48s21.49 48 48 48 48-21.49 48-48c0-26.509-21.49-48-48-48zM108.922 60.922c-26.51 0-48 21.49-48 48s21.49 48 48 48 48-21.49 48-48-21.491-48-48-48z">
    </path>
  </svg>
</div>
        </body>
</html>
