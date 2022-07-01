// See https://aka.ms/new-console-template for more information

using Ardalis.GuardClauses;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

Console.WriteLine("Runs tests to check which is quicker to check for null.");

BenchmarkRunner.Run<ArgNullTests>();

public class ArgNullTests
{
    [Benchmark]
    public object IfStatement()
    {
        object test = null;

        try
        {
            if (test is null)
            {
                throw new ArgumentNullException(nameof(test), "test is null");
            }
        }
        catch (Exception e)
        {

        }

        return test;
    }

    [Benchmark]
    public object ThrowIfNull()
    {
        object test = null;

        try
        {
            ArgumentNullException.ThrowIfNull(test, nameof(test));
        }
        catch (Exception e)
        {
        }

        return test;
    }

    [Benchmark]
    public object ArdalisNull()
    {
        object test = null;

        try
        {
            Guard.Against.Null(test, nameof(test));
        }
        catch (Exception e)
        {
        }
        
        return test;
    }
}