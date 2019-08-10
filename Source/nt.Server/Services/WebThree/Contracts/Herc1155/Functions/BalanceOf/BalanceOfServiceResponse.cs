namespace nt.Server.Services.WebThree.Contracts.Herc1155.BalanceOf
{ 
  using nt.Shared.Features.Base;
  using nt.Shared.Features.WebThree;
  using System.Collections.Generic;
    using System.Numerics;

    public class BalanceOfServiceResponse : BaseResponse
    {
    public int Balance { get; set; }
    }
}
