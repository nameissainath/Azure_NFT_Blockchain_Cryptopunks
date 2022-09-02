using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nethereum.Web3;
using NftBot.Contracts.CryptoPunks;

namespace NftBot
{
  public class Startup
  {
    private const string EthereumNodeAddress = "https://cloudflare-eth.com/";
    private const string CryptoPunksAddress = "0xb47e3cd837dDF8e4c57F05d70Ab865de6e193BBB";

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddHttpClient().AddControllers().AddNewtonsoftJson();

      services.AddSingleton<BotFrameworkAuthentication, ConfigurationBotFrameworkAuthentication>();

      services.AddSingleton<IBotFrameworkHttpAdapter, AdapterWithErrorHandler>();

      services.AddTransient<Web3>(_ => new Web3(EthereumNodeAddress));

      services.AddTransient<CryptoPunksService>(sp => new(sp.GetRequiredService<Web3>(), CryptoPunksAddress));

      services.AddTransient<IBot, Bots.NftBot>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseDefaultFiles()
          .UseStaticFiles()
          .UseWebSockets()
          .UseRouting()
          .UseAuthorization()
          .UseEndpoints(endpoints =>
          {
            endpoints.MapControllers();
          });

      // app.UseHttpsRedirection();
    }
  }
}
