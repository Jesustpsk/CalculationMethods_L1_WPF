using System;

namespace CalculationMethods_L1_WPF;

public static class CalcMeth
{
    public static double F(double x)
    {
        return 4 * x + Math.Pow(Math.E, x);
    }

    public static double FDerivative(double x)
    {
        return 4 + Math.Pow(Math.E, x);
    }
    public static double BisectionMethod(double a, double b, double epsilon)
    {
        if (F(a) * F(b) >= 0)
        {
            throw new ArgumentException("Функция должна иметь разные знаки на концах интервала");
        }

        var c = a;
        while ((b - a) >= epsilon)
        {
            c = (a + b) / 2;
        
            if (Math.Abs(F(c)) < epsilon)
            {
                break;
            }
            else if (F(c) * F(a) < 0)
            {
                b = c;
            }
            else
            {
                a = c;
            }
        }

        return c;
    }
    public static double NewtonMethod(double a, double b, double epsilon)
    {
        var x0 = (a + b) / 2;
        var xN = F(x0);
        var xN1 = xN - F(xN) / FDerivative(xN);
        while (Math.Abs(xN1 - xN) > epsilon)
        {
            xN = xN1;
            xN1 = xN - F(xN) / FDerivative(xN);
        }
        return xN1;
    }

    public static double CombinedMethod(double a, double b, double epsilon)
    {
        var x0 = a;
        var x1 = b;
        var fX0 = F(x0);
        var fX1 = F(x1);
        while (Math.Abs(fX1) > epsilon)
        {
            var x2 = x1 - fX1 * (x1 - x0) / (fX1 - fX0);
            x0 = x1;
            x1 = x2;
            fX0 = fX1;
            fX1 = F(x1);
        }
        return x1;
    }

    public static double ChordMethod(double a, double b, double epsilon)
    {
        if (F(a) * F(b) >= 0)
        {
            throw new ArgumentException("Функция должна иметь разные знаки на концах интервала");
        }

        var x = a;
        double prevX;
        do
        {
            prevX = x;
            x -= (b - a) * F(x) / (F(b) - F(a));
        
            if (Math.Abs(F(x)) < epsilon)
            {
                break;
            }
            else if (F(x) * F(a) < 0)
            {
                b = x;
            }
            else
            {
                a = x;
            }
        }
        while (Math.Abs(x - prevX) >= epsilon);

        return x;
    }
    
}