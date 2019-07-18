
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
      NethInstance = ServiceProvider.GetService<NethWeb3>();
    }

    private IServiceProvider ServiceProvider { get; }
    private NethWeb3 NethInstance { get; set; }

    public void Web3ShouldNotBeNull() => NethInstance.Instance.ShouldNotBeNull();
  }
}
