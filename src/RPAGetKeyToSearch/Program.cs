using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using RPAProjectTool;

namespace RPAGetKeyToSearch
{
    internal class Program
    {
        public static async Task Main()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 50,
            });

            ConsoleLogServer.DefaultLog("打开博客园，获取第一行博客数据");
            var pageBoKeYuan = await browser.NewPageAsync();
            await pageBoKeYuan.GotoAsync("https://www.cnblogs.com/");
            var responseResults = await pageBoKeYuan.TextContentAsync(".post-item-title:first-child");

            ConsoleLogServer.DefaultLog("打开百度，进行搜索");
            var pageBaiDu = await browser.NewPageAsync();
            await pageBaiDu.GotoAsync("https://www.baidu.com/");

            //文本输入
            await pageBaiDu.FillAsync("#kw", responseResults);

            await pageBaiDu.ClickAsync("#su");

            ConsoleLogServer.SucceedLog("搜索完成");

            Console.ReadLine();
        }
    }
}
