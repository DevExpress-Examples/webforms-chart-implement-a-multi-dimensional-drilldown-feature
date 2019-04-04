<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to implement a multi-dimensional DrillDown feature


<p>This example demonstrates how you can implement a multi-dimensional DrillDown in the WebChartControl via callbacks only. At that point, WebChartControl  is dynamically updated without reposting the whole page to the server. Please make a note of the following key points of this example:</p><p>- The WebChartControl.EnableViewState property is set to false, since the WebChartControl is updated manually.<br />
- The ASPxClientWebChartControl.ObjectSelected client-side event handler initiates a callback to the server via the ASPxClientWebChartControl.PerformCallback() method.<br />
- All necessary data for this sample is contained in the DrillDownDataSet. The Page.Filter* and Page.Show* methods are used to filter the data and bind it to WebChartControl  correspondingly.<br />
- The core of the DrillDown functionality is implemented in the WebChartControl.CustomCallback event handler.</p>

<br/>


