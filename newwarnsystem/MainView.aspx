<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainView.aspx.cs" Inherits="newwarnsystem.MainView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            position:absolute;
            left:101px;
            top:47px;
            /*width:1000px;*/
            height: 520px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 800px;width:1000px;left:0px;top:0px; margin-left: 160px;">
    
        <asp:Label ID="Label1" runat="server" Text="坝体预警系统" Font-Size="Larger"></asp:Label>
    
        <br />
&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="示意地图" Font-Size="Medium"></asp:Label>
    
    </div>
    </form>
</body>
</html>
