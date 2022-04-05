using System;
using System.IO;

namespace Binary_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            //sample data
            int i = 25;
            double d = 3.14159;
            bool b = true;
            string s = "I am happy";

            //create the file
            BinaryWriter bw = new BinaryWriter(new FileStream("mydata", FileMode.Create));

            //writing into the file
            bw.Write(i);
            bw.Write(d);
            bw.Write(b);
            bw.Write(s);

            //close file
            bw.Close();

            //connecting to the file
            BinaryReader br = new BinaryReader(new FileStream("mydata", FileMode.Open));

            //reading from the file
            i = br.ReadInt32();
            Console.WriteLine("Integer data: {0}", i);
            d = br.ReadDouble();
            Console.WriteLine("Double data: {0}", d);
            b = br.ReadBoolean();
            Console.WriteLine("Boolean data: {0}", b);
            s = br.ReadString();
            Console.WriteLine("String data: {0}", s);

            //close the file
            br.Close();

            Console.ReadLine();
        }
    }
}
