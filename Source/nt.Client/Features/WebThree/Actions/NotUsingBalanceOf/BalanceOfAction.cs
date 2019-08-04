namespace nt.Client.Features.WebThree.Actions.BalanceOf
{
    using MediatR;

    public class BalanceOfAction : IRequest<WebThreeState>
    {
        public uint TokenId { get; set; }
    }
}
