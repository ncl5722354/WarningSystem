<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="report.aspx.cs" Inherits="newwarningsystem.report" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style86 {
            position: absolute;
            top: 1px;
            left: 20px;
            width: 3%;
            z-index: 10;
            height:5%;
        }
        .auto-style12 {
            position: absolute;
            top: 0%;
            left: 0%;
            z-index: 9;
            width: 100%;
            height: 5%;
        }
        .auto-style4 {
            position: absolute;
            top: 1%;
            left: 40%;
            z-index: 9;
            width: 100%;
            height: 4%;
            margin-right: 0px;
        }
        .Image_home
        {
            position:absolute;
            top:0%;
            left:90%;
            width:3%;
            height:4%;
            z-index:9;
        }
        .report
        {
            position:absolute;
            top:20%;
            left:0%;
            width:60%;
            height:75%;
            z-index:9;
        }
         .auto-style1 {
            height: 628px;
        }
         .reportview
         {
              position:absolute;
            top:20%;
            left:0%;
            width:80%;
            height:75%;
            z-index:10;
         }
         .Panel_port
         {
             position:absolute;
            top:20%;
            left:10%;
            width:60%;
            height:75%;
            z-index:10;
         }
         .Panel_rili
         {
             position:absolute;
            top:20%;
            left:75%;
            width:24%;
            height:75%;
            z-index:10;
         }
         .Label_Title
         {
              position:absolute;
            top:10%;
            left:10%;
            width:60%;
            height:8%;
            z-index:10;
            text-align:center;
         }
         .Label_rili
         {
             position:absolute;
            top:10%;
            left:75%;
            width:24%;
            height:8%;
            z-index:10;
            text-align:center;
         }
    </style>
</head>
<body>
    <form id="form1" runat="server"  style="width:100%; height:100%">
    <div class="auto-style1">
        <asp:Image ID="Image_icon" CssClass="auto-style86" runat="server"  ImageUrl="~/Resource/图片2.png" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" />
        <asp:Image ID="Image_title" CssClass="auto-style12" runat="server" BackColor="#0000CC" ImageUrl="~/Resource/图片1.png"  />
        <asp:Label ID="Label_title" runat="server" CssClass="auto-style4" Text="坝光收费站边坡防护预警系统" Font-Names="黑体" Font-Size="15pt" ForeColor="White"></asp:Label>
        
         <asp:ImageButton ID="Image_home" CssClass="Image_home" runat="server" ImageUrl="~/Resource/home.png" OnClick="ImageButton_home_Click"  />
        
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
        <asp:Panel ID="Panel_port" CssClass="Panel_port" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" ScrollBars="Vertical">
        </asp:Panel>
        <asp:Label ID="Label_Title1" CssClass="Label_Title" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" Text="详情报表"></asp:Label>
        <asp:Label ID="Label_rili" CssClass="Label_rili" runat="server"  BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" Text="日期选择"></asp:Label>
        <asp:Panel ID="Panel_rili" CssClass="Panel_rili" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" ScrollBars="Vertical">
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>

        </asp:Panel>
        
    </div>
        
    </form>
</body>
</html>
