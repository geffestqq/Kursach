<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sotrudnik.aspx.cs" Inherits="KursachReklamnoeAgentstvo.Sotrudnik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Preloader.css" rel="stylesheet" />
</head>
<body BackGround="Back.jpg">
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="sdsSotrudnik" runat ="server"></asp:SqlDataSource>

        
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
             <Center>
             <asp:GridView ID ="gvSotrudnik" runat ="server" AllowSorting ="true" 
                     Font-Size ="16"  Font-Names ="Arial" CssClass="td" 
                     OnRowDataBound="gvSotrudnik_RowDataBound" 
                     OnSelectedIndexChanged="gvSotrudnik_SelectedIndexChanged" 
                     OnSorting="gvSotrudnik_Sorting" BackColor="#99FF33"    >
                
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
                <asp:Label ID ="Label1" runat="server" CssClass="Texting" Text ="Поиск:" 
                 ForeColor="White"></asp:Label>   
                      <asp:TextBox ID="TextBox2" runat="server" CssClass="textboxing" ></asp:TextBox>
                      <asp:Button ID="Button1" runat="server" Height="37px" 
                 style="margin-left: 369px; margin-top: 9px" Text="Найти" Width="92px" OnClick="Button1_Click" 
                 />
             <asp:Button ID="Button2" runat="server" Height="37px" 
                 style="margin-left: 9px; margin-top: 9px" Text="Фильтрация" Width="91px" OnClick="Button2_Click" 
                 />
                      <br />
                <br />
                     <asp:Label ID ="Label2" runat="server" CssClass="Texting" 
                 Text ="Имя сотрудника:" Font-Size="24pt" ForeColor="White"></asp:Label>   
                    
                     <asp:TextBox ID="TextBox5" runat="server" Height="31px" 
                 style="margin-left: 6px" Width="351px"></asp:TextBox>
                    
                     <br />
                     <asp:Label ID ="Label3" runat="server" CssClass="Texting" 
                 Text ="Фамилия сотрудника:" Font-Size="24pt" ForeColor="White"></asp:Label>   
                    
                     <asp:TextBox ID="TextBox4" runat="server" Height="31px" 
                 style="margin-left: 6px" Width="351px"></asp:TextBox>
                    
                     <br />
                     <asp:Label ID ="Label4" runat="server" CssClass="Texting" 
                 Text ="Отчество  сотрудника:" Font-Size="24pt" ForeColor="White"></asp:Label>   
                    
                     <asp:TextBox ID="TextBox6" runat="server" Height="31px" 
                 style="margin-left: 6px" Width="351px"></asp:TextBox>
                    
                     <br />
                     <asp:Label ID ="Label5" runat="server" CssClass="Texting" 
                 Text ="Дата рождения:" Font-Size="24pt" ForeColor="White"></asp:Label>   
                    
                     <asp:TextBox ID="TextBox7" runat="server" Height="31px" 
                 style="margin-left: 6px" Width="351px"></asp:TextBox>
                    
                     <br />
                     <asp:Label ID ="Label6" runat="server" CssClass="Texting" 
                 Text ="Серия паспорта:" Font-Size="24pt" ForeColor="White"></asp:Label>   
                    
                     <asp:TextBox ID="TextBox8" runat="server" Height="31px" 
                 style="margin-left: 6px" Width="351px"></asp:TextBox>
                    
                     <br />
                     <asp:Label ID ="Label7" runat="server" CssClass="Texting" 
                 Text ="Номер паспорта:" Font-Size="24pt" ForeColor="White"></asp:Label>   
                    
                     <asp:TextBox ID="TextBox9" runat="server" Height="31px" 
                 style="margin-left: 6px" Width="351px"></asp:TextBox>
                    
                     <br />
                     <asp:Label ID ="Label8" runat="server" CssClass="Texting" 
                 Text ="Статус:" Font-Size="24pt" ForeColor="White"></asp:Label>   
                    
                     <asp:TextBox ID="TextBox10" runat="server" Height="31px" 
                 style="margin-left: 6px" Width="351px"></asp:TextBox>
                    
                     <br />
                     <asp:Label ID ="Label12" runat="server" CssClass="Texting" 
                 Text ="Дата приема:" Font-Size="24pt" ForeColor="White"></asp:Label>   
                    
                     <asp:TextBox ID="TextBox11" runat="server" Height="31px" 
                 style="margin-left: 6px" Width="351px"></asp:TextBox>
                    
                     <br />
                     <asp:Label ID ="Label9" runat="server" CssClass="Texting" 
                 Text ="Название должности:" Font-Size="24pt" ForeColor="White"></asp:Label>   
                    
             <asp:ListBox ID="ListBox3" runat="server" Height="45px" style="margin-top: 2px" 
                 Width="321px" AutoPostBack="True"></asp:ListBox>
                    
                     <asp:Label ID ="Label11" runat="server" CssClass="Texting" 
                 Text ="Логин:" Font-Size="24pt" ForeColor="White"></asp:Label>   
                    
             <asp:ListBox ID="ListBox2" runat="server" Height="43px" style="margin-top: 2px; margin-left: 3px;" 
                 Width="551px" AutoPostBack="True"></asp:ListBox>
                    
             <br />
             <br />
             <asp:Button ID="Button3" runat="server" Height="37px"  
                 style="margin-left: 369px; margin-top: 9px" Text="Добавить" Width="92px" 
                 OnClick="Button3_Click" />
             <asp:Button ID="Button4" runat="server" Height="37px" 
                 style="margin-left: 78px; margin-top: 9px" Text="Изменить" Width="95px" OnClick="Button4_Click" 
               />
             <asp:Button ID="Button5" runat="server" Height="37px" 
                 style="margin-left: 81px; margin-top: 9px" Text="Удалить" Width="92px" OnClick="Button5_Click" 
                />
             <asp:Button ID="Button6" runat="server" Height="37px" 
                 style="margin-left: 81px; margin-top: 9px" Text="Отмена" Width="92px" 
                 />
             <br />
            </left>
             <center>    
                    <a href="MainPage.aspx" style="color:white">Вернуться на главную</a>
                </center>     
        </div>
    </form>
</body>
</html>
