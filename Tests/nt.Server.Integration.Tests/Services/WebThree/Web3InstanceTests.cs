
namespace nt.Server.Integration.Tests.Services.WebThree
{
  using System;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using nt.Server.Services.WebThree.Instance;
  using Shouldly;

  class Web3InstanceTests
  {
    public Web3InstanceTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      NethInstance = ServiceProvider.GetService<NethWeb3>();
    }

    private IServiceProvider ServiceProvider { get; }
    private IMediator Mediator { get; }
    private NethWeb3 NethInstance { get; set; }

    public void Web3ShouldNotBeNull() => NethInstance.Instance.ShouldNotBeNull();
  }
}
