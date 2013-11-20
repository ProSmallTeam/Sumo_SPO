using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NUnit.Framework;

namespace MetaObtainer
{
    [TestFixture]
    public class MetaObtainer
    {
        [Test]
        public void Run()
        {


            var wfApp =
                new WorkflowApplication(new PrimitiveMetaObtainingSequenceActivity.PrimitiveMetaObtainingSequenceActivity());

            wfApp.Completed = delegate(WorkflowApplicationCompletedEventArgs e)
            {
                int turns = Convert.ToInt32(e.Outputs["Counter"]);
                //throw new NotImplementedException(turns.ToString());
                MessageBox.Show("ololol");

                // syncEvent.Set();
            };

            wfApp.Run();
        }

    }
}
