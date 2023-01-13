
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AuthService.Application.Features.Users.Queries.GenerateLoginUri;
using AuthService.Application.Models;
using Moq;
using Shouldly;
using Xunit;

namespace LitterService.Application.UnitTests.Features.Lits.Queries
{

    public class GenerateLoginUriQueryHandlerTests
    {
        public GenerateLoginUriQueryHandlerTests()
        {
        }
        [Fact]
        public async Task Handle_Url_ShouldContainMandatoryOAuthQueryParams()
        {
            //Arrange
            var query = new GenerateLoginUriQuery();
            var oAuthOptions = new Mock<OAuthOptions>();
            var sut = new GenerateLoginUriQueryHandler(oAuthOptions.Object);

            //Act
            var result = await sut.Handle(query, new CancellationToken());

            //Assert
            result.ShouldContain("client_id=");
            result.ShouldContain("redirect_uri=");
            result.ShouldContain("scope=");
            result.ShouldContain("state=");
        }
    }
}