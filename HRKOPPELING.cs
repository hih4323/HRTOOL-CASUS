using hrtool.HRModel;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace hrtool
{
    internal class HRKoppeling
    {

    /*Vanuit deze class wordt er verbinding gelegd met het HR systeem van Rayco.
     Vanuit hier worden medewerkers opgevraagd en de uren kunnen worden bekeken*/

        private readonly HttpClient client = new HttpClient();
        private string baseURL;

        public HRKoppeling(string baseURL)
        {
            this.baseURL = baseURL;
        }

        public IDictionary<string, string>? WerknemerIndex()
        //Opvragen van medewerkers
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var stringTask = client.GetStringAsync(baseURL + "/employees");

            try
            {
                var jsonString = stringTask.Result;

                IDictionary<string, string>? employeeIndex =
                    JsonSerializer.Deserialize<IDictionary<string, string>>(jsonString);

                if (employeeIndex != null)
                {
                    return employeeIndex;
                }

                MessageBox.Show("Onverwachte response: " + jsonString);
            }
            catch (AggregateException ex)
            {
                MessageBox.Show("HR systeem communicatiefout: " + ex.Message);
            }

            return null;

        }

        public int[]? Beschikbaarheid(int werknemerId, int jaar, int weekNr)
        // Opvragen van rooster HRID/jaar/week
        {

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/json");


            var stringTask = client.GetStringAsync(baseURL + "/employee/" + werknemerId + "/availability/" + jaar + "/" + weekNr);

            try
            {
                var jsonString = stringTask.Result;

                Availability? availability = JsonSerializer.Deserialize<Availability>(jsonString);

                if (availability != null &&
                    availability.availability != null &&
                    availability.availability.Count == 7)
                {
                    int[] beschikbaarheid = new int[7];

                    for (var i = 0; i < 7; i++)
                    {
                        beschikbaarheid[i] = availability.availability[i];
                    }

                    return beschikbaarheid;
                }

                MessageBox.Show("Onverwachte response: " + jsonString);
            }
            catch (AggregateException ex)
            {
                MessageBox.Show("HR systeem communicatiefout: " + ex.Message);
            }

            return null;
        }

        public bool CheckPort()
        {
            /*In deze functie wordt er gecontroleerd of er verbinding is met het HR systeem van
             Rayco, hieronder een korte toelichting: */

            string hostname = "127.0.0.1";
            int portno = 8008;
            IPAddress ipa = (IPAddress)Dns.GetHostAddresses(hostname)[0];


            try
            {
                System.Net.Sockets.Socket sock = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
                sock.Connect(ipa, portno);
                if (sock.Connected == true)
                {
                    sock.Close();
                    return true;
                } // Poort is in gebruik van het desbetreffende IP adress


            }
            catch (System.Net.Sockets.SocketException ex)
            {
                if (ex.ErrorCode == 10061)
                {
                    return false;
                } // Indien de poort niet in gebruik is wordt er op het dashboard een melding gegeven
                    
            }

            return false;
        }

    }
}
