namespace nt.Shared.Features.WebThree.Contracts.Herc1155.BalanceOf
{
    using nt.Shared.Features.Base;
    using MediatR;

    public class BalanceOfSharedRequest : BaseRequest, IRequest<BalanceOfSharedResponse>
    {
        public const string Route = "api/balanceOf";

        public uint ViewTokenId { get; set; }

        public static string RouteFactory(int aId) => $"api/balanceOf?ViewTokenId={aId}";
    }

}