using HBG.Utils.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace HBG.Examples.Socket.Server
{
    public class SocketServer
    {
        //服务器为每一个连接客户端产生一个线程，这样可以接受多个连接:
        private TcpListener tcpListener;
        private Thread listenThread;

        public void Run()
        {
            this.tcpListener = new TcpListener(IPAddress.Any, 3000);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
        }

        private void ListenForClients()
        {
            this.tcpListener.Start();
            while (true)
            {
                //blocks until a client has connected to the server
                System.Net.Sockets.Socket clientSocket = tcpListener.AcceptSocket();

                //create a thread to handle communication
                //with connected client
                Thread recvThread = new Thread(new ParameterizedThreadStart(HandleCommunicationWithClient));
                recvThread.Start(clientSocket);
            }
        }

        private void HandleCommunicationWithClient(object clientSocket)
        {
            System.Net.Sockets.Socket socket = (System.Net.Sockets.Socket)clientSocket;

            byte[] recvBytes = new byte[1024];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;
                try
                {
                    //blocks until a client sends a message
                    socket.Blocking = true;
                    bytesRead = socket.Receive(recvBytes, recvBytes.Length, 0);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }

                //message has successfully been received
                Console.WriteLine(Encoding.UTF8.GetString(recvBytes, 0, bytesRead));

                //向客户端连续推送数据
                byte[] toClientBytes = new byte[1024];
                int counter = 0;
                while (true)
                {
                    try
                    {
                        toClientBytes = Encoding.UTF8.GetBytes(counter + "-向客户端连续推送数据测试\r\n");
                        socket.Send(toClientBytes, toClientBytes.Length, 0);
                        Thread.Sleep(1*1000);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.GetInstance().WriteLog(string.Format("向客户端连续推送数据失败：{0}\n{1}", ex.Message, ex.StackTrace), LogType.错误);
                        break;
                    }

                    counter++;
                }
            }

            //关闭Socket连接
            socket.Close();
        }
    }
}
