using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace DooPackage.FileReaderWriter
{
    public class FileReaderWriter : MonoBehaviour
    {
        public void Write(List<string> target, string filepath)
        {
            using (StreamWriter sw = new StreamWriter(filepath))
            {
                target.ForEach(line => sw.WriteLine(line));
            }
        }

        public List<string> Read(string filepath)
        {
            using(StreamReader sr = new StreamReader(filepath))
            {
                List<string> lines = new List<string>();

                while (sr.Peek() >= 0) lines.Add(sr.ReadLine());

                return lines;
            }
        }
    }
}