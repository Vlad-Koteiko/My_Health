using My_Health.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Health.Services
{
    class FaleIOServes
    {
        private string PATH;

        public FaleIOServes(string path)
        {
            PATH = path;
        }

        public BindingList<user> LoadDate()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<user>();
            }

            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<user>>(fileText);
            }

        }

        public void SaveDate(user DataList)
        {
            using (StreamWriter write = File.CreateText(PATH))
            {
                // write.Dispose();  using 
                string output = JsonConvert.SerializeObject(DataList);
                write.Write(output);
            }

        }

        public void Path(string path)
        {
            PATH = path;
        }


    }
}
