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
    /// 


    public class program
    {
        public static void Main(string[] args)
        {
           // String server = "34.70.168.249";
            //Int32 port = 3001;
            //TcpClient client = new TcpClient(server, port);
            //NetworkStream stream = client.GetStream();

           //String temp = String.Format("{0} {1} {2}", "aaaa", 100.1, 200.1);
           //Byte[] dataT = System.Text.Encoding.ASCII.GetBytes(temp);
           //stream.Write(dataT, 0, dataT.Length);
           //Console.WriteLine(temp);

            // Everything starts with initializing Host, which manages connection to the 
            // Tobii Engine and provides all the Tobii Core SDK functionality.
            // NOTE: Make sure that Tobii.EyeX.exe is running
            var host = new Host();

            // 2. Create stream. 
            var gazePointDataStream = host.Streams.CreateGazePointDataStream();

            //put your user id shown in the browser
            var uid = 0;

            var count = 0;
            var frequency = 10;

            var real_width = 1920;
            var real_height = 1080;
            var screen_width = 1536;
            var screen_height = 864;

            // 3. Get the gaze data!
            gazePointDataStream.GazePoint((x, y, ts) => {
             String message = String.Format("{0} {1} {2} \n",uid, x, y);
             var convert_x = x / real_width * screen_width;
             var convert_y = y / real_height * screen_height;
                System.Windows.Forms.Cursor.Position = new System.Drawing.Point(Convert.ToInt32(convert_x), Convert.ToInt32(convert_y));
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                count = count + 1;
                if (count == frequency) {
                    //stream.Write(data, 0, data.Length);
                    //stream.Flush();
                    count = 0;
                    Console.WriteLine(message);


                }

            });

            
            // okay, it is 4 lines, but you won't be able to see much without this one :)
            Console.ReadKey();
            //client.Close();

            //String temp = String.Format("I am here socket");
            //Byte[] dataT = System.Text.Encoding.ASCII.GetBytes(temp);
           // NetworkStream stream1 = client.GetStream();
            //stream1.Write(dataT, 0, dataT.Length);
            ///Console.WriteLine(temp);


            // we will close the coonection to the Tobii Engine before exit.
            host.DisableConnection();
           

        }
    }
}
