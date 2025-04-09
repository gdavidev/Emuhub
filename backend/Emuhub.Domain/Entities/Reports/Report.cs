using Emuhub.Domain.Entities.Users;

namespace Emuhub.Domain.Entities.Reports;

public enum ReportSolutionStatus
{
    NONE,
    DEFERRED,
    UNDEFERRED
}

public class Report
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required User Author { get; set; }
    public User? Attendant { get; set; }
    public ReportSolutionStatus SolutionStatus { get; set; }
}
