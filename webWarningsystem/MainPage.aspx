<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="webWarningsystem.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 132px;
            left: 22px;
            z-index: 1;
            width: 703px;
            height: 469px;
        }
        .auto-style2 {
            position: absolute;
            top: 102px;
            left: 97px;
            z-index: 1;
            width: 51px;
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Image ID="Image1" runat="server" BorderStyle="Solid" CssClass="auto-style1" />
        <p>
            <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text="Label"></asp:Label>
        /p>
    </form>
</body>
</html>
