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
    public class ClubInvitationTests : BaseStakeholdersIntegrationTest
    {
        public ClubInvitationTests(StakeholdersTestFactory factory) : base(factory) {}

        [Fact]
        public void Sends_invite()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
            var invitation = new ClubInvitationDto
            {
                ClubId = -1,
                TouristId = -1,
                InvitationMessage = "generic invitation message",
                InvitationStatus = "SENT"
            };

            // Act

            var result = controller.SendInvite(invitation);

            // Assert
            Assert.IsType<NoContentResult>(result);

        }

        private static ClubInvitationController CreateController(IServiceScope scope)
        {
            return new ClubInvitationController(scope.ServiceProvider.GetRequiredService<IClubInvitationService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
