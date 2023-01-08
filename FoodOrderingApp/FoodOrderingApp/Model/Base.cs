using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.Model
{
    public interface IBase
    {
        string pluralTable { get; }
        string byColumn { get; set; }
        object byValue { get; set; }
    }
}
