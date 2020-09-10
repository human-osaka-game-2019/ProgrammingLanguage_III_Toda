using System;
using System.Linq;
using System.Collections.Generic;

namespace ProgrammingLanguage_III
{ 
    class Labyrinth
    {
        static void Main(string[] args)
        {
            MapData map_data = new MapData();
            List<int> map = map_data.GetMap(2);
            int scale = map_data.GetScale(2);

            Counter counter = new Counter(0);

            int array_max = map.Count();
            CellPicture cell_picture = new CellPicture(0, array_max);

            string? output_line = null;

            for (int num = 0; num < array_max; num++)
            {
                counter++;

                cell_picture[num] = (map[num] == 0 ? "　" : "■");


                if (counter.Val % scale == 0 && counter.Val > 0)
                {
                    output_line += cell_picture[num];
                    Console.WriteLine(output_line);

                    output_line = null;
                }
                else
                {
                    output_line += cell_picture[num];
                }

            }
        }

        class CellPicture
        {
            string[] array;
            int lower;   // 配列添字の下限

            public CellPicture(int lower, int upper)
            {
                this.lower = lower;
                array = new string[upper - lower];
            }

            public string this[int i]
            {
                set { this.array[i] = value; }
                get { return this.array[i]; }
            }
        }
    }

    class MapData
    {
        public List<int> GetMap(int map_num)
        {
            var list = map_num switch
            {
                1 => new List<int>(map_1),
                2 => new List<int>(map_2),
                _ => new List<int>(lost_map)
            };

            return list;
        }
        public int GetScale(int map_num)
        { 
            var scale = map_num switch
            {
                1 => 5,
                2 => 10,
                _ => 0
            };

            return scale;
        }

        int[] lost_map = { -1 };

        int[] map_1 = {
            1, 1, 1, 1, 1,
            1, 0, 0, 0, 1,
            1, 1, 1, 0, 1,
            1, 0, 0, 0, 1,
            1, 1, 1, 1, 1,
        };

        int[] map_2 = {
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 0, 0, 0, 1, 0, 0, 0, 1, 1,
            1, 1, 1, 0, 1, 0, 1, 0, 0, 1,
            1, 0, 0, 0, 1, 0, 1, 1, 0, 1,
            1, 1, 0, 1, 1, 0, 0, 1, 0, 1,
            1, 0, 0, 0, 1, 1, 0, 1, 0, 1,
            1, 1, 1, 0, 1, 0, 0, 1, 0, 1,
            1, 0, 1, 0, 0, 0 ,1, 1, 0, 1,
            1, 0, 0, 0, 1, 0, 1, 0, 0, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
        };
    }

    class Counter
    {
        int val;
        public Counter(int num) { this.val = num; }

        public int Val
        {
            get { return val; }
            set { val = value; }
        }
        
        public static Counter operator ++(Counter c)
        {
            return new Counter(c.val + 1);
        }
    }
}
