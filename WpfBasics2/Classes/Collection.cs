using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSharp.Classes
{
    class Collection //general-use methods for extraction used throughout project
    {
        //Gets filepath using textfile name
        public string getFilePath(string txtfilename)
        {
            //string path = Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "");
          
            string defaultFolder = System.AppDomain.CurrentDomain.BaseDirectory;
            string navigateFolder = "..\\..\\Resources\\Textfiles\\" + txtfilename + ".txt";
            string filePath = Path.Combine(defaultFolder, navigateFolder);
            return filePath;
        }
        //Get all info in a list using textfile name
        public List<string> getTextFileList(string txtfilename)
        {
            List<string> lines = File.ReadAllLines(getFilePath(txtfilename)).ToList();
            return lines;
        }

        //Get a line using line number and textfile name
        public string getTextFileLine(string txtfilename, int zerobasedlineNo)
        {
            string line = File.ReadLines(getFilePath(txtfilename)).ElementAt(zerobasedlineNo);
            return line;
        }

        //Get a line element using line number and element number (for string array containing line elements)
        public string getTextFileElement(string txtfilename, int zerobasedlineNo, int elementNo)
        {
            string line = File.ReadLines(getFilePath(txtfilename)).ElementAt(zerobasedlineNo);
            string[] lineElements = line.Split('*');
            string Element = lineElements[elementNo];
            return Element;
        }
    }
}
