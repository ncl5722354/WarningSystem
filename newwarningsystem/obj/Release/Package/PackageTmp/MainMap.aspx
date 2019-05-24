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
            top: 11%;
            left: 10%;
            z-index: 1;
            width: 80%;
            height: 80%;
            
        }
        .auto-style3 {
            position: absolute;
            top: 0px;
            left: -1px;
            z-index: 1;
            width: 100%;
            height: 100%;
        }
        .auto-style4 {
            position: absolute;
            top: 1%;
            left: 0%;
            z-index: 4;
            width: 100%;
            height: 4%;
            margin-right: 0px;
        }
        .auto-style5 {
            position: absolute;
            top: 30%;
            left: 28%;
            z-index: 1;
            width: 2%;
            height: 4%;
        }
        .auto-style6 {
            position: absolute;
            top: 26%;
            left: 43%;
            z-index:1;
            width:2%;
            height:4%;
        }
        .auto-style7 {
            position: absolute;
            top: 32%;
            left: 43%;
            z-index:1;
            width:2%;
            height:4%;
        }
        .auto-style8 {
            position: absolute;
            top: 46%;
            left: 25%;
            z-index: 1;
            height: 4%;
            right: 74%;
            width:2%;
        }
        .auto-style9 {
            position: absolute;
            top: 48%;
            left: 34%;
            z-index:1;
            width:2%;
            height:4%;
            right: 920px;
        }
        .auto-style10 {
            position: absolute;
            top: 48%;
            left: 41%;
            z-index: 1;
            width:2%;
            height: 4%;
            right: 822px;
        }
        .auto-style11 {
            position: absolute;
            top: 48%;
            left: 47%;
            z-index: 1;
            width: 2%;
            height: 4%;
        }
        .auto-style12 {
            position: absolute;
            top: 0%;
            left: 0%;
            z-index: 3;
            width: 100%;
            height: 5%;
        }
        .auto-style13 {
            position: absolute;
            top: 5%;
            left: 0%;
            z-index: 3;
            width: 100%;
            height: 5%;
        }
        .auto-style14 {
            position: absolute;
            top: 6%;
            left: 70%;
            z-index: 4;
            width: 20%;
            height: 5%;
        }
        .auto-style15 {
            position: absolute;
            top: 6%;
            left: 10%;
            z-index: 4;
            width: 20%;
            height: 4%;
        }
        </style>
</head>
<body style="height: 100%; width:100%;">
    <form id="form1" runat="server" style="width:100%; height:100%">
    <div class="auto-style1">
        
        <!-- 关于时间的更新-->
        <asp:ScriptManager ID="ScriptManager1" runat="Server" ></asp:ScriptManager><!--必须包含这个控件，否则UpdatePanel无法使用-->  
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">  
                <ContentTemplate>当前时间是：  
            <!--Lable和Timer控件必须都包含在UpdatePanel控件中 -->  
                    <asp:Label ID="Label_timer" CssClass="auto-style14" runat="server" Text="Label" Font-Names="微软雅黑" ForeColor="White"></asp:Label>  <!--用于显示时间-->  
                    <asp:Timer ID="Timer1" runat="server" Interval="1000"></asp:Timer><!-- 用于更新时间，每1秒更新一次-->  
                </ContentTemplate>                  
            </asp:UpdatePanel>     
        <!-- 鼠标点到点上 -->

        <asp:Image ID="Image_title" CssClass="auto-style12" runat="server" BackColor="#0000CC"  />
        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="auto-style15" ForeColor="White" OnClick="LinkButton1_Click1">报表查询</asp:LinkButton>
        <asp:Image ID="Image_time" CssClass="auto-style13" runat="server" BackColor="#0066FF" />
        <asp:Image ID="Imagebg" runat="server" CssClass="auto-style3" ImageUrl="~/Resource/u=1497079183,493793446&amp;fm=26&amp;gp=0.jpg" BackColor="#333300" />
        <asp:Image ID="Imagemap" runat="server" CssClass="auto-style2" ImageUrl="~/Resource/pic.png" OnDataBinding="Imagemap_DataBinding" BorderStyle="Solid" />
        <asp:Label ID="Label_title" runat="server" CssClass="auto-style4" Text="坝光收费站边坡防护预警系统" Font-Names="黑体" Font-Size="15pt" ForeColor="White"></asp:Label>
         <asp:ImageButton ID="Image_point1" runat="server" CssClass="auto-style5" ImageUrl="~/Resource/position.png" OnClick="Image_point1_Click" ToolTip="一号坡 2164-2317" onmouseover="point1_in()" />
        <asp:ImageButton ID="Image_point2" runat="server" CssClass="auto-style6" ImageUrl="~/Resource/position.png" style="z-index: 1" OnClick="Image_point2_Click" ToolTip="二号坡 2361-2558" />
        <asp:ImageButton ID="Image_point3" runat="server" CssClass="auto-style7" ImageUrl="~/Resource/position.png" style="z-index: 1" OnClick="Image_point3_Click" ToolTip="三号坡 2934-3074" />
        <asp:ImageButton ID="Image_point4" runat="server" CssClass="auto-style8" ImageUrl="~/Resource/position.png" OnClick="Image_point4_Click" ToolTip="侧斜管标定1号管 602-675" />
        <asp:ImageButton ID="Image_point5" runat="server" CssClass="auto-style9" ImageUrl="~/Resource/position.png" OnClick="Image_point5_Click" ToolTip="侧斜管标定2号管 742-810" />
        <asp:ImageButton ID="Image_point6" runat="server" CssClass="auto-style10" ImageUrl="~/Resource/position.png" OnClick="Image_point6_Click" ToolTip="侧斜管标定3号管 875-939" />
         <asp:ImageButton ID="Image_point7" runat="server" CssClass="auto-style11" ImageUrl="~/Resource/position.png" OnClick="Image_point7_Click" ToolTip="侧斜管标定4号管 994-1069" />
    </div>
    </form>
</body>
</html>


