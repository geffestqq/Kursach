<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Zakaz.aspx.cs" Inherits="KursachReklamnoeAgentstvo.Zakaz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Preloader.css" rel="stylesheet" />
</head>
<body background ="Back.jpg">
    <form id="form1" runat="server">
       <asp:SqlDataSource ID="sdsZakaz" runat ="server"></asp:SqlDataSource>
        
           <div class="preloader">
  <svg class="preloader__image" role="img" xmlns="http://www.w3.org/2000/svg"   viewBox="0 0 512 512">
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
             <Center>
             <asp:GridView ID ="gvZakaz" runat ="server" AllowSorting ="true" Font-Size ="16"  Font-Names ="Arial" CssClass="td" OnRowDataBound="gvZakaz_RowDataBound" OnSelectedIndexChanged="gvZakaz_SelectedIndexChanged" OnSelectedIndexChanging="gvZakaz_SelectedIndexChanging" OnSorting="gvZakaz_Sorting" BackColor="#99FF33" BorderColor="Black"    >
                
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
                         
                <asp:Label ID ="Label1" runat="server" CssClass="Texting" Text ="Поиск:" 
                 ForeColor="White"></asp:Label>   
                      <asp:TextBox ID="TextBox2" runat="server" CssClass="textboxing" ></asp:TextBox>
                      <asp:Button ID="Button1" runat="server" Height="37px" 
                 style="margin-left: 369px; margin-top: 9px" Text="Найти" Width="92px" 
                 />
             <asp:Button ID="Button2" runat="server" Height="37px" 
                 style="margin-left: 9px; margin-top: 9px" Text="Фильтрация" Width="91px" OnClick="Button2_Click" 
                  />
                      <br />
                <br />
                     <asp:Label ID ="Label2" runat="server" CssClass="Texting" 
                 Text ="Тема заказа:" Font-Size="24pt" ForeColor="White"></asp:Label>   
                    
                     <asp:TextBox ID="TextBox3" runat="server" Height="31px" 
                 style="margin-left: 6px" Width="351px"></asp:TextBox>
                    
                     <br />
                     <asp:Label ID ="Label3" runat="server" CssClass="Texting" 
                 Text ="Дата принятия:" Font-Size="24pt" ForeColor="White"></asp:Label>   
                     
             <asp:TextBox ID="TextBox4" runat="server" Height="31px" 
                 style="margin-left: 6px" Width="336px"></asp:TextBox>
             <br />
                     <asp:Label ID ="Label5" runat="server" CssClass="Texting" 
                 Text ="Дата окончания:" Font-Size="24pt" ForeColor="White"></asp:Label>   
                     
             <asp:TextBox ID="TextBox6" runat="server" Height="31px" 
                 style="margin-left: 6px" Width="336px"></asp:TextBox>
             <br />
                     <asp:Label ID ="Label7" runat="server" CssClass="Texting" 
                 Text ="Утверждение:" Font-Size="24pt" ForeColor="White"></asp:Label>   
                     
             <asp:TextBox ID="TextBox5" runat="server" Height="31px" 
                 style="margin-left: 6px" Width="336px"></asp:TextBox>
             <br />
                     <asp:Label ID ="Label9" runat="server" CssClass="Texting" 
                 Text ="Название статуса:" Font-Size="24pt" ForeColor="White"></asp:Label>   
                     
             <asp:ListBox ID="ListBox4" runat="server" Height="30px" style="margin-top: 0px" 
                 Width="384px" AutoPostBack="True"></asp:ListBox>
             <br />
                     <asp:Label ID ="Label6" runat="server" CssClass="Texting" 
                 Text ="Сотрудник:" Font-Size="24pt" ForeColor="White"></asp:Label>   
                     
             <asp:ListBox ID="ListBox1" runat="server" Height="30px" style="margin-top: 0px" 
                 Width="384px" AutoPostBack="True"></asp:ListBox>
             <br />
                     <asp:Label ID ="Label8" runat="server" CssClass="Texting" 
                 Text ="Клиент:" Font-Size="24pt" ForeColor="White"></asp:Label>   
                     
             <asp:ListBox ID="ListBox3" runat="server" Height="30px" style="margin-top: 0px" 
                 Width="384px" AutoPostBack="True"></asp:ListBox>
             <br />
             <br />
             <br />
             <br />
             <asp:Button ID="Button3" runat="server" Height="37px"  
                 style="margin-left: 369px; margin-top: 9px" Text="Добавить" Width="92px" OnClick="Button3_Click" 
                  />
             <asp:Button ID="Button4" runat="server" Height="37px" 
                 style="margin-left: 78px; margin-top: 9px" Text="Удалить" Width="95px" OnClick="Button4_Click" 
                />
             <asp:Button ID="Button5" runat="server" Height="37px" 
                 style="margin-left: 81px; margin-top: 9px" Text="Изменить" Width="92px" OnClick="Button5_Click" 
                 />
             <asp:Button ID="Button6" runat="server" Height="37px" 
                 style="margin-left: 81px; margin-top: 9px" Text="Отмена" Width="92px" />
             <br />
                     
            </left>
             <center>    
                    <a href="MainPage.aspx" style="color:white">Вернуться на главную</a>
                </center>     
        </div>
    </form>
</body>
</html>
