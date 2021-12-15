using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using RPAProjectTool;


namespace RPADownload
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

            ConsoleLogServer.DefaultLog("下载文件");
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://dotnet.microsoft.com/en-us/download");
            // Start the task of waiting for the download
            //var waitForDownloadTask = page.WaitForDownloadAsync();
            // Perform the action that initiates download
            //
            var responseResults = await page.TextContentAsync("css=[data-bi-name='Download']");
            await page.ClickAsync("css=[data-bi-name='Download']");
            // Wait for the download process to complete
            //var download = await waitForDownloadTask;
            //var path = await download.PathAsync();

            ConsoleLogServer.SucceedLog("下载完成");

            Console.ReadLine();
        }
    }
}
