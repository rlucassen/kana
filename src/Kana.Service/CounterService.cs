using System.Collections.Generic;
using System.IO;
using System.Linq;
using Kana.Model.Entities;
using Kana.Model.Interfaces.Service;
using Newtonsoft.Json;

namespace Kana.Service
{
    public class CounterService : ICounterService
    {
        protected string jsonLocation;
        protected JsonSerializer jsonSerializer;

        public CounterService(string jsonLocation)
        {
            this.jsonLocation = jsonLocation;
            jsonSerializer = new JsonSerializer();
        }

        private List<Counter> GetCounters()
        {
            using (var file = File.OpenText(jsonLocation))
            {
                var counters = (List<Counter>)jsonSerializer.Deserialize(file, typeof(List<Counter>));
                return counters ?? new List<Counter>();
            }
        }

        private void SetCounters(List<Counter> counters)
        {
            using (StreamWriter file = File.CreateText(jsonLocation))
            {
                jsonSerializer.Serialize(file, counters);
            }
        }

        public Counter GetCounter(string name)
        {
            return GetCounters().FirstOrDefault(x => x.Name == name) ?? new Counter() {Name = name};
        }

        public void SetCounter(Counter counter)
        {
            var counters = GetCounters();

            var index = counters.FindLastIndex(x => x.Name == counter.Name);

            if (index == -1)
            {
                counters.Add(counter);
            }
            else
            {
                counters[index] = counter;
            }

            SetCounters(counters);
        }

        public int Increment(string name)
        {
            var counter = GetCounter(name);
            counter.Increment();
            SetCounter(counter);
            return counter.Count;
        }

        public void Reset(string name)
        {
            var counter = GetCounter(name);
            counter.Reset();
            SetCounter(counter);
        }
    }
}