using HBG.Utils.Log;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace HBG.Examples.Socket.Client
{
    public class SocketClient
    {
        private System.Net.Sockets.Socket socket = null;
        public void Run()
        {
            string serverIp = ConfigurationManager.AppSettings["SocketHostIp"];
            int serverPort = Convert.ToInt32(ConfigurationManager.AppSettings["SocketHostPort"]);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(serverIp), serverPort);
         
            try
            {
                socket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //连接Socket服务端
                socket.Connect(endPoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string sendMsg = "\"欢迎连接到服务器！\"\r\n";
            byte[] sendBytes = new byte[1024];
            sendBytes = Encoding.UTF8.GetBytes(sendMsg);

            try
            {
                //向服务端推送消息
                socket.Send(sendBytes, sendBytes.Length, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Thread recvThread = new Thread(new ThreadStart(ReceiveMsg));
            recvThread.Name = "服务端消息接收线程";
            recvThread.Start();

            while (true)
            {
                //阻塞线程
                Thread.Sleep(30 * 1000);
            }
        }

        /// <summary>
        /// 接收服务端消息
        /// </summary>
        private void ReceiveMsg()
        {
            if (socket!=null)
            {
                SocketReader socketReader = new SocketReader();
                while (true)
                {
                    string msg = string.Empty;
                    socketReader.ReadPacket(socket,out msg);
                    Console.WriteLine(msg);
                    Thread.Sleep(1 * 1000);
                }
            }
        }
    }
}
