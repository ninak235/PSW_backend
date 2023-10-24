using Explorer.BuildingBlocks.Core.Domain;


namespace Explorer.Stakeholders.Core.Domain;

    public class ClubInvitation : Entity
    {
        public long ClubInvitationId { get; init; }
        public long ClubId { get; init; }
        public long TouristId { get; init; }
        public string InvitationMessage { get; init; }
        public ClubInvitationStatus InvitationStatus { get; init; }


        public ClubInvitation(long clubInvitationId, long clubId, long touristId, string invitationMessage) 
        {
            ClubInvitationId = clubInvitationId;
            ClubId = clubId;
            TouristId = touristId;
            InvitationMessage = invitationMessage;
            InvitationStatus = ClubInvitationStatus.SENT;
            Validate();
        }

        private void Validate()
        {
            if (ClubInvitationId < 0) throw new ArgumentException("Invalid ClubInvitationId");
            if (ClubId < 0) throw new ArgumentException("Invalid ClubId");
            if (TouristId < 0) throw new ArgumentException("Invalid TouristId");
        }
    }

public enum ClubInvitationStatus
{
    SENT,
    DECLINED,
    ACCEPTED
}

