# Cache Direct(VisM.OCX)インタフェースをエミュレーションするIRIS用.NETクラス

VisM.OCXのインタフェースを.Net上で動作するようにIRISの.Net Native APIを使用して実装


## 使用方法

### IRISサーバー

使用バージョンは、IRIS for Windows (x86-64) 2022.2 (Build 368U) Fri Oct 21 2022 16:43:20 EDTです。

### IRISサーバー側のクラス

CacheDirect.Emulator.clsを適当なネームスペースにインポート（サンプルはUSERネームスペースで動かすことを前提にしています）

### C#のプロジェクト作成

Visual Studio 2019でコンソールアプリ(.NET Framework)プロジェクトを新規作成します。

テストしたバージョンは、以下になります。

Microsoft Visual Studio Community 2019

Version 16.11.15

FrameworkのバージョンはV4.8を選択します。

以下のファイルをそのプロジェクトに追加します。

プロジェクト->既存の項目の追加

- cacheDirectWapper.cs
- ConsoleApp.cs

以下のファイルを削除します。

- Program.cs

Microsoft Visual Studio Community 2022を使用する場合には、

Microsoft Visual Studio Community 2022では、コンソールアプリプロジェクトを新規作成します。

C# Linux macOS Windows コンソール

テストしたバージョンは、以下になります。

Microsoft Visual Studio Community 2022

Version 17.0.1

Frameworkのバージョンは.NET 6.0(長期的なサポート)を選択します。

以下のファイルを追加します。

- net60/ConsoleApp/cacheDirectWapper.cs
- net60/ConsoleApp/ConsoleApp.cs

以下のファイルを削除します。

- Program.cs


### 参照設定

Visual Studioのプロジェクト設定から参照の追加を選び、以下のファイルを追加してください。

Visual Studio 2019の場合

```
c:\InterSystems\IRIS\dev\dotnet\bin\v4.6.2

InterSystems.Data.IRISClient.dll
```

Visual Studio 2022の場合

```
c:\InterSystems\IRIS\dev\dotnet\bin\net6.0

InterSystems.Data.IRISClient.dll
```

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
