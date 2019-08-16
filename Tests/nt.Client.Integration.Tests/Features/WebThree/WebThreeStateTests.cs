namespace nt.Client.Integration.Tests.Features.WebThree.WebThreeStateTests
{
  using BlazorState;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using nt.Client.Features.WebThree;
  using nt.Client.Features.WebThree.Actions.AddFormDataToState;
  using nt.Client.Features.WebThree.Components.NftTemplates;
  using nt.Client.Features.WebThree.Components.NftTemplates.PurchaseOrder;
  using nt.Client.Integration.Tests.Infrastructure;
  using Shouldly;
  using System;
  using System.Threading.Tasks;
  using TypeSupport.Extensions;

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

    public async Task WebThreeState_Get_Form_Data()
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

    public async Task WebThreeState_ShouldAdd_FormDataObjectToSTate()
    {
      var formData = new PurchaseOrderData()
      {
        Approver = "I approve",
        Title = "NewTestFormTitle",
        DeliveryDate = DateTime.Now,
        Department = "DepartMentData",
        Item_Code = "ITem Code Data",
        Item_Discount = 42,
        Item_Name = "TEst ITem Name",
        Item_Price = "Item_Price data",
        Item_Qty = 42,
        Item_Total = 42,
        Notes = "Here are some notes",
        Requester = "The Request is success"
      };
      string MutableDataTestString = "Mutable Data Test Words With a Full Model";
      var SendFormInfo = new AddFormDataToStateAction()
      {
        FormObjectValues = formData,
        MutableDataString = MutableDataTestString
      };

      WebThreeState SendFormDataResponse = await Mediator.Send(SendFormInfo);

      SendFormDataResponse.ImmutableObject.Title.ShouldBe("NewTestFormTitle");
      SendFormDataResponse.MutableDataString.ShouldBe("Mutable Data Test Words With a Full Model");

      WebThreeState ControlWebThreeState = Store.GetState<WebThreeState>();

      ControlWebThreeState.ImmutableObject.Title.ShouldBe("NewTestFormTitle");
      ControlWebThreeState.ImmutableObject.GetProperty("Approver").GetValue(ControlWebThreeState.ImmutableObject).ShouldBe("I approve");
      ControlWebThreeState.ImmutableObject.GetProperty("Item_Total").GetValue(ControlWebThreeState.ImmutableObject).ShouldBe(42);

      //ImmutableObjectBase ControlImmutableObj = ControlWebThreeState.ImmutableObject;
      //ImmutableObjectBase TestedImmutableObj = SendFormDataResponse.ImmutableObject;

      //ControlWebThreeState.ImmutableObject.Title.ShouldBe("Mutable Data Test Words With a Full Model");


      //System.Reflection.PropertyInfo[] Control_ImmutableObjectParams = ControlWebThreeState.ImmutableObject.GetType().GetProperties();

      //foreach (System.Reflection.PropertyInfo prop in Control_ImmutableObjectParams)
      //{
      //  var testValue =
      //}

      //static object GetValue(System.Reflection.PropertyInfo PropName, object TargetObj)
      //{
      //  return PropName.GetValue(TargetObj);
      //}
    }
  }
}