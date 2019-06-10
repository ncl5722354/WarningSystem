<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zhuziview.aspx.cs" Inherits="newwarningsystem.zhuziview" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        
        .auto-style1 {
            height: 1017px;
        }
        .auto-style2 {
            position: absolute;
            top: 10%;
            left: 30%;
            z-index: 1;
            width: 320px;
            height: 25px;
        }
        .auto-style3 {
            position: absolute;
            top: 100px;
            left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
        .auto-style4 {
            position: absolute;
            top: 180px;
            left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
        .auto-style5 {
            position: absolute;
            top: 260px;
           left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
        .auto-style6 {
            position: absolute;
            top: 340px;
             left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
        .auto-style7 {
            position: absolute;
            top: 420px;
            left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
        .auto-style8 {
            position: absolute;
            top: 500px;
             left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
        .auto-style9 {
            position: absolute;
            top: 580px;
             left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
        .auto-style10 {
            position: absolute;
            top: 660px;
             left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
        .auto-style11 {
            position: absolute;
            top: 740px;
             left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
        .auto-style12 {
            position: absolute;
            top: 820px;
            left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
        .auto-style13 {
            position: absolute;
            top: 900px;
            left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
         .auto-style14 {
            position: absolute;
            top: 980px;
            left: 40%;
            z-index: 1;
            width: 20%;
           height: 80px;
        }
          .auto-style15 {
            position: absolute;
            top: 1060px;
            left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
           .auto-style16 {
            position: absolute;
            top: 1140px;
            left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
        .auto-style17 {
            position: absolute;
            top: 1220px;
           left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
             .auto-style18 {
            position: absolute;
            top: 1300px;
            left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
              .auto-style19 {
            position: absolute;
            top: 1380px;
           left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
               .auto-style20 {
            position: absolute;
            top: 1460px;
            left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
                .auto-style21 {
            position: absolute;
            top: 1540px;
            left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
                 .auto-style22 {
            position: absolute;
            top: 1620px;
            left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
                  .auto-style23 {
            position: absolute;
            top: 1700px;
            left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
         .auto-style24 {
            position: absolute;
            top: 1780px;
             left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
          .auto-style25 {
            position: absolute;
            top: 1860px;
            left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
          .auto-style26 {
            position: absolute;
            top: 1920px;
           left: 40%;
            z-index: 1;
            width: 20%;
           height: 80px;
        }
          .auto-style27 {
            position: absolute;
            top: 2000px;
           left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
          .auto-style28 {
            position: absolute;
            top: 2080px;
           left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
          .auto-style29 {
            position: absolute;
            top: 2160px;
            left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
          .auto-style30 {
            position: absolute;
            top: 2240px;
            left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
          .auto-style31 {
            position: absolute;
            top: 2320px;
            left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
           .auto-style32 {
            position: absolute;
            top: 2400px;
            left: 40%;
            z-index: 1;
            width: 20%;
           height: 80px;
        }
           .auto-style33 {
            position: absolute;
            top: 2480px;
            left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
           .auto-style34 {
            position: absolute;
            top: 2560px;
            left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
           .auto-style35 {
            position: absolute;
            top: 2640px;
            left: 40%;
            z-index: 1;
            width: 20%;
           height: 80px;
        }
           .auto-style36 {
            position: absolute;
            top: 2720px;
            left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
           .auto-style37 {
            position: absolute;
            top: 2800px;
            left: 40%;
            z-index: 1;
            width: 20%;
           height: 80px;
        }
           .auto-style38 {
            position: absolute;
            top: 2880px;
            left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
           .auto-style39 {
            position: absolute;
            top: 2960px;
            left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
           .auto-style40 {
            position: absolute;
            top: 3040px;
            left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
           .auto-style41 {
            position: absolute;
            top: 3120px;
            left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
           .auto-style42 {
            position: absolute;
            top: 3200px;
            left: 40%;
            z-index: 1;
            width: 20%;
            height: 80px;
        }
        .auto-style43 {
            width: 1365px;
            left:700px;
        }

         .auto-style45 {

            position: absolute;
            top: 416px;
            left: 747px;
            z-index: 1;
            width: 172px;
            height: 262px;
        }
        .auto-style47 {
            position: absolute;
            top: 415px;
            z-index: 1;
            width: 171px;
            height: 262px;
            left: 1029px;
            margin-top: 7px;
        }
        .auto-style48 {
            position: absolute;
            top: 707px;
            left: 747px;
            z-index: 1;
        }

        .auto-style53 {
            position: absolute;
            top: 150px;
            left: 20px;
            z-index: 1;
            width: 74px;
            height: 20px;
        }
        
        .auto-style54 {
            position: absolute;
            top: 14%;
            left: 11%;
            z-index: 1;
            width: 74px;
            height: 20px;
        }
        
        .auto-style55 {
            position: absolute;
            top: 430px;
            left: 934px;
            z-index: 1;
        }
        .auto-style56 {
            position: absolute;
            top: 150px;
            left: 370px;
            z-index: 1;
            width: 74px;
            height: 20px;
        }
        
        .auto-style57 {
            position: absolute;
            top: 14%;
            left: 32%;
            z-index: 1;
            width: 34%;
            height: 20px;
        }
        
        .auto-style58 {
            
            position: absolute;
            top: 68%;
            left: 20%;
            z-index: 1;
            width: 500px;
            height: 27px;
        
        }
        
        .auto-style59 {
           position: absolute;
            top:500px;
            left: 750px;
            z-index: 1;
            width: 60px;
            height: 30px;
            }
        
        .auto-style60 {
            position: absolute;
            top: 500px;
            left: 820px;
            z-index: 1;
            width: 60px;
            height: 30px;
            right: 104px;
        }
        
        .auto-style61 {
            position: absolute;
            top: 35%;
            left: 45%;
            z-index: 1;
            width: 121px;
            height: 200px;
        }
        
        .auto-style62 {
            position: absolute;
            top: 30%;
            left: 90%;
            z-index: 1;
            width: 188px;
            height: 35px;
        }
        
        .auto-style63 {
             position: absolute;
            top: 500px;
            left: 890px;
            z-index: 1;
            width: 60px;
            height: 30px;
            right: 159px;
        }
        
        .auto-style64 {
             position: absolute;
            top: 500px;
            left: 960px;
            z-index: 1;
            width: 60px;
            height: 30px;
            right: 248px;
        }
        
         .auto-style65 {
            position: absolute;
            top: 1%;
            left: 10%;
            height: 4%;
            width: 5%;
            z-index: 4;
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
            top: 17px;
            left: -5px;
            width: 200%;
            height:380%;
            z-index: 0;
            
        }
        
        .auto-style68 {
            position: absolute;
            top: 20%;
            left: 0%;
            width: 8%;
            height:30%;
            z-index: 3;
           
        }
         .auto-style69 {
            position: absolute;
            top: 15%;
            left: 2%;
            
           
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
            width: 55%;
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
            width: 65%;
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
            width: 75%;
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
            width: 85%;
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
            width: 95%;
            height:7%;
            z-index: 3;
           
        }
             .auto-style81 {
            position: absolute;
            top: 30%;
            left: 60%;
            z-index: 1;
            width: 188px;
            height: 35px;
           
        }
             .auto-style82 {
            position: absolute;
            top: 35%;
            left: 60%;
            z-index: 1;
            width: 121px;
            height: 200px;
        }
              .auto-style83 {
            position: absolute;
            top: 20%;
            left: 0%;
            z-index: 1;
            width: 70%;
            height: 60%;
        }
               .auto-style84 {
            position: absolute;
            top: 0%;
            left: 0%;
            z-index: 4;
            width: 100%;
            height: 5%;
        }
             .auto-style85 {
            position: absolute;
            top: 0px;
            left: 20px;
            width: 3%;
            z-index: 5;
            height:5%;
        }

             .auto-style86 {
            position: absolute;
            top: 0px;
            left: 20%;
            width: 40%;
            z-index: 5;
            height:5%;
        }
        .auto-style87 {
            position: absolute;
            top: 1%;
            left: 70%;
            height: 4%;
            width: 20%;
            z-index: 4;
        }
        .auto-style88 {
            position: absolute;
            top: 20%;
            left: 71%;
            width: 30%;
            z-index: 6;
            height: 10%;
        }      
         .auto-style89 {
            position: absolute;
            top: 22%;
            left: 80%;
            width: 25%;
            z-index: 7;
            height:7%;
        }     
         .auto-style90 {
            position: absolute;
            top: 53%;
            left: 71%;
            width: 30%;
            z-index: 6;
            height:7%;
        }
         .auto-style91 {
            position: absolute;
            top: 53%;
            left: 75%;
            width: 25%;
            z-index: 7;
            height:10%;
        }
         .auto-style92 {
            position: absolute;
            top: 60%;
            left: 71%;
            width: 28%;
            z-index: 6;
            height:20%;
        }

         .auto-style93 {
            position: absolute;
            top: 68%;
            left: 75%;
            width: 10%;
            z-index: 7;
            height:10%;
        }
          .auto-style94 {
            position: absolute;
            top: 68%;
            left: 83%;
            width: 10%;
            z-index: 7;
            height:10%;
        }
          .auto-style95 {
            position: absolute;
            top: 6%;
            left: 60%;
            width: 5%;
            z-index: 7;
            height:8%;
        }
           .auto-style96 {
            position: absolute;
            top: 6%;
            left: 68%;
            width: 5%;
            z-index: 7;
            height:8%;
        }
           .auto-style97 {
            position: absolute;
            top: 6%;
            left: 76%;
            width: 5%;
            z-index: 7;
            height:8%;
        }

        </style>
</head>
<body  id="body1"  style="height: 1275px; margin-right: 0px;">
    <form id="form1" runat="server" class="auto-style43">
    <div id="div1" class="auto-style1">
 
         <asp:Image ID="Image_icon" CssClass="auto-style85" runat="server"  ImageUrl="~/Resource/图片2.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" />

         <asp:Panel ID="Panel2" CssClass="auto-style83" runat="server" ScrollBars="Vertical" BorderColor="Black" BackColor="#66CCFF" BorderStyle="Solid" BorderWidth="4px">
         <asp:Image ID="Image1" runat="server" CssClass="auto-style3" ImageUrl="~/Resource/zhu_tou.png" />
    
        <asp:Image ID="Image2" runat="server" CssClass="auto-style4" ImageUrl="~/Resource/zhu_shen.png" />
    
        <asp:Image ID="Image3" runat="server" CssClass="auto-style5" ImageUrl="~/Resource/zhu_shen.png" />
    
        <asp:Image ID="Image4" runat="server" CssClass="auto-style6" ImageUrl="~/Resource/zhu_shen.png" />
    
        <asp:Image ID="Image5" runat="server" CssClass="auto-style7" ImageUrl="~/Resource/zhu_shen.png" />
    
        <asp:Image ID="Image6" runat="server" CssClass="auto-style8" ImageUrl="~/Resource/zhu_shen.png" />
    
        <asp:Image ID="Image7" runat="server" CssClass="auto-style9" ImageUrl="~/Resource/zhu_shen.png" />
    
        <asp:Image ID="Image8" runat="server" CssClass="auto-style10" ImageUrl="~/Resource/zhu_shen.png" />
    
        <asp:Image ID="Image9" runat="server" CssClass="auto-style11" ImageUrl="~/Resource/zhu_shen.png" />
    
        <asp:Image ID="Image10" runat="server" CssClass="auto-style12" ImageUrl="~/Resource/zhu_shen.png" />
    
        <asp:Image ID="Image11" runat="server" CssClass="auto-style13" ImageUrl="~/Resource/zhu_shen.png" />

        
         <asp:Image ID="Image12" runat="server" CssClass="auto-style14" ImageUrl="~/Resource/zhu_shen.png" />
         <asp:Image ID="Image13" runat="server" CssClass="auto-style15" ImageUrl="~/Resource/zhu_shen.png" />
         <asp:Image ID="Image14" runat="server" CssClass="auto-style16" ImageUrl="~/Resource/zhu_shen.png" />
         <asp:Image ID="Image15" runat="server" CssClass="auto-style17" ImageUrl="~/Resource/zhu_shen.png" />
         <asp:Image ID="Image16" runat="server" CssClass="auto-style18" ImageUrl="~/Resource/zhu_shen.png" />
         <asp:Image ID="Image17" runat="server" CssClass="auto-style19" ImageUrl="~/Resource/zhu_shen.png" />
         <asp:Image ID="Image18" runat="server" CssClass="auto-style20" ImageUrl="~/Resource/zhu_shen.png" />
         <asp:Image ID="Image19" runat="server" CssClass="auto-style21" ImageUrl="~/Resource/zhu_shen.png" />
         <asp:Image ID="Image20" runat="server" CssClass="auto-style22" ImageUrl="~/Resource/zhu_shen.png" />
         <asp:Image ID="Image21" runat="server" CssClass="auto-style23" ImageUrl="~/Resource/zhu_shen.png" />
         <asp:Image ID="Image22" runat="server" CssClass="auto-style24" ImageUrl="~/Resource/zhu_shen.png" />
         <asp:Image ID="Image23" runat="server" CssClass="auto-style25" ImageUrl="~/Resource/zhu_shen.png" />
         <asp:Image ID="Image24" runat="server" CssClass="auto-style26" ImageUrl="~/Resource/zhu_shen.png" />
         <asp:Image ID="Image25" runat="server" CssClass="auto-style27" ImageUrl="~/Resource/zhu_shen.png" />
         <asp:Image ID="Image26" runat="server" CssClass="auto-style28" ImageUrl="~/Resource/zhu_shen.png" />
         <asp:Image ID="Image27" runat="server" CssClass="auto-style29" ImageUrl="~/Resource/zhu_shen.png" />
         <asp:Image ID="Image28" runat="server" CssClass="auto-style30" ImageUrl="~/Resource/zhu_shen.png" />
         <asp:Image ID="Image29" runat="server" CssClass="auto-style31" ImageUrl="~/Resource/zhu_shen.png" />
         <asp:Image ID="Image30" runat="server" CssClass="auto-style32" ImageUrl="~/Resource/zhu_shen.png" />
        <asp:Image ID="Image31" runat="server" CssClass="auto-style33" ImageUrl="~/Resource/zhu_shen.png" />
        <asp:Image ID="Image32" runat="server" CssClass="auto-style34" ImageUrl="~/Resource/zhu_shen.png" />
        <asp:Image ID="Image33" runat="server" CssClass="auto-style35" ImageUrl="~/Resource/zhu_shen.png" />
        <asp:Image ID="Image34" runat="server" CssClass="auto-style36" ImageUrl="~/Resource/zhu_shen.png" />
        <asp:Image ID="Image35" runat="server" CssClass="auto-style37" ImageUrl="~/Resource/zhu_shen.png" />
        <asp:Image ID="Image36" runat="server" CssClass="auto-style38" ImageUrl="~/Resource/zhu_shen.png" />
        <asp:Image ID="Image37" runat="server" CssClass="auto-style39" ImageUrl="~/Resource/zhu_shen.png" />
        <asp:Image ID="Image38" runat="server" CssClass="auto-style40" ImageUrl="~/Resource/zhu_shen.png" />
        <asp:Image ID="Image39" runat="server" CssClass="auto-style41" ImageUrl="~/Resource/zhu_shen.png" />
        <asp:Image ID="Image40" runat="server" CssClass="auto-style42" ImageUrl="~/Resource/zhu_di.png" />
         </asp:Panel>
        <asp:Label ID="Label_weizhi" CssClass="auto-style93" runat="server" Text="位置" Font-Names="微软雅黑"></asp:Label>
        <asp:Label ID="Label_weiyiliang" CssClass="auto-style94" runat="server" Text="位移量" Font-Names="微软雅黑"></asp:Label>
       
         <asp:Image ID="Image41" runat="server" CssClass="auto-style84" BackColor="#0000CC" ImageUrl="~/Resource/图片1.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3" />
         <asp:Image ID="Image43" CssClass="auto-style90"  runat="server" ImageUrl="~/Resource/图片4.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px"/>
        <asp:label  ID="label_baojing" runat="server" text="报警显示" CssClass="auto-style91" Font-Size="XX-Large" ForeColor="White"></asp:label>
        <asp:Image ID="Image44" CssClass="auto-style92" runat="server" ImageUrl="~/Resource/dise.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" />
        <asp:ImageButton ID="ImageButton_chafen" runat="server" BackColor="#3366FF" CssClass="auto-style97" ImageUrl="~/Resource/find_magnifier_magnifying_glass_search_zoom_64px_1225492_easyicon.net.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" OnClick="ImageButton_chafen_Click" />
         <asp:ImageButton ID="ImageButton_home" runat="server" BackColor="#3366FF" CssClass="auto-style95" ImageUrl="~/Resource/home.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" OnClick="ImageButton_home_Click" />

         <div style="position: absolute; z-index: 5; top: 30%; width: 30%; height: 20%; left: 71%;">
             <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" OnDayRender="Calendar1_DayRender1" Width="350px" OnSelectionChanged="Calendar1_SelectionChanged" >
                 <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                 <DayStyle BorderColor="#660066" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                 <NextPrevStyle BorderColor="White" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                 <OtherMonthDayStyle ForeColor="#999999" />
                 <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                 <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Names="微软雅黑" Font-Size="12pt" ForeColor="#333399" />
                 <TodayDayStyle BackColor="#CCCCCC" />
             </asp:Calendar>
         </div>
 
         <asp:Image ID="Image_bg" CssClass="auto-style67" runat="server" BackColor="#0099CC"   />
    
        <asp:Label ID="Label_title" runat="server" CssClass="auto-style2" Font-Names="黑体" Font-Size="20pt" Text="柱状图"></asp:Label>
    
        <asp:ImageButton ID="ImageButton_set" CssClass="auto-style96" runat="server" ImageUrl="~/Resource/settings_64px_1229386_easyicon.net.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" BackColor="#3366FF" OnClick="ImageButton_set_Click"/>

    

        <asp:Chart ID="Chart1" runat="server" CssClass="auto-style44" Visible="False" BackColor="Transparent">

            <series>
                <asp:Series ChartType="Spline" Name="曲线1" Color="Red">
                </asp:Series>
            <asp:Series ChartArea="ChartArea1" ChartType="Spline" Color="Blue" Name="曲线2"></asp:Series></series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
    
       
    
        
    
       
    

        <asp:ListBox ID="ListBox1" runat="server" CssClass="auto-style45" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" OnTextChanged="ListBox1_TextChanged" Visible="False"></asp:ListBox>
        <asp:ListBox ID="ListBox2" runat="server" CssClass="auto-style47" OnSelectedIndexChanged="ListBox2_SelectedIndexChanged" Visible="False"></asp:ListBox>
        <asp:Button ID="Button1" runat="server" CssClass="auto-style48" OnClick="Button1_Click" Text="确认" Visible="False" />
    
  
        <asp:LinkButton ID="link" CssClass="auto-style65" ForeColor="White" Text="主页面" runat="server" OnClick="link0_Click" Visible="false"></asp:LinkButton>
       
    
       
    
        <asp:Chart ID="Chart2" runat="server" CssClass="auto-style44" BorderlineColor="Black" BorderlineDashStyle="Solid" BackColor="DarkGray" Width="961px" BorderlineWidth="3">
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

        <asp:Label ID="Label6" runat="server" CssClass="auto-style55" Text="曲线2选择" Visible="False"></asp:Label>
        <asp:Label ID="Label4" runat="server" CssClass="auto-style51" Text="曲线1选择" Visible="False"></asp:Label>
        
        
        
        <asp:Label ID="Label7" runat="server" CssClass="auto-style53" Text="测量位置" Visible="false"></asp:Label>
        
        <asp:Label ID="Label8" runat="server" CssClass="auto-style54" style="z-index: 1" Text="线缆状态" ForeColor="White" Visible="false"></asp:Label>
        
        <asp:Label ID="Label9" runat="server" CssClass="auto-style56" style="z-index: 1" Text="测量位置" Visible="false"></asp:Label>
        
        <asp:Label ID="Label10" runat="server" CssClass="auto-style57" style="z-index: 1" Text="线缆状态" ForeColor="White" Visible="false"></asp:Label>
        
        <asp:Label ID="Label11" runat="server" CssClass="auto-style58" Text="趋势曲线" ForeColor="White" Visible="false"></asp:Label>
        
        <asp:Button ID="Button2" runat="server" CssClass="auto-style59" Text="放大" BorderStyle="Solid" BorderWidth="2px" OnClick="Button2_Click" Visible="False" />
        
        <asp:Button ID="Button3" runat="server" BorderStyle="Solid" CssClass="auto-style60" Text="缩小" OnClick="Button3_Click" Visible="False" />
        
        <asp:ListBox ID="ListBox3" runat="server" CssClass="auto-style61" AutoPostBack="True" OnSelectedIndexChanged="ListBox3_SelectedIndexChanged" BackColor="#9999FF" Visible="false"></asp:ListBox>
        
        <asp:Label ID="Label12" runat="server" CssClass="auto-style62" Text="选择日期" Font-Names="微软雅黑" Font-Size="20pt" Visible="False" ></asp:Label>
        
        <asp:Button ID="Button4" runat="server" BorderStyle="Solid" CssClass="auto-style63" Text="前进" OnClick="Button4_Click" Visible="False" />
        
        <asp:Button ID="Button5" runat="server" CssClass="auto-style64" style="z-index: 1" Text="后退" BorderStyle="Solid" OnClick="Button5_Click" Visible="False" />
        
        <asp:ListBox ID="ListBox4" runat="server" CssClass="auto-style82" AutoPostBack="True" OnSelectedIndexChanged="ListBox4_SelectedIndexChanged" BackColor="#9999FF" Visible="false"></asp:ListBox>
    
       <asp:Label ID="Label2" runat="server" CssClass="auto-style81" Text="选择时间" ForeColor="White" Visible="false"></asp:Label>
    
       <asp:Image ID="Image42" CssClass="auto-style88" runat="server" ImageUrl="~/Resource/图片4.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px"/>

    <asp:label  ID="label_rili" runat="server" text="日历选择" CssClass="auto-style89" Font-Size="XX-Large" ForeColor="White"></asp:label>
        <asp:LinkButton ID="link0" CssClass="auto-style66" Text="差分查询" runat="server" OnClick="link_Click" ForeColor="White" Visible="false"></asp:LinkButton>
       
         <asp:Panel ID="Panel1" CssClass="auto-style68" runat="server" BackColor="#CCFFFF" BorderColor="Black" BorderStyle="Solid">
             <asp:Label ID="Label14"  CssClass="auto-style70"  runat="server" Text="线缆颜色对应位移量" ForeColor="Black" Font-Size="Smaller"></asp:Label>
             <asp:Label ID="Label1" CssClass="auto-style71"  runat="server" Text="<0.01mm" ForeColor="White" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label15" CssClass="auto-style72" runat="server" Text="Label" ForeColor="DarkBlue" BackColor="DarkBlue" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label16" CssClass="auto-style73" runat="server" Text="<=0.5mm" ForeColor="White" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label17" CssClass="auto-style74" runat="server" Text="Label" ForeColor="Blue" BackColor="Blue" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label18" CssClass="auto-style75" runat="server" Text="<=1.0mm" ForeColor="White" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label19" CssClass="auto-style76" runat="server" Text="Label" ForeColor="LightGreen" BackColor="LightGreen" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label20" CssClass="auto-style77" runat="server" Text="<2.0mm"  ForeColor="White" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label21" CssClass="auto-style78" runat="server" Text="Label" ForeColor="Yellow" BackColor="Yellow" Font-Size="Small"></asp:Label>
             <asp:Label ID="Label22" CssClass="auto-style79" runat="server" Text=">=2.0mm" Font-Size="Small" ForeColor="White"></asp:Label>
             <asp:Label ID="Label23" CssClass="auto-style80" runat="server" Text="Label" ForeColor="Red" BackColor="Red" Font-Size="Small"></asp:Label>
         </asp:Panel>
    
       
     <asp:Label ID="Label13" CssClass="auto-style69" runat="server" Text="预警等级" ForeColor="White" BackColor="Blue" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px"></asp:Label>
       
     <asp:Image ID="Image_title" CssClass="auto-style86"  runat="server" ImageUrl="~/Resource/图片3.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" />

       <!-- 关于时间的更新-->
        <asp:ScriptManager ID="ScriptManager1" runat="Server" ></asp:ScriptManager><!--必须包含这个控件，否则UpdatePanel无法使用-->  
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">  
                <ContentTemplate>当前时间是：  
            <!--Lable和Timer控件必须都包含在UpdatePanel控件中 -->  
                    <asp:Label ID="Label_timer" CssClass="auto-style87" runat="server" Text="Label" Font-Names="微软雅黑" ForeColor="White" Font-Size="Large"></asp:Label>  <!--用于显示时间-->  
                    <asp:Timer ID="Timer1" runat="server" Interval="1000"></asp:Timer><!-- 用于更新时间，每1秒更新一次-->  
                </ContentTemplate>                  
            </asp:UpdatePanel>     
        <!-- 鼠标点到点上 -->
    
    </div>
    </form>
</body>
</html>
