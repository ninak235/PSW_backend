using Explorer.BuildingBlocks.Core.Domain;
using System;

namespace Explorer.Stakeholders.Core.Domain;

public enum RequestStatus
{
        PENDING,
        DECLINED,
        ACCEPTED
}

public class ClubRequest : Entity
{
        public long ClubRequestId { get; init; }
        public long UserId { get; init; }
        public long ClubOwnerId { get; init; }
        public RequestStatus Status { get; init; } 

        public ClubRequest()
        {
            Status = RequestStatus.PENDING; 
        }

        public ClubRequest(int clubRequestId,long userId,long clubOwnerId,RequestStatus status)
        {
            ClubRequestId = clubRequestId;
            UserId = userId;
            ClubOwnerId = clubOwnerId;
            Status = status;
            Validate();
        }

        private void Validate()
        {
             if (UserId == 0) throw new ArgumentException("Invalid UserId");
             if (ClubRequestId==0) throw new ArgumentException("Invalid ClubRequestId");
             if (ClubOwnerId==0) throw new ArgumentException("Invalid ClubOwnerId");
        
        }
}


