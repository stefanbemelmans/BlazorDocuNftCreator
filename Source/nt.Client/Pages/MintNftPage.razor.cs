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

    public int NewTokenId
    {
      get => WebThreeState.NewTokenId;

      set { }
    }

    public bool ShowMintingButton { get; set; } = true;

    // These values are gotten in the AssetNftPageModel Init
    public uint TotalNfts
    {
      get => WebThreeState.TotalNftTypes;
      set { }
    }

    public string TransactionHash
    {
      get => WebThreeState.TransactionHash;
      set { }
    }

    public async void MintNft()
    {
      ShowMintingButton = false;
      IsMinting = true;
      Console.WriteLine("Trying to Console...empty?");
      Console.WriteLine($"Mutable Data String is: {MutableDataString}");
      Console.WriteLine($"Type of FormData {FormData.GetType()}");
      foreach (System.Reflection.PropertyInfo prop in FormData.GetType().GetProperties())
      {
        Console.WriteLine($"{prop.Name}: {prop.GetValue(FormData)}");
      }

      byte[] serializedImmutableObject = Serializer.Serialize(FormData);

      string serializedObjectAsBase64String = Convert.ToBase64String(serializedImmutableObject);

      WebThreeState MintingResponse = await Mediator.Send(new MintNftOfTypeAction()
      {
        ImmutableDataString = serializedObjectAsBase64String,
        MutableDataString = MutableDataString,
        MintNftId = CurrentNftTemplate.NftId
      });

      TransactionHash = MintingResponse.TransactionHash;
      NewTokenId = MintingResponse.NewTokenId;
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