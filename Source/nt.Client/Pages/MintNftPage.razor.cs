namespace nt.Client.Pages
{
  using AnySerializer;
  using nt.Client.Features.Base.Components;
  using nt.Client.Features.WebThree;
  using nt.Client.Features.WebThree.Actions.MintNft;
  using nt.Client.Features.WebThree.Components.NftTemplates;
  using nt.Shared.Features.WebThree;
  using System;

  public class MintNftPageModel : BaseComponent
  {
    public NftTemplate CurrentNftTemplate
    {
      get => WebThreeState.CurrentNftTemplate;
      set { }
    }

    public ImmutableObjectBase FormData
    {
      get => WebThreeState.ImmutableObject;
      set { }
    }


    public bool HasMinted { get; set; } = false;
    public bool IsMinting { get; set; } = false;

    public string MutableDataString
    {
      get => WebThreeState.MutableDataString;
      set { }
    }
    public bool ShowMintingButton { get; set; } = true;

    // These values are gotten in the AssetNftPageModel Init
    public uint TotalNfts
    {
      get => WebThreeState.TotalNftTypes;
      set { }
    }


    public async void MintNft()
    {
      ShowMintingButton = false;
      IsMinting = true;
      
      byte[] serializedImmutableObject = Serializer.Serialize(FormData);

      string serializedObjectAsBase64String = Convert.ToBase64String(serializedImmutableObject);

      WebThreeState mintingResponse = await Mediator.Send(new MintNftOfTypeClientAction()
      {
        ImmutableDataString = serializedObjectAsBase64String,
        MutableDataString = MutableDataString,
        MintNftId = CurrentNftTemplate.NftId
      });

      IsMinting = false;
      HasMinted = true;
    }

    public void ToggleHasMinted()
    {
      HasMinted = !HasMinted;
      ToggleIsMinting();
    }

    public void ToggleIsMinting() => IsMinting = !IsMinting;

    public void ToggleMintingButton() => ShowMintingButton = !ShowMintingButton;
  }
}