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
            left: 20%;
            z-index: 1;
            width: 60%;
            height: 60%;
            
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
            left: 40%;
            z-index: 4;
            width: 100%;
            height: 4%;
            margin-right: 0px;
        }

        @keyframes myfirst {
				from {
					width:2.5%;
                    height:5%;
                    
				}
				to {

				   width:2%;
                   height:4%;
				}
			}
        .auto-style5 {
            position: absolute;
            top: 25%;
            left: 32%;
            z-index: 6;
            width: 2%;
            height: 4%;
            
        }
        

        
        .auto-style6 {
            position: absolute;
            top: 22%;
            left: 45%;
            z-index:6;
            width:2%;
            height:4%;
        }
        .auto-style7 {
            position: absolute;
            top: 27%;
            left: 45%;
            z-index:6;
            width:2%;
            height:4%;
        }
        .auto-style8 {
            position: absolute;
            top: 37%;
            left: 32%;
            z-index: 6;
            height: 4%;
            right: 74%;
            width:2%;
        }
        .auto-style9 {
            position: absolute;
            top: 38%;
            left: 38%;
            z-index:6;
            width:2%;
            height:4%;
            right: 920px;
        }
        .auto-style10 {
            position: absolute;
            top: 38%;
            left: 45%;
            z-index: 6;
            width:2%;
            height: 4%;
            right: 822px;
        }
        .auto-style11 {
            position: absolute;
            top: 38%;
            left: 49%;
            z-index: 6;
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
            top: 16%;
            left: 16%;
            z-index: 4;
            width: 20%;
            height: 4%;
             
        }
        .auto-style16 {
            position: absolute;
            top: 23%;
            left: 29%;
            z-index: 5;
            width: 10%;
            height: 8%;
             opacity:0.5;
             border-radius:100%;
             border-color:red;
             border-width:3px;
             
        }
        .auto-style17 {
            position: absolute;
            top: 22%;
            left: 40.5%;
            z-index: 5;
            width: 9%;
            height: 5%;
             opacity:0.5;
             border-radius:100%;
             border-color:red;
             border-width:3px;
        }
        .auto-style18 {
            position: absolute;
            top: 28%;
            left: 41.5%;
            z-index: 5;
            width: 9%;
            height: 5%;
             opacity:0.5;
             border-radius:100%;
             border-color:red;
             border-width:3px;
        }
         .auto-style19 {
            position: absolute;
            top: 36%;
            left: 31.5%;
            z-index: 5;
            width: 3%;
            height: 5%;
             opacity:0.5;
             border-radius:100%;
            
        }
         .auto-style20 {
            position: absolute;
            top: 37%;
            left: 37.5%;
            z-index: 5;
            width: 3%;
            height: 5%;
            opacity:0.5;
             border-radius:100%;
             
        }
         .auto-style21 {
            position: absolute;
            top: 38%;
            left: 44.5%;
            z-index: 5;
            width: 3%;
            height: 5%;
            opacity:0.5;
             border-radius:100%;
             
        }
         .auto-style22 {
            position: absolute;
            top: 38%;
            left: 48.5%;
            z-index: 5;
            width: 3%;
            height: 5%;
            opacity:0.5;
             border-radius:100%;
             
        }
         .auto-style68 {
            position: absolute;
            top: 14%;
            left: 0%;
            width: 9%;
            height:30%;
            z-index: 3;
           
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
            top: 23%;
            left: 5%;
            width: 100%;
            height:3%;
            z-index: 4;
           
        }
           .auto-style72 {
            position: absolute;
            top: 22%;
            left: 5%;
            width: 20%;
            height:7%;
            z-index: 3;
           
        }
            .auto-style73 {
            position: absolute;
            top: 38%;
            left: 5%;
            width: 100%;
            height:3%;
            z-index: 4;
           
        }
            .auto-style74 {
            position: absolute;
            top: 37%;
            left: 5%;
            width: 30%;
            height:7%;
            z-index: 3;
           
        }
             .auto-style75 {
            position: absolute;
            top: 53%;
            left: 5%;
            width: 100%;
            height:3%;
            z-index: 4;
           
        }
             .auto-style76 {
            position: absolute;
            top: 52%;
            left: 5%;
            width: 40%;
            height:7%;
            z-index: 3;
           
        }
             .auto-style77 {
            position: absolute;
            top: 68%;
            left: 5%;
            width: 100%;
            height:3%;
            z-index: 4;
           
        }
             .auto-style78 {
            position: absolute;
            top: 67%;
            left: 4%;
            width: 50%;
            height:7%;
            z-index: 3;
           
        }
             .auto-style79 {
            position: absolute;
            top: 83%;
            left: 5%;
            width: 100%;
            height:3%;
            z-index: 4;
           
        }
             .auto-style80 {
            position: absolute;
            top: 82%;
            left: 5%;
            width: 60%;
            height:7%;
            z-index: 3;
           
        }
           .auto-style81 {
            position: absolute;
            top: 14%;
            left: 0.4%;
            width: 9%;
            height:4%;
            z-index: 3;
           

           
        }
           .auto-style82 {
            position: absolute;
            top: 11%;
            left: 75%;
            width: 25%;
            height:81%;
            z-index: 4;
            opacity:0.75;
           

           
        }
            .auto-style86 {
            position: absolute;
            top: 0px;
            left: 20px;
            width: 3%;
            z-index: 4;
            height:5%;
        }
         
            .panel_shuliangtongji {
            position: absolute;
            top: 11%;
            left: 0;
            width: 19%;
            z-index: 4;
            height:50%;
        }   
            .Label_dangqiantongji {
            position: absolute;
            top: 5%;
            left: 2%;
            width: 80%;
            z-index: 5;
            height:10%;
        }   
            .Label_shuoming {
            position: absolute;
            top: 15%;
            left: 2%;
            width: 80%;
            z-index: 5;
            height:10%;
        }  
            .Label_label1 {
            position: absolute;
            top: 22%;
            left: 2%;
            width: 80%;
            z-index: 5;
            height: 10%;
        }
            .Label_label2 {
            position: absolute;
            top: 42%;
            left: 2%;
            width: 80%;
            z-index: 5;
            height: 10%;
        }
            .Label_label3 {
            position: absolute;
            top: 62%;
            left: 2%;
            width: 80%;
            z-index: 5;
            height: 10%;
        }
            .Label_label4 {
            position: absolute;
            top: 82%;
            left: 2%;
            width: 80%;
            z-index: 5;
            height: 10%;
        }
            .Panel_process1 {
            position: absolute;
            top: 30%;
            left: 2%;
            width: 70%;
            z-index: 5;
            height: 7%;
        }
            .Panel_process2 {
            position: absolute;
            top: 50%;
            left: 2%;
            width: 70%;
            z-index: 5;
            height: 7%;
        }
            .Panel_process3 {
            position: absolute;
            top: 70%;
            left: 2%;
            width: 70%;
            z-index: 5;
            height: 7%;
        }
            .Panel_process4 {
            position: absolute;
            top: 90%;
            left: 2%;
            width: 70%;
            z-index: 5;
            height: 7%;
        }
            .Panel_value1 {
            position: absolute;
            top: 30%;
            left: 2%;
            width: 10%;
            z-index: 6;
            height: 7%;
        }
            .Panel_value2 {
            position: absolute;
            top: 50%;
            left: 2%;
            width: 10%;
            z-index: 6;
            height: 7%;
        }
            .Panel_value3 {
            position: absolute;
            top: 70%;
            left: 2%;
            width: 10%;
            z-index: 6;
            height: 7%;
        }
            .Panel_value4 {
            position: absolute;
            top: 90%;
            left: 2%;
            width: 10%;
            z-index: 6;
            height: 7%;
        }
            .Panel_bingzhuangtu {
            position: absolute;
            top: 61%;
            left: 0%;
            width: 19%;
            z-index: 6;
            height: 38%;
        }
            .Chart_bingzhuangtu {
            position: absolute;
            top: 10%;
            left: 3%;
            width: 30px;
            z-index: 6;
            height: 30px;
        }
            .Panel_mapinfo {
            position: absolute;
            top: 13%;
            left: 21%;
            width: 50%;
            z-index: 7;
            height: 6%;
            border-radius:3%;
            opacity:0.8;
        }
            .biaozhi1 {
            position: absolute;
            top: 14%;
            left: 22%;
            width: 20px;
            z-index: 7;
            height:20px;
            border-radius:100%;
        }
             .biaozhi2 {
            position: absolute;
            top: 14%;
            left: 32%;
            width: 20px;
            z-index: 7;
            height:20px;
            border-radius:100%;
        }
             .biaozhi3 {
            position: absolute;
            top: 14%;
            left: 42%;
            width: 20px;
            z-index: 7;
            height:20px;
            border-radius:100%;
        }
             .biaozhi4 {
            position: absolute;
            top: 14%;
            left: 52%;
            width: 20px;
            z-index: 7;
            height:20px;
            border-radius:100%;
        }
             .biaozhi5 {
            position: absolute;
            top: 14%;
            left: 62%;
            width: 20px;
            z-index: 7;
            height:20px;
            border-radius:100%;
        }
             .biaozhi1_label {
            position: absolute;
            top: 14%;
            left: 24%;
            width: 80px;
            z-index: 7;
            height:20px;
            
        }
            .biaozhi2_label {
            position: absolute;
            top: 14%;
            left: 34%;
            width: 80px;
            z-index: 7;
            height:20px;
            
        }
            .biaozhi3_label {
            position: absolute;
            top: 14%;
            left: 44%;
            width: 80px;
            z-index: 7;
            height:20px;
            
        }
            .biaozhi4_label {
            position: absolute;
            top: 14%;
            left: 54%;
            width: 80px;
            z-index: 7;
            height:20px;
            
        }
            .biaozhi5_label {
            position: absolute;
            top: 14%;
            left: 64%;
            width: 80px;
            z-index: 7;
            height:20px;
            
        }
        .Panel_shebeizhuangtai {
            position: absolute;
            top: 11%;
            left: 81%;
            width: 19%;
            z-index: 7;
            height: 50%;
        }
        .Label_zaixian {
            position:absolute;
            top:80%;
            left:5%;
            width:30%;
            height:10%;
            z-index:7;
        }
        .Label_lixian {
            position:absolute;
            top:80%;
            left:35%;
            width:30%;
            height:10%;
            z-index:7;
        }
        .Label_zaixianbili {
            position:absolute;
            top:80%;
            left:65%;
            width:30%;
            height:10%;
            z-index:7;
        }
        .Label_zaixianshow
        {
            position:absolute;
            top:90%;
            left:5%;
            width:30%;
            height:10%;
            z-index:7;
        }
        .Label_lixianshow
        {
            position:absolute;
            top:90%;
            left:35%;
            width:30%;
            height:10%;
            z-index:7;
        }
        .Label_zaixianbilishow
        {
            position:absolute;
            top:90%;
            left:65%;
            width:30%;
            height:10%;
            z-index:7;
        }
        .Panel_gongnengqu
        {
            position:absolute;
            top:61%;
            left:81%;
            width:19%;
            height:38%;
            z-index:7;
        }
        .image_graft
        {
            position:absolute;
            top:20%;
            left:20%;
            width:40px;
            height:40px;
            z-index:7;
            border-radius:3px;
        }
        .image_attition
        {
            position:absolute;
            top:20%;
            left:60%;
            width:40px;
            height:40px;
            z-index:7;
            border-radius:3px;
        }
        .Image_set
        {
            position:absolute;
            top:60%;
            left:20%;
            width:40px;
            height:40px;
            z-index:7;
            border-radius:3px;
        }
        .Panel_jingbao
        {
            position:absolute;
            top:72%;
            left:20%;
            width:60%;
            height:28%;
            z-index:6;
           
        }
        .Label_baojing
        {
            position:absolute;
            top:73%;
            left:22%;
            width:100px;
            height:20px;
            z-index:6;
        }
        .Label_header1 {
            position:absolute;
            top:78%;
            left:23%;
            width:100px;
            height:20px;
            z-index:6;
        }
        .Label_header2 {
            position:absolute;
            top:78%;
            left:43%;
            width:100px;
            height:20px;
            z-index:6;
        }
        .Label_header3 {
            position:absolute;
            top:78%;
            left:63%;
            width:100px;
            height:20px;
            z-index:6;
        }
        .Label_baifenbi1
        {
            position: absolute;
            top: 30%;
            left: 83%;
            width: 70%;
            z-index: 7;
            height: 7%;
        }
        .Label_baifenbi2
        {
            position: absolute;
            top: 50%;
            left: 83%;
            width: 70%;
            z-index: 7;
            height: 7%;
        }
        .Label_baifenbi3
        {
            position: absolute;
            top: 70%;
            left: 83%;
            width: 70%;
            z-index: 7;
            height: 7%;
        }
        .Label_baifenbi4
        {
            position: absolute;
            top: 90%;
            left: 83%;
            width: 70%;
            z-index: 7;
            height: 7%;
        }
        .Panel_baojing_info
        {
            position:absolute;
            top:85%;
            left:20%;
            width:60%;
            z-index:8;
            height:15%;
        }
        .Panel_chart
        {
            position:absolute;
            top:80%;
            left:0%;
            width:80%;
            z-index:9;
            height:15%;
        }
        .label_zuidaweiyixinxi
        {
            position:absolute;
            top:5%;
            left:0%;
            width:100%;
            z-index:9;
            height:10%;
        }
        .label_quyu1
        {
            position:absolute;
            top:18%;
            left:0%;
            width:100%;
            z-index:9;
            height:5%;
        }
        .label_quyu2
        {
            position:absolute;
            top:29%;
            left:0%;
            width:100%;
            z-index:9;
            height:5%;
        }
        .label_quyu3
        {
            position:absolute;
            top:40%;
            left:0%;
            width:100%;
            z-index:9;
            height:5%;
        }
        .label_quyu4
        {
            position:absolute;
            top:51%;
            left:0%;
            width:100%;
            z-index:9;
            height:5%;
        }
        .label_quyu5
        {
            position:absolute;
            top:62%;
            left:0%;
            width:100%;
            z-index:9;
            height:5%;
        }
        .label_quyu6
        {
            position:absolute;
            top:73%;
            left:0%;
            width:100%;
            z-index:9;
            height:5%;
        }
        .label_quyu7
        {
            position:absolute;
            top:84%;
            left:0%;
            width:100%;
            z-index:9;
            height:5%;
        }
            </style>
     
<script type="text/javascript">
    function VisiblePanel2()
    {
        

        
    }
</script>


</head>
<body style="height: 100%; width:100%;">
    <form id="form1" runat="server" style="width:100%; height:100%">
    <div class="auto-style1">
        
        <!-- 关于时间的更新-->
        <asp:ScriptManager ID="ScriptManager1" runat="Server" ></asp:ScriptManager><!--必须包含这个控件，否则UpdatePanel无法使用-->  
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">  
                <ContentTemplate>
            <!--Lable和Timer控件必须都包含在UpdatePanel控件中 -->  
                  <asp:Label ID="Label_timer" CssClass="auto-style14" runat="server" Text="Label" Font-Names="微软雅黑" ForeColor="White"></asp:Label>  <!--用于显示时间-->  
                  
                   
                  <asp:Timer ID="Timer1" runat="server" Interval="1000"></asp:Timer><!-- 用于更新时间，每1秒更新一次-->  
                        
                    <asp:Panel ID="Panel_bingzhuangtu" CssClass="Panel_bingzhuangtu" runat="server" BorderColor="#00CCFF" BorderStyle="Groove" BorderWidth="3px" BackColor="#0C2B61">
            <asp:Label ID="Label_baojingshuoming" CssClass="Label_dangqiantongji" runat="server" Text="报警说明" Font-Bold="True" Font-Names="微软雅黑" ForeColor="#CCFFFF"></asp:Label>
            <asp:Chart ID="Chart_bingzhuangtu" runat="server" CssClass="Chart_bingzhuangtu" BackColor="Transparent">
                <Series>
                    <asp:Series Name="Series1" ChartType="Pie"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                       
                    </asp:ChartArea>
                </ChartAreas>
                <Titles>
                    <asp:Title Name="报警图示">
                    </asp:Title>
                </Titles>
            </asp:Chart>
        </asp:Panel>
          <asp:Panel ID="Panel_chart" CssClass="Panel_chart" runat="server" BackColor="#3333FF">
            <asp:Chart ID="Chart1" runat="server" Width="1200px" Height="200px" Visible="true">
                <Series>
                    <asp:Series Name="Series1" ChartType="Spline"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisY Title="位移量(毫米)">
                        </AxisY>
                        <AxisX Title="位置(米)">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Titles>
                    <asp:Title Name="Title1">
                    </asp:Title>
                </Titles>
            </asp:Chart>
        </asp:Panel>
                    <!--新界面信息-->
        <asp:Panel ID="Panel_shuliangtongji" CssClass="panel_shuliangtongji" runat="server" BorderColor="#00CCFF" BorderStyle="Groove" BorderWidth="3px" BackColor="#0C2B61" >
            <asp:Label ID="Label_danqiantongji" CssClass="Label_dangqiantongji" runat="server" Text="当前统计" Font-Bold="True" Font-Names="微软雅黑" ForeColor="#CCFFFF"></asp:Label>
            <asp:Label ID="Label_shuoming" CssClass="Label_shuoming" runat="server" Text="全局各个位移数量占比" Font-Bold="True" Font-Names="微软雅黑" ForeColor="#CCFFFF" Font-Size="10pt"></asp:Label>
            <asp:Label ID="Label_label1" CssClass="Label_label1" runat="server" Text="小于0.01mm" Font-Bold="True" Font-Names="微软雅黑" ForeColor="#CCFFFF" Font-Size="7pt"></asp:Label>
            <asp:Label ID="Label_label2" CssClass="Label_label2" runat="server" Text="0.01mm到0.1mm" Font-Bold="True" Font-Names="微软雅黑" ForeColor="#CCFFFF" Font-Size="7pt"></asp:Label>
            <asp:Label ID="Label_label3" CssClass="Label_label3" runat="server" Text="0.1mm到0.2mm" Font-Bold="True" Font-Names="微软雅黑" ForeColor="#CCFFFF" Font-Size="7pt"></asp:Label>
            <asp:Label ID="Label_label4" CssClass="Label_label4" runat="server" Text="大于0.2mm" Font-Bold="True" Font-Names="微软雅黑" ForeColor="Maroon" Font-Size="7pt"></asp:Label>
            <asp:Panel ID="Panel_process_1" CssClass="Panel_process1" runat="server" BackColor="#041435"></asp:Panel>
            <asp:Panel ID="Panel_process_2" CssClass="Panel_process2" runat="server" BackColor="#041435"></asp:Panel>
            <asp:Panel ID="Panel_process_3" CssClass="Panel_process3" runat="server" BackColor="#041435"></asp:Panel>
            <asp:Panel ID="Panel_process_4" CssClass="Panel_process4" runat="server" BackColor="#041435"></asp:Panel>
            <asp:Panel ID="Panel_value1" CssClass="Panel_value1" runat="server" BackColor="DarkBlue"></asp:Panel>
            <asp:Panel ID="Panel_value2" CssClass="Panel_value2" runat="server" BackColor="Blue"></asp:Panel>
            <asp:Panel ID="Panel_value3" CssClass="Panel_value3" runat="server" BackColor="LightGreen"></asp:Panel>
            <asp:Panel ID="Panel_value4" CssClass="Panel_value4" runat="server" BackColor="Red"></asp:Panel>
            <asp:Label ID="Label_baifenbi1" CssClass="Label_baifenbi1" runat="server" Text="0%" Font-Bold="True" Font-Names="微软雅黑" ForeColor="#CCFFFF" Font-Size="7pt"></asp:Label>
            <asp:Label ID="Label_baifenbi2" CssClass="Label_baifenbi2" runat="server" Text="0%" Font-Bold="True" Font-Names="微软雅黑" ForeColor="#CCFFFF" Font-Size="7pt"></asp:Label>
            <asp:Label ID="Label_baifenbi3" CssClass="Label_baifenbi3" runat="server" Text="0%" Font-Bold="True" Font-Names="微软雅黑" ForeColor="#CCFFFF" Font-Size="7pt"></asp:Label>
            <asp:Label ID="Label_baifenbi4" CssClass="Label_baifenbi4" runat="server" Text="0%" Font-Bold="True" Font-Names="微软雅黑" ForeColor="#CCFFFF" Font-Size="7pt"></asp:Label>
        </asp:Panel>
                </ContentTemplate>                  
            </asp:UpdatePanel>  
        
        <!--这里加了conditional之后，各自更新更自的-->
         <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">  
                <ContentTemplate>
                    
                        <asp:ImageButton ID="Image_point1" runat="server" CssClass="auto-style5" ImageUrl="~/Resource/position.png" OnClick="Image_point1_Click" ToolTip="一号坡 2164-2317"/>
                        <asp:ImageButton ID="Image_point2" runat="server" CssClass="auto-style6" ImageUrl="~/Resource/position.png" OnClick="Image_point2_Click" ToolTip="二号坡 2361-2558" />
                        <asp:ImageButton ID="Image_point3" runat="server" CssClass="auto-style7" ImageUrl="~/Resource/position.png" OnClick="Image_point3_Click" ToolTip="三号坡 2934-3074" />
                        <asp:ImageButton ID="Image_point4" runat="server" CssClass="auto-style8" ImageUrl="~/Resource/position.png" OnClick="Image_point4_Click" ToolTip="侧斜管标定1号管 602-675" />
                        <asp:ImageButton ID="Image_point5" runat="server" CssClass="auto-style9" ImageUrl="~/Resource/position.png" OnClick="Image_point5_Click" ToolTip="侧斜管标定2号管 742-810" />
                        <asp:ImageButton ID="Image_point6" runat="server" CssClass="auto-style10" ImageUrl="~/Resource/position.png" OnClick="Image_point6_Click" ToolTip="侧斜管标定3号管 875-939" />
                        <asp:ImageButton ID="Image_point7" runat="server" CssClass="auto-style11" ImageUrl="~/Resource/position.png" OnClick="Image_point7_Click" ToolTip="侧斜管标定4号管 994-1069" />
                           


                 </ContentTemplate>
             </asp:UpdatePanel>
          <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">  
                <ContentTemplate>
                    <asp:Panel ID="Circle1" BackColor="Orange" runat="server" CssClass="auto-style16" ToolTip="一号坡 2164-2317" >
                        
                    </asp:Panel>
                    <asp:Panel ID="Circle2" BackColor="Orange" runat="server" CssClass="auto-style17" ToolTip="二号坡 2361-2558" />
                    <asp:Panel ID="Circle3" BackColor="Orange" runat="server" CssClass="auto-style18" ToolTip="三号坡 2934-3074" />
                    <asp:Panel ID="Circle4" BackColor="Orange" runat="server" CssClass="auto-style19" ToolTip="侧斜管标定1号管 602-675" />
                    <asp:Panel ID="Circle5" BackColor="Orange" runat="server" CssClass="auto-style20" ToolTip="侧斜管标定2号管 742-810" />
                    <asp:Panel ID="Circle6" BackColor="Orange" runat="server" CssClass="auto-style21" ToolTip="侧斜管标定3号管 875-939" />
                    <asp:Panel ID="Circle7" BackColor="Orange" runat="server" CssClass="auto-style22" ToolTip="侧斜管标定4号管 994-1069" />
                    <asp:Panel ID="Panel_baojing_info" CssClass="Panel_baojing_info" runat="server" ScrollBars="Vertical" >
                        </asp:Panel> 

                    <!--区域最大位移信息-->
        <asp:Panel ID="Panel_shebeizhuangtai" CssClass="Panel_shebeizhuangtai" runat="server" BorderColor="#00CCFF" BorderStyle="Groove" BorderWidth="3px" BackColor="#0C2B61">
              <asp:Label ID="label_zuidaweiyixinxi" runat="server" ForeColor="White" Font-Size="Small" CssClass="label_zuidaweiyixinxi" Text="区域###位置###最大位移" Font-Names="微软雅黑"></asp:Label>
              <asp:Label ID="label_quyu1" runat="server" ForeColor="White" Font-Size="Smaller" CssClass="label_quyu1" Text="一号坡" Font-Names="微软雅黑"> </asp:Label>
              <asp:Label ID="label_quyu2" runat="server" ForeColor="White" Font-Size="Smaller" CssClass="label_quyu2" Text="二号坡" Font-Names="微软雅黑"> </asp:Label>
              <asp:Label ID="label_quyu3" runat="server" ForeColor="White" Font-Size="Smaller" CssClass="label_quyu3" Text="三号坡" Font-Names="微软雅黑"> </asp:Label>
              <asp:Label ID="label_quyu4" runat="server" ForeColor="White" Font-Size="Smaller" CssClass="label_quyu4" Text="一号管" Font-Names="微软雅黑"> </asp:Label>
              <asp:Label ID="label_quyu5" runat="server" ForeColor="White" Font-Size="Smaller" CssClass="label_quyu5" Text="二号管" Font-Names="微软雅黑"> </asp:Label>
              <asp:Label ID="label_quyu6" runat="server" ForeColor="White" Font-Size="Smaller" CssClass="label_quyu6" Text="三号管" Font-Names="微软雅黑"> </asp:Label>
              <asp:Label ID="label_quyu7" runat="server" ForeColor="White" Font-Size="Smaller" CssClass="label_quyu7" Text="四号管" Font-Names="微软雅黑"> </asp:Label>
        </asp:Panel>
                    <asp:Timer ID="timer" Interval="5000" runat="server"/>

                </ContentTemplate>
          </asp:UpdatePanel>

         <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" OnDataBinding="UpdatePanel4_DataBinding" Visible="false">  
                <ContentTemplate>
                     <asp:Panel ID="Panel2" CssClass="auto-style82" BackColor="Blue" runat="server" >
                         
                         
                         
                     </asp:Panel>

        
                    <asp:Timer ID="timer2" Interval="4000" runat="server" OnTick="timer2_Tick1"/>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="timer3" EventName="Tick" />
                </Triggers>
         </asp:UpdatePanel>
        <asp:Timer ID="timer3" Interval="20000" runat="server" OnTick="timer3_Tick"/>
         <asp:Panel ID="Panel1" CssClass="auto-style68" runat="server" BackColor="Silver" BorderColor="Black" BorderStyle="Solid" Visible="false">
             <asp:Label ID="Label14"  CssClass="auto-style70" runat="server" Text="线缆颜色对应位移量" ForeColor="Black" Font-Size="Smaller" Visible="false"></asp:Label>
             <asp:Label ID="Label1" CssClass="auto-style71"  runat="server" Text="<0.01mm" ForeColor="White" Font-Size="Small" Visible="false"></asp:Label>
             <asp:Label ID="Label15" CssClass="auto-style72" runat="server" Text="L" ForeColor="DarkBlue" BackColor="DarkBlue" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label16" CssClass="auto-style73" runat="server" Text="<=0.5mm" ForeColor="White" Font-Size="Small" Visible="false"></asp:Label>
             <asp:Label ID="Label17" CssClass="auto-style74" runat="server" Text="Label" ForeColor="Blue" BackColor="Blue" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label18" CssClass="auto-style75" runat="server" Text="<=1.0mm" ForeColor="White" Font-Size="Small" Visible="false"></asp:Label>
             <asp:Label ID="Label19" CssClass="auto-style76" runat="server" Text="Label" ForeColor="LightGreen" BackColor="LightGreen" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label20" CssClass="auto-style77" runat="server" Text="<2.0mm"  ForeColor="White" Font-Size="Small" Visible="false"></asp:Label>
             <asp:Label ID="Label21" CssClass="auto-style78" runat="server" Text="Label" ForeColor="Yellow" BackColor="Yellow" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label22" CssClass="auto-style79" runat="server" Text=">=2.0mm" Font-Size="Small" ForeColor="White" Visible="false"></asp:Label>
             <asp:Label ID="Label23" CssClass="auto-style80" runat="server" Text="Label" ForeColor="Red" BackColor="Red" Font-Size="Small"></asp:Label>
         </asp:Panel>
        <asp:Image ID="Image_title" CssClass="auto-style12" runat="server" BackColor="#0000CC" ImageUrl="~/Resource/图片1.png"  />
        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="auto-style15" ForeColor="White" OnClick="LinkButton1_Click1" Visible="false">报表查询</asp:LinkButton>
        
        <asp:Image ID="Image_time" CssClass="auto-style13" runat="server" BackColor="#0066FF" />
        
        <asp:Image ID="Imagebg" runat="server" CssClass="auto-style3" ImageUrl="~/Resource/bg.png" BackColor="#333300" />
         <asp:Image ID="Image_icon" CssClass="auto-style86" runat="server"  ImageUrl="~/Resource/图片2.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" />
        <asp:Label ID="Label24" runat="server" Text="报警等级" CssClass="auto-style81" BackColor="#000099" ForeColor="White" Visible="false"></asp:Label>
   
        
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
   
        
   
        <asp:Image ID="Imagemap" runat="server" CssClass="auto-style2" ImageUrl="~/Resource/pic.png" OnDataBinding="Imagemap_DataBinding" BorderStyle="Ridge" BorderColor="#00CCFF" BorderWidth="4px" />
        <asp:Label ID="Label_title" runat="server" CssClass="auto-style4" Text="坝光收费站边坡防护预警系统" Font-Names="黑体" Font-Size="15pt" ForeColor="White"></asp:Label>
         
        <asp:Panel ID="mapinfo" CssClass="Panel_mapinfo" BackColor="White"  runat="server" >
            
        </asp:Panel>
        <asp:Panel ID="biaozhi1" BackColor="DarkBlue" CssClass="biaozhi1" runat="server"/>
        <asp:Panel ID="biaozhi2" BackColor="Blue" CssClass="biaozhi2" runat="server"/>
        <asp:Panel ID="biaozhi3" BackColor="LightGreen" CssClass="biaozhi3" runat="server"/>
        <asp:Panel ID="biaozhi4" BackColor="Yellow" CssClass="biaozhi4" runat="server"/>
        <asp:Panel ID="biaozhi5" BackColor="Red" CssClass="biaozhi5" runat="server"/>
        <asp:Label ID="biaozhi1_label" CssClass="biaozhi1_label" runat="server" />
        <asp:Label ID="biaozhi2_label" CssClass="biaozhi2_label" runat="server" />
        <asp:Label ID="biaozhi3_label" CssClass="biaozhi3_label" runat="server" />
        <asp:Label ID="biaozhi4_label" CssClass="biaozhi4_label" runat="server" />
        <asp:Label ID="biaozhi5_label" CssClass="biaozhi5_label" runat="server" />

        <!--饼状图-->
        

        

        

        <!--功能区-->
        <asp:Panel ID="Panel_gongnengqu" CssClass="Panel_gongnengqu" runat="server" BorderColor="#00CCFF" BorderStyle="Groove" BorderWidth="3px" BackColor="#0C2B61">
           <asp:Label ID="Label_gongnengqu" CssClass="Label_dangqiantongji" runat="server" Text="功能区" Font-Bold="True" Font-Names="微软雅黑" ForeColor="#CCFFFF"></asp:Label>
           <asp:ImageButton ID="image_graft" CssClass="image_graft" runat="server" ImageUrl="~/Resource/graph.png" OnClick="image_graft_Click" />
           <asp:ImageButton ID="Image_baojing" CssClass="image_attition" runat="server" ImageUrl="~/Resource/attention.png" OnClick="Image_baojing_Click" />
           <asp:ImageButton ID="Image_set" CssClass="Image_set" runat="server" ImageUrl="~/Resource/settings_64px_1228852_easyicon.net.png" OnClick="Image_set_Click" />
        </asp:Panel>

        <!--报警信息-->
        <asp:Panel ID="Panel_baojing" CssClass="Panel_jingbao" runat="server" BorderColor="#00CCFF" BorderStyle="Groove" BorderWidth="3px" BackColor="#0C2B61">
            
        </asp:Panel>
        <asp:Label ID="Label_baojing" CssClass="Label_baojing" runat="server" Text="报警信息" Font-Bold="True" Font-Names="微软雅黑" ForeColor="#CCFFFF"></asp:Label>
        <asp:label ID="Label_header1"  runat="server" CssClass="Label_header1" Text="报警地点" ForeColor="White" />
        <asp:label ID="Label_header2"  runat="server" CssClass="Label_header2" Text="报警位置" ForeColor="White" />
        <asp:label ID="Label_header3"  runat="server" CssClass="Label_header3" Text="位移量" ForeColor="White" />

        
    </div>
    </form>
</body>
</html>



<script type="text/javascript">
    var x = window.screen.height;
    var y = window.screen.width;
    document.getElementById("HiddenField1").value = x.toString();
    document.getElementById("HiddenField2").value = y.toString();
    </script>
