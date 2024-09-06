using WebSocketSharp;

namespace DerasWebsocketProtocolSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var ws = new WebSocket("ws://localhost:3030"))
            {
                // Event handler for receiving messages from the server
                ws.OnMessage += (sender, e) =>
                {
                    Console.WriteLine("Received from server: " + e.Data);
                    MessageBox.Show(e.Data);
                };

                ws.Connect();
                string message = "{\"event\": \"scan-rfid-on\"}";
                ws.Send(message);
                Console.WriteLine("Message sent: " + message);

                // Wait for a response from the server
                Console.ReadLine();
                ws.Close();
            }
        }
    }
}
