using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles.Properties
{
    internal class Colors
    {
        public const string White = "White";
        public const string Black = "Black";
        public const string Gray = "Gray";
        public const string Red = "Red";
        public const string Blue = "Blue";
        public const string Yellow = "Yellow";
        public const string Green = "Green";
        public const string Purple = "Purple";
        public const string Orange = "Orange";
        public const string Brown = "Brown";
        public const string Pink = "Pink";
        public const string Cyan = "Cyan";
        public const string Magenta = "Magenta";
        public const string Gold = "Gold";
        public const string Silver = "Silver";
        public const string Maroon = "Maroon";
        public const string Turquoise = "Turquoise";
        public const string Beige = "Beige";
        public const string Violet = "Violet";

        public static string[] AllColors = [White, Black, Gray, Red, Blue, Yellow, Green, Purple, Orange, Brown, Green, Turquoise, Violet];

        //src: https://stackoverflow.com/questions/6944056/compare-string-similarity
        public static int GetLevenshteinDistance(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
            {
                if (string.IsNullOrEmpty(t))
                    return 0;
                return t.Length;
            }

            if (string.IsNullOrEmpty(t))
            {
                return s.Length;
            }

            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // initialize the top and right of the table to 0, 1, 2, ...
            for (int i = 0; i <= n; d[i, 0] = i++) ;
            for (int j = 1; j <= m; d[0, j] = j++) ;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
                    int min1 = d[i - 1, j] + 1;
                    int min2 = d[i, j - 1] + 1;
                    int min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }
            return d[n, m];
        }
    }
}
