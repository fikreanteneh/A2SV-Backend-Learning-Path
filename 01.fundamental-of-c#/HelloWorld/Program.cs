// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

// Task3.gradeCalc();

Dictionary<char, int> dict = Task2.counter("Hello World");

foreach (KeyValuePair<char, int> kvp in dict )
{
    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
}