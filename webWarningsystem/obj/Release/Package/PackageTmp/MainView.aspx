<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainView.aspx.cs" Inherits="webWarningsystem.MainView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            width: 332px;
            height: 26px;
        }
        .auto-style1 {
            position: absolute;
            top: 39px;
            left: 388px;
            z-index: 1;
            width: 310px;
            height: 49px;
        }
        .auto-style2 {
            position: absolute;
            top: 106px;
            left: 37px;
            z-index: 1;
        }
        .auto-style3 {
            position: absolute;
            top: 106px;
            left: 96px;
            z-index: 1;
            margin-top: 0px;
        }
        .auto-style4 {
            position: absolute;
            top: 106px;
            left: 176px;
            z-index: 1;
        }
        .auto-style5 {
            width: 1044px;
            height: 562px;
            position: absolute;
            top: 131px;
            left: 40px;
            z-index: 1;
        }
        .auto-style6 {
            position: absolute;
            top: 106px;
            left: 257px;
            z-index: 1;
        }
    </style>
</head>
<body style="width: 1011px; height: 722px; margin-left: 25px; margin-top: 35px">
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" BackColor="White" CssClass="auto-style1" Font-Names="黑体" Font-Size="XX-Large" Text="坝体预警系统"></asp:Label>
        <asp:Button ID="Button1" runat="server" CssClass="auto-style2" OnClick="Button1_Click" Text="主画面" />
        <p>
            <asp:Button ID="Button3" runat="server" CssClass="auto-style3" OnClick="Button3_Click" Text="差分查询" />
        </p>
        <asp:Button ID="Button4" runat="server" CssClass="auto-style4" Text="报警记录" />
        <asp:Button ID="Button5" runat="server" CssClass="auto-style3" OnClick="Button5_Click" style="height: 21px" Text="差分查询" />
        <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" CssClass="auto-style5">
        </asp:Panel>
        <asp:Button ID="Button6" runat="server" CssClass="auto-style6" Text="报表分析" />
    </form>
</body>
</html>
