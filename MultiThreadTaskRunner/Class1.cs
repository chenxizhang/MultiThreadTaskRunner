using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadTaskRunner
{
    [Cmdlet(VerbsCommon.New, "MultiTaskJob")]
    public class RunTask : Cmdlet
    {
        [Parameter(Position = 0)]
        public ScriptBlock Block { get; set; }

        [Parameter(Position = 1)]
        public int ThreadCount { get; set; }

        [Parameter(Position = 2)]
        public IEnumerable<object> Source { get; set; }

        protected override void ProcessRecord()
        {
            Parallel.ForEach(Source, (obj) =>
            {
                Block.Invoke(obj);
            });
        }
    }
}
