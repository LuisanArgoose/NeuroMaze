using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    [Serializable]
    public class Seans
    {
        //public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Size { get; set; }
        public float PlayTime { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Seed { get; set; }
        public int Average { get; set; }
        public List<SeansPoint> SeansWriter { get; set; }
        public string GetDate()
        {
            return Date.ToString();
        }

        public Seans(){}
    }
}