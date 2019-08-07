using Microsoft.AspNetCore.Components;
using nt.Client.Features.Base.Components;
using nt.Client.Features.WebThree.Components.NftTemplates.PurchaseOrder;
using nt.Client.Features.WebThree;
using nt.Client.Features.WebThree.Components.NftTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  public class DocumentComponentModel : BaseComponent
  {
    [Parameter]
    public uint NftId { get; set; }
    public PurchaseOrderTemplate PurchaseOrderTemplate { get; set; } = new PurchaseOrderTemplate();
 
  }
}
