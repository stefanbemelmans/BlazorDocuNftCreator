﻿namespace nt.Client.Features.WebThree.Components.NftTemplates.PurchaseOrder
{
  using Microsoft.AspNetCore.Components;
  using System;
  using System.Collections.Generic;

  public class PurchaseOrderData : ImmutableObjectBase
  {
   
    public string Approver { get; set; }

    public DateTime DeliveryDate { get; set; } = DateTime.Now;

    public string Department { get; set; }

    public string Item_Code { get; set; }

    public int Item_Discount { get; set; }

    public string Item_Name { get; set; }

    public string Item_Price { get; set; }

    public int Item_Qty { get; set; }

    public int Item_Total { get; set; }

    public string Notes { get; set; }

    public string Requester { get; set; }
  }
}