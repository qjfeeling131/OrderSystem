﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Model.DTO
{
    public class OM_B1InfomationDTO
    {
        int _GSCode;

        public int GSCode
        {
            get { return _GSCode; }
            set { _GSCode = value; }
        }

        string _GSMessage;

        public string GSMessage
        {
            get { return _GSMessage; }
            set { _GSMessage = value; }
        }

        int _JFZCode;

        public int JFZCode
        {
            get { return _JFZCode; }
            set { _JFZCode = value; }
        }
        string _JFZMessage;

        public string JFZMessage
        {
            get { return _JFZMessage; }
            set { _JFZMessage = value; }
        }

        bool _IsException;

        public bool IsException
        {
            get { return _IsException; }
            set { _IsException = value; }
        }

        string _ExceptionMessage;

        public string ExceptionMessage
        {
            get { return _ExceptionMessage; }
            set { _ExceptionMessage = value; }
        }
    }
}
