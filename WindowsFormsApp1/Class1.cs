using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Class1
    {

            public string Location { get; set; }
            public decimal M1 { get; set; }
            public decimal M2 { get; set; }

        public int[] x = new int[8] { 1, 0, 1, 1, 0, 1, 1, 0 };
        public int[] y = new int[8] { 1, 2, 3, 4, 5, 6, 7, 8 };

        public decimal M3 { get; set; }
            public decimal M4 { get; set; }
            public decimal M5 { get; set; }
            public decimal M6 { get; set; }
            public decimal M7 { get; set; }
            public decimal M8 { get; set; }

            public decimal G1 { get; set; }
            public decimal G2 { get; set; }
            public decimal G3 { get; set; }
            public decimal G4 { get; set; }
            public decimal G5 { get; set; }
            public decimal G6 { get; set; }
            public decimal G7 { get; set; }
            public decimal G8 { get; set; }

            public object this[string propertyName]
            {
                get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
                set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
            }
        }
    
}
