
namespace nt.Server.Integration.Tests.Services.WebThree
{
  using System;
  using System.Threading.Tasks;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Nethereum.Contracts;
  using nt.Server.Services.WebThree.Contracts.NftCreator.ContractInstance;
  using nt.Server.Services.WebThree.Instance;
  using nt.Shared.Constants.ContractConstants.NftCreator;
  using Shouldly;
  class NftCreatorInstanceTests
  {
    public NftCreatorInstanceTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      NftCreatorInstance = ServiceProvider.GetService<NftCreatorInstance>();
    }

    private IServiceProvider ServiceProvider { get; }
    private IMediator Mediator { get; }
    private NftCreatorInstance NftCreatorInstance { get; set; }

    public void NftCreatorInstanceIsNotNullTests() => NftCreatorInstance.Instance.ShouldNotBe(null);

    public void InstanceShouldBeAContract() => NftCreatorInstance.Instance.ShouldBeOfType<Contract>();

    public void InstanceShouldHaveCorrectEthAddress()
    {
      string address = NftCreatorInstance.Instance.Address;

      address.ShouldBe(NftCreatorAddresses.NftCreatorRinkebyAddress);

    }



  }
}
