using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace CJia.Health.Tools
{
    /// <summary>
    /// ftp帮助类
    /// </summary>
    public class FtpHelp
    {
        public static void UploadFileByUri(string filePath, string uri, string hostname, string username, string password)
        {
            if (uri.Trim() == "")
            {
                return;
            }
            FileInfo fileinfo = new FileInfo(filePath);
            //if (!FtpIsExistsFile(targetDir, hostname, username, password)) //新建targetDir目录
            //    MakeDir(targetDir, hostname, username, password);
            //string URI = "ftp://" + hostname + "/" + targetDir + "/" + fileinfo.Name;
            System.Net.FtpWebRequest ftp = GetRequest(uri, username, password);
            //设置FTP命令 设置所要执行的FTP命令，
            ftp.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
            //指定文件传输的数据类型
            ftp.UseBinary = true;
            ftp.UsePassive = true;
            ftp.ContentLength = fileinfo.Length;//告诉ftp文件大小
            const int BufferSize = 2048;//缓冲大小设置为2KB
            byte[] content = new byte[BufferSize - 1 + 1];
            int dataRead;
            using (FileStream fs = fileinfo.OpenRead())//打开一个文件流 (System.IO.FileStream) 去读上传的文件
            {
                try
                {
                    using (Stream rs = ftp.GetRequestStream())//把上传的文件写入流
                    {
                        do
                        {
                            dataRead = fs.Read(content, 0, BufferSize);//每次读文件流的2KB
                            rs.Write(content, 0, dataRead);
                        } while (!(dataRead < BufferSize));
                        rs.Close();
                    }
                }
                catch { }
                finally
                {
                    fs.Close();
                }
            }
            ftp = null;
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="filePath">需要上传的文件完整路径</param>
        /// <param name="targetDir">目标路径</param>
        /// <param name="hostname">ftp地址</param>
        /// <param name="username">ftp用户名</param>
        /// <param name="password">ftp密码</param>
        public static void UploadFile(string filePath, string targetDir, string hostname, string username, string password)
        {
            if (targetDir.Trim() == "")
            {
                return;
            }
            FileInfo fileinfo = new FileInfo(filePath);
            if (!FtpIsExistsFile(targetDir, hostname, username, password)) //新建targetDir目录
                MakeDir(targetDir, hostname, username, password);
            string URI = "ftp://" + hostname + "/" + targetDir + "/" + fileinfo.Name;
            System.Net.FtpWebRequest ftp = GetRequest(URI, username, password);
            //设置FTP命令 设置所要执行的FTP命令，
            ftp.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
            //指定文件传输的数据类型
            ftp.UseBinary = true;
            ftp.UsePassive = true;
            ftp.ContentLength = fileinfo.Length;//告诉ftp文件大小
            const int BufferSize = 2048;//缓冲大小设置为2KB
            byte[] content = new byte[BufferSize - 1 + 1];
            int dataRead;
            using (FileStream fs = fileinfo.OpenRead())//打开一个文件流 (System.IO.FileStream) 去读上传的文件
            {
                try
                {
                    using (Stream rs = ftp.GetRequestStream())//把上传的文件写入流
                    {
                        do
                        {
                            dataRead = fs.Read(content, 0, BufferSize);//每次读文件流的2KB
                            rs.Write(content, 0, dataRead);
                        } while (!(dataRead < BufferSize));
                        rs.Close();
                    }
                }
                catch { }
                finally
                {
                    fs.Close();
                }
            }
            ftp = null;
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="localDir">下载至本地路径</param>
        /// <param name="FtpDir">ftp目标文件路径</param>
        /// <param name="FtpFile">从ftp要下载的文件名</param>
        /// <param name="hostname">ftp地址即IP</param>
        /// <param name="username">ftp用户名</param>
        /// <param name="password">ftp密码</param>
        public static void DownloadFile(string localDir, string FtpDir, string FtpFile, string hostname, string username, string password)
        {
            string URI = "FTP://" + hostname + "/" + FtpDir + "/" + FtpFile;
            string tmpname = Guid.NewGuid().ToString();
            string localfile = localDir + @"\" + tmpname;

            System.Net.FtpWebRequest ftp = GetRequest(URI, username, password);
            ftp.Method = System.Net.WebRequestMethods.Ftp.DownloadFile;
            ftp.UseBinary = true;
            ftp.UsePassive = false;

            using (FtpWebResponse response = (FtpWebResponse)ftp.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (FileStream fs = new FileStream(localfile, FileMode.CreateNew))
                    {
                        try
                        {
                            byte[] buffer = new byte[2048];
                            int read = 0;
                            do
                            {
                                read = responseStream.Read(buffer, 0, buffer.Length);
                                fs.Write(buffer, 0, read);
                            } while (!(read == 0));
                            responseStream.Close();
                            fs.Flush();
                            fs.Close();
                        }
                        catch (Exception)
                        {
                            fs.Close();
                            File.Delete(localfile);
                            throw;
                        }
                    }
                    responseStream.Close();
                }
                response.Close();
            }
            try
            {
                File.Delete(localDir + @"\" + FtpFile);
                File.Move(localfile, localDir + @"\" + FtpFile);
                ftp = null;
                ftp = GetRequest(URI, username, password);
                ftp.Method = System.Net.WebRequestMethods.Ftp.DeleteFile;
                ftp.GetResponse();

            }
            catch (Exception ex)
            {
                File.Delete(localfile);
                throw ex;
            }
            ftp = null;
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="localDir"></param>
        /// <param name="uri"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static void DownloadFile(string localDir, string uri, string username, string password)
        {
            string[] arr = uri.Split('/');
            string fileName = uri.Split('/')[arr.Length - 1];
            string URI = uri;
            string tmpname = Guid.NewGuid().ToString();
            string localfile = localDir + @"\" + fileName.Split('.')[0];
            if (File.Exists(localfile)) return;
            if (File.Exists(localDir + @"\" + fileName)) return;
            System.Net.FtpWebRequest ftp = GetRequest(URI, username, password);
            ftp.Method = System.Net.WebRequestMethods.Ftp.DownloadFile;
            ftp.UseBinary = true;
            ftp.UsePassive = false;

            using (FtpWebResponse response = (FtpWebResponse)ftp.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (FileStream fs = new FileStream(localfile, FileMode.CreateNew))
                    {
                        try
                        {
                            byte[] buffer = new byte[2048];
                            int read = 0;
                            do
                            {
                                read = responseStream.Read(buffer, 0, buffer.Length);
                                fs.Write(buffer, 0, read);
                            } while (!(read == 0));
                            responseStream.Close();
                            fs.Flush();
                            fs.Close();
                        }
                        catch (Exception)
                        {
                            fs.Close();
                            File.Delete(localfile);
                            throw;
                        }
                    }
                    responseStream.Close();
                }
                response.Close();
            }
            try
            {
                //File.Delete(localDir + @"\" + fileName);
                //File.Move(localfile, localDir + @"\" + fileName);

            }
            catch (Exception ex)
            {
                File.Delete(localfile);
                throw ex;
            }
            ftp = null;
        }
        /// <summary>
        /// 在ftp服务器上创建目录
        /// </summary>
        /// <param name="dirName">创建的目录名称</param>
        /// <param name="ftpHostIP">ftp地址</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        public static void MakeDir(string dirName, string ftpHostIP, string username, string password)
        {
            try
            {
                StringBuilder dir = new StringBuilder("");
                string[] dirs = dirName.Split('/');
                System.Net.FtpWebRequest ftp;
                FtpWebResponse response = null;
                for (int i = 0; i < dirs.Length; i++)
                {
                    try
                    {
                        dir.Append(dirs[i]);
                        string uri = "ftp://" + ftpHostIP + "/" + dir;
                        ftp = GetRequest(uri, username, password);
                        ftp.Method = WebRequestMethods.Ftp.MakeDirectory;
                        response = (FtpWebResponse)ftp.GetResponse();
                        response.Close();
                    }
                    catch { }
                    finally
                    {
                        dir.Append("/");
                    }
                }
                dir.Clear();
            }
            catch (Exception ex)
            {
                Message.Show(ex.Message);
            }
        }
        /// <summary>
        /// 在ftp服务器上创建目录
        /// </summary>
        /// <param name="dirUri"></param>
        /// <param name="hostName"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static void MakeDirByUri(string dirUri, string hostName, string username, string password)
        {
            try
            {
                StringBuilder dir = new StringBuilder("");
                string[] dirs = dirUri.Split('/');
                System.Net.FtpWebRequest ftp;
                FtpWebResponse response = null;
                for (int i = 3; i < dirs.Length; i++)
                {
                    try
                    {
                        dir.Append(dirs[i]);
                        string uri = "ftp://" + hostName + "/" + dir;
                        ftp = GetRequest(uri, username, password);
                        ftp.Method = WebRequestMethods.Ftp.MakeDirectory;
                        response = (FtpWebResponse)ftp.GetResponse();
                        response.Close();
                    }
                    catch { }
                    finally
                    {
                        dir.Append("/");
                    }
                }
                dir.Clear();
            }
            catch (Exception ex)
            {
                Message.Show(ex.Message);
            }
        }
        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="dirName">删除的目录名称</param>
        /// <param name="ftpHostIP">ftp地址</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        public static void DelDir(string dirName, string ftpHostIP, string username, string password)
        {
            try
            {
                string uri = "ftp://" + ftpHostIP + "/" + dirName;
                System.Net.FtpWebRequest ftp = GetRequest(uri, username, password);
                ftp.Method = WebRequestMethods.Ftp.RemoveDirectory;
                FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                Message.Show(ex.Message);
            }
        }
        /// <summary>
        /// 文件重命名
        /// </summary>
        /// <param name="currentUri">当前目录名称,文件完整ftp路径</param>
        /// <param name="newFilename">重命名文件名称(扩展名)</param>
        /// <param name="ftpServerIP">ftp地址</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        public static void Rename(string currentUri, string newFilename, string username, string password)
        {
            try
            {
                System.Net.FtpWebRequest ftp = GetRequest(currentUri, username, password);
                ftp.Method = WebRequestMethods.Ftp.Rename;
                ftp.RenameTo = newFilename;
                FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                Message.Show(ex.Message);
            }
        }
        /// <summary>
        /// 将文件移动到当前目录子目录Copy文件夹中
        /// </summary>
        /// <param name="currentUri"></param>
        /// <param name="hostName"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static void MoveFileToCopy(string currentUri, string hostName, string username, string password)
        {
            try
            {
                string fileName = Path.GetFileName(currentUri);
                string path = Path.GetDirectoryName(currentUri).Replace('\\', '/').Insert(4, "/");
                if (!FtpIsExistsFile(path + "/Copy", username, password))
                    MakeDirByUri(path + "/Copy", hostName, username, password);
                Rename(currentUri, "Copy/" + fileName, username, password);
            }
            catch (Exception ex)
            {
                Message.Show(ex.Message);
            }
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="currentFilename"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static void DeleteFile(string currentUri, string username, string password)
        {
            try
            {
                System.Net.FtpWebRequest ftp = GetRequest(currentUri, username, password);
                ftp.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                Message.Show(ex.Message);
            }
        }
        /// <summary>
        /// 判断ftp服务器上该目录是否存在
        /// </summary>
        /// <param name="dirName"></param>
        /// <param name="ftpHostIP"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool FtpIsExistsFile(string dirName, string ftpHostIP, string username, string password)
        {
            bool flag = true;
            try
            {
                string uri = "ftp://" + ftpHostIP + "/" + dirName + "/";
                System.Net.FtpWebRequest ftp = GetRequest(uri, username, password);
                ftp.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
                response.Close();
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }
        /// <summary>
        /// 判断ftp服务器上该目录是否存在
        /// </summary>
        /// <param name="dirUri"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private static bool FtpIsExistsFile(string dirUri, string username, string password)
        {
            bool flag = true;
            try
            {
                string uri = dirUri + "/";
                System.Net.FtpWebRequest ftp = GetRequest(uri, username, password);
                ftp.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
                response.Close();
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }
        /// <summary>
        /// 获取当前目录下文件列表（文件及目录）
        /// </summary>
        /// <param name="targetDir"></param>
        /// <param name="hostname"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static List<string> ListDirectory(string targetDir, string hostname, string username, string password)
        {
            List<string> result = new List<string>();
            try
            {
                string URI = "FTP://" + hostname + "/" + targetDir + "/";
                System.Net.FtpWebRequest ftp = GetRequest(URI, username, password);
                ftp.Method = System.Net.WebRequestMethods.Ftp.ListDirectory;
                ftp.UsePassive = true;
                ftp.UseBinary = true;
                string str = GetStringResponse(ftp);
                str = str.Replace("\r\n", "\r").TrimEnd('\r');
                str = str.Replace("\n", "\r");
                if (str != string.Empty)
                    result.AddRange(str.Split('\r'));
                return result;
            }
            catch { }
            return null;
        }
        /// <summary>
        /// 获取当前目录下文件列表(仅文件) mask为文件格式 .jpg
        /// </summary>
        /// <returns></returns>
        public static string[] GetFileList(string targetDir, string hostname, string username, string password, string mask)
        {
            StringBuilder result = new StringBuilder();
            try
            {
                string URI = "ftp://" + hostname + "/" + targetDir + "/";
                System.Net.FtpWebRequest ftp = GetRequest(URI, username, password);
                ftp.Method = WebRequestMethods.Ftp.ListDirectory;
                WebResponse response = ftp.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (mask.Trim() != string.Empty)
                    {
                        if (line.EndsWith(mask))
                        {
                            result.Append(line);
                            result.Append("\n");
                        }
                    }
                    else
                    {
                        result.Append(line);
                        result.Append("\n");
                    }
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch (Exception)
            {
                return null;
            }
        }
        private static string GetStringResponse(FtpWebRequest ftp)
        {
            string result = "";
            using (FtpWebResponse response = (FtpWebResponse)ftp.GetResponse())
            {
                long size = response.ContentLength;
                using (Stream datastream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(datastream, System.Text.Encoding.Default))
                    {
                        result = sr.ReadToEnd();
                        sr.Close();
                    }
                    datastream.Close();
                }
                response.Close();
            }
            return result;
        }

        private static FtpWebRequest GetRequest(string URI, string username, string password)
        {
            //根据服务器信息FtpWebRequest创建类的对象
            FtpWebRequest result = (FtpWebRequest)FtpWebRequest.Create(URI);
            //提供身份验证信息
            result.Credentials = new System.Net.NetworkCredential(username, password);
            //设置请求完成之后是否保持到FTP服务器的控制连接，默认值为true
            result.KeepAlive = false;
            return result;
        }
    }
}
