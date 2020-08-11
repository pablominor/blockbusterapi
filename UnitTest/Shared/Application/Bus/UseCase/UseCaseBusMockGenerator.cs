using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Bus.UseCase;
using Moq;

namespace UnitTest.Shared.Application.Bus.UseCase
{
    public class UseCaseBusMockGenerator
    {

        public static Mock<IUseCaseBus> CreateUseCaseBusThatDispatchAnyRequest()
        {
            Mock<IUseCaseBus> useCaseBus = new Mock<IUseCaseBus>();
            useCaseBus.Setup(o => o.Dispatch(It.IsAny<IRequest>()));
            return useCaseBus;
        }

        public static Mock<IUseCaseBus> CreateUseCaseBusThatReturnResponse(IResponse response)
        {
            Mock<IUseCaseBus> useCaseBus = new Mock<IUseCaseBus>();
            useCaseBus.Setup(o => o.Dispatch(It.IsAny<IRequest>())).Returns(response);
            return useCaseBus;
        }

    }
}
