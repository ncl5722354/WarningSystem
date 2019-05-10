<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChaFenChaxun.ascx.cs" Inherits="webWarningsystem.ChaFenChaxun" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<style type="text/css">
    .auto-style1 {
        position: absolute;
        top: 163px;
        left: 83px;
        z-index: 1;
        width: 102px;
        margin-bottom: 0px;
    }
    .auto-style2 {
        position: absolute;
        top: 469px;
        left: 169px;
        z-index: 1;
        width: 114px;
        height: 110px;
    }
    .auto-style3 {
        position: absolute;
        top: 476px;
        left: 316px;
        z-index: 1;
        width: 102px;
        margin-bottom: 0px;
    }
    .auto-style4 {
        position: absolute;
        top: 471px;
        left: 397px;
        z-index: 1;
        width: 114px;
        height: 109px;
    }
</style>

<p>
    &nbsp;</p>
<p>
    <asp:Chart ID="Chart1" runat="server" CssClass="auto-style1" Height="385px" Width="784px">
        <series>
            <asp:Series ChartType="Spline" Name="Series1">
            </asp:Series>
        </series>
        <chartareas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </chartareas>
    </asp:Chart>
</p>
<p>
    &nbsp;</p>
<p>
    <asp:Label ID="Label1" runat="server" CssClass="auto-style3" Text="曲线2选择"></asp:Label>
</p>
<asp:ListBox ID="ListBox1" runat="server" CssClass="auto-style2"></asp:ListBox>
<asp:ListBox ID="ListBox2" runat="server" CssClass="auto-style4"></asp:ListBox>
<asp:Label ID="Label2" runat="server" CssClass="auto-style1" Text="曲线1选择"></asp:Label>

