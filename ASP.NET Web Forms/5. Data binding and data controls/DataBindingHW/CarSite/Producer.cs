using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSite
{
    public class Producer
    {
        public string Name { get; set; }

        public ICollection<Model> Models { get; set; }

        public Producer(string producerName)
        {
            this.Name = producerName;
        }

        public Producer(string producerName, ICollection<Model> models)
        {
            this.Name = producerName;
            this.Models = models;
        }
    }
}