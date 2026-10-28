namespace _20261028_FilesDemo
{
    internal class Program
    {
        const string WORK_FILE_NAME = "..\\..\\..\\test.txt";

        static void Main(string[] args)
        {
            WriteTextData();

            ReadTextData();

            FileInfo fiWorkFile = new FileInfo(WORK_FILE_NAME);

            if (fiWorkFile.Exists)
            {
                Console.WriteLine("+");

                Console.WriteLine($"Work File Size: {fiWorkFile.Length}");

                //string[] allFiles = Directory.GetFiles("C:\\Users\\opiur\\source\\repos\\", "*.cs", SearchOption.AllDirectories);

                string[] allFiles = Directory.GetFiles("C:\\Users\\opiur\\source\\repos\\", "t*.txt", SearchOption.AllDirectories);

                for (int i = 0; i < allFiles.Length; i++)
                {
                    Console.WriteLine(allFiles[i]);
                }
            }
            else
            {
                Console.WriteLine("-");
            }

        }

        private static void ReadTextData()
        {
            using (Stream sOut = new FileStream(WORK_FILE_NAME, FileMode.Open))
            {
                StreamReader readerWorkFile = new StreamReader(sOut);

                string s = readerWorkFile.ReadLine();

                Console.WriteLine(s);

                int k = int.Parse(readerWorkFile.ReadLine());
                Console.WriteLine(k);

                double p = double.Parse(readerWorkFile.ReadLine());
                Console.WriteLine(p);

                Student stud1 = ReadStudent(readerWorkFile);

                Console.WriteLine(stud1);
            }    // sOut.Dispose();    --> Close file
        }

        private static void WriteTextData()
        {
            using (Stream sOut = new FileStream(WORK_FILE_NAME, FileMode.OpenOrCreate))
            {
                StreamWriter writerWorkFile = new StreamWriter(sOut);

                writerWorkFile.WriteLine("Very important text!");

                int k = 321;

                writerWorkFile.WriteLine(k);

                double p = 12.456;

                writerWorkFile.WriteLine(p);

                WriteStudent(writerWorkFile, new Student() { RBN = 231846, Name = "Ivan", AvgMark = 9.75 });

                writerWorkFile.Flush();    // Cкидання буферу
            }    // sOut.Dispose();    --> Close file
        }

        public static void WriteStudent(StreamWriter w, Student s)
        {
            w.WriteLine($"{s.RBN} {s.Name} {s.AvgMark}");
        }

        public static Student ReadStudent(StreamReader r)
        {
            string sIn = r.ReadLine();

            string[] fields = sIn.Split();

            Student s = new Student()
            { 
                RBN = int.Parse(fields[0]),
                Name = fields[1],
                AvgMark = double.Parse(fields[2])
            };

            return s;
        }
    }
}
