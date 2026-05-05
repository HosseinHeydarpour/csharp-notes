using System.Text.RegularExpressions;

namespace RegexApp
{
    // What are Regular Expressions
    // A sequence of characters that define a search pattern.
    // These patterns are used to match and manipulate strings based on specific criteria,
    // allowing for powerful text processing and data validation.
    // Example breakdown of a regular expression:
    // /[\w._%±]+@[\w.-]+.[a-zA-Z]{2,4}/
    // [\w._%±]+ → match any word character, dot, underscore, percent, plus, or hyphen,
    // as many times as possible
    // @ → match the @ symbol
    // [\w.-]+ → match any word character, dot, or hyphen
    // . → match a literal dot
    // [a-zA-Z]{2,4} → match upper- or lowercase letters, at least 2 times but no more than 4 times


    // Why Use Regular Expressions?
    // Validate inputs (emails, URLs, etc.).
    // Ensure that user-entered data adheres to the required format,
    // such as checking if an email address or URL is valid.
    //-------
    // Search and replace text.
    // Efficiently find and replace specific patterns within large texts,
    // streamlining data cleaning and modification tasks.
    //-------
    // Extract specific patterns.
    // Identify and extract meaningful data, such as phone numbers or dates,
    // from unstructured text for further processing.
    //-------

    // Regex in Various Languages
    // Regex is a universal tool used across many programming languages,
    // including, but not limited to,
    // C#, C++, Java, JavaScript, and Python.

    internal class Program
    {
        static void Main(string[] args)
        {
            // To get all the digits
            //string pattern = @"\d";
            string pattern = @"\d{5}";
            Regex regex = new Regex(pattern);

            string text = "Hi there my number is: 123456";

            MatchCollection matchCollection = regex.Matches(text);

            Console.WriteLine("{0} hits found: \n {1}", matchCollection.Count, text);

            foreach (Match hit in matchCollection) 
            {
                GroupCollection group = hit.Groups;
                
                Console.WriteLine("{0} found at {1}", group[0].Value, group[0].Index);
            }

            Console.ReadKey();
        }
    }
}
