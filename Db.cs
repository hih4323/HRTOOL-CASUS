using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRTOOL_CASUS
{
    internal class Db
    {
    /*Dit is de class waar alle database functies samen komen. Er wordt gelezen, geschreven en verwijderd vanuit
     de database. Er volgt een kleine uitleg per functie wat er gebeurd: */

        private SQLiteConnection sqlite_conn;
        public Db()
        {
            
            sqlite_conn = CreateConnection();
        }
        static SQLiteConnection CreateConnection() 
        {
            //Verbinding leggen met de database

            SQLiteConnection sqlite_conn;
            // Het aanmaken van een nieuwe vervinding:
            sqlite_conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
            // Het openen van een nieuwe connnectie:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Er kan niet worden verbonden de database, vraag om ondersteuning" + ex.Message);
            }
            return sqlite_conn;
        }

        public void UpdateAanpassen(int hrid, string datum, int weeknummer,int weekdag, string project, string projectsoort, int id)
        {
            //Vanuit deze functie kan een project worden bijgewerkt

            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "UPDATE werkuren SET hrid = '"+hrid+"', datum = '"+datum+"' ,weeknummer = '" +weeknummer+ "' ,weekdag = '" +weekdag+ "' , project = '" + project+"' , projectsoort = '" +projectsoort+ "' WHERE id = '" +id+ "';";
            sqlite_cmd.ExecuteNonQuery();


        }

        public void Inplannen(int hrid,string datum, int weeknummer, int weekdag, string project, string projectsoort)
        {
            //vanuit deze functie wordt een project ingeplanned en toegevoegd aan de database

            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO werkuren (hrid, datum, weeknummer, weekdag, project, projectsoort) VALUES(@var1,@var2,@var3,@var4,@var5,@var6)";

            sqlite_cmd.Parameters.Add(new SQLiteParameter("@var1", hrid));
            sqlite_cmd.Parameters.Add(new SQLiteParameter("@var2", datum));
            sqlite_cmd.Parameters.Add(new SQLiteParameter("@var3", weeknummer));
            sqlite_cmd.Parameters.Add(new SQLiteParameter("@var4", weekdag));
            sqlite_cmd.Parameters.Add(new SQLiteParameter("@var5", project));
            sqlite_cmd.Parameters.Add(new SQLiteParameter("@var6", projectsoort));

            sqlite_cmd.ExecuteNonQuery();
        }

        public void DeleteWerkuren(string id)
        {
            //Hier kan een project worden verwijderd op basis van het opgegeven ID

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "DELETE FROM werkuren WHERE id= '" + id + "'";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                Console.WriteLine(myreader);
            }

        }

        public Boolean Login(string naam, string pass)
        {
            //Hier wordt er vanuit de database gekeken of iemand kan inloggen.
            //Er wordt een boolean teruggekeerd naar het inlogvenster

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT `gebruikersnaam` FROM gebruikers WHERE `wachtwoord` = '" + pass + "' AND `gebruikersnaam` = '" + naam + "'";
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                bool ver = sqlite_datareader.Read();
                
                if (ver == false)
                {
                    return true;
                }
                
            }

            return false;

        }

        public List<string> ReadForEdit(string id)
        {
            //Als iemand een project wilt aanpassen dienen eerst de gegevens worden ingelezen
            //daarvoor is deze functie bestemd. Dit gebeurd op basis van het ingegeven ID

            List<string> leesaanpassen = new List<string> { };

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT hrid,datum,weeknummer,weekdag,project,projectsoort FROM werkuren WHERE id = @var1;";

            sqlite_cmd.Parameters.Add(new SQLiteParameter("@var1", id));

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                for (int i = 0; i < 6; i++)
                {
                    string? myreader = sqlite_datareader[i].ToString();
                    if (myreader != null)
                    {
                        leesaanpassen.Add(myreader);
                    }
                }

                return leesaanpassen;
            }

            return leesaanpassen;
            

        }

        public List<string> ReadWerkuren()
        {
            //Hier wordt alles ingelezen vanuit tabel werkuren om een overzicht te kunnen weergeven
            //op het dashboard van de Rayco planner.

            List<string> werkuren = new List<string> { };

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM 'werkuren'";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                    string? myreader1 = sqlite_datareader[0].ToString();
                    string? myreader2 = sqlite_datareader[1].ToString();
                    string? myreader3 = sqlite_datareader[2].ToString();
                    string? myreader4 = sqlite_datareader[3].ToString();
                    string? myreader5 = sqlite_datareader[4].ToString();
                    string? myreader6 = sqlite_datareader[5].ToString();
                    string? myreader7 = sqlite_datareader[6].ToString();

                werkuren.Add(myreader1 + "\t"+ myreader2 +"\t\t" + myreader3 + "\t\t" +myreader4 + "\t\t" +myreader5+ "\t\t\t" + myreader7 + "\t" + myreader6);
                
            }

            return werkuren;

        }

        public List<string> ReadDataProjecten()
        {
            //Het inlezen van de project om in een dropdown menu te kunnen wergeven

            List<string> lijstprojecten = new List<string> {};

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT `naam` FROM 'project'";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                lijstprojecten.Add(myreader);
            }

            //sqlite_conn.Close();

            return lijstprojecten;

        }

        public List<string> ReadDataProjectenSoort()
        {
            //Het inlezen van de projectsoort om in een dropdown menu te kunnen wergeven

            List<string> lijstprojectsoorten = new List<string> { };

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT `naam` FROM 'projectsoort'";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                lijstprojectsoorten.Add(myreader);
            }

            //sqlite_conn.Close();

            return lijstprojectsoorten;

        }

        public List<int> ReadInzetUren(int hrid, int weeknummer)
        {
            //Om de beschikbaarheid van iemand te kunnen inlezen moeten de ingeplande uren worden bepaald
            //er wordt vanuit deze functie ingelezen welk project en de functie hieronder beplaalt de tijd
            //die er is aan verbonden en keert een int terug en wordt aan de lijst toegevoegd. De lijst bestaat
            //uit 7 getallen (ma t/m vrij)

            List<int> lijst = new List<int> {0,0,0,0,0,0,0};


            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT weekdag,project FROM werkuren WHERE hrid = '" +hrid+ "' AND weeknummer = '" +weeknummer+ "';";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string? readdag = sqlite_datareader[0].ToString();
                int weekdag = (Convert.ToInt32(readdag) - 1);

                string? project = sqlite_datareader[1].ToString();
                int uitrekenen = ReadProjectUren(project);

                if (lijst[weekdag] == 0)
                {
                    lijst[weekdag] = uitrekenen;
                }

                else if (lijst[weekdag] != 0)
                {
                    lijst[weekdag] = lijst[weekdag] + uitrekenen;
                }
                
            }

            //sqlite_conn.Close();

            return lijst;

        }

        public int ReadProjectUren(string projectnaam)
        {
            //Zie beschrijving 'ReadInzetUren'

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT duur FROM project WHERE naam = '" +projectnaam+ "';";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string? uren = sqlite_datareader[0].ToString();
                int uitkomst = Convert.ToInt32(uren);
                return uitkomst;
            }

            //sqlite_conn.Close();

            return 0;
        }

    }
}
