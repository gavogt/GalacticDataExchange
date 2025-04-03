using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange
{
    internal class AlienLanguageConverter
    {
        private static readonly Dictionary<char, string> LetterToAlien = new Dictionary<char, string>()
        {
            { 'A', "⟡" },
            { 'B', "⚸" },
            { 'C', "∇" },
            { 'D', "∞" },
            { 'E', "⊕" },
            { 'F', "∆" },
            { 'G', "⚛" },
            { 'H', "⟟" },
            { 'I', "⟠" },
            { 'J', "⇝" },
            { 'K', "☍" },
            { 'L', "☋" },
            { 'M', "☌" },
            { 'N', "♒" },
            { 'O', "♏" },
            { 'P', "☽" },
            { 'Q', "☾" },
            { 'R', "⚹" },
            { 'S', "✶" },
            { 'T', "✱" },
            { 'U', "✲" },
            { 'V', "✳" },
            { 'W', "✴" },
            { 'X', "✵" },
            { 'Y', "✷" },
            { 'Z', "✸" }
        };

        private static readonly Dictionary<string, char> AlienToLetter = LetterToAlien.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);


        /// <summary>
        /// Encodes a given string into an alien language representation.
        /// </summary>
        /// <param name="input">Takes a string input that's human readable.</param>
        /// <returns>The encoded alien text.</returns>
        internal static string Encode(string input)
        {
            // Check if the input string is null or empty
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            // Initialize a StringBuilder to build the encoded string
            StringBuilder encoded = new StringBuilder();

            // Convert the input string to uppercase to match the dictionary keys
            foreach (char c in input.ToUpperInvariant())
            {
                if (LetterToAlien.TryGetValue(c, out string? alienChar))
                {
                    encoded.Append(alienChar); // Append the alien character if found in the dictionary
                }
                else
                {
                    encoded.Append(c); // Append the character as is if not found in the dictionary
                }

            }

            // Convert StringBuilder to a regular string and return the Alien TExt
            return encoded.ToString();

        }

        /// <summary>
        /// Decodes a given alien text back into human readable format.
        /// </summary>
        /// <param name="alienText">The alien glyph text.</param>
        /// <returns>A human readable string</returns>
        internal static string Decode(string alienText)
        {
            // Check if the alien text is null or empty
            if (string.IsNullOrEmpty(alienText))
                return string.Empty;

            foreach (var kvp in AlienToLetter)
            {
                // Replace each alien character with its corresponding letter
                alienText = alienText.Replace(kvp.Key, kvp.Value.ToString());
            }

            // Return the human readable string
            return alienText;
        }
    }
}
