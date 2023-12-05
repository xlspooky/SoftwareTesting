// Copyright Information
// ==================================
// SoftwareTesting - PlaywrightTests - UserInterfaceTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

using Microsoft.Playwright;
using System.Diagnostics;

namespace PlaywrightTests;


public class UserInterfaceTests
{

    //https://medium.com/version-1/playwright-a-modern-end-to-end-testing-for-web-app-with-c-language-support-c55e931273ee#:~
    [Fact]
    public static async Task VerifyGoogleSearchForPlaywright()
    {
        
        using IPlaywright playwright = await Playwright.CreateAsync();
        await using var browser =
            await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions() { Headless = true, SlowMo = 50 });

        IBrowserContext context = await browser.NewContextAsync();

        IPage page = await context.NewPageAsync();
        //Navigate to Google.com
       /* await page.GotoAsync("https://google.com");
        IReadOnlyList<IFrame> f = page.Frames;
         if (f.Count > 1)
         {
             await f[1].ClickAsync("text=No thanks");
         }
        // Search Playwright
        await page.FillAsync("[aria-label=\"Search\"]", "Playwright");
        
        // Press Enter
        var response = await page.RunAndWaitForNavigationAsync(async () => await page.PressAsync("[aria-label=\"Search\"]", "Enter"));
        //Click on the first search option
        await page.ClickAsync("xpath=//h3[contains(text(),'Playwright: Fast and reliable end-to-end testing')]");
        //Verify Page URL
        Assert.Equal("https://playwright.dev/", page.Url);
        // Click text=Get started
        await page.ClickAsync("text=Get Started");
        //Verify Page URL
        Assert.Equal("https://playwright.dev/docs/intro", page.Url);*/

        //start of letsusedata login tests

        //navigate to letsusedata
        await page.GotoAsync("https://letsusedata.com/");

        
        //fill username for Test1
        await page.GetByPlaceholder("Your Username").ClickAsync();
        await page.GetByPlaceholder("Your Username").FillAsync("Test1");

        //fill password
        await page.GetByPlaceholder("Your Password").ClickAsync();
        await page.GetByPlaceholder("Your Password").FillAsync("12345678");

        //click login
        
        await page.GetByRole(AriaRole.Button, new() { NameString = "Login" }).ClickAsync();

        //checks the page to see if invalid password shows up
        await Assertions.Expect(page.Locator("body")).ToContainTextAsync("Invalid Password");
        

        //fill username for Test2
        await page.GetByPlaceholder("Your Username").ClickAsync();
        await page.GetByPlaceholder("Your Username").FillAsync("Test2");

        //fill password
        await page.GetByPlaceholder("Your Password").ClickAsync();
        await page.GetByPlaceholder("Your Password").FillAsync("iF3sBF7c");

        //click login
        await page.GetByRole(AriaRole.Button, new() { NameString = "Login" }).ClickAsync();

        //checks to see if Intro to Data Analytics class is there to verify the login was successful
        await Assertions.Expect(page.Locator("[id=\"\\31 14CourseTitle\"]")).ToContainTextAsync("Intro to Data Analytics");
    }


}