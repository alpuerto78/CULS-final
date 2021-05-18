using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace CULS_SERVER
{
    static class Network
    {

        private static TcpListener Server { get; set; }
        private static IPAddress localAddr = IPAddress.Parse(
            Initialization.ReadConfigurationFile("IPV4Configuration", "IPAddress"));
        private static int listenerPort = int.Parse(
            Initialization.ReadConfigurationFile("IPV4Configuration", "Port")); // default is 5000
        private static string Data { get; set; }

        public static void StartListener()
        {
            Server = null;
            try
            {

                // TcpListener server = new TcpListener(port);
                Server = new TcpListener(localAddr, listenerPort);

                // Start listening for client requests.
                Server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                String Data = null;

                // Enter the listening loop.
                while (true)
                {
                    Console.Write("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also use server.AcceptSocket() here.
                    TcpClient client = Server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    Data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        Data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", Data);

                    }

                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }

        public static void StopListener()
        {
            Server.Stop();
        }

        public static void SendData(Int32 destinationPort, IPAddress destinationLocalAddr, String message)
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer
                // connected to the same address as specified by the server, port
                // combination.
                TcpClient client = new TcpClient(destinationLocalAddr.ToString(), destinationPort);

                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Get a client stream for reading and writing.

                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer.
                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", message);

                // Close everything.
                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }

        // The default interfaceName of LAN is "Local Area Connection", but this code is designed to support other interfaceName and wireless connections

        public static void SetStaticIPV4LocalAddress(String interfaceName, String ip, String mask, String gateway, String port)  //set ip to static
        {
            ExecuteCommand("/c netsh interface ip set address \"" + interfaceName + "\" static " + ip + " " + mask + " " + gateway);

            //update contents of config.ini
            var section = "IPV4Configuration";
            Initialization.WriteConfigurationFile(section, "IPAddress", ip);
            Initialization.WriteConfigurationFile(section, "SubnetMask", mask);
            Initialization.WriteConfigurationFile(section, "DefaultGateway", gateway);
            Initialization.WriteConfigurationFile(section, "Port", port);

        }

        public static void SetDHCPIPV4LocalAddress(String interfaceName) //set ip back to auto (DHCP)
        {
            ExecuteCommand("/c netsh interface ip set address \"" + interfaceName + "\" dhcp ");
        }

        //getters
        private static string GetIPV4LocalAddress()
        {
            try
            {
                IPAddress[] ipv4Addresses = Array.FindAll(
                    Dns.GetHostEntry(string.Empty).AddressList,
                    a => a.AddressFamily == AddressFamily.InterNetwork);

                return ipv4Addresses[0].ToString();
            }
            catch (Exception e)
            {
                throw new Exception("No network adapters with an IPv4 address in the system!");
            }
        }

        public static string GetIPV4SubnetMask()
        {
            foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation unicastIPAddressInformation in adapter.GetIPProperties().UnicastAddresses)
                {
                    if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        if (localAddr.Equals(unicastIPAddressInformation.Address))
                        {
                            return unicastIPAddressInformation.IPv4Mask.ToString();
                        }
                    }
                }
            }
            throw new ArgumentException(string.Format("Can't find subnetmask for IP address '{0}'", localAddr));// to be edited
        }

        public static string GetIPV4DefaultGateway()
        {
            return NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up)
                .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .SelectMany(n => n.GetIPProperties()?.GatewayAddresses)
                .Select(g => g?.Address)
                .Where(a => a != null)
                .FirstOrDefault().ToString();
        }

        public static string GetIPV4Port()
        {
            return listenerPort.ToString();
        }

        private static void ExecuteCommand(String command) //function to execute a cmd command with admin privilege
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
                psi.UseShellExecute = true;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.Verb = "runas";
                psi.Arguments = command;
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
