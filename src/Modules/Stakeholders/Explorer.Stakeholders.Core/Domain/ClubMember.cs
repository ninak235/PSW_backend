using Explorer.BuildingBlocks.Core.Domain;
using System;

namespace Explorer.Stakeholders.Core.Domain;

public class ClubMember : Entity
{
    public long UserId { get; init; }
    public long ClubId { get; init; }


    public ClubMember()
    {

    }

    public ClubMember(long userId, long clubId)
    {

        UserId = userId;
        ClubId = clubId;

        Validate();
    }

    private void Validate()
    {
        if (UserId == 0) throw new ArgumentException("Invalid UserId");
        if (ClubId == 0) throw new ArgumentException("Invalid ClubOwnerId");

    }
}

