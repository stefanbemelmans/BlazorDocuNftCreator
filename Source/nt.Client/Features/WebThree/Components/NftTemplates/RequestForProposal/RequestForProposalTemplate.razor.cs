namespace nt.Client.Features.WebThree.Components.NftTemplates.RequestForProposal
{
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.Base.Components;
  using nt.Client.Features.WebThree.Actions.AddFormDataToState;
  using nt.Client.Features.WebThree.Components.NftTemplates;
  using System;
  using System.Threading.Tasks;

  public class RequestForProposalTemplateModel : BaseComponent
  {
    [Parameter]
    public RequestForProposalData FormData { get; set; } = new RequestForProposalData();
    
    public string MutableDataString { get; set; }

    public RequestForProposalTemplateModel()
    {
      FormData.Title = "Request For Proposal";
    }

    public async void SendDataToState()
    {
      ConsoleData();
      WebThreeState response = await Mediator.Send(new AddFormDataToStateAction()
      {
        FormObjectValues = FormData,
        MutableDataString = MutableDataString
      });

      WebThreeState.CollectedFormValues.FormValues = response.CollectedFormValues.FormValues;
      WebThreeState.CollectedFormValues.MutableDataString = response.CollectedFormValues.MutableDataString;

     
    }

    public void ConsoleData()
    {
      Console.WriteLine("Trying to Console...empty?");
      foreach (System.Reflection.PropertyInfo prop in FormData.GetType().GetProperties())
      {
        Console.WriteLine($"{prop.Name}: {prop.GetValue(FormData)}");
      }
    }
  }
}