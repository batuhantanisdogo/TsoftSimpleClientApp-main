// See https://aka.ms/new-console-template for more information

using Bussiness.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using TsoftConsoleApp.Models;
using TsoftSimpleClientApp.Models;
using TsoftSimpleClientApp.Services;

var serviceProvider = new ServiceCollection();
var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile(Directory.GetCurrentDirectory() + "/appsettings.json");
var configs = configurationBuilder.Build();
serviceProvider.Configure<TsoftRequestModel>(configs.GetSection("TsoftRequestModel")); // Bu İşlemden Sonra IOptions<T> den appsetting.json daki tüm değerlere ulaşabiliriz

serviceProvider.AddSingleton<ITsfotClient, TsoftClientService>();
serviceProvider.AddLogging();

using var services = serviceProvider.BuildServiceProvider();
var client = services.GetRequiredService<ITsfotClient>();
var productRequest = new RestRequest($"product/get");
productRequest.Method = Method.Post;

var prdcts = await  client.RequestByUrl<List<GetProductModel>>(productRequest);

Console.ReadLine();