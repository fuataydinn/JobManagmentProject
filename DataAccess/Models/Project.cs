using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Project
    {
        public Project()
        {
            Tasks = new List<MainTask>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        private int _estimatedDurationDays;
        public int EstimatedDurationInDays
        {
            get { return _estimatedDurationDays; }
            set
            {
                if (value <= 0)
                {
                    _estimatedDurationDays = 0;
                }
                _estimatedDurationDays = value;
            }
        }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get { return StartDate.AddDays(EstimatedDurationInDays); } }

        private DateTime? _startedOn;
        public DateTime? StartedOn { get { return _startedOn; } }
        private DateTime? _completedOn;
        public DateTime? CompletedOn { get { return _completedOn; } }
        private DateTime? _closedOn;
        public DateTime? ClosedOn { get { return _closedOn; } }

        public int WorkedDays { 
            get
            {
                if (StartedOn==null)
                {
                  return  0;
                }
                else if (CompletedOn!=null || ClosedOn!=null)
                {
                    return (int)(CompletedOn.Value - StartedOn.Value).TotalDays;
                }
                else
                {
                    return (int)(DateTime.Today - StartedOn.Value).TotalDays;
                }
            } 
        }
        public int RemainingDays {
            get
            {
                var referenceDate = ClosedOn.HasValue ? ClosedOn.Value : DateTime.Now;

                var daysDifference = (int)(DueDate - referenceDate).TotalDays;

                return daysDifference >= 0 ? daysDifference : 0;
            } 
        }
        public ProjectStatus Status { 
              get
            {
                if (!StartedOn.HasValue)
                {
                    return ClosedOn.HasValue
                        ? ProjectStatus.Closed
                        : ProjectStatus.None;
                }
                else if (!ClosedOn.HasValue)
                {
                    return DateTime.Today <= DueDate
                        ? ProjectStatus.InProgress
                        : ProjectStatus.Delayed;
                }
                else if (!CompletedOn.HasValue)
                {
                    return ProjectStatus.Canceled;
                }
                else
                {
                    return CompletedOn.Value <= DueDate
                        ? ProjectStatus.CompletedOnTime
                        : ProjectStatus.CompletedWithDelay;
                }
            }
        }
        public ICollection<MainTask> Tasks { get; set; }

        public void Start()
        {
            if (StartedOn == null)
            {
                _startedOn = DateTime.Now;
            }
        }
        public void Complete()
        {
            if (CompletedOn==null)
            {
                _completedOn = DateTime.Now;
                Close();
            }
        }
        public void Close()
        {
            if (ClosedOn==null)
            {
                _closedOn = DateTime.Now;

            }
        }


    }
}
