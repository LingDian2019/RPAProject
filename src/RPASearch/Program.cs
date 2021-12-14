using System;
using System.Threading.Tasks;
using RPAProjectTool;
using Microsoft.Playwright;

namespace RPASearch
{
    internal class Program
    {
        public static async Task Main()
        {
            ConsoleLogServer.DefaultLog("打开百度网页，并进行搜索");

            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 50,
            });
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://www.baidu.com/");

            //文本输入
            await page.FillAsync("#kw", "RPA");

            await page.ClickAsync("#su");

            ConsoleLogServer.SucceedLog("搜索完成");

            Console.ReadLine();
        }
    }
}
