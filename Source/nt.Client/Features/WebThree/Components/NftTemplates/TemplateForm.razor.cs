namespace nt.Client.Features.WebThree.Components.NftTemplates
{
  using System.Collections;
  using System.Collections.Generic;
  using nt.Shared.Features.WebThree;

  public class TemplateFormBase 
  {
    //public TemplateFormBase()
    //{
    //  NftProps = new Dictionary<string, string>();
    //}
    public uint NftId { get; set; }

    public string Name { get; set; }
    public string Symbol { get; set; }
    public uint MintLimit { get; set; }
    public uint AttachedTokens { get; set; }


   public Dictionary<string, string> NftProps;


  }
}
