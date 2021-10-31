using System;
using System.Collections.Generic;

namespace FuncSharp.Examples
{
    public class Commit : Product2<DateTime, int>
    {
        public Commit(DateTime dateTime, int changeCount)
            : base(dateTime, changeCount)
        {
        }

        public DateTime DateTime { get { return ProductValue1; } }
        public int ChangeCount { get { return ProductValue2; } }
    }

    public class PunchCard : DataCube2<DayOfWeek, int, int>
    {
    }

    public static class PunchCardUtilities
    {
        public static PunchCard CreatePunchCard(IEnumerable<Commit> commits)
        {
            var punchCard = new PunchCard();
            foreach (var commit in commits)
            {
                punchCard.SetOrElseUpdate(commit.DateTime.DayOfWeek, commit.DateTime.Hour, commit.ChangeCount, (a, b) => a + b);
            }

            return punchCard;
        }
    }
}
