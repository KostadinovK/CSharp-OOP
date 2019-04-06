using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class JobCollection
{
    private List<IJob> jobs;

    public JobCollection()
    {
        jobs = new List<IJob>();
    }

    public void AddJob(IJob job)
    {
        jobs.Add(job);
        job.JobDoneEvent += HandleJobDoneEvent;
    }

    public void HandleJobDoneEvent(IJob sender)
    {
        jobs.Remove(sender);
    }

    public void PassWeek()
    {
        foreach (var job in jobs.ToList())
        {
            job.Update();
        }
    }

    public void Status()
    {
        foreach (var job in jobs)
        {
            Console.WriteLine(job.Status());
        }
    }
}
