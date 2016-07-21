using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
  public class XCosmoWeatherParser
  {
    List<int> _dayToday;
    List<int> _dayTomorrow;
    List<int> _dayAfterTomorrow;
    String _rawData;
    bool _dataOld;

    public XCosmoWeatherParser()
    {
      _dayToday = new List<int>();
      _dayTomorrow = new List<int>();
      _dayAfterTomorrow = new List<int>();
      _rawData = "";
      _dataOld = false;
    }

    public XCosmoWeatherParser(String s)
    {
      _dayToday = new List<int>();
      _dayTomorrow = new List<int>();
      _dayAfterTomorrow = new List<int>();
      _rawData = s;
      _dataOld = false;
    }

    bool GetPoints(int i)
    {
      int length = _rawData.Length;
      int points = 0;
      string point = "";

      for (int j = i + 7; j < length; ++j)
      {
        if (points == 3)
          break;

        if (_rawData[j] != 0x0020 && _rawData[j] != 0x000d && _rawData[j] != 0x000a)
        {
          point += _rawData[j];
        }
        else
        {
          if (point == "")
            continue;

          try
          {
            int p = Convert.ToInt32(point, 10);

            switch (points)
            {
              case 0:
                _dayToday.Add(p);
                break;
              case 1:
                _dayTomorrow.Add(p);
                break;
              case 2:
                _dayAfterTomorrow.Add(p);
                break;
              default:
                return false;
            }
            ++points;
            point = "";
            continue;
          }
          catch (SystemException e)
          {
            return false;
          }
        }
      }

      if (points != 3)
        return false;
      return true;
    }

    public bool LoadData()
    {
      if (_rawData.IndexOf("0030 UTC") == -1)
      {
        if (_rawData.IndexOf("1230 UTC") == -1)
          return false;
        else
          _dataOld = true;
      }

      _rawData = _rawData.Replace("(G1)", "    ");
      _rawData = _rawData.Replace("(G2)", "    ");
      _rawData = _rawData.Replace("(G3)", "    ");
      _rawData = _rawData.Replace("(G4)", "    ");
      _rawData = _rawData.Replace("(G5)", "    ");
      _rawData = _rawData.Replace("       ", " ");

      int index = _rawData.IndexOf("00-03UT");

      if (!(index > -1 && GetPoints(index)))
        return false;

      index = _rawData.IndexOf("03-06UT");
      if (!(index > -1 && GetPoints(index)))
        return false;

      index = _rawData.IndexOf("06-09UT");
      if (!(index > -1 && GetPoints(index)))
        return false;

      index = _rawData.IndexOf("09-12UT");
      if (!(index > -1 && GetPoints(index)))
        return false;

      index = _rawData.IndexOf("12-15UT");
      if (!(index > -1 && GetPoints(index)))
        return false;

      index = _rawData.IndexOf("15-18UT");
      if (!(index > -1 && GetPoints(index)))
        return false;

      index = _rawData.IndexOf("18-21UT");
      if (!(index > -1 && GetPoints(index)))
        return false;

      index = _rawData.IndexOf("21-00UT");
      if (!(index > -1 && GetPoints(index)))
        return false;        

      return true;
    }

    public List<int> GetTodayWeather()
    {
      if (_dataOld)
        return _dayTomorrow;
      return _dayToday;
    }

    public List<int> GetTomorrowWeather()
    {
      if (_dataOld)
        return _dayAfterTomorrow;
      return _dayTomorrow;
    }

  }
}
