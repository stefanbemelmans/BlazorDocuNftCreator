namespace nt.Client.Features.Nft.Components
{
  public class NftTemplate
    {
        string OwnerEthAddress { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }

        public string Symbol { get; set; }

        public int MintLimit { get; set; }

        public int AttachedTokens { get; set; }

    }

}