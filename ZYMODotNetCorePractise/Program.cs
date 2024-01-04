using AKLMPSTYZDotNetCore.ConsoleApp.RefitExamples;
using ConsoleApp.DapperExamples;
using ZYMODotNetCorePractise.EFCoreExamples;
// AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
// adoDotNetExample.Run();

// UserAdoDotNet userAdoDotNet = new UserAdoDotNet();
// userAdoDotNet.Run();

//UserDapperService userDapper = new UserDapperService();
//userDapper.Run();
// UserDapper userDapper = new UserDapper();
// userDapper.Run();

// HttpClientExample httpClientExample = new HttpClientExample();
// await httpClientExample.Run();


//RestClientExample restClientExample = new RestClientExample();
//await restClientExample.Run();

Console.WriteLine("Please wait for api...");

Console.ReadKey();
RefitExample refitExample = new RefitExample();
await refitExample.Run();

Console.ReadKey();
