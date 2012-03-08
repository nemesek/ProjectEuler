using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
public static class StopwatchExtensions
{
    /// <summary>
    /// Extends the Stopwatch class with a method to time an Action delegate
    /// </summary>
    /// <param name="stopwatch"></param>
    /// <param name="action"></param>
    public static void Time(this Stopwatch stopwatch, Action action)
    {
        stopwatch.Time(action, 1);
    }

    public static void Time(this Stopwatch stopwatch, Action action, long numberOfIterations)
    {
        stopwatch.Reset();
        stopwatch.Start();

        for (int i = 0; i < numberOfIterations; i++)
        {
            action();
        }

        stopwatch.Stop();
    }

    public static double TimeInFractionalSeconds(this Stopwatch stopwatch)
    {
        // figure out how much of a second a Stopwatch tick represents
        double secondsPerTick = (double)1 / Stopwatch.Frequency;

        return stopwatch.ElapsedTicks*secondsPerTick;
    }
}
}
