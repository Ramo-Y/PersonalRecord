namespace PersonalRecord.Domain.Models.Entities
{
    using System.Collections.ObjectModel;

    public class MovementRecordGroup
    {
        public string GroupName { get; set; }

        public ObservableCollection<MovementRecord> MovementRecords { get; set; }
    }
}