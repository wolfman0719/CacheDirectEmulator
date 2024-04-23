# Visual Studio Code + C# Dev kitプラグインを使用してビルド

- Visual Studio Code にC# Dev Kitをインストール
- cd7.csprojの内容を環境に合わせる

IRISの.netライブラリーの場所を環境に合わせる
（テンプレートはMacOSの場合のディレクトリ構造を想定しています）

```
 <ItemGroup>
    <Reference Include="InterSystems.Data.Utils">
      <HintPath>..\..\..\..\..\Applications\iris\dev\dotnet\bin\net7.0\InterSystems.Data.Utils.dll</HintPath>
    </Reference>
    <Reference Include="InterSystems.Data.IRISClient">
      <HintPath>..\..\..\..\..\Applications\iris\dev\dotnet\bin\net7.0\InterSystems.Data.IRISClient.dll</HintPath>
    </Reference>
  </ItemGroup>
```

