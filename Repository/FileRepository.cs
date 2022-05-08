using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Documents;
using Lab2.Models;
using Lab2.Tools;

namespace Lab2.Repository
{
    public class FileRepository
    {
        private static readonly string BaseFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "zloydi");

        public FileRepository()
        {

            if (!Directory.Exists(BaseFolder))
            {
                Directory.CreateDirectory(BaseFolder);
                Task.Run(async () =>
                {
                    List<DBPerson> persons = DBPersonCreator.create(50);
                    foreach (DBPerson person in persons)
                    {
                        await AddOrUpdateAsync(person);
                    }
                }).Wait();
            }
        }

        public async Task AddOrUpdateAsync(DBPerson obj)
        {
            var stringObj = JsonSerializer.Serialize(obj);

            using (StreamWriter sw = new StreamWriter(Path.Combine(BaseFolder, obj.Email+".json"), false))
            {
                await sw.WriteAsync(stringObj);
            }
        }

        public void Delete(string email)
        {
            string filePath = Path.Combine(BaseFolder, email+".json");

            if (!File.Exists(filePath)) return;

            File.Delete(filePath);
        }

        public async Task<DBPerson> GetAsync(string email)
        {
            string stringObj = null;
            string filePath = Path.Combine(BaseFolder, email+".json");

            if (!File.Exists(filePath))
                return null;

            using (StreamReader sw = new StreamReader(filePath))
            {
                stringObj = await sw.ReadToEndAsync();
            }

            return JsonSerializer.Deserialize<DBPerson>(stringObj);
        }

        public async Task<List<DBPerson>> GetAllAsync()
        {
            var res = new List<DBPerson>();
            foreach (var file in Directory.EnumerateFiles(BaseFolder))
            {
                string stringObj = null;

                using (StreamReader sw = new StreamReader(file))
                {
                    stringObj = await sw.ReadToEndAsync();
                }

                DBPerson person = JsonSerializer.Deserialize<DBPerson>(stringObj);
                res.Add(person);
            }

            return res;
        }

        public List<DBPerson> GetAll()
        {
            var res = new List<DBPerson>();
            foreach (var file in Directory.EnumerateFiles(BaseFolder))
            {
                string stringObj = null;

                using (StreamReader sw = new StreamReader(file))
                {
                    stringObj = sw.ReadToEnd();
                }

                res.Add(JsonSerializer.Deserialize<DBPerson>(stringObj));
            }

            return res;
        }
    }
}