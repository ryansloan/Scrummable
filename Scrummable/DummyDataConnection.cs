using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrummable
{
    class DummyDataConnection : BugDatabaseInterface
    {
        private String filename;
        private string[] fieldsArray = { "ID", "Title", "Assigned To", "Node Name", "Fix By", "Estimate"};
        public DummyDataConnection(String filename)
        {
            this.filename = filename;
        }
        public bool Connect()
        {
            bool success = false;
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + this.filename))
            {
                success = true;
            }
            
            return success;
        }
        public void Disconnect()
        {
           //dummy thang
        }
        public List<Bug> ImportBugsAssignedTo(String user)
        {
            List<Bug> bugList = new List<Bug>();
            StreamReader reader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\"+this.filename); //import semicolon delimited file
            Bug b;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(';');
                //order: Id, Title, AssignedTo,FixBy,Estimate,NodeName
                if (values[2].Equals(user))
                {
                    b = new Bug();
                    b.Id = values[0];
                    b.Title = values[1];
                    b.AssignedTo = values[2];
                    b.FixBy = values[3];
                    b.Estimate = Convert.ToInt32(values[4]);
                    b.NodeName = values[5];

                    bugList.Add(b);
                }

            }
            reader.Close();
            Console.WriteLine(bugList.Count + " Items found");
            return bugList;
        }
        public Bug ImportBugById(String id)
        {
            StreamReader reader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\"+this.filename); //import semicolon delimited file
            Bug b=null;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(';');
                //order: Id, Title, AssignedTo,FixBy,Estimate,NodeName
                if (values[0].Equals(id))
                {
                    b = new Bug();
                    b.Id = values[0];
                    b.Title = values[1];
                    b.AssignedTo = values[2];
                    b.FixBy = values[3];
                    b.Estimate = Convert.ToInt32(values[4]);
                    b.NodeName = values[5];
                }

            }
            reader.Close();
            return b;
        }
        public List<Bug> ImportBugById(String[] idArray)
        {
            StreamReader reader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + this.filename); //import semicolon delimited file
            Bug b;
            List<Bug> bugList = new List<Bug>();
            Hashtable BugIdTable = new Hashtable();
            foreach (String id in idArray) {
                BugIdTable.Add(id, false);
            }
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(';');
                //order: Id, Title, AssignedTo,FixBy,Estimate,NodeName
                if (BugIdTable.ContainsKey(values[0]))
                {
                    b = new Bug();
                    b.Id = values[0];
                    b.Title = values[1];
                    b.AssignedTo = values[2];
                    b.FixBy = values[3];
                    b.Estimate = Convert.ToInt32(values[4]);
                    b.NodeName = values[5];
                    bugList.Add(b);
                }

            }
            reader.Close();
            return bugList;
        }
        public bool ExportBugChanges(Bug b)
        {
            return false;
        }
    }
}
