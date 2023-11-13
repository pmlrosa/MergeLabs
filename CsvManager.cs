using System.Text.RegularExpressions;

namespace MergeLabs
{
public class CsvManager
{
    private const char CsvNewLineCharacter = '\n';
    private const char CsvCellSeperator = ',';
    private const string CsvNullCellIdentifier = "NULL";

    public static string SimpleTransformCsv(string input)
    {
            if (string.IsNullOrEmpty(input))
            { //The input string is null or empty
                return input; //Return the same input string 
            }

            string[] inputLines = Regex.Split(input, $"{CsvNewLineCharacter}"); //Splits the input text into lines
            if (inputLines.Length <= 1)
            { //Input string has no line breaker char
                return input; //Return the same input string
            }

            string output = inputLines[0]; //Write the headers to the text to return
            //The pattern to check if the line is removed or not. Searchs for ,NULL or NULL,
            string pattern = $"({CsvCellSeperator}{CsvNullCellIdentifier}|{CsvNullCellIdentifier}{CsvCellSeperator})";
            for (int line = 1; line < inputLines.Length; line++)
            {
                if (!Regex.IsMatch(inputLines[line], pattern))
                { //Line doesn't have a cell with NULL value
                    output = output + CsvNewLineCharacter + inputLines[line]; //Write the line to the text to return
                }
            }

            return output;
        }

        public static string TransformCsv(string input)
        {
            if (string.IsNullOrEmpty(input))
            { //The input string is null or empty
                return input; //Return the same input string 
            }

            //The first line is the headers
            int idxHeaders = input.IndexOf(CsvNewLineCharacter); //Gets the headers end of line index
            if (idxHeaders == -1)
            { //There is no line breaker char
                return input; //Return the same input string
            };

            string output = input.Substring(0, idxHeaders); //Write the headers in the text to return
            //Get the lines with the data that are after the headers
            string[] inputLines = input.Substring(idxHeaders + 1).Split(CsvNewLineCharacter);
            if (inputLines.Length <= 1)
            { //There is no more line breakers char
                if (!LineHasNullCellIdentifier(inputLines[0]))
                { //Line doesn't have a cell with NULL value
                    output = output + CsvNewLineCharacter + inputLines[0]; //Write the line to the text to return
                }
            }
            else
            { //There is more line breakers char
                for (int line = 0; line < inputLines.Length; line++)
                {
                    if (!LineHasNullCellIdentifier(inputLines[line]))
                    { //Line doesn't have a cell with NULL value
                        output = output + CsvNewLineCharacter + inputLines[line]; //Write the line to the text to return
                    }
                }
            }

            return output;
        }

        private static bool LineHasNullCellIdentifier(string line)
        {
            bool hasNull = false;
            string[] words = line.Split(CsvCellSeperator);
            foreach (string word in words)
            {
                if (word == CsvNullCellIdentifier)
                {
                    hasNull = true;
                    break;
                }
            }

            return hasNull;
        }
    }
}