using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;

using System.ComponentModel;
using UABEAvalonia;
using UABEAvalonia.Plugins;
using TexturePlugin;
using TextAssetPlugin;

using AssetsTools.NET;
using AssetsTools.NET.Extra;

namespace UABEAfC {
    internal class CompressBundle {


        public CompressBundle() { }


        public AssetWorkspace Workspace { set; get; }
        public AssetsManager am = new AssetsManager();//{  get => Workspace.am; }

        private BundleFileInstance bundleInst;

        private ArgCont ag;
        private AssetBundleCompressionType compOp;

        public CompressBundle(ArgCont args,string path,AssetBundleCompressionType option) {
            ag = args;
            compOp = option;

            Init(); //Load classdata.tpk to AssetManager.

            ag.AssetFilePath = path;    // presave bundle file _decmp



            try {
                Proc(ag.AssetFilePath);
            } catch (Exception ex) {
                Console.WriteLine("Error");
                Console.WriteLine(ex.ToString());

            }

        }




        private void Init() {
            //am = new AssetsManager();
            string classDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "classdata.tpk");
            if (File.Exists(classDataPath)) {
                am.LoadClassPackage(classDataPath);
            } else {
                //await MessageBoxUtil.ShowDialog(this, "Error", "Missing classdata.tpk by exe.\nPlease make sure it exists.");
                Console.WriteLine("Missing classdata.tpk by exe.\nPlease make sure it exists.");
            }
        }


        public void Proc(string filePath) {


            DetectedFileType fileType = AssetBundleDetector.DetectFileType(filePath);

            am.UnloadAllAssetsFiles(true);
            am.UnloadAllBundleFiles();


            if (fileType == DetectedFileType.BundleFile) {
                bundleInst = am.LoadBundleFile(filePath, false);
                //don't pester user to decompress if it's only the header that is compressed
                if (AssetBundleUtil.IsBundleDataCompressed(bundleInst.file)) {
                    DecompressToMemory(bundleInst); 
                } else {
                    if ((bundleInst.file.bundleHeader6.flags & 0x3F) != 0) //header is compressed (most likely)
                        bundleInst.file.UnpackInfoOnly();
                }


                if (compOp != AssetBundleCompressionType.NONE) {
                    Compress(bundleInst, ag.AssetFilePathOrigin, compOp);
                }


                am.UnloadAllAssetsFiles(true);
                am.UnloadAllBundleFiles();
                bundleInst = null;
                Workspace = null;
                am = null;
                return;
            }

        }


        private void Compress(BundleFileInstance bundleInst, string path, AssetBundleCompressionType compType) {
            using (FileStream fs = File.OpenWrite(path))
            using (AssetsFileWriter w = new AssetsFileWriter(fs)) {
                bundleInst.file.Pack(bundleInst.file.reader, w, compType);
            }
        }



        public int DecompressToMemory(BundleFileInstance bundleInst) {
            AssetBundleFile bundle = bundleInst.file;

            MemoryStream bundleStream = new MemoryStream();
            bundle.Unpack(bundle.reader, new AssetsFileWriter(bundleStream));

            int type = bundle.bundleHeader6.GetCompressionType();

            bundleStream.Position = 0;

            AssetBundleFile newBundle = new AssetBundleFile();
            newBundle.Read(new AssetsFileReader(bundleStream), false);

            bundle.reader.Close();
            bundleInst.file = newBundle;
            return type;
        }

    }
}
