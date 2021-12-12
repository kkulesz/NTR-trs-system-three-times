using System.Collections.Generic;
using System;

namespace lab2and3.Models.DomainModel
{
    public record UsersMonth
    {
        public int Year { get; init; }
        public int Month { get; init; }
        public virtual User User { get; init; }
        public bool Frozen { get; init; }

        public DateTime NextMonth()
        {
            if (Month == 12)
                return new DateTime(Year + 1, 1, 1);
            return new DateTime(Year, Month + 1, 1);
        }

        public DateTime PreviousMonth()
        {
            if (Month == 1)
                return new DateTime(Year - 1, 12, 1);
            return new DateTime(Year, Month - 1, 1);
        }

        public DateTime ThisMonth()
        {
            return new DateTime(Year, Month, 1);
        }
    }
}