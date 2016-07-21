using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Net;


namespace Weather
{
  [DataContract]
  internal class Pogoda
  {
    [DataMember]
    internal string name;

    [DataMember]
    internal int _id;

    [DataMember]
    internal string country;
  }

  [DataContract]
  internal class Configuration
  {
    [DataMember]
    internal string key;

    [DataMember]
    internal string locationname;

    [DataMember]
    internal string locationid;
  }


  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {

    long _temp;

    public MainWindow()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Pogoda)); //
      MemoryStream stream = new MemoryStream();
      //MemoryStream tofile = new MemoryStream();
      StreamWriter writer = new StreamWriter(stream);
      //StreamReader file = new System.IO.StreamReader("x:\\city.list.json");
      //string line;
      //Pogoda w;
      //while ((line = file.ReadLine()) != null)
      //{
      //  writer.Write(line);
      //  writer.Flush();
      //  stream.Position = 0;
      //  w = (Pogoda)ser.ReadObject(stream);
      //  stream.SetLength(0);
      //  if (w.country.Equals("RU"))
      //  {
      //    ser.WriteObject(tofile, w);
      //    writer.Write("\n");
      //    writer.Flush();
      //  }
      //}
      //FileStream fs = File.Create("x:\\russia.json");
      //tofile.WriteTo(fs);
      //fs.Close();

      //"9f54e8f43f8e66ec08255ddbba4b1964"
      string url = /*"https://msdn.microsoft.com/en-us/library/456dfw4f(v=vs.110).aspx";
      //*/"http://api.openweathermap.org/data/2.5/weather?id=524894&units=metric&lang=ru&appid=9f54e8f43f8e66ec08255ddbba4b1964";
      WebRequest webRequesto = WebRequest.Create(url);
      

      //WebResponse webResp = webRequest.GetResponse();
      //Stream objStream = webResp.GetResponseStream();
      //StreamReader reader = new StreamReader(objStream);
      //string responseFromServer = reader.ReadToEnd();
      ////objStream.Position = 0;
      //writer.Write(responseFromServer);
      writer.Flush();
      stream.Position = 0;
      //Pogoda pp = (Pogoda)ser.ReadObject(stream);
      writer.Close();
      //reader.Close();
      //webResp.Close();

      //===============================================================================================================
/*
      WebRequest webRequest = WebRequest.Create("http://services.swpc.noaa.gov/text/3-day-forecast.txt");
      WebResponse wcosm = webRequest.GetResponse();

      Stream sscosm = wcosm.GetResponseStream();
      StreamReader rcosm = new StreamReader(sscosm);
      String scosm = rcosm.ReadToEnd();

      XCosmoWeatherParser cosmoweather = new XCosmoWeatherParser(scosm);
      if(cosmoweather.LoadData())
      {
        List<int> today = cosmoweather.GetTodayWeather();
        List<int> tomorrow = cosmoweather.GetTomorrowWeather();
      }
*/
      //===============================================================================================================

      





    }
  }
}
