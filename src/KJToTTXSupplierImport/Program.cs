using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace KJToTTXSupplierImport
{
    internal class Program
    {
        public static async Task Main()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync();
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://playwright.dev/dotnet");
            //截图
            await page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot.png" });
            Console.ReadLine();
        }
    }
}
