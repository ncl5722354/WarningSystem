<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="newwarningsystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 628px;
        }
        .auto-style2 {
            height: 660px;
        }
        .auto-style3 {
            position: absolute;
            top: 0%;
            left: 0%;
            z-index: 1;
            width: 100%;
            height: 100%;
        }
        .auto-style4 {
            position: absolute;
            top: 79px;
            left: 100px;
            z-index: 1;
            width: 546px;
            height: 47px;
        }
        .auto-style5 {
            position: absolute;
            top: 501px;
            left: 200px;
            z-index:1;
            width:100px;
            height:30px;
        }
        .auto-style6 {
            position: absolute;
            top: 600px;
            left: 200px;
            z-index:1;
            width:100px;
            height:30px;
        }
        .auto-style7 {
            position: absolute;
            top: 501px;
            left: 300px;
            z-index: 1;
            width: 250px;
            height: 30px;
        }
        .auto-style8 {
            position: absolute;
            top: 600px;
            left: 300px;
            z-index: 1;
            width: 250px;
            height: 30px;
        }
        .auto-style9 {
            position: absolute;
            top: 700px;
            left: 500px;
            z-index: 1;
            width: 100px;
            height: 40px;
        }
        .auto-style10 {
            position: absolute;
            top: 760px;
            left: 500px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style2">
    <div class="auto-style1">
        
        
        <asp:Image ID="Image1" runat="server" CssClass="auto-style3" ImageUrl="~/Resource/u=1497079183,493793446&amp;fm=26&amp;gp=0.jpg" />
        <asp:Label ID="Label_title" runat="server" CssClass="auto-style4" Text="光收费站边坡防护预警系统" Font-Names="黑体" Font-Size="30pt" ForeColor="White"></asp:Label>
        <asp:Label ID="Label_username" runat="server" CssClass="auto-style5" Text="用户名" BorderColor="White" Font-Names="黑体" Font-Size="20pt" ForeColor="White"></asp:Label>
        <asp:Label ID="Label_password" runat="server" CssClass="auto-style6" Text="密  码" style="z-index: 1" Font-Names="黑体" Font-Size="20pt" ForeColor="White"></asp:Label>
        <asp:TextBox ID="TextBox_username" runat="server" CssClass="auto-style7" Font-Names="黑体" Font-Size="20pt"></asp:TextBox>
        <asp:TextBox ID="TextBox_password" runat="server" CssClass="auto-style8" Font-Names="黑体" Font-Size="20pt"></asp:TextBox>
        <asp:Button ID="Button_ok" runat="server" CssClass="auto-style9" Text="登录" Font-Names="黑体" Font-Size="20pt" OnClick="Button_ok_Click"/>
        <asp:Label ID="Label_error" runat="server" CssClass="auto-style10" style="z-index: 1" Text="用户名或密码错误" ForeColor="#990000"></asp:Label>
    </div>
    </form>
</body>
</html>
