﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;



namespace UABEC {
    internal class Program {
        static string ver = "0.10";

        static void Main(string[] args) {

            ArgCont ag = new ArgCont();
            string str = "";




            if (args.Length == 0) {
                //show help

                Console.WriteLine("====  UABEA for Command  v"+ver+ " (Early Access)  ====");
                Console.WriteLine("");
                Console.WriteLine("Command:");
                Console.WriteLine("  UABEfC [Asset]");
                Console.WriteLine("    Show a list of Asset file or bundle contents. ");
                Console.WriteLine("    The process shows the ItemName of each file. It's required for import/exoprt argument.");
                Console.WriteLine("");
                Console.WriteLine("  UABEfC [Asset] -export [ItemName]");
                Console.WriteLine("    Export the file that matches ItemName in Asset.");
                Console.WriteLine("");
                Console.WriteLine("  UABEfC [Asset] -import [ItemName] [ImportFile]");
                Console.WriteLine("    Import 'ImportFile' as ItemName into Asset.");
                Console.WriteLine("");
                Console.WriteLine("Example:");
                Console.WriteLine("  UABEfC \"C:\\Sample\\resources.assets\" -export \"SampleData:0:11\"");
                Console.WriteLine("  UABEfC \"C:\\Sample\\resources.assets\" -import \"SampleTexture:0:27\" \"C:\\Sample\\texture.png\" ");
                Console.WriteLine("  UABEfC \"C:\\Sample\\AssetBundle\" -import \"BundleA/objectsxml:0:144\" \"C:\\Sample\\test.xml\" ");

                return;
            }

            bool fileExist = true;
            ag.assetFilePath = args[0];
            ag.assetFilePathOrigin = args[0];
            fileExist = CheckExistFile(ag.assetFilePath);

            if (args.Length <= 2) {

                ag.option = "show";
                //show assetfile            
            } else if (args.Length > 2) {
                ag.option = args[1];
                ag.itemName = args[2];
                if (args[1] == "-export") {
                    //
                }
                if (args[1] == "-import") {
                    ag.importFilePath = args[3];
                    fileExist=CheckExistFile(ag.importFilePath);

                }
            }



            if (fileExist == false) { return; }

                Main main = new Main(ag);

            return;

        }

        static private bool CheckExistFile(string path) {
            if (File.Exists(path)) { return true; }
            Console.WriteLine("["+path+"] is not found.");
            return false;
        }

    }



    public class ArgCont{ // arguments container
    
        public string assetFilePath { get; set; }
        public string assetFilePathOrigin { get; set; }
        public string option { get; set; }
        public string importFilePath { get; set; }
        public string bundleName { get; private set; }
        public string assetName { get; private set; }
        public string fileId { get; private set; }
        public string pathId { get; private set; }
        private string _itemName;

        public string itemName {

            set {
                _itemName = value;
                string[] t = value.Split(new char[] { '/' });
                string str = "";
                if (t.Length == 2) { bundleName = t[0]; str = t[1]; } else { str = t[0]; }
                string[] ss = str.Split(new char[] { ':' });
                assetName = ss[0];
                fileId = ss[1];
                pathId = ss[2];

            }
        }

    }

}
