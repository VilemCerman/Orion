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
    public partial class CardDetail : ContentView
    {
 //       private ChartEntry[] entries = new[]
 //{
 //            new ChartEntry(212)
 //            {
 //                Label = "UWP",
 //                ValueLabel = "212",
 //                Color = SKColor.Parse("#8931EF"),
 //                ValueLabelColor = SKColor.Parse("#8931EF"),
 //                TextColor = SKColor.Parse(ThemeManager.graphTextColor)
 //            },
 //            new ChartEntry(248)
 //            {
 //                Label = "Android",
 //                ValueLabel = "248",
 //                Color = SKColor.Parse("#FF00BD"),
 //                ValueLabelColor = SKColor.Parse("#FF00BD"),
 //                TextColor = SKColor.Parse(ThemeManager.graphTextColor)
 //            },
 //            new ChartEntry(128)
 //            {
 //                Label = "iOS",
 //                ValueLabel = "128",
 //                Color = SKColor.Parse("#87E911"),
 //                ValueLabelColor = SKColor.Parse("#87E911"),
 //                TextColor = SKColor.Parse(ThemeManager.graphTextColor)
 //            },
 //            new ChartEntry(514)
 //            {
 //                Label = "Shared",
 //                ValueLabel = "514",
 //                Color = SKColor.Parse("#E11845"),
 //                ValueLabelColor = SKColor.Parse("#E11845"),
 //                TextColor = SKColor.Parse(ThemeManager.graphTextColor)
 //       } };
        public string GraphType { get; private set; }
        public string[,] Data { get; private set; }
        public CardDetail(string graphType, string[,] data)
        {
            InitializeComponent();
            ThemeManager.LoadTheme();

            GraphType = graphType;
            Data = data;

            App.Globals.LastViewedGraph = graphType;
            App.Globals.LastViewedData = data;

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
                        Label = data[0, i],
                        ValueLabel = data[1, i],
                        ValueLabelColor = SKColor.Parse(GraphColors.DarkColorsArray[i - someClrLdngVar]),
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
                        Label = data[0, i],
                        ValueLabel = data[1, i],
                        ValueLabelColor = SKColor.Parse(GraphColors.ColorsArray[i - someClrLdngVar]),
                        Color = SKColor.Parse(GraphColors.ColorsArray[i - someClrLdngVar])
                    };
                }
            }

            switch (GraphType)
            {
                case "BarChart":
                    Chart.Chart = new BarChart { Entries = entries };
                    break;
                case "LineChart":
                    Chart.Chart = new LineChart { Entries = entries };
                    break;
                case "RadialGaugeChart":
                    Chart.Chart = new RadialGaugeChart { Entries = entries };
                    break;
                case "RadarChart":
                    Chart.Chart = new RadarChart { Entries = entries };
                    break;
                default:
                    Chart.Chart = new DonutChart { Entries = entries };
                    break;
            }

            Chart.Chart.BackgroundColor = SKColors.Transparent;
            ChartFrame.BackgroundColor = Color.FromHex(ThemeManager.CardBackgroundColor);
            ChartTitle.TextColor = Color.FromHex(ThemeManager.TextColor);
        }
    }
}