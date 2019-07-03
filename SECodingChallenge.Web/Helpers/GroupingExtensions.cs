using SECodingChallenge.Web.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SECodingChallenge.Web.Helpers
{
    public static class GroupingExtensions
    {
        public const int CSVMinimumBytes = 128;

        public static T1 GetHighesCountGroup<T1, T2>(this IEnumerable<IGrouping<T1, T2>> groups)
        {
            var temp = 0;
            T1 vehicle = default(T1);
            foreach (IGrouping<T1,T2> group in groups)
            {
                if (group.Count() > temp)
                {
                    temp = group.Count();
                    vehicle = group.Key;
                }
            }
            return vehicle;
        }
    }
}