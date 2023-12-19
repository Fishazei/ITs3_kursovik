using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IT_3S_Kursovik.classes
{
    public struct Record
    {
        public string name;
        public int points;

        public Record(string name, int points)
        {
            this.name = name;
            this.points = points;
        }
    }
    internal class RecordsHandler
    {
        List<Record> records = null;
        public RecordsHandler()
        {
            records = new List<Record>();
        }

        public void AddRecord(Record newRez)
        {
            int i;
            for (i = 0; i < records.Count; i++)
                if (records[i].points < newRez.points) break;
            records.Insert(i, newRez);
        }

        public bool ReadRecords()
        {

            return false;
        }

        public List<Record> GetRecords()
        { 
            MessageBox.Show(records[0].points.ToString() + records[0].name.ToString());
            return records;
        }

    }
}
