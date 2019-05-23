<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubMap.aspx.cs" Inherits="newwarningsystem.SubMap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        
        .auto-style65 {
            position: absolute;
            top: 1%;
            left: 10%;
            height: 4%;
            width: 5%;
            z-index: 4;
        }
         .auto-style43 {
            position: absolute;
            top: 0px;
            left: 0px;
            height: 150%;
            width: 100%;
            z-index: -1;
        }
         .auto-style42 {
            position: absolute;
            top: 15%;
            left: 15%;
            height: 60%;
            width: 50%;
            z-index: 0;
        }
         
         .auto-style44 {
            position: absolute;
            top: 5%;
            left: 20%;
            height: 5%;
            width: 20%;
            z-index: 0;
        }
         .auto-style68 {
            position: absolute;
            top: 20%;
            left: 5%;
            width: 9%;
            height:30%;
            z-index: 3;
            right: -466px;
        }
         .auto-style69 {
            position: absolute;
            top: 15%;
            left: 8%;
            width: 13%;
            height:6%;
            z-index: 3;
            right: 3px;
        }
          .auto-style70 {
            position: absolute;
            top: 0%;
            left: 0%;
            width: 100%;
            height:3%;
            z-index: 3;
           
        }
           .auto-style71 {
            position: absolute;
            top: 15%;
            left: 0%;
            width: 100%;
            height:3%;
            z-index: 3;
           
        }
           .auto-style72 {
            position: absolute;
            top: 22%;
            left: 20%;
            width: 50%;
            height:6%;
            z-index: 3;
           
        }
            .auto-style73 {
            position: absolute;
            top: 30%;
            left: 0%;
            width: 100%;
            height:3%;
            z-index: 3;
           
        }
            .auto-style74 {
            position: absolute;
            top: 37%;
            left: 20%;
            width: 50%;
            height:6%;
            z-index: 3;
           
        }
             .auto-style75 {
            position: absolute;
            top: 45%;
            left: 0%;
            width: 100%;
            height:3%;
            z-index: 3;
           
        }
             .auto-style76 {
            position: absolute;
            top: 52%;
            left: 20%;
            width: 50%;
            height:6%;
            z-index: 3;
           
        }
             .auto-style77 {
            position: absolute;
            top: 60%;
            left: 0%;
            width: 100%;
            height:3%;
            z-index: 3;
           
        }
             .auto-style78 {
            position: absolute;
            top: 67%;
            left: 20%;
            width: 50%;
            height:6%;
            z-index: 3;
           
        }
             .auto-style79 {
            position: absolute;
            top: 75%;
            left: 0%;
            width: 100%;
            height:3%;
            z-index: 3;
           
        }
             .auto-style80 {
            position: absolute;
            top: 82%;
            left: 20%;
            width: 50%;
            height:6%;
            z-index: 3;
           
        }
             .auto-style58 {
            
            position: absolute;
            top: 70%;
            left: 70%;
            z-index: 4;
            width: 500px;
            height: 27px;
        
        }
             .auto-style61 {
            position: absolute;
            top: 40%;
            left:70%;
            z-index: 1;
            width: 121px;
            height: 200px;
        }
              .auto-style81 {
            position: absolute;
            top: 37%;
            left: 80%;
            z-index: 1;
            width: 188px;
            height: 35px;
           
        }
              .auto-style62 {
            position: absolute;
            top: 37%;
            left: 70%;
            z-index: 1;
            width: 188px;
            height: 35px;
           
        }
             .auto-style82 {
            position: absolute;
            top: 40%;
            left: 80%;
            z-index: 1;
            width: 121px;
            height: 200px;
        }
             .auto-style66 {
            position: absolute;
            top: 1%;
            left: 15%;
            width: 10%;
            z-index: 4;
            height:4%;
        }
             .auto-style67 {
            position: absolute;
            top: 0px;
            left: 0px;
            width: 100%;
            z-index: 3;
            height:5%;
        }
             </style>
