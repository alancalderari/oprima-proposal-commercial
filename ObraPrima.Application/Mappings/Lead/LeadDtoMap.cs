using ObraPrima.Application.DTOs.Lead;
using ObraPrima.Application.Mappings.Proposal;

namespace ObraPrima.Application.Mappings.Lead;

public static class LeadDtoMap
{
    public static LeadDto ToDto(this Domain.Context.Entities.Lead lead)
    {
        lead.Proposal?.ProposalHistories?.Reverse();
        
        return new LeadDto
        {
            Id = lead.Id,
            CompanyName = lead.CompanyName,
            ResponsibleName = lead.PersonName,
            ResponsibleEmail = lead.Email.Address,
            ResponsiblePhone = lead.PersonPhone,
            Supplier = new LeadDto.SupplierDto
            {
                SupplierName = lead.Supplier?.Name,
                SupplierEmail = lead.Supplier?.Email,
                SupplierPhone = lead.Supplier?.Phone
            },
            Proposal = lead.Proposal?.ToDto(),
            TimelineEvents = lead.Proposal?.ProposalHistories?.Select(x => new LeadDto.TimelineEvent(x.EventType, x.EventDate, x.Description, x.ProposalId)).ToList()
        };
    }
}