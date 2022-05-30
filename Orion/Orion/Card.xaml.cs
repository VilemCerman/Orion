using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Orion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Card : ContentView
    {
        public string GraphType { get; private set; }
        public string[,] Data { get; private set; }
        private ChartEntry[] _entries;
        public Card(string graphType, int dataSource)
        {
            InitializeComponent();
            switch (dataSource)
            {
                case 1:
                    Data = DataSource.Data1;
                    break;
                case 2:
                    Data = DataSource.Data2;
                    break;
                case 3:
                    Data = DataSource.Data3;
                    break;
            }
            GraphType = graphType;
            ChartEntry[] entries = new ChartEntry[Data.GetLength(1)];
            int someClrLdngVar = 0;
            if (ThemeManager.DarkSwitchOn)
            {
                for (int i = 0; i < Data.GetLength(1); i++)
                {
                    if (i == GraphColors.DarkColorsArray.Length)
                        someClrLdngVar += GraphColors.DarkColorsArray.Length;
                    entries[i] = new ChartEntry(int.Parse(Data[1, i]))
                    {
                        Color = SKColor.Parse(GraphColors.DarkColorsArray[i - someClrLdngVar])
                    };
                }
            }
            else
            {
                for (int i = 0; i < Data.GetLength(1); i++)
                {
                    if (i == GraphColors.ColorsArray.Length)
                        someClrLdngVar += GraphColors.ColorsArray.Length;
                    entries[i] = new ChartEntry(int.Parse(Data[1, i]))
                    {
                        Color = SKColor.Parse(GraphColors.ColorsArray[i - someClrLdngVar])
                    };
                }
            }

            _entries = entries;

            switch (GraphType)
            {
                case "BarChart":
                    cardChart.Chart = new BarChart { Entries = entries };
                    break;
                case "LineChart":
                    cardChart.Chart = new LineChart { Entries = entries };
                    break;
                case "RadialGaugeChart":
                    cardChart.Chart = new RadialGaugeChart { Entries = entries };
                    break;
                case "RadarChart":
                    cardChart.Chart = new RadarChart { Entries = entries };
                    break;
                default:
                    cardChart.Chart = new DonutChart { Entries = entries };
                    break;
            }

            cardChart.Chart.BackgroundColor = SKColors.Transparent;
        }

        private void ChangeGraph_Tapped(object sender, EventArgs e)
        {
            cardChart.Chart = new BarChart { Entries = _entries };
        }
    }
}