using System;
using System.Threading.Tasks;
using Tobii.Interaction;
using System.Net.Sockets;

namespace interaction_streams_101
{
    /// <summary>
    /// the data streams provide nicely filtered eye-gaze data from the eye tracker 
    /// transformed to a convenient coordinate system. the point on the screen where 
    /// your eyes are looking (gaze point), and the points on the screen where your 
    /// eyes linger to focus on something (fixations) are given as pixel coordinates 
    /// on the screen. the positions of your eyeballs (eye positions) are given in 
    /// space coordinates in millimeters relative to the center of the screen.
    /// 
    /// let's see how is simple to find out where are you looking at the screen
    /// using gazepoint data stream, accessible from streams property of host instance.
    /// </summary>
    public class program
    {
        public static void Main(string[] args)
        {
            String server = "localhost";
            Int32 port = 8080;
            TcpClient client = new TcpClient(server, port);
            NetworkStream stream = client.GetStream();
            // Everything starts with initializing Host, which manages connection to the 
            // Tobii Engine and provides all the Tobii Core SDK functionality.
            // NOTE: Make sure that Tobii.EyeX.exe is running
            var host = new Host();

            // 2. Create stream. 
            var gazePointDataStream = host.Streams.CreateGazePointDataStream();

            // 3. Get the gaze data!
            gazePointDataStream.GazePoint((x, y, ts) => {
                String message = String.Format("Timestamp: {0}\t X: {1} Y:{2}", ts, x, y);
                Console.WriteLine(message);
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
            });

            // okay, it is 4 lines, but you won't be able to see much without this one :)
            Console.ReadKey();

            // we will close the coonection to the Tobii Engine before exit.
            host.DisableConnection();
        }
    }
}