</head>
<body style="height: 150%; width: 100%">
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Image ID="Image2"  CssClass="auto-style43" runat="server"   ImageUrl="~/Resource/u=1497079183,493793446&amp;fm=26&amp;gp=0.jpg"/>
        <asp:Label ID="Label_title"  CssClass="auto-style44" runat="server" Font-Names="微软雅黑" Font-Size="20pt" ForeColor="White" Text="Label"></asp:Label>
        <asp:Image ID="Image_head" runat="server" CssClass="auto-style67" BackColor="#000066" />
        <asp:Image ID="Image1"  CssClass="auto-style42" runat="server" />
        <asp:Label ID="Label12" runat="server" CssClass="auto-style62" Text="选择日期" ForeColor="White"></asp:Label>
        <asp:LinkButton ID="link" CssClass="auto-style65" Text="主页面" runat="server" OnClick="link0_Click" ForeColor="White"></asp:LinkButton>
       <asp:Label ID="Label2" runat="server" CssClass="auto-style81" Text="选择时间" ForeColor="White"></asp:Label>
    <asp:Label ID="Label11" runat="server" CssClass="auto-style58" Text="趋势曲线" ForeColor="White"></asp:Label>
         <asp:LinkButton ID="link0" CssClass="auto-style66" Text="差分查询" runat="server" OnClick="link_Click" ForeColor="White"></asp:LinkButton>
       <asp:Panel ID="Panel1" CssClass="auto-style68" runat="server" BackColor="#CCFFFF">
             <asp:Label ID="Label14"  CssClass="auto-style70"  runat="server" Text="线缆颜色对应位移量" ForeColor="Black" Font-Size="Smaller"></asp:Label>
             <asp:Label ID="Label1" CssClass="auto-style71"  runat="server" Text="位移量<0.01mm" ForeColor="Black" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label15" CssClass="auto-style72" runat="server" Text="Label" ForeColor="DarkBlue" BackColor="DarkBlue" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label16" CssClass="auto-style73" runat="server" Text="位移量<=0.5mm" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label17" CssClass="auto-style74" runat="server" Text="Label" ForeColor="Blue" BackColor="Blue" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label18" CssClass="auto-style75" runat="server" Text="位移量<=1.0mm" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label19" CssClass="auto-style76" runat="server" Text="Label" ForeColor="LightGreen" BackColor="LightGreen" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label20" CssClass="auto-style77" runat="server" Text="位移量<2.0mm" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label21" CssClass="auto-style78" runat="server" Text="Label" ForeColor="Yellow" BackColor="Yellow" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label22" CssClass="auto-style79" runat="server" Text="位移量>=2.0mm" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label23" CssClass="auto-style80" runat="server" Text="Label" ForeColor="Red" BackColor="Red" Font-Size="Small"></asp:Label>
         </asp:Panel>
    <asp:ListBox ID="ListBox3" runat="server" CssClass="auto-style61" AutoPostBack="True" OnSelectedIndexChanged="ListBox3_SelectedIndexChanged" BackColor="#9999FF"></asp:ListBox>
    <asp:ListBox ID="ListBox4" runat="server" CssClass="auto-style82" AutoPostBack="True" OnSelectedIndexChanged="ListBox4_SelectedIndexChanged" BackColor="#9999FF"></asp:ListBox>
        <asp:Chart ID="Chart2" runat="server"  BorderlineColor="Black" BorderlineDashStyle="Solid" BackColor="DarkGray">
            <series>
                <asp:Series ChartType="Spline" Name="曲线1" Color="RoyalBlue" XValueType="DateTime" ToolTip="时间 ：#VALX 位移#VAL " YValuesPerPoint="2">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisY Enabled="True">
                    </AxisY>
                    <AxisX Enabled="True">
                    </AxisX>
                </asp:ChartArea>
            </chartareas>
            <BorderSkin BackColor="Transparent" BackSecondaryColor="White" BorderDashStyle="Dash" BorderWidth="5" />
        </asp:Chart>
        <asp:Label ID="Label13" CssClass="auto-style69" runat="server" Text="图例" ForeColor="White"></asp:Label>
    </form>
</body>
</html>
