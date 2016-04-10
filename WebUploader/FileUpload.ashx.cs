using System;
using System.Web;
using System.IO;
using System.Text;

namespace WebUploader
{
    /// <summary>
    /// FileUpload 的摘要说明
    /// </summary>
    public class FileUpload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //指定字符集
            context.Response.ContentEncoding = Encoding.UTF8;
            if (context.Request["REQUEST_METHOD"] == "OPTIONS")
            {
                context.Response.End();
            }
            SaveFile(context);
        }
        /// <summary>
        /// 文件保存操作
        /// </summary>
        /// <param name="basePath"></param>
        private void SaveFile(HttpContext context,string basePath = "~/Upload/Images/")
        {
            var name = string.Empty;
            basePath = (basePath.IndexOf("~") > -1) ? context.Server.MapPath(basePath) :
            basePath;
            HttpFileCollection files = context.Request.Files;
            //如果目录不存在，则创建目录
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }

            var suffix = files[0].ContentType.Split('/');
            //获取文件格式
            var _suffix = suffix[1].Equals("jpeg", StringComparison.CurrentCultureIgnoreCase) ? "" : suffix[1];
            Random rand = new Random(24 * (int)DateTime.Now.Ticks);
            name = rand.Next() + "." + _suffix;
            //文件保存
            var full = basePath + name;
            files[0].SaveAs(full);
            var _result = "{\"jsonrpc\" : \"2.0\", \"result\" : null, \"id\" : \"" + name + "\"}";
            context.Response.Write(_result);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}