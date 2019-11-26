using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace MathData
{
    public static class MathData
    {
        public static string DecToBin(BigInteger k)
        {
            int intResult = 0;
            string result = "";
            BigInteger binary = k / 17;
            while (binary >= 1)
            {
                if (binary % 2 == 0)
                    result = result + "0";
                else result = result + "1";
                binary = binary / 2;
                //binary = Math.Floor();
            }
            char[] binArray = result.ToCharArray();
            result = "";
            for (int i = binArray.Length - 1; i >= 0; i--)
            {
                result = result + binArray[i];
            }

            if (result.Length != 1802)
            {
                int counter = result.Length;
                for (var i = 0; i < 1802 - counter; i++)
                result = result.Insert(0, "0");
            }
            return result;
        }
        
        public static List<string> BinToGraph(string data)
        {
            int graphHeight = 17;
            int graphWidth = 106; // Переменной должна быть! Если есть вопросы как должна выщитываться, то говори, помогу с этим.
            List<string> binColumn = new List<string>();
            for (var i = 0; i < graphWidth; i++)
            {
                string buff = "";
                buff = data.Substring(i * graphHeight, graphHeight);
                binColumn.Add(buff);
            }
            return binColumn;
        }
    }
}
