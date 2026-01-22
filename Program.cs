using System;
using Mission3Assignment;

// Quote Analyzer Application
// Analyzes user-provided quotes for word count, character count, and letter frequency

Console.WriteLine("Please enter a quote to analyze");
string? userQuote = Console.ReadLine();

if (string.IsNullOrWhiteSpace(userQuote))
{
    Console.WriteLine("No quote provided. Exiting.");
    return;
}

QuoteTools analyzer = new QuoteTools();

int wordCount = analyzer.CountWords(userQuote);
int characterCount = analyzer.CountCharacters(userQuote);
string letterFrequencies = analyzer.GetLetterFrequencies(userQuote);

Console.WriteLine();
Console.WriteLine($"Quote: \"{userQuote}\"");
Console.WriteLine($"Words: {wordCount}");
Console.WriteLine($"Characters (including spaces): {characterCount}");
Console.WriteLine(letterFrequencies);
