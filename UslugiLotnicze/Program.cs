﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Reflection;
using UslugiLotnicze;

class Program
{
    static void Main(string[] args)
    {
        TextInterface textInterface = new TextInterface();
        textInterface.ShowMenu();
    }
}