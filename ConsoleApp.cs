using System;
using System.Diagnostics;

// Add the following using statement

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
        void OnError(object sender, EventArgs e)
        {
            Debug.Print("OnError Event Occurs!!!");
        }
        void Executed(object sender, EventArgs e)
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
                cacheDirectWapper cdw = new cacheDirectWapper("Server = localhost; Log File=cprovider.log;Port=51773; Namespace=USER; Password = SYS; User ID = _system;");

                cdw.ErrorEvent += OnError;
                cdw.ExecuteEvent += Executed;

                cdw.P0 = "ABC;DEF;GHI";
                cdw.P1 = ";";
                cdw.PDELIM = ";";

                cdw.Execute("=$PIECE(P0,P1,2)");

                Debug.Print("P1 = " + cdw.P1);
                Debug.Print("VALUE = " + cdw.VALUE);
                Debug.Print("ErrorName = " + cdw.ErrorName);
                Debug.Print("\n");

                cdw.P0 = "あいうえお;かきくけこ;さしすせそ";
                cdw.P1 = ";";
                cdw.PDELIM = ";";

                cdw.Execute("=$PIECE(P0,P1,2)");

                Debug.Print("P1 = " + cdw.P1);
                Debug.Print("VALUE = " + cdw.VALUE);
                Debug.Print("ErrorName = " + cdw.ErrorName);
                Debug.Print("\n");

                cdw.Execute("set PLIST(1)= 123,PLIST(2)=456,PLIST(3)=7890");

                Debug.Print("PLIST(1) = " + cdw.getPLIST(1));
                Debug.Print("PLIST(2) = " + cdw.getPLIST(2));
                Debug.Print("PLIST(3) = " + cdw.getPLIST(3));
                Debug.Print("PLIST # = " + cdw.getPLISTLength().ToString());
                Debug.Print("PLIST = " + cdw.PLIST);
                Debug.Print("ErrorName = " + cdw.ErrorName);
                Debug.Print("\n");

                cdw.Code = "set %X=345 d INT^%XD set P0 = %D";
                cdw.ExecFlag = 1;

                Debug.Print("P0 = " + cdw.P0);
                Debug.Print("ErrorName = " + cdw.ErrorName);
                Debug.Print("\n");

                Debug.Print("wait for 5 seconds ");
                cdw.Code = "set P0=23456";
                cdw.Interval = 5000;
                cdw.ExecFlag = 3;

                Console.WriteLine("Waiting for 5 seconds till the timer expires ");
                Console.WriteLine("If 5 seconds passed, Please press any key");
                Console.ReadLine();

                Debug.Print("P0 = " + cdw.P0);
                Debug.Print("ErrorName = " + cdw.ErrorName);
                Debug.Print("\n");

                cdw.ExecFlag = 2;
                cdw.Code = "=$zv";
                cdw.P0 = cdw.VALUE;

                Debug.Print("P0 = " + cdw.P0);
                Debug.Print("VALUE = " + cdw.VALUE);
                Debug.Print("\n");

                cdw.Execute("set a = P00");

                Debug.Print("ErrorName = " + cdw.ErrorName);
                Debug.Print("\n");
                // Cleanup CachedirectWapper

                cdw.end();
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

                /*
                // Create a cacheDirectWapper instance
                cacheDirectWapper cdw = new cacheDirectWapper("Server = localhost; Log File=cprovider.log;Port=51773; Namespace=USER; Password = SYS; User ID = _system;");

                //cdw.ErrorEvent += OnError;
                cdw.P0 = "ABC;DEF;GHI";
                cdw.P1 = ";";
                cdw.PDELIM = ";";

                cdw.Execute("=$PIECE(P0,P1,2)");

                Debug.Print("P1 = " + cdw.P1);
                Debug.Print("\n");
                Debug.Print("VALUE = " + cdw.VALUE);
                Debug.Print("\n");
                Debug.Print("ErrorName = " + cdw.ErrorName);
                Debug.Print("\n");

                cdw.P0 = "あいうえお;かきくけこ;さしすせそ";
                cdw.P1 = ";";
                cdw.PDELIM = ";";

                cdw.Execute("=$PIECE(P0,P1,2)");

                Debug.Print("P1 = " + cdw.P1);
                Debug.Print("\n");
                Debug.Print("VALUE = " + cdw.VALUE);
                Debug.Print("\n");
                Debug.Print("ErrorName = " + cdw.ErrorName);
                Debug.Print("\n");

                cdw.Execute("set PLIST(1)= 123,PLIST(2)=456,PLIST(3)=7890");

                Debug.Print("PLIST(1) = " + cdw.getPLIST(1));
                Debug.Print("\n");
                Debug.Print("PLIST(2) = " + cdw.getPLIST(2));
                Debug.Print("\n");
                Debug.Print("PLIST(3) = " + cdw.getPLIST(3));
                Debug.Print("\n");
                Debug.Print("PLIST # = " + cdw.getPLISTLength());
                Debug.Print("\n");
                Debug.Print("PLIST = " + cdw.PLIST);
                Debug.Print("\n");
                Debug.Print("ErrorName = " + cdw.ErrorName);
                Debug.Print("\n");

                cdw.Code = "set %X=345 d INT^%XD set P0 = %D";
                cdw.ExecFlag = 1;

                Debug.Print("P0 = " + cdw.P0);
                Debug.Print("\n");
                Debug.Print("ErrorName = " + cdw.ErrorName);
                Console.Write("\n");

                cdw.Execute("set a = P00");

                Debug.Print("ErrorName = " + cdw.ErrorName);
                Debug.Print("\n");
                // Cleanup CachedirectWapper

                cdw.end();
                */
            }
            finally
            {
            }
		}
    }
}
