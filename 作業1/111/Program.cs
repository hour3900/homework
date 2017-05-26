using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _111
{
    class Program
    {
        static void Main(string[] args)
        {
            var stations = FindStations();
            showStation(stations);
            Console.ReadLine();

        }

        public static List<Station> FindStations()
        {
            List<Station> stations = new List<Station>();
            var xml = XElement.Load(@"C:\Users\user\Desktop\A17000000J-000003-xCS.xml");
            var stationsData = xml.Descendants("DATA").ToList();


            stationsData
                .Where(x => !x.IsEmpty).ToList()
                .ForEach(stationData =>
                {


                    var colum_1 = stationData.Element("colum_1").Value.Trim();
                    var colum_2 = stationData.Element("colum_2").Value.Trim();
                    var colum_3 = stationData.Element("colum_3").Value.Trim();
                    var colum_4 = stationData.Element("colum_4").Value.Trim();
                    var colum_5 = stationData.Element("colum_5").Value.Trim();

                    Station Data = new Station();
                    Data.colum_1 = colum_1;
                    Data.colum_2 = colum_2;
                    Data.colum_3 = colum_3;
                    Data.colum_4 = colum_4;
                    Data.colum_5 = colum_5;
                    stations.Add(Data);

                });
            return stations;
       }
        public static void showStation(List<Station> stations)
        {
            Console.WriteLine(string.Format("共收到{0}筆醫院的資料", stations.Count));
            stations.ForEach(x =>
            {

                Console.WriteLine(string.Format("名稱：{0}，地址：{1}", x.colum_2, x.colum_5));
          
            });


        }

    }
}
