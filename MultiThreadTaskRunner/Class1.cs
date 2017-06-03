using System.Collections.Generic;
using System.Management.Automation;
using System.Threading.Tasks;

namespace MultiThreadTaskRunner
{
    /// <summary>
    /// 这是一个多线程执行脚本的工具
    /// </summary>
    [Cmdlet(VerbsCommon.New, "MultiTaskJob",HelpUri = "https://github.com/chenxizhang/MultiThreadTaskRunner")]
    public class RunTask : Cmdlet
    {

        [Parameter(Position = 0,HelpMessage ="请指定要执行的PowerShell代码块",Mandatory =true)]
        public ScriptBlock Block { get; set; }

        [Parameter(Position = 1, HelpMessage = "请指定要同时运行的线程数，这个取决于你当前计算机的硬件配置，一般建议的数量是CPU数量。默认为4")]
        public int ThreadCount { get; set; } = 4;

        [Parameter(Position = 2,HelpMessage ="请指定要执行的源，通常指的是一个数据集合。")]
        public IEnumerable<object> Source { get; set; }

        
        protected override void ProcessRecord()
        {
            Parallel.ForEach(Source,new ParallelOptions() {
                MaxDegreeOfParallelism = ThreadCount
            }, (obj) =>
            {
                Block.Invoke(obj);
            });
        }
    }
}
