using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2_List_Duplicating_Files
{
    class Program
    {
        static string GetNameFromPath(string dir)
        {
            string name = "";
            int index = 0;
            for (index = dir.Length - 1; index >= 0; index--)
            {
                if (dir[index] == '\\')
                {
                    break;
                }
            }

            for (int indexName = index+1; indexName < dir.Length; indexName++)
            {
                name += dir[indexName];
            }
            return name;
        }

        static bool CheckBytes(byte[] firstFileByte, byte[] secondFileByte)
        {
            if (firstFileByte.Length == secondFileByte.Length)
            {
                for (int index = 0; index < firstFileByte.Length; index++)
                {
                    if (firstFileByte[index] != secondFileByte[index])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        static void listDuplicatingFiles(string dir)
        {
            Dictionary<string, byte[]> bytesOfAllFiles = new Dictionary<string, byte[]>();
            List<string> fileNames = new List<string>();
            bool equal = false;
            
            string[] filesInDir = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);
            for (int index = 0; index < filesInDir.Length; index++)
            {
                string name = GetNameFromPath(filesInDir[index]);
                byte[] fileByteArray = File.ReadAllBytes(filesInDir[index]);

                bytesOfAllFiles.Add(name, fileByteArray);
            }

            for (int firstIndex = 0; firstIndex < bytesOfAllFiles.Count; firstIndex++)
            {
                KeyValuePair<string, byte[]> firstFileByte = bytesOfAllFiles.ElementAt(firstIndex);
                for (int secondIndex = firstIndex + 1; secondIndex < bytesOfAllFiles.Count; secondIndex++)
                {
                    KeyValuePair<string, byte[]> secondFileByte = bytesOfAllFiles.ElementAt(secondIndex);
                    if (CheckBytes(firstFileByte.Value, secondFileByte.Value))
                    {
                        equal = true;
                        if (!fileNames.Contains(secondFileByte.Key))
                        {
                            fileNames.Add(secondFileByte.Key);
                        }
                        break;
                    }
                    else
                    {
                        equal = false;
                    }
                    
                }
                if (!equal)
                {
                    if (!fileNames.Contains(firstFileByte.Key))
                    {
                        fileNames.Add(firstFileByte.Key);
                    }
                }

            }
            Console.WriteLine(string.Join(", ", fileNames));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Put directory path: ");
            string dirPath = Console.ReadLine();
            bool exists = Directory.Exists(dirPath);
            if (exists)
            {
                listDuplicatingFiles(dirPath);
            }
            else
            {
                Console.WriteLine("Directory do not exit");
            }
        }
    }
}
