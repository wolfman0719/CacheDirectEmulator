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

Property Error As %Integer [ Calculated, ReadOnly ];

Property Interval As %Integer;

Property ErrorStatus As %Status [ Private ];

Method ErrorNameGet() As %String
{
	quit ..iErrorName
}

Method ErrorGet() As %Integer
{
	quit ..iError
}

Method PropsDataGet() As %List
{
	quit $listbuild(..P0,..P1,..P2,..P3,..P4,..P5,..P6,..P7,..P8,..P9,..PLIST,..PDELIM,..VALUE,..Error,..ErrorName)
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
   set ..iError = 0
 
   //+++ 実行するコードの中で、出力先を指定せずにWriteを発行した場合にエラーとなるのを防ぐ
   set curdev=$IO   // 現 Device を保持
   //----- NULL Device にスイッチ (Write用) -----
   set nulldev=##class(%Device).GetNullDevice()
   open nulldev
   use nulldev
   do ##class(%Device).ChangePrincipal() // SWITCH
   //--- Write対応
   xecute ecommand
   //----- 元の Device (curdev) に戻す -----
   use curdev
   do ##class(%Device).ChangePrincipal() // SWITCH
   close nulldev  // NULL Device をClose
      
   do ..PropertyRestore()
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
	quit "V2.3.1"
}

ClassMethod Test()
{
	set cd = ..%New()
	set cd.P0 = "ABC;DEF;GHI"
	set cd.P1 = ";"
	set cd.PDELIM = ";"
	set command = $listbuild("=$piece(P0,P1,2)",cd.P0,cd.P1,cd.P2,cd.P3,cd.P4,cd.P5,cd.P6,cd.P7,cd.P8,cd.P9,cd.PLIST,cd.PDELIM,$namespace)
	do cd.Execute(command)
	write "VALUE = ",cd.VALUE,!
	if cd.iError write "ErrorStatus = ",$system.Status.DisplayError(cd.ErrorStatus)
}

}
