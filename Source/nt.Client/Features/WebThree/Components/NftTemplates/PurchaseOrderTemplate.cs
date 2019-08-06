using System;
using TypeSupport.Extensions;

namespace nt.Client.Features.WebThree.Components.NftTemplates
{
    public class ItemTemplate
    {
        public string Code { get; set; } = "";
        public string Discount { get; set; } = "";
        public string Name { get; set; } = "";
        public string Price { get; set; } = "";
        public int Qty { get; set; } = 0;
        public int Total { get; set; } = 0;
    }

    public class PurchaseOrderTemplate : ImmutableDataObjectBase
    {
        public string Approver { get; set; } = "";

        public DateTime DeliveryDate => DateTime.Now;

        public string Department { get; set; } = "";

        public ItemTemplate ItemTemplate = new ItemTemplate();

        public string Notes { get; set; } = "";

        public string Requester { get; set; } = "";

        public PurchaseOrderTemplate()
        {
            PropList.Add(this.GetProperties(0));
        }
    }
}