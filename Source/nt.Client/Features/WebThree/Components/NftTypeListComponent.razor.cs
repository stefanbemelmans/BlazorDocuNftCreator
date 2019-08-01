namespace nt.Client.Features.WebThree.Components
{
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.Base.Components;
  using nt.Client.Features.WebThree.Actions.ChangeCurrentNft;
  using nt.Shared.Features.WebThree;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  public class NftTypeListComponentModel : BaseComponent
  {
    public List<NftTemplate> NftDataList => WebThreeState.TemplateDataList;

    public int CurrentNftType => WebThreeState.CurrentNftTypeIndex;

    //public void SelectNftTemplate(UIChangeEventArgs eventArgs)
    //{

    //  var changeNftRequest = new ChangeCurrentNftAction()
    //  {
    //    NewNftTypeIndex = eventArgs.Key 
    //  }
    }
  }



