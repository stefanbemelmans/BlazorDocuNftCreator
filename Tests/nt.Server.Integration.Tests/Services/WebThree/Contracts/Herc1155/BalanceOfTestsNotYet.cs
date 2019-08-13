using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Threading.Tasks;
using nt.Server.Services.WebThree.Contracts.Herc1155.ContractInstance;
using nt.Server.Services.WebThree.Instance;
using nt.Server.Services.WebThree.Contracts.Herc1155.BalanceOf;
using nt.Shared.Features.WebThree.Contracts.Herc1155.BalanceOf;

namespace nt.Server.Integration.Tests.Services.WebThree.Contracts.Herc1155
{
    class BalanceOfTests
    {
        public BalanceOfTests(TestFixture aTestFixture)
        {
            ServiceProvider = aTestFixture.ServiceProvider;
            Mediator = ServiceProvider.GetService<IMediator>();
            NethWeb3 = ServiceProvider.GetService<NethWeb3>();
            Herc1155 = ServiceProvider.GetService<Herc1155Instance>();
            //NFtCreator = ServiceProvider.GetService<NftCreatorInstance>();
        }

        private IServiceProvider ServiceProvider { get; }
        private IMediator Mediator { get; }
        private NethWeb3 NethWeb3 { get; set; }
        private Herc1155Instance Herc1155 { get; set; }
        //private NftCreatorInstance NFtCreator { get; set; }

        public async Task ShouldGetTokenBalance()
        { // 
          // Arrange
          //
      BalanceOfServiceResponse response = await Mediator.Send(new BalanceOfServiceRequest()
            {
                TokenId = 5
            });

            response.ShouldNotBe(null);
            response.Balance.ShouldBe(1);
        }

        public async Task ShouldGetSharedTokenBalance()
        {
      BalanceOfSharedResponse response = await Mediator.Send(new BalanceOfSharedRequest()
            {
                ViewTokenId = 5
            });

            response.ShouldNotBe(null);
            response.Balance.ShouldBe(1);
        }

    }
}
