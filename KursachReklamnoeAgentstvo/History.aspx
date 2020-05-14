<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="KursachReklamnoeAgentstvo.History" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Preloader.css" rel="stylesheet" />
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body background ="Back.jpg">
    
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
        <asp:SqlDataSource ID="sdsHistory" runat ="server" DataSourceMode="DataSet"></asp:SqlDataSource>
        <div>
             <Center>
             <asp:GridView ID ="gvHistory" runat ="server" AllowSorting ="true" Font-Size ="16"  Font-Names ="Arial" CssClass="td" OnRowDataBound="gvHistory_RowDataBound2"  OnPageIndexChanged="gvHistory_PageIndexChanged" OnPageIndexChanging="gvHistory_PageIndexChanging"    >
                
                   <RowStyle CssClass="grid-view-main-normal" />
                   <HeaderStyle CssClass="grid-view-main-header" />
                    
                   <AlternatingRowStyle CssClass="grid-view-main-alternate" />
                 <Columns>
                  
                        <asp:CommandField ShowSelectButton ="true" />
                    </Columns>
                   </asp:GridView>
                 <br />
                 <asp:Button ID="Button1" runat="server" Text="Word"/>
                 <asp:Button ID="Button2" runat="server"  Text="Excel" />
                 <asp:Button ID="Button3" runat="server" Text="PDF"/>
            </Center>           
        </div>
         <center>    
                    <a href="MainPage.aspx" style="color:white">Вернуться на главную</a>
                </center>     
    </form>
</body>
</html>
