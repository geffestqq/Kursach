<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Authorization.aspx.cs" Inherits="KursachReklamnoeAgentstvo.Authorization" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Preloader.css" rel="stylesheet" />
    <title></title>
</head>
<body background ="Back.jpg";>
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


        <asp:SqlDataSource ID="sdsAuthorization" runat ="server"></asp:SqlDataSource>
        <div>
             <Center>
            <asp:GridView ID ="gvAuthorization" runat ="server" AllowSorting ="true" 
                     Font-Size ="16"  CssClass="table"  Font-Names ="Arial" 
                     OnRowDataBound="gvAuthorization_RowDataBound" 
                     OnSelectedIndexChanged="gvAuthorization_SelectedIndexChanged" 
                     OnSorting="gvAuthorization_Sorting" BackColor="#CCFF33">
                   <RowStyle CssClass="grid-view-main-normal" />
                   <HeaderStyle CssClass="grid-view-main-header" />
                    
                   <AlternatingRowStyle CssClass="grid-view-main-alternate" />
                 <Columns>        
                        <asp:CommandField ShowSelectButton ="true" />
                    </Columns>
                   </asp:GridView>
            </Center>
                 <left>
                <br />            
                <br />
                <br />
                         
                <asp:Label ID ="Label1" runat="server" CssClass="Texting" Text ="Поиск:"></asp:Label>   
                      <asp:TextBox ID="TextBox2" runat="server" CssClass="textboxing" ></asp:TextBox>
                      <asp:Button ID="Button1" runat="server" Height="37px" 
                 style="margin-left: 369px; margin-top: 9px" Text="Найти" Width="92px" 
                 OnClick="Button1_Click" />
             <asp:Button ID="Button2" runat="server" Height="37px" 
                 style="margin-left: 9px; margin-top: 9px" Text="Фильтрация" Width="91px" 
                 OnClick="Button2_Click" />
                      <br />
                <br />
                     <asp:Label ID ="Label2" runat="server" CssClass="Texting" 
                 Text ="Логин:" Font-Size="24pt"></asp:Label>   
                    
                     <asp:TextBox ID="TextBox3" runat="server" Height="31px" 
                 style="margin-left: 6px" Width="351px"></asp:TextBox>
                    
                     <br />
                     <asp:Label ID ="Label3" runat="server" CssClass="Texting" 
                 Text ="Пароль:" Font-Size="24pt"></asp:Label>   
                     
             <asp:TextBox ID="TextBox4" runat="server" Height="31px" 
                 style="margin-left: 6px" Width="336px"></asp:TextBox>
             <br />
                     <asp:Label ID ="Label4" runat="server" CssClass="Texting" Text ="Роль:" 
                 Font-Size="24pt"></asp:Label>   
                     
             <asp:ListBox ID="ListBox1" runat="server" Height="75px" style="margin-top: 0px" 
                 Width="384px"></asp:ListBox>
             <br />
             <br />
             <asp:Button ID="Button3" runat="server" Height="37px" OnClick="Button3_Click" 
                 style="margin-left: 369px; margin-top: 9px" Text="Добавить" Width="92px" />
             <asp:Button ID="Button4" runat="server" Height="37px" 
                 style="margin-left: 78px; margin-top: 9px" Text="Удалить" Width="95px" 
                 OnClick="Button4_Click" />
             <asp:Button ID="Button5" runat="server" Height="37px" 
                 style="margin-left: 81px; margin-top: 9px" Text="Изменить" Width="92px" 
                 OnClick="Button5_Click" />
             <asp:Button ID="Button6" runat="server" Height="37px" 
                 style="margin-left: 81px; margin-top: 9px" Text="Отмена" Width="92px" />
             <br />
                     
            </left>
             <center>    
                    <a href="Admin.aspx" style="color:white">Вернуться на главную</a>
                </center>     
        </div>
    </form>
</body>
</html>
