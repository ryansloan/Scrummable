using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrummable
{
    interface BugDatabaseInterface
    {
        bool Connect();
        void Disconnect();
        List<Bug> ImportBugsAssignedTo(String user);
        Bug ImportBugById(String id);
        List<Bug> ImportBugById(String[] id);
        bool ExportBugChanges(Bug b);
    }
}
