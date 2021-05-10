using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public class CodeService
    {
        public static string GenerateRandomCode()
        {
            Random random = new Random();
            Dictionary<int, string> charactes = new Dictionary<int, string>()
            {
                { 1, "A" }, { 2, "B" }, { 3, "C" }, { 4, "D" }, { 5, "E" }, { 6, "F" },
                { 7, "G" }, { 8, "H" }, { 9, "I" }, { 10, "J" }, { 11, "K" }, { 12, "L" },
                { 13, "M" }, { 14, "N" }, { 15, "O" }, { 16, "P" }, { 17, "Q" }, { 18, "R" },
                { 19, "S" }, { 20, "T" }, { 21, "W" }, { 22, "X" }, { 23, "Y" }, { 24, "Z" },
            };

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                int number = random.Next(1, 25);
                sb.Append(charactes[number]);
            }

            for (int i = 0; i < 2; i++)
            {
                int number = random.Next(0, 10);
                sb.Append(number);
            }

            return sb.ToString();
        }
    }
}
