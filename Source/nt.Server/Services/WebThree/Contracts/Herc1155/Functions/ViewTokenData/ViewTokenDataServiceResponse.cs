namespace nt.Server.Services.WebThree.Contracts.Herc1155.Functions
{
  using nt.Shared.Features.Base;
  using nt.Shared.Features.WebThree;
    public class ViewTokenDataServiceResponse : BaseResponse
    {
    public byte[] SerializedTokenData { get; set; }
    public uint TokenType { get; set; }
    }
}
