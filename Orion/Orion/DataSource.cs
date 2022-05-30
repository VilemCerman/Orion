using System;
using System.Collections.Generic;
using System.Text;

namespace Orion
{
    class DataSource
    {
        public static string[,] Data1 { get; private set; } = new string[2, 4] { { "Jan", "Feb", "Mar", "Apr" }, { "2423", "2648", "1745", "1923" } };
        public static string[,] Data2 { get; private set; } = new string[2, 7] { { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul" }, { "2023", "2648", "1523", "973", "812", "883", "923"} };
        public static string[,] Data3 { get; private set; } = new string[2, 5] { { "Jan", "Feb", "Mar", "Apr", "May"}, { "2023", "2648", "1523", "973", "823"} };


    }
}
