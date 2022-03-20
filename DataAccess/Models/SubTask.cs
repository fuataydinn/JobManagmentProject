using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class SubTask : TaskBase
    {
        public int ParentId { get; set; }

        public MainTask ParentTask { get; set; }

        private DateTime? _startedOn;
        public override DateTime? StartedOn => _startedOn;

        private DateTime? _completedOn;
        public override DateTime? CompletedOn { get { return _completedOn; } }

        public override TaskStatus Status
        {
            get
            {
                if (!StartedOn.HasValue)
                {
                    return TaskStatus.Open;
                }
                else if (!CompletedOn.HasValue)
                {
                    return TaskStatus.InProgress;
                }
                else
                {
                    return TaskStatus.Done;
                }
            }
        }

        public void Start()
        {
            if (!StartedOn.HasValue)
            {
                _startedOn = DateTime.Now;
            }
        }

        public void Complete()
        {
            if (StartedOn.HasValue && !CompletedOn.HasValue)
            {
                _completedOn = DateTime.Now;
            }
        }
    }
}
