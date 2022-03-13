Imports InterSystems.Data.IRISClient;
Imports InterSystems.Data.IRISClient.ADO;
Imports cdapp

Module Module1
    Sub Main()
	    #If AUTOCONNECT Then
        Dim cdw As cacheDirectWapper = New cacheDirectWapper("Server = localhost; Port=1972; Namespace=USER; Password = SYS; User ID = _system;") With {
        .P0 = "ABC;DEF;GHI",
        .P1 = ";",
        .PDELIM = ";"
        }
	    #Else
		Dim irisconn As IRISConnection = New IRISConnection()
		irisconn.ConnectionString = "Server = localhost; Port=1972; Namespace=USER; Password = SYS; User ID = _system;"
		irisconn.Open()
        Dim cdw As cacheDirectWapper = New cacheDirectWapper(irisconn) With {
        .P0 = "ABC;DEF;GHI",
        .P1 = ";",
        .PDELIM = ";"
        }
		#End If
		
        cdw.Execute("=$PIECE(P0,P1,2)")

        Console.WriteLine("P1 = " + cdw.P1)
        Console.WriteLine(vbCrLf)
        Console.WriteLine("VALUE = " + cdw.VALUE)
        Console.WriteLine(vbCrLf)
        Console.WriteLine("ErrorName = " + cdw.ErrorName)
        Console.WriteLine(vbCrLf)

        cdw.P0 = "あいうえお;かきくけこ;さしすせそ"
        cdw.P1 = ";"
        cdw.PDELIM = ";"
        cdw.Execute("=$PIECE(P0,P1,2)")
        Console.WriteLine("P1 = " + cdw.P1)
        Console.WriteLine(vbCrLf)
        Console.Write("VALUE = " + cdw.VALUE)
        Console.WriteLine(vbCrLf)
        Console.Write("ErrorName = " + cdw.ErrorName)
        Console.WriteLine(vbCrLf)

        cdw.Execute("set PLIST(1)= 123,PLIST(2)=456,PLIST(3)=7890")

        Console.Write("PLIST(1) = " + cdw.getPLIST(1))
        Console.WriteLine(vbCrLf)
        Console.Write("PLIST(2) = " + cdw.getPLIST(2))
        Console.WriteLine(vbCrLf)
        Console.Write("PLIST(3) = " + cdw.getPLIST(3))
        Console.WriteLine(vbCrLf)
        Console.Write("PLIST # = " + cdw.getPLISTLength().ToString())
        Console.WriteLine(vbCrLf)
        Console.Write("PLIST = " + cdw.PLIST)
        Console.WriteLine(vbCrLf)
        Console.Write("ErrorName = " + cdw.ErrorName)
        Console.WriteLine(vbCrLf)

        cdw.Code = "set %X=345 d INT^%XD set P0 = %D"
        cdw.ExecFlag = 1

        Console.Write("P0 = " + cdw.P0)
        Console.WriteLine(vbCrLf)
        Console.Write("ErrorName = " + cdw.ErrorName)
        Console.WriteLine(vbCrLf)

        cdw.Execute("set a = P00")

        Console.Write("ErrorName = " + cdw.ErrorName)
        Console.WriteLine(vbCrLf)

        'Cleanup CachedirectWapper

        cdw.end()

    End Sub

End Module
