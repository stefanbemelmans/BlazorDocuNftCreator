namespace nt.Client.Pages
{
  using nt.Client.Features.Base.Components;
  using nt.Client.Features.WebThree;
  using nt.Client.Features.WebThree.Components.NftTemplates;
  using nt.Shared.Features.WebThree;
  using  nt.Client.Features.WebThree.Components;
  using System;

  public class MintNftPageModel : BaseComponent
  {
    public NftTemplate CurrentNftTemplate
    {
      get => WebThreeState.CurrentNftTemplate;
      set { }
    }

    // These values are gotten in the AssetNftPageModel Init
    public uint TotalNfts
    {
      get => WebThreeState.TotalNftTypes;
      set { }
    }

    public ImmutableObjectBase FormData
    {
      get => WebThreeState.ImmutableObject;
      set { }
    }

    public string MutableDataString
    {
      get => WebThreeState.MutableDataString;
      set { }
    }

    public void MintNft()
    {
    
        Console.WriteLine("Trying to Console...empty?");
      Console.WriteLine($"Mutable Data String is: {MutableDataString}");
        foreach (System.Reflection.PropertyInfo prop in FormData.GetType().GetProperties())
        {
          Console.WriteLine($"{prop.Name}: {prop.GetValue(FormData)}");
        }
    }
  }
}