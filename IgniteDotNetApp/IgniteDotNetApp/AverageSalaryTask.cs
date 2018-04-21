using Apache.Ignite.Core.Compute;
using System;
using System.Collections.Generic;

namespace IgniteDotNetApp
{
    class AverageSalaryTask : ComputeTaskSplitAdapter<ICollection<Employee>, Tuple<long, int>, long>
    {

        public override long Reduce(IList<IComputeJobResult<Tuple<long, int>>> results)
        {
            throw new NotImplementedException();
        }

        protected override ICollection<IComputeJob<Tuple<long, int>>> Split(int gridSize, ICollection<Employee> arg)
        {
            //throw new NotImplementedException();
            ICollection<Employee> employees = arg;

            var jobs = new List<IComputeJob<Tuple<long, int>>>(gridSize);

            int count = 0;

            foreach (Employee employee in employees)
            {
                int idx = count++ % gridSize;

                AverageSalaryJob job;

                if (idx >= jobs.Count)
                {
                    job = new AverageSalaryJob();

                    jobs.Add(job);
                }
                else
                    job = (AverageSalaryJob)jobs[idx];

                job.Add(employee);
            }

            return jobs;
        }
    }
}
