using System;

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
		static void Main(string[] args)
		{

			//
			// TODO: Add code to start application here
			//
            try
            {
                // Create a cacheDirectWapper instance
                cacheDirectWapper cdw = new cacheDirectWapper("Server = localhost; Log File=cprovider.log;Port=51773; Namespace=USER; Password = SYS; User ID = _system;");

                cdw.P0 = "ABC;DEF;GHI";
                cdw.P1 = ";";
                cdw.PDELIM = ";";

                cdw.Execute("=$PIECE(P0,P1,2)");

                Console.Write("P1 = " + cdw.P1);
                Console.Write("\n");
                Console.Write("Value = " + cdw.Value);
                Console.Write("\n");
                Console.Write("ErrorName = " + cdw.ErrorName);
                Console.Write("\n");

                cdw.Execute("set PLIST(1)= 123,PLIST(2)=456,PLIST(3)=7890");

                Console.Write("PLIST(1) = " + cdw.getPLIST(1));
                Console.Write("\n");
                Console.Write("PLIST(2) = " + cdw.getPLIST(2));
                Console.Write("\n");
                Console.Write("PLIST(3) = " + cdw.getPLIST(3));
                Console.Write("\n");
                Console.Write("PLIST = " + cdw.PLIST);
                Console.Write("\n");
                Console.Write("ErrorName = " + cdw.ErrorName);
                Console.Write("\n");

                cdw.Code = "set %X=345 d INT^%XD set P0 = %D";
                cdw.ExecFlag = 1;

                Console.Write("P0 = " + cdw.P0);
                Console.Write("\n");
                Console.Write("ErrorName = " + cdw.ErrorName);
                Console.Write("\n");

                cdw.Execute("set a = P00");

                Console.Write("ErrorName = " + cdw.ErrorName);
                Console.Write("\n");
                // Cleanup CachedirectWapper

                cdw.end();
            }
            finally
            {
            }
		}
	}
}
