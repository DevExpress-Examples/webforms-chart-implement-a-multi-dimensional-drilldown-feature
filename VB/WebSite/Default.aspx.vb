Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.XtraCharts
Imports DrillDownDataSetTableAdapters

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not IsPostBack) Then
			Dim ddds As New DrillDownDataSet()
			Dim cta As New CategoriesTableAdapter()

			cta.Fill(ddds.Categories)
			Session("DrillDownDataSet") = ddds
			Session("detailsLevel") = 0
			ShowCategories()
		End If
	End Sub

	Private Sub ShowCategories()
		' Create series
		Dim categoriesSeries As New Series("Categories", ViewType.Bar)

		' Cpecify ScaleTypes
		categoriesSeries.ArgumentScaleType = ScaleType.Qualitative
		categoriesSeries.ValueScaleType = ScaleType.Numerical

		' Bound series to data
		categoriesSeries.DataSource = (TryCast(Session("DrillDownDataSet"), DrillDownDataSet)).Categories
		categoriesSeries.ArgumentDataMember = "CategoryName"
		categoriesSeries.ValueDataMembers.AddRange(New String() { "CategoryID" })

		WebChartControl1.Series.Clear()
		WebChartControl1.Series.Add(categoriesSeries)
		WebChartControl1.DataBind()
	End Sub

	Private Sub ShowProducts()
		' Create series
		Dim productsSeries As New Series("Products", ViewType.Bar)

		' Cpecify ScaleTypes
		productsSeries.ArgumentScaleType = ScaleType.Qualitative
		productsSeries.ValueScaleType = ScaleType.Numerical

		' Bound series to data
		productsSeries.DataSource = (TryCast(Session("DrillDownDataSet"), DrillDownDataSet)).Products
		productsSeries.ArgumentDataMember = "ProductName"
		productsSeries.ValueDataMembers.AddRange(New String() { "UnitPrice" })

		WebChartControl1.Series.Clear()
		WebChartControl1.Series.Add(productsSeries)
		WebChartControl1.DataBind()
	End Sub

	Private Sub ShowOrderDetails()
		' Create series
		Dim orderDetailsSeries As New Series("OrderDetails", ViewType.Bar)

		' Cpecify ScaleTypes
		orderDetailsSeries.ArgumentScaleType = ScaleType.Qualitative
		orderDetailsSeries.ValueScaleType = ScaleType.Numerical

		' Bound series to data
		orderDetailsSeries.DataSource = (TryCast(Session("DrillDownDataSet"), DrillDownDataSet)).Order_Details
		orderDetailsSeries.ArgumentDataMember = "OrderID"
		orderDetailsSeries.ValueDataMembers.AddRange(New String() { "UnitPrice" })

		WebChartControl1.Series.Clear()
		WebChartControl1.Series.Add(orderDetailsSeries)
		WebChartControl1.DataBind()
	End Sub

	Private Sub FilterProducts(ByVal categoryName As String)
		Dim ddds As DrillDownDataSet = (TryCast(Session("DrillDownDataSet"), DrillDownDataSet))
		Dim pta As New ProductsTableAdapter()

		ddds.Products.Clear()
		pta.FillBy(ddds.Products, categoryName)
	End Sub

	Private Sub FilterOrderDetails(ByVal productName As String)
		Dim ddds As DrillDownDataSet = (TryCast(Session("DrillDownDataSet"), DrillDownDataSet))
		Dim oda As New Order_DetailsTableAdapter()

		ddds.Order_Details.Clear()
		oda.FillBy(ddds.Order_Details, productName)
	End Sub

	' Drill implementation
	Protected Sub WebChartControl1_CustomCallback(ByVal sender As Object, ByVal e As DevExpress.XtraCharts.Web.CustomCallbackEventArgs)
		Dim detailsLevel As Integer = Convert.ToInt32(Session("detailsLevel"))
		Dim argument As String = e.Parameter

		If argument <> "" Then
			' DrillDown
			If detailsLevel = 0 Then
				FilterProducts(argument)
				ShowProducts()
			Else
				If detailsLevel = 1 Then
					FilterOrderDetails(argument)
				End If
				ShowOrderDetails()
			End If

			If detailsLevel < 2 Then
				detailsLevel += 1
			End If
		Else
			' DrillUp
			If detailsLevel > 0 Then
				detailsLevel -= 1
			End If

			If detailsLevel = 0 Then
				ShowCategories()
			ElseIf detailsLevel = 1 Then
				ShowProducts()
			End If
		End If

		Session("detailsLevel") = detailsLevel
	End Sub
End Class
