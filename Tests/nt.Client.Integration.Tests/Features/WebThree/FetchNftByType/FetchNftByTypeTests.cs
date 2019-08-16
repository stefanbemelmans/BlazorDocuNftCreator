namespace nt.Client.Integration.Tests.Features.WebThree.GetNftList
{
  using System;
  using Shouldly;
  using nt.Client.Features.WebThree;
  using nt.Client.Integration.Tests.Infrastructure;
  using Microsoft.Extensions.DependencyInjection;
  using MediatR;
  using System.Threading.Tasks;
  using System.Net.Http;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;
  using Microsoft.AspNetCore.Components;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftCount;
  using nt.Shared.Features.WebThree;
  using System.Collections.Generic;

  internal class FetchNftByTypeTests
  {
    private IMediator Mediator { get; }
    private HttpClient HttpClient { get; }
    private IServiceProvider ServiceProvider { get; }
    public FetchNftByTypeTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      HttpClient = ServiceProvider.GetService<HttpClient>();
    }


    public async Task ClientHttpTest()
    {

      string url = GetNftByTypeSharedRequest.RouteFactory(1);


      GetNftByTypeSharedResponse Nft = await HttpClient.GetJsonAsync<GetNftByTypeSharedResponse>(url);

      Nft.ShouldNotBe(null);
      Nft.NftTypeDto.Name.ShouldBe("Purchase Order");

    }

    public async Task BuildTemplateLIst()
    {
      //  Arrange
      GetNftCountSharedResponse countResponse = await HttpClient.GetJsonAsync<GetNftCountSharedResponse>(GetNftCountSharedRequest.Route);
           
      var nftList = new List<NftTemplate>();
      
      // Act
      for(int nft = 1; nft <= countResponse.NftCount; nft++)
      {
        GetNftByTypeSharedResponse nftType = await HttpClient.GetJsonAsync<GetNftByTypeSharedResponse>(GetNftByTypeSharedRequest.RouteFactory(nft));

        nftList.Add(nftType.NftTypeDto);
      }

      // Assert

      nftList.Count.ShouldBe(2);

      nftList[0].Name.ShouldBe("Purchase Order");
      nftList[1].Name.ShouldBe("Purchase Requeset");



    }
   
  }
}
