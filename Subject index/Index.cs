using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Subject_index
{
    internal class Index
    {
        public List<IndexEntry> entries = new List<IndexEntry>();
        //метод добавление нового слова с указанием страницы
        public IndexEntry FindEntry(string word)
        {
            foreach (var item in entries)
            {
                if (item.Word == word)
                    return item;
            }
            return null;
        }
        public void Addword(string word, int page)
        {
            IndexEntry entry = null;
            foreach (var item in entries)
            {
                if (item.Word == word)
                {
                    entry = item;
                    break;
                }
            }
            if ( entry != null)
            {
                entry.AddPage(page);
            }
            else
            {
                IndexEntry newEntry = new IndexEntry(word);
                newEntry.AddPage(page);
                entries.Add(newEntry);
            }
        }
        // метод удаление слова
        public bool RemoveWord(string word)
        {
            IndexEntry entry = FindEntry(word);

            if (entry != null)
            {
                entries.Remove(entry);
                return true;
            }

            return false;
        }
        public bool RemovePage(string word, int page)
        {
            IndexEntry entry = FindEntry(word);

            if (entry != null)
            {
                return entry.RemovePage(page);
            }

            return false;
        }
        //метод сохранение данных в .txt файл для зпедактирования
        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine($"{entry.Word}|{string.Join(",", entry.pages)}");
                }
            }
        }
        //метод сохранения данных для документа
        public void ExportToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                entries = entries.OrderBy(x => x.Word).ToList();
                char currentLetter = '\0';
                foreach (var entry in entries)
                {
                    if (!String.IsNullOrEmpty(entry.Word))
                    {
                        char firstletter = char.ToUpper(entry.Word[0]);

                        if (firstletter != currentLetter)
                        {
                            currentLetter = firstletter;
                            writer.WriteLine();
                            writer.WriteLine(currentLetter);
                            writer.WriteLine(new string('_', 20));
                        }
                        writer.WriteLine($"     {entry.Word} - {string.Join(", ", entry.pages)}");
                    }
                }
            }
        }
        // метод загрузки данных(чтение .txt файла)
        public void LoadFromFile(string filename)
        {
            entries.Clear();

            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        string word = parts[0];
                        string[] pagesStr = parts[1].Split(',');

                        foreach (string pageStr in pagesStr)
                        {
                            if (int.TryParse(pageStr.Trim(), out int page))
                            {
                                Addword(word, page);
                            }
                        }
                    }
                }
            }
        }
    }
}
