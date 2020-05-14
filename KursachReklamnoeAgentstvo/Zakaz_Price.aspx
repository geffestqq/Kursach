<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Zakaz_Price.aspx.cs" Inherits="KursachReklamnoeAgentstvo.Zakaz_Price" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="sdsZakaz_Price" runat ="server"></asp:SqlDataSource>
        <div>
             <Center>
             <asp:GridView ID ="gvZakaz_Price" runat ="server" AllowSorting ="true" Font-Size ="16"  Font-Names ="Arial" CssClass="td" OnRowDataBound="gvZakaz_Price_RowDataBound"    >
                
                   <RowStyle CssClass="grid-view-main-normal" />
                   <HeaderStyle CssClass="grid-view-main-header" />
                    
                   <AlternatingRowStyle CssClass="grid-view-main-alternate" />
                 <Columns>
                  
                        <asp:CommandField ShowSelectButton ="true" />
                    </Columns>
                   </asp:GridView>
            </Center>
             <center>    
                    <a href="MainPage.aspx" style="color:white">Вернуться на главную</a>
                </center>     
        </div>
    </form>
</body>
</html>
