namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.Base.Components;
  using nt.Client.Features.WebThree.Components.NftTemplates.PurchaseOrder;
  using nt.Client.Features.WebThree.Components.NftTemplates.BillOfLading;
  using nt.Client.Features.WebThree.Components.NftTemplates.PurchaseRequest;
  using nt.Client.Features.WebThree.Components.NftTemplates.RequestForProposal;
  using nt.Client.Features.WebThree.Components.NftTemplates.RequestForQuotation;

  public class DocumentComponentModel : BaseComponent
  {
    [Parameter]
    public uint NftId { get; set; }
    public PurchaseOrderTemplate PurchaseOrderTemplate { get; set; } = new PurchaseOrderTemplate();

    public BillOfLadingTemplate BillOfLadingTemplate { get; set; } = new BillOfLadingTemplate();

    public PurchaseRequestTemplate PurchaseRequestTemplate { get; set; } = new PurchaseRequestTemplate();

    public RequestForProposalTemplate RequestForProposalTemplate { get; set; } = new RequestForProposalTemplate();

    public RequestForQuotationTemplate RequestForQuotoationTemplate { get; set; } = new RequestForQuotationTemplate();


  }
}
