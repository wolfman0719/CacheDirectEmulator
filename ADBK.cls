/// ADBK from DASL definition
Class User.ADBK Extends (%Persistent, %XML.Adaptor) [ Not Abstract, ClassType = persistent, Not Final, Not Hidden, Inheritance = right, Not NoContext, Not ProcedureBlock, StorageStrategy = SQLStorage, System = 0 ]
{

Query ByName(Name As %String) As %SQLQuery(CONTAINID = 1) [ SqlProc ]
{
SELECT %ID,ANAME FROM ADBK
 WHERE (ANAME %STARTSWITH :Name)
 ORDER BY %ID
}

Parameter KEYS = "AID";

Property AAGE As %Integer [ Calculated, SqlComputeCode = { If {ABTHDAY}="" s {AAGE}="" Quit
 s {AAGE}=$H-{ABTHDAY}\365
 Quit  
}, SqlComputed ];

/// Birthday
Property ABTHDAY As %Date;

/// City Name
Property ACITY As %String(TRUNCATE = 1);

/// ANAME
Property ANAME As %String(TRUNCATE = 1);

/// Phone No. Home
Property APHHOME As %String(PATTERN = ".N1""-"".N1""-"".N", TRUNCATE = 1);

/// Phone No. Other
Property APHOTH1 As %String(PATTERN = ".N1""-"".N1""-"".N", TRUNCATE = 1);

/// Phone No. Working
Property APHWORK As %String(PATTERN = ".N1""-"".N1""-"".N", TRUNCATE = 1);

/// State 
Property ASTATE As %String(TRUNCATE = 1);

/// Street Name
Property ASTREET As %String(TRUNCATE = 1);

/// Zip Code
Property AZIP As %String(PATTERN = "3N1""-""4N", TRUNCATE = 1);

Method AAGEGet() As %Integer
{
 If ..ABTHDAY="" Quit ""
 Quit $H-..ABTHDAY\365
}

Storage SQLStorage
{
<SqlIdExpression>$$next("^ADBK(""COUNT"")")</SqlIdExpression>
<SQLMap name="IndexMap">
<Global>^ADBK</Global>
<RowIdSpec name="1">
<Expression>{L4}</Expression>
<Field>AID</Field>
</RowIdSpec>
<Structure>delimited</Structure>
<Subscript name="1">
<AccessType>sub</AccessType>
<Expression>"XNAME"</Expression>
</Subscript>
<Subscript name="2">
<AccessType>sub</AccessType>
<Expression>$P({ANAME},"　",1)</Expression>
</Subscript>
<Subscript name="3">
<AccessType>sub</AccessType>
<Expression>$P({ANAME},"　",2)</Expression>
</Subscript>
<Subscript name="4">
<AccessType>sub</AccessType>
<Expression>{AID}</Expression>
</Subscript>
<Type>index</Type>
</SQLMap>
<SQLMap name="MasterMap">
<Data name="ABTHDAY">
<Delimiter>";"</Delimiter>
<Node>"DEMO"</Node>
<Piece>6</Piece>
</Data>
<Data name="ACITY">
<Delimiter>";"</Delimiter>
<Node>"DATA"</Node>
<Piece>3</Piece>
</Data>
<Data name="ANAME">
<Delimiter>";"</Delimiter>
<Node>"DEMO"</Node>
<Piece>1</Piece>
</Data>
<Data name="APHHOME">
<Delimiter>";"</Delimiter>
<Node>"PHONE"</Node>
<Piece>1</Piece>
</Data>
<Data name="APHOTH1">
<Delimiter>";"</Delimiter>
<Node>"PHONE"</Node>
<Piece>3</Piece>
</Data>
<Data name="APHWORK">
<Delimiter>";"</Delimiter>
<Node>"PHONE"</Node>
<Piece>2</Piece>
</Data>
<Data name="ASTATE">
<Delimiter>";"</Delimiter>
<Node>"DEMO"</Node>
<Piece>3</Piece>
</Data>
<Data name="ASTREET">
<Delimiter>";"</Delimiter>
<Node>"DEMO"</Node>
<Piece>2</Piece>
</Data>
<Data name="AZIP">
<Delimiter>";"</Delimiter>
<Node>"DEMO"</Node>
<Piece>5</Piece>
</Data>
<Global>^ADBK</Global>
<RowIdSpec name="1">
<Expression>{L2}</Expression>
<Field>AID</Field>
</RowIdSpec>
<Structure>delimited</Structure>
<Subscript name="1">
<AccessType>sub</AccessType>
<Expression>"DATA"</Expression>
</Subscript>
<Subscript name="2">
<AccessType>sub</AccessType>
<Expression>{AID}</Expression>
</Subscript>
<Type>data</Type>
</SQLMap>
<SqlRowIdName>AID</SqlRowIdName>
<SqlTableNumber>1</SqlTableNumber>
<StreamLocation>^User.ADBKS</StreamLocation>
<Type>%Storage.SQL</Type>
}

}
