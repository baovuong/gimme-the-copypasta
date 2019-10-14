using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GimmeTheCopyPasta
{
    public static class ShuffleExtensions
    {
        public static IEnumerable<tsource>
               RandomShuffle<tsource>(this IEnumerable<tsource> source)
        {
            return source.Select(t => new {
                Index = System.Guid.NewGuid(),
                Value = t
            })
                .OrderBy(p => p.Index)
                .Select(p => p.Value);
        }
    }
}
