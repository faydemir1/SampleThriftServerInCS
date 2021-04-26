/* 
 *  Author: Fikri Aydemir
 *  Date  :	10/04/2020 15:14
 *  
 *  Released under MIT License
 *
 */

namespace Server.APIGateway.Thrift
{
    /// <summary>
    /// Main Program
    /// </summary> 
    public class Program
    {
        /// <summary>
        ///  Program Entry
        /// </summary> 
        public static void Main(string[] args)
        {
            var startup = new Startup();
            startup.StartServer();
        }
    }
}
