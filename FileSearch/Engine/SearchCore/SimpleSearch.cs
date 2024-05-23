using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearch.Engine.SearchCore
{
    internal class SimpleSearch : ISearch
    {
        string dirName;
        string fileName;

        public SimpleSearch(string DirName, string FileName)
        {
            dirName = DirName;
            fileName = FileName;
        }

        public List<string> StartSearch()
        {
            List<string> searchingFiles = new List<string>();

            return searchingFiles;
        }


        public void SearchCore()
        {
            while (true)
            {

            }
        }
    }
}
