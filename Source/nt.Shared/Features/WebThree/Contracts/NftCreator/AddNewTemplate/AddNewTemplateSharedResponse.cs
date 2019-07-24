using System;
using System.Collections.Generic;
using System.Text;

namespace nt.Shared.Features.WebThree.Contracts.NftCreator.AddNewTemplate
{
  class AddNewTemplateSharedResponse
  {
    Nethereum.RPC.Eth.DTOs.TransactionReceipt NewTemplateTransactionReceipt { get; set; }

  }
}
