using ZYMODotNetCorePractise.EFCoreExamples;
// AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
// adoDotNetExample.Run();

// UserAdoDotNet userAdoDotNet = new UserAdoDotNet();
// userAdoDotNet.Run();

UserDapper userDapper = new UserDapper();
userDapper.Run();
// UserDapper userDapper = new UserDapper();
// userDapper.Run();

// HttpClientExample httpClientExample = new HttpClientExample();
// await httpClientExample.Run();

RestClientExample restClientExample = new RestClientExample();
await restClientExample.Run();

Console.ReadKey();
