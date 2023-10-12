using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CA23101205
{
    class Program
    {
        static void Main()
        {
            var requiests = new List<Request>();
            using var sr = new StreamReader(@"..\..\..\src\NASAlog.txt", Encoding.UTF8);
            while (!sr.EndOfStream) requiests.Add(new(sr.ReadLine()));

            Console.WriteLine($"5. feladat: Kérések száma: {requiests.Count}");

            var f6 = requiests.Sum(r => r.ByteSize);
            Console.WriteLine($"6. feladat: Válaszok összmérete: {f6} byte");

            var f8 = (float)requiests.Count(r => r.HaveDomain) / requiests.Count * 100f;
            Console.WriteLine($"8. feladat: Domaines kérések: {f8:0.00}%");

            var f9 = requiests
                .GroupBy(r => r.Status)
                .ToDictionary(k => k.Key, v => v.Count());
            Console.WriteLine("9. feladat: Statisztika:");
            foreach (var kvp in f9) Console.WriteLine($"\t{kvp.Key}: {kvp.Value,4} db");

        }
    }
}
