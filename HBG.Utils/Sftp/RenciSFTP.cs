﻿using System;
using System.Collections;
using System.IO;
using Renci.SshNet;
using HBG.Utils.Log;

/************************描述 SFTP操作类****************************************** 
**创建者  : FYF 
**创建时间: 2015-03-11 
**描述    : SFTP操作类 
**注意    : 所有远程目录或路径可包含工作目录(sftp.WorkingDirectory)，此时路径以"/"开头；也可以不包含工作目录，此时路径不以"/"开头 
** 履历   ：No.         日期           修改人                 描述 
*********************************************************************************/

namespace HBG.Utils
{
    /// <summary>  
    /// SFTP操作类  
    /// </summary>  
    public class SftpHelper
    {
        #region 字段或属性  
        private SftpClient sftp;
        /// <summary>  
        /// SFTP连接状态  
        /// </summary>  
        public bool Connected { get { return sftp.IsConnected; } }
        #endregion

        #region 构造  
        /// <summary>  
        /// 构造  
        /// </summary>  
        /// <param name="ip">IP</param>  
        /// <param name="port">端口</param>  
        /// <param name="user">用户名</param>  
        /// <param name="pwd">密码</param>  
        public SftpHelper(string ip, string port, string user, string pwd)
        {
            sftp = new SftpClient(ip, Int32.Parse(port), user, pwd);
        }
        #endregion

        #region 连接SFTP  
        /// <summary>  
        /// 连接SFTP  
        /// </summary>  
        /// <returns>true成功</returns>  
        public bool Connect()
        {
            try
            {
                if (!Connected)
                {
                    sftp.Connect();
                }
                
            }
            catch (Exception ex)
            {
                LogHelper.GetInstance().WriteLog(string.Format("连接SFTP失败，原因：{0}\r\n{1}", ex.Message, ex.StackTrace), LogType.错误);
                //throw new Exception(string.Format("连接SFTP失败，原因：{0}", ex.Message));
                return false;
            }
            return true;
        }
        #endregion

        #region 断开SFTP  
        /// <summary>  
        /// 断开SFTP  
        /// </summary>   
        public void Disconnect()
        {
            try
            {
                if (sftp != null && Connected)
                {
                    sftp.Disconnect();
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetInstance().WriteLog(string.Format("断开SFTP失败，原因：{0}\r\n{1}", ex.Message, ex.StackTrace), LogType.错误);
                //throw new Exception(string.Format("断开SFTP失败，原因：{0}", ex.Message));
            }
        }
        #endregion

        #region SFTP上传文件  
        /// <summary>  
        /// SFTP上传文件  
        /// </summary>  
        /// <param name="localPath">本地路径</param>  
        /// <param name="remotePath">远程路径</param>  
        public void Put(string localPath, string remotePath)
        {
            try
            {
                using (var file = File.OpenRead(localPath))
                {
                    Connect();
                    sftp.UploadFile(file, remotePath);
                    Disconnect();
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetInstance().WriteLog(string.Format("SFTP文件上传失败，原因：{0}\r\n{1}", ex.Message, ex.StackTrace), LogType.错误);
                // throw new Exception(string.Format("SFTP文件上传失败，原因：{0}", ex.Message));
            }
        }
        #endregion

        #region SFTP获取文件  
        /// <summary>  
        /// SFTP获取文件  
        /// </summary>  
        /// <param name="remotePath">远程路径</param>  
        /// <param name="localPath">本地路径</param>  
        public void Get(string remotePath, string localPath)
        {
            try
            {
                Connect();
                var byt = sftp.ReadAllBytes(remotePath);
                Disconnect();
                File.WriteAllBytes(localPath, byt);
            }
            catch (Exception ex)
            {
                LogHelper.GetInstance().WriteLog(string.Format("SFTP文件获取失败，原因：{0}\r\n{1}", ex.Message, ex.StackTrace),LogType.错误);
                //throw new Exception(string.Format("SFTP文件获取失败，原因：{0}", ex.Message));
            }

        }
        #endregion

        #region 删除SFTP文件  
        /// <summary>  
        /// 删除SFTP文件   
        /// </summary>  
        /// <param name="remoteFile">远程路径</param>  
        public void Delete(string remoteFile)
        {
            try
            {
                Connect();
                sftp.Delete(remoteFile);
                Disconnect();
            }
            catch (Exception ex)
            {
                LogHelper.GetInstance().WriteLog(string.Format("SFTP文件删除失败，原因：{0}\r\n{1}", ex.Message, ex.StackTrace), LogType.错误);
                //throw new Exception(string.Format("SFTP文件删除失败，原因：{0}", ex.Message));
            }
        }
        #endregion

        #region 获取SFTP文件列表  
        /// <summary>  
        /// 获取SFTP文件列表  
        /// </summary>  
        /// <param name="remotePath">远程目录</param>  
        /// <param name="fileSuffix">文件后缀</param>  
        /// <returns></returns>  
        public ArrayList GetFileList(string remotePath, string fileSuffix)
        {
            var objList = new ArrayList();
            try
            {
                Connect();
                var files = sftp.ListDirectory(remotePath);
                Disconnect();
                foreach (var file in files)
                {
                    string name = file.Name;
                    if (name.Length > (fileSuffix.Length + 1) && fileSuffix == name.Substring(name.Length - fileSuffix.Length))
                    {
                        objList.Add(name);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.GetInstance().WriteLog(string.Format("SFTP文件列表获取失败，原因：{0}\r\n{1}", ex.Message, ex.StackTrace), LogType.错误);
                //throw new Exception(string.Format("SFTP文件列表获取失败，原因：{0}", ex.Message));
            }

            return objList;
        }
        #endregion

        #region 移动SFTP文件  
        /// <summary>  
        /// 移动SFTP文件  
        /// </summary>  
        /// <param name="oldRemotePath">旧远程路径</param>  
        /// <param name="newRemotePath">新远程路径</param>  
        public void Move(string oldRemotePath, string newRemotePath)
        {
            try
            {
                Connect();
                sftp.RenameFile(oldRemotePath, newRemotePath);
                Disconnect();
            }
            catch (Exception ex)
            {
                LogHelper.GetInstance().WriteLog(string.Format("SFTP文件移动失败，原因：{0}\r\n{1}", ex.Message, ex.StackTrace), LogType.错误);
                //throw new Exception(string.Format("SFTP文件移动失败，原因：{0}", ex.Message));
            }
        }
        #endregion

    }

}
