Class CacheDirect.UnitTests Extends %UnitTest.TestCase
{

/// セットアップ
/// 　テストを実行するネームスペース上に以下のグローバルを作成する
/// Setup
///   Make the global on the namespace to run the unit test as follows:
/// Set ^UnitTestRoot = "c:\UnitTests"
///  上で設定したディレクトリは存在している必要がある。
///  そのディレクトリの下にCacheDirectというサブディレクトリを作成
///  そのサブディレクトリにこのクラスをxml形式またはudl形式でエクスポート
///  The directory set above needs to exist.
///  Create a subdirectory called CacheDirect under that directory
///  Export this class in xml or udl format to its subdirectory
///  
/// do ##class(%UnitTest.Manager).DebugLoadTestSuite("CacheDirect")
/// do ##class(%UnitTest.Manager).DebugRunTestCase("CacheDirect")
Method TestCacheDirect() [ PublicList = (P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, PLIST, PDELIM, Value) ]
{
  set cd = ##class(CacheDirect.Emulator).%New()
	
  set cd.P0 = "ABC;DEF;FGH"
  set cd.P1 = ";"
  do cd.Execute("=$piece(P0,P1,2)")
  Do $$$AssertEquals(cd.P0,P0,"Property P0 is correct")
  Do $$$AssertEquals(cd.P1,P1,"Property P1 is correct")
  Do $$$AssertEquals(cd.VALUE,"DEF","Property VALUE is correct")

  set cd.P2 = "あいうえお;かきくけこ;さしすせそ"
  do cd.Execute("=$piece(P2,P1,3)")
  Do $$$AssertEquals(cd.P2,P2,"Property P2 is correct")
  Do $$$AssertEquals(cd.VALUE,"さしすせそ","Property VALUE is correct")

  set cd.P3 = "ABC;DEF;FGH"
  do cd.Execute("=$piece(P3,P1,2)")
  Do $$$AssertEquals(cd.P3,P3,"Property P3 is correct")

  set cd.P4 = "ABC;DEF;FGH"
  do cd.Execute("=$piece(P4,P1,2)")
  Do $$$AssertEquals(cd.P4,P4,"Property P4 is correct")

  set cd.P5 = "ABC;DEF;FGH"
  do cd.Execute("=$piece(P5,P1,2)")
  Do $$$AssertEquals(cd.P5,P5,"Property P5 is correct")

  set cd.P6 = "ABC;DEF;FGH"
  do cd.Execute("=$piece(P6,P1,2)")
  Do $$$AssertEquals(cd.P6,P6,"Property P6 is correct")

  set cd.P7 = "ABC;DEF;FGH"
  do cd.Execute("=$piece(P7,P1,2)")
  Do $$$AssertEquals(cd.P7,P7,"Property P7 is correct")

  set cd.P8 = "ABC;DEF;FGH"
  do cd.Execute("=$piece(P8,P1,2)")
  Do $$$AssertEquals(cd.P8,P8,"Property P8 is correct")

  set cd.P9 = "ABC;DEF;FGH"
  do cd.Execute("=$piece(P9,P1,2)")
  Do $$$AssertEquals(cd.P9,P9,"Property P9 is correct")

  set cd.PDELIM = ","
  set cd.PLIST = ""
  do cd.Execute("set PLIST(1) = ""ABC"",PLIST(2) = ""ZZZ"",PLIST(3) = ""あいうえお""")
  Do $$$AssertEquals(cd.PLIST,"ABC,ZZZ,あいうえお","Property PLIST is correct")
  Do $$$AssertEquals(PLIST,3,"variable PLIST is correct")
	
  set cd.PDELIM = "^"
  set cd.PLIST = ""
  do cd.Execute("set PLIST="""",PLIST(""first"") = ""ABC"",PLIST(""second"") = ""ZZZ"",PLIST(""third"") = ""あいうえお""")
  Do $$$AssertEquals(cd.PLIST,"ABC^ZZZ^あいうえお","Property PLIST is correct")
  Do $$$AssertEquals(PLIST,3,"variable PLIST is correct")

  set cd.PDELIM = "$"
  set cd.PLIST = ""
  do cd.Execute("set PLIST=2,PLIST(1) = ""ABC"",PLIST(2) = ""ZZZ"",PLIST(3) = ""あいうえお""")
  Do $$$AssertEquals(cd.PLIST,"ABC$ZZZ","Property PLIST is correct")
  Do $$$AssertEquals(PLIST,2,"variable PLIST is correct")

  set cd.PDELIM = "^"
  set cd.PLIST = ""
  set PLIST = 5
  set PLIST(1) = "ABC"
  set PLIST(3) = "ZZZ"
  set PLIST(5) = "あいうえお"
  do cd.Execute("set PLIST=5,PLIST(1) = ""ABC"",PLIST(3) = ""ZZZ"",PLIST(5) = ""あいうえお""")
  Do $$$AssertEquals(cd.PLIST,"ABC^^ZZZ^^あいうえお","Property PLIST is correct")
  Do $$$AssertEquals(PLIST,5,"variable PLIST is correct")

  do cd.Execute("$extract($ZV,1,4)")
  Do $$$AssertEquals(cd.VALUE,"IRIS","Property VALUE is correct")

  do cd.Execute("=$extract($ZV,1,4)")
  Do $$$AssertEquals(cd.VALUE,"IRIS","Property VALUE is correct")
  kill cd
}

}
