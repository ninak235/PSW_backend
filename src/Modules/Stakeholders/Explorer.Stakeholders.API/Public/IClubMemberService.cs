using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Public
{
    public interface IClubMemberService
    {
        Result<PagedResult<ClubMemberDto>> GetPaged(int page, int pageSize);
        Result<ClubMemberDto> Create(ClubMemberDto clubMember);
        Result<ClubMemberDto> Update(ClubMemberDto clubMember);
        Result Delete(int id);
    }
}