<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chart.aspx.cs" Inherits="newwarningsystem.Chart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style86 {
            position: absolute;
            top: 0px;
            left: 20px;
            width: 3%;
            z-index: 4;
            height:5%;
        }
        .auto-style12 {
            position: absolute;
            top: -2147483648%;
            left: 1%;
            z-index: 3;
            width: 100%;
            height: 5%;
        }
        .auto-style4 {
            position: absolute;
            top: 1%;
            left: 40%;
            z-index: 4;
            width: 100%;
            height: 4%;
            margin-right: 0px;
        }

        .auto-style13 {
            position: absolute;
            top: -2147483648%;
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
        .bg{
            position: absolute;
            z-index:1;
        }
        .zongchar{
            position: absolute;
            top:15%;
            left:20px;
            z-index:5;
            height:40%;
        }
        .fenchar{
            position: absolute;
            top:60%;
            left:20px;
            z-index:5;
            height:40%;
        }
        .Button1{
            position: absolute;
            top:55%;
            left:10%;
            z-index:6;
            width:5%;
            height:5%;
        } 
        .Button2{
            position: absolute;
            top:55%;
            left:18%;
            z-index:6;
            width:5%;
            height:5%;
        }     
        .Button3{
            position: absolute;
            top:55%;
            left:26%;
            z-index:6;
            width:5%;
            height:5%;
        }     
        .Button4{
            position: absolute;
            top:55%;
            left:34%;
            z-index:6;
            width:5%;
            height:5%;
        } 
        .Button5{
            position: absolute;
            top:55%;
            left:42%;
            z-index:6;
            width:5%;
            height:5%;
        } 
        .Button6{
            position: absolute;
            top:55%;
            left:50%;
            z-index:6;
            width:5%;
            height:5%;
        }  
        .Button7{
            position: absolute;
            top:55%;
            left:58%;
            z-index:6;
            width:5%;
            height:5%;
        }     
        .auto-style87 {
            position: absolute;
            top: 55%;
            left: 10%;
            z-index: 6;
            width: 5%;
            height: 5%;
            right: 771px;
        }
        .auto-style88 {
            position: absolute;
            top: -2147483648%;
            left: 27%;
            z-index: 6;
            width: 5%;
            height: 5%;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="坡道1"  CssClass="auto-style87" OnClick="Button1_Click" />
         <asp:Button ID="Button2" runat="server" Text="坡道2" CssClass="Button2" OnClick="Button2_Click" />
         <asp:Button ID="Button3" runat="server" Text="坡道3" CssClass="Button3" OnClick="Button3_Click" />
         <asp:Button ID="Button4" runat="server" Text="管道1" CssClass="Button4" OnClick="Button4_Click" />
        <asp:Button ID="Button5" runat="server" Text="管道2" CssClass="Button5" OnClick="Button5_Click" />
        <asp:Button ID="Button6" runat="server" Text="管道3" CssClass="Button6" OnClick="Button6_Click" />
        <asp:Button ID="Button7" runat="server" Text="管道4" CssClass="Button7" OnClick="Button7_Click" />
        <asp:Panel  ID="panelbg" Width="100%" Height="100%" runat="server" BorderColor="#003399" CssClass="bg">
            
            
           
            
        </asp:Panel>
        <asp:Image ID="Image_icon" CssClass="auto-style86" runat="server"  ImageUrl="~/Resource/图片2.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" />
        <asp:Image ID="Image_title" CssClass="auto-style12" runat="server" BackColor="#0000CC" ImageUrl="~/Resource/图片1.png"  />
        <asp:Label ID="Label_title" runat="server" CssClass="auto-style4" Text="坝光收费站边坡防护预警系统" Font-Names="黑体" Font-Size="15pt" ForeColor="White"></asp:Label>
         <asp:ScriptManager ID="ScriptManager1" runat="Server" ></asp:ScriptManager><!--必须包含这个控件，否则UpdatePanel无法使用-->  
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">  
                <ContentTemplate> 
            <!--Lable和Timer控件必须都包含在UpdatePanel控件中 -->  
                        <asp:Label ID="Label_timer" CssClass="auto-style14" runat="server" Text="Label" Font-Names="微软雅黑" ForeColor="White"></asp:Label>  <!--用于显示时间-->  
                        <asp:Timer ID="Timer1" runat="server" Interval="1000"></asp:Timer><!-- 用于更新时间，每1秒更新一次-->  

                   </ContentTemplate>
            </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">  
                <ContentTemplate> 
           
               <asp:Chart ID="Chart1" runat="server" CssClass="zongchar" BorderlineColor="Black" BorderlineDashStyle="Solid" BorderlineWidth="3" Height="193px" Width="834px">
                <Series>
                    <asp:Series Name="Series1">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisY Title="位移(mm)">
                        </AxisY>
                        <AxisX Title="位置(m)" Interval="100">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Titles>
                    <asp:Title Name="Title1" Text="位移总览">
                    </asp:Title>
                </Titles>
                   <BorderSkin SkinStyle="Sunken" />
            </asp:Chart>
                    <asp:Chart ID="Chart2" CssClass="fenchar" runat="server" BorderlineColor="Black" BorderlineDashStyle="Solid" BorderlineWidth="3" Height="193px" Width="834px">
                <Series>
                    <asp:Series Name="Series1">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisY Title="位移(mm)">
                        </AxisY>
                        <AxisX Title="位置(m)" Interval="10">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Titles>
                    <asp:Title Name="Title1" Text="位移总览">
                    </asp:Title>
                </Titles>
                   <BorderSkin SkinStyle="Sunken" />
            </asp:Chart>

                   </ContentTemplate>
            </asp:UpdatePanel>
        <asp:Image ID="Image_time" CssClass="auto-style13" runat="server" BackColor="#0066FF" />
    </div>
    </form>
</body>
</html>
