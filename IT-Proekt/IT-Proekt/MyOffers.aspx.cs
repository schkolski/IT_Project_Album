using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT_Proekt
{
    public partial class MyOffers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnImageUpload_Click(object sender, EventArgs e)
        {

            string fileName = FileUpload1.PostedFile.FileName;

            if (fileName != "") 
            {
                byte[] image;
                Stream stream = FileUpload1.PostedFile.InputStream;
                BinaryReader binRead = new BinaryReader(stream);
                image = binRead.ReadBytes((Int32)stream.Length);


                Database db = new Database();
                int id = db.addSlikaMem(image);

                Response.Write(id); // Da se izbrisi
            }
            
            
        }
    }
}