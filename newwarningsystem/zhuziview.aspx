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
            top: 51px;
            left: 100px;
            z-index: 1;
            width: 320px;
            height: 25px;
        }
        .auto-style3 {
            position: absolute;
            top: 100px;
            left: 200px;
            z-index: 1;
            width: 150px;
            height: 80px;
        }
        .auto-style4 {
            position: absolute;
            top: 180px;
            left:  200px;
            z-index: 1;
            width: 150px;
            height: 80px;
        }
        .auto-style5 {
            position: absolute;
            top: 260px;
            left:  200px;
            z-index: 1;
            width: 150px;
            height: 80px;
        }
        .auto-style6 {
            position: absolute;
            top: 340px;
            left:  200px;
            z-index: 1;
            width: 150px;
            height: 80px;
        }
        .auto-style7 {
            position: absolute;
            top: 420px;
            left:  200px;
            z-index: 1;
            width: 150px;
            height: 80px;
        }
        .auto-style8 {
            position: absolute;
            top: 500px;
            left:  200px;
            z-index: 1;
            width: 150px;
            height: 80px;
        }
        .auto-style9 {
            position: absolute;
            top: 580px;
            left:  200px;
            z-index: 1;
            width: 150px;
            height: 80px;
        }
        .auto-style10 {
            position: absolute;
            top: 660px;
            left:  200px;
            z-index: 1;
            width: 150px;
            height: 80px;
        }
        .auto-style11 {
            position: absolute;
            top: 740px;
            left:  200px;
            z-index: 1;
            width: 150px;
            height: 80px;
        }
        .auto-style12 {
            position: absolute;
            top: 820px;
            left:  200px;
            z-index: 1;
            width: 150px;
            height: 80px;
        }
        .auto-style13 {
            position: absolute;
            top: 900px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
         .auto-style14 {
            position: absolute;
            top: 980px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
          .auto-style15 {
            position: absolute;
            top: 1060px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
           .auto-style16 {
            position: absolute;
            top: 1140px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
            .auto-style17 {
            position: absolute;
            top: 1220px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
             .auto-style18 {
            position: absolute;
            top: 1300px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
              .auto-style19 {
            position: absolute;
            top: 1380px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
               .auto-style20 {
            position: absolute;
            top: 1460px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
                .auto-style21 {
            position: absolute;
            top: 1540px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
                 .auto-style22 {
            position: absolute;
            top: 1620px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
                  .auto-style23 {
            position: absolute;
            top: 1700px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
         .auto-style24 {
            position: absolute;
            top: 1780px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
          .auto-style25 {
            position: absolute;
            top: 1860px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
          .auto-style26 {
            position: absolute;
            top: 1920px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
          .auto-style27 {
            position: absolute;
            top: 2000px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
          .auto-style28 {
            position: absolute;
            top: 2080px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
          .auto-style29 {
            position: absolute;
            top: 2160px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
          .auto-style30 {
            position: absolute;
            top: 2240px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
          .auto-style31 {
            position: absolute;
            top: 2320px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
           .auto-style32 {
            position: absolute;
            top: 2400px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
           .auto-style33 {
            position: absolute;
            top: 2480px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
           .auto-style34 {
            position: absolute;
            top: 2560px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
           .auto-style35 {
            position: absolute;
            top: 2640px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
           .auto-style36 {
            position: absolute;
            top: 2720px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
           .auto-style37 {
            position: absolute;
            top: 2800px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
           .auto-style38 {
            position: absolute;
            top: 2880px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
           .auto-style39 {
            position: absolute;
            top: 2960px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
           .auto-style40 {
            position: absolute;
            top: 3040px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
           .auto-style41 {
            position: absolute;
            top: 3120px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
        }
           .auto-style42 {
            position: absolute;
            top: 3200px;
            left:  200px;
            z-index: 1;
            height: 80px;
            width: 150px;
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
        .auto-style46 {
            position: absolute;
            top: 430px;
            left: 933px;
            z-index: 1;
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
            top: 150px;
            left: 120px;
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
            top: 150px;
            left: 360px;
            z-index: 1;
            width: 74px;
            height: 20px;
        }
        
        .auto-style58 {
            
            position: absolute;
            top: 155px;
            left: 750px;
            z-index: 1;
            width: 172px;
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
            top: 200px;
            left: 524px;
            z-index: 1;
            width: 121px;
            height: 357px;
        }
        
        .auto-style62 {
            position: absolute;
            top: 158px;
            left: 599px;
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
            top: 35px;
            left: 879px;
            height: 26px;
            width: 72px;
            z-index: 2;
        }
        .auto-style66 {
            position: absolute;
            top: 34px;
            left: 948px;
            width: 72px;
            z-index: 2;
            right: 89px;
        }
        .auto-style67 {
            position: absolute;
            top: 0px;
            left: 0px;
            width: 100%;
            height:380%;
            z-index: 0;
            right: 0px;
        }
        

        </style>
</head>
<body  id="body1" style="height: 1275px; margin-right: 0px;">
    <form id="form1" runat="server" class="auto-style43">
    <div id="div1" class="auto-style1">
         <asp:Image ID="Image_bg" CssClass="auto-style67" runat="server" ImageUrl="~/Resource/u=1497079183,493793446&amp;fm=26&amp;gp=0.jpg"   />
    
        <asp:Label ID="Label_title" runat="server" CssClass="auto-style2" Font-Names="黑体" Font-Size="20pt" Text="柱状图"></asp:Label>
    
       
    

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
    
       
    

        <asp:ListBox ID="ListBox1" runat="server" CssClass="auto-style45" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" OnTextChanged="ListBox1_TextChanged" Visible="False"></asp:ListBox>
        <asp:Label ID="Label3" runat="server" CssClass="auto-style46" Text="曲线2选择" Visible="False"></asp:Label>
        <asp:ListBox ID="ListBox2" runat="server" CssClass="auto-style47" OnSelectedIndexChanged="ListBox2_SelectedIndexChanged" Visible="False"></asp:ListBox>
        <asp:Button ID="Button1" runat="server" CssClass="auto-style48" OnClick="Button1_Click" Text="确认" Visible="False" />
    
       
    
       
    
       
    
        <asp:LinkButton ID="link" CssClass="auto-style65" Text="主页面" runat="server" OnClick="link0_Click"></asp:LinkButton>
       
    
       
    
        <asp:Chart ID="Chart2" runat="server" CssClass="auto-style44" BorderlineColor="Black" BorderlineDashStyle="Solid" BackColor="DarkGray" Width="444px">
            <series>
                <asp:Series ChartType="Spline" Name="曲线1" Color="Red" XValueType="DateTime">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
            <BorderSkin BackColor="Transparent" BackSecondaryColor="White" BorderDashStyle="Dash" BorderWidth="5" />
        </asp:Chart>

        <asp:Label ID="Label6" runat="server" CssClass="auto-style55" Text="曲线2选择" Visible="False"></asp:Label>
        <asp:Label ID="Label4" runat="server" CssClass="auto-style51" Text="曲线1选择" Visible="False"></asp:Label>
        
        
        
        <asp:Label ID="Label7" runat="server" CssClass="auto-style53" Text="测量位置" Visible="false"></asp:Label>
        
        <asp:Label ID="Label8" runat="server" CssClass="auto-style54" style="z-index: 1" Text="线缆状态" ForeColor="White"></asp:Label>
        
        <asp:Label ID="Label9" runat="server" CssClass="auto-style56" style="z-index: 1" Text="测量位置" Visible="false"></asp:Label>
        
        <asp:Label ID="Label10" runat="server" CssClass="auto-style57" style="z-index: 1" Text="线缆状态" ForeColor="White"></asp:Label>
        
        <asp:Label ID="Label11" runat="server" CssClass="auto-style58" Text="趋势曲线"></asp:Label>
        
        <asp:Button ID="Button2" runat="server" CssClass="auto-style59" Text="放大" BorderStyle="Solid" BorderWidth="2px" OnClick="Button2_Click" Visible="False" />
        
        <asp:Button ID="Button3" runat="server" BorderStyle="Solid" CssClass="auto-style60" Text="缩小" OnClick="Button3_Click" Visible="False" />
        
        <asp:ListBox ID="ListBox3" runat="server" CssClass="auto-style61" AutoPostBack="True" OnSelectedIndexChanged="ListBox3_SelectedIndexChanged" BackColor="#9999FF"></asp:ListBox>
        
        <asp:Label ID="Label12" runat="server" CssClass="auto-style62" style="z-index: 1" Text="日期选择"></asp:Label>
        
        <asp:Button ID="Button4" runat="server" BorderStyle="Solid" CssClass="auto-style63" Text="前进" OnClick="Button4_Click" Visible="False" />
        
        <asp:Button ID="Button5" runat="server" CssClass="auto-style64" style="z-index: 1" Text="后退" BorderStyle="Solid" OnClick="Button5_Click" Visible="False" />
        
       
    
       
    
       
    
        <asp:LinkButton ID="link0" CssClass="auto-style66" Text="差分查询" runat="server" OnClick="link_Click"></asp:LinkButton>
       

    
       
    
       
    
       
    
    </div>
    </form>
</body>
</html>
