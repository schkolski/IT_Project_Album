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
        }

        protected void fillMyOffers(string username)
        {
            Database db = new Database();
            List<Ponuda> ponudi = db.getAllOffersByUsername(username);


            for (int i = 0; i < ponudi.Count; i+=2) //example usage
            {
                if (ponudi.Count % 2 == 1 && i + 1 == ponudi.Count) //dokolku treba da se loadiraat neparen
                {                                                   //broj ponudi, poslednata ponuda e
                    Ponuda p = ponudi[i];                           //myOfferHalf.ascx
                    myOfferHalf offer = (myOfferHalf)LoadControl("myOfferHalf.ascx");
                    offer.Name = p.Name;
                    offer.Description = p.Desc;
                    offer.Price = p.Price;
                    offer.Offer1ID = p.ID;
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

                    offer.Name2 = p2.Name;
                    offer.Description2 = p2.Desc;
                    offer.Price2 = p2.Price;
                    offer.Offer2ID = p2.ID;

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
                Album album = db.getAlbumByNameAndYear(txbNewOfferAlbum.Text.Trim(),
                    Int32.Parse(txbNewOfferAlbumYear.Text.Trim()));
                string offerDesc = txbNewOfferDescription.Text.Trim();
                int price = Int32.Parse(txbNewOfferPrice.Text.Trim());
                string name = txbNewOfferAlbum.Text;
                int albumid = album.ID;
                int brslika = Int32.Parse(txbNewOfferID.Text.Trim());
                int exchange = chkNewOfferExchange.Checked ? 1 : 0;
                String username = Session["UserName"].ToString();
                DateTime datum = DateTime.Now;
                int quantity = Int32.Parse(txbNewOfferNumber.Text.Trim());
                bool executeQuery = db.addOffer(offerDesc, price, name, albumid,
                    brslika, exchange, username, datum, quantity);

                System.Diagnostics.Debug.WriteLine("executeQuery AddNEWOFFER:" + executeQuery.ToString());
                if (executeQuery)
                {
                    lblErrorInput.Text = "Успешно додадена нова понуда.";
                    lblErrorInput.ForeColor = Color.Green;
                    pnlErrorInput.Update();
                    clearNewOffer();
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

        protected void btnOfferClear_Click(object sender, EventArgs e)
        {
            clearNewOffer();
        }

        private void clearNewOffer()
        {
            txbNewOfferAlbum.Text = "";
            txbNewOfferID.Text = "";
            txbNewOfferAlbumYear.Text = "";
            chkNewOfferExchange.Checked = false;
            txbNewOfferNumber.Text = "1";
            txbNewOfferDescription.Text = "";
            txbNewOfferPrice.Text = "";
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
            string albumName = txbNewOfferAlbum.Text.Trim();
            int albumYear = Int32.Parse(txbNewOfferAlbumYear.Text.Trim());
            int pictureID = Int32.Parse(txbNewOfferID.Text.Trim());

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
            System.Diagnostics.Debug.WriteLine(
                String.Format("AlbumName:{0},  AlbumYear:{1}, AlbumID:{2}, PictureID:{3}",
                    album.Name.ToString(), album.Year.ToString(), album.ID.ToString(), pictureID.ToString()
                ));
            return db.checkIfPictureExists(album.ID, pictureID); 
        }
        private bool validateDescription() { return (txbNewOfferDescription.Text.Trim()).Length > 0; }
        private bool validatePrice() { return (txbNewOfferPrice.Text.Trim()).Length > 0; }
        private bool validateQuantity() { return Int32.Parse((txbNewOfferNumber.Text.Trim())) > 0; }

        private bool isInputEmpty()
        {
            bool albumName = txbNewOfferAlbum.Text.Equals("");
            bool albumYear = txbNewOfferAlbumYear.Text.Equals("");
            bool ID = txbNewOfferID.Text.Equals("");
            bool brSliki = txbNewOfferNumber.Text.Equals("");
            bool price = txbNewOfferPrice.Text.Equals("");

            if (albumName || albumYear || ID || brSliki || price)
            {
                return true;
            }
            return false;
        }

        private void emptyInputErrorMessage()
        {
            if (txbNewOfferAlbum.Text.Equals(""))
            {
                lblErrorInput.Text = "Внесовте погрешни податоци.";
                txbNewOfferAlbum.BackColor = Color.Red;
            }
            else
            {
                txbNewOfferAlbum.BackColor = Color.White;
            }

            if (txbNewOfferAlbumYear.Text.Equals(""))
            {
                lblErrorInput.Text = "Внесовте погрешни податоци.";
                txbNewOfferAlbumYear.BackColor = Color.Red;
            }
            else
            {
                txbNewOfferAlbumYear.BackColor = Color.White;
            }

            if (txbNewOfferID.Text.Equals(""))
            {
                lblErrorInput.Text = "Внесовте погрешни податоци.";
                txbNewOfferID.BackColor = Color.Red;
            }
            else
            {
                txbNewOfferID.BackColor = Color.White;
            }

            if (txbNewOfferNumber.Text.Equals(""))
            {
                lblErrorInput.Text = "Внесовте погрешни податоци.";
                txbNewOfferNumber.BackColor = Color.Red;
            }
            else
            {
                txbNewOfferNumber.BackColor = Color.White;
            }

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

    }
}