using System;
using System.IO;
using System.Net;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            new Class1();
        }
    }

    public class Class1
    {
        private HttpListener listener;
        private int listenerPort;

        public Class1()
        {
            listenerPort = 1337;

            try
            {
                listener = new HttpListener();
                listener.IgnoreWriteExceptions = true;
                StartHTTPListener();
            }
            catch (PlatformNotSupportedException)
            {
                listener = null;
            }
        }

        public Boolean StartHTTPListener()
        {
            try
            {
                if (listener.IsListening)
                    return true;

                string prefix = "http://+:" + listenerPort + "/";
                listener.Prefixes.Clear();
                listener.Prefixes.Add(prefix);
                listener.Start();

                for (;;)
                {
                    HttpListenerContext ctx = listener.GetContext();
                    new Thread(() => ProcessRequest(ctx)).Start();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Exception");
                return false;
            }
        }

        private void ProcessRequest(HttpListenerContext context)
        {
            StreamWriter writer = new StreamWriter(context.Response.OutputStream);
            writer.Write(context.Request.RawUrl);
            writer.Flush();
            context.Response.OutputStream.Close();
        }
    }
}
