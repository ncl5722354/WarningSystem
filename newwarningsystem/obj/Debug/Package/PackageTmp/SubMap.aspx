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
            width: 60%;
            z-index: 0;
        }
         
         .auto-style44 {
            position: absolute;
            top: 12%;
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

             </style>
</head>

<body style="height: 150%; width: 100%">
    <form id="form1" runat="server">
    <div>
    
        <asp:label  ID="label_warnlevel" runat="server" text="报警等级" CssClass="auto-style86" Font-Size="XX-Large" ForeColor="White"></asp:label>
        <asp:label  ID="label_rili" runat="server" text="日历选择" CssClass="auto-style88" Font-Size="XX-Large" ForeColor="White"></asp:label>
        <asp:label  ID="label_baojing" runat="server" text="报警显示" CssClass="auto-style90" Font-Size="XX-Large" ForeColor="White"></asp:label>
        <asp:Image ID="Image2"  CssClass="auto-style43" runat="server"   ImageUrl="~/Resource/u=1497079183,493793446&amp;fm=26&amp;gp=0.jpg"/>
        <asp:Label ID="Label_title" CssClass="auto-style44" runat="server" Font-Names="微软雅黑" Font-Size="20pt" ForeColor="White" Text="Label" BackColor="#FF3300" BorderStyle="Solid" BorderColor="Black" BorderWidth="3px"></asp:Label>
        <asp:Image ID="Image_icon" CssClass="auto-style83" runat="server"  ImageUrl="~/Resource/图片2.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" />
        <asp:ImageButton ID="ImageButton_set" CssClass="auto-style95" runat="server" ImageUrl="~/Resource/settings_64px_1229386_easyicon.net.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" BackColor="#3366FF" OnClick="ImageButton_set_Click"/>
        <asp:Image ID="Image_head" runat="server" CssClass="auto-style67" BackColor="#000066" ImageUrl="~/Resource/图片1.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px"/>
        <asp:Image ID="Image_title" CssClass="auto-style84"  runat="server" ImageUrl="~/Resource/图片3.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" />
        <asp:Image ID="Image3" CssClass="auto-style91" runat="server" ImageUrl="~/Resource/dise.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" />
        <asp:Image ID="Image4" CssClass="auto-style85" runat="server" ImageUrl="~/Resource/图片4.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px"/>
        <asp:Image ID="Image5" CssClass="auto-style87"  runat="server" ImageUrl="~/Resource/图片4.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px"/>
        <asp:Image ID="Image6" CssClass="auto-style89"  runat="server" ImageUrl="~/Resource/图片4.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px"/>
        <asp:Image ID="Image7" runat="server" />
        <asp:Label ID="Label_weizhi" CssClass="auto-style92" runat="server" Text="位置" Font-Names="微软雅黑"></asp:Label>
        <asp:Label ID="Label_weiyiliang" CssClass="auto-style93" runat="server" Text="位移量" Font-Names="微软雅黑"></asp:Label>
       
        <asp:ImageButton ID="ImageButton_home" runat="server" BackColor="#3366FF" CssClass="auto-style94" ImageUrl="~/Resource/home.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" OnClick="ImageButton_home_Click" />
        <asp:ImageButton ID="ImageButton_chafen" runat="server" BackColor="#3366FF" CssClass="auto-style96" ImageUrl="~/Resource/find_magnifier_magnifying_glass_search_zoom_64px_1225492_easyicon.net.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" OnClick="ImageButton_chafen_Click" />

        <asp:Image ID="Image1"  CssClass="auto-style42" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" />
        <asp:Label ID="Label12" runat="server" CssClass="auto-style62" Text="选择日期" ForeColor="White" Visible="false"></asp:Label>
        <asp:LinkButton ID="link" CssClass="auto-style65" Text="主页面" runat="server" OnClick="link0_Click" ForeColor="White" Visible="false"></asp:LinkButton>
       <asp:Label ID="Label2" runat="server" CssClass="auto-style81" Text="选择时间" ForeColor="White" Visible="false"></asp:Label>
       <asp:Label ID="Label11" runat="server" CssClass="auto-style58" Text="趋势曲线" ForeColor="White" Visible="false"></asp:Label>
       <asp:LinkButton ID="link0" CssClass="auto-style66" Text="差分查询" runat="server" OnClick="link_Click" ForeColor="White" Visible="false"></asp:LinkButton>
       <asp:Panel ID="Panel1" CssClass="auto-style68" runat="server" BackColor="#CCFFFF" BorderColor="Black" BorderStyle="Solid">
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
                <ContentTemplate>当前时间是：  
            <!--Lable和Timer控件必须都包含在UpdatePanel控件中 -->  
                    <asp:Label ID="Label_timer" CssClass="auto-style14" runat="server" Text="Label" Font-Names="微软雅黑" ForeColor="White" Font-Size="Large"></asp:Label>  <!--用于显示时间-->  
                    <asp:Timer ID="Timer1" runat="server" Interval="1000"></asp:Timer><!-- 用于更新时间，每1秒更新一次-->  
                </ContentTemplate>                  
            </asp:UpdatePanel>     
        <!-- 鼠标点到点上 -->


         <div style="position: absolute; z-index: 5; top: 25%; width: 25%; height: 20%; left: 75%;">
             <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" OnDayRender="Calendar1_DayRender1" Width="100%" OnSelectionChanged="Calendar1_SelectionChanged" >
                 <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                 <DayStyle BorderColor="#660066" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                 <NextPrevStyle BorderColor="White" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                 <OtherMonthDayStyle ForeColor="#999999" />
                 <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                 <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Names="微软雅黑" Font-Size="12pt" ForeColor="#333399" />
                 <TodayDayStyle BackColor="#CCCCCC" />
             </asp:Calendar>
       </div>
    <asp:ListBox ID="ListBox3" runat="server" CssClass="auto-style61" AutoPostBack="True" OnSelectedIndexChanged="ListBox3_SelectedIndexChanged" BackColor="#9999FF" Visible="false"></asp:ListBox>
    <asp:ListBox ID="ListBox4" runat="server" CssClass="auto-style82" AutoPostBack="True" OnSelectedIndexChanged="ListBox4_SelectedIndexChanged" BackColor="#9999FF" Visible="false"></asp:ListBox>
        
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
       
        <asp:Label ID="Label13" CssClass="auto-style69" runat="server" Text="图例" ForeColor="White" Visible="false"></asp:Label>
       
        </div>
    </form>
</body>
</html>
