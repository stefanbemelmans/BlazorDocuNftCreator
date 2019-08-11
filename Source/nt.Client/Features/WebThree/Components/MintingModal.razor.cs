using Microsoft.AspNetCore.Components;
using nt.Client.Features.Base.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nt.Client.Features.WebThree.Components
{
  public class MintingModalModel : BaseComponent
  {
    [Parameter]
    public bool IsMinting { get; set; } = false;

    public void ChangeModalState() => IsMinting = !IsMinting;

  }
}
