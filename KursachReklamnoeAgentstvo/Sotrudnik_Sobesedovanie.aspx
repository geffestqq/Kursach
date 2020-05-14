<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sotrudnik_Sobesedovanie.aspx.cs" Inherits="KursachReklamnoeAgentstvo.Sotrudnik_Sobesedovanie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <asp:SqlDataSource ID="sdsSotrudnik_Sobesedovanie" runat ="server"></asp:SqlDataSource>
        <div>
             <Center>
             <asp:GridView ID ="gvSotrudnik_Sobesedovanie" runat ="server" AllowSorting ="true" Font-Size ="16"  Font-Names ="Arial" CssClass="td" OnRowDataBound="gvSotrudnik_Sobesedovanie_RowDataBound" OnSelectedIndexChanged="gvSotrudnik_Sobesedovanie_SelectedIndexChanged"    >
                
                   <RowStyle CssClass="grid-view-main-normal" />
                   <HeaderStyle CssClass="grid-view-main-header" />
                    
                   <AlternatingRowStyle CssClass="grid-view-main-alternate" />
                 <Columns>
                  
                        <asp:CommandField ShowSelectButton ="true" />
                    </Columns>
                   </asp:GridView>
            </Center>
        </div>
    </form>
</body>
</html>
