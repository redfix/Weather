using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
  public class XWeatherParser
  {    
    enum Direction 
    {
      North, South, East, West, Northwest, Northeast, Southwest, Southeast
    }
    public XWeatherParser() { }
    float GetTemp();
    float GetPressure();
    int GetHumidity();
    float GetWindSpeed();
    Direction GetWindDirection();
    String GetDescription();
    String GetIcon();

  }
}
