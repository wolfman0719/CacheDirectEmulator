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

Property Value As %String(MAXLEN = 32000, TRUNCATE = 1);

Property PLIST As %String(MAXLEN = 32000, TRUNCATE = 1);

Property PDELIM As %String(TRUNCATE = 1) [ InitialExpression = {$C(13,10)} ];

Property ExecFlag As %Integer;

Property iErrorName As %String [ Private ];

Property iError As %Integer [ InitialExpression = 0, Private ];

Property ErrorName As %String [ Calculated, ReadOnly ];

Property Error As %Integer [ Calculated, ReadOnly ];

Method ErrorNameGet() As %String
{
	quit ..iErrorName
}

Method ErrorGet() As %Integer
{
	quit ..iError
}

Method getPLIST(offset As %Integer) As %String
{
	quit $piece(..PLIST,..PDELIM,offset)
}

Method setPLIST(offset As %Integer, value As %String)
{
	set $piece(..PLIST,..PDELIM,offset) = value
}

Method Execute(Command As %String) As %Boolean [ PublicList = (P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, PLIST, PDELIM, Value, Code) ]
{
 try {
	  if ($extract(Command,1) = "=") {		   
         set ecommand="Set %result="_$extract(Command,2,*)
	  }
      else {
	         set ecommand = Command
      }
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
      set tPLIST=..PLIST
      set PDELIM = ..PDELIM
      for i = 1:1:$length(tPLIST,PDELIM) {
	      set PLIST(i) = $piece(tPLIST,PDELIM,i)
      }
      set ..iErrorName = ""
      set ..iError = 0
 
      xecute ecommand
      
      if $data(%result) set ..Value=%result
      set ..P0 = P0
      set ..P1 = P1
      set ..P2 = P2
      set ..P3 = P3
      set ..P4 = P4
      set ..P5 = P5
      set ..P6 = P6
      set ..P7 = P7
      set ..P8 = P8
      set ..P9 = P9
      set tPLast = +$Order(PLIST(""),-1)
      set tPLIST = $get(PLIST(1))
      for i = 2:1:tPLast {
	      set tPLIST = tPLIST_PDELIM_$get(PLIST(i))
      }
      set ..PLIST = tPLIST
      set PLIST = $length(..PLIST,PDELIM)
 }
 catch error {
	 set ..iErrorName = error.Name
	 set ..iError = 1
 }
 if ..iError = 1 {
	 quit 0
 }
 quit 1
}

ClassMethod Version() As %String
{
	quit "V1.0.0"
}

}
