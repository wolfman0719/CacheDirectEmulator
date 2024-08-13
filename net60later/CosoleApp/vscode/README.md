# Visual Studio Code + C# Dev kitプラグインを使用してビルド

- .net 8.0 sdkをダウンロードしてインストール
- Visual Studio Code にC# Dev Kitをインストール
- cd8.csprojの内容を環境に合わせる
- net60later/ConsoleAppの下のソースコードとcd8.csprojファイルを同じディレクトリに置く

IRISの.netライブラリーの場所を環境に合わせる
（テンプレートはMacOSの場合のディレクトリ構造を想定しています）

```
 <ItemGroup>
    <Reference Include="InterSystems.Data.Utils">
      <HintPath>\opt\iris\dev\dotnet\bin\net8.0\InterSystems.Data.Utils.dll</HintPath>
    </Reference>
    <Reference Include="InterSystems.Data.IRISClient">
      <HintPath>\opt\iris\dev\dotnet\bin\net8.0\InterSystems.Data.IRISClient.dll</HintPath>
    </Reference>
  </ItemGroup>
```

# Emulator.clsをUserネームスペースにロード

```
>d $system.OBJ.Load("/temp/Emulator.cls","ck")
```

# Visual Studio Codeを起動し、プロジェクトを開く

- VS Codeのファイルメニューよりフォルダーを開くを選択
- cd8.csprojが存在するディレクトリを開く
- ConsoleApp.csを開く
- 実行メニューからデバッグの開始を選択
- デバッグコンソールに実行結果が表示されるのを確認
