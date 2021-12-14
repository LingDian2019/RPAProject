using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using RPAProjectTool;

namespace RPAScreenshot
{
    internal class Program
    {
        public static async Task Main()
        {
            ConsoleLogServer.DefaultLog("打开网页，并截图保存");

            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 50,
            });
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://playwright.dev/dotnet");

            //截图
            await page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot.png" });

            ConsoleLogServer.SucceedLog("截图完成");

            Console.ReadLine();
        }
    }
}
