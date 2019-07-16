namespace nt.Server
{
  using BlazorState;
  using MediatR;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.ResponseCompression;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Hosting;
  using System.Linq;
  using nt.Shared.Constants.AccountAddresses;
  using nt.Shared.Constants.WebThree;
  using Nethereum;
  using System.Reflection;
  using Nethereum.Web3;
  using Nethereum.Contracts;
  using nt.Shared.Constants;

  public class Startup
  {
    public void Configure
    (
      IApplicationBuilder aApplicationBuilder,
      IWebHostEnvironment aWebHostEnvironment
    )
    {
      aApplicationBuilder.UseResponseCompression();

      if (aWebHostEnvironment.IsDevelopment())
      {
        aApplicationBuilder.UseDeveloperExceptionPage();
        aApplicationBuilder.UseBlazorDebugging();
      }

      aApplicationBuilder.UseRouting();
      aApplicationBuilder.UseEndpoints
      (
        aEndpointRouteBuilder =>
        {
          aEndpointRouteBuilder.MapControllers(); // We use explicit attribute routing so dont need MapDefaultControllerRoute
          aEndpointRouteBuilder.MapBlazorHub();
          aEndpointRouteBuilder.MapFallbackToPage("/_Host");
        }
      );
      aApplicationBuilder.UseClientSideBlazorFiles<Client.Startup>();
    }

    public void ConfigureServices(IServiceCollection aServiceCollection)
    {
      aServiceCollection.AddRazorPages();
      aServiceCollection.AddServerSideBlazor();

      aServiceCollection.AddMvc();

      aServiceCollection.AddResponseCompression
      (
        aResponseCompressionOptions =>
          aResponseCompressionOptions.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat
          (
            new[] { "application/octet-stream" }
          )
      );

      aServiceCollection.AddBlazorState
      (
        (aOptions) => aOptions.Assemblies =
          new Assembly[]
          {
            typeof(Client.Startup).GetTypeInfo().Assembly
          }
      );
      // gotta build the web3 class;
      aServiceCollection.AddSingleton(new Web3(TestEthAccounts.TesterAcct, Web3Endpoints.RinkebyEndpoint));
      aServiceCollection.AddSingleton<Contract>( new Services.WebThree.Contracts.NftCreator.ContractInstance.NftCreatorInstance());
      new Client.Startup().ConfigureServices(aServiceCollection);

      aServiceCollection.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

      aServiceCollection.Scan
      (
        aTypeSourceSelector => aTypeSourceSelector
          .FromAssemblyOf<Startup>()
          .AddClasses()
          .AsSelf()
          .WithScopedLifetime()
      );
    }
  }
}