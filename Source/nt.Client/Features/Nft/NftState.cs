using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorState;

namespace nt.Client.Features.Nft
{
  internal partial class NftState :State<NftState>
  {
    public int TotalNftTypes { get; set; }

    public int CurrentNftType { get; set; }

    public NftState() { }

    protected override void Initialize()
    {
      // Get TotalNftTypesAction
      TotalNftTypes = 5;
    }
  }
}
