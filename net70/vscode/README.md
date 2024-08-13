# Visual Studio Code + C# Dev kitプラグインを使用してビルド

- .net 7.0 sdkをダウンロードしてインストール
- Visual Studio Code にC# Dev Kitをインストール
- cd7.csprojの内容を環境に合わせる

IRISの.netライブラリーの場所を環境に合わせる
（テンプレートはMacOSの場合のディレクトリ構造を想定しています）

```
 <ItemGroup>
    <Reference Include="InterSystems.Data.Utils">
      <HintPath>\Applications\iris\dev\dotnet\bin\net7.0\InterSystems.Data.Utils.dll</HintPath>
    </Reference>
    <Reference Include="InterSystems.Data.IRISClient">
      <HintPath>\Applications\iris\dev\dotnet\bin\net7.0\InterSystems.Data.IRISClient.dll</HintPath>
    </Reference>
  </ItemGroup>
```

# Emulator.clsをUserネームスペースにロード

```
>d $system.OBJ.Load("/temp/Emulator.cls","ck")
```

# Visual Studio Codeを起動し、プロジェクトを開く

- VS Codeのファイルメニューよりフォルダーを開くを選択
- cd7.csprojが存在するディレクトリを開く
- ConsoleApp.csを開く
- 実行メニューからデバッグの開始を選択
- デバッグコンソールに実行結果が表示されるのを確認
