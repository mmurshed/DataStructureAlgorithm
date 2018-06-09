using System;
namespace Algorithm.Graph.ShortestPath
{
    /*
Parallel job scheduling. As an example application, we revisit the class of scheduling problems that we first considered in Section 4.2 (page 574) (Topological Sort). Specifically, consider the following scheduling problem (differences from the problem on page 575 are italicized):
Parallel precedence-constrained scheduling. Given a set of jobs of specified du- ration to be completed, with precedence constraints that specify that certain jobs have to be completed before certain other jobs are begun, how can we schedule the jobs on identical processors (as many as needed) such that they are all com- pleted in the minimum amount of time while still respecting the constraints?

Definition. The critical path method for parallel scheduling is to proceed as follows:
Create an edge-weighted DAG with a source s, a sink t, and two vertices for each job (a start vertex and an end vertex). For each job, add an edge from its start vertex to its end vertex with weight equal to its duration. For each precedence constraint v->w, add a zero-weight edge from the end vertex corresponding tovs to the begin- ning vertex corresponding to w. Also add zero-weight edges from the source to each job’s start vertex and from each job’s end vertex to the sink. Now, schedule each job at the time given by the length of its longest path from the source.
        */
    public class ParallelJobScheduling
    {
        public void CriticalPathMethod()
        {
        }
    }
}
