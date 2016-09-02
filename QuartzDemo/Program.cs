using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace QuartzDemo
{
    class Program
    {
        /*开源的作业调度工具
         */
        static void Main(string[] args)
        {
            try
            {
                //新建工厂类
                ISchedulerFactory factory =
                    new StdSchedulerFactory();

                //工厂类生成调度器
                IScheduler scheduler = factory.GetScheduler();

                //首次执行时间设定
                DateTime dateTime = TriggerUtils.GetNextGivenSecondDate(null, 8);

                //执行时间间隔
                TimeSpan timeSpan = TimeSpan.FromSeconds(10);
                TimeSpan timeSpan2 = TimeSpan.FromSeconds(5);

                //初始化作业和触发器
                JobDetail jobDetail = new JobDetail("job1", "group1", typeof (Job.HelloJob));
                Trigger trigger = new SimpleTrigger("trigger1", "group2", "job1", "group1", dateTime, null,
                    SimpleTrigger.RepeatIndefinitely, timeSpan);

                JobDetail jobDetail2 = new JobDetail("job2", "group1", typeof(Job.DumbJob));
                Trigger trigger2 = new SimpleTrigger("trigger2", "group2", "job2", "group1", dateTime, null,
                    SimpleTrigger.RepeatIndefinitely, timeSpan2);

                //为调度器增加作业和触发器
                scheduler.AddJob(jobDetail, true);
                scheduler.ScheduleJob(trigger);

                scheduler.AddJob(jobDetail2, true);
                scheduler.ScheduleJob(trigger2);

                //启动调度器
                scheduler.Start();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }


        }   
    }
}
