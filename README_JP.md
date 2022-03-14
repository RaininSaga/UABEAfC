[English](https://github.com/RaininSaga/UABEAfC/blob/master/README.md)

# UABEA for Command  (Early Access) 

UnityのAssetFileやAssetBundleに対して、コマンドライン上で簡易的なimport/exportを行います。   
UABEAfCは [nesrak1/UABEA](https://github.com/nesrak1/UABEA)を基に作成されました。

他アプリから呼び出したり、batファイルでバッチ処理させたりする用途を想定しています。  
それ以外の用途ではUABEAを利用するほうが幸せになれると思います。

UABEAのコードを基にしているため、基本的にUABEAでできないことはUABEAfCでもできません。  
RawData、Texture2D、textAssetのimport/exportに対応しています。  
LZ4、LZMAの圧縮形式に対応しており、指定したAssetBundleが圧縮されていた場合は自動的に展開または圧縮（repack）を行います。
  
  
本ソフトウェアはMITライセンスのもとで複製・配布・改変ができます。  
ようは、お好みのプロジェクトにUABEAfCをぶち込んで使ったりしてください。Licenseファイルは消さないでね。

## Command
  ```UABEfC [Asset]```  
    指定したAssetの中身をリストを表示します。  
    ここで各ファイルのItemNameが表示されます。import/exoprtする際にこのItemNameを使ってファイル情報の指定をします。

  ```UABEfC [Asset] -export [ItemName]```   
    Asset内のItemNameと一致するファイルをexportします。

  ```UABEfC [Asset] -import [ItemName] [ImportFile]```  
    ImportFileをItemNameとしてAssetにexportします。
　　

## Example:
  ```UABEfC "C:\Sample\resources.assets" -export "SampleData:0:11"```  
  ```UABEfC "C:\Sample\resources.assets" -import "SampleTexture:0:27" "C:\Sample\texture.png"```  
  ```UABEfC "C:\Sample\AssetBundle" -import "CAB-123456789/objectsxml:0:144" "C:\Sample\test.xml"```  
     
  ```[ItemName]```は"BundleArchiveName/AssetName:FileId:PathId"という要素で構成されています。バンドルでない場合は"/"は省略できます。
