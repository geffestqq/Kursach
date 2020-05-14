<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Backup.aspx.cs" Inherits="KursachReklamnoeAgentstvo.Backup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <center>
            <asp:Label ID="Label1" runat="server" Text="Выберите путь сохранения"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtPath" runat="server" Width="302px"></asp:TextBox>
            &nbsp;
            <asp:Button ID="Button1" runat="server" Text="Browse" 
            OnClick="Button1_Click1"/>
            &nbsp;<asp:Button ID="Button2" runat="server" Text="BackUp" 
            OnClick="Button2_Click" />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="Выберите файл с базой"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtRestore" runat="server" Width="302px"></asp:TextBox>
            &nbsp;
            <asp:Button ID="Button3" runat="server" Text="Browse" 
            OnClick="Button3_Click" Width="60px" />
            &nbsp;
            <asp:Button ID="Button4" runat="server" Text="Restore" 
            OnClick="Button4_Click"/>
            </center>
             <center>    
                    <a href="Admin.aspx" style="color:aqua">Вернуться на главную</a>
                </center>     
        <br />
    </form>
</body>
</html>
