using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.VisualBasic.FileIO;

namespace ZioskProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            while (true)
            {
                Console.WriteLine("Enter zip code or 'exit' to quit : ");
                string readStr = Console.ReadLine();
                if (readStr == "exit")
                {
                    break;
                }

                try
                {
                    
                    using (TextFieldParser lines = new TextFieldParser(path+ @"/data/LA_Full_Service_Restaurants.csv"))
                    {

                        while (true)
                        {
                            lines.Delimiters = new string[] { "," };

                            string[] parts = lines.ReadFields();
                            if (parts == null)
                            {
                                break;
                            }

                            int count = 0;
                            if (parts[5].Substring(0, 5) == readStr)
                            {
                                Console.Write(parts[1]);
                                Console.Write(" - ");
                                Console.WriteLine(parts[3]);
                                count++;
                            }
                            if (count >= 5)
                                break;
                        }
                    }
                    Console.WriteLine("Above are the first 5 restaurants in the given zip code.\n");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Internal server error : \n" + ex.Message);
                }


            }
        }
    }
}

