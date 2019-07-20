namespace nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType
{
  
    public class NftTemplate
    {
      public int Type { get; set; }
      public string Name { get; set; }

      public string Symbol { get; set; }

      public int MintLimit { get; set; }

      public int AttachedTokens { get; set; }

    }

}
