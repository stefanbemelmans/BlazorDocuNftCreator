namespace nt.Client.Features.WebThree.Components
{
  using nt.Client.Features.Base.Components;
  using nt.Client.Features.WebThree.Components.NftTemplates;
  using System;
  using System.Collections.Generic;

  public class MintNftTemplateComponentModel : BaseComponent
  {
    
    public MintNftTemplateComponentModel()
    {
      BuildInputs();
    }

    public TemplateBase TokenTypeInfo { get; set; }

    public Dictionary<object, object> FormInputs;

    public void BuildInputs()
    {
      foreach (System.Reflection.PropertyInfo prop in TokenTypeInfo.GetType().GetProperties())
      {
        FormInputs.Add(prop.ToString(), prop.GetType());
      }
    }

    public void PrintValues()
    {
      foreach(System.Reflection.PropertyInfo prop in TokenTypeInfo.GetType().GetProperties())
      {
        Console.WriteLine($"{prop.ToString()}: {prop.ToString()}"); 
      }
    }

    

  }
}
    
