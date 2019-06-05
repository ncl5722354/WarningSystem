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
            top: 30%;
            left: 28%;
            z-index: 6;
            width: 2%;
            height: 4%;
            
        }
        

        
        .auto-style6 {
            position: absolute;
            top: 26%;
            left: 43%;
            z-index:6;
            width:2%;
            height:4%;
        }
        .auto-style7 {
            position: absolute;
            top: 32%;
            left: 43%;
            z-index:6;
            width:2%;
            height:4%;
        }
        .auto-style8 {
            position: absolute;
            top: 46%;
            left: 25%;
            z-index: 6;
            height: 4%;
            right: 74%;
            width:2%;
        }
        .auto-style9 {
            position: absolute;
            top: 48%;
            left: 34%;
            z-index:6;
            width:2%;
            height:4%;
            right: 920px;
        }
        .auto-style10 {
            position: absolute;
            top: 48%;
            left: 41%;
            z-index: 6;
            width:2%;
            height: 4%;
            right: 822px;
        }
        .auto-style11 {
            position: absolute;
            top: 48%;
            left: 47%;
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
            top: 28%;
            left: 25%;
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
            top: 26%;
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
            top: 32%;
            left: 40.5%;
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
            top: 45%;
            left: 24.5%;
            z-index: 5;
            width: 3%;
            height: 5%;
             opacity:0.5;
             border-radius:100%;
            
        }
         .auto-style20 {
            position: absolute;
            top: 47%;
            left: 33.5%;
            z-index: 5;
            width: 3%;
            height: 5%;
            opacity:0.5;
             border-radius:100%;
             
        }
         .auto-style21 {
            position: absolute;
            top: 47%;
            left: 40.5%;
            z-index: 5;
            width: 3%;
            height: 5%;
            opacity:0.5;
             border-radius:100%;
             
        }
         .auto-style22 {
            position: absolute;
            top: 47%;
            left: 46%;
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
            width: 20%;
            height:81%;
            z-index: 4;
            opacity:0.75;
           

           
        }
           .auto-style83 {
            position: absolute;
            top: 10%;
            left: 0%;
            width: 100%;
            height:85%;
            z-index: 6;    
        }
           .auto-style84 {
            position: absolute;
            top: 80%;
            left: 0%;
            width: 100%;
            height:20%;
            z-index: 6; 
            opacity: 0.75;   
        }
           .auto-style85 {
            position: absolute;
            width:100%;
            height:100%;
            left:0px;
            top:0px;
            
        }
            .auto-style86 {
            position: absolute;
            top: 0px;
            left: 20px;
            width: 3%;
            z-index: 4;
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
                <ContentTemplate>当前时间是：  
            <!--Lable和Timer控件必须都包含在UpdatePanel控件中 -->  
                        <asp:Label ID="Label_timer" CssClass="auto-style14" runat="server" Text="Label" Font-Names="微软雅黑" ForeColor="White"></asp:Label>  <!--用于显示时间-->  
                        <asp:Timer ID="Timer1" runat="server" Interval="1000"></asp:Timer><!-- 用于更新时间，每1秒更新一次-->  
                        
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
                    <asp:Image ID="Circle1" BackColor="Orange" runat="server" CssClass="auto-style16" ToolTip="一号坡 2164-2317" />
                    <asp:Image ID="Circle2" BackColor="Orange" runat="server" CssClass="auto-style17" ToolTip="二号坡 2361-2558" />
                    <asp:Image ID="Circle3" BackColor="Orange" runat="server" CssClass="auto-style18" ToolTip="三号坡 2934-3074" />
                    <asp:Image ID="Circle4" BackColor="Orange" runat="server" CssClass="auto-style19" ToolTip="侧斜管标定1号管 602-675" />
                    <asp:Image ID="Circle5" BackColor="Orange" runat="server" CssClass="auto-style20" ToolTip="侧斜管标定2号管 742-810" />
                    <asp:Image ID="Circle6" BackColor="Orange" runat="server" CssClass="auto-style21" ToolTip="侧斜管标定3号管 875-939" />
                    <asp:Image ID="Circle7" BackColor="Orange" runat="server" CssClass="auto-style22" ToolTip="侧斜管标定4号管 994-1069" />
                    <asp:Timer ID="timer" Interval="10000" runat="server"/>
                </ContentTemplate>
          </asp:UpdatePanel>

         <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" OnDataBinding="UpdatePanel4_DataBinding">  
                <ContentTemplate>
                     <asp:Panel ID="Panel2" CssClass="auto-style82" BackColor="Blue" runat="server" >
                         
                     </asp:Panel>

                    <asp:Panel ID="Panel3" CssClass="auto-style84" runat="server" BackColor="#3333FF">
            <asp:Chart ID="Chart1" runat="server" Width="1200px" Height="200px">
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
                    <asp:Timer ID="timer2" Interval="4000" runat="server" OnTick="timer2_Tick1"/>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="timer3" EventName="Tick" />
                </Triggers>
         </asp:UpdatePanel>
        <asp:Timer ID="timer3" Interval="20000" runat="server" OnTick="timer3_Tick"/>
         <asp:Panel ID="Panel1" CssClass="auto-style68" runat="server" BackColor="Silver" BorderColor="Black" BorderStyle="Solid">
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
        
        <asp:Image ID="Imagebg" runat="server" CssClass="auto-style3" ImageUrl="~/Resource/u=1497079183,493793446&amp;fm=26&amp;gp=0.jpg" BackColor="#333300" />
         <asp:Image ID="Image_icon" CssClass="auto-style86" runat="server"  ImageUrl="~/Resource/图片2.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" />
        <asp:Label ID="Label24" runat="server" Text="报警等级" CssClass="auto-style81" BackColor="#000099" ForeColor="White"></asp:Label>
        
        
        
       
        
        
        
        <asp:Image ID="Imagemap" runat="server" CssClass="auto-style2" ImageUrl="~/Resource/pic.png" OnDataBinding="Imagemap_DataBinding" BorderStyle="Solid" />
        <asp:Label ID="Label_title" runat="server" CssClass="auto-style4" Text="坝光收费站边坡防护预警系统" Font-Names="黑体" Font-Size="15pt" ForeColor="White"></asp:Label>
         
    </div>
    </form>
</body>
</html>


