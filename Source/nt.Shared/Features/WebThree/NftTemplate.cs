namespace nt.Shared.Features.WebThree
{
  using System.Collections;
  using System.Collections.Generic;
  public class NftTemplate : IEnumerable<NftTemplate>
    {
      public int Id { get; set; }
      public string Name { get; set; }

      public string Symbol { get; set; }

      public int MintLimit { get; set; }

      public int AttachedTokens { get; set; }

    public IEnumerator<NftTemplate> GetEnumerator() => throw new System.NotImplementedException();

    IEnumerator IEnumerable.GetEnumerator() => throw new System.NotImplementedException();
  }

}
