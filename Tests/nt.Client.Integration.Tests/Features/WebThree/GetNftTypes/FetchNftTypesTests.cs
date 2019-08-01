namespace nt.Client.Integration.Tests.Features.WebThree.GetNftTypes
{
  using System;
  using Shouldly;
  using nt.Client.Features.WebThree;
  using nt.Client.Integration.Tests.Infrastructure;
  using Microsoft.Extensions.DependencyInjection;
  using MediatR;
  using System.Threading.Tasks;
  using System.Net.Http;
  using nt.Client.Features.WebThree.Actions;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;
  using Microsoft.AspNetCore.Components;
  using nt.Shared.Features.WebThree;
  using System.Collections.Generic;

  internal class FetchNftTypesTests
  {
    private IMediator Mediator { get; }
    private IServiceProvider ServiceProvider { get; }
    private HttpClient HttpClient { get; }
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
      ActionResponse.TotalNftTypes.ShouldBeGreaterThan((uint)2);

    }

    public async Task Should_Fetch_NftTypes()
    {
      var fetchNftTypes = new GetNftTypesClientFeaturesAction();

      WebThreeState response = await Mediator.Send(fetchNftTypes);

      response.TotalNftTypes.ShouldBeGreaterThan((uint)2);
    }

    public async Task Should_Generate_NftTypesList()
    {
      var NftTypeList = new List<NftTemplate>();
      var NftTypeDict = new Dictionary<uint, NftTemplate>();

      var fetchNftTypes = new GetNftByTypeAction();

      WebThreeState response = await Mediator.Send(fetchNftTypes);

      int NumOfTemplates = (int)response.TotalNftTypes;

      for (uint ctr = 1; ctr < NumOfTemplates; ctr++)
      {
        string requestUri = GetNftByTypeSharedRequest.RouteFactory((int)ctr);

        GetNftByTypeSharedResponse templateResponse = await HttpClient.GetJsonAsync<GetNftByTypeSharedResponse>(requestUri);
        templateResponse.NftTypeData.ShouldBeOfType<NftTemplate>();
        //  NftTypeList.Add(templateResponse);
        //  NftTypeDict[ctr] = templateResponse;
        //
      }

      //NftTypeList.Count.ShouldBe(3);

      //NftTypeList[3].Name.ShouldBe("TesterTemplate_0");
      //NftTypeDict[4].Name.ShouldBe("TesterTemplate_0");
    }

  }
}
