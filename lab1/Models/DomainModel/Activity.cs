using System;
using System.Collections.Generic;

namespace lab1.Models
{
    public class Activity
    {
        public readonly string Code;
        public readonly Project Project;
        public readonly User Executor;
        public int Budget { get; set; }
        public Boolean isActive { get; set; }
        public List<string> subactivities { get; set; } //todo: remove setter
        public DateTime date { get; set; }
    }
}