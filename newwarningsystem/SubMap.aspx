<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubMap.aspx.cs" Inherits="newwarningsystem.SubMap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        
        .auto-style65 {
            position: absolute;
            top: 35px;
            left: 879px;
            height: 26px;
            width: 72px;
            z-index: 2;
        }
         .auto-style44 {
            position: absolute;
            top: 35px;
            left: 1300px;
            height: 500px;
            width: 1000px;
            z-index: 2;
        }
        </style>
</head>
<body style="height: 746px; width: 1544px">
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Image ID="Image1" runat="server" Height="621px" style="margin-top: 58px" Width="1226px" />
    
       
    
       
    
       
    
        <asp:LinkButton ID="link" CssClass="auto-style65" Text="主页面" runat="server" OnClick="link0_Click"></asp:LinkButton>
       
    
       
    
        <asp:Chart ID="Chart2" runat="server" CssClass="auto-style44" BorderlineColor="Black" BorderlineDashStyle="Solid">
            <series>
                <asp:Series ChartType="Spline" Name="曲线1" Color="Red" XValueType="DateTime">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
            <BorderSkin BackColor="Transparent" BackGradientStyle="LeftRight" BackSecondaryColor="White" BorderDashStyle="Dash" BorderWidth="5" SkinStyle="Emboss" />
        </asp:Chart>

    </form>
</body>
</html>
