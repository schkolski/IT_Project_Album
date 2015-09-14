using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

namespace IT_Proekt
{
    public partial class Statistiki : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            double[] yValues = { 71.15, 23.19, 5.66 };
            string[] xValues = { "AAA", "BBB", "CCC" };
            Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);

            Chart1.Series["Default"].Points[0].Color = Color.MediumSeaGreen;
            Chart1.Series["Default"].Points[1].Color = Color.PaleGreen;
            Chart1.Series["Default"].Points[2].Color = Color.LawnGreen;

            Chart1.Series["Default"].ChartType = SeriesChartType.Pie;

            Chart1.Series["Default"]["PieLabelStyle"] = "Disabled";

            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

            Chart1.Legends[0].Enabled = true;




            Chart2.Series["Default"].Points.DataBindXY(xValues, yValues);

            Chart2.Series["Default"].Points[0].Color = Color.MediumSeaGreen;
            Chart2.Series["Default"].Points[1].Color = Color.PaleGreen;
            Chart2.Series["Default"].Points[2].Color = Color.LawnGreen;
        
            Chart2.Series["Default"].ChartType = SeriesChartType.Pie;

            Chart2.Series["Default"]["PieLabelStyle"] = "Disabled";

            Chart2.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

            Chart2.Legends[0].Enabled = true;






            Chart3.Series["Default"].Points.DataBindXY(xValues, yValues);

            Chart3.Series["Default"].Points[0].Color = Color.MediumSeaGreen;
            Chart3.Series["Default"].Points[1].Color = Color.PaleGreen;
            Chart3.Series["Default"].Points[2].Color = Color.LawnGreen;

            Chart3.Series["Default"].ChartType = SeriesChartType.Pie;

            Chart3.Series["Default"]["PieLabelStyle"] = "Disabled";

            Chart3.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

            Chart3.Legends[0].Enabled = true;
        }

        protected void LogOut_Click(Object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
    }
}