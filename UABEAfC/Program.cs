using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;



namespace UABEAfC {
    internal class Program {
        static readonly string ver = "0.21";

        static void Main(string[] args) {

            ArgCont ag = new ArgCont();




            if (args.Length == 0) {
                //show help

                Console.WriteLine("====  UABEA for Command  v" + ver + " (Early Access)  ====");
                Console.WriteLine("Copyright (c) 2022 Rainin");
                Console.WriteLine("Copyright (c) 2021 nesrak1");
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
                Console.WriteLine("  UABEfC \"C:\\Sample\\AssetBundle\" -import \"CAB-123456789/objectsxml:0:144\" \"C:\\Sample\\test.xml\" ");

                return;
            }

            bool fileExist = true;
            ag.AssetFilePath = args[0];
            ag.AssetFilePathOrigin = args[0];
            fileExist = CheckExistFile(ag.AssetFilePath);

            if (args.Length <= 2) {

                ag.Option = "-show";
                //show assetfile            
            } else if (args.Length > 2) {
                ag.Option = args[1];
                ag.ItemName = args[2];
                if (args[1] == "-export") {
                    //
                }
                if (args[1] == "-import") {
                    ag.ImportFilePath = args[3];
                    fileExist = CheckExistFile(ag.ImportFilePath);

                }

                if (ag.FileId == null) {
                    Console.WriteLine(" No FileId.");
                    fileExist = false;
                }

                if (ag.PathId == null) {
                    Console.WriteLine(" No PathId.");
                    fileExist = false;
                }




            }


            if (fileExist == false) { return; }

            Main main = new Main(ag);

            return;

        }

        static private bool CheckExistFile(string path) {
            if (File.Exists(path)) { return true; }
            Console.WriteLine("[" + path + "] is not found.");
            return false;
        }

    }



    public class ArgCont { // arguments container

        public string AssetFilePath { get; set; }
        public string AssetFilePathOrigin { get; set; }
        public string Option { get; set; }
        public string ImportFilePath { get; set; }
        public string BundleName { get; private set; }
        public string AssetName { get; private set; }
        public string FileId { get; private set; }
        public string PathId { get; private set; }
        private string _itemName;

        public string ItemName {

            set {
                _itemName = value;
                string[] t = value.Split(new char[] { '/' });
                string str = "";
                if (t.Length == 2) { BundleName = t[0]; str = t[1]; } else { str = t[0]; }
                string[] ss = str.Split(new char[] { ':' });
                try {
                    AssetName = ss[0];
                    FileId = ss[1];
                    PathId = ss[2];
                }catch (Exception) {
                    Console.WriteLine("Error: Invalid ItemName.");
                }

            }
        }

    }

}
