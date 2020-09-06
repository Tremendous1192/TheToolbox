using System;
using System.Collections.Generic;
using System.Text;

namespace TheToolbox.DataProcessing.Base
{
    public interface IRandomNumber
    {
        double NextDouble();
        decimal NextDecimal();

    }
}
