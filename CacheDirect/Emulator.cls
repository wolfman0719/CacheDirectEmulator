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

Method Execute(Command As %String) As %Boolean [ PublicList = (P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, PLIST, PDELIM, VALUE, Code) ]
{
 try {
	  if ($extract(Command,1) = "=") {		   
         set ecommand="Set VALUE="_$extract(Command,2,*)
	  }
      elseif ($extract(Command,1) = "$") {
         set ecommand="Set VALUE="_Command
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
      set VALUE =..VALUE
      kill PLIST
      set tPLIST=..PLIST
      set PDELIM = ..PDELIM
      if tPLIST'="" {
        for i = 1:1:$length(tPLIST,PDELIM) {
	      set PLIST(i) = $piece(tPLIST,PDELIM,i)
        }
      }
      set ..iErrorName = ""
      set ..iError = 0
 
      xecute ecommand
      
	  do ..PropertyRestore()
 }
 catch error {
	 do ..PropertyRestore()
	 set ..iErrorName = error.Name
	 set ..iError = 1
 }
 if ..iError = 1 {
	 quit '$$$OK
 }
 quit $$$OK
}

Method PropertyRestore() As %Status [ PublicList = (P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, PLIST, PDELIM, VALUE, Code) ]
{
      if $data(VALUE) set ..VALUE=VALUE
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
      kill plist
      set node = "",plistcount = 0
      for {
	      set node = $order(PLIST(node))
	      if node = "" quit
	      set plistcount = plistcount + 1
	      set plist(plistcount) = PLIST(node)
      }
      if +$get(PLIST) = 0 set PLIST = plistcount
      for i = 1:1:PLIST {
	      set PLISTS = $get(PLISTS)_PDELIM_$get(plist(i))
      }
      set ..PLIST = $extract($get(PLISTS),2,*)
}

ClassMethod Version() As %String
{
	quit "V1.0.4"
}

}
