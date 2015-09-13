using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IT_Proekt
{

    public class Database
    {
        public void Log(string methodName, string msg)
        {
            System.Diagnostics.Debug.WriteLine(methodName + " : " + msg);
        }
        public SqlConnection getConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;

            return new SqlConnection(connectionString);
        }
        public Korisnik getUserInfoByUsername(string username)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            Korisnik k = null;
            //string name, string username, DateTime bday, int sex, int type, double thrustLevel)
            try
            {
                con.Open();
                string query = "SELECT type, name, email, birthday, sex, trust_level " +
                    "FROM Korisnik WHERE username=@username";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@username", username);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    k = new Korisnik(
                         reader["name"].ToString(),
                         username,
                         reader["email"].ToString(),
                         DateTime.Parse(reader["birthday"].ToString()),
                         Int32.Parse(reader["sex"].ToString()),
                         Int32.Parse(reader["type"].ToString()),
                         Double.Parse(reader["trust_level"].ToString())
                     );
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("getUserInfoByUsername", result);
            }
            return k;
        }
        public List<Album> getAllAlbums()
        {
            SqlConnection con = getConnection();
            string result = "OK";
            List<Album> albums = null;
            try
            {
                con.Open();
                string query = "SELECT id, name, year_published FROM Album";
                SqlCommand command = new SqlCommand(query, con);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataSet data = new DataSet();
                dataAdapter.Fill(data);

                albums = new List<Album>();
                foreach (DataRow row in data.Tables[0].Rows)
                {
                    Album album = new Album(
                        Int32.Parse(row["id"].ToString()),
                        row["name"].ToString(),
                        Int32.Parse(row["year_published"].ToString())
                    );
                    albums.Add(album);
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("getAllAlbums", result);
            }
            return albums;
        }
        public Album getAlbumByNameAndYear(string name, int year)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            Album album = null;
            try
            {
                con.Open();
                string query = "SELECT id, name, year_published FROM Album WHERE name=@name AND year_published=@year";

                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@year", year);


                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    album = new Album(
                         Int32.Parse(reader["id"].ToString()),
                         name,
                         year
                     );
                }

                return album;
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("getAlbumByNameAndYear", result);
            }
            return album;
        }
        public Album getAlbumByID(int albumID)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            Album album = null;
            try
            {
                con.Open();
                string query = "SELECT name, year_published FROM Album WHERE id=@album_id";

                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@album_id", albumID);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    album = new Album(
                         albumID,
                         reader["name"].ToString(),
                         Int32.Parse(reader["year_published"].ToString())
                     );
                }

                return album;
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("getAlbumByID", result);
            }
            return album;
        }
        public Slika getPicture(int albumID, int pictureID)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            Slika picture = null;
            try
            {
                con.Open();
                string query = "SELECT name, url FROM Slika " +
                                "WHERE broj=@broj AND album_id=@album_id";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@broj", pictureID);
                command.Parameters.AddWithValue("@album_id", albumID);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    picture = new Slika(pictureID, albumID,
                        reader["url"] as String,
                        reader["name"] as String);

                    return picture;
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("getPicture", result);
            }
            return picture;
        }
        public List<Slika> getAllPicturesByAlbumID(int album_id)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            List<Slika> pictures = null;
            try
            {
                con.Open();
                string query = "SELECT  broj, url, name FROM Slika " +
                                "WHERE album_id=@album_id";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@album_id", album_id);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataSet data = new DataSet();
                dataAdapter.Fill(data);

                pictures = new List<Slika>();
                foreach (DataRow row in data.Tables[0].Rows)
                {
                    Slika picture = new Slika(
                            Int32.Parse(row["broj"].ToString()),
                            album_id,
                            row["url"].ToString(),
                            row["name"].ToString()
                        );
                    pictures.Add(picture);
                }
                return pictures;
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("getAllPicturesByAlbumID", result);
            }
            return pictures;
        }
        public List<Ponuda> getAllOffers()
        {
            SqlConnection con = getConnection();
            string result = "OK";
            List<Ponuda> offers = null;
            try
            {
                con.Open();
                string query = "SELECT id, offer_description, price, name, " +
                                    "album_id, broj_slika, exchange, username, datum " +
                               "FROM Ponuda";

                SqlCommand command = new SqlCommand(query, con);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataSet data = new DataSet();
                dataAdapter.Fill(data);

                offers = new List<Ponuda>();
                foreach (DataRow row in data.Tables[0].Rows)
                {
                    Ponuda offer = new Ponuda(
                        Int32.Parse(row["id"].ToString()),
                        row["offer_description"].ToString(),
                        Int32.Parse(row["price"].ToString()),
                        row["name"].ToString(),
                        Int32.Parse(row["album_id"].ToString()),
                        Int32.Parse(row["broj_slika"].ToString()),
                        row["username"].ToString(),
                        Int32.Parse(row["exchange"].ToString()),
                        DateTime.Parse(row["datum"].ToString())
                    );
                    offers.Add(offer);
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("getAllOffers", result);
            }
            return offers;
        }
        public List<Ponuda> getAllOffersByUsername(string username)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            List<Ponuda> offers = null;
            try
            {
                con.Open();
                string query = "SELECT id, offer_description, price, name, " +
                                    "album_id, broj_slika, exchange, username, datum " +
                               "FROM Ponuda " +
                               "WHERE username=@username";

                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@username", username);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataSet data = new DataSet();
                dataAdapter.Fill(data);

                offers = new List<Ponuda>();
                foreach (DataRow row in data.Tables[0].Rows)
                {
                    Ponuda offer = new Ponuda(
                        Int32.Parse(row["id"].ToString()),
                        row["offer_description"].ToString(),
                        Int32.Parse(row["price"].ToString()),
                        row["name"].ToString(),
                        Int32.Parse(row["album_id"].ToString()),
                        Int32.Parse(row["broj_slika"].ToString()),
                        row["username"].ToString(),
                        Int32.Parse(row["exchange"].ToString()),
                        DateTime.Parse(row["datum"].ToString())
                    );
                    offers.Add(offer);
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("getAllOffersByUsername", result);
            }
            return offers;
        }
        public List<Ponuda> getAllOffersForUsername(string username, string orderBy)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            List<Ponuda> offers = null;
            try
            {
                con.Open();
                string query = 
                    "SELECT * FROM Ponuda as p "+
                    "WHERE p.album_id IN ( "+
					        "SELECT distinct(po.album_id) "+
					        "FROM Poseduva as po "+
					        "WHERE po.username = @username "+
				            ") "+
		            "AND p.broj_slika NOT IN ( "+
						    "SELECT po1.broj_slika "+
						    "FROM Poseduva as po1 "+
						    "WHERE po1.album_id = p.album_id AND po1.username=@username AND "+
							"po1.quantity > 0 "+
                            ") "+
                    "AND p.id NOT IN ( "+
					        "SELECT t.ponuda_id from Transakcija as t "+
					        "WHERE t.username = @username "+
			                ") "+
                    "ORDER BY " + orderBy;

                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@username", username);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataSet data = new DataSet();
                dataAdapter.Fill(data);

                offers = new List<Ponuda>();
                foreach (DataRow row in data.Tables[0].Rows)
                {
                    Ponuda offer = new Ponuda(
                        Int32.Parse(row["id"].ToString()),
                        row["offer_description"].ToString(),
                        Int32.Parse(row["price"].ToString()),
                        row["name"].ToString(),
                        Int32.Parse(row["album_id"].ToString()),
                        Int32.Parse(row["broj_slika"].ToString()),
                        row["username"].ToString(),
                        Int32.Parse(row["exchange"].ToString()),
                        DateTime.Parse(row["datum"].ToString())
                    );
                    offers.Add(offer);
                }
                return offers;
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("getAllOffersForUsername", result);
            }
            return offers;
        }
        public int getQuantity(string username, int album_id, int broj_slika)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            int quantity = 0;
            try
            {
                con.Open();
                string query = "SELECT quantity " +
                               "FROM Poseduva " +
                               "WHERE username=@username AND " +
                                   "album_id=@album_id AND " +
                                   "broj_slika=@broj_slika";

                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@album_id", album_id);
                command.Parameters.AddWithValue("@broj_slika", broj_slika);


                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    quantity = Int32.Parse(reader["quantity"].ToString());
                }
                return quantity;
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("getQuantity", result);
            }
            return quantity;
        }

        public bool addKorisnik(string username, string password, string name,
            string email, int type, DateTime birthDay, int sex)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();
                // TODO: Ovde mozi treba trustlevel? ILi default se vnesuva ako nema niso?
                //TODO: ADD email????
                string query = "INSERT INTO Korisnik (type, name, username,email, passwd, birthday, sex,datum_na_reg)" +
                        " VALUES (@type, @name, @username, @email,HASHBYTES('SHA1',@passwd), @birthday, @sex,@datum_na_reg)";
                //   HASHBYTES('SHA1',@passwd)
                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@type", type);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@passwd", password);
                command.Parameters.AddWithValue("@birthday", birthDay);
                command.Parameters.AddWithValue("@sex", sex);
                command.Parameters.AddWithValue("@datum_na_reg", DateTime.Now);



                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                result = e.Message;
                return false;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("addKorisnik", result);
            }
            return true;

            //return new Korisnik(name, username, new DateTime(), 0, type, 0);
        }
        public bool addTransakcijaBuy(string username, int offerID)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();
                string query = "INSERT INTO Transakcija " +
                    "(ponuda_id, username, datum, status, album_id, broj_slika) " +
                    "VALUES (@ponuda_id, @username, @datum, @status, null, null)";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@ponuda_id", offerID);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@datum", DateTime.Now);
                command.Parameters.AddWithValue("@status", 0);
                //command.Parameters.AddWithValue("@album_id", null);
                //command.Parameters.AddWithValue("@broj_slika", null);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                result = e.Message;
                return false;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("addTransakcijaBuy", result);
            }
            return true;
        }
        public bool addTransakcijaExchange(string username, int offerID, int albumID, int pictureID)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();
                string query = "INSERT INTO Transakcija " +
                    "(ponuda_id, username, datum, status, album_id, broj_slika) " +
                    "VALUES (@ponuda_id, @username, @datum, @status, @album_id, @broj_slika)";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@ponuda_id", offerID);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@datum", DateTime.Now);
                command.Parameters.AddWithValue("@status", 0);
                command.Parameters.AddWithValue("@album_id", albumID);
                command.Parameters.AddWithValue("@broj_slika", pictureID);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                result = e.Message;
                return false;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("addTransakcijaExchange", result);
            }
            return true;
        }
        public bool addOffer(string offerDesc, int price, string name, int albumid,
            int brslika, int exchange, String username, DateTime datum, int quantity)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();
                string query = "INSERT INTO Ponuda " +
                    "(offer_description, price, name, album_id, broj_slika, exchange, username, datum)" +
                        " VALUES (@odesc, @price, @name, @album_id, @broj_slika, @exchange, @username, @datum)";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@odesc", offerDesc);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@album_id", albumid);
                command.Parameters.AddWithValue("@broj_slika", brslika);
                command.Parameters.AddWithValue("@exchange", exchange);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@datum", datum);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                result = e.Message;
                return false;
            }
            finally
            {
                con.Close();
                // Log the result
                if (result.Equals("OK"))
                {
                    addPoseduvaRelation(username, albumid, brslika, quantity);
                }
                Log("addOffer", result);
            }
            return true;
        }

        public int addAlbum(string name, int pubYear, int broj_na_sliki)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            int res = -1;
            try
            {
                con.Open();
                string query = "INSERT INTO Album " +
                    "(name, year_published, broj_na_sliki) OUTPUT INSERTED.id" +
                        " VALUES (@name, @pub_year, @broj_na_sliki)";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@pub_year", pubYear);
                command.Parameters.AddWithValue("@broj_na_sliki", broj_na_sliki);

                object returnObj = command.ExecuteScalar();

                if (returnObj != null)
                {
                    int.TryParse(returnObj.ToString(), out res);
                    Log("addAlbumRES", res.ToString());
                    return res;
                }

            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("addAlbum", result + " " + res.ToString());
            }
            return res;
        }

        public bool addSlika(int broj, int albumid, string name, string url)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();
                string query = "INSERT INTO Slika " +
                    "(broj, album_id, url, name)" +
                        " VALUES (@broj, @album_id, @url, @name)";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@broj", broj);
                command.Parameters.AddWithValue("@album_id", albumid);
                command.Parameters.AddWithValue("@url", url);
                command.Parameters.AddWithValue("@name", name);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                result = e.Message;
                return false;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("addSlika", result);
            }
            return true;
        }

        public bool addPoseduvaRelation(string username, int albumid, int brslika, int quantity)
        {
            // Ova se izvrshuva privatno pri dodavanje na slikicka

            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();
                string query = "INSERT INTO Poseduva " +
                    "(username, album_id, broj_slika, quantity)" +
                        " VALUES (@username, @album_id, @broj_slika, @quantity)";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@album_id", albumid);
                command.Parameters.AddWithValue("@broj_slika", brslika);
                command.Parameters.AddWithValue("@quantity", quantity);


                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                result = e.Message;
                return false;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("addPoseduvaRelation", result);
            }
            return true;
        }

        public bool updatePoseduvaRelation(string username, int albumid, int brslika, int quantity)
        {

            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();
                string query = "UPDATE Poseduva " +
                               "SET quantity=@quantity " +
                               "WHERE username=@username AND album_id=@album_id AND broj_slika=@broj_slika";


                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@album_id", albumid);
                command.Parameters.AddWithValue("@broj_slika", brslika);
                command.Parameters.AddWithValue("@quantity", quantity);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                result = e.Message;
                return false;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("updatePoseduvaRelation", result);
            }
            return true;
        }
        public bool refreshOffer(int id)
        {

            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();
                string query = "UPDATE Ponuda " +
                               "SET datum=@datum " +
                               "WHERE id=@id";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@datum", DateTime.Now);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                result = e.Message;
                return false;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("refreshOffer", result);
            }
            return true;
        }
        public bool updateOffer(int id, string offerDesc, int price, string name, int albumid,
            int brslika, int exchange, String username, DateTime datum)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();
                string query = "UPDATE Ponuda " +
                               "SET offer_description=@offerDesc, " +
                               " price=@price, " +
                               " name=@name, " +
                               " album_id=@album_id, " +
                               " broj_slika=@broj_slika, " +
                               " exchange=@exchange, " +
                               " username=@username, " +
                               " datum=@datum " +
                               "WHERE id=@id";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@offerDesc", offerDesc);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@album_id", albumid);
                command.Parameters.AddWithValue("@broj_slika", brslika);
                command.Parameters.AddWithValue("@exchange", exchange);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@datum", datum);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                result = e.Message;
                return false;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("updateOffer", result);
            }
            return true;
        }
        public bool changePassword(string username, string oldPassword, string newPassword)
        {
            if (!checkKorisnik(username, oldPassword))
            {
                Log("changePassword->checkKorisnik", "Wrong old password");
                return false;
            }
            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();
                string query = "UPDATE Korisnik " +
                               "SET passwd=HASHBYTES('SHA1',@newPassword) " +
                               "WHERE username=@username " +
                               "AND passwd=HASHBYTES('SHA1',@oldPassword)";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@newPassword", newPassword);
                command.Parameters.AddWithValue("@oldPassword", oldPassword);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                result = e.Message;
                return false;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("changePassword", result);
            }
            return true;
        }
        public bool updateKorisnik(string username, string newName,
            string newEmail, DateTime newBirthDay, int newSex)
        {
            Log("DATUM:", newBirthDay.ToString());
            // type e nepromenliv
            // Datumot na registracija e nepromenliv

            Log("USERNAME:", username);
            Log("NEW_NAME:", newName);
            Log("NEW_EMAIL:", newEmail);
            Log("NEW_bDAY:", newBirthDay.ToShortDateString());
            Log("NEW_SEX:", newSex.ToString());


            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();
                string query = "UPDATE Korisnik " +
                               "SET name=@newName, " +
                               " email=@newEmail, " +
                               " birthday=@newBirthDay, " +
                               " sex=@newSex " +
                               "WHERE username=@username ";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@newName", newName);
                command.Parameters.AddWithValue("@newEmail", newEmail);
                command.Parameters.AddWithValue("@newBirthDay", newBirthDay);
                command.Parameters.AddWithValue("@newSex", newSex);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                result = e.Message;
                return false;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("updateKorisnik", result);
            }
            return true;
        }

        public bool updateQuantity(string username, int album_id, int broj_slika, int newQuantity)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();
                string query = "UPDATE Poseduva " +
                               "SET quantity=@newQuantity " +
                               "WHERE username=@username " +
                               "AND album_id=@album_id " +
                               "AND broj_slika=@broj_slika";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@newQuantity", newQuantity);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@album_id", album_id);
                command.Parameters.AddWithValue("@broj_slika", broj_slika);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                result = e.Message;
                return false;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("updateQuantity", result);
            }
            return true;
        }

        public bool updateSlika(int broj, int album_id, int oldSlikaId, int newSlikaId)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();
                // TODO: Remove SlikaMem before update 'WHERE id=oldSlikaId'
                string query = "UPDATE Slika " +
                               "SET picture_id=@picture_id " +
                               "WHERE broj=@broj " +
                               "AND album_id=@album_id";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@picture_id", newSlikaId);
                command.Parameters.AddWithValue("@broj", broj);
                command.Parameters.AddWithValue("@album_id", album_id);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                result = e.Message;
                return false;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("updateSlika", result);
            }
            return true;
        }

        public bool checkKorisnik(string username, string passwd)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();

                string query = "SELECT TOP 1 username " +
                               "FROM Korisnik " +
                               "WHERE username=@username " +
                               "AND passwd=HASHBYTES('SHA1',@passwd)";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@passwd", passwd);

                bool userCount = command.ExecuteScalar() != null;
                return userCount;
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("checkKorisnik", result);
            }
            return false;
        }

        public bool checkIfExistsKorisnik(string username)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();

                string query = "SELECT TOP 1 username " +
                               "FROM Korisnik " +
                               "WHERE username=@username";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@username", username);

                bool userCount = command.ExecuteScalar() != null;
                return userCount;
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("checkIfExistsKorisnik", result);
            }
            return false;
        }
        public bool checkIfAlbumExists(string name, int year)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();

                string query = "SELECT TOP 1 id " +
                               "FROM Album " +
                               "WHERE name=@name AND year_published=@year";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@year", year);

                bool albumCount = command.ExecuteScalar() != null;
                return albumCount;
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("checkIfAlbumExists", result);
            }
            return false;
        }
        public bool checkIfPictureExists(int albumID, int pictureID)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();

                string query = "SELECT TOP 1 name " +
                               "FROM Slika " +
                               "WHERE broj=@picture_id AND album_id=@album_id";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@picture_id", pictureID);
                command.Parameters.AddWithValue("@album_id", albumID);

                return command.ExecuteScalar() != null;
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("checkIfPictureExists", result);
            }
            return false;
        }
        public bool deleteKorisnik(string username, string passwd)
        {
            // DONE and CHECKED but TRIPLE CHECK THIS!!!
            // TODO: where username = username AND password = AES_ENCRYPT(@passwd, SHA1(@username))";
            //        1. Remove all from Ponuda 
            //        2. Remove all from Poseduva
            //        3. Finally remove Korisnik
            bool check = checkKorisnik(username, passwd);

            if (check)
            {
                bool ponuda = removeAllOffersByUsername(username);
                bool poseduva = removeAllPoseduvaByUsername(username);

                if (ponuda && poseduva)
                {
                    SqlConnection con = getConnection();
                    string result = "OK";
                    try
                    {
                        con.Open();

                        string query = "DELETE FROM Korisnik " +
                                       "WHERE username=@username";

                        SqlCommand command = new SqlCommand(query, con);
                        command.Prepare();
                        command.Parameters.AddWithValue("@username", username);

                        command.ExecuteNonQuery();

                    }
                    catch (Exception e)
                    {
                        result = e.Message;
                        return false;
                    }
                    finally
                    {
                        con.Close();
                        // Log the result
                        Log("addAlbum", result);
                    }
                    return true;
                }
                Log("deleteKorisnik", "Cannot delete all from Ponuda and Poseduva for username='" + username + "'");
                return false;
            }
            Log("deleteKorisnik", "Wrong username or password");
            return false;
        }

        public bool deleteAlbum(int id)
        {
            // TODO: where album_id = id; // DONE and CHECKED but TRIPLE CHECK THIS!!!
            //        1. Remove all from Ponuda 
            //        2. Remove all from Poseduva
            //        3. Remove all from Slika
            //        4. Finally remove Album 

            bool ponuda = removeAllOffersByAlbumId(id);
            bool poseduva = removeAllPoseduvaByAlbumId(id);
            bool slika = removeAllSlikaByAlbumId(id);
            if (ponuda && poseduva && slika)
            {
                SqlConnection con = getConnection();
                string result = "OK";
                try
                {
                    con.Open();

                    string query = "DELETE FROM Album " +
                                   "WHERE id=@id";

                    SqlCommand command = new SqlCommand(query, con);
                    command.Prepare();
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    result = e.Message;
                    return false;
                }
                finally
                {
                    con.Close();
                    // Log the result
                    Log("deleteAlbum", result);
                }
                return true;
            }
            Log("deleteAlbum", "Cannot delete all from Ponuda and Poseduva for album_id='" + id + "'");
            return false;
        }

        public bool removeOffer(string username, int albumID, int pictureID)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();

                string query1 = "DELETE FROM Ponuda " +
                                "WHERE username=@username AND "+
                                "album_id=@album_id AND broj_slika=@picture_id";
                string query2 = "DELETE FROM Poseduva " +
                                "WHERE username=@username AND " +
                                "album_id=@album_id AND broj_slika=@picture_id";

                SqlCommand cmd = con.CreateCommand();
                SqlTransaction transaction = con.BeginTransaction("Deleting an Offer");

                cmd.Connection = con;
                cmd.Transaction = transaction;

                cmd.CommandText = query1;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@album_id", albumID);
                cmd.Parameters.AddWithValue("@picture_id", pictureID);
                cmd.ExecuteNonQuery();
                cmd.CommandText = query2;
                cmd.ExecuteNonQuery();

                transaction.Commit();
                Log("removeOffer", "Successfully removed an Offer");

            }
            catch (Exception e)
            {
                result = e.Message;
                return false;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("removeOffer", result);
            }
            return true;
        }
        private bool deleteSlika(int broj)
        {
            bool ponuda = removeAllOffersByBroj(broj);
            bool poseduva = removeAllPoseduvaByBroj(broj);

            if (ponuda && poseduva)
            {
                SqlConnection con = getConnection();
                string result = "OK";
                try
                {
                    con.Open();

                    string query = "DELETE FROM Slika " +
                                   "WHERE broj=@broj";

                    SqlCommand command = new SqlCommand(query, con);
                    command.Prepare();
                    command.Parameters.AddWithValue("@broj", broj);

                    command.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    result = e.Message;
                    return false;
                }
                finally
                {
                    con.Close();
                    // Log the result
                    Log("deleteSlika", result);
                }
                return true;
            }
            Log("deleteSlika", "Cannot delete all from Ponuda and Poseduva for slika-broj='" + broj + "'");
            return false;
        }

        private bool deleteSlikaMem(int id)
        {

            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();

                string query = "DELETE FROM Slika_mem " +
                               "WHERE id=@id";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                result = e.Message;
                return false;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("deleteSlikaMem", result);
            }
            return true;
        }

        private bool removeAllOffersByAlbumId(int album_id)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();

                string query = "DELETE FROM Ponuda " +
                               "WHERE album_id=@album_id";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@album_id", album_id);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                result = e.Message;
                return false;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("removeAllOffersByAlbumId", result);
            }
            return true;
        }
        private bool removeAllOffersByUsername(string username)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();

                string query = "DELETE FROM Ponuda " +
                               "WHERE username=@username";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@username", username);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                result = e.Message;
                return false;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("removeAllOffersByUsername", result);
            }
            return true;
        }
        private bool removeAllOffersByBroj(int broj)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();

                string query = "DELETE FROM Ponuda " +
                               "WHERE broj=@broj";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@broj", broj);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                result = e.Message;
                return false;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("removeAllOffersByBroj", result);
            }
            return true;
        }
        private bool removeAllPoseduvaByAlbumId(int album_id)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();

                string query = "DELETE FROM Poseduva " +
                               "WHERE album_id=@album_id";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@album_id", album_id);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                result = e.Message;
                return false;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("removeAllPoseduvaByAlbumId", result);
            }
            return true;
        }
        private bool removeAllPoseduvaByUsername(string username)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();

                string query = "DELETE FROM Poseduva " +
                               "WHERE id=@id";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@username", username);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                result = e.Message;
                return false;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("removeAllPoseduvaByUsername", result);
            }
            return true;
        }
        private bool removeAllPoseduvaByBroj(int broj)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();

                string query = "DELETE FROM Poseduva " +
                               "WHERE broj=@broj";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@broj", broj);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                result = e.Message;
                return false;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("removeAllPoseduvaByBroj", result);
            }
            return true;
        }
        private bool removeAllSlikaByAlbumId(int album_id)
        {
            // TODO:
            // pri brishenje na site sliki od Slika da se izbrishat site memorirani sliki vo Slika_mem
            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();

                string query = "DELETE FROM Slika " +
                               "WHERE album_id=@album_id";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@album_id", album_id);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                result = e.Message;
                return false;
            }
            finally
            {
                con.Close();
                // Log the result
                Log("removeAllSlikaByAlbumId", result);
            }
            return true;
        }

    }
}
