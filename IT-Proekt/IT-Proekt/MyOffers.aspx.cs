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

        }

        protected void btnNewOfferSubmit_Click(object sender, EventArgs e)
        {
            if (validateOffer())
            {
                int exchange;
                if(chkNewOfferExchange.Checked){
                    exchange=1;
                } else {
                    exchange=0;
                }

                DataTable dtAlbumID = getAlbumID(txbNewOfferAlbum.Text, txbNewOfferAlbumYear.Text);
                DataTable dtSlikaID = getSlikaID(txbNewOfferID.Text, txbNewOfferAlbum.Text, txbNewOfferAlbumYear.Text);
                
                string offerDescription = txbNewOfferDescription.Text;
                int price = Int32.Parse(txbNewOfferPrice.Text);
                string name = txbNewOfferID.Text + " " + txbNewOfferAlbum.Text + " " + txbNewOfferAlbumYear.Text;
                int albumID = Int32.Parse(dtAlbumID.Rows[0]["id"].ToString());
                int slikaID = Int32.Parse(dtSlikaID.Rows[0]["broj"].ToString());
                DateTime date = DateTime.Now;

                bool executeQuery = new Database().addOffer(offerDescription,price,name,albumID,
                                                            slikaID,exchange,"user_example",date);

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
            //get data
            DataTable dtAlbumName=getAlbumName(txbNewOfferAlbum.Text);
            DataTable dtAlbumID = getAlbumID(txbNewOfferAlbum.Text,txbNewOfferAlbumYear.Text);
            DataTable dtID = getSlikaID(txbNewOfferID.Text, txbNewOfferAlbum.Text, txbNewOfferAlbumYear.Text);    

            //check data and display error message

            bool nameError = dtAlbumName.Rows.Count < 1;
            bool yearError = dtAlbumID.Rows.Count < 1;
            bool idError = dtID.Rows.Count < 1;
            bool emptyInput = isInputEmpty();

            if (nameError || yearError || idError || emptyInput)
            {
                if (nameError)
                {
                    lblErrorInput.Text = "Внесовте погрешни податоци.";
                    txbNewOfferAlbum.ForeColor = Color.Red;
                }
                else
                {
                    txbNewOfferAlbum.ForeColor = Color.Black;
                }

                if (yearError)
                {
                    lblErrorInput.Text = "Внесовте погрешни податоци.";
                    txbNewOfferAlbumYear.ForeColor = Color.Red;
                }
                else
                {
                    txbNewOfferAlbumYear.ForeColor = Color.Black;
                }

                if (idError)
                {
                    lblErrorInput.Text = "Внесовте погрешни податоци.";
                    txbNewOfferID.ForeColor = Color.Red;
                }
                else
                {
                    txbNewOfferID.ForeColor = Color.Black;
                }

                pnlErrorInput.Update();

                //if input empty, add red background
                emptyInputErrorMessage();

                return false;
            }
            else
            {
                lblErrorInput.Text = "";
                pnlErrorInput.Update();
                return true;
            }
            
        }

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

        private DataTable getAlbumName(string name)
        {
            Database db = new Database();
            SqlConnection cn = db.getConnection();

            DataTable dtName = new DataTable();
            SqlCommand cmdName = new SqlCommand();
            cmdName.Connection = cn;
            cmdName.CommandType = CommandType.Text;
            cmdName.CommandText = "select name from Album where name=@name";

            cmdName.Parameters.AddWithValue("@name", txbNewOfferAlbum.Text);

            //get data
            try
            {
                cn.Open();
                SqlDataAdapter daName = new SqlDataAdapter();

                daName.SelectCommand = cmdName;
                daName.Fill(dtName);
            }
            catch
            {

            }
            finally
            {
                cn.Close();
            }

            return dtName;
        }

        private DataTable getAlbumID(string name, string year)
        {
            Database db = new Database();
            SqlConnection cn = db.getConnection();
            DataTable dtAlbumID = new DataTable();

            SqlCommand cmdAlbumID = new SqlCommand();
            cmdAlbumID.Connection = cn;
            cmdAlbumID.CommandType = CommandType.Text;
            cmdAlbumID.CommandText = "select id from Album where name=@name and year_published=@year";

            cmdAlbumID.Parameters.AddWithValue("@name", txbNewOfferAlbum.Text);
            cmdAlbumID.Parameters.AddWithValue("@year", txbNewOfferAlbumYear.Text);

            //get data
            try
            {
                cn.Open();
                SqlDataAdapter daAlbumID = new SqlDataAdapter();

                daAlbumID.SelectCommand = cmdAlbumID;
                daAlbumID.Fill(dtAlbumID);
            }
            catch
            {

            }
            finally
            {
                cn.Close();
            }

            return dtAlbumID;
        }

        private DataTable getSlikaID(string id, string name, string year)
        {
            Database db = new Database();
            SqlConnection cn = db.getConnection();
            DataTable dtID = new DataTable();

            SqlCommand cmdID = new SqlCommand();
            cmdID.Connection = cn;
            cmdID.CommandType = CommandType.Text;
            cmdID.CommandText = "select broj " +
                                 "from Slika, (select id from Album where name=@name and year_published=@year) as album " +
                                 "where picture_id=@id and album_id=album.id";

            cmdID.Parameters.AddWithValue("@id", txbNewOfferID.Text);
            cmdID.Parameters.AddWithValue("@name", txbNewOfferAlbum.Text);
            cmdID.Parameters.AddWithValue("@year", txbNewOfferAlbumYear.Text);

            //get data
            try
            {
                cn.Open();
                SqlDataAdapter daID = new SqlDataAdapter();

                daID.SelectCommand = cmdID;
                daID.Fill(dtID);
            }
            catch
            {

            }
            finally
            {
                cn.Close();
            }

            return dtID;
        }

    }
}