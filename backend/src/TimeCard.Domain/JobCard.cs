using System.ComponentModel.DataAnnotations.Schema;

namespace TimeCard.Domain;

[Table(name: "JobCards")]
public class JobCard
{
    public int JobCardId { get; set; }
    public int EmployeeId { get; set; }
    public string JobId { get; set; }
    public Job? Job { get; set; }
    public DateTime DateWorked { get; set; }
    public Employee? Employee { get; set; }
    public double HoursWorked { get; set; }
}
