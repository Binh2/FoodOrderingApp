﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    class OperationType : Attribute
    {
        string type;
        public string Type { get => type; }
        public OperationType(string operationType)
        {
            switch (operationType)
            {
                case ("Insert"):
                case ("Update"):
                case ("Delete"):
                case ("Select"):
                    type = operationType;
                    break;
            }
            throw new ArgumentException("operationType can only be Insert or Update or Delete or Select");
        }
    }
}
