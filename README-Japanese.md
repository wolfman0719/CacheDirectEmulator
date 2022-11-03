# .Net class mimics Cache Direct(VisM.OCX) interface for IRIS

VisM.OCXのインタフェースを.Net上で動作するようにIRISの.Net Native APIを使用して実装


## 使用方法

### IRISサーバー

使用バージョンは、IRIS for Windows (x86-64) 2022.2 (Build 368U) Fri Oct 21 2022 16:43:20 EDTです。

### IRISサーバー側のクラス

CacheDirect.Emulator.clsを適当なネームスペースにインポート（サンプルはUSERネームスペースで動かすことを前提にしています）

### C#のプロジェクトファイルをVisual Studioで読み込む

Visual Studio 2019でConsole C# Applicationプロジェクトを新規作成します。

使用したバージョンは、以下になります。

Microsoft Visual Studio Community 2019

Version 16.6.0

以下のファイルをそのプロジェクトに追加します。

- cacheDirectWapper.cs
- ConsoleApp.cs

Microsoft Visual Studio Community 2022を使用する場合には、以下のファイルを追加します。

- net60/ConsoleApp/cacheDirectWapper.cs
- net60/ConsoleApp/ConsoleApp.cs

### 参照設定

Visual Studioのプロジェクト設定から参照の追加を選び、以下のファイルを追加してください。

c:\InterSystems\IRIS\dev\dotnet\bin\v4.6.2

InterSystems.Data.IRISClient.dll

c:\InterSystems\IRIS\dev\dotnet\bin\net6.0

InterSystems.Data.IRISClient.dll

### ビルド

Visual Studioのビルドメニューからビルドをクリック

出力ウィンドウにエラーがないことを確認してください。

エラーが出る場合は、参照設定がうまくいっていない可能性が高いです。

### 実行

Visual Studioのデバッグメニューからデバッグの開始をクリックします。

このアプリケーションを終了するには、任意のキーを押す必要があります。

アプリケーションの出力結果は、Visual Studioの出力ウィンドウに表示されます。

### VB.Net用サンプル

Module1.vbは、このエミュレータを使用するVB.Netサンプルコードです。

このサンプルを動かすには、

1. C# class libraryプロジェクトを作成します。

2. cacheDirectWapper.csをそのプロジェクトに追加します。

3. InterSystems.Data.IRISClient.dllの参照を追加します。

4. プロジェクトをビルドします。

5. VB.Net コンソールアプリケーションプロジェクトを作成します。

6. Module1.vbをプロジェクトに追加します。

7. InterSystems.Data.IRISClient.dllの参照を追加します。

8. 作成したクラスライブラリーdllの参照をプロジェクトに追加します。

## 制限事項

### サポートしていないプロパティ

- ConnectionState
- ConTag
- ElapsedTime
- ErrorTrap
- KeepAliveInterval
- KeepAliveTimeOut
- LogMask
- MServer
- MsgText
- PromptInterval
- Server
- Tag
- TimeOut

### サポートしていないメソッド

- DeleteConnection
- SetMServer
- SetServer

### サポートしていないイベント

- Shutdown Events

### サポートされない追加機能

- ErrorTrapping
- The Keep Alive Feature
- Server Read Loop and Quick Check
- Read and Write Hooks
- Other Server Side Hooks
- User Cancel Option

### Visual Basic依存機能

Cache Directの機能の中で、Visual Basicの固有の機能は、サポートしていません。

- コールバック機能
- MessageBox
- DoEventsなど

## コンストラクター

2個のコンストラクターが用意されています。

cacheDirectWapper(string constr)

cacheDirectWapper(IRISConnection irisconn)

## 複数ネームスペースでの利用

アプリケーション内でネームスペースを切り替える必要がある場合には、CacheDirect.Emulatorクラスを各ネームスペースにインポートするか、パッケージマッピングを行う必要があります。
