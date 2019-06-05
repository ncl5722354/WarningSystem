<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Set.aspx.cs" Inherits="newwarningsystem.Set" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position:absolute;
            height: 20px;
            width:100px;
            top:30px;
            left:30px;
        }
        .auto-style2 {
            position:absolute;
            height: 20px;
            width:100px;
            top:70px;
            left:30px;
        }
        .auto-style3 {
            position:absolute;
            height: 20px;
            width:100px;
            top:110px;
            left:30px;
        }
         .auto-style4 {
            position:absolute;
            height: 20px;
            width:100px;
            top:150px;
            left:30px;
        }
         .auto-style5 {
            position:absolute;
            height: 20px;
            width:100px;
            top:190px;
            left:30px;
        }
         .auto-style6 {
            position:absolute;
            height: 20px;
            width:100px;
            top:230px;
            left:30px;
        }
         .auto-style7 {
            position:absolute;
            height: 20px;
            width:200px;
            top:70px;
            left:200px;
            bottom: 220px;
        }
         .auto-style8 {
            position:absolute;
            height: 20px;
            width:200px;
            top:110px;
            left:200px;
        }
         .auto-style9 {
            position:absolute;
            height: 20px;
            width:200px;
            top:150px;
            left:200px;
        }
         .auto-style10 {
            position:absolute;
            height: 20px;
            width:200px;
            top:190px;
            left:200px;
        }
          .auto-style11 {
            position:absolute;
            height: 20px;
            width:200px;
            top:230px;
            left:200px;
            right: 372px;
        }
          .auto-style12 {
            position:absolute;
            height: 30px;
            width:60px;
            top:230px;
            left:500px;
        }
     </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Label ID="Label1" runat="server" Text="设定报警阈值" CssClass="auto-style1"></asp:Label>
        <p>
        <asp:Label ID="Label2" runat="server" Text="一级阈值" CssClass="auto-style2"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="二级阈值" CssClass="auto-style3"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="三级阈值" CssClass="auto-style4"></asp:Label>
        <asp:Label ID="Label5" runat="server" Text="四级阈值" CssClass="auto-style5"></asp:Label>
        <asp:Label ID="Label6" runat="server" Text="五级阈值" CssClass="auto-style6"></asp:Label>
        </p>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style7" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style8" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBox3" runat="server" CssClass="auto-style9" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBox4" runat="server" CssClass="auto-style10" OnTextChanged="TextBox4_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBox5" runat="server" CssClass="auto-style11" OnTextChanged="TextBox5_TextChanged"></asp:TextBox>
        
            <asp:Button ID="Button1" runat="server" Text="确定" CssClass="auto-style12" OnClick="Button1_Click" UseSubmitBehavior="False" />
       
    </form>
</body>
</html>
