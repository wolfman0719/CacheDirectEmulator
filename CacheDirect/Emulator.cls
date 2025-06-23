Class CacheDirect.Emulator Extends %RegisteredObject [ ProcedureBlock ]
{

Property P0 As %String(MAXLEN = 32000, TRUNCATE = 1);

Property P1 As %String(MAXLEN = 32000, TRUNCATE = 1);

Property P2 As %String(MAXLEN = 32000, TRUNCATE = 1);

Property P3 As %String(MAXLEN = 32000, TRUNCATE = 1);

Property P4 As %String(MAXLEN = 32000, TRUNCATE = 1);

Property P5 As %String(MAXLEN = 32000, TRUNCATE = 1);

Property P6 As %String(MAXLEN = 32000, TRUNCATE = 1);

Property P7 As %String(MAXLEN = 32000, TRUNCATE = 1);

Property P8 As %String(MAXLEN = 32000, TRUNCATE = 1);

Property P9 As %String(MAXLEN = 32000, TRUNCATE = 1);

Property Code As %String(MAXLEN = 32000, TRUNCATE = 1);

Property VALUE As %String(MAXLEN = 32000, TRUNCATE = 1);

Property PLIST As %String(MAXLEN = 32000, TRUNCATE = 1);

Property PDELIM As %String(TRUNCATE = 1) [ InitialExpression = {$C(13,10)} ];

Property PropsData As %List [ Calculated, ReadOnly ];

Property ExecFlag As %Integer;

Property iErrorName As %String [ Private ];

Property iError As %Integer [ InitialExpression = 0, Private ];

Property ErrorName As %String [ Calculated, ReadOnly ];

// 　詳細エラー情報

// Detailed Error information

Property ErrorDetail As %String [ Calculated, ReadOnly ];

Property Error As %Integer [ Calculated, ReadOnly ];

Property ErrorStatus As %Status [ Private ];

Method ErrorNameGet() As %String
{
  quit ..iErrorName
}

Method ErrorGet() As %Integer
{
  quit ..iError
}

Method ErrorDetailGet() As %Integer
{
  quit $system.Status.GetErrorText(..ErrorStatus)
}

Method PropsDataGet() As %List
{
  quit $listbuild(..P0,..P1,..P2,..P3,..P4,..P5,..P6,..P7,..P8,..P9,..PLIST,..PDELIM,..VALUE,..Error,..ErrorName,..ErrorDetail)
}

Method getPLIST(offset As %Integer) As %String
{
  quit $piece(..PLIST,..PDELIM,offset)
}

Method setPLIST(offset As %Integer, value As %String)
{
  set $piece(..PLIST,..PDELIM,offset) = value
}

Method Execute(Message As %List) As %Boolean [ PublicList = (P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, PLIST, PDELIM, VALUE, Code) ]
{
  try {
	 
    set Command = $list(Message,1)
    set ..P0 = $list(Message,2)
    set ..P1 = $list(Message,3)
    set ..P2 = $list(Message,4)
    set ..P3 = $list(Message,5)
    set ..P4 = $list(Message,6)
    set ..P5 = $list(Message,7)
    set ..P6 = $list(Message,8)
    set ..P7 = $list(Message,9)
    set ..P8 = $list(Message,10)
    set ..P9 = $list(Message,11)
    set ..PDELIM = $list(Message,13)
	 	  
    set P0=..P0
    set P1=..P1
    set P2=..P2
    set P3=..P3
    set P4=..P4
    set P5=..P5
    set P6=..P6
    set P7=..P7
    set P8=..P8
    set P9=..P9
    set PDELIM=..PDELIM
	  
    set ..PLIST = $list(Message,12)
    set namespace = $list(Message,14)
    set timeout =  +$list(Message,15)
	  
    if (namespace '= "") && (namespace '= $namespace) {
      set $namespace = namespace
    }
     
    set tPLIST=..PLIST

    if (tPLIST'="") && (tPLIST'= $char(0)) {
      for i = 1:1:$length(tPLIST,PDELIM) {
        set PLIST(i) = $piece(tPLIST,PDELIM,i)
      }
    }

    if ($extract(Command,1) = "=") {		   
      set ecommand="Set VALUE="_$extract(Command,2,*)
    }
    elseif ($extract(Command,1) = "$") {
      set ecommand="Set VALUE="_Command
    }
    else {
      set ecommand = Command
    }
      
    set ..iErrorName = ""
    set ..ErrorStatus = 1
    set ..iError = 0
 
    if timeout < 1 { 
      //  実行するコードの中で、出力先を指定せずにWriteを発行した場合にエラーとなるのを防ぐ
      //  Prevent an error from occurring when Write is issued without specifying the output destination in the code to be executed.
      set curdev=$IO   // 現 Device を保持 store the current device
      // NULL Device にスイッチ
      // Switching to NULL Device
      set nulldev=##class(%Device).GetNullDevice()
      open nulldev
      use nulldev
      do ##class(%Device).ChangePrincipal() 
      xecute ecommand
      // 元の Device (curdev) に戻す
      // Restoring the original device
      use curdev
      do ##class(%Device).ChangePrincipal() 
      close nulldev  // Closing NULL deice
      
      do ..PropertyRestore()
    }
    else {
      // タイムアウト検知用のイベント生成
      // Create an event for timeout
      set eventname="CDExecute"_$job
      do $system.Event.Create(eventname)
      // timeoutの単位は、ミリ秒なので1000で割る
      // the unit of timeout value is milisecond
      
      set timeout = timeout/1000
   
      // JOBにローカル変数を渡すためローカル変数を一時グローバルにコピーする
      // Copy local variables to temp Globals to pass the parameters to JOB
      kill ^IRISTempCDEmu($Job)
      set ^IRISTempCDEmu($Job,"P0")=$Get(P0)
      set ^IRISTempCDEmu($Job,"P1")=$Get(P1)
      set ^IRISTempCDEmu($Job,"P2")=$Get(P2)
      set ^IRISTempCDEmu($Job,"P3")=$Get(P3)
      set ^IRISTempCDEmu($Job,"P4")=$Get(P4)
      set ^IRISTempCDEmu($Job,"P5")=$Get(P5)
      set ^IRISTempCDEmu($Job,"P6")=$Get(P6)
      set ^IRISTempCDEmu($Job,"P7")=$Get(P7)
      set ^IRISTempCDEmu($Job,"P8")=$Get(P8)
      set ^IRISTempCDEmu($Job,"P9")=$Get(P9)
      set ^IRISTempCDEmu($Job,"PLIST")=$Get(PLIST)
      set ^IRISTempCDEmu($Job,"PDELIM")=$Get(PDELIM)

      // ジョブ起動を行う
      // Kickoff a job
      Job ..ExecuteJob(ecommand)
      set childpid=$ZChild

      // ジョブ起動した子ジョブがタイムアウト時間内で終了するのを待つ
      // Wait for the jobbed process to complete within the timeout period
      set ret=$system.Event.Wait(eventname,timeout)
   
     if ret=$$$OK {
       // 起動ジョブがタイムアウト以内で完了
       // The jobbed process has been completed within the timeout period
       set VALUE=$Get(^IRISTempCDEmu($Job,"VALUE"))
       set P0=$Get(^IRISTempCDEmu($Job,"P0"))
       set P1=$Get(^IRISTempCDEmu($Job,"P1"))
       set P2=$Get(^IRISTempCDEmu($Job,"P2"))
       set P3=$Get(^IRISTempCDEmu($Job,"P3"))
       set P4=$Get(^IRISTempCDEmu($Job,"P4"))
       set P5=$Get(^IRISTempCDEmu($Job,"P5"))
       set P6=$Get(^IRISTempCDEmu($Job,"P6"))
       set P7=$Get(^IRISTempCDEmu($Job,"P7"))
       set P8=$Get(^IRISTempCDEmu($Job,"P8"))
       set P9=$Get(^IRISTempCDEmu($Job,"P9"))
       set PLIST=$Get(^IRISTempCDEmu($Job,"PLIST"))
       set PDELIM=$Get(^IRISTempCDEmu($Job,"PDELIM"))
       set VALUE=$Get(^IRISTempCDEmu($Job,"VALUE"))
       set ..iError = $Get(^IRISTempCDEmu($Job,"Error"))
       set ..iErrorName = $Get(^IRISTempCDEmu($Job,"ErrorName"))
       set ..ErrorStatus = $Get(^IRISTempCDEmu($Job,"ErrorStatus"))

       do ..PropertyRestore()

     } 
     else {
       // タイムアウト発生!!
       // Timeout has come!!
       set ..iError=1
       set ..iErrorName="<TIMEOUT> "
       set ..ErrorStatus=$$$ERROR($$$GeneralError,"Request timed out")
     }

     // ^IRISTempCDEmuとイベントのクリーンアップ
     // Crean up IRISTempCDEmu and the event
     kill ^IRISTempCDEmu($Job)
     do $system.Event.Delete(eventname)
   }  
 }    
 catch error {
   do ..PropertyRestore()
   set ..iErrorName = error.Name
   set ..iError = 1
   set ..ErrorStatus = error.AsStatus()
 }
 if ..iError = 1 {
    kill P0,P1,P2,P3,P4,P5,P6,P7,P8,P9,PLIST,PDELIM,VALUE
    quit '$$$OK
 }
 
 kill P0,P1,P2,P3,P4,P5,P6,P7,P8,P9,PLIST,PDELIM,VALUE
 
 quit $$$OK
}

ClassMethod ExecuteJob(Command As %String) [ PublicList = (P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, PLIST, PDELIM, VALUE, Code) ]
{
 try {
    set parentpid=$ZParent
    set eventname="CDExecute"_parentpid
    set P0=$Get(^IRISTempCDEmu(parentpid,"P0"))
    set P1=$Get(^IRISTempCDEmu(parentpid,"P1"))
    set P2=$Get(^IRISTempCDEmu(parentpid,"P2"))
    set P3=$Get(^IRISTempCDEmu(parentpid,"P3"))
    set P4=$Get(^IRISTempCDEmu(parentpid,"P4"))
    set P5=$Get(^IRISTempCDEmu(parentpid,"P5"))
    set P6=$Get(^IRISTempCDEmu(parentpid,"P6"))
    set P7=$Get(^IRISTempCDEmu(parentpid,"P7"))
    set P8=$Get(^IRISTempCDEmu(parentpid,"P8"))
    set P9=$Get(^IRISTempCDEmu(parentpid,"P9"))
    set PLIST=$Get(^IRISTempCDEmu(parentpid,"PLIST"))
    set PDELIM=$Get(^IRISTempCDEmu(parentpid,"PDELIM"))

    xecute Command

    set ^IRISTempCDEmu(parentpid,"P0")=P0
    set ^IRISTempCDEmu(parentpid,"P1")=P1
    set ^IRISTempCDEmu(parentpid,"P2")=P2
    set ^IRISTempCDEmu(parentpid,"P3")=P3
    set ^IRISTempCDEmu(parentpid,"P4")=P4
    set ^IRISTempCDEmu(parentpid,"P5")=P5
    set ^IRISTempCDEmu(parentpid,"P6")=P6
    set ^IRISTempCDEmu(parentpid,"P7")=P7
    set ^IRISTempCDEmu(parentpid,"P8")=P8
    set ^IRISTempCDEmu(parentpid,"P9")=P9
    set ^IRISTempCDEmu(parentpid,"PLIST")=PLIST
    set ^IRISTempCDEmu(parentpid,"PDELIM")=PDELIM
    set ^IRISTempCDEmu(parentpid,"VALUE")=VALUE
    set ^IRISTempCDEmu(parentpid,"Error")=0    

  }
  catch error {
    set ^IRISTempCDEmu(parentpid,"Error")=1
    set ^IRISTempCDEmu(parentpid,"ErrorName")=error.Name
    set ^IRISTempCDEmu(parentpid,"ErrorStatus") = error.AsStatus()
  }

  do $system.Event.Signal(eventname)
}

Method PropertyRestore() As %Status [ PublicList = (P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, PLIST, PDELIM, VALUE, Code) ]
{
  if $data(VALUE) set ..VALUE=VALUE
  set ..P0 = $get(P0)
  set ..P1 = $get(P1)
  set ..P2 = $get(P2)
  set ..P3 = $get(P3)
  set ..P4 = $get(P4)
  set ..P5 = $get(P5)
  set ..P6 = $get(P6)
  set ..P7 = $get(P7)
  set ..P8 = $get(P8)
  set ..P9 = $get(P9)
  set ..PDELIM = $get(PDELIM)
  set ..PLIST = ""
  kill plist
  set node = "",plistcount = 0
  for {
    set node = $order(PLIST(node))
    if node = "" quit
    set plistcount = plistcount + 1
    set plist(plistcount) = PLIST(node)
  }
  if +$get(PLIST) = 0 {
    set PLIST = plistcount
    for i = 1:1:PLIST {
      set PLISTS = $get(PLISTS)_PDELIM_$get(plist(i))
    }
    set ..PLIST = $extract($get(PLISTS),2,*)
  }
  else {
    for i = 1:1:PLIST {
      set PLISTS = $get(PLISTS)_PDELIM_$get(PLIST(i))
    }
    set ..PLIST = $extract($get(PLISTS),2,*)
  }
}

ClassMethod GetNamespace() As %String
{
  quit $namespace
}

ClassMethod Version() As %String
{
  quit "V2.4.1"
}

ClassMethod Test() As %Status
{
  write ..Version(),!
  set cd = ..%New()
  set cd.P0 = "ABC;DEF;GHI"
  set cd.P1 = ";"
  set cd.PDELIM = ";"
  set command = $listbuild("=$piece(P0,P1,2)",cd.P0,cd.P1,cd.P2,cd.P3,cd.P4,cd.P5,cd.P6,cd.P7,cd.P8,cd.P9,cd.PLIST,cd.PDELIM,$namespace)
  do cd.Execute(command)
  write "VALUE = ",cd.VALUE,!
  if cd.iError write "ErrorStatus = ",$system.Status.DisplayError(cd.ErrorStatus)
  quit $$$OK
}

}
