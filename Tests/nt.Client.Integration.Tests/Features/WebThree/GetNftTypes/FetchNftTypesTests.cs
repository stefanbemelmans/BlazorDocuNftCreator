namespace nt.Client.Integration.Tests.Features.WebThree.GetNftTypes
{
  using MediatR;
  using Microsoft.AspNetCore.Components;
  using Microsoft.Extensions.DependencyInjection;
  using nt.Client.Features.WebThree;
  using nt.Client.Features.WebThree.Actions;
  using nt.Client.Integration.Tests.Infrastructure;
  using nt.Shared.Features.WebThree;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;
  using Shouldly;
  using System;
  using System.Collections.Generic;
  using System.Net.Http;
  using System.Threading.Tasks;

  internal class FetchNftTypesTests
  {
    private HttpClient HttpClient { get; }
    private IMediator Mediator { get; }
    private IServiceProvider ServiceProvider { get; }

    public FetchNftTypesTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      HttpClient = ServiceProvider.GetService<HttpClient>();
    }

    public async Task ClientActionTest()
    {
      var Action = new GetNftTypesClientFeaturesAction();

      WebThreeState ActionResponse = await Mediator.Send(Action);

      ActionResponse.ShouldNotBe(null);
      ActionResponse.TotalNftTypes.ShouldBe((uint)2);
    }

    public async Task Should_Fetch_NftTypes()
    {
      var fetchNftTypes = new GetNftTypesClientFeaturesAction();

      WebThreeState response = await Mediator.Send(fetchNftTypes);

      response.TotalNftTypes.ShouldBe((uint)2);
    }

    public async Task Should_Generate_NftTypesList()
    {
      var nftTypeList = new List<NftTemplate>();
      var nftTypeDict = new Dictionary<uint, NftTemplate>();

      var fetchNftTypes = new GetNftTypesClientFeaturesAction();

      WebThreeState response = await Mediator.Send(fetchNftTypes);

      int NumOfTemplates = (int)response.TotalNftTypes;
      // Nft templates are not zero indexed.
      for (uint ctr = 1; ctr <= NumOfTemplates; ctr++)
      {
        string requestUri = GetNftByTypeSharedRequest.RouteFactory((int)ctr);

        GetNftByTypeSharedResponse templateResponse = await HttpClient.GetJsonAsync<GetNftByTypeSharedResponse>(requestUri);
        templateResponse.NftTypeDto.ShouldBeOfType<NftTemplate>();
        //var template = new NftTemplate()
        //{
        //    Name = templateResponse.NftTypeDto.Name,
        //    Symbol = templateResponse.NftTypeDto.Symbol,
        //    MintLimit = templateResponse.NftTypeDto.MintLimit,
        //    AttachedTokens = templateResponse.NftTypeDto.AttachedTokens
        //};
        nftTypeList[(int)ctr] = templateResponse.NftTypeDto;
        //  NftTypeDict[ctr] = templateResponse;
        //
      }

      nftTypeList.Count.ShouldBeGreaterThan(1);
      nftTypeList[1].Name.ShouldBe("Purchase Order");
      nftTypeList[2].Name.ShouldBe("Purchase Requeset");
    }

    public async Task Should_Generate_NftTypesListWithIds()
    {
      var NftTypeList = new List<NftTemplate>();

      var fetchNftTypes = new GetNftTypesClientFeaturesAction();

      WebThreeState response = await Mediator.Send(fetchNftTypes);

      int NumOfTemplates = (int)response.TotalNftTypes;
      // Nft templates are not zero indexed.
      for (uint ctr = 1; ctr <= NumOfTemplates; ctr++)
      {
        string requestUri = GetNftByTypeSharedRequest.RouteFactory((int)ctr);

        GetNftByTypeSharedResponse templateResponse = await HttpClient.GetJsonAsync<GetNftByTypeSharedResponse>(requestUri);
        templateResponse.NftTypeDto.ShouldBeOfType<NftTemplate>();
        var template = new NftTemplate()
        {
          NftId = ctr,
          Name = templateResponse.NftTypeDto.Name,
          Symbol = templateResponse.NftTypeDto.Symbol,
          MintLimit = templateResponse.NftTypeDto.MintLimit,
          AttachedTokens = templateResponse.NftTypeDto.AttachedTokens
        };
        NftTypeList.Add(template);
        //  NftTypeDict[ctr] = templateResponse;
        //
      }

      NftTypeList.Count.ShouldBe(2);

      NftTypeList[1].Name.ShouldBe("Purchase Order");
      NftTypeList[2].Name.ShouldBe("Purchase Requeset");
    }
  }
}