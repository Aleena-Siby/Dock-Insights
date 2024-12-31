using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class VesselProjects
{
    [Key]
    public int SlNo { get; set; }

    [Column("ManagementName")]
    public string ManagementName { get; set; }

    [Column("VesselName")]
    public string VesselName { get; set; }

    [Column("ProjectName")]
    public string ProjectName { get; set; }

    [Column("SurveyDueDate")]
    public DateTime SurveyDueDate { get; set; }

    [Column("ProjectCreatedDate")]
    public DateTime ProjectCreatedDate { get; set; }

    [Column("Stage")]
    public string Stage { get; set; }

    [Column("FinalizedYard")]
    public string FinalizedYard { get; set; }

    [Column("TotalSpecCount")]
    public int TotalSpecCount { get; set; }

    [Column("LastActivityDate")]
    public DateTime LastActivityDate { get; set; }
}