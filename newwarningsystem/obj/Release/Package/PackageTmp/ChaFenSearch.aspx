<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChaFenSearch.aspx.cs" Inherits="newwarningsystem.ChaFenSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

         .auto-style45 {
            position: absolute;
            top: 418px;
            left: 134px;
            z-index: 1;
            width: 172px;
            height: 262px;
        }
        .auto-style46 {
            position: absolute;
            top: 431px;
            left: 329px;
            z-index: 1;
            width: 82px;
        }
        .auto-style47 {
            position: absolute;
            top: 414px;
            z-index: 1;
            width: 171px;
            height: 262px;
            left: 426px;
            margin-top: 7px;
        }
             .auto-style51 {
            position:absolute;
            top: 432px;
            left: 45px;
            height: 39px;
            width: 83px;
            z-index:2;
            right: 571px;
        }
             .auto-style48 {
            position: absolute;
            top: 708px;
            left: 83px;
            z-index: 1;
        }
            .auto-style65 {
            position: absolute;
            top: 35px;
            left: 517px;
            height: 26px;
            width: 72px;
            z-index: 2;
            right: 104px;
        }
        .auto-style66 {
            position: absolute;
            top: 28px;
            left: 282px;
            z-index: 1;
        }
        
        </style>
</head>
<body style="height: 632px">
    <form id="form1" runat="server">
    
       
    
        <asp:Chart ID="Chart1" runat="server" CssClass="auto-style44">
            <series>
                <asp:Series ChartType="Spline" Name="曲线1" Color="Red">
                </asp:Series>
            <asp:Series ChartArea="ChartArea1" ChartType="Spline" Color="Blue" Name="曲线2"></asp:Series></series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
            <BorderSkin BorderDashStyle="Solid" SkinStyle="Emboss" />
        </asp:Chart>
    
       
    
        <asp:ListBox ID="ListBox1" runat="server" CssClass="auto-style45" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" OnTextChanged="ListBox1_TextChanged"></asp:ListBox>
        <asp:Label ID="Label3" runat="server" CssClass="auto-style46" Text="曲线2选择(蓝)"></asp:Label>
        <asp:ListBox ID="ListBox2" runat="server" CssClass="auto-style47" OnSelectedIndexChanged="ListBox2_SelectedIndexChanged"></asp:ListBox>
        <asp:Label ID="Label4" runat="server" CssClass="auto-style51" Text="曲线1选择(红)"></asp:Label>
    
       
    
       
    
       
    
        <asp:LinkButton ID="link" CssClass="auto-style65" Text="主页面" runat="server" OnClick="link_Click"></asp:LinkButton>
       
    
       
    
        <asp:Label ID="Label5" runat="server" CssClass="auto-style66" Font-Bold="True" Font-Size="40pt" Text="Label"></asp:Label>
        <p>
        <asp:Button ID="Button1" runat="server" CssClass="auto-style48" OnClick="Button1_Click" Text="确认" />
    
       
    
       
    
       
    
        </p>
        </form>
</body>
</html>
