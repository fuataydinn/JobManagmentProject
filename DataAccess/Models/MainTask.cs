using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class MainTask : TaskBase
    {
        public MainTask()
        {
            SubTasks = new List<SubTask>();
        }
        public int ProjectId { get; set; } //
        public EmployeeExperience RequiredExperience { get; set; }
        public int AssignedTo { get; set; }
        public float CompletionRate { get; }
        public Project Project { get; set; }  //
        public int MyProperty { get; set; }
        public Employee AssignedToEmployee { get; set; }
        public ICollection<SubTask> SubTasks { get; }  //

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

        public override DateTime? StartedOn
        {
            get
            {
                if (SubTasks.Any(sub => sub.StartedOn != null))
                {
                    var firstStartedSubTask = SubTasks
                        .Where(sub => sub.StartedOn != null)
                        .OrderBy(sub => sub.StartedOn)
                        .First();

                    return firstStartedSubTask.StartedOn;
                }
                else
                {
                    return null;
                }            
            }
        }

        public override DateTime? CompletedOn
        {
            get
            {
                if (SubTasks.All(sub => sub.CompletedOn != null))
                {
                    var lastCompletedTask = SubTasks
                        .OrderByDescending(sub => sub.CompletedOn)
                        .First();

                    return lastCompletedTask.CompletedOn;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
