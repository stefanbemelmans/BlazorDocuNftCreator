﻿namespace nt.Client.Pages
{
  using nt.Client.Features.Base.Components;
  using nt.Client.Features.WebThree;
  using nt.Client.Features.WebThree.Components.NftTemplates;
  using nt.Shared.Features.WebThree;
  using AnySerializer;
  using System;
  using nt.Client.Features.WebThree.Actions.MintNft;
  using nt.Client.Features.WebThree.Components.NftTemplates.PurchaseOrder;

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

    public bool IsMinting { get; set; } = false;

    public void MintNft()
    {
      IsMinting = true;
        Console.WriteLine("Trying to Console...empty?");
      Console.WriteLine($"Mutable Data String is: {MutableDataString}");
        foreach (System.Reflection.PropertyInfo prop in FormData.GetType().GetProperties())
        {
          Console.WriteLine($"{prop.Name}: {prop.GetValue(FormData)}");
        }

      Type ObjectType = FormData.GetType();

      ImmutableObjectBase formDataToMint = FormData;
      Console.WriteLine($"trying new object type,{formDataToMint.GetType()}; NFTID: {CurrentNftTemplate.NftId}");
      Console.WriteLine($"{ObjectType} is FormData's Type");


      //PurchaseOrderData blah = formDataToMint;
      foreach (System.Reflection.PropertyInfo prop in formDataToMint.GetType().GetProperties())
      {
        Console.WriteLine($"{prop.Name}: {prop.GetValue(formDataToMint)}");
      }

      //byte[] serializedImmutableObject = Serializer.Serialize(FormData);

      //string serializedObjectAsBase64String = Convert.ToBase64String(serializedImmutableObject);

      //Mediator.Send(new MintNftOfTypeAction()
      //{
      //  ImmutableDataString = serializedObjectAsBase64String,
      //  MutableDataString = MutableDataString,
      //  MintNftId = CurrentNftTemplate.NftId

      //});
      
    }
  }
}