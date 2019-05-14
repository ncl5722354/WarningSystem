<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainMap.aspx.cs" Inherits="newwarningsystem.MainMap" %>

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
            position: absolute;
            top: 100px;
            left: 10px;
            z-index: 1;
            width: 1200px;
            height: 800px;
        }
        .auto-style3 {
            position: absolute;
            top: 0px;
            left: 0px;
            z-index: 1;
            width: 1920px;
            height: 1080px;
        }
        .auto-style4 {
            position: absolute;
            top: 10px;
            left: 10px;
            z-index: 1;
            width: 300px;
            height: 66px;
        }
        .auto-style5 {
            position: absolute;
            top: 300px;
            left: 300px;
            z-index: 1;
            width: 17px;
            height: 20px;
        }
        .auto-style6 {
            position: absolute;
            top: 270px;
            left: 500px;
            z-index:1;
            width:17px;
            height:20px;
        }
        .auto-style7 {
            position: absolute;
            top: 330px;
            left: 500px;
            z-index:1;
            width:17px;
            height:20px;
        }
        .auto-style8 {
            position: absolute;
            top: 400px;
            left: 230px;
            z-index: 1;
            width: 17px;
            height: 20px;
        }
        .auto-style9 {
            position: absolute;
            top: 400px;
            left: 350px;
            z-index:1;
            width:17px;
            height:20px;
        }
        .auto-style10 {
            position: absolute;
            top: 370px;
            left: 460px;
            z-index: 1;
            width: 17px;
            height: 20px;
        }
        .auto-style11 {
            position: absolute;
            top: 370px;
            left: 550px;
            z-index: 1;
            width: 17px;
            height: 20px;
        }
    </style>
</head>
<body style="height: 1080px; width:1920px;">
    <form id="form1" runat="server">
    <div class="auto-style1">
        
        <asp:Image ID="Imagebg" runat="server" CssClass="auto-style3" ImageUrl="~/Resource/u=1497079183,493793446&amp;fm=26&amp;gp=0.jpg" />
        <asp:Image ID="Imagemap" runat="server" CssClass="auto-style2" ImageUrl="~/Resource/pic.png" OnDataBinding="Imagemap_DataBinding" />
        <asp:Label ID="Label_title" runat="server" CssClass="auto-style4" Text="地图示意" Font-Names="黑体" Font-Size="30pt" ForeColor="White"></asp:Label>
         <asp:ImageButton ID="Image_point1" runat="server" CssClass="auto-style5" ImageUrl="~/Resource/position.png" />
        <asp:ImageButton ID="Image_point2" runat="server" CssClass="auto-style6" ImageUrl="~/Resource/position.png" style="z-index: 1" />
        <asp:ImageButton ID="Image_point3" runat="server" CssClass="auto-style7" ImageUrl="~/Resource/position.png" style="z-index: 1" />
        <asp:ImageButton ID="Image_point4" runat="server" CssClass="auto-style8" ImageUrl="~/Resource/position.png" />
        <asp:ImageButton ID="Image_point5" runat="server" CssClass="auto-style9" ImageUrl="~/Resource/position.png" style="z-index: 1" />
        <asp:ImageButton ID="Image_point6" runat="server" CssClass="auto-style10" ImageUrl="~/Resource/position.png" />
         <asp:ImageButton ID="Image_point7" runat="server" CssClass="auto-style11" ImageUrl="~/Resource/position.png" />
    </div>
    </form>
</body>
</html>
