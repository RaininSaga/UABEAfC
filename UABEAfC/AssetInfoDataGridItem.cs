using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UABEAvalonia;

namespace UABEAfC {
    public class AssetInfoDataGridItem : INotifyPropertyChanged {
        public string Name { get; set; }
        public string Container { get; set; }
        public string Type { get; set; }
        public uint TypeID { get; set; }
        public int FileID { get; set; }
        public long PathID { get; set; }
        public int Size { get; set; }
        public string Modified { get; set; }

        public AssetContainer assetContainer;

        public event PropertyChangedEventHandler? PropertyChanged;

        //ultimate lazy
        public void Update(string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
