using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YaqeenDAL.Model
{
    public enum MedicationType
    {
        Tablet,
        LiquidFilledCapsule,
        Capsule,
        Cream,
        Device,
        Drops,
        Foam,
        Gel,
        Inhaler,
        Injection,
        Liquid,
        Lotion,
        Ointment,
        Patch,
        Powder,
        Spray,
        Suppository,
        Topical
    }

    public enum MedicationUnit
    {
        MG,
        MCG,
        G,
        ML,
        Percentage
    }

    public enum ScheduleFrequency
    {
        RegularIntervals,
        SpecificDays,
        AsNeeded
    }

    public enum DayOfTheWeek
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    public enum FrequencyInterval
    {
        EveryDay,
        Every8Hours,
        Every12Hours,
        EveryOtherDay
    }

    public enum ScheduleEntityType
    {
        Medication,
        RoutineTest,
        Appointment
    }

    [Index(nameof(UserId), IsUnique = false)]
    [Index(nameof(EntityType), nameof(UserId), IsUnique = false)]
    public class Schedule : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScheduleId { get; set; }
        public string CronExpression { get; set; }
        public string UserId { get; set; }
        public ScheduleEntityType EntityType { get; set; }
        [Column(TypeName = "jsonb")]
        public Dictionary<string, string> Entity { get; set; }
        public DateTime StartDate { get; set; }

        // Navigation Properties
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual ICollection<Symptom>? Symptom { get; set; }
    }


    [Index(nameof(UserId), IsUnique = false)]
    [Index(nameof(EntityType), nameof(UserId), IsUnique = false)]
    public class OneOffSchedule : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScheduleId { get; set; }
        public string UserId { get; set; }
        public ScheduleEntityType EntityType { get; set; }
        [Column(TypeName = "jsonb")]
        public Dictionary<string, string> Entity { get; set; }
        public DateTime StartDate { get; set; }

        // Navigation Properties
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual ICollection<Symptom>? Symptom { get; set; }
    }
    
    // [Index(nameof(PatientUserId), IsUnique = false)]
    // public class Medication : Entity
    // {
    //     [Key]
    //     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //     public int MedicationId { get; set; }
    //     public string PatientUserId { get; set; }
    //     public MedicationType Type { get; set; }
    //     public string Name { get; set; }
    //     public string? PhotoLink { get; set; }
    //     public MedicationUnit Unit { get; set; }
    //     public int StrengthTimes100 { get; set; }
    //     public int DosageTimes100 { get; set; }
    //     public Schedule? Schedule { get; set; }

    //     // Navigation Properties
    //     [ForeignKey("PatientUserId")]
    //     public virtual Patient Patient { get; set; }
    // }

    public class ScheduleInstance : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScheduleInstanceId { get; set; }
        public int ScheduleId { get; set; }
        public DateTime? Time { get; set; }
        public bool? Done { get; set; }
        public bool? Skipped { get; set; }
        public bool? Missed { get; set; }
        public string? Notes { get; set; }

        // Navigation Properties
        [ForeignKey("ScheduleId")]
        public virtual Schedule Schedule { get; set; }
    }

    public class SymptomLookup : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SymptomLookupId { get; set; }
        public string Name { get; set; }
        public int TranslationId { get; set; }
    }

    public class Symptom : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SymptomId { get; set; }
        public int SymptomLookupId { get; set; }
        public List<int>? SymptomLookupIds { get; set; }
        public string PatientUserId { get; set; }
        public DateTime? Time { get; set; }
        public string Details { get; set; }
        public string? PhotoLink { get; set; }
        public string? Notes { get; set; }

        // Navigation Properties
        [ForeignKey("PatientUserId")]
        public virtual Patient Patient { get; set; }
        [ForeignKey("SymptomLookupId")]
        public virtual SymptomLookup SymptomLookup { get; set; }
        public virtual ICollection<Schedule>? Schedules { get; set; }
    }
}
