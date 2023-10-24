using Explorer.API.Controllers.Administrator.Administration;
using Explorer.API.Controllers.Tourist;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Infrastructure.Database;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Tests.Integration.Club
{
    [Collection("Sequential")]
    public class ClubRequestCommandTests : BaseStakeholdersIntegrationTest
    {
        public ClubRequestCommandTests(StakeholdersTestFactory factory) : base(factory) { }

        [Fact]
        public void Sends_request()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
            var invitation = new ClubRequestDto
            {
                ClubRequestId = 1, 
                UserId = 123,      
                ClubId = 456,     
                Status = "PENDING"
            };

            // Act

            var result = controller.SendRequest(invitation);

            // Assert
            Assert.IsType<NoContentResult>(result);

        }

        private static ClubRequestController CreateController(IServiceScope scope)
        {
            return new ClubRequestController(scope.ServiceProvider.GetRequiredService<IClubRequestService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}