using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
        public override string ToString()
        {
            while (name.Length < 9) { name = name.Insert(name.Length, " "); }
            return name + " |  " + points.ToString() + "\n";
        }
    }

    internal class RecordsHandler
    {
        List<Record> records = null;
        public RecordsHandler()
        {
            records = new List<Record>();
            LoadRecords("records.txt");
        }

        public void AddRecord(Record newRez)
        {
            int i;
            for (i = 0; i < records.Count; i++)
                if (records[i].points < newRez.points) break;
            if (i < 10)
            {
                records.Insert(i, newRez);
                SaveRecords("records.txt");
            }
            if (records.Count >= 10)
            {
                records.RemoveRange(10, records.Count - 10);
            }
        }

        public string GetRecords()
        {
            string str = null;
            int i = 0;
            foreach (Record rec in records)
            {
                i++;
                if (i < 10) str += i.ToString() + ".  " + rec.ToString();
                else str += i.ToString() + ". " + rec.ToString();
            }
            return str;
        }

        // Метод для записи списка структур в файл в формате CSV
        public void SaveRecords(string filePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (Record record in records)
                    {
                        sw.WriteLine($"{record.name},{record.points}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибок записи в файл
                Console.WriteLine($"Error saving records: {ex.Message}");
            }
        }

        // Метод для чтения списка структур из файла в формате CSV
        public void LoadRecords(string filePath)
        {
            try
            {
                records.Clear(); // Очистим текущий список перед загрузкой новых данных

                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 2 && int.TryParse(parts[1], out int points))
                        {
                            records.Add(new Record(parts[0], points));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибок чтения из файла
                Console.WriteLine($"Error loading records: {ex.Message}");
            }
        }
    }
}
