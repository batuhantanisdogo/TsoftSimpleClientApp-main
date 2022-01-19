using System.Net;
using Bussiness.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using TsoftSimpleClientApp.Helpers;
using TsoftSimpleClientApp.Models;

namespace TsoftSimpleClientApp.Services
{
    public class TsoftClientService : ITsfotClient
    {
        private ILogger<TsoftClientService> _logger;
        private readonly IOptions<TsoftRequestModel> _tsoftLoginModel;

        public TsoftClientService(
            ILogger<TsoftClientService> logger,
            IOptions<TsoftRequestModel> tsoftLoginModel
        )
        {
            _logger = logger;
            _tsoftLoginModel = tsoftLoginModel;
        }

        private RestClient _client;
        private LoginResponseModel LoginToken { get; set; }
        public RestClient Client => (_client ??= CreateClient());

        public async Task<T> RequestByUrl<T>(RestRequest param, Method method = RestSharp.Method.Post, bool silentNotification = false)
            where T : class, new()
        {
            var requestParameter = string.Format("{0} - Tsoft request parameters json:\n{1}",
                Common.ConvertIstanbulDateTime(DateTime.Now), JsonConvert.SerializeObject(
                    param.Parameters,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        Formatting = Formatting.Indented
                    }));
            try
            {
                using (_logger.BeginScope(this))
                {
                    try
                    {
                        var loginToken = await LoginTsoft();
                        if (loginToken.Token != null) param.AddOrUpdateParameter("token", loginToken.Token);
                        else
                        {
                            _logger.LogError("Login token is empty.");
                            return null;
                        }


                        param.Method = method;
                        var response = await Client.ExecuteAsync<T>(param);
                        try
                        {
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                var data = JsonConvert.DeserializeObject<BaseResponse<T>>(response.Content);
                                if (data != null && data.Success)
                                {
                                    var consoleMessage = string.Join(Environment.NewLine,
                                        data?.Message.Select(x => $"{x.Code}-{x.Id}-{string.Join(",", x.Text)}")
                                            .ToList() ??
                                        new List<string>());

                                    using (_logger.BeginScope("TsoftClientRequestScope"))
                                    {
                                        _logger.LogInformation((string.IsNullOrEmpty(consoleMessage)
                                                                   ? "request error but response message is empty."
                                                                   : consoleMessage));
                                    }
                                    
                                    return data.Data;
                                }
                                else
                                {
                                    var consoleMessage = string.Join(Environment.NewLine,
                                        data?.Message.Select(x => $"{x.Code}-{x.Id}-{string.Join(",", x.Text)}")
                                            .ToList() ??
                                        new List<string>());
                                    
                                    using (_logger.BeginScope("kjsdnfkjlsdnfgkjsjlfkjn"))
                                    {
                                        _logger.LogError((string.IsNullOrEmpty(consoleMessage)
                                                             ? "request error but response message is empty."
                                                             : consoleMessage));
                                    }
                                    
                                    return null;
                                }
                            }
                            else
                            {
                                using (_logger.BeginScope("ksjfhgkjdfhgblkjdfgnlkjdhngljkdnfjkgbn"))
                                {
                                    _logger.LogWarning(response.ErrorException,
                                        response.ErrorMessage);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            using (_logger.BeginScope("akjdh ajkhdjkabhfbkuahfbklajfkl"))
                            {
                                _logger.LogError(e,  "Tsoft request error");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                       
                        _logger.LogError(e, "Tsoft request error");
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

            return null;
        }

        private RestClient CreateClient()
        {
            var client = new RestClient(_tsoftLoginModel.Value.Url);
            client.UseJson();
            client.UseNewtonsoftJson();
            return client;
        }

        private async  Task<LoginResponseModel> LoginTsoft()
        {
            using (_logger.BeginScope(nameof(TsoftClientService) + "LoginTsoft"))
            {
                if (LoginToken is null || LoginToken.ExpirationTime <= DateTime.Now)
                {
                    var request = new RestRequest($"auth/login/{_tsoftLoginModel.Value.UserName}", Method.Post);
                    request.AddParameter("pass", _tsoftLoginModel.Value.Password);
                    var response = await Client.PostAsync(request);
                    try
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var data =
                                JsonConvert.DeserializeObject<BaseResponse<List<LoginResponseModel>>>(response.Content);
                            if (data != null && data.Success)
                            {
                                LoginToken = data.Data.FirstOrDefault();
                                return LoginToken;
                            }
                            else
                            {
                                var consoleMessage = string.Join(Environment.NewLine,
                                    data?.Message.Select(x => $"{x.Code}-{x.Id}-{string.Join(",", x.Text)}") ??
                                    new List<string>());
                                _logger.LogWarning(string.IsNullOrEmpty(consoleMessage)
                                    ? "request error but response message is empty."
                                    : consoleMessage);
                            }
                        }
                        else
                        {
                            _logger.LogWarning(response.ErrorException, response.ErrorMessage);
                        }
                    }
                    catch (Exception e)
                    {
                        return new LoginResponseModel();
                    }
                }
                else
                {
                    return LoginToken;
                }

                return new LoginResponseModel();
            }
        }
    }

    public interface ITsfotClient
    {
        Task<T>  RequestByUrl<T>(RestRequest param, Method method = Method.Post, bool silentNotification = true) where T : class, new();
    }
}