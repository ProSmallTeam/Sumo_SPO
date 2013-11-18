using System;
using System.Collections.Generic;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using NumberGuessWorkflowActivities;
using System.Threading;

namespace NumberGuessWorkflowHost
{

    class Program
    {
        static void Main(string[] args)
        {
            var syncEvent = new AutoResetEvent(false);
            var idleEvent = new AutoResetEvent(false);


            var inputs = new Dictionary<string, object>() { { "MaxNumber", 13 } };

            var wfApp =
                new WorkflowApplication(new SequentialNumberGuessWorkflow(), inputs);


            wfApp.Completed = delegate(WorkflowApplicationCompletedEventArgs e)
            {
                int turns = Convert.ToInt32(e.Outputs["Turns"]);
                Console.WriteLine("Congratulations, you guessed the number in {0} turns.", turns);

                syncEvent.Set();
            };

            wfApp.Aborted = delegate(WorkflowApplicationAbortedEventArgs e)
            {
                Console.WriteLine(e.Reason);
                syncEvent.Set();
            };

            wfApp.OnUnhandledException = delegate(WorkflowApplicationUnhandledExceptionEventArgs e)
            {
                Console.WriteLine(e.UnhandledException.ToString());
                return UnhandledExceptionAction.Terminate;
            };

            wfApp.Idle = delegate(WorkflowApplicationIdleEventArgs e)
            {
                idleEvent.Set();
            };


            wfApp.Run();

            // Loop until the workflow completes.
            var handles = new WaitHandle[] { syncEvent, idleEvent };
            while (WaitHandle.WaitAny(handles) != 0)
            {
                // Gather the user input and resume the bookmark.
                bool validEntry = false;
                while (!validEntry)
                {
                    int guess;
                    if (!Int32.TryParse(Console.ReadLine(), out guess))
                    {
                        Console.WriteLine("Please enter an integer.");
                    }
                    else
                    {
                        validEntry = true;
                        wfApp.ResumeBookmark("EnterGuess", guess);
                    }
                }
            }
        }
    }
}
