namespace nt.Client.Features.WebThree.Components
{
    using nt.Client.Features.Base.Components;
    using nt.Client.Features.WebThree.Components.NftTemplates;
    using nt.Shared.Features.WebThree;
    using System;

    public class MintNftTemplateComponentModel : BaseComponent
    {
        public PurchaseOrderTemplate TemplateFormProperties = new PurchaseOrderTemplate();


        public NftTemplate CurrentNftTemplate => WebThreeState.CurrentNftTemplate;
        

        public void PrintValues()
        {
            foreach (System.Reflection.PropertyInfo prop in TemplateFormProperties.GetType().GetProperties())
            {
                Console.WriteLine($"{prop.ToString()}: {prop.ToString()}");
            }
        }
    }
}