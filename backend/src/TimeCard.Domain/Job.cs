using System.ComponentModel.DataAnnotations.Schema;

namespace TimeCard.Domain;

[Table(name: "Jobs")]
public class Job
{
    public string JobId { get; set; }
    public string JobType { get; set; }
    public DateTime DateCreated { get; set; }
    public string ClientName { get; set; }
    public string ClientPhone { get; set; }
    public string ClientContactName { get; set; }
    public List<JobCard>? JobCards { get; set; }
}