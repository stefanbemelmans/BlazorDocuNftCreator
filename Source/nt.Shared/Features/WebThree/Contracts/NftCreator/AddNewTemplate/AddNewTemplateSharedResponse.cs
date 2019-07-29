
namespace nt.Shared.Features.WebThree.Contracts.NftCreator.AddNewTemplate
{
  using nt.Shared.Features.Base;
  public class AddNewTemplateSharedResponse : BaseResponse
  {
    public Nethereum.RPC.Eth.DTOs.TransactionReceipt NewTemplateTransactionReceipt { get; set; }

  }
}
