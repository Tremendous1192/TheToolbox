using System;
using System.Collections.Generic;
using System.Text;

namespace TheToolbox.DataProcessing.Base
{
    public partial class TypeChange
    {
        public static string Change_String(double input)
        {
            return (Math.Round(input * 1000.0 * 1000.0 * 1000.0) / (1000.0 * 1000.0 * 1000.0)).ToString();
        }

    }
}
