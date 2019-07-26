namespace nt.Server.Integration.Tests.Features.WebThree.Contracts.NftCreator
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using Shouldly;
    using MediatR;
    using System.Threading.Tasks;
    using nt.Shared.Features.WebThree.Contracts.NftCreator.AddNewTemplate;
    using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftTypes;
  using nt.Shared.Features.WebThree.Contracts.NftCreator.GetNftByType;

  class AddNewTemplateTests
    {
        public AddNewTemplateTests(TestFixture aTestFixture)
        {
            ServiceProvider = aTestFixture.ServiceProvider;
            Mediator = ServiceProvider.GetService<IMediator>();
        }

        private IServiceProvider ServiceProvider { get; }
        private IMediator Mediator { get; }

        public async Task ShouldCreateServerFeaturesNftTemplate()
        {
            var getNftTypeRequest = new AddNewTemplateSharedRequest();
            GetNftTypesSharedResponse totalTypesBeforeTest = await Mediator.Send(new GetNftTypesSharedRequest());

            AddNewTemplateSharedResponse response = await Mediator.Send( new AddNewTemplateSharedRequest
            {
              NewTemplateName = "Server Feature Test Template",
              NewTemplateSymbol = "SFTT",
              NewTemplateMintLimit = 1000,
              NewTemplateAttachedTokens = 0
            }
            );

            GetNftTypesSharedResponse totalTypesAfterTest = await Mediator.Send(new GetNftTypesSharedRequest());

            response.NewTemplateTransactionReceipt.ShouldNotBe(null);

            totalTypesAfterTest.TotalNftTypes.ShouldBeGreaterThan(totalTypesBeforeTest.TotalNftTypes);

            var newTemplateData = await Mediator.Send(new GetNftByTypeSharedRequest
            {
                GetNftType = (uint)totalTypesAfterTest.TotalNftTypes
            }
            );

            newTemplateData.NftTypeData.Name.ShouldMatch("Server Feature Test Template");
            newTemplateData.NftTypeData.Symbol.ShouldMatch("SFTT");
            newTemplateData.NftTypeData.MintLimit.ShouldBe(1000);
        }
    }
}
