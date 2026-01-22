using System;

namespace Mission3Assignment;

/// <summary>
/// Provides utility methods for analyzing quotes and text input.
/// </summary>
public class QuoteTools
{
    /// <summary>
    /// Counts the number of words in the input string.
    /// Splits on spaces and removes empty entries.
    /// </summary>
    /// <param name="input">The text input to analyze</param>
    /// <returns>The number of words found, or 0 if input is null or whitespace</returns>
    public int CountWords(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return 0;
        }

        return input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
    }

    /// <summary>
    /// Counts the total number of characters in the input string, including spaces.
    /// </summary>
    /// <param name="input">The text input to analyze</param>
    /// <returns>The total character count, or 0 if input is null</returns>
    public int CountCharacters(string input)
    {
        if (input == null)
        {
            return 0;
        }

        return input.Length;
    }

    /// <summary>
    /// Analyzes letter frequency in the input string (case-insensitive, A-Z only).
    /// Returns a formatted string showing the frequency of each letter.
    /// </summary>
    /// <param name="input">The text input to analyze</param>
    /// <returns>A formatted string showing letter frequencies from A to Z</returns>
    public string GetLetterFrequencies(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return BuildFrequencyOutput(new int[26]);
        }

        int[] counts = new int[26];

        foreach (char ch in input)
        {
            char lowerCh = char.ToLower(ch);
            
            if (lowerCh >= 'a' && lowerCh <= 'z')
            {
                counts[lowerCh - 'a']++;
            }
        }

        return BuildFrequencyOutput(counts);
    }

    /// <summary>
    /// Builds the formatted output string for letter frequencies.
    /// </summary>
    /// <param name="counts">Array of 26 integers representing A-Z frequencies</param>
    /// <returns>Formatted string with letter frequencies</returns>
    private string BuildFrequencyOutput(int[] counts)
    {
        System.Text.StringBuilder output = new System.Text.StringBuilder();
        output.AppendLine("Letter frequency:");

        for (int i = 0; i < 26; i++)
        {
            char letter = (char)('A' + i);
            output.AppendLine($"{letter}: {counts[i]}");
        }

        return output.ToString();
    }
}
