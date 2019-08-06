namespace nt.Client.Features.WebThree.Components.NftTemplates.PurchaseOrder
{
    using Microsoft.AspNetCore.Components;
    using nt.Client.Features.Base.Components;
    using System;
    public class PurchaseOrderTemplateModel : BaseComponent
    {
        [Parameter]
        public string Approver { get; set; }
        [Parameter]
        public DateTime DeliveryDate { get; set; } = DateTime.Now;
        [Parameter]
        public string Department { get; set; }
        [Parameter]
        public string Item_Code { get; set; }
        [Parameter]
        public string Item_Discount { get; set; }
        [Parameter]
        public string Item_Name { get; set; }
        [Parameter]
        public string Item_Price { get; set; }
        [Parameter]
        public int Item_Qty { get; set; }
        [Parameter]
        public int Item_Total { get; set; }
        [Parameter]
        public string Notes { get; set; }
        [Parameter]
        public string Requester { get; set; }
        
        public string Title => "Purchase Order";


        public void PrintValues()
        {
            foreach (System.Reflection.PropertyInfo prop in this.GetType().GetProperties())
            {
                Console.WriteLine($"{prop.ToString()}: {prop.ToString()}");
            }
        }
        public PurchaseOrderTemplateModel()
        {

        }
    }
}