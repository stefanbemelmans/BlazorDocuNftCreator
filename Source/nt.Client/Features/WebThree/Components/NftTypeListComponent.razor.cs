namespace nt.Client.Features.WebThree.Components
{
    using Microsoft.AspNetCore.Components;
    using nt.Client.Features.Base.Components;
    using nt.Client.Features.WebThree.Actions.ChangeCurrentNft;
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

        //public NftTemplate SelectedTemplate { get; set; }
       public void SetNewNft(UIChangeEventArgs eventArgs)
        {
            string templateName = eventArgs.Value.ToString();
            Console.WriteLine(templateName);
            Mediator.Send(new ChangeCurrentNftAction() { TemplateName = templateName });
        }
    }
}



