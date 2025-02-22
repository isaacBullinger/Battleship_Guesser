using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

public class Cell
{
    private char _indicator;

    public Cell()
    {
        _indicator = ' ';
    }

    public char GetIndicator()
    {
        return _indicator;
    }

    public void SetIndicator(char indicator)
    {
        _indicator = indicator;
    }
}