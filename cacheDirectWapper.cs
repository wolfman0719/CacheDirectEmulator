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
        public IRISConnection conn = new IRISConnection();
        public IRIS iris;
        public IRISObject cd;
        public event EventHandler ErrorEvent;
        public event EventHandler ExecuteEvent;

        private System.Timers.Timer timer = new System.Timers.Timer();

        private string p0;
        private string p1;
        private string p2;
        private string p3;
        private string p4;
        private string p5;
        private string p6;
        private string p7;
        private string p8;
        private string p9;
        private string plist;
        private string pdelim;
        private string value;
        private string code;
        private long execflag;
        private string errorname;
        private long error;
        private long interval;
        private string inamespace;
        private IRISList props;

        private void Exec3(object source, ElapsedEventArgs e)
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
                this.cd.Set("P0", value);
            }
            get { return this.p0; }
        }
        public string P1
        {
            set 
            { 
                this.p1 = value;
                this.cd.Set("P1", value);
            
            }
            get { return this.p1; }
        }
        public string P2
        {
            set 
            { 
                this.p2 = value;
                this.cd.Set("P2", value);
            }
            get { return this.p2; }
        }
        public string P3
        {
            set 
            { 
                this.p3 = value;
                this.cd.Set("P3",value);
            }
            get { return this.p3; }
        }
        public string P4
        {
            set 
            { 
                this.p4 = value;
                this.cd.Set("P4", value);
            }
            get { return this.p4; }
        }
        public string P5
        {
            set 
            { 
                this.p5 = value;
                this.cd.Set("P5", value);
            }
            get { return this.p5; }
        }
        public string P6
        {
            set 
            { 
                this.p6 = value;
                this.cd.Set("P6", value);
            }
            get { return this.p6; }
        }
        public string P7
        {
            set 
            { 
                this.p7 = value;
                this.cd.Set("P7", value);
            }
            get { return this.p7; }
        }
        public string P8
        {
            set 
            { 
                this.p8 = value;
                this.cd.Set("P8", value);
            }
            get { return this.p8; }
        }
        public string P9
        {
            set 
            { 
                this.p9 = value;
                this.cd.Set("P9", value);
            }
            get { return this.p9; }
        }
        public string PLIST
        {
            set 
            { 
                this.plist = value;
                this.cd.Set("PLIST", value);
            }
            get { return this.plist; }
        }
        public string PDELIM
        {
            set 
            { 
                this.pdelim = value;
                this.cd.Set("PDELIM", value);
            }
            get { return this.pdelim; }
        }
        public string VALUE
        {
            set 
            { 
                this.value = value;
                this.cd.Set("VALUE", value);
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

                    // ƒ^ƒCƒ}[‚ðŠJŽn‚·‚é
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
                this.Execute("set $namespace=" + "" + value + "");
            }
            get
            {
                return iris.ClassMethodString("CacheDirect.Emulator", "GetNamespace");
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

        public long Execute(string command)
        {
            long status;

            status = (long)cd.Invoke("Execute", command);

            props = cd.GetIRISList("PropsData");

            if (props.Get(1) != null) 
            {
                if (props.Get(1).GetType().Name == "string")
                {
                    p0 = (string)props.Get(1);
                }
                else if (props.Get(1).GetType().Name == "Byte[]")
                {
                    p0 = System.Text.Encoding.ASCII.GetString((byte[])props.Get(1));
                }
                else
                {
                    p0 = props.Get(1).ToString();
                }
            }

            if (props.Get(2) != null)
            {
                if (props.Get(2).GetType().Name == "string")
                {
                    p1 = (string)props.Get(2);
                }
                else if (props.Get(2).GetType().Name == "Byte[]")
                {
                    p1 = System.Text.Encoding.ASCII.GetString((byte[])props.Get(2));
                }
                else
                {
                    p1 = props.Get(2).ToString();
                }
            }

            if (props.Get(3) != null)
            {
                if (props.Get(3).GetType().Name == "string")
                {
                    p2 = (string)props.Get(3);
                }
                else if (props.Get(3).GetType().Name == "Byte[]")
                {
                    p2 = System.Text.Encoding.ASCII.GetString((byte[])props.Get(3));
                }
                else
                {
                    p2 = props.Get(3).ToString();
                }
            }

            if (props.Get(4) != null)
            {
                if (props.Get(4).GetType().Name == "string")
                {
                    p3 = (string)props.Get(4);
                }
                else if (props.Get(4).GetType().Name == "Byte[]")
                {
                    p3 = System.Text.Encoding.ASCII.GetString((byte[])props.Get(4));
                }
                else
                {
                    p3 = props.Get(4).ToString();
                }
            }

            if (props.Get(5) != null)
            {
                if (props.Get(5).GetType().Name == "string")
                {
                    p4 = (string)props.Get(5);
                }
                else if (props.Get(5).GetType().Name == "Byte[]")
                {
                    p4 = System.Text.Encoding.ASCII.GetString((byte[])props.Get(5));
                }
                else
                {
                    p4 = props.Get(5).ToString();
                }
            }

            if (props.Get(6) != null)
            {
                if (props.Get(6).GetType().Name == "string")
                {
                    p5 = (string)props.Get(6);
                }
                else if (props.Get(6).GetType().Name == "Byte[]")
                {
                    p5 = System.Text.Encoding.ASCII.GetString((byte[])props.Get(6));
                }
                else
                {
                    p5 = props.Get(6).ToString();
                }
            }

            if (props.Get(7) != null)
            {
                if (props.Get(7).GetType().Name == "string")
                {
                    p6 = (string)props.Get(7);
                }
                else if (props.Get(7).GetType().Name == "Byte[]")
                {
                    p6 = System.Text.Encoding.ASCII.GetString((byte[])props.Get(7));
                }
                else
                {
                    p6 = props.Get(7).ToString();
                }
            }

            if (props.Get(8) != null)
            {
                if (props.Get(8).GetType().Name == "string")
                {
                    p7 = (string)props.Get(8);
                }
                else if (props.Get(8).GetType().Name == "Byte[]")
                {
                    p7 = System.Text.Encoding.ASCII.GetString((byte[])props.Get(8));
                }
                else
                {
                    p7 = props.Get(8).ToString();
                }
            }

            if (props.Get(9) != null)
            {
                if (props.Get(9).GetType().Name == "string")
                {
                    p8 = (string)props.Get(9);
                }
                else if (props.Get(9).GetType().Name == "Byte[]")
                {
                    p8 = System.Text.Encoding.ASCII.GetString((byte[])props.Get(9));
                }
                else
                {
                    p8 = props.Get(9).ToString();
                }
            }

            if (props.Get(10) != null)
            {
                if (props.Get(10).GetType().Name == "string")
                {
                    p9 = (string)props.Get(10);
                }
                else if (props.Get(10).GetType().Name == "Byte[]")
                {
                    p9 = System.Text.Encoding.ASCII.GetString((byte[])props.Get(10));
                }
                else
                {
                    p9 = props.Get(10).ToString();
                }
            }

            if (props.Get(11) != null)
            {
                if (props.Get(11).GetType().Name == "string")
                {
                    plist = (string)props.Get(11);
                }
                else if (props.Get(11).GetType().Name == "Byte[]")
                {
                    plist = System.Text.Encoding.ASCII.GetString((byte[])props.Get(11));
                }
                else
                {
                    plist = props.Get(11).ToString();
                }
            }

            if (props.Get(12) != null)
            {
                if (props.Get(12).GetType().Name == "string")
                {
                    pdelim = (string)props.Get(12);
                }
                else if (props.Get(12).GetType().Name == "Byte[]")
                {
                    pdelim = System.Text.Encoding.ASCII.GetString((byte[])props.Get(12));
                }
                else
                {
                    pdelim = props.Get(12).ToString();
                }
            }

            if (props.Get(13) != null)
            {
                if (props.Get(13).GetType().Name == "string")
                {
                    value = (string)props.Get(13);
                }
                else if (props.Get(13).GetType().Name == "Byte[]")
                {
                    value = System.Text.Encoding.ASCII.GetString((byte[])props.Get(13));
                }
                else
                {
                    value = props.Get(13).ToString();
                }
            }

            if (props.Get(14) != null)
            {
                error = (int)props.Get(14);
            }

            if (props.Get(15) != null)
            {
                if (props.Get(15).GetType().Name == "string")
                {
                    errorname = (string)props.Get(15);
                }
                else if (props.Get(15).GetType().Name == "Byte[]")
                {
                    errorname = System.Text.Encoding.ASCII.GetString((byte[])props.Get(15));
                }
                else
                {
                    errorname = props.Get(15).ToString();
                }
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

            if (cd.Get("PLIST") is string)
            {
                string plist = (string)cd.Get("PLIST");
                PLISTArray = plist.Split(cd.Get("PDELIM").ToString().ToCharArray());

            }
            else {
                if (cd.Get("PLIST") != null)
                {

                   PLISTArray = cd.Get("PLIST").ToString().Split(cd.Get("PDELIM").ToString().ToCharArray());
                }

            }


            return PLISTArray[index - 1];
        }
        public long getPLISTLength()
        {
            string[] PLISTArray = { "" };

            if (cd.Get("PLIST") is string)
            {
                string plist = (string)cd.Get("PLIST");
                PLISTArray = plist.Split(cd.Get("PDELIM").ToString().ToCharArray());

            }
            else
            {
                if (cd.Get("PLIST") != null)
                {

                    PLISTArray = cd.Get("PLIST").ToString().Split(cd.Get("PDELIM").ToString().ToCharArray());
                }

            }

            return PLISTArray.Length;
        }

        public Boolean setPLIST(int index, string replace)
        {
            string[] PLISTArray = { "" };

            if (cd.Get("PLIST") is string)
            {
                string plist = (string)cd.Get("PLIST");
                PLISTArray = plist.ToString().Split((cd.Get("PDELIM").ToString().ToCharArray()));
            }
            else
            {
                if (cd.Get("PLIST") != null)
                {

                    PLISTArray = cd.Get("PLIST").ToString().Split((cd.Get("PDELIM").ToString().ToCharArray()));
                }
            }

            if (index <= PLISTArray.Length)
            {
                PLISTArray[index - 1] = replace;
                cd.Set("PLIST", string.Join(cd.Get("PDELIM").ToString(), PLISTArray));
            }

            if (cd.Get("PLIST") is string)
            {
                plist = (string)cd.Get("PLIST");
            }
            else
            {
                if (cd.Get("PLIST") != null)
                {
                    plist = cd.Get("PLIST").ToString();
                }
            }

            return true;
        }
        public string Version
        {
            get { return "V2.1"; }
        }
    }
}
