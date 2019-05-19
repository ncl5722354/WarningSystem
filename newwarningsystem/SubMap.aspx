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
            top: 10%;
            left: 60%;
            height: 30%;
            width: 60%;
            z-index: 2;
        }
         .auto-style43 {
            position: absolute;
            top: 0px;
            left: 0px;
            height: 100%;
            width: 200%;
            z-index: -1;
        }
         .auto-style42 {
            position: absolute;
            top: 5%;
            left: 5%;
            height: 60%;
            width: 50%;
            z-index: 0;
        }
        </style>
</head>
<body style="height: 746px; width: 1544px">
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Image ID="Image2"  CssClass="auto-style43" runat="server"   ImageUrl="~/Resource/u=1497079183,493793446&amp;fm=26&amp;gp=0.jpg"/>
        <asp:Image ID="Image1"  CssClass="auto-style42" runat="server" />
        
       
    
       
    
       
    
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
            
        </asp:Chart>

    </form>
</body>
</html>
