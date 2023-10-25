using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class ClubInvitationService : CrudService<ClubInvitationDto, ClubInvitation>, IClubInvitationService
    {
        private readonly IUserService _userService;
        public ClubInvitationService(ICrudRepository<ClubInvitation> repository, IMapper mapper, IUserService userService) : base(repository, mapper) 
        {
            _userService = userService;
        }

        public Result<PagedResult<UserDto>> GetTourists(long clubId)
        {
            var result = _userService.GetAll();
            var tourists = new List<UserDto>();

            if (result.IsSuccess)
            {
                PagedResult<UserDto> users = result.Value;
                PagedResult<ClubInvitationDto> invitations = GetAll();
               

                foreach(var user in users.Results) 
                {
                    bool shouldAdd = true;
                    foreach (ClubInvitationDto i  in invitations.Results)
                    {
                        // provera za turistu fali
                        if(i.ClubId == clubId && i.InvitationStatus != "DECLINED" && user.id == i.TouristId)
                        {
                            shouldAdd = false;
                            break;
                        }
                    }
                    if (shouldAdd)
                    {
                        tourists.Add(user);
                    }
                }
            }

            var touristsResult = new PagedResult<UserDto>(tourists, tourists.Count);
            

            return touristsResult;
        }

        public Result<ClubInvitationDto> SendInvite(ClubInvitationDto invitation)
        {
            Result<PagedResult<ClubInvitationDto>> invitationsResult = GetPaged(0, 0);
            if (invitationsResult.IsSuccess)
            {
                PagedResult<ClubInvitationDto> invitations = invitationsResult.Value;

                foreach (ClubInvitationDto i in invitations.Results)
                {
                    if(i.TouristId == invitation.TouristId && i.InvitationStatus != "DECLINED")
                    {
                        //throw new Exception("There is an invite already sent to this tourist ! ");
                    }
                }
            }
            
            Create(invitation);
            return null;
        }

        public Result<PagedResult<ClubMemberDto>> GetMembers(long clubId)
        {

            throw new NotImplementedException();
        }

        private PagedResult<ClubInvitationDto> GetAll()
        {
            return GetPaged(0, 0).Value;
        }
    }
}
