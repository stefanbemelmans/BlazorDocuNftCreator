namespace nt.Client.Features.WebThree.Components
{
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.Base.Components;
  using nt.Client.Features.WebThree.Actions.ChangeCurrentNft;
  using nt.Client.Features.WebThree.Components.NftTemplates;
  using nt.Client.Features.WebThree.Components.NftTemplates.PurchaseOrder;
  using nt.Shared.Features.WebThree;
  using System;
  using System.Collections.Generic;

  public class NftTypeListComponentModel : BaseComponent
  {
    public List<NftTemplate> NftDataList => WebThreeState.TemplateDataList;

    public NftTemplate CurrentNftTemplate
    {
      get => WebThreeState.CurrentNftTemplate;
      set { }
    }
    //public int CurrentNftType { get; set; } = 0;

    public PurchaseOrderTemplate Document { get; set; } = new PurchaseOrderTemplate();

    public PurchaseOrderData PoData { get; set; } = new PurchaseOrderData();

    //public NftTemplate SelectedTemplate { get; set; }
    public void SetNewNft(UIChangeEventArgs aEventArgs)
    {
      string templateName = aEventArgs.Value.ToString();
      Console.WriteLine(templateName);
      Mediator.Send(new ChangeCurrentNftAction() { TemplateName = templateName });
    }

    public PurchaseOrderTemplate GetDocument(uint NftType)
    {
      if (NftType == 5)
      {
        return Document;
      }
      else { return null; }

    }
  }
}




