using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace QuartzDemo
{
    public class Job
    {
        public  class HelloJob:IJob
        {
            public void Execute(JobExecutionContext jobExecutionContext)
            {
                Console.WriteLine("执行HelloJob");
            }
        }

        public class DumbJob:IJob
        {
            public void Execute(JobExecutionContext jobExecutionContext)
            {
                Console.WriteLine("执行DumbJob");
            }
        }
    }
}
