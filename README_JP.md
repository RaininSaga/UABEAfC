[English](https://github.com/RaininSaga/UABEAfC/blob/master/README.md)

# UABEA for Command  (Early Access) 

UnityのAssetFileやAssetBundleに対して、コマンドライン上で簡易的なimport/exportを行います。UABEAfCは [nesrak1/UABEA](https://github.com/nesrak1/UABEA)を基に作成されました。

他アプリから呼び出したり、batファイルでバッチ処理させたりする用途を想定しています。
それ以外の用途ではUABEAを利用するほうが便利だと思います。

UABEAのコードを基にしているため、UABEAでできないことはUABEAfCでもできません。（コマンドライン利用が唯一の利点）
RawData、Texture2D、textAssetのimport/exportに対応しています。Dumpの取り扱いはできません。

## Command
  ```UABEfC [Asset]```  
    指定したAssetの中身をリストを表示します。
    ここで各ファイルのItemNameが表示されるので、import/exoprtする際にこのItemNameを使ってファイル情報の指定をします。

  ```UABEfC [Asset] -export [ItemName]```  
    Asset内のItemNameと一致するファイルをexportします。

  ```UABEfC [Asset] -import [ItemName] [ImportFile]```  
    ImportFileをItemNameとしてAssetにexportします。

## Example:
  ```UABEfC "C:\Sample\resources.assets" -export "SampleData:0:11"```  
  ```UABEfC "C:\Sample\resources.assets" -import "SampleTexture:0:27" "C:\Sample\texture.png"```  
  ```UABEfC "C:\Sample\AssetBundle" -import "BundleA/objectsxml:0:144" "C:\Sample\test.xml"```  
