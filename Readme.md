<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128574855/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1250)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# Chart for Web Forms - How to Implement a Multi-Dimensional Drill-Down Feature

This example demonstrates how you can implement a multi-dimensional Drill-Down in the WebChartControl with callbacks only. The WebChartControl is dynamically updated without reposting the whole page to the server. The `WebChartControl.EnableViewState` property is set to `false`, since the `WebChartControl` is updated manually.

- The [ASPxClientWebChartControl.ObjectSelected](xref:https://docs.devexpress.com/AspNet/DevExpress.XtraCharts.Web.WebChartControl.ObjectSelected) client-side event handler initiates a callback to the server with the [ASPxClientWebChartControl.PerformCallback()](https://docs.devexpress.com/AspNet/js-ASPxClientWebChartControl.PerformCallback(args)) method.
- All necessary data for this sample is contained in the `DrillDownDataSet`. The `Page.Filter` and `Page.Show` methods are used to filter the data and bind it to the `WebChartControl` correspondingly.
- The Drill-Down functionality is implemented in the [WebChartControl.CustomCallback](https://docs.devexpress.com/AspNet/DevExpress.XtraCharts.Web.WebChartControl.CustomCallback) event handler.

## Files to Review

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))






