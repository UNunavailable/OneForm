using System;
using System.Collections.Generic;
using System.Text;

namespace OneForm
{
    class Data
    {
        public Dictionary<String, string[]> workshops;
        public Dictionary<String, string[]> workers;

        public Data()
        {
            workshops = new Dictionary<string, string[]>(2);
            workshops.Add("Москва", new[] {"Заготовительный цех", "Электрический цех"});
            workshops.Add("Казань", new[] {"Механосборочный цех"});

            workers = new Dictionary<string, string[]>(3);
            workers.Add("Москва. Заготовительный цех", new[] {"Петров", "Попов"});
            workers.Add("Казань. Механосборочный цех", new[] {"Силков"});
            workers.Add("Москва. Электрический цех", new[] {"Семёнов"});
        }
    }

    class WorkerTime
    {
        public string city { get; set; }
        public string workshop { get; set; }
        public string worker { get; set; }
        public int brigade { get; set; }
        public int shift { get; set; }

        public WorkerTime(string city, string workshop, string worker, int brigade, int shift)
        {
            this.city = city;
            this.workshop = workshop;
            this.worker = worker;
            this.brigade = brigade;
            this.shift = shift;
        }
    }
}
