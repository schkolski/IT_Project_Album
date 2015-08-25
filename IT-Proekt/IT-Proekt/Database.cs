using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IT_Proekt
{

    public class Database
    {
        public SqlConnection getConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            return new SqlConnection(connectionString);
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
                string query = "INSERT INTO Korisnik (type, name, username, passwd, birthday, sex, datum_na_reg)" +
                        " VALUES (@type, @name, @username, @email, AES_ENCRYPT(@passwd, SHA1(@username)), @birthday, @sex, @datum_na_reg)";

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
                Console.WriteLine(result);
            }
            return true;

            //return new Korisnik(name, username, new DateTime(), 0, type, 0);
        }

        public bool addOffer(string offerDesc, int price, string name, int albumid,
            int brslika, int exchange, String username, DateTime datum)
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
                Console.WriteLine(result);
            }
            return true;
        }

        public bool addAlbum(string name, int pubYear)
        {
            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();
                string query = "INSERT INTO Album " +
                    "(name, year_published)" +
                        " VALUES (@name, @pub_year)";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@pub_year", pubYear);


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
                Console.WriteLine(result);
            }
            return true;
        }

        public bool addSlika(int broj, int albumid, int picture_id)
        {
            // Ova se izvrshuva privatno pri dodavanje na slikicka
            
            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();
                string query = "INSERT INTO Slika " +
                    "(broj, album_id, picture_id)" +
                        " VALUES (@broj, @album_id, @picture_id)";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@broj", broj);
                command.Parameters.AddWithValue("@album_id", albumid);
                command.Parameters.AddWithValue("@picture_id", picture_id);


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
                Console.WriteLine(result);
            }
            return true;
        }

        //  TODO: implement
        public int addSlikaMem()
        {
            // TODO: add img into db
            // RETURN: Image database ID
            int ID = -1;
            // Add some code...
            return ID;
        }
        
        private bool addPoseduvaRelation(string username, int albumid, int brslika, int quantity)
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
                Console.WriteLine(result);
            }
            return true;
        }
        
        public bool refreshOffer(int id){
            
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
                Console.WriteLine(result);
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
                               "SET price=@price, " +
                               "SET name=@name, " +
                               "SET album_id=@album_id, " +
                               "SET broj_slika=@broj_slika, " +
                               "SET exchange=@exchange, " +
                               "SET username=@username, " +
                               "SET datum=@datum, " +
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
                Console.WriteLine(result);
            }
            return true;
        }

        public bool updateKorisnik(string oldUsername, string oldPassword,
            string newUsername, string newPassword, string newName,
            string newEmail, DateTime newBirthDay, int newSex) 
        {
            // type e nepromenliv
            // Datumot na registracija e nepromenliv
            SqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();
                string query = "UPDATE Korisnik " +
                               "SET username=@newUsername " +
                               "SET passwd=AES_ENCRYPT(@newPassword, SHA1(@newUsername)) " +
                               "SET name=@newName " +
                               "SET email=@newEmail " +
                               "SET birthday=@newBirthDay " +
                               "SET sex=@newSex " +
                               "WHERE username=@oldUsername " +
                               "AND password=AES_ENCRYPT(@oldPassword, SHA1(@oldUsername))";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@newUsername", newUsername);
                command.Parameters.AddWithValue("@oldUsername", oldUsername);
                command.Parameters.AddWithValue("@newPassword", newPassword);
                command.Parameters.AddWithValue("@oldPassword", oldPassword);
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
                Console.WriteLine(result);
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
                Console.WriteLine(result);
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
                Console.WriteLine(result);
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
                               "AND passwd=AES_ENCRYPT(@passwd, SHA1(@username))";

                SqlCommand command = new SqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@passwd", passwd);

                int userCount = (int)command.ExecuteScalar();
                return userCount > 0;
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                con.Close();
                // Log the result
                Console.WriteLine(result);
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

            if (check) { 
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
                        Console.WriteLine(result);
                    }
                    return true;
                }
                Console.WriteLine("Cannot delete all from Ponuda and Poseduva for username='" + username+"'");
                return false;
            }
            Console.WriteLine("Wrong username or password");
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
                    Console.WriteLine(result);
                }
                return true;
            }
            Console.WriteLine("Cannot delete all from Ponuda and Poseduva for album_id='" + id + "'");
            return false;
        }

        private bool deleteSlika(int broj) 
        {
            bool ponuda = removeAllOffersByBroj(broj);
            bool poseduva = removeAllPoseduvaByBroj(broj);

            if (ponuda && poseduva) { 
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
                    Console.WriteLine(result);
                }
                return true;
            }
            Console.WriteLine("Cannot delete all from Ponuda and Poseduva for slika-broj='" + broj + "'");
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
                Console.WriteLine(result);
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
                Console.WriteLine(result);
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
                Console.WriteLine(result);
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
                Console.WriteLine(result);
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
                Console.WriteLine(result);
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
                Console.WriteLine(result);
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
                Console.WriteLine(result);
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
                Console.WriteLine(result);
            }
            return true;
        }
        
    }
}
