using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Stakeholders.Core.Domain
{
    public class ClubMember : Entity
    {
        public long ClubId { get; init; }
        public long UserId { get; init; }

        public ClubMember(long clubId, long userId)
        {
            ClubId = clubId;
            UserId = userId;
        }

    }
}
