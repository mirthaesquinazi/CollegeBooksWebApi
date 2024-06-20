using CollegeBooks.Api.Controllers;
using Microsoft.AspNetCore.Http;
using Moq.AutoMock;

namespace CollegeBooks.UnitTests.Api
{
    public abstract class ApiBaseControllerTests<T> where T : ApiBaseController
    {
        protected readonly T Controller;
        protected readonly AutoMocker Mocker;

        protected ApiBaseControllerTests()
        {
            Mocker = new AutoMocker();

            var httpResponseMock = Mocker.GetMock<HttpResponse>(true);
            httpResponseMock.Setup(mock => mock.Headers).Returns(new HeaderDictionary());

            var httpRequestMock = Mocker.GetMock<HttpRequest>(true);

            var httpContextMock = Mocker.GetMock<HttpContext>(true);
            httpContextMock.Setup(mock => mock.Response).Returns(httpResponseMock.Object);
            httpContextMock.Setup(mock => mock.Request).Returns(httpRequestMock.Object);

            Controller = Mocker.CreateInstance<T>();
            Controller.ControllerContext.HttpContext = httpContextMock.Object;
        }
    }
}
