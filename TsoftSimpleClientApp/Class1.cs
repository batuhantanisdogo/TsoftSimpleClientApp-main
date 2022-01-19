using Bussiness.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RestSharp;
using TsoftSimpleClientApp.Models;
using TsoftSimpleClientApp.Services;

namespace TsoftSimpleClientApp;

public class Class1
{
    public void main(params string[] args)
    {
        var serviceProvider = new ServiceCollection();
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddJsonFile(Directory.GetCurrentDirectory() + "/appsettings.json");
        var configs = configurationBuilder.Build();
        serviceProvider.Configure<TsoftRequestModel>(configs.GetSection("TsoftRequestModel"));

        serviceProvider.AddSingleton<ITsfotClient, TsoftClientService>();
        serviceProvider.AddLogging();
        using var services = serviceProvider.BuildServiceProvider();
        var client = services.GetRequiredService<ITsfotClient>();
        var productRequest = new RestRequest($"product/get");
        productRequest.Method = Method.Post;

        var prdcts = client.RequestByUrl<List<ProductResponse>>(productRequest);
    }
}