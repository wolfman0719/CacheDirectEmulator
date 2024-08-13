using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Timers;
using InterSystems.Data.IRISClient;
using InterSystems.Data.IRISClient.ADO;

namespace cdapp
{
    public class cacheDirectWapper
    {
        public IRISConnection conn = new();
        public IRIS iris;
        public IRISObject cd;
        public event EventHandler ErrorEvent = delegate { };
        public event EventHandler ExecuteEvent = delegate { };

        private readonly System.Timers.Timer timer = new();

        private string p0 = "";
        private string p1 = "";
        private string p2 = "";
        private string p3 = "";
        private string p4 = "";
        private string p5 = "";
        private string p6 = "";
        private string p7 = "";
        private string p8 = "";
        private string p9 = "";
        private string plist = "";
        private string pdelim = "\r\n";
        private string value = "";
        private string code = "";
        private long execflag = 0;
        private string errorname = "";
        private long error = 0;
        private long interval;
        private string inamespace = "";
        private IRISList props = new();

        private void Exec3(object? source, ElapsedEventArgs e)
        {
            timer.Stop();
            this.Execute(this.code);
            this.execflag = 0;
        }


        protected virtual void OnError()
        {
            ErrorEvent?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void Executed()
        {
            ExecuteEvent?.Invoke(this, EventArgs.Empty);
        }

        public string P0
        {
            set 
            { 
                this.p0 = value;
            }
            get { return this.p0; }
        }
        public string P1
        {
            set 
            { 
                this.p1 = value;
            
            }
            get { return this.p1; }
        }
        public string P2
        {
            set 
            { 
                this.p2 = value;
            }
            get { return this.p2; }
        }
        public string P3
        {
            set 
            { 
                this.p3 = value;
            }
            get { return this.p3; }
        }
        public string P4
        {
            set 
            { 
                this.p4 = value;
            }
            get { return this.p4; }
        }
        public string P5
        {
            set 
            { 
                this.p5 = value;
            }
            get { return this.p5; }
        }
        public string P6
        {
            set 
            { 
                this.p6 = value;
            }
            get { return this.p6; }
        }
        public string P7
        {
            set 
            { 
                this.p7 = value;
            }
            get { return this.p7; }
        }
        public string P8
        {
            set 
            { 
                this.p8 = value;
            }
            get { return this.p8; }
        }
        public string P9
        {
            set 
            { 
                this.p9 = value;
            }
            get { return this.p9; }
        }
        public string PLIST
        {
            set 
            { 
                this.plist = value;
            }
            get { return this.plist; }
        }
        public string PDELIM
        {
            set 
            { 
                this.pdelim = value;
            }
            get { return this.pdelim; }
        }
        public string VALUE
        {
            set 
            { 
                this.value = value;
            }
            get
            {
                if (this.execflag == 2)
                {
                    this.Execute(this.code);
                    this.execflag = 0;
                }
                return this.value;
            }
        }
        public string Code
        {
            set { this.code = value; }
            get { return this.code; }
        }
        public long ExecFlag
        {
            set
            {
                this.execflag = value;
                if (value == 1)
                {
                    this.Execute(this.code);
                    this.execflag = 0;
                }
                else if (value == 2)
                {
                }
                else if (value == 3)
                {
                    timer.Interval = this.interval;
                    timer.AutoReset = true;
                    timer.Enabled = true;
                    timer.Elapsed += new ElapsedEventHandler(Exec3);

                   
                    timer.Start();

                }
            }
            get { return this.execflag; }
        }

        public string NameSpace
        {
            set
            {
                this.inamespace = value;
            }
            get
            {
                return this.inamespace;
            }
        }
        public long Interval
        {
            set
            {
                this.interval = value;
            }
            get { return this.interval; }
        }
        public string ErrorName
        {
            get { return this.errorname; }
        }
        public string Error
        {
            get { return this.error.ToString(); }
        }


        public cacheDirectWapper(string constr)
        {
            try
            {

                conn.ConnectionString = constr;
                conn.Open();
                iris = IRIS.CreateIRIS(conn);
                cd = (IRISObject)iris.ClassMethodObject("CacheDirect.Emulator", "%New");

            }
            finally
            {
            }
        }

        public cacheDirectWapper(IRISConnection irisconn)
        {
            try
            {

                conn = irisconn;
                iris = IRIS.CreateIRIS(conn);
                cd = (IRISObject)iris.ClassMethodObject("CacheDirect.Emulator", "%New");

            }
            finally
            {
            }
        }
        public Boolean end()
        {

            try
            {
                cd.Dispose();
                conn.Close();
            }
            finally
            {
            }
            return true;
        }

        public void Dispose()
        {

            try
            {
                cd.Dispose();
            }
            finally
            {
            }
        }

        private static string PropGet(IRISList props,int index)
        {
            string? result;

            if (props.Get(index) != null)
            {
                if (props.Get(index).GetType().Name == "string")
                {
                    result = (string)props.Get(index);
                }
                else if (props.Get(index).GetType().Name == "Byte[]")
                {
                    result = System.Text.Encoding.Latin1.GetString((byte[])props.Get(index));
                }
                else
                {
                    result = props.Get(index).ToString();
                }
          
            }
            else { result = null; }

            if (result != null)
            {
                return result;
            }
            else {
                return ""; 
            }

        }

        public long Execute(string command)
        {
            long status;

            IRISList sendmessage = new();

            sendmessage.Add(command);
            sendmessage.Add(p0);
            sendmessage.Add(p1);
            sendmessage.Add(p2);
            sendmessage.Add(p3);
            sendmessage.Add(p4);
            sendmessage.Add(p5);
            sendmessage.Add(p6);
            sendmessage.Add(p7);
            sendmessage.Add(p8);
            sendmessage.Add(p9);
            sendmessage.Add(plist);
            sendmessage.Add(pdelim);
            sendmessage.Add(inamespace);

            status = (long)cd.Invoke("Execute", sendmessage);

            props = cd.GetIRISList("PropsData");

            p0 = PropGet(props, 1);
            p1 = PropGet(props, 2);
            p2 = PropGet(props, 3);
            p3 = PropGet(props, 4);
            p4 = PropGet(props, 5);
            p5 = PropGet(props, 6);
            p6 = PropGet(props, 7);
            p7 = PropGet(props, 8);
            p8 = PropGet(props, 9);
            p9 = PropGet(props, 10);
            plist = PropGet(props, 11);
            pdelim = PropGet(props, 12);
            value = PropGet(props, 13);
            errorname = PropGet(props, 15);

            if (props.Get(14) != null)
            {
                error = (int)props.Get(14);
            }

            if (error == 1)
            {
                OnError();
            }

            Executed();

            return status;
        }

        public string getPLIST(int index)
        {
            string[] PLISTArray = { "" };
            
            if (index < 1) return "";

            if (plist is string)
            {
                if (pdelim is null)
                {
                    pdelim = "\r\n";
                }

                PLISTArray = plist.Split(pdelim.ToCharArray());

            }
            else {
                if (plist != null)
                {
                    if (pdelim is null)
                   {
                      pdelim = "\r\n";
                   }
                   if (plist != null && plist.Length > 0)
                    {
                        PLISTArray = plist.Split(pdelim.ToCharArray());
                    }

                }

            }

            if (PLISTArray.Length >= index && PLISTArray[index - 1] != null)
            {
                return PLISTArray[index - 1];
            }
            else {
                return "";
            }

        }
        public long getPLISTLength()
        {
            string[] PLISTArray = { "" };

            if (plist is string)
            {
                if (pdelim is null)
                {
                    pdelim = "\r\n";
                }

                PLISTArray = plist.Split(pdelim.ToCharArray());

            }
            else
            {
                if (plist != null)
                {

                    if (pdelim is null)
                    {
                        pdelim = "\r\n";
                    }

                    if (plist != null && plist.Length > 0)
                    {
                        PLISTArray = plist.Split(pdelim.ToCharArray());
                    }
                }

            }

            return PLISTArray.Length;
        }

        public Boolean setPLIST(int index, string replace)
        {
            string[] PLISTArray = { "" };

            if (plist is string)
            {

                if (pdelim is null)
                {
                    pdelim = "\r\n";
                }

                PLISTArray = plist.ToString().Split((pdelim.ToCharArray()));
            }
            else
            {
                if (plist != null)
                {

                    if (pdelim is null)
                    {
                        pdelim = "\r\n";
                    }

                    if (plist != null && plist.Length > 0)
                    {
                        PLISTArray = plist.Split(pdelim.ToCharArray());
                    }
                }
            }

            if (index <= PLISTArray.Length)
            {
                PLISTArray[index - 1] = replace;
            }

            return true;
        }
        public static string Version
        {
            get { return "V2.3.1"; }
        }
    }
}
