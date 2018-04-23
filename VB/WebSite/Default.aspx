<%@ Page Language="vb" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.XtraCharts.v8.3.Web, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>
<%@ Register Assembly="DevExpress.XtraCharts.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.XtraCharts" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
		<dxchartsui:WebChartControl ID="WebChartControl1" runat="server"  Width="700px" Height="300px"
			EnableViewState="False"
			EnableClientSideAPI="True" 
			ClientInstanceName="chart" OnCustomCallback="WebChartControl1_CustomCallback" >

			<ClientSideEvents ObjectSelected="function(s, e) {
	var parameter = (e.additionalHitObject!=null?e.additionalHitObject.argument:&quot;&quot;);

	chart.PerformCallback(parameter);
	e.processOnServer = false;
}" ObjectHotTracked="function(s, e) {
	s.SetCursor((e.additionalHitObject != null) ? 'pointer' : 'default');    
}" />

		</dxchartsui:WebChartControl>
		<br />
	</form>
</body>
</html>
