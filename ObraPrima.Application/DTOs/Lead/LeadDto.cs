using System.ComponentModel;
using ObraPrima.Application.DTOs.Proposal;
using ObraPrima.Application.Mappings.Proposal;
using ObraPrima.Domain.Context.Entities;

namespace ObraPrima.Application.DTOs.Lead;

public record LeadDto
{
    public int Id { get; set; }
    public string? CompanyName { get; set; }
    public string? ResponsibleName { get; set; }
    public string? ResponsibleEmail { get; set; }
    public string? ResponsiblePhone { get; set; }
    public List<TimelineEvent>? TimelineEvents { get; set; }
    public SupplierDto? Supplier { get; set; }
    public ProposalDto? Proposal { get; set; }
    public record SupplierDto()
    {
        public string? SupplierName { get; set; } 
        public string? SupplierEmail { get; set; } 
        public string? SupplierPhone { get; set; } 
    }
    public record TimelineEvent
    {
        public int ProporalId { get; set; }
        public DateTime? DateEvent { get; set; }
        public string Event { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public int Typo { get; set; }

        public TimelineEvent(EEventType eEventType, DateTime dateEvent, string description, int proposalId)
        {
            DateEvent = dateEvent;
            Description = description;
            
            switch (eEventType)
            {
                case EEventType.Created:
                    Event = nameof(EEventType.Created);
                    Color = "#009688";
                    Typo = (int)TypeText.H6;
                    break;
                case EEventType.Sended:
                    Event = nameof(EEventType.Sended);
                    Color = "#2196F3";
                    Typo = (int)TypeText.H6;
                    break;
                case EEventType.Refused:
                    Event = nameof(EEventType.Refused);
                    Color = "#F44336";
                    Typo = (int)TypeText.H6;
                    break;
                case EEventType.Aproved:
                    Event = nameof(EEventType.Aproved);
                    Color = "#81C784";
                    Typo = (int)TypeText.H6;
                    break;
                case EEventType.Signed:
                    Event = nameof(EEventType.Signed);
                    Color = "#4CAF50";
                    Typo = (int)TypeText.H6;
                    break;
                default:
                    Event = "Updated";
                    Color = "#BDBDBD";
                    Typo = (int)TypeText.Body1;
                    break;
            }
        }
        private enum TypeText
        {
            H6 = 6,
            Body1=9,
        }
    }
}