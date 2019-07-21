using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  public class BillOfLadingTemplate
  {
    public int NftId = 6;
    struct Bill_Of_Lading
    {
      string Lading;
      string Order;
      string PO;
      string date;
      string Carrier;
      string Shipper;
      string Consignee;
      string Instructions;
    }
    struct Item
    {
      string ItemCode;
      string Quantity;
      string Weight;
      string Details;
    }
  }
}
