using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;



namespace UABEC
{
    internal class Program
    {


        static void Main(string[] args)
        {

            ArgCont ag = new ArgCont();




            if (args.Length == 0)
            {
                //show help. end.

                return;
            }


            ag.assetFilePath = args[0];
            ag.assetFilePathOrigin = args[0];
            if (args.Length <= 2)
            {

                ag.option = "show";
                //show assetfile            
            }
            else if (args.Length > 2)
            {
                ag.option = args[1];
                ag.itemName = args[2];
                if (args[1] == "-export")
                {

                }
                if (args[1] == "-import")
                {
                    ag.importFilePath = args[3];
                }


            }

            Main main = new Main(ag);

            return;

        }

    }



    public class ArgCont // arguments container
    {
        public string assetFilePath { get; set; }
        public string assetFilePathOrigin { get; set; }
        public string option { get; set; }
        public string importFilePath { get; set; }
        public string bundleName { get; private set; }
        public string assetName { get; private set; }
        public string fileId { get; private set; }
        public string pathId { get; private set; }
        private string _itemName;

        public string itemName
        {

            set
            {
                _itemName = value;
                string[] t = value.Split(new char[] { '/' });
                string str = "";
                if (t.Length == 2) { bundleName = t[0]; str = t[1]; }
                else { str = t[0]; }
                string[] ss = str.Split(new char[] { ':' });
                assetName = ss[0];
                fileId = ss[1];
                pathId = ss[2];

            }
        }

    }

}
