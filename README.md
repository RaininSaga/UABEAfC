# UABEA for Command  (Early Access) 

Simple import/export on the command line to Unity's AssetFile and AssetBundle.
UABEAfC was created based on [nesrak1/UABEA](https://github.com/nesrak1/UABEA).

It is intended for use when calling from other applications or batch processing with .bat files.
For other uses, it would be more convenient to use UABEA.  
Since it is based on UABEA code, what UABEA cannot do, UABEAfC cannot do either. (Command line use is the only advantage)  
RawData, Texture2D, and TextAsset import/export are supported. Dump is not supported.

## Command
  ```UABEfC [Asset]```  
    Show a list of Asset file or bundle contents.
    The process shows the ItemName of each file. It's required for import/exoprt argument.

  ```UABEfC [Asset] -export [ItemName]```  
    Export the file that matches ItemName in Asset.

  ```UABEfC [Asset] -import [ItemName] [ImportFile]```  
    Import 'ImportFile' as ItemName into Asset.

## Example:
  ```UABEfC "C:\Sample\resources.assets" -export "SampleData:0:11"```  
  ```UABEfC "C:\Sample\resources.assets" -import "SampleTexture:0:27" "C:\Sample\texture.png"```  
  ```UABEfC "C:\Sample\AssetBundle" -import "BundleA/objectsxml:0:144" "C:\Sample\test.xml"```  
