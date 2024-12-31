using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace  backend.Models
{


public class DryDockDue
{
    [Key]
    public int SlNo { get; set; }

    [Column("ManagementName")] // Ensure column names match the DB
    public string ManagementName { get; set; }

    [Column("VesselName")]
    public string VesselName { get; set; }

    [Column("SurveyDueDate")]
    public DateTime SurveyDueDate { get; set; }
}}