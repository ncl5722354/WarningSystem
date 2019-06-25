<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubMap.aspx.cs" Inherits="newwarningsystem.SubMap" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style14 {
            position: absolute;
            top: 1%;
            left: 70%;
            height: 4%;
            width: 20%;
            z-index: 4;
        }

        .auto-style65 {
            position: absolute;
            top: 1%;
            height: 4%;
            width: 5%;
            z-index: 4;
        }
         .auto-style43 {
            position: absolute;
            top: 0px;
            left: 0px;
            height: 99%;
            width: 100%;
            z-index: -1;
        }
         .auto-style42 {
            position: absolute;
            top: 15%;
            left: 20%;
            z-index: 1;
            width: 60%;
            height: 60%;
        }
         
         .auto-style44 {
            position: absolute;
            top: 9%;
            left: 35%;
           
            z-index: 6;
        }
         .auto-style68 {
            position: absolute;
            top: 15%;
            left: 0%;
            width: 15%;
            height:60%;
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
            top: 5%;
            left: 0%;
            width: 100%;
            height:3%;
            z-index: 3;
           
        }
           .auto-style71 {
            position: absolute;
            top: 13%;
            left: 5%;
            width: 100%;
            height:3%;
            z-index: 4;
           
        }
           .auto-style72 {
            position: absolute;
            top: 12%;
            left: 5%;
            width: 40%;
            height:6%;
            z-index: 3;
           
        }
            .auto-style73 {
            position: absolute;
            top: 24%;
            left: 5%;
            width: 100%;
            height:3%;
            z-index: 4;
           
        }
            .auto-style74 {
            position: absolute;
            top: 23%;
            left: 5%;
            width: 50%;
            height:6%;
            z-index: 3;
           
        }
             .auto-style75 {
            position: absolute;
            top: 34%;
            left: 5%;
            width: 100%;
            height:3%;
            z-index: 4;
           
        }
             .auto-style76 {
            position: absolute;
            top: 33%;
            left: 5%;
            width: 60%;
            height:6%;
            z-index: 3;
           
        }
             .auto-style77 {
            position: absolute;
            top: 44%;
            left: 5%;
            width: 100%;
            height:3%;
            z-index: 4;
           
        }
             .auto-style78 {
            position: absolute;
            top: 43%;
            left: 5%;
            width: 70%;
            height:6%;
            z-index: 3;
           
        }
             .auto-style79 {
            position: absolute;
            top: 54%;
            left: 5%;
            width: 100%;
            height:3%;
            z-index: 4;
           
        }
             .auto-style80 {
            position: absolute;
            top: 53%;
            left: 5%;
            width: 80%;
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
            left: -3px;
            width: 100%;
            z-index: 3;
            height:5%;
        }
              .auto-style83 {
            position: absolute;
            top: 0px;
            left: 20px;
            width: 3%;
            z-index: 4;
            height:5%;
        }

              .auto-style84 {
            position: absolute;
            top: 0px;
            left: 20%;
            width: 40%;
            z-index: 5;
            height:5%;
        }
            .auto-style85 {
            position: absolute;
            top: 5%;
            left: 0%;
            width: 15%;
            z-index: 5;
            height:10%;
        }
             .auto-style86 {
            position: absolute;
            top: 8%;
            left: 4%;
            width: 15%;
            z-index: 6;
            height:10%;
        }
             .auto-style87 {
            position: absolute;
            top: 15%;
            left: 75%;
            width: 25%;
            z-index: 6;
            height:10%;
        }
             .auto-style88 {
            position: absolute;
            top: 18%;
            left: 85%;
            width: 25%;
            z-index: 7;
            height:7%;
        }
             .auto-style89 {
            position: absolute;
            top: 48%;
            left: 75%;
            width: 25%;
            z-index: 6;
            height:7%;
        }
             .auto-style90 {
            position: absolute;
            top: 48%;
            left: 85%;
            width: 25%;
            z-index: 7;
            height:10%;
        } .auto-style91 {
            position: absolute;
            top: 50%;
            left: 75%;
            width: 25%;
            z-index: 6;
            height:25%;
        }
          .auto-style92 {
            position: absolute;
            top: 60%;
            left: 79%;
            width: 10%;
            z-index: 7;
            height:10%;
        }
          .auto-style93 {
            position: absolute;
            top: 60%;
            left: 87%;
            width: 10%;
            z-index: 7;
            height:10%;
        }
          .auto-style94 {
            position: absolute;
            top: 6%;
            left: 60%;
            width: 5%;
            z-index: 7;
            height:8%;
            right: 358px;
        }
           .auto-style95 {
            position: absolute;
            top: 6%;
            left: 68%;
            width: 5%;
            z-index: 7;
            height:8%;
        }
            .auto-style96 {
            position: absolute;
            top: 6%;
            left: 76%;
            width: 5%;
            z-index: 7;
            height:8%;
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
            .Panel_shebeizhuangtai {
            position: absolute;
            top: 11%;
            left: 81%;
            width: 19%;
            z-index: 7;
            height: 50%;
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
            top: 19%;
            left: 21%;
            width: 50%;
            z-index: 7;
            height: 7%;
            border-radius:3%;
            opacity:0.8;
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
            left:21%;
            width:40px;
            height:40px;
            z-index:7;
            border-radius:3px;
        }
        .Image_home{
            position:absolute;
            top:60%;
            left:60%;
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
         .Panel_mapinfo {
            position: absolute;
            top: 15%;
            left: 21%;
            width: 50%;
            z-index: 7;
            height: 10%;
            border-radius:3%;
            opacity:0.8;
        }
            .biaozhi1 {
            position: absolute;
            top: 20%;
            left: 22%;
            width: 20px;
            z-index: 7;
            height:20px;
            border-radius:100%;
        }
             .biaozhi2 {
            position: absolute;
            top: 20%;
            left: 32%;
            width: 20px;
            z-index: 7;
            height:20px;
            border-radius:100%;
        }
             .biaozhi3 {
            position: absolute;
            top: 20%;
            left: 42%;
            width: 20px;
            z-index: 7;
            height:20px;
            border-radius:100%;
        }
             .biaozhi4 {
            position: absolute;
            top: 20%;
            left: 52%;
            width: 20px;
            z-index: 7;
            height:20px;
            border-radius:100%;
        }
             .biaozhi5 {
            position: absolute;
            top: 20%;
            left: 62%;
            width: 20px;
            z-index: 7;
            height:20px;
            border-radius:100%;
        }
             .biaozhi1_label {
            position: absolute;
            top: 20%;
            left: 24%;
            width: 80px;
            z-index: 7;
            height:20px;
            
        }
            .biaozhi2_label {
            position: absolute;
            top: 20%;
            left: 34%;
            width: 80px;
            z-index: 7;
            height:20px;
            
        }
            .biaozhi3_label {
            position: absolute;
            top: 20%;
            left: 44%;
            width: 80px;
            z-index: 7;
            height:20px;
            
        }
            .biaozhi4_label {
            position: absolute;
            top: 20%;
            left: 54%;
            width: 80px;
            z-index: 7;
            height:20px;
            
        }
            .biaozhi5_label {
            position: absolute;
            top: 20%;
            left: 64%;
            width: 80px;
            z-index: 7;
            height:20px;
            
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
         .shebeizhuangtai_table_panel
         {
             position:absolute;
            top:10%;
            left:0%;
            width:100%;
            z-index:9;
            height:90%;
            
         }
         
         .label_weizhi_title
         {
             position: absolute;
            top: 0%;
            left: 5%;
            width: 40%;
            z-index: 9;
            height: 10%;
            text-align:center; 
         }
         .label_weiyi_title
         {
             position: absolute;
            top: 0%;
            left: 50%;
            width: 40%;
            z-index: 9;
            height: 10%;
            text-align:center; 
         }
         .Label_baojingshuoming1
        {
            position:absolute;
            top:74%;
            left:2%;
            width:10%;
            z-index:10;
            height:4%;
            text-align:center;
        }
             </style>
</head>

<body style="height: 150%; width: 100%">
    <form id="form1" runat="server">
    <div>
    
        <asp:label  ID="label_warnlevel" runat="server" text="报警等级" CssClass="auto-style86" Font-Size="XX-Large" ForeColor="White" Visible="false"></asp:label>
        <asp:label  ID="label_rili" runat="server" text="日历选择" CssClass="auto-style88" Font-Size="XX-Large" ForeColor="White" Visible="false"></asp:label>
        <asp:label  ID="label_baojing" runat="server" text="报警显示" CssClass="auto-style90" Font-Size="XX-Large" ForeColor="White" Visible="false"></asp:label>
        <asp:Image ID="Image2"  CssClass="auto-style43" runat="server"   ImageUrl="~/Resource/u=1497079183,493793446&amp;fm=26&amp;gp=0.jpg"/>
        <asp:Label ID="Label_title" CssClass="auto-style44" runat="server" Font-Names="微软雅黑" Font-Size="20pt" ForeColor="White" Text="Label" BackColor="#FF3300" BorderStyle="Solid" BorderColor="Black" BorderWidth="3px"></asp:Label>
        <asp:Image ID="Image_icon" CssClass="auto-style83" runat="server"  ImageUrl="~/Resource/图片2.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" />
        <asp:ImageButton ID="ImageButton_set" CssClass="auto-style95" runat="server" ImageUrl="~/Resource/settings_64px_1229386_easyicon.net.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" BackColor="#3366FF" OnClick="ImageButton_set_Click" Visible="false"/>
        <asp:Image ID="Image_head" runat="server" CssClass="auto-style67" BackColor="#000066" ImageUrl="~/Resource/图片1.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px"/>
        <asp:Image ID="Image_title" CssClass="auto-style84"  runat="server" ImageUrl="~/Resource/图片3.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" />
        <asp:Image ID="Image3" CssClass="auto-style91" runat="server" ImageUrl="~/Resource/dise.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" Visible="false"/>
        <asp:Image ID="Image4" CssClass="auto-style85" runat="server" ImageUrl="~/Resource/图片4.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" Visible="false"/>
        <asp:Image ID="Image5" CssClass="auto-style87"  runat="server" ImageUrl="~/Resource/图片4.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" Visible="false"/>
        <asp:Image ID="Image6" CssClass="auto-style89"  runat="server" ImageUrl="~/Resource/图片4.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" Visible="false"/>
        <asp:Image ID="Image7" runat="server" />
        <asp:Label ID="Label_weizhi" CssClass="auto-style92" runat="server" Text="位置" Font-Names="微软雅黑" Visible="false"></asp:Label>
        <asp:Label ID="Label_weiyiliang" CssClass="auto-style93" runat="server" Text="位移量" Font-Names="微软雅黑" Visible="false"></asp:Label>
       
        <asp:ImageButton ID="ImageButton_home" runat="server" BackColor="#3366FF" CssClass="auto-style94" ImageUrl="~/Resource/home.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" OnClick="ImageButton_home_Click" Visible="false" />
        <asp:ImageButton ID="ImageButton_chafen" runat="server" BackColor="#3366FF" CssClass="auto-style96" ImageUrl="~/Resource/find_magnifier_magnifying_glass_search_zoom_64px_1225492_easyicon.net.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" OnClick="ImageButton_chafen_Click" Visible="false"/>

        <asp:Image ID="Image1"  CssClass="auto-style42" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" />
        <asp:Label ID="Label12" runat="server" CssClass="auto-style62" Text="选择日期" ForeColor="White" Visible="false"></asp:Label>
        <asp:LinkButton ID="link" CssClass="auto-style65" Text="主页面" runat="server" OnClick="link0_Click" ForeColor="White" Visible="false"></asp:LinkButton>
       <asp:Label ID="Label2" runat="server" CssClass="auto-style81" Text="选择时间" ForeColor="White" Visible="false"></asp:Label>
       <asp:Label ID="Label11" runat="server" CssClass="auto-style58" Text="趋势曲线" ForeColor="White" Visible="false"></asp:Label>
       <asp:LinkButton ID="link0" CssClass="auto-style66" Text="差分查询" runat="server" OnClick="link_Click" ForeColor="White" Visible="false"></asp:LinkButton>
       <asp:Panel ID="Panel1" CssClass="auto-style68" runat="server" BackColor="#CCFFFF" BorderColor="Black" BorderStyle="Solid" Visible="false">
             <asp:Label ID="Label14"  CssClass="auto-style70"  runat="server" Text="线缆颜色对应位移量" ForeColor="Black" Font-Size="Smaller" ></asp:Label>
             <asp:Label ID="Label1" CssClass="auto-style71"  runat="server" Text="<0.01mm" ForeColor="White" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label15" CssClass="auto-style72" runat="server" Text="Label" ForeColor="DarkBlue" BackColor="DarkBlue" Font-Size="Small" BorderColor="Black" BorderStyle="Solid" BorderWidth="2"></asp:Label>
             <asp:Label ID="Label16" CssClass="auto-style73" runat="server" Text="<=0.5mm" Font-Size="Small" ForeColor="White"></asp:Label>
             <asp:Label ID="Label17" CssClass="auto-style74" runat="server" Text="Label" ForeColor="Blue" BackColor="Blue" Font-Size="Small" BorderColor="Black" BorderStyle="Solid" BorderWidth="2"></asp:Label>
             <asp:Label ID="Label18" CssClass="auto-style75" runat="server" Text="<=1.0mm" ForeColor="White" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label19" CssClass="auto-style76" runat="server" Text="Label" ForeColor="LightGreen" BackColor="LightGreen" Font-Size="Small" BorderColor="Black" BorderStyle="Solid" BorderWidth="2"></asp:Label>
             <asp:Label ID="Label20" CssClass="auto-style77" runat="server" Text="<2.0mm" ForeColor="White" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label21" CssClass="auto-style78" runat="server" Text="Label" ForeColor="Yellow" BackColor="Yellow" Font-Size="Small" BorderColor="Black" BorderStyle="Solid" BorderWidth="2"></asp:Label>
             <asp:Label ID="Label22" CssClass="auto-style79" runat="server" Text=">=2.0mm" ForeColor="White" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label23" CssClass="auto-style80" runat="server" Text="Label" ForeColor="Red" BackColor="Red" Font-Size="Small" BorderColor="Black" BorderStyle="Solid" BorderWidth="2"></asp:Label>
         </asp:Panel>


        <!-- 关于时间的更新-->
        <asp:ScriptManager ID="ScriptManager1" runat="Server" ></asp:ScriptManager><!--必须包含这个控件，否则UpdatePanel无法使用-->  
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">  
                <ContentTemplate>
            <!--Lable和Timer控件必须都包含在UpdatePanel控件中 -->  
                    <asp:Label ID="Label_timer" CssClass="auto-style14" runat="server" Text="Label" Font-Names="微软雅黑" ForeColor="White" Font-Size="Large"></asp:Label>  <!--用于显示时间-->  
                     <asp:Label ID="Label_baojingshuoming1" CssClass="Label_baojingshuoming1" runat="server" Text="总体说明" Font-Bold="True" Font-Names="微软雅黑" ForeColor="#CCFFFF"></asp:Label>
                    
                    <asp:Timer ID="Timer1" runat="server" Interval="1000"></asp:Timer><!-- 用于更新时间，每1秒更新一次-->  
                    <!--饼状图-->
        <asp:Panel ID="Panel_bingzhuangtu" CssClass="Panel_bingzhuangtu" runat="server" BorderColor="#00CCFF" BorderStyle="Groove" BorderWidth="3px" BackColor="#0C2B61">
            <asp:Label ID="Label_baojingshuoming" CssClass="Label_dangqiantongji" runat="server" Text="总体说明" Font-Bold="True" Font-Names="微软雅黑" ForeColor="#CCFFFF"></asp:Label>
        </asp:Panel>

                    <asp:Panel ID="Panel_chart" CssClass="Panel_chart" runat="server" BackColor="#3333FF">
        <asp:Chart ID="Chart2" runat="server"  BorderlineColor="Black" BorderlineDashStyle="Solid" BackColor="DarkGray" Width="961px" BorderlineWidth="3">
            <series>
                <asp:Series ChartType="Spline" Name="曲线1" Color="RoyalBlue" XValueType="DateTime" ToolTip="时间 ：#VALX 位移#VAL " YValuesPerPoint="2">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisY Enabled="True" Title="位移量(mm)">
                    </AxisY>
                    <AxisX Enabled="True" Title="时间">
                    </AxisX>
                </asp:ChartArea>
            </chartareas>
            <Titles>
                <asp:Title Name="Title1" Text="曲线">
                </asp:Title>
            </Titles>
            <BorderSkin BackColor="Transparent" BackSecondaryColor="White" BorderDashStyle="Dash" BorderWidth="5" />
        </asp:Chart>
      </asp:Panel>
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
            <asp:Timer  runat="server" Interval="5000"/>
        </asp:Panel>


       
        <asp:Panel ID="Panel_baojing_info" CssClass="Panel_baojing_info" runat="server" ScrollBars="Vertical" >
        </asp:Panel> 
                </ContentTemplate>                  
            </asp:UpdatePanel>     
        <!-- 鼠标点到点上 -->
        <asp:UpdatePanel ID="updatepanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate >
                <asp:Panel ID="Panel_shebeizhuangtai" CssClass="Panel_shebeizhuangtai" runat="server" BorderColor="#00CCFF" BorderStyle="Groove" BorderWidth="3px" BackColor="#0C2B61">
                <asp:Panel ID="shebeizhuangtai_table_panel" CssClass="shebeizhuangtai_table_panel" runat="server" ScrollBars="Vertical"></asp:Panel>
                <asp:Label ID="label_weizhi_title" CssClass="label_weizhi_title" runat="server" Text="位置(m)" BorderStyle="Solid" BorderWidth="2px" BorderColor="Black"  ForeColor="White"></asp:Label>
                <asp:Label ID="label_weiyi_title" CssClass="label_weiyi_title" runat="server" Text="位移(mm)" BorderStyle="Solid" BorderWidth="2px" BorderColor="Black"  ForeColor="White"></asp:Label>
                <asp:Timer  runat="server" Interval="10000"/>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>

         <div style="position: absolute; z-index: 5; top: 25%; width: 25%; height: 20%; left: 75%;">
             
       </div>
    <asp:ListBox ID="ListBox3" runat="server" CssClass="auto-style61" AutoPostBack="True" OnSelectedIndexChanged="ListBox3_SelectedIndexChanged" BackColor="#9999FF" Visible="false"></asp:ListBox>
    <asp:ListBox ID="ListBox4" runat="server" CssClass="auto-style82" AutoPostBack="True" OnSelectedIndexChanged="ListBox4_SelectedIndexChanged" BackColor="#9999FF" Visible="false"></asp:ListBox>
     
       
        <asp:Label ID="Label13" CssClass="auto-style69" runat="server" Text="图例" ForeColor="White" Visible="false"></asp:Label>
       <!--新界面信息-->
        
        
        

       

        <!--功能区-->
        <asp:Panel ID="Panel_gongnengqu" CssClass="Panel_gongnengqu" runat="server" BorderColor="#00CCFF" BorderStyle="Groove" BorderWidth="3px" BackColor="#0C2B61">
           <asp:Label ID="Label_gongnengqu" CssClass="Label_dangqiantongji" runat="server" Text="功能区" Font-Bold="True" Font-Names="微软雅黑" ForeColor="#CCFFFF"></asp:Label>
           <asp:ImageButton ID="image_graft" CssClass="image_graft" runat="server" ImageUrl="~/Resource/graph.png" OnClick="image_graft_Click" />
           <asp:ImageButton ID="Image_baojing" CssClass="image_attition" runat="server" ImageUrl="~/Resource/attention.png" OnClick="Image_baojing_Click" />
           <asp:ImageButton ID="Image_set" CssClass="Image_set" runat="server" ImageUrl="~/Resource/settings_64px_1228852_easyicon.net.png" OnClick="Image_set_Click" Visible="False" />
           <asp:ImageButton ID="Image_home" CssClass="Image_home" runat="server" ImageUrl="~/Resource/home.png" OnClick="ImageButton_home_Click" />
        </asp:Panel>


        <!--报警信息-->
        <asp:Panel ID="Panel_baojing" CssClass="Panel_jingbao" runat="server" BorderColor="#00CCFF" BorderStyle="Groove" BorderWidth="3px" BackColor="#0C2B61">
            
        </asp:Panel>
        <asp:Label ID="Label3" CssClass="Label_baojing" runat="server" Text="报警信息" Font-Bold="True" Font-Names="微软雅黑" ForeColor="#CCFFFF"></asp:Label>
        <asp:label ID="Label_header1"  runat="server" CssClass="Label_header1" Text="报警地点" ForeColor="White" />
        <asp:label ID="Label_header2"  runat="server" CssClass="Label_header2" Text="报警位置" ForeColor="White" />
        <asp:label ID="Label_header3"  runat="server" CssClass="Label_header3" Text="位移量" ForeColor="White" />
        
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
    </div>
    </form>
</body>
</html>
