using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  public class PurchaseRequestTemplate
  {
    public int NftId = 4;
    struct Item
    {
     public string StockNumber { get; set; }
     public string Description { get; set; }
     public string Qty { get; set; }
     public string UnitPrice { get; set; }
     public string ExtendedCost { get; set; }

    }

    struct PurchaseRequest
    {
     public string Date { get; set; }
     public string Requester { get; set; }
     public string Department { get; set; }
     public string ChargeTo { get; set; }
     public string Vendor { get; set; }
     public string VendorAddress { get; set; }
     public string VendorContact { get; set; }
     public string Phone { get; set; }
     public string DateNeeded { get; set; }
     public string ShipVia { get; set; }
    }
  }
}
