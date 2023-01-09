using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.Model
{
    public interface IBase
    {
        string pluralTable { get; }
        string uniqueColumn { get; set; }
        string IDColumn { get; }
        List<string> parameterColumns { get; }
    }
}
