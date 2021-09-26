using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Health.Models
{
  public  class user
    {
        public string User { get; set; }
        public int Rank { get; set; }
        public string Status { get; set; }
        public int Steps { get; set; }
        public int Max_Step { get; set; }
        public int Min_Step { get; set; }

        public int[] Day_Step = new int[31];

        public int Sred_Steps { get; set; }


      public  void Sred_value()               // средняе значение 
        {
            long temp = 0;
            for (int i = 1; i <= 30; i++)
            {
                temp = temp + Day_Step[i];
            }
            Sred_Steps = (int)(temp / 30);
        }

       public void Max_Value()               // максимальное значение
        {
            int temp = 0;
            for (int i = 1; i <= 30; i++)
            {
                if (Day_Step[i] > temp)
                {
                    Max_Step = Day_Step[i];
                    temp = Day_Step[i];
                }
            }
        }

        public void Min_Value()            // минимальное значение 
        {
            int temp = int.MaxValue;
            for (int i = 1; i <= 30; i++)
            {
                if (Day_Step[i] < temp)
                {
                    Min_Step = Day_Step[i];
                    temp = Day_Step[i];
                }
            }
        }



    }

}
