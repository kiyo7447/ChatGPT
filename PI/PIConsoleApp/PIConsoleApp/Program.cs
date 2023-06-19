// See https://aka.ms/new-console-template for more information

using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Numerics.MPFR;


//開始ログをConsoleに出力します。
Console.WriteLine("Start PIConsoleApp");


Console.WriteLine("Hello, World!");

int precision = 10000; // 計算する精度を設定します。この数値が大きいほど、精度が高まります。

Console.WriteLine(ComputePiチュードーンサリアナアルゴリズム(precision));

//終了ログをConsoleに出力します。
Console.WriteLine("End PIConsoleApp");

//こいつは、チュードーンサリアナアルゴリズムを使って円周率を計算する関数です。
//しかし、結果の桁数は低いです。なぜなら、double型を使っているからです。
//3.14144648
static double ComputePiチュードーンサリアナアルゴリズム(int digits)
{
    const int Digits = 1000;
    const int Iterations = 100000000; // 10億回試行
    BigInteger totalPoints = 0;
    BigInteger circlePoints = 0;

    RandomNumberGenerator rng = RandomNumberGenerator.Create();

    for (int i = 0; i < Iterations; i++)
    {
        double x = GetNextRandomDouble(rng);
        double y = GetNextRandomDouble(rng);

        if (x * x + y * y <= 1)
            circlePoints++;

        totalPoints++;
    }

    // モンテカルロ法による円周率の近似値計算
    double piApproximation = 4.0 * (double)circlePoints / (double)totalPoints;

    Console.WriteLine($"円周率の近似値（モンテカルロ法、試行回数 {Iterations}回）: {piApproximation}");

    return piApproximation;
}

static double GetNextRandomDouble(RandomNumberGenerator rng)
{
    byte[] bytes = new byte[8];
    rng.GetBytes(bytes);
    ulong randomUint64 = BitConverter.ToUInt64(bytes);
    return (double)randomUint64 / ulong.MaxValue;
}


static BigInteger ComputePiMonteCarlo(int digits)
{
    int Digits = digits;
    int ExtraDigits = 10;
    int Scale = Digits + ExtraDigits;

    BigInteger pi = BigInteger.Zero;
    BigInteger a = ScaleB(1, Scale);

    for (int k = 0; k <= Scale; k++)
    {
        // 8k + 1 term
        BigInteger t = BigInteger.DivRem(a, 8 * k + 1, out _);
        pi += t;

        // 8k + 4 term
        t = BigInteger.DivRem(a, 8 * k + 4, out _);
        pi -= t;

        // 8k + 5 term
        t = BigInteger.DivRem(a, 8 * k + 5, out _);
        pi -= t;

        // 8k + 6 term
        t = BigInteger.DivRem(a, 8 * k + 6, out _);
        pi -= t;

        a = BigInteger.DivRem(a * 16, 1, out _);
    }

    pi *= 4;

    string pi_str = pi.ToString().Insert(1, ".");
    Console.WriteLine(pi_str.Substring(0, Digits + 1));

    return pi; 
}

static BigInteger ScaleB(int num, int scale)
{
    return BigInteger.Pow(10, scale) * num;
}


