namespace nt.Server.Services.WebThree.Contracts.NftCreator.Functions.GetTotalNftTypes
{
  using MediatR;

  public class GetTotalNftTypesRequest : IRequest<GetTotalNftTypesResponse>
    {
      // An empty request as the function it is calling is a Call function on the Contract with no passed params.
    }
}
