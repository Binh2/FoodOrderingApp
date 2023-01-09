using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    class OperationType : Attribute
    {
        string _type;
        public string Type { get => _type; }
        public OperationType(string operationType)
        {
            if (isValidOperationType(operationType)) _type = operationType;
            else throw new ArgumentException("operationType can only be Insert or Update or Delete or Select");
        }
        static public bool isValidOperationType(string operationType)
        {
            switch (operationType)
            {
                case ("Insert"):
                case ("Update"):
                case ("Delete"):
                case ("Select"):
                    return true;
            }
            return false;
        }
    }
}
