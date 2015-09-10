using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT_Proekt
{
    public partial class Testing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            // TODO: dodaj Images/album_name/
            string path = Server.MapPath("Images/");

            if (fuPicture.HasFile)
            {
                string ext = Path.GetExtension(fuPicture.FileName);

                if (ext.Equals(".jpg") || ext.Equals(".jpeg") || ext.Equals(".png"))
                {
                    fuPicture.SaveAs(path + fuPicture.FileName);
                    string img_name = "~/images/" + fuPicture.FileName;

                    string q = "INSERT INTO Pictures(src, id, src1) VALUES('" + img_name +
                        "', '" + tbIdInput.Text.Trim() + "', " + "'" + img_name + "')";

                    string connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;

                    SqlConnection con = new SqlConnection(connectionString);
                    SqlCommand cmd = new SqlCommand(q, con);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    img1.ImageUrl = img_name;

                    lblResponse.Text = "Succsessful..." + img_name;
                }
                else
                {
                    lblResponse.Text = "Invalid format";
                }
            }
            else
            {
                lblResponse.Text = "No file selected";
            }
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("Images/");

            // fuPicture.SaveAs(path + fuPicture.FileName);

            string img_name = "";// +fuPicture.FileName;

            string q = "SELECT src1 FROM Pictures WHERE id='" + tbId.Text.Trim() + "'";

            string connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(q, con);

            con.Open();
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                img_name += r["src1"] as String;
            }
            con.Close();
            img2.ImageUrl = img_name;

            lblResponse.Text = "Succsessful retrieved..." + img_name;

        }
    }
}