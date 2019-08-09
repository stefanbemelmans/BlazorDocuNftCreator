namespace nt.Client.Integration.Tests.Features.WebThree.GetNftTypes
{
  using BlazorState;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using nt.Client.Features.WebThree;
  using nt.Client.Features.WebThree.Actions.AddFormDataToState;
  using nt.Client.Features.WebThree.Components.NftTemplates;
  using nt.Client.Integration.Tests.Infrastructure;
  using Shouldly;
  using System;
  using System.Threading.Tasks;

  internal class WebThreeStateTests
  {
    private IMediator Mediator { get; }
    private IServiceProvider ServiceProvider { get; }
    private IStore Store { get; }
    private WebThreeState webThreeState { get; set; }

    public WebThreeStateTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Store = ServiceProvider.GetService<IStore>();
      Mediator = ServiceProvider.GetService<IMediator>();
    }

    public async Task  WebThreeState_Get_Form_Data()
    {
      var formData = new ImmutableObjectBase()
      {
        Title = "TestFormTitle"
      };
      string MutableDataTestString = "Mutable Data Test Words";
      var SendFormInfo = new AddFormDataToStateAction()
      {
        FormObjectValues = formData,
        MutableDataString = MutableDataTestString
      };


      WebThreeState SendFormDataResponse = await Mediator.Send(SendFormInfo);

      SendFormDataResponse.ImmutableObject.Title.ShouldBe("TestFormTitle");
      SendFormDataResponse.MutableDataString.ShouldBe("Mutable Data Test Words");
    }

    public void WebThreeState_Should_Exist()
    {
      webThreeState = Store.GetState<WebThreeState>();

      webThreeState.ShouldNotBe(null);

      webThreeState.OwnedTokenIdList.Count.ShouldBe(0);
    }
  }
}