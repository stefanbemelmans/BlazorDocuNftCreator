﻿namespace nt.Client.Integration.Tests.Features.Counter
{
  using nt.Client.Features.Counter;
  using nt.Client.Integration.Tests.Infrastructure;
  using BlazorState;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using System;
  using System.Threading.Tasks;

  internal class IncrementCounterTests
  {
    private CounterState CounterState { get; set; }
    private IMediator Mediator { get; }
    private IServiceProvider ServiceProvider { get; }
    private IStore Store { get; }

    public IncrementCounterTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      Store = ServiceProvider.GetService<IStore>();
      CounterState = Store.GetState<CounterState>();
    }

    public async Task Should_Decrement_Counter()
    {
      //Arrange
      CounterState.Initialize(aCount: 15);

      var incrementCounterRequest = new IncrementCounterAction
      {
        Amount = -2
      };

      //Act
      CounterState = await Mediator.Send(incrementCounterRequest);

      //Assert
      CounterState.Count.ShouldBe(13);
    }

    public async Task Should_Increment_Counter()
    {
      //Arrange
      CounterState.Initialize(aCount: 22);

      var incrementCounterRequest = new IncrementCounterAction
      {
        Amount = 5
      };

      //Act
      CounterState = await Mediator.Send(incrementCounterRequest);

      //Assert
      CounterState.Count.ShouldBe(27);
    }
  }
}