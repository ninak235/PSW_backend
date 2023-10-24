using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Dtos;
public class ClubInvitationDto
{
    public long ClubInvitationId { get; set; }
    public long ClubId { get; set; }
    public long TouristId { get; set; }
    public string InvitationMessage { get; set; }
    public string InvitationStatus { get; set; }

}


