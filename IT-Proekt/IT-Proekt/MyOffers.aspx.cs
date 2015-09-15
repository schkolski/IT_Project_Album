using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using System.Web.Services;

namespace IT_Proekt
{
    public partial class MyOffers : System.Web.UI.Page
    {
        Database db;
        ServiceReference1.WebService1 ab;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                fillMyOffers(Session["UserName"].ToString()); // dinamichno dodaj offers
            }
            if (!Page.IsPostBack)
            {
                db = new Database();
                string username = Session["UserName"].ToString();
                List<int> albuIDs = db.getAllAlbumIDsFromPoseduvaByUsername(username);
                ddAlbumName.Items.Add("--Избери");
                foreach (int albumID in albuIDs)
                {
                    Album a = db.getAlbumByID(albumID);
                    ddAlbumName.Items.Add(a.Name);
                }
            }
        }

        protected void fillMyOffers(string username)
        {
            Database db = new Database();
            List<Ponuda> ponudi = db.getAllOffersByUsername(username);

            for (int i = 0; i < ponudi.Count; i += 2) //example usage
            {
                if (ponudi.Count % 2 == 1 && i + 1 == ponudi.Count) //dokolku treba da se loadiraat neparen
                {                                                   //broj ponudi, poslednata ponuda e
                    Ponuda p = ponudi[i];                           //myOfferHalf.ascx
                    myOfferHalf offer = (myOfferHalf)LoadControl("myOfferHalf.ascx");
                    offer.Name = p.Name;
                    offer.Description = p.Desc;
                    offer.Price = p.Price;
                    offer.Offer1ID = p.ID;
                    Slika s = db.getPicture(p.AlbumID, p.BrojSlika);
                    if (s != null)
                        offer.imgUrl = s.Url;
                    offer.albumID = p.AlbumID;
                    offer.pictureID = p.BrojSlika;
                    repeaterMyOffers.Controls.Add(offer);
                }
                else
                {
                    Ponuda p1 = ponudi[i];
                    Ponuda p2 = ponudi[i + 1];

                    myOffer offer = (myOffer)LoadControl("myOffer.ascx");
                    offer.Name1 = p1.Name;
                    offer.Description1 = p1.Desc;
                    offer.Price1 = p1.Price;
                    offer.Offer1ID = p1.ID;
                    Slika s1 = db.getPicture(p1.AlbumID, p1.BrojSlika);
                    if (s1 != null)
                        offer.imgUrl_1 = s1.Url;

                    offer.albumID_1 = p1.AlbumID;
                    offer.pictureID_1 = p1.BrojSlika;

                    offer.Name2 = p2.Name;
                    offer.Description2 = p2.Desc;
                    offer.Price2 = p2.Price;
                    offer.Offer2ID = p2.ID;

                    Slika s2 = db.getPicture(p2.AlbumID, p2.BrojSlika);
                    if (s2 != null)
                        offer.imgUrl_2 = s2.Url;

                    offer.albumID_2 = p2.AlbumID;
                    offer.pictureID_2 = p2.BrojSlika;

                    repeaterMyOffers.Controls.Add(offer);
                    //TODO: fill offer with picture 
                    //  somethink like this:
                    //img.ImgUrl = db.getPictureUrl(p.AlbumID, p.BrojSlika);
                }

            }

        }

        protected void btnNewOfferSubmit_Click(object sender, EventArgs e)
        {
            if (validateOffer())
            {
                Database db = new Database();
                Album album = db.getAlbumByNameAndYear(ddAlbumName.SelectedItem.Text.Trim(),
                    Int32.Parse(ddAlbumYear.SelectedItem.Text.Trim()));
                string offerDesc = txbNewOfferDescription.Text.Trim();
                int price = -1;
                Int32.TryParse(txbNewOfferPrice.Text.Trim(), out price);
                string name = ddAlbumName.SelectedItem.Text;
                int albumid = album.ID;
                int brslika = Int32.Parse(ddPictureNumber.SelectedItem.Text.Trim());
                int exchange = chkNewOfferExchange.Checked ? 1 : 0;
                String username = Session["UserName"].ToString();
                DateTime datum = DateTime.Now;
                int quantity = 1;
                bool executeQuery = db.addOffer(offerDesc, price, name, albumid,
                    brslika, exchange, username, datum, quantity);

                System.Diagnostics.Debug.WriteLine("executeQuery" + executeQuery.ToString());
                if (executeQuery)
                {
                    lblErrorInput.Text = "Успешно додадена нова понуда.";
                    lblErrorInput.ForeColor = Color.Green;
                    pnlErrorInput.Update();
                    clearNewOffer();
                    // TODO: Review this new feature...
                    refreshPage();
                }
                else
                {
                    lblErrorInput.Text = "Понудата не е додадена успешно.";
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Paga na validacija...");
                lblErrorInput.Text = "Грешка во валидација";
            }
        }
        private void refreshPage()
        {
            Response.Redirect("~/MyOffers.aspx");
        }
        protected void btnOfferClear_Click(object sender, EventArgs e)
        {
            clearNewOffer();
        }

        private void clearNewOffer()
        {

            ddAlbumName.SelectedIndex = 0;
            ddAlbumYear.Items.Clear();
            ddPictureNumber.Items.Clear();
            chkNewOfferExchange.Checked = false;
            txbNewOfferDescription.Text = "";
            txbNewOfferPrice.Text = "0";
        }


        private bool validateOffer() //treba da se dodade proverka na tipot na vlezot(int, string...)
        {
            // Validate:
            //  *Album:
            //  - albumName
            //  - albumYear
            // *Picture
            //  - pictureID and albumID
            // *hasDescription
            // *hasPrice or cheched Exchange
            // *hasQuantity >= 1
            string albumName = ddAlbumName.SelectedItem.Text.Trim();
            int albumYear = -1;
            Int32.TryParse(ddAlbumYear.SelectedItem.Text.Trim(), out albumYear);
            int pictureID = -1;
            Int32.TryParse(ddPictureNumber.SelectedItem.Text.Trim(), out pictureID);

            System.Diagnostics.Debug.WriteLine(
                String.Format("AlbumName:{0} AlbumYear:{1} PictureID:{2}",
                albumName, albumYear, pictureID));

            bool valAlbum = validateAlbum(albumName, albumYear);
            bool valImg = validatePicture(albumName, albumYear, pictureID);
            bool valDesc = validateDescription();
            bool valPrice = validatePrice();
            bool valQuant = validateQuantity();
            System.Diagnostics.Debug.WriteLine(
                           String.Format("valAlbum:{0} valImg:{1} valDesc:{2} valPrice:{3} valQuant:{4} CH:{5}",
                           valAlbum.ToString(), valImg.ToString(), valDesc.ToString(), valPrice.ToString(),
                           valQuant.ToString(), chkNewOfferExchange.Checked.ToString()));
            return valAlbum && valImg && valDesc && (valPrice || chkNewOfferExchange.Checked) && valQuant;
        }
        private bool validateAlbum(string name, int year)
        {
            Database db = new Database();
            return db.checkIfAlbumExists(name, year);
        }
        private bool validatePicture(string albumName, int albumYear, int pictureID)
        {
            Database db = new Database();
            Album album = db.getAlbumByNameAndYear(albumName, albumYear);
            //System.Diagnostics.Debug.WriteLine(
            //    String.Format("AlbumName:{0},  AlbumYear:{1}, AlbumID:{2}, PictureID:{3}",
            //        album.Name.ToString(), album.Year.ToString(), album.ID.ToString(), pictureID.ToString()
            //    ));
            if (album != null)
                return db.checkIfPictureExists(album.ID, pictureID);
            return false;
        }
        private bool validateDescription() { return (txbNewOfferDescription.Text.Trim()).Length > 0; }
        private bool validatePrice() { return (txbNewOfferPrice.Text.Trim()).Length > 0; }
        private bool validateQuantity() { return 1 > 0; }

        private bool isInputEmpty()
        {
            bool albumName = ddAlbumName.SelectedItem.Text.Equals("");
            bool albumYear = ddAlbumYear.SelectedItem.Text.Equals("");
            bool ID = ddPictureNumber.SelectedItem.Text.Equals("");

            bool price = txbNewOfferPrice.Text.Equals("");

            if (albumName || albumYear || ID || price)
            {
                return true;
            }
            return false;
        }

        private void emptyInputErrorMessage()
        {
            if (txbNewOfferPrice.Text.Equals(""))
            {
                lblErrorInput.Text = "Внесовте погрешни податоци.";
                txbNewOfferPrice.BackColor = Color.Red;
            }
            else
            {
                txbNewOfferPrice.BackColor = Color.White;
            }

            pnlErrorInput.Update();
        }

        protected void LogOut_Click(Object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }

        protected void btnImagePreview_Click(object sender, EventArgs e)
        {
            // TODO: Better validation
            int albumYear = -1;
            Int32.TryParse(ddAlbumYear.SelectedItem.Text.Trim(), out albumYear);
            int albumID = getAlbumID(ddAlbumName.SelectedItem.Text.Trim(), albumYear);
            int pictureID = -1;
            Int32.TryParse(ddPictureNumber.SelectedItem.Text.Trim(), out pictureID);

            imgNewOfferPreview.ImageUrl = getImageUrl(albumID, pictureID);
        }
        private int getAlbumID(string albumName, int albumYear)
        {
            Database db = new Database();
            Album a = db.getAlbumByNameAndYear(albumName, albumYear);
            if (a != null)
                return a.ID;
            return -1;
        }
        private string getImageUrl(int albumID, int pictureID)
        {
            Database db = new Database();
            Slika s = db.getPicture(albumID, pictureID);

            if (s != null)
                return s.Url;
            return "";
        }

        protected void ddAlbumName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddAlbumYear.Items.Clear();
            ab = new ServiceReference1.WebService1();
            System.Diagnostics.Debug.WriteLine("ovde ke vlezish");
            if (ddAlbumName.SelectedIndex != -1)
            {
                ddAlbumYear.Items.Add("<<--Изберете-->>");
                foreach (String s in ab.getAlbumYearByName(ddAlbumName.SelectedItem.Text))
                {
                    ddAlbumYear.Items.Add(s);
                }
            }
        }

        protected void ddAlbumYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddPictureNumber.Items.Clear();
            if (ddAlbumYear.SelectedIndex != 0)
            {
                db = new Database();
                int x = db.getPictureNumbers(ddAlbumName.SelectedItem.Text, Int32.Parse(ddAlbumYear.SelectedItem.Text));
                int albumYear = Int32.Parse(ddAlbumYear.SelectedItem.Text);
                string albumName = ddAlbumName.SelectedItem.Text;
                string username = Session["UserName"].ToString();
                int albumID = -1;
                Album a = db.getAlbumByNameAndYear(albumName, albumYear);
                if (a != null)
                    albumID = a.ID;
                ddPictureNumber.Items.Add("--Избери");
                for (int i = 1; i <= x; i++)
                {
                    int q = db.getQuantity(username, albumID, i);

                    if (q < 1)
                        continue;

                    ddPictureNumber.Items.Add(i + "");
                }
            }
        }

    }
}