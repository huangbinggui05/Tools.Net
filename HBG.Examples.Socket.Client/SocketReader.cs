using HBG.Utils.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HBG.Examples.Socket.Client
{
    public class SocketReader
    {
        private const string delimiter = "\r\n"; //消息分隔字符串
        private static readonly byte[] delimiterBytes = Encoding.Default.GetBytes(delimiter);
        private List<byte> recvBytes = new List<byte>();

        /// <summary>
        /// 读取一个包，包之间采用定界符delimiter分割
        /// </summary>
        /// <returns></returns>
        public void ReadPacket(System.Net.Sockets.Socket socket, out string msg)
        {
            msg = string.Empty;
            byte[] buffer = new byte[1024];//接收缓存
            int searchIndex = 0;
            while (true)
            {
                #region 1.在缓冲中搜索分隔符，如果找到，则把分隔符前的字符返回，并移除缓存中的包括分隔符在内及之前的字符
                //如果没有找到，从socket中读取一个包
                for (; searchIndex <= recvBytes.Count - delimiterBytes.Length; searchIndex++)
                {
                    bool found = true;
                    for (int i = 0; i < delimiterBytes.Length; i++)
                    {
                        if (recvBytes[searchIndex + i] != delimiterBytes[i])
                        {
                            found = false;
                            break;
                        }
                    }
                    if (found)
                    {
                        msg = Encoding.UTF8.GetString(recvBytes.ToArray(), 0, searchIndex);
                        recvBytes.RemoveRange(0, searchIndex + delimiterBytes.Length);
                        return;
                    }
                }
                #endregion

                #region 2.从socket接收数据
                int recvByteCount = 0;//每次接收到的字节数
                try
                {
                    socket.Blocking = true;
                    recvByteCount = socket.Receive(buffer, buffer.Length, SocketFlags.None);
                }
                catch (Exception ex)
                {
                    string errMsg = string.Format("Socket消息接收异常：{0}\n{1}", ex.Message, ex.StackTrace);
                    LogHelper.GetInstance().WriteLog(errMsg, LogType.错误);
                    Console.WriteLine(errMsg);
                    break;
                }
                #endregion

                #region 3.将接收到的数据拷贝到list中
                for (int i = 0; i < recvByteCount; i++)
                {
                    recvBytes.Add(buffer[i]);
                }
                #endregion 
            }
        }
    }
}
