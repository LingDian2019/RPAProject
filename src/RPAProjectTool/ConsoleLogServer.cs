using System.Drawing;
using Console = Colorful.Console;

namespace RPAProjectTool
{
    /// <summary>
    /// 控制台日志服务
    /// </summary>
    public static class ConsoleLogServer
    {
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message">消息</param>
        public static void DefaultLog(string message)
        {
            Console.WriteLine(message, Color.White);
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message">消息</param>
        public static void WarnLog(string message)
        {
            Console.WriteLine(message, Color.Yellow);
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message">消息</param>
        public static void ErrorLog(string message)
        {
            Console.WriteLine(message, Color.Red);
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message">消息</param>
        public static void SucceedLog(string message)
        {
            Console.WriteLine(message, Color.Green);
        }
    }
}
