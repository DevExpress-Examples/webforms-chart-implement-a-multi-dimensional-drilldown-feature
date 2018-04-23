using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.XtraCharts;
using DrillDownDataSetTableAdapters;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if(!IsPostBack) {
            DrillDownDataSet ddds = new DrillDownDataSet();
            CategoriesTableAdapter cta = new CategoriesTableAdapter();

            cta.Fill(ddds.Categories);
            Session["DrillDownDataSet"] = ddds;
            Session["detailsLevel"] = 0;
            ShowCategories();
        }
    }

    private void ShowCategories() {
        // Create series
        Series categoriesSeries = new Series("Categories", ViewType.Bar);

        // Cpecify ScaleTypes
        categoriesSeries.ArgumentScaleType = ScaleType.Qualitative;
        categoriesSeries.ValueScaleType = ScaleType.Numerical;

        // Bound series to data
        categoriesSeries.DataSource = (Session["DrillDownDataSet"] as DrillDownDataSet).Categories;
        categoriesSeries.ArgumentDataMember = "CategoryName";
        categoriesSeries.ValueDataMembers.AddRange(new string[] { "CategoryID" });

        WebChartControl1.Series.Clear();
        WebChartControl1.Series.Add(categoriesSeries);
        WebChartControl1.DataBind();
    }

    private void ShowProducts() {
        // Create series
        Series productsSeries = new Series("Products", ViewType.Bar);

        // Cpecify ScaleTypes
        productsSeries.ArgumentScaleType = ScaleType.Qualitative;
        productsSeries.ValueScaleType = ScaleType.Numerical;

        // Bound series to data
        productsSeries.DataSource = (Session["DrillDownDataSet"] as DrillDownDataSet).Products;
        productsSeries.ArgumentDataMember = "ProductName";
        productsSeries.ValueDataMembers.AddRange(new string[] { "UnitPrice" });

        WebChartControl1.Series.Clear();
        WebChartControl1.Series.Add(productsSeries);
        WebChartControl1.DataBind();
    }

    private void ShowOrderDetails() {
        // Create series
        Series orderDetailsSeries = new Series("OrderDetails", ViewType.Bar);

        // Cpecify ScaleTypes
        orderDetailsSeries.ArgumentScaleType = ScaleType.Qualitative;
        orderDetailsSeries.ValueScaleType = ScaleType.Numerical;

        // Bound series to data
        orderDetailsSeries.DataSource = (Session["DrillDownDataSet"] as DrillDownDataSet).Order_Details;
        orderDetailsSeries.ArgumentDataMember = "OrderID";
        orderDetailsSeries.ValueDataMembers.AddRange(new string[] { "UnitPrice" });

        WebChartControl1.Series.Clear();
        WebChartControl1.Series.Add(orderDetailsSeries);
        WebChartControl1.DataBind();
    }

    private void FilterProducts(string categoryName) {
        DrillDownDataSet ddds = (Session["DrillDownDataSet"] as DrillDownDataSet);
        ProductsTableAdapter pta = new ProductsTableAdapter();

        ddds.Products.Clear();
        pta.FillBy(ddds.Products, categoryName);
    }

    private void FilterOrderDetails(string productName) {
        DrillDownDataSet ddds = (Session["DrillDownDataSet"] as DrillDownDataSet);
        Order_DetailsTableAdapter oda = new Order_DetailsTableAdapter();

        ddds.Order_Details.Clear();
        oda.FillBy(ddds.Order_Details, productName);
    }

    // Drill implementation
    protected void WebChartControl1_CustomCallback(object sender, DevExpress.XtraCharts.Web.CustomCallbackEventArgs e) {
        int detailsLevel = Convert.ToInt32(Session["detailsLevel"]);
        string argument = e.Parameter;

        if(argument != "") {
            // DrillDown
            if(detailsLevel == 0) {
                FilterProducts(argument);
                ShowProducts();
            }
            else  {
                if(detailsLevel == 1)
                    FilterOrderDetails(argument);
                ShowOrderDetails();
            }

            if(detailsLevel < 2)
                detailsLevel++;
        }
        else {
            // DrillUp
            if(detailsLevel > 0)
                detailsLevel--;

            if(detailsLevel == 0)
                ShowCategories();
            else if(detailsLevel == 1)
                ShowProducts();
        }

        Session["detailsLevel"] = detailsLevel;
    }
}
