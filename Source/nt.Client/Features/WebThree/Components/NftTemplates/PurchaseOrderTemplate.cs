using System;
using System.Collections.Generic;
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

    public class PurchaseOrderTemplate
    {
        public string Approver { get; set; } = "";
        public List<string> CleanItemPropertyList { get; }
        public List<string> CleanPropertyList { get; }
        public DateTime DeliveryDate => DateTime.Now;
        public string Department { get; set; } = "";
        public ICollection<TypeSupport.ExtendedProperty> ItemPropList { get; set; }
        public string Notes { get; set; } = "";
        public ICollection<TypeSupport.ExtendedProperty> PoPropList { get; set; }
        public string Requester { get; set; } = "";
        public string Title => "Purchase Order";

        public PurchaseOrderTemplate()
        {
            PoPropList = this.GetProperties(0);
            var ItemTemplate = new ItemTemplate();
            ItemPropList = ItemTemplate.GetProperties(0);
            CleanItemPropertyList = CleanPropList(ItemPropList);
            CleanPropertyList = CleanPropList(PoPropList);
           

        }

        public List<string> CleanPropList(ICollection<TypeSupport.ExtendedProperty> ListToClean)
        {
            List<string> PropNames = new List<string>();

            foreach (var property in ListToClean)
            {
                if (property.Name != "PoPropList" | property.Name != "ItemPropList" | property.Name != "CleanPropertyList" | property.Name != "CleanItemPropertyList")
                {
                    PropNames.Add(property.Name);
                }
            }
            return PropNames;
        }
    }
}