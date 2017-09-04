using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Utils
{
   public class FileUtil
    {
        /// <summary>
        /// 保存一个文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="response">http响应</param>
        public static string SaveFile(string directory,HttpWebResponse response)
        {
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return string.Empty;//找不到则直接返回null
            }

           
            string fileDir = DateTime.Now.ToString("yyyyMMddhhmmss")+Guid.NewGuid().ToString();
            string dirSum = Path.Combine(directory, fileDir);
            if (!Directory.Exists(dirSum))
                Directory.CreateDirectory(dirSum);
            string fileinfo = response.Headers["Content-Disposition"];
            var url = response.ResponseUri.ToString();
            string filename = response.Headers["Content-Disposition"] != null ?
                   response.Headers["Content-Disposition"].Replace("attachment; filename=", "").Replace("\"", "") :
                   response.Headers["Location"] != null ? Path.GetFileName(response.Headers["Location"]) :
                   url.Contains('?') || url.Contains('=')||url.Contains('.') ?
                   Path.GetFileName(url) : Guid.NewGuid().ToString();
            string filepath = Path.Combine(dirSum, filename);
            // 转换为byte类型
            using (System.IO.Stream stream = response.GetResponseStream())
            {
                //创建本地文件写入流
                using (Stream fs = new FileStream(filepath, FileMode.Create))
                {
                    byte[] bArr = new byte[1024];
                    int size = stream.Read(bArr, 0, (int)bArr.Length);
                    while (size > 0)
                    {
                        fs.Write(bArr, 0, size);
                        size = stream.Read(bArr, 0, (int)bArr.Length);
                    }
                }
            }
            return filepath;
        }
        /// <summary>
        /// 清空一个目录
        /// </summary>
        /// <param name="srcPath"></param>
        public static void ClearDir(string srcPath)
        {
            if (!Directory.Exists(srcPath))
            {
                return;
            }
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// 删除过期文件及文件夹
        /// </summary>
        /// <param name="srcPath"></param>
        /// <param name="timeSpan"></param>
        public static void ClearDirByDate(string srcPath, TimeSpan timeSpan)
        {
            DirectoryInfo dir = new DirectoryInfo(srcPath);
            FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
            foreach (FileSystemInfo i in fileinfo)
            {
                if (DateTime.Now - i.CreationTime > timeSpan)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);

                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
            }
        }
    }
}
