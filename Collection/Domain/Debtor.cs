using System;

namespace Domain;
public class Debtor
{
    public Debtor() {
        Status = true;
        CreationDate = DateTime.Now;
    }
    public int DebtorCode { get; set; }
    public string Document { get; set; }
    public string DocumentType { get; set; }
    public string Name { get; set; }
    public DateTime? BirthdayDate { get; set; }
    public string? Work { get; set; }
    public decimal? Salary { get; set; }
    public string CreatorUser { get; set; }
    public DateTime? CreationDate { get; set; }
    public string? ModifierUser { get; set; }
    public DateTime? ModificationDate { get; set; }
    public bool Status { get; set; }
}
