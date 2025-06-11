using System;
using System.Diagnostics;
using InterSystems.Data.IRISClient;
using InterSystems.Data.IRISClient.ADO;

namespace cdapp
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    class ConsoleApp
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        void OnError(object? sender, EventArgs e)
        {
            Debug.Print("OnError Event Occurs!!!");
        }
        void Executed(object? sender, EventArgs e)
        {
            Debug.Print("Executed Event Occurs!!!");
        }

        public ConsoleApp()
        {

            //
            // TODO: Add code to start application here
            //
            try
            {
                // Create a cacheDirectWapper instance
                IRISConnection irisconn = new IRISConnection();
                irisconn.ConnectionString = "Server = localhost; Log File=cprovider.log;Port=1972; Namespace=USER; Password = SYS; User ID = _system;";
                irisconn.Open();

                cacheDirectWapper cdw = new cacheDirectWapper(irisconn);

                cacheDirectWapper cdw2 = new cacheDirectWapper(irisconn);

                cdw.ErrorEvent += OnError;
                cdw.ExecuteEvent += Executed;

                Debug.Print("Client Version = " + cacheDirectWapper.Version);

                cdw.P0 = "ABC;DEF;GHI";
                cdw.P1 = ";";
                cdw.PDELIM = ";";
                cdw.PLIST = "abc;def;ghi;klm";
                cdw.P2 = "aaa";
                cdw.P3 = "bbb";
                cdw.P4 = "ccc";
                cdw.P5 = "ddd";
                cdw.P6 = "eee";
                cdw.P7 = "fff";
                cdw.P8 = "ggg";
                cdw.P9 = "hhh";


                cdw.Execute("=$PIECE(P0,P1,2)");

                Debug.Print("=$PIECE(P0,P1,2)");
                Debug.Print("P0 = " + cdw.P0);
                Debug.Print("P1 = " + cdw.P1);
                Debug.Print("P2 = " + cdw.P2);
                Debug.Print("P3 = " + cdw.P3);
                Debug.Print("P4 = " + cdw.P4);
                Debug.Print("P5 = " + cdw.P5);
                Debug.Print("P6 = " + cdw.P6);
                Debug.Print("P7 = " + cdw.P7);
                Debug.Print("P8 = " + cdw.P8);
                Debug.Print("P9 = " + cdw.P9);
                Debug.Print("PLIST = " + cdw.PLIST);
                Debug.Print("PDELIM = " + cdw.PDELIM);
                Debug.Print("VALUE = " + cdw.VALUE);
                Debug.Print("ErrorName = " + cdw.ErrorName);
                Debug.Print("\n");

                cdw2.P2 = "ABC;DEF;GHI";
                cdw2.P3 = ";";
                cdw2.PDELIM = ";";

                cdw2.Execute("=$PIECE(P2,P3,2)");

                Debug.Print("=$PIECE(P2,P3,2)");
                Debug.Print("P2 = " + cdw2.P2);
                Debug.Print("P3 = " + cdw2.P3);
                Debug.Print("VALUE = " + cdw2.VALUE);
                Debug.Print("ErrorName = " + cdw2.ErrorName);
                Debug.Print("\n");

                cdw.P0 = "あいうえお;かきくけこ;さしすせそ";
                cdw.P1 = ";";
                cdw.PDELIM = ";";

                cdw.Execute("=$PIECE(P0,P1,2)");

                Debug.Print("=$PIECE(P0,P1,2)");
                Debug.Print("P0 = " + cdw.P0);
                Debug.Print("P1 = " + cdw.P1);
                Debug.Print("P2 = " + cdw.P2);
                Debug.Print("P3 = " + cdw.P3);
                Debug.Print("P4 = " + cdw.P4);
                Debug.Print("P5 = " + cdw.P5);
                Debug.Print("P6 = " + cdw.P6);
                Debug.Print("P7 = " + cdw.P7);
                Debug.Print("P8 = " + cdw.P8);
                Debug.Print("P9 = " + cdw.P9);
                Debug.Print("PLIST = " + cdw.PLIST);
                Debug.Print("PDELIM = " + cdw.PDELIM);
                Debug.Print("VALUE = " + cdw.VALUE);
                Debug.Print("ErrorName = " + cdw.ErrorName);
                Debug.Print("\n");

                cdw.PLIST = "";
                cdw.Execute("set PLIST(1)= 123,PLIST(2)=456,PLIST(3)=7890");

                Debug.Print("set PLIST(1)= 123,PLIST(2)=456,PLIST(3)=7890");
                Debug.Print("P0 = " + cdw.P0);
                Debug.Print("P1 = " + cdw.P1);
                Debug.Print("P2 = " + cdw.P2);
                Debug.Print("P3 = " + cdw.P3);
                Debug.Print("P4 = " + cdw.P4);
                Debug.Print("P5 = " + cdw.P5);
                Debug.Print("P6 = " + cdw.P6);
                Debug.Print("P7 = " + cdw.P7);
                Debug.Print("P8 = " + cdw.P8);
                Debug.Print("P9 = " + cdw.P9);
                Debug.Print("PLIST = " + cdw.PLIST);
                Debug.Print("PDELIM = " + cdw.PDELIM);
                Debug.Print("VALUE = " + cdw.VALUE);
                Debug.Print("PLIST(1) = " + cdw.getPLIST(1));
                Debug.Print("PLIST(2) = " + cdw.getPLIST(2));
                Debug.Print("PLIST(3) = " + cdw.getPLIST(3));
                Debug.Print("PLIST(4) = " + cdw.getPLIST(4));
                Debug.Print("PLIST # = " + cdw.getPLISTLength().ToString());
                Debug.Print("PLIST = " + cdw.PLIST);
                Debug.Print("ErrorName = " + cdw.ErrorName);
                Debug.Print("\n");

                cdw.PLIST = "";
                cdw.Code = "set %X=345 d INT^%XD set P0 = %D KILL P2,P3,P4,P5,P6,P7,P8,P9";
                cdw.ExecFlag = 1;

                Debug.Print("set %X=345 d INT^%XD set P0 = %D");
                Debug.Print("P0 = " + cdw.P0);
                Debug.Print("P1 = " + cdw.P1);
                Debug.Print("P2 = " + cdw.P2);
                Debug.Print("P3 = " + cdw.P3);
                Debug.Print("P4 = " + cdw.P4);
                Debug.Print("P5 = " + cdw.P5);
                Debug.Print("P6 = " + cdw.P6);
                Debug.Print("P7 = " + cdw.P7);
                Debug.Print("P8 = " + cdw.P8);
                Debug.Print("P9 = " + cdw.P9);
                Debug.Print("PLIST = " + cdw.PLIST);
                Debug.Print("PDELIM = " + cdw.PDELIM);
                Debug.Print("VALUE = " + cdw.VALUE);
                Debug.Print("PLIST(1) = " + cdw.getPLIST(1));
                Debug.Print("PLIST(2) = " + cdw.getPLIST(2));
                Debug.Print("PLIST(3) = " + cdw.getPLIST(3));
                Debug.Print("PLIST # = " + cdw.getPLISTLength().ToString());
                Debug.Print("PLIST = " + cdw.PLIST);
                Debug.Print("ErrorName = " + cdw.ErrorName);
                Debug.Print("\n");

                Debug.Print("wait for 5 seconds ");
                cdw.Code = "set P0=23456";
                cdw.Interval = 5000;
                cdw.ExecFlag = 3;

                Console.WriteLine("Waiting for 5 seconds till the timer expires ");
                Console.WriteLine("If 5 seconds passed, Please press any key");
                Console.ReadLine();

                Debug.Print("set P0=23456");
                Debug.Print("P0 = " + cdw.P0);
                Debug.Print("P1 = " + cdw.P1);
                Debug.Print("P2 = " + cdw.P2);
                Debug.Print("P3 = " + cdw.P3);
                Debug.Print("P4 = " + cdw.P4);
                Debug.Print("P5 = " + cdw.P5);
                Debug.Print("P6 = " + cdw.P6);
                Debug.Print("P7 = " + cdw.P7);
                Debug.Print("P8 = " + cdw.P8);
                Debug.Print("P9 = " + cdw.P9);
                Debug.Print("PLIST = " + cdw.PLIST);
                Debug.Print("PDELIM = " + cdw.PDELIM);
                Debug.Print("VALUE = " + cdw.VALUE);
                Debug.Print("PLIST(1) = " + cdw.getPLIST(1));
                Debug.Print("PLIST(2) = " + cdw.getPLIST(2));
                Debug.Print("PLIST(3) = " + cdw.getPLIST(3));
                Debug.Print("PLIST # = " + cdw.getPLISTLength().ToString());
                Debug.Print("PLIST = " + cdw.PLIST);
                Debug.Print("ErrorName = " + cdw.ErrorName);
                Debug.Print("\n");

                cdw.ExecFlag = 2;
                cdw.Code = "=$zv";
                cdw.P0 = cdw.VALUE;

                Debug.Print("=$zv");
                Debug.Print("P0 = " + cdw.P0);
                Debug.Print("VALUE = " + cdw.VALUE);
                Debug.Print("\n");

                cdw.Execute("$zv");

                Debug.Print("$zv");
                Debug.Print("VALUE = " + cdw.VALUE);
                Debug.Print("ErrorName = " + cdw.ErrorName);
                Debug.Print("\n");

                cdw.Execute("set a = P00");

                Debug.Print("set a = P00");
                Debug.Print("ErrorName = " + cdw.ErrorName);
                Debug.Print("ErrorDetail = " + cdw.ErrorDetail);
                Debug.Print("\n");

                // timeoutはミリ秒が単位
                // timeout is miliseocond based
                cdw.TimeOut = 5000;
                cdw.Execute("=$zv");
                Debug.Print("VALUE = " + cdw.VALUE);
                Debug.Print("ErrorName = " + cdw.ErrorName);
                Debug.Print("ErrorDetail = " + cdw.ErrorDetail);
                Debug.Print("\n");

                cdw.Execute("set x=$zv h 10");
                Debug.Print("ErrorName = " + cdw.ErrorName);
                Debug.Print("ErrorDetail = " + cdw.ErrorDetail);
                Debug.Print("\n");
                                
                cdw.Execute("=##class(CacheDirect.Emulator).Version()");
                Debug.Print("VALUE = " + cdw.VALUE);
                Debug.Print("ErrorName = " + cdw.ErrorName);
                Debug.Print("ErrorDetail = " + cdw.ErrorDetail);
                Debug.Print("\n");
                // Cleanup CachedirectWapper
                cdw.end();
                cdw2.Dispose();
            }
            finally
            {
            }
        }

        static void Main(string[] args)
        {

            //
            // TODO: Add code to start application here
            //
            try
            {

                ConsoleApp ca = new ConsoleApp();

            }
            finally
            {
            }
        }
    }
}
