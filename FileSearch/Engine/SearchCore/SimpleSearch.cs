using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace FileSearch.Engine.SearchCore
{
    // сначала нужно как то инициализировать дерево и потом искать 
    //или
    //сразу как сторишь ищешь

    //как искать и сторить то ???

    // one node == one folder

    // всегда ли у бинарного дерева числа слева меньше а числа справа больше, зачем??

    class Node
    {
        public HashSet<string> Values { get; set; } // current folder`s files
        // hashset читать!!!!!!!

        public List<Node> Children { get; set; } // current folder`s folders

        //public List<Node> Children { get; set; } // current folder`s folders
        // maybe children is it list of node

        public string Key { get; set; } // directory of current folder
        
        public Node(IEnumerable<string> values, List<Node> children, string key) 
        {
            Values = new HashSet<string>(values);
            Children = children;
            Key = key;
        }
    }

    internal class SimpleSearch
    {
        public List<string> SearchInNodes(Node rootNode, string searchFile)
        {
            Queue<Node> queue = new Queue<Node>();
            var resList = new List<string>();

            queue.Enqueue(rootNode);

            while(queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                foreach (var item in currentNode.Values)
                {
                    var fileName = item.Split("\\")[^1];
                    if (fileName.ToLower().Contains(searchFile.ToLower()))
                        resList.Add(item);
                }

                foreach (var node in currentNode.Children)
                {
                    queue.Enqueue(node);
                }
            }

            return resList;
        }

        public void PrintNode(Node rootNode)
        {
            var queue = new Queue<Node>();

            queue.Enqueue(rootNode);

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                Console.WriteLine(currentNode.Key);
                foreach (var value in currentNode.Values)
                {
                    Console.WriteLine("  " + value);
                }

                foreach (var node in currentNode.Children)
                {
                    queue.Enqueue(node);
                }
            }
        }

        public Node CreateNode(string directoryOfFolder)
        {
            string[] folders = Directory.GetDirectories(directoryOfFolder);
            string[] files = Directory.GetFiles(directoryOfFolder);

            if (folders.Length == 0)
                return new Node(files, new List<Node>(), directoryOfFolder);

            var nodes = new List<Node>();

            foreach (var folder in folders)
            {
                nodes.Add(CreateNode(folder));                
            }

            return new Node(files, nodes, directoryOfFolder);
        }
    }
}
