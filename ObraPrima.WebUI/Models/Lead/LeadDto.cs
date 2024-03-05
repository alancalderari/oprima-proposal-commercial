using MudBlazor;
using ObraPrima.WebUI.Models.Proposal;

namespace ObraPrima.WebUI.Models.Lead;

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
        public Typo Typo { get; set; }
    }
}