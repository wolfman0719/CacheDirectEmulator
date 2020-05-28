# .Net class mimics Cache Direct(VisM.OCX) interface for IRIS

VisM.OCXのインタフェースを.Net上で動作するようにIRISの.Net Native APIを使用して実装


## 使用方法

###IRISサーバー

使用バージョンは、IRIS for Windows (x86-64) 2020.1 (Build 215U) Mon Mar 30 2020 20:14:33 EDTです。
2019.3ではヌルポインターエラーでクラッシュします。

### IRISサーバー側のクラス

CacheDirect.Emulator.clsを適当なネームスペースにインポート（サンプルはUSERネームスペースで動かすことを前提にしています）

### C#のプロジェクトファイルをVisual Studioで読み込む

C_SharpConsoleApplication.csprojファイルをVisual Studioで読み込ます。

使用したバージョンは、以下になります。

Microsoft Visual Studio Community 2019
Version 16.6.0

### 参照設定

Visual Studioのプロジェクト設定から参照の追加を選び、以下のファイルを追加してください。

<インストールディスク>\InterSystems\IRIS\dev\dotnet\bin\v4.0.30319

InterSystems.Data.IRISClient.dll
InterSystems.Data.Gateway64.exe

### ビルド

Visual StudioのビルドメニューからC_SharpConsoleApplicationのビルドをクリック
出力ウィンドウにエラーがないことを確認してください。
エラーが出る場合は、参照設定がうまくいっていない可能性が高いです。

### 実行

Visual Studioのデバッグメニューからデバッグなしで実行をクリックします。


## 制限事項

Cache Directの機能の中で、Visual Basicの固有の機能は、サポートしていません。

コールバック機能、MessageBoxなど

