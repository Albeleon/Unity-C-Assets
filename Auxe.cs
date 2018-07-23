/*
 * Auxe (Auxiliar Extension):
 * This file contains the main method extensions developed to facilitate functions made in C#.
 * It only needs the library "System", "System.Collections.Generic" and "System.Xml.Linq" to work, so it's usable in any C# project.
 * 
 * Developed by Alberto León Meaños, 22/07/2018, License GNU General Public License v3.0
 * */


using System;
using System.Collections.Generic;
using System.Xml.Linq;


/*
 * Delegates -> TDelegate:
 * A Generic Delegate that allows any type. This will allow to use any delegate for some of the upcoming functions.
 * There are currently five versions of this TDelegate with more or less input arguments of other generic different types.
 * It doesn't allow more than 4 input arguments.
 * */
public delegate T TDelegate<T>();
public delegate T TDelegate<T, T1>(T1 arg1);
public delegate T TDelegate<T, T1, T2>(T1 arg1, T2 arg2);
public delegate T TDelegate<T, T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3);
public delegate T TDelegate<T, T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);


/*
 * Delegates -> VoidDelegate:
 * A Delegate that returns void. This will allow to use void functions and to complement what TDelegate is missing.
 * There are currently five versions of this TDelegate with more or less input arguments of other generic different types.
 * It doesn't allow more than 4 input arguments.
 * */
public delegate void VoidDelegate();
public delegate void VoidDelegate<T1>(T1 arg1);
public delegate void VoidDelegate<T1, T2>(T1 arg1, T2 arg2);
public delegate void VoidDelegate<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3);
public delegate void VoidDelegate<T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);


public static class Auxe
{
    /////////////////// T EXTENSIONS /////////////////////

    /*
     * T[] [T value].Array<T>() / static T[] Array<T>(T value):
     *      Function: Returns an array of size 1 with the element inserted.
     *      Usefulness: For code that uses operations on only arrays and needs a particular element turned into one.
     *      
     * List<T> [T value].List<T>() / static List<T> List<T>(T value):
     *      Function: Returns a list of size 1 with the element inserted.
     *      Usefulness: For code that uses operations on only lists and needs a particular element turned into one.
     * */
    public static T[] Array<T>(this T value)
    {
        return new T[] { value };
    }
    public static List<T> List<T>(this T value)
    {
        return new List<T>(value.Array());
    }


    /////////////////// ICOMPARABLE EXTENSIONS /////////////////////

    /*
     * bool [T value].Between<T>(T min, T max) / static T[] Between<T>(T value, T min, T max) { where T : IComparable }:
     *      Function: Returns whether a value is inside two other values (min and max).
     *      Usefulness: To both quickly calculate whether a number is inside with one function. Usable for Delegates.
     * */
    public static bool Between<T>(this T value, T min, T max) where T : IComparable
    {
        return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
    }


    /////////////////// INT EXTENSIONS /////////////////////

    /*
     * int [int number].Abs() / static int Abs(int number):
     *      Function: Returns the absolute value of a number.
     *      Usefulness: To quickly calculate a value's number with its own method without overstuffing the code with "Math.Abs(x)".
     *      Returned also in "int" value.
     *      Based on: Math.Abs().
     * */
    public static int Abs(this int number)
    {
        return Math.Abs(number);
    }

    /*
     * int [int number].Pow(int potenc) / static int Pow(int number, int potenc):
     *      Function: Returns the power value of a number to a specific value.
     *      Usefulness: To quickly calculate a value's power number with its own method without overstuffing the code with "Math.Pow(x, y)".
     *      Returned also in "int" value.
     *      Based on: Math.Pow().
     * */
    public static int Pow(this int number, int potenc)
    {
        return (int) Math.Pow(number, potenc);
    }


    /////////////////// FLOAT EXTENSIONS /////////////////////

    /*
     * float [float number].Abs() / static float Abs(float number):
     *      Function: Returns the absolute value of a number.
     *      Usefulness: To quickly calculate a value's number with its own method without overstuffing the code with "Math.Abs(x)".
     *      Returned also in "float" value.
     *      Based on: Math.Abs().
     * */
    public static float Abs(this float number)
    {
        return Math.Abs(number);
    }

    /*
     * float [float number].Pow(float potenc) / static float Pow(float number, float potenc):
     *      Function: Returns the power value of a number to a specific value.
     *      Usefulness: To quickly calculate a value's power number with its own method without overstuffing the code with "Math.Pow(x, y)".
     *      Returned also in "float" value.
     *      Based on: Math.Pow().
     * */
    public static float Pow(this float number, float potenc)
    {
        return (float)Math.Pow(number, potenc);
    }

    /*
     * float [float number].Floor() / static float Floor(float number):
     *      Function: Returns the floor number of a specific value.
     *      Usefulness: To quickly calculate a value's floor number with its own method without overstuffing the code with "Math.Floor(x)".
     *      Returned also in "float" value.
     *      Based on: Math.Floor().
     *      
     * float [float number].Floor(float chunk) / static float Floor(float number, float chunk):
     *      Function: Returns the floor number of a specific value in a particular multiple of chunks.
     *      Usefulness: To quickly calculate a value's floor number in a particular set of chunks.
     *      i.e. if we want to filter a value (3.9) in 0.4 / 0.5 multiples, by putting these data, it returns 3.6 / 3.5
     *      Based on: Math.Floor().
     * */
    public static float Floor(this float number)
    {
        return (float)Math.Floor(number);
    }
    public static float Floor(this float number, float chunk)
    {
        return (float)Math.Floor(number / chunk) * chunk;
    }
    

    /////////////////// STRING EXTENSIONS /////////////////////

    //      (Properties):
    public static readonly string formatNumber = "0123456789.";
    public static readonly string formatNumberNatural = "0123456789";
    public static readonly char[] formatChar = { ' ', '\n', '\r' };
    public static readonly string formatOperator = "+-*/";
    public static readonly string formatBrackets = "()";
    public static readonly string[] formatString = { " ", "\n", "\r" };


    //      (Static Functions):

    /*
     * static bool Contains(string content, string format):
     *      Function: Returns whether "format" is contained in "content".
     *      Usefulness: To use this function in List functions with two input arguments to fill.
     * */
    public static bool Contains(string content, string format)
    {
        return content.Contains(format);
    }

    /*
     * static bool IndexOf(string content, string format):
     *      Function: Returns the first position of the string "format" if it's contained in "content", otherwise -1.
     *      Usefulness: To use this function in List functions with two input arguments to fill.
     * */
    public static int IndexOf(string content, string format)
    {
        return content.IndexOf(format);
    }

    /*
     * static bool Length(string content):
     *      Function: Returns the length of the content. If it's null, returns -1.
     *      Usefulness: To use this function in List functions.
     * */
    public static int Length(string content)
    {
        return content != null ? content.Length : -1;
    }


    //      (Functions):

    /*
     * int [string content].CompareTo(string firstParam, string secondParam) / static int CompareTo(string content, string firstParam, string secondParam):
     *      Function: Returns -1 if firstParam is before secondParam inside the string. In the opposite case, it's 1. In any other case, 0.
     *      Usefulness: To quickly calculate if a string is before or after another inside one, and also check if there's an error.
     * */
    public static int CompareTo(this string content, string firstParam, string secondParam)
    {
        if (content == null || (content.Contains(firstParam) && content.Contains(secondParam)))
            return 0;
        if (content.IndexOf(firstParam) < content.IndexOf(secondParam, content.IndexEndOf(firstParam)))
            return -1;
        if (content.IndexOf(secondParam) < content.IndexOf(firstParam, content.IndexEndOf(secondParam)))
            return 1;
        return 0;
    }

    /*
     * bool [string content].Contains(char format) / static bool Contains(char format):
     *      Function: Returns whether the char "format" is included in the string.
     *      Usefulness: To not have to convert a "char" inmediately into string to use the "Contains" function.
     * */
    public static bool Contains(this string content, char format)
    {
        return content.Contains(format.ToString());
    }

    /*
     * bool [string content].Format(char separator, params string[] inside) / static bool Format(string content, char separator, params string[] inside):
     *      Function: Returns whether the content contains in each individual part (separated by the separator) the respective element of "inside".
     *      Usefulness: To quickly check if a string has the adequate format.
     * */
    public static bool Format(this string content, char separator, params string[] inside)
    {
        string[] separateContent = content.Split(separator);
        if (separateContent.Length != inside.Length)
            return false;
        
        for (int i = 0; i < separateContent.Length; i++)
            if (!separateContent[i].Contains(inside[i]))
                return false;

        return true;
    }

    /*
     * bool [string content].IsEmpty() / static bool IsEmpty(string content):
     *      Function: Returns whether the content is empty.
     *      Usefulness: Turn the empty size into a function easily checkable and usable in List functions.
     * */
    public static bool IsEmpty(this string content)
    {
        return content.Length == 0;
    }

    /*
     * bool [string content].IsFormat(string format) / static bool IsFormat(string content, string format):
     *      Function: Returns whether each character of "content" is inside "format".
     *      Usefulness: To check if a particular string has a limited and controlled amount of characters to be used.
     * */
    public static bool IsFormat(this string content, string format)
    {
        return content.IsAll(format.Contains);
    }

    /*
     * float [string content].ParseOperation() / static float ParseOperation(string content):
     *      Function: Returns a number which is the operation of the string parsed according to the normal format and characters { +-/*^() }.
     *      It allows for spaces and line jumps, but not any other character aside of the operators, numbers and '.' (',' isn't allowed).
     *      Usefulness: To turn text operations (for example, inside a file) into a number inmediately.
     * */
    public static float ParseOperation(this string content)
    {
        float current;
        string text = content.Remove(formatString);
        string[] set;
        if (!text.IsFormat(formatNumber + formatOperator + formatBrackets))
            return 0f;

        foreach (char c in formatOperator)
        {
            set = text.Split(c.ToString(), "(", ")");
            if (set.Length > 1)
                switch (c)
                {
                    case '+':
                        current = 0;
                        foreach (string st in set)
                            current += st.ParseOperation();
                        return current;
                    case '-':
                        current = set[0].ParseOperation() * 2;
                        foreach (string st in set)
                            current -= st.ParseOperation();
                        return current;
                    case '*':
                        current = 1;
                        foreach (string st in set)
                            current *= st.ParseOperation();
                        return current;
                    case '/':
                        current = set[0].ParseOperation() * set[0].ParseOperation();
                        foreach (string st in set)
                            current /= st.ParseOperation();
                        return current;
                }
        }
        return float.Parse(text);
    }

    /*
     * string [string content].TrimExtense() / static string TrimExtense(string content):
     *      Function: Returns a string without the "formatChar" characters at the beginning and end of the string (' ', '\n', '\r').
     *      Usefulness: To quickly trim all the essential characters aside of only the spaces..
     * */
    public static string TrimExtense(this string content)
    {
        return Cut(content, formatChar);
    }


    //      (Cut):

    /*
     * string [string content].Cut(int characterStart, int characterEnd) / static string Cut(string content, int characterStart, int characterEnd):
     *      Function: Returns a string with a specific number of characters removed from the beginning and end of the content.
     *      Usefulness: To quickly cut the desired elements of a string without making any more calculations.
    
     * string [string content].Cut(params char[] list) / static string Cut(string content, params char[] list):
     *      Function: Returns a string with the specific chars cut from the beginning and end of the content.
     *      Usefulness: To quickly cut the desired elements of a string without making any more calculations.
     *      The chars can be just put as params.
     *      
     * string [string content].Cut(IEnumerable<char> list) / static string Cut(string content, IEnumerable<char> list):
     *      Function: Returns a string with the specific chars cut from the beginning and end of the content.
     *      Usefulness: To quickly cut the desired elements of a string without making any more calculations.
     *      Any IEnumerable<char> (lists, strings) are valid.
     * */
    public static string Cut(this string content, int characterStart, int characterEnd)
    {
        if (content == null || characterStart < 0 || characterEnd < 0 || content.Length < characterStart + characterEnd)
            return null;

        string t = content;
        if (characterEnd > 0)
            t = t.Remove(t.Length - characterEnd);
        if (characterStart > 0)
            t = t.Remove(0, characterStart);
        return t;
    }
    public static string Cut(this string content, params char[] list)
    {
        return Cut(content, list as IEnumerable<char>);
    }
    public static string Cut(this string content, IEnumerable<char> list)
    {
        string t = content;
        List<char> u = new List<char>(list);
        if (t == null || t.Length == 0)
            return null;

        while (t.Length > 0 && u.Contains(t[0]))
            t = t.Substring(1);
        while (t.Length > 0 && u.Contains(t[t.Length - 1]))
            t = Cut(t, 0, 1);

        return t;
    }


    //      (EndNumber, EndNumberAdd, EndNumberReplace):

    /*
     * string [string content].EndNumber() / static string EndNumber(string content):
     *      Function: Returns the last part of the string that contains numbers (not including decimals {'.'} ).
     *      Usefulness: To quickly get the number at the end of a string.
     * */
    public static string EndNumber(this string content)
    {
        int i;

        for (i = content.Length - 1; i >= 0 && formatNumberNatural.Contains(content[i].ToString()); i--)
            ;
        if (i == content.Length - 1)
            return "";
        return content.Substring(i + 1);
    }

    /*
     * string [string content].EndNumberAdd(int offset) / static string EndNumberAdd(string content, int offset):
     *      Function: Returns a string whose last number is increased by one.
     *      Usefulness: To quickly add a number to a string while mantaining the format.
     * */
    public static string EndNumberAdd(this string content, int offset)
    {
        string en = EndNumber(content);
        return en.IsEmpty() ? content : content.Substring(0, content.Length - en.Length) + (int.Parse(en) + offset).ToString("D" + en.Length);
    }

    /*
     * string [string content].EndNumberReplace(int offset) / static string EndNumberAdd(string content, int offset):
     *      Function: Returns a string whose last number is replaced by other.
     *      Usefulness: To quickly replace a number of a string while mantaining the format.
     * */
    public static string EndNumberReplace(this string content, int number)
    {
        string en = EndNumber(content);
        return en.IsEmpty() ? content: content.Substring(0, content.Length - en.Length) + number.ToString("D" + en.Length);
    }


    //      (IndexOf, IndexEndOf):

    /*
     * int[] [string content].IndexOf(params string[] chars) / static int[] IndexOf(string content, params string[] chars):
     *      Function: Returns an array of int with each char's IndexOf value (in case of error, -1).
     *      Usefulness: To quickly calculate the index values in an array.
     * */
    public static int[] IndexOf(this string content, params string[] chars)
    {
        return chars.IsAll(content.Contains)? chars.Execute(content.IndexOf).ToArray() : null;
    }

    /*
     * int [string content].IndexEndOf(string chars) / static int IndexEndOf(string content, string chars):
     *      Function: Returns the index of a string right after "chars".
     *      Usefulness: To quickly know the position of a string right after an inside string that was searched.
     *      
     * int [string content].IndexEndOf(string chars, int startIndex) / static int IndexEndOf(string content, string chars, int startIndex):
     *      Function: Returns the index of a string right after "chars". It starts looking from one particular index.
     *      Usefulness: To quickly know the position of a string right after an inside string that was searched.
     * */
    public static int IndexEndOf(this string content, string chars)
    {
        return content.Contains(chars)? content.IndexOf(chars) + chars.Length : -1;
    }
    public static int IndexEndOf(this string content, string chars, int startIndex)
    {
        return content.Contains(chars) && content.Between(startIndex)? content.IndexOf(chars, startIndex) + chars.Length : -1;
    }

    /*
     * int[] [string content].IndexEndOf(params string[] chars) / static int[] IndexEndOf(string content, params string[] chars):
     *      Function: Returns an array of int with each char's IndexEndOf value (in case of error, -1).
     *      Usefulness: To quickly calculate the index values in an array.
     * */
    public static int[] IndexEndOf(this string content, params string[] chars)
    {
        return chars.IsAll(content.Contains) ? chars.Execute(content.IndexEndOf).ToArray() : null;
    }


    //      (Remove):

    /*
     * string [string content].Remove(params char[] chars) / static string Remove(string content, params char[] chars):
     *      Function: Returns a string with each char parameter removed from it.
     *      Usefulness: To quickly remove characters from a string. The chars can be just put as params.
     *      
     * string [string content].Remove(IEnumerable<char> chars) / static string Remove(string content,IEnumerable<char> chars):
     *      Function: Returns a string with each char parameter removed from it.
     *      Usefulness: To quickly remove characters from a string. Any IEnumerable<char> (lists, strings) are valid.
     *      
     * string [string content].Remove(params string[] chars) / static string Remove(string content, params string[] chars):
     *      Function: Returns a string with each string parameter removed from it.
     *      Usefulness: To quickly remove strings from the main string. The chars can be just put as params.
     *      
     * string [string content].Remove(IEnumerable<char> chars) / static string Remove(string content,IEnumerable<char> chars):
     *      Function: Returns a string with each string parameter removed from it.
     *      Usefulness: To quickly remove strings from the main string. Any IEnumerable<string> (lists) are valid.
     *      Usefulness: To quickly remove characters from a string. Any IEnumerable<char> (lists, strings) are valid.
     * */
    public static string Remove(this string content, params char[] chars)
    {
        return Remove(content, chars as IEnumerable<char>);
    }
    public static string Remove(this string content, IEnumerable<char> chars)
    {
        return Remove(content, chars.ToIEnumerableString());
    }
    public static string Remove(this string content, params string[] strings)
    {
        return Remove(content, strings as IEnumerable<string>);
    }
    public static string Remove(this string content, IEnumerable<string> strings)
    {
        string t = content;
        foreach (string s in strings)
            t = t.Replace(s, "");
        return t;
    }


    //      (Split):

    /*
     * string[] [string content].Split(string openKey, string closeKey) / static string[] Split(string content, string openKey, string closeKey):
     *      Function: Returns a list of strings with the content inside each openKey and closeKey, ignoring the rest.
     *      Usefulness: To quickly get the content inside these parameters.
     *      
     * string[] [string content].Split(string separator, string openIgnore, string closeIgnore)
     * / static string[] Split(string content, string separator, string openIgnore, string closeIgnore):
     *      Function: Returns a list of strings separated by the string "separator", ignoring the separators inside openIgnore and closeIgnore.
     *      Usefulness: To split without consider characters inside some specific parameters where it shouldn't be taken in account.
     * */
    public static string[] Split(this string content, string openKey, string closeKey)
    {
        List<string> list = new List<string>();
        string t;
        int counter = 0;

        while (true)
        {
            t = content.Substring(counter).Substring(openKey, closeKey);
            if (t == null)
            {
                if (content.Substring(counter).Length > 0)
                    list.Add(content.Substring(counter));
                return list.ToArray();
            }
            list.Add(content.Substring(counter, openKey).Cut(0, openKey.Length));
            list.Add(t.Cut(openKey.Length, closeKey.Length));
            counter = content.IndexEndOf(t);
        }
    }
    public static string[] Split(this string content, string separator, string openIgnore, string closeIgnore)
    {
        List<string> list = new List<string>();

        bool loop = true;
        int counter = 0, startElement = 0, indexSep = 0, openCharIgnore = 0;
        while (true)
        {
            while (loop)
            {
                indexSep = content.IndexOf(separator, counter);
                openCharIgnore = content.IndexOf(openIgnore, counter);
                if (indexSep == -1)
                {
                    list.Add(content.Substring(startElement));
                    return list.ToArray();
                }
                else if (openCharIgnore == -1 || indexSep < openCharIgnore)
                {
                    list.Add(content.SubstringIndex(startElement, indexSep - 1));
                    loop = false;
                }
                else
                    counter = content.IndexOf(closeIgnore, openCharIgnore + openIgnore.Length) + closeIgnore.Length;
                if (counter == -1)
                    return null;
            }
            startElement = indexSep + separator.Length;
            counter = startElement;
            loop = true;
        }
    }


    //      (Substring, SubstringChar, SubstringIndex)

    /*
     * string [string content].Substring(string openKey) / static string Substring(string content, string openKey):
     *      Function: Returns a substring of the content starting from the first string subpart found.
     *      Returns null if it's not possible.
     *      Usefulness: To quickly get a substring without converting to a number position with IndexOf and using string.
     *      
     * string [string content].Substring(int startIndex, string closeKey) / static string Substring(string content, int startIndex, string closeKey):
     *      Function: Returns a substring of the content starting from a number position and ending with the upcoming string found.
     *      Returns null if a closed substring can't be found.
     *      Usefulness: To quickly get a substring with mixed parameters and an end of the substring.
     *      
     * string [string content].Substring(string openKey, string closeKey) / static string Substring(string content, string openKey, string closeKey):
     *      Function: Returns a substring of the content starting from the first string subpart found and ending with the upcoming string found.
     *      Returns null if a closed substring can't be found.
     *      Usefulness: To quickly get a closed substring from beginning and end with only the string, without doing complicated IndexOf conversions.
     *      
     * string [string content].Substring(string openKey, string closeKey, string openIgnore, string closeIgnore)
     * / static string Substring(string content, string openKey, string closeKey, string openIgnore, string closeIgnore):
     *      Function: Returns a substring of the content starting from the first string subpart found and ending with the upcoming string found.
     *      It ignores the keys inside "openIgnore" and "closeIgnore".
     *      Returns null if a closed substring can't be found.
     *      Usefulness: To quickly get a closed substring from beginning and end with only the string, without doing complicated IndexOf conversions.
     *      It also allows to get a complete substring that has key characters in parts where it should be ignored.
     * */
    public static string Substring(this string content, string openKey)
    {
        return content.Contains(openKey)? content.Substring(content.IndexOf(openKey)) : null;
    }
    public static string Substring(this string content, int startIndex, string closeKey)
    {
        if (!content.Between(startIndex) || !content.Contains(closeKey) || startIndex > closeKey.IndexOf(closeKey, startIndex))
            return null;
        return content.SubstringIndex(startIndex, content.IndexOf(closeKey));
    }
    public static string Substring(this string content, string openKey, string closeKey)
    {
        if (content.CompareTo(openKey, closeKey) >= 0)
            return null;
        return content.SubstringIndex(content.IndexOf(openKey), content.IndexEndOf(closeKey, content.IndexEndOf(openKey)) - 1);
    }
    public static string Substring(this string content, string openKey, string closeKey, string openIgnore, string closeIgnore)
    {
        bool loop = true;
        int counter = 0, openCharKey = 0, closeCharKey = 0, openCharIgnore = 0;
        while (loop)
        {
            openCharKey = content.IndexOf(openKey, counter);
            openCharIgnore = content.IndexOf(openIgnore, counter);
            if (openCharKey == -1)
                return null;
            else if (openCharIgnore == -1 || openCharKey < openCharIgnore)
                loop = false;
            else
                counter = content.IndexOf(closeIgnore, openCharIgnore + openIgnore.Length);
            if (counter == -1)
                return null;
        }
        counter = openCharKey + openKey.Length;
        loop = true;
        while (loop)
        {
            closeCharKey = content.IndexOf(closeKey, counter);
            openCharIgnore = content.IndexOf(openIgnore, counter);
            if (closeCharKey == -1)
                return null;
            else if (openCharIgnore == -1 || closeCharKey < openCharIgnore)
                loop = false;
            else
                counter = content.IndexOf(closeIgnore, openCharIgnore + openIgnore.Length) + closeIgnore.Length;
        }

        return content.SubstringIndex(openCharKey, closeCharKey + closeKey.Length - 1);
    }

    /*
     * string [string content].SubstringChar(char openKey) / static string SubstringChar(char openKey, char closeKey):
     *      Function: Returns a substring of the content starting from the first char found and ending with the upcoming char found.
     *      Returns null if a closed substring can't be found.
     *      Usefulness: To quickly get a closed substring with chars. Needs the "Char" in the name to not be confused by SubstringIndex.
     * */
    public static string SubstringChar(this string content, char openKey, char closeKey)
    {
        return Substring(content, openKey.ToString(), closeKey.ToString());
    }

    /*
     * string [string content].SubstringIndex(int startIndex, int endIndex) / static string SubstringIndex(int startIndex, int endIndex):
     *      Function: Returns a substring of the content starting from the first and last index position (including that last index).
     *      Returns null if a closed substring can't be found.
     *      Usefulness: To quickly get a closed substring with index instead of using the length.
     *      Needs the "Index" in the name to not be confused by Substring normal (where last index is "length") and SubstringChar.
     * */
    public static string SubstringIndex(this string content, int startIndex, int endIndex)
    {
        if (content == null || (content.Between(startIndex) && content.Between(endIndex)) || startIndex > endIndex)
            return null;
        return content.Substring(startIndex, endIndex - startIndex + 1);
    }


    /////////////////// IENUMERABLE<CHAR> EXTENSIONS /////////////////////

    /*
     * IEnumerable<string> [IEnumerable<char> array].ToIEnumerableString() / static IEnumerable<string> ToIEnumerableString(IEnumerable<char> array):
     *      Function: Returns an IEnumerable where each "char" has been turned into "string".
     *      Usefulness: To quickly get a conversion to be used in diverse operations.
     * */
    public static IEnumerable<string> ToIEnumerableString(this IEnumerable<char> array)
    {
        return array.Execute(char.ToString);
    }


    /////////////////// IENUMERABLE<STRING> EXTENSIONS /////////////////////

    /*
     * string [IEnumerable<string> array].Concatenate() / static string Concatenate(IEnumerable<string> array):
     *      Function: Returns a string that is composed of all the string of the IEnumerable concatenated one after the other.
     *      Usefulness: To quickly get a message from its different parts.
     *      
     * string [IEnumerable<string> array].Concatenate(string separator) / static string Concatenate(IEnumerable<string> array, string separator):
     *      Function: Returns a string that is composed of all the string of the IEnumerable concatenated one after the other, separated by the separator.
     *      Usefulness: To quickly get a message from its different parts, with a concrete separator included.
     * */
    public static string Concatenate(this IEnumerable<string> array)
    {
        string result = "";
        foreach (string str in array)
            result += str;
        return result;
    }
    public static string Concatenate(this IEnumerable<string> array, string separator)
    {
        string result = "";
        foreach (string str in array)
            result += separator + str;
        return result.Substring(separator.Length);
    }


    /////////////////// IENUMERABLE<INT> EXTENSIONS /////////////////////

    /*
     * int [IEnumerable<int> array].Min() / static int Min(IEnumerable<int> array):
     *      Function: Returns the minimum value of the elements of the array.
     *      Usefulness: To quickly get the minimum value.
     * */
    public static int Min(this IEnumerable<int> array)
    {
        int value = int.MaxValue;
        foreach (int fl in array)
            value = Math.Min(value, fl);

        return value;
    }

    /*
     * int [IEnumerable<int> array].Min() / static int Min(IEnumerable<int> array):
     *      Function: Returns the earliest index of the minimum value of the elements of the array.
     *      Usefulness: To quickly get the earliest index of the minimum value.
     * */
    public static int MinIndex(this IEnumerable<int> array)
    {
        int value = int.MaxValue;
        int val = -1, i = 0;
        foreach (int fl in array)
        {
            val = value != (value = Math.Min(value, fl)) ? i : val;
            i++;
        }

        return val;
    }

    /*
     * int [IEnumerable<int> array].Max() / static int Max(IEnumerable<int> array):
     *      Function: Returns the maximum value of the elements of the array.
     *      Usefulness: To quickly get the maximum value.
     * */
    public static int Max(this IEnumerable<int> array)
    {
        int value = int.MinValue;
        foreach (int fl in array)
            value = Math.Max(value, fl);

        return value;
    }

    /*
     * int [IEnumerable<int> array].Max() / static int Max(IEnumerable<int> array):
     *      Function: Returns the earliest index of the maximum value of the elements of the array.
     *      Usefulness: To quickly get the earliest index of the maximum value.
     * */
    public static int MaxIndex(this IEnumerable<int> array)
    {
        int value = int.MinValue;
        int val = -1, i = 0;
        foreach (int fl in array)
        {
            val = value != (value = Math.Max(value, fl)) ? i : val;
            i++;
        }

        return val;
    }


    /////////////////// IENUMERABLE<FLOAT> EXTENSIONS /////////////////////

    /*
     * float [IEnumerable<float> array].Min() / static float Min(IEnumerable<float> array):
     *      Function: Returns the minimum value of the elements of the array.
     *      Usefulness: To quickly get the minimum value.
     * */
    public static float Min(this IEnumerable<float> array)
    {
        float value = float.PositiveInfinity;
        foreach (float fl in array)
            value = Math.Min(value, fl);

        return value;
    }

    /*
     * float [IEnumerable<float> array].Min() / static float Min(IEnumerable<float> array):
     *      Function: Returns the earliest index of the minimum value of the elements of the array.
     *      Usefulness: To quickly get the earliest index of the minimum value.
     * */
    public static int MinIndex(this IEnumerable<float> array)
    {
        float value = float.PositiveInfinity;
        int val = -1, i = 0;
        foreach (float fl in array)
        {
            val = value != (value = Math.Min(value, fl)) ? i : val;
            i++;
        }

        return val;
    }

    /*
     * float [IEnumerable<float> array].Max() / static float Max(IEnumerable<float> array):
     *      Function: Returns the maximum value of the elements of the array.
     *      Usefulness: To quickly get the maximum value.
     * */
    public static float Max(this IEnumerable<float> array)
    {
        float value = float.NegativeInfinity;
        foreach (float fl in array)
            value = Math.Max(value, fl);

        return value;
    }

    /*
     * float [IEnumerable<float> array].Max() / static float Max(IEnumerable<float> array):
     *      Function: Returns the earliest index of the maximum value of the elements of the array.
     *      Usefulness: To quickly get the earliest index of the maximum value.
     * */
    public static int MaxIndex(this IEnumerable<float> array)
    {
        float value = float.NegativeInfinity;
        int val = -1, i = 0;
        foreach (float fl in array)
        {
            val = value != (value = Math.Max(value, fl)) ? i : val;
            i++;
        }

        return val;
    }


    /////////////////// IENUMERABLE<T> EXTENSIONS /////////////////////

    //      (Functions):

    /*
     * bool [IEnumerable<T> content].Between<T>(int counter) / static bool Between<T>(IEnumerable<T> content, int counter):
     *      Function: Returns whether the "counter" value reflects a valid position inside the IEnumerable.
     *      Usefulness: To quickly get the earliest index of the maximum value.
     * */
    public static bool Between<T>(this IEnumerable<T> content, int counter)
    {
        return counter.Between(0, new List<T>(content).Count - 1);
    }

    /*
     * List<T1> [IEnumerable<T2> array].ConstantClone<T1, T2>(T1 constantValue)
     * / static List<T1> ConstantClone<T1, T2>(IEnumerable<T2> array, T1 constantValue):
     *      Function: Returns a list of the same size as the IEnumerable but with possible different type, that has one constant value.
     *      Usefulness: To quickly get a clone with the same size and a particular value.
     * */
    public static List<T1> ConstantClone<T1, T2>(this IEnumerable<T2> array, T1 constantValue)
    {
        List<T1> list = new List<T1>();
        foreach (T2 el in array)
            list.Add(constantValue);
        return list;
    }

    /*
     * bool [IEnumerable<T> content].IsEmpty() / static bool IsEmpty(IEnumerable<T> content):
     *      Function: Returns whether the content is empty.
     *      Usefulness: Turn the empty size into a function easily checkable and usable in List functions.
     * */
    public static bool IsEmpty<T>(this IEnumerable<T> content)
    {
        if (content != null)
            foreach (T el in content)
                return false;
        return true;
    }


    //      (First, Last):

    /*
     * T [IEnumerable<T> array].First<T>() / static T First<T>(IEnumerable<T> array) { where T : class }:
     *      Function: Returns the first element of the IEnumerable. If it's empty, returns "null".
     *      Usefulness: Quickly gets for all types of IEnumerables the first element.
     *      
     * T [IEnumerable<T> array].First<T>(T defValue) / static T First<T>(IEnumerable<T> array, T defValue):
     *      Function: Returns the first element of the IEnumerable. If it's empty, returns the default value.
     *      Usefulness: Quickly gets for all types of IEnumerables the first element. This includes also when T isn't a class.
     * */
    public static T First<T>(this IEnumerable<T> array) where T : class
    {
        return array.First(null);
    }
    public static T First<T>(this IEnumerable<T> array, T defValue)
    {
        foreach (T el in array)
            return el;
        return defValue;
    }

    /*
     * T [IEnumerable<T> array].Last<T>() / static T Last<T>(IEnumerable<T> array) { where T : class }:
     *      Function: Returns the last element of the IEnumerable. If it's empty, returns "null".
     *      Usefulness: Quickly gets for all types of IEnumerables the last element.
     *      
     * T [IEnumerable<T> array].Last<T>(T defValue) / static T Last<T>(IEnumerable<T> array, T defValue):
     *      Function: Returns the last element of the IEnumerable. If it's empty, returns the default value.
     *      Usefulness: Quickly gets for all types of IEnumerables the last element. This includes also when T isn't a class.
     * */
    public static T Last<T>(this IEnumerable<T> array) where T : class
    {
        return array.Last(null);
    }
    public static T Last<T>(this IEnumerable<T> array, T defValue)
    {
        T last = defValue;
        foreach (T el in array)
            last = el;
        return last;
    }


    //      (IsAll, IsAny):

    /*
     * bool [IEnumerable<T1> array].IsAll<T1, T {...}>(T{A} arg{A} , TDelegate<bool, T{A}, T1, T{B}> action, T{B} arg{B})
     * / static bool IsAll<T1, T{...}>(IEnumerable<T1> array, T{A} arg{A} , TDelegate<bool, T{A}, T1, T{B}> action, T{B} arg{B}):
     *      Terms: {A} and {B} is a set of attributes in a particular order. {A} and {B} are both included in {...} not mattering the order.
     *      Function: For a list, checks if a function that returns "bool" is true for all the values inside. Otherwise, it's false.
     *      For functions up to 4 input arguments, the other values can be put (must be constants), but they require to be put in the right order,
     *      with the position where the variable argument would be, it's where the Delegate is.
     *      (i.e. "[List<string>].IsAll(largeString.Contains)" checks if all the strings are contained in "largeString")
     *      (i.e. "[List<int>].IsAll(Auxe.Between, min, max);" checks if all the numbers in the list are between "min" and "max")
     *      (i.e. "[List<int>].IsAll(value, min, Auxe.Between);" checks if the value number is always between "min" and each number in the list)
     *      Usefulness: Quickly gets this calculation in one function in a very versatile and quick way.
     * */
    public static bool IsAll<T1>(this IEnumerable<T1> array, TDelegate<bool, T1> action)
    {
        foreach (T1 el in array) if (!action(el)) return false; return true;
    }
    public static bool IsAll<T1, T2>(this IEnumerable<T1> array, T2 arg2, TDelegate<bool, T2, T1> action)
    {
        foreach (T1 el in array) if (!action(arg2, el)) return false; return true;
    }
    public static bool IsAll<T1, T2>(this IEnumerable<T1> array, TDelegate<bool, T1, T2> action, T2 arg2)
    {
        foreach (T1 el in array) if (!action(el, arg2)) return false; return true;
    }
    public static bool IsAll<T1, T2, T3>(this IEnumerable<T1> array, T2 arg2, T3 arg3, TDelegate<bool, T2, T3, T1> action)
    {
        foreach (T1 el in array) if (!action(arg2, arg3, el)) return false; return true;
    }
    public static bool IsAll<T1, T2, T3>(this IEnumerable<T1> array, T2 arg2, TDelegate<bool, T2, T1, T3> action, T3 arg3)
    {
        foreach (T1 el in array) if (!action(arg2, el, arg3)) return false; return true;
    }
    public static bool IsAll<T1, T2, T3>(this IEnumerable<T1> array, TDelegate<bool, T1, T2, T3> action, T2 arg2, T3 arg3)
    {
        foreach (T1 el in array) if (!action(el, arg2, arg3)) return false; return true;
    }
    public static bool IsAll<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, T3 arg3, T4 arg4, TDelegate<bool, T2, T3, T4, T1> action)
    {
        foreach (T1 el in array) if (!action(arg2, arg3, arg4, el)) return false; return true;
    }
    public static bool IsAll<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, T3 arg3, TDelegate<bool, T2, T3, T1, T4> action, T4 arg4)
    {
        foreach (T1 el in array) if (!action(arg2, arg3, el, arg4)) return false; return true;
    }
    public static bool IsAll<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, TDelegate<bool, T2, T1, T3, T4> action, T3 arg3, T4 arg4)
    {
        foreach (T1 el in array) if (!action(arg2, el, arg3, arg4)) return false; return true;
    }
    public static bool IsAll<T1, T2, T3, T4>(this IEnumerable<T1> array, TDelegate<bool, T1, T2, T3, T4> action, T2 arg2, T3 arg3, T4 arg4)
    {
        foreach (T1 el in array) if (!action(el, arg2, arg3, arg4)) return false; return true;
    }

    /*
     * bool [IEnumerable<T1> array].IsAll<T1, T2, T...>(T{A} arg{A} , TDelegate<bool, T{A}, T1, T{B}, T2, T{C}> func, T{B} arg{B},
     *      TDelegate<bool, T1, TDelegate<bool, T{A}, T1, T{B}, T2, T{C}>> c2)
     * / static bool IsAll<T1, T2, T...>(IEnumerable<T1> array, T{A} arg{A} , TDelegate<bool, T{A}, T1, T{B}, T2, T{C}> func, T{B} arg{B},
     *      TDelegate<bool, T1, TDelegate<bool, T{A}, T1, T{B}, T2, T{C}>> c2):
     *      Terms: {A}, {B} and {C} is a set of attributes in a particular order. {A}, {B} and {C} are all included in {...} not mattering the order.
     *      Function: Upgrade of the normal IsAll function. For each element of the function, it summons another IsAll/IsAny for a second list of parameters.
     *      This means that, at least, we need a function with 2 input arguments where two will be variable,
     *      and each 1st parameter will have its bool value decided after checking with each 2nd parameter. IsAll and IsAny can be combined however they want.
     *      For functions up to 3 input arguments, the other values can be put (must be constants), but they require to be put in the right order,
     *      with the position where the variable argument would be, it's where the Delegate is, and the position of the 2nd variable argument the IsAny/IsAll.
     *      (i.e. "[List<string>].IsAll(Auxe.Contains, [List<string>].IsAny)" checks if all the parameters of the first list have, at least,
     *      one of the parameters of the 2nd list inside. Each 1st parameter will return true if at least one. If one 1st parameter fails, returns "false")
     *      Usefulness: Allows to stack the IsAll and IsAny functions in more useful ways depending of the situation, again, saving a lot of code sometimes.
     * */
    public static bool IsAll<T1, T2>(this IEnumerable<T1> array, TDelegate<bool, T1, T2> func, TDelegate<bool, T1, TDelegate<bool, T1, T2>> c2)
    {
        foreach (T1 el in array) if (!c2(el, func)) return false; return true;
    }
    public static bool IsAll<T1, T2>(this IEnumerable<T1> array, TDelegate<bool, TDelegate<bool, T2, T1>, T1> c2, TDelegate<bool, T2, T1> func)
    {
        foreach (T1 el in array) if (!c2(func, el)) return false; return true;
    }
    public static bool IsAll<T1, T2, T3>(this IEnumerable<T1> array, T3 arg3, TDelegate<bool, T3, T1, T2> func, TDelegate<bool, T3, T1, TDelegate<bool, T3, T1, T2>> c2)
    {
        foreach (T1 el in array) if (!c2(arg3, el, func)) return false; return true;
    }
    public static bool IsAll<T1, T2, T3>(this IEnumerable<T1> array, T3 arg3, TDelegate<bool, T3, TDelegate<bool, T3, T2, T1>, T1> c2, TDelegate<bool, T3, T2, T1> func)
    {
        foreach (T1 el in array) if (!c2(arg3, func, el)) return false; return true;
    }
    public static bool IsAll<T1, T2, T3>(this IEnumerable<T1> array, TDelegate<bool, T1, T2, T3> func, TDelegate<bool, T1, TDelegate<bool, T1, T2, T3>, T3> c2, T3 arg3)
    {
        foreach (T1 el in array) if (!c2(el, func, arg3)) return false; return true;
    }
    public static bool IsAll<T1, T2, T3>(this IEnumerable<T1> array, TDelegate<bool, TDelegate<bool, T2, T1, T3>, T1, T3> c2, TDelegate<bool, T2, T1, T3> func, T3 arg3)
    {
        foreach (T1 el in array) if (!c2(func, el, arg3)) return false; return true;
    }
    public static bool IsAll<T1, T2, T3>(this IEnumerable<T1> array, TDelegate<bool, T1, T3, T2> func, T3 arg3, TDelegate<bool, T1, T3, TDelegate<bool, T1, T3, T2>> c2)
    {
        foreach (T1 el in array) if (!c2(el, arg3, func)) return false; return true;
    }
    public static bool IsAll<T1, T2, T3>(this IEnumerable<T1> array, TDelegate<bool, TDelegate<bool, T2, T3, T1>, T3, T1> c2, T3 arg3, TDelegate<bool, T2, T3, T1> func)
    {
        foreach (T1 el in array) if (!c2(func, arg3, el)) return false; return true;
    }

    /*
     * bool [IEnumerable<T1> array].IsAny<T1, T {...}>(T{A} arg{A} , TDelegate<bool, T{A}, T1, T{B}> action, T{B} arg{B})
     * / static bool IsAny<T1, T{...}>(IEnumerable<T1> array, T{A} arg{A} , TDelegate<bool, T{A}, T1, T{B}> action, T{B} arg{B}):
     *      Terms: {A} and {B} is a set of attributes in a particular order. {A} and {B} are both included in {...} not mattering the order.
     *      Function: For a list, checks if a function that returns "bool" is true for any the values inside. Otherwise, it's false.
     *      For functions up to 4 input arguments, the other values can be put (must be constants), but they require to be put in the right order,
     *      with the position where the variable argument would be, it's where the Delegate is.
     *      (i.e. "[List<string>].IsAny(largeString.Contains)" checks if any the strings are contained in "largeString")
     *      (i.e. "[List<int>].IsAny(Auxe.Between, min, max);" checks if at least one of the numbers in the list are between "min" and "max")
     *      (i.e. "[List<int>].IsAny(value, min, Auxe.Between);" checks if value number is at least once between "min" and each number in the list)
     *      Usefulness: Quickly gets this calculation in one function in a very versatile and quick way.
     * */
    public static bool IsAny<T1>(this IEnumerable<T1> array, TDelegate<bool, T1> action)
    {
        foreach (T1 el in array) if (action(el)) return true; return false;
    }
    public static bool IsAny<T1, T2>(this IEnumerable<T1> array, T2 arg2, TDelegate<bool, T2, T1> action)
    {
        foreach (T1 el in array) if (action(arg2, el)) return true; return false;
    }
    public static bool IsAny<T1, T2>(this IEnumerable<T1> array, TDelegate<bool, T1, T2> action, T2 arg2)
    {
        foreach (T1 el in array) if (action(el, arg2)) return true; return false;
    }
    public static bool IsAny<T1, T2, T3>(this IEnumerable<T1> array, T2 arg2, T3 arg3, TDelegate<bool, T2, T3, T1> action)
    {
        foreach (T1 el in array) if (action(arg2, arg3, el)) return true; return false;
    }
    public static bool IsAny<T1, T2, T3>(this IEnumerable<T1> array, T2 arg2, TDelegate<bool, T2, T1, T3> action, T3 arg3)
    {
        foreach (T1 el in array) if (action(arg2, el, arg3)) return true; return false;
    }
    public static bool IsAny<T1, T2, T3>(this IEnumerable<T1> array, TDelegate<bool, T1, T2, T3> action, T2 arg2, T3 arg3)
    {
        foreach (T1 el in array) if (action(el, arg2, arg3)) return true; return false;
    }
    public static bool IsAny<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, T3 arg3, T4 arg4, TDelegate<bool, T2, T3, T4, T1> action)
    {
        foreach (T1 el in array) if (action(arg2, arg3, arg4, el)) return true; return false;
    }
    public static bool IsAny<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, T3 arg3, TDelegate<bool, T2, T3, T1, T4> action, T4 arg4)
    {
        foreach (T1 el in array) if (action(arg2, arg3, el, arg4)) return true; return false;
    }
    public static bool IsAny<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, TDelegate<bool, T2, T1, T3, T4> action, T3 arg3, T4 arg4)
    {
        foreach (T1 el in array) if (action(arg2, el, arg3, arg4)) return true; return false;
    }
    public static bool IsAny<T1, T2, T3, T4>(this IEnumerable<T1> array, TDelegate<bool, T1, T2, T3, T4> action, T2 arg2, T3 arg3, T4 arg4)
    {
        foreach (T1 el in array) if (action(el, arg2, arg3, arg4)) return true; return false;
    }

    /*
     * bool [IEnumerable<T1> array].IsAny<T1, T2, T...>(T{A} arg{A} , TDelegate<bool, T{A}, T1, T{B}, T2, T{C}> func, T{B} arg{B},
     *      TDelegate<bool, T1, TDelegate<bool, T{A}, T1, T{B}, T2, T{C}>> c2)
     * / static bool IsAny<T1, T2, T...>(IEnumerable<T1> array, T{A} arg{A} , TDelegate<bool, T{A}, T1, T{B}, T2, T{C}> func, T{B} arg{B},
     *      TDelegate<bool, T1, TDelegate<bool, T{A}, T1, T{B}, T2, T{C}>> c2):
     *      Terms: {A}, {B} and {C} is a set of attributes in a particular order. {A}, {B} and {C} are all included in {...} not mattering the order.
     *      Function: Upgrade of the normal IsAny function. For each element of the function, it summons another IsAll/IsAny for a second list of parameters.
     *      This means that, at least, we need a function with 2 input arguments where two will be variable,
     *      and each 1st parameter will have its bool value decided after checking with each 2nd parameter. IsAll and IsAny can be combined however they want.
     *      For functions up to 3 input arguments, the other values can be put (must be constants), but they require to be put in the right order,
     *      with the position where the variable argument would be, it's where the Delegate is, and the position of the 2nd variable argument the IsAny/IsAll.
     *      (i.e. "[List<string>].IsAny(Auxe.Contains, [List<string>].IsAll)" checks if at least one parameter of the first list has all the parameters
     *      of the 2nd list inside. Each 1st parameter will return true if all the 2nd parameters are inside. If one 1st parameter succeeds, returns "true")
     *      Usefulness: Allows to stack the IsAll and IsAny functions in more useful ways depending of the situation, again, saving a lot of code sometimes.
     * */
    public static bool IsAny<T1, T2>(this IEnumerable<T1> array, TDelegate<bool, T1, T2> func, TDelegate<bool, T1, TDelegate<bool, T1, T2>> c2)
    {
        foreach (T1 el in array) if (c2(el, func)) return true; return false;
    }
    public static bool IsAny<T1, T2>(this IEnumerable<T1> array, TDelegate<bool, TDelegate<bool, T2, T1>, T1> c2, TDelegate<bool, T2, T1> func)
    {
        foreach (T1 el in array) if (c2(func, el)) return true; return false;
    }
    public static bool IsAny<T1, T2, T3>(this IEnumerable<T1> array, T3 arg3, TDelegate<bool, T3, T1, T2> func, TDelegate<bool, T3, T1, TDelegate<bool, T3, T1, T2>> c2)
    {
        foreach (T1 el in array) if (c2(arg3, el, func)) return true; return false;
    }
    public static bool IsAny<T1, T2, T3>(this IEnumerable<T1> array, T3 arg3, TDelegate<bool, T3, TDelegate<bool, T3, T2, T1>, T1> c2, TDelegate<bool, T3, T2, T1> func)
    {
        foreach (T1 el in array) if (c2(arg3, func, el)) return true; return false;
    }
    public static bool IsAny<T1, T2, T3>(this IEnumerable<T1> array, TDelegate<bool, T1, T2, T3> func, TDelegate<bool, T1, TDelegate<bool, T1, T2, T3>, T3> c2, T3 arg3)
    {
        foreach (T1 el in array) if (c2(el, func, arg3)) return true; return false;
    }
    public static bool IsAny<T1, T2, T3>(this IEnumerable<T1> array, TDelegate<bool, TDelegate<bool, T2, T1, T3>, T1, T3> c2, TDelegate<bool, T2, T1, T3> func, T3 arg3)
    {
        foreach (T1 el in array) if (c2(func, el, arg3)) return true; return false;
    }
    public static bool IsAny<T1, T2, T3>(this IEnumerable<T1> array, TDelegate<bool, T1, T3, T2> func, T3 arg3, TDelegate<bool, T1, T3, TDelegate<bool, T1, T3, T2>> c2)
    {
        foreach (T1 el in array) if (c2(el, arg3, func)) return true; return false;
    }
    public static bool IsAny<T1, T2, T3>(this IEnumerable<T1> array, TDelegate<bool, TDelegate<bool, T2, T3, T1>, T3, T1> c2, T3 arg3, TDelegate<bool, T2, T3, T1> func)
    {
        foreach (T1 el in array) if (c2(func, arg3, el)) return true; return false;
    }


    //      (Filter):

    /*
     * List<T1> [IEnumerable<T1> array].Filter<T1, T {...}>(T{A} arg{A} , TDelegate<bool, T{A}, T1, T{B}> action, T{B} arg{B})
     * / static List<T1> Filter<T1, T{...}>(IEnumerable<T1> array, T{A} arg{A} , TDelegate<bool, T{A}, T1, T{B}> action, T{B} arg{B}):
     *      Terms: {A} and {B} is a set of attributes in a particular order. {A} and {B} are both included in {...} not mattering the order.
     *      Function: For a list, returns a list with all the elemnts that in the bool function returned "false" removed.
     *      For functions up to 4 input arguments, the other values can be put (must be constants), but they require to be put in the right order,
     *      with the position where the variable argument would be, it's where the Delegate is.
     *      (i.e. "[List<string>].Filter(largeString.Contains)" returns a list with only the strings contained in "largeString")
     *      (i.e. "[List<int>].Filter(Auxe.Between, min, max);" returns a list with only the numbers between "min" and "max")
     *      Usefulness: Quickly get a list filtered by a particular function condition.
     * */
    public static List<T1> Filter<T1> (this IEnumerable<T1> array, TDelegate<bool, T1> action)
    {
        var list = new List<T1>(); foreach (T1 el in array) if (action(el)) list.Add(el); return list;
    }
    public static List<T1> Filter<T1, T2>(this IEnumerable<T1> array, T2 arg2, TDelegate<bool, T2, T1> action)
    {
        var list = new List<T1>(); foreach (T1 el in array) if (action(arg2, el)) list.Add(el); return list;
    }
    public static List<T1> Filter<T1, T2>(this IEnumerable<T1> array, TDelegate<bool, T1, T2> action, T2 arg2)
    {
        var list = new List<T1>(); foreach (T1 el in array) if (action(el, arg2)) list.Add(el); return list;
    }
    public static List<T1> Filter<T1, T2, T3>(this IEnumerable<T1> array, T2 arg2, T3 arg3, TDelegate<bool, T2, T3, T1> action)
    {
        var list = new List<T1>(); foreach (T1 el in array) if (action(arg2, arg3, el)) list.Add(el); return list;
    }
    public static List<T1> Filter<T1, T2, T3>(this IEnumerable<T1> array, T2 arg2, TDelegate<bool, T2, T1, T3> action, T3 arg3)
    {
        var list = new List<T1>(); foreach (T1 el in array) if (action(arg2, el, arg3)) list.Add(el); return list;
    }
    public static List<T1> Filter<T1, T2, T3>(this IEnumerable<T1> array, TDelegate<bool, T1, T2, T3> action, T2 arg2, T3 arg3)
    {
        var list = new List<T1>(); foreach (T1 el in array) if (action(el, arg2, arg3)) list.Add(el); return list;
    }
    public static List<T1> Filter<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, T3 arg3, T4 arg4, TDelegate<bool, T2, T3, T4, T1> action)
    {
        var list = new List<T1>(); foreach (T1 el in array) if (action(arg2, arg3, arg4, el)) list.Add(el); return list;
    }
    public static List<T1> Filter<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, T3 arg3, TDelegate<bool, T2, T3, T1, T4> action, T4 arg4)
    {
        var list = new List<T1>(); foreach (T1 el in array) if (action(arg2, arg3, el, arg4)) list.Add(el); return list;
    }
    public static List<T1> Filter<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, TDelegate<bool, T2, T1, T3, T4> action, T3 arg3, T4 arg4)
    {
        var list = new List<T1>(); foreach (T1 el in array) if (action(arg2, el, arg3, arg4)) list.Add(el); return list;
    }
    public static List<T1> Filter<T1, T2, T3, T4>(this IEnumerable<T1> array, TDelegate<bool, T1, T2, T3, T4> action, T2 arg2, T3 arg3, T4 arg4)
    {
        var list = new List<T1>(); foreach (T1 el in array) if (action(el, arg2, arg3, arg4)) list.Add(el); return list;
    }


    //      (Get):

    /*
     * T1 [IEnumerable<T1> array].Get<T1, T {...}>(T{A} arg{A} , TDelegate<bool, T{A}, T1, T{B}> action, T{B} arg{B}, T1 defValue)
     * / static T1 Get<T1, T{...}>(IEnumerable<T1> array, T{A} arg{A} , TDelegate<bool, T{A}, T1, T{B}> action, T{B} arg{B}, T1 defValue):
     *      Terms: {A} and {B} is a set of attributes in a particular order. {A} and {B} are both included in {...} not mattering the order.
     *      Function: For a list, returns the first element that returned "true" with the bool function. If there's none, returns defValue.
     *      For functions up to 4 input arguments, the other values can be put (must be constants), but they require to be put in the right order,
     *      with the position where the variable argument would be, it's where the Delegate is.
     *      (i.e. "[List<string>].Get(largeString.Contains, null)" returns the first string contained in "largeString". If there's none, returns "null")
     *      (i.e. "[List<int>].Get(Auxe.Between, min, max, -24);" returns the first number between "min" and "max". If there's none, returns "-24")
     *      Usefulness: Quickly get an object from a list by a particular function condition.
     * */
    public static T1 Get<T1>(this IEnumerable<T1> array, TDelegate<bool, T1> action, T1 defValue)
    {
        foreach (T1 el in array) if (action(el)) return el; return defValue;
    }
    public static T1 Get<T1, T2>(this IEnumerable<T1> array, T2 arg2, TDelegate<bool, T2, T1> action, T1 defValue)
    {
        foreach (T1 el in array) if (action(arg2, el)) return el; return defValue;
    }
    public static T1 Get<T1, T2>(this IEnumerable<T1> array, TDelegate<bool, T1, T2> action, T2 arg2, T1 defValue)
    {
        foreach (T1 el in array) if (action(el, arg2)) return el; return defValue;
    }
    public static T1 Get<T1, T2, T3>(this IEnumerable<T1> array, T2 arg2, T3 arg3, TDelegate<bool, T2, T3, T1> action, T1 defValue)
    {
        foreach (T1 el in array) if (action(arg2, arg3, el)) return el; return defValue;
    }
    public static T1 Get<T1, T2, T3>(this IEnumerable<T1> array, T2 arg2, TDelegate<bool, T2, T1, T3> action, T3 arg3, T1 defValue)
    {
        foreach (T1 el in array) if (action(arg2, el, arg3)) return el; return defValue;
    }
    public static T1 Get<T1, T2, T3>(this IEnumerable<T1> array, TDelegate<bool, T1, T2, T3> action, T2 arg2, T3 arg3, T1 defValue)
    {
        foreach (T1 el in array) if (action(el, arg2, arg3)) return el; return defValue;
    }
    public static T1 Get<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, T3 arg3, T4 arg4, TDelegate<bool, T2, T3, T4, T1> action, T1 defValue)
    {
        foreach (T1 el in array) if (action(arg2, arg3, arg4, el)) return el; return defValue;
    }
    public static T1 Get<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, T3 arg3, TDelegate<bool, T2, T3, T1, T4> action, T4 arg4, T1 defValue)
    {
        foreach (T1 el in array) if (action(arg2, arg3, el, arg4)) return el; return defValue;
    }
    public static T1 Get<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, TDelegate<bool, T2, T1, T3, T4> action, T3 arg3, T4 arg4, T1 defValue)
    {
        foreach (T1 el in array) if (action(arg2, el, arg3, arg4)) return el; return defValue;
    }
    public static T1 Get<T1, T2, T3, T4>(this IEnumerable<T1> array, TDelegate<bool, T1, T2, T3, T4> action, T2 arg2, T3 arg3, T4 arg4, T1 defValue)
    {
        foreach (T1 el in array) if (action(el, arg2, arg3, arg4)) return el; return defValue;
    }


    //      (Max, Min, MaxIndex, MinIndex):

    /*
     * T1 [IEnumerable<T1> array].Max<T1, T {...}>(T{A} arg{A} , TDelegate<float, T{A}, T1, T{B}> action, T{B} arg{B}, T1 defValue)
     * / static T1 Max<T1, T{...}>(IEnumerable<T1> array, T{A} arg{A} , TDelegate<float, T{A}, T1, T{B}> action, T{B} arg{B}, T1 defValue):
     *      Terms: {A} and {B} is a set of attributes in a particular order. {A} and {B} are both included in {...} not mattering the order.
     *      Function: For a list, returns the earliest element whose result of the float function is the maximum. If there's none, returns defValue.
     *      For functions up to 4 input arguments, the other values can be put (must be constants), but they require to be put in the right order,
     *      with the position where the variable argument would be, it's where the Delegate is.
     *      (i.e. "[List<string>].Max(Auxe.Length, null)" returns the earliest string with the maximum length. If there's none, returns null)
     *      Usefulness: Quickly get an element that causes a maximum with a function from a list.
     * */
    public static T1 Max<T1> (this IEnumerable<T1> array, TDelegate<float, T1> action, T1 defValue)
    {
        return !IsEmpty(array) && action != null ? (array as T1[])[array.MaxIndex(action)] : defValue;
    }
    public static T1 Max<T1, T2>(this IEnumerable<T1> array, T2 arg2, TDelegate<float, T2, T1> action, T1 defValue)
    {
        return !IsEmpty(array) && action != null ? (array as T1[])[array.MaxIndex(arg2, action)] : defValue;
    }
    public static T1 Max<T1, T2>(this IEnumerable<T1> array, TDelegate<float, T1, T2> action, T2 arg2, T1 defValue)
    {
        return !IsEmpty(array) && action != null ? (array as T1[])[array.MaxIndex(action, arg2)] : defValue;
    }
    public static T1 Max<T1, T2, T3>(this IEnumerable<T1> array, T2 arg2, T3 arg3, TDelegate<float, T2, T3, T1> action, T1 defValue)
    {
        return !IsEmpty(array) && action != null ? (array as T1[])[array.MaxIndex(arg2, arg3, action)] : defValue;
    }
    public static T1 Max<T1, T2, T3>(this IEnumerable<T1> array, T2 arg2, TDelegate<float, T2, T1, T3> action, T3 arg3, T1 defValue)
    {
        return !IsEmpty(array) && action != null ? (array as T1[])[array.MaxIndex(arg2, action, arg3)] : defValue;
    }
    public static T1 Max<T1, T2, T3>(this IEnumerable<T1> array, TDelegate<float, T1, T2, T3> action, T2 arg2, T3 arg3, T1 defValue)
    {
        return !IsEmpty(array) && action != null ? (array as T1[])[array.MaxIndex(action, arg2, arg3)] : defValue;
    }
    public static T1 Max<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, T3 arg3, T4 arg4, TDelegate<float, T2, T3, T4, T1> action, T1 defValue)
    {
        return !IsEmpty(array) && action != null ? (array as T1[])[array.MaxIndex(arg2, arg3, arg4, action)] : defValue;
    }
    public static T1 Max<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, T3 arg3, TDelegate<float, T2, T3, T1, T4> action, T4 arg4, T1 defValue)
    {
        return !IsEmpty(array) && action != null ? (array as T1[])[array.MaxIndex(arg2, arg3, action, arg4)] : defValue;
    }
    public static T1 Max<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, TDelegate<float, T2, T1, T3, T4> action, T3 arg3, T4 arg4, T1 defValue)
    {
        return !IsEmpty(array) && action != null ? (array as T1[])[array.MaxIndex(arg2, action, arg3, arg4)] : defValue;
    }
    public static T1 Max<T1, T2, T3, T4>(this IEnumerable<T1> array, TDelegate<float, T1, T2, T3, T4> action, T2 arg2, T3 arg3, T4 arg4, T1 defValue)
    {
        return !IsEmpty(array) && action != null ? (array as T1[])[array.MaxIndex(action, arg2, arg3, arg4)] : defValue;
    }

    /*
     * T1 [IEnumerable<T1> array].Min<T1, T {...}>(T{A} arg{A} , TDelegate<float, T{A}, T1, T{B}> action, T{B} arg{B}, T1 defValue)
     * / static T1 Min<T1, T{...}>(IEnumerable<T1> array, T{A} arg{A} , TDelegate<float, T{A}, T1, T{B}> action, T{B} arg{B}, T1 defValue):
     *      Terms: {A} and {B} is a set of attributes in a particular order. {A} and {B} are both included in {...} not mattering the order.
     *      Function: For a list, returns the earliest element whose result of the float function is the minimum. If there's none, returns defValue.
     *      For functions up to 4 input arguments, the other values can be put (must be constants), but they require to be put in the right order,
     *      with the position where the variable argument would be, it's where the Delegate is.
     *      (i.e. "[List<string>].Min(Auxe.Length, null)" returns the earliest string with the minimum length. If there's none, returns null)
     *      Usefulness: Quickly get an element that causes a minimum with a function from a list.
     * */
    public static T1 Min<T1>(this IEnumerable<T1> array, TDelegate<float, T1> action, T1 defValue)
    {
        return !IsEmpty(array) && action != null ? (array as T1[])[array.Execute(action).MinIndex()] : defValue;
    }
    public static T1 Min<T1, T2>(this IEnumerable<T1> array, T2 arg2, TDelegate<float, T2, T1> action, T1 defValue)
    {
        return !IsEmpty(array) && action != null ? (array as T1[])[array.Execute(arg2, action).MinIndex()] : defValue;
    }
    public static T1 Min<T1, T2>(this IEnumerable<T1> array, TDelegate<float, T1, T2> action, T2 arg2, T1 defValue)
    {
        return !IsEmpty(array) && action != null ? (array as T1[])[array.Execute(action, arg2).MinIndex()] : defValue;
    }
    public static T1 Min<T1, T2, T3>(this IEnumerable<T1> array, T2 arg2, T3 arg3, TDelegate<float, T2, T3, T1> action, T1 defValue)
    {
        return !IsEmpty(array) && action != null ? (array as T1[])[array.Execute(arg2, arg3, action).MinIndex()] : defValue;
    }
    public static T1 Min<T1, T2, T3>(this IEnumerable<T1> array, T2 arg2, TDelegate<float, T2, T1, T3> action, T3 arg3, T1 defValue)
    {
        return !IsEmpty(array) && action != null ? (array as T1[])[array.Execute(arg2, action, arg3).MinIndex()] : defValue;
    }
    public static T1 Min<T1, T2, T3>(this IEnumerable<T1> array, TDelegate<float, T1, T2, T3> action, T2 arg2, T3 arg3, T1 defValue)
    {
        return !IsEmpty(array) && action != null ? (array as T1[])[array.Execute(action, arg2, arg3).MinIndex()] : defValue;
    }
    public static T1 Min<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, T3 arg3, T4 arg4, TDelegate<float, T2, T3, T4, T1> action, T1 defValue)
    {
        return !IsEmpty(array) && action != null ? (array as T1[])[array.Execute(arg2, arg3, arg4, action).MinIndex()] : defValue;
    }
    public static T1 Min<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, T3 arg3, TDelegate<float, T2, T3, T1, T4> action, T4 arg4, T1 defValue)
    {
        return !IsEmpty(array) && action != null ? (array as T1[])[array.Execute(arg2, arg3, action, arg4).MinIndex()] : defValue;
    }
    public static T1 Min<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, TDelegate<float, T2, T1, T3, T4> action, T3 arg3, T4 arg4, T1 defValue)
    {
        return !IsEmpty(array) && action != null ? (array as T1[])[array.Execute(arg2, action, arg3, arg4).MinIndex()] : defValue;
    }
    public static T1 Min<T1, T2, T3, T4>(this IEnumerable<T1> array, TDelegate<float, T1, T2, T3, T4> action, T2 arg2, T3 arg3, T4 arg4, T1 defValue)
    {
        return !IsEmpty(array) && action != null ? (array as T1[])[array.Execute(action, arg2, arg3, arg4).MinIndex()] : defValue;
    }

    /*
     * int [IEnumerable<T1> array].MaxIndex<T1, T {...}>(T{A} arg{A} , TDelegate<float, T{A}, T1, T{B}> action, T{B} arg{B})
     * / static int MaxIndex<T1, T{...}>(IEnumerable<T1> array, T{A} arg{A} , TDelegate<float, T{A}, T1, T{B}> action, T{B} arg{B}):
     *      Terms: {A} and {B} is a set of attributes in a particular order. {A} and {B} are both included in {...} not mattering the order.
     *      Function: For a list, returns the earliest index of an element whose result of the float function is the maximum. If there's none, returns -1.
     *      For functions up to 4 input arguments, the other values can be put (must be constants), but they require to be put in the right order,
     *      with the position where the variable argument would be, it's where the Delegate is.
     *      (i.e. "[List<string>].MaxIndex(Auxe.Length)" returns the earliest index of the element with the maximum length, or -1)
     *      Usefulness: Quickly get the index of an element that causes a maximum with a function from a list.
     * */
    public static int MaxIndex<T1>(this IEnumerable<T1> array, TDelegate<float, T1> action)
    {
        return !IsEmpty(array) && action != null ? array.Execute(action).MaxIndex() : -1;
    }
    public static int MaxIndex<T1, T2>(this IEnumerable<T1> array, T2 arg2, TDelegate<float, T2, T1> action)
    {
        return !IsEmpty(array) && action != null ? array.Execute(arg2, action).MaxIndex() : -1;
    }
    public static int MaxIndex<T1, T2>(this IEnumerable<T1> array, TDelegate<float, T1, T2> action, T2 arg2)
    {
        return !IsEmpty(array) && action != null ? array.Execute(action, arg2).MaxIndex() : -1;
    }
    public static int MaxIndex<T1, T2, T3>(this IEnumerable<T1> array, T2 arg2, T3 arg3, TDelegate<float, T2, T3, T1> action)
    {
        return !IsEmpty(array) && action != null ? array.Execute(arg2, arg3, action).MaxIndex() : -1;
    }
    public static int MaxIndex<T1, T2, T3>(this IEnumerable<T1> array, T2 arg2, TDelegate<float, T2, T1, T3> action, T3 arg3)
    {
        return !IsEmpty(array) && action != null ? array.Execute(arg2, action, arg3).MaxIndex() : -1;
    }
    public static int MaxIndex<T1, T2, T3>(this IEnumerable<T1> array, TDelegate<float, T1, T2, T3> action, T2 arg2, T3 arg3)
    {
        return !IsEmpty(array) && action != null ? array.Execute(action, arg2, arg3).MaxIndex() : -1;
    }
    public static int MaxIndex<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, T3 arg3, T4 arg4, TDelegate<float, T2, T3, T4, T1> action)
    {
        return !IsEmpty(array) && action != null ? array.Execute(arg2, arg3, arg4, action).MaxIndex() : -1;
    }
    public static int MaxIndex<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, T3 arg3, TDelegate<float, T2, T3, T1, T4> action, T4 arg4)
    {
        return !IsEmpty(array) && action != null ? array.Execute(arg2, arg3, action, arg4).MaxIndex() : -1;
    }
    public static int MaxIndex<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, TDelegate<float, T2, T1, T3, T4> action, T3 arg3, T4 arg4)
    {
        return !IsEmpty(array) && action != null ? array.Execute(arg2, action, arg3, arg4).MaxIndex() : -1;
    }
    public static int MaxIndex<T1, T2, T3, T4>(this IEnumerable<T1> array, TDelegate<float, T1, T2, T3, T4> action, T2 arg2, T3 arg3, T4 arg4)
    {
        return !IsEmpty(array) && action != null ? array.Execute(action, arg2, arg3, arg4).MaxIndex() : -1;
    }

    /*
     * int [IEnumerable<T1> array].MinIndex<T1, T {...}>(T{A} arg{A} , TDelegate<float, T{A}, T1, T{B}> action, T{B} arg{B})
     * / static int MinIndex<T1, T{...}>(IEnumerable<T1> array, T{A} arg{A} , TDelegate<float, T{A}, T1, T{B}> action, T{B} arg{B}):
     *      Terms: {A} and {B} is a set of attributes in a particular order. {A} and {B} are both included in {...} not mattering the order.
     *      Function: For a list, returns the earliest index of an element whose result of the float function is the minimum. If there's none, returns -1.
     *      For functions up to 4 input arguments, the other values can be put (must be constants), but they require to be put in the right order,
     *      with the position where the variable argument would be, it's where the Delegate is.
     *      (i.e. "[List<string>].MinIndex(Auxe.Length)" returns the earliest index of the element with the minimum length, or -1)
     *      Usefulness: Quickly get the index of an element that causes a minimum with a function from a list.
     * */
    public static int MinIndex<T1>(this IEnumerable<T1> array, TDelegate<float, T1> action)
    {
        return !IsEmpty(array) && action != null ? array.Execute(action).MinIndex() : -1;
    }
    public static int MinIndex<T1, T2>(this IEnumerable<T1> array, T2 arg2, TDelegate<float, T2, T1> action)
    {
        return !IsEmpty(array) && action != null ? array.Execute(arg2, action).MinIndex() : -1;
    }
    public static int MinIndex<T1, T2>(this IEnumerable<T1> array, TDelegate<float, T1, T2> action, T2 arg2)
    {
        return !IsEmpty(array) && action != null ? array.Execute(action, arg2).MinIndex() : -1;
    }
    public static int MinIndex<T1, T2, T3>(this IEnumerable<T1> array, T2 arg2, T3 arg3, TDelegate<float, T2, T3, T1> action)
    {
        return !IsEmpty(array) && action != null ? array.Execute(arg2, arg3, action).MinIndex() : -1;
    }
    public static int MinIndex<T1, T2, T3>(this IEnumerable<T1> array, T2 arg2, TDelegate<float, T2, T1, T3> action, T3 arg3)
    {
        return !IsEmpty(array) && action != null ? array.Execute(arg2, action, arg3).MinIndex() : -1;
    }
    public static int MinIndex<T1, T2, T3>(this IEnumerable<T1> array, TDelegate<float, T1, T2, T3> action, T2 arg2, T3 arg3)
    {
        return !IsEmpty(array) && action != null ? array.Execute(action, arg2, arg3).MinIndex() : -1;
    }
    public static int MinIndex<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, T3 arg3, T4 arg4, TDelegate<float, T2, T3, T4, T1> action)
    {
        return !IsEmpty(array) && action != null ? array.Execute(arg2, arg3, arg4, action).MinIndex() : -1;
    }
    public static int MinIndex<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, T3 arg3, TDelegate<float, T2, T3, T1, T4> action, T4 arg4)
    {
        return !IsEmpty(array) && action != null ? array.Execute(arg2, arg3, action, arg4).MinIndex() : -1;
    }
    public static int MinIndex<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, TDelegate<float, T2, T1, T3, T4> action, T3 arg3, T4 arg4)
    {
        return !IsEmpty(array) && action != null ? array.Execute(arg2, action, arg3, arg4).MinIndex() : -1;
    }
    public static int MinIndex<T1, T2, T3, T4>(this IEnumerable<T1> array, TDelegate<float, T1, T2, T3, T4> action, T2 arg2, T3 arg3, T4 arg4)
    {
        return !IsEmpty(array) && action != null ? array.Execute(action, arg2, arg3, arg4).MinIndex() : -1;
    }


    //      (Summation):

    /*
     * float [IEnumerable<T1> array].Summation<T1, T {...}>(T{A} arg{A} , TDelegate<float, T{A}, T1, T{B}> action, T{B} arg{B})
     * / static T1 Max<T1, T{...}>(IEnumerable<T1> array, T{A} arg{A} , TDelegate<float, T{A}, T1, T{B}> action, T{B} arg{B}):
     *      Terms: {A} and {B} is a set of attributes in a particular order. {A} and {B} are both included in {...} not mattering the order.
     *      Function: For a list, returns the summation of the float function for each element.
     *      For functions up to 4 input arguments, the other values can be put (must be constants), but they require to be put in the right order,
     *      with the position where the variable argument would be, it's where the Delegate is.
     *      (i.e. "[List<string>].Max(Auxe.Length, null)" returns the summation of all the strings' length)
     *      Usefulness: Quickly get the summation from a list that needs to act upon a function.
     * */
    public static float Summation<T1>(this IEnumerable<T1> array, TDelegate<float, T1> action)
    {
        float current = 0f; foreach (T1 el in array) current += action(el); return current;
    }
    public static float Summation<T1, T2>(this IEnumerable<T1> array, T2 arg2, TDelegate<float, T2, T1> action)
    {
        float current = 0f; foreach (T1 el in array) current += action(arg2, el); return current;
    }
    public static float Summation<T1, T2>(this IEnumerable<T1> array, TDelegate<float, T1, T2> action, T2 arg2)
    {
        float current = 0f; foreach (T1 el in array) current += action(el, arg2); return current;
    }
    public static float Summation<T1, T2, T3>(this IEnumerable<T1> array, T2 arg2, T3 arg3, TDelegate<float, T2, T3, T1> action)
    {
        float current = 0f; foreach (T1 el in array) current += action(arg2, arg3, el); return current;
    }
    public static float Summation<T1, T2, T3>(this IEnumerable<T1> array, T2 arg2, TDelegate<float, T2, T1, T3> action, T3 arg3)
    {
        float current = 0f; foreach (T1 el in array) current += action(arg2, el, arg3); return current;
    }
    public static float Summation<T1, T2, T3>(this IEnumerable<T1> array, TDelegate<float, T1, T2, T3> action, T2 arg2, T3 arg3)
    {
        float current = 0f; foreach (T1 el in array) current += action(el, arg2, arg3); return current;
    }
    public static float Summation<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, T3 arg3, T4 arg4, TDelegate<float, T2, T3, T4, T1> action)
    {
        float current = 0f; foreach (T1 el in array) current += action(arg2, arg3, arg4, el); return current;
    }
    public static float Summation<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, T3 arg3, TDelegate<float, T2, T3, T1, T4> action, T4 arg4)
    {
        float current = 0f; foreach (T1 el in array) current += action(arg2, arg3, el, arg4); return current;
    }
    public static float Summation<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, TDelegate<float, T2, T1, T3, T4> action, T3 arg3, T4 arg4)
    {
        float current = 0f; foreach (T1 el in array) current += action(arg2, el, arg3, arg4); return current;
    }
    public static float Summation<T1, T2, T3, T4>(this IEnumerable<T1> array, TDelegate<float, T1, T2, T3, T4> action, T2 arg2, T3 arg3, T4 arg4)
    {
        float current = 0f; foreach (T1 el in array) current += action(el, arg2, arg3, arg4); return current;
    }


    //      (Execute, ExecuteDoble, ExecuteDobleDistinct):

    /*
     * List<T> [IEnumerable<T1> array].Execute<T, T1, T {...}>(T{A} arg{A} , TDelegate<T, T{A}, T1, T{B}> action, T{B} arg{B})
     * / static List<T> Execute<T, T1, T{...}>(IEnumerable<T1> array, T{A} arg{A} , TDelegate<T, T{A}, T1, T{B}> action, T{B} arg{B}):
     *      Terms: {A} and {B} is a set of attributes in a particular order. {A} and {B} are both included in {...} not mattering the order.
     *      Function: For a list, returns a list of the same size with the result for each one being the function result by using that element as input.
     *      For functions up to 4 input arguments, the other values can be put (must be constants), but they require to be put in the right order,
     *      with the position where the variable argument would be, it's where the Delegate is.
     *      (i.e. "[List<string>].Execute(Auxe.IsEmpty)" returns a list of bools saying the result of the function)
     *      (i.e. "[List<int>].Execute(Auxe.Abs)" returns a list of number that have been applied the Abs function)
     *      Usefulness: Quickly apply a list of changes to many elements at once with the same function.
     * */
    public static List<T> Execute<T, T1>(this IEnumerable<T1> array, TDelegate<T, T1> action)
    {
        var current = new List<T>(); foreach (T1 el in array) current.Add(action(el)); return current;
    }
    public static List<T> Execute<T, T1, T2>(this IEnumerable<T1> array, T2 arg2, TDelegate<T, T2, T1> action)
    {
        var current = new List<T>(); foreach (T1 el in array) current.Add(action(arg2, el)); return current;
    }
    public static List<T> Execute<T, T1, T2>(this IEnumerable<T1> array, TDelegate<T, T1, T2> action, T2 arg2)
    {
        var current = new List<T>(); foreach (T1 el in array) current.Add(action(el, arg2)); return current;
    }
    public static List<T> Execute<T, T1, T2, T3>(this IEnumerable<T1> array, T2 arg2, T3 arg3, TDelegate<T, T2, T3, T1> action)
    {
        var current = new List<T>(); foreach (T1 el in array) current.Add(action(arg2, arg3, el)); return current;
    }
    public static List<T> Execute<T, T1, T2, T3>(this IEnumerable<T1> array, T2 arg2, TDelegate<T, T2, T1, T3> action, T3 arg3)
    {
        var current = new List<T>(); foreach (T1 el in array) current.Add(action(arg2, el, arg3)); return current;
    }
    public static List<T> Execute<T, T1, T2, T3>(this IEnumerable<T1> array, TDelegate<T, T1, T2, T3> action, T2 arg2, T3 arg3)
    {
        var current = new List<T>(); foreach (T1 el in array) current.Add(action(el, arg2, arg3)); return current;
    }
    public static List<T> Execute<T, T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, T3 arg3, T4 arg4, TDelegate<T, T2, T3, T4, T1> action)
    {
        var current = new List<T>(); foreach (T1 el in array) current.Add(action(arg2, arg3, arg4, el)); return current;
    }
    public static List<T> Execute<T, T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, T3 arg3, TDelegate<T, T2, T3, T1, T4> action, T4 arg4)
    {
        var current = new List<T>(); foreach (T1 el in array) current.Add(action(arg2, arg3, el, arg4)); return current;
    }
    public static List<T> Execute<T, T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, TDelegate<T, T2, T1, T3, T4> action, T3 arg3, T4 arg4)
    {
        var current = new List<T>(); foreach (T1 el in array) current.Add(action(arg2, el, arg3, arg4)); return current;
    }
    public static List<T> Execute<T, T1, T2, T3, T4>(this IEnumerable<T1> array, TDelegate<T, T1, T2, T3, T4> action, T2 arg2, T3 arg3, T4 arg4)
    {
        var current = new List<T>(); foreach (T1 el in array) current.Add(action(el, arg2, arg3, arg4)); return current;
    }

    /*
     * List<T> [IEnumerable<T1> array].Execute<T, T1, T2, T {...}>(T{A} arg{A}, TDelegate<T, T{A}, T1, T{B}, T2, T{C}> action,
     *      T{B} arg{B}, IEnumerable<T2> otherlist, T{C} arg{C})
     * / static List<T> Execute<T, T1, T2, T{...}>(IEnumerable<T1> array, T{A} arg{A}, TDelegate<T, T{A}, T1, T{B}, T2, T{C}> action,
     *      T{B} arg{B}, IEnumerable<T2> otherlist, T{C} arg{C}):
     *      Terms: {A}, {B} and {C} is a set of attributes in a particular order. {A}, {B} and {C} are all included in {...} not mattering the order.
     *      Function: For a list, applies a function by paring in a function each first parameter with each second parameter, and adds it.
     *      This means that the size of the list will be array.Length * otherlist.Length, with the first parameter functions first.
     *      For functions up to 3 input arguments, the other values can be put (must be constants), but they require to be put in the right order,
     *      with the position where the variable argument would be, it's where the Delegate is, and the position of the 2nd variable argument the IEnumerable.
     *      (i.e. "[List<string>].Execute(Auxe.Contains, [List<string>])" returns a list of bools saying
     *      whether each string in the 2nd list is contained in each parameter in the 1st list)
     *      (i.e. "[List<string>].Execute([List<string>], Auxe.Contains)" returns a list of bools saying
     *      whether each string in the 1nd list is contained in each parameter in the 2nd list)
     *      Usefulness: Quickly apply a list of changes to pars of elements and their results.
     * */
    public static List<T> Execute<T, T1, T2>(this IEnumerable<T1> array, TDelegate<T, T1, T2> action, IEnumerable<T2> otherlist)
    {
        var current = new List<T>(); foreach (T1 el1 in array) foreach (T2 el2 in otherlist) current.Add(action(el1, el2)); return current;
    }
    public static List<T> Execute<T, T1, T2>(this IEnumerable<T1> array, IEnumerable<T2> otherlist, TDelegate<T, T2, T1> action)
    {
        var current = new List<T>(); foreach (T1 el1 in array) foreach (T2 el2 in otherlist) current.Add(action(el2, el1)); return current;
    }
    public static List<T> Execute<T, T1, T2, T3>(this IEnumerable<T1> array, T3 arg3, TDelegate<T, T3, T1, T2> action, IEnumerable<T2> otherlist)
    {
        var current = new List<T>(); foreach (T1 el1 in array) foreach (T2 el2 in otherlist) current.Add(action(arg3, el1, el2)); return current;
    }
    public static List<T> Execute<T, T1, T2, T3>(this IEnumerable<T1> array, T3 arg3, IEnumerable<T2> otherlist, TDelegate<T, T3, T2, T1> action)
    {
        var current = new List<T>(); foreach (T1 el1 in array) foreach (T2 el2 in otherlist) current.Add(action(arg3, el2, el1)); return current;
    }
    public static List<T> Execute<T, T1, T2, T3>(this IEnumerable<T1> array, TDelegate<T, T1, T3, T2> action, T3 arg3, IEnumerable<T2> otherlist)
    {
        var current = new List<T>(); foreach (T1 el1 in array) foreach (T2 el2 in otherlist) current.Add(action(el1, arg3, el2)); return current;
    }
    public static List<T> Execute<T, T1, T2, T3>(this IEnumerable<T1> array, IEnumerable<T2> otherlist, T3 arg3, TDelegate<T, T2, T3, T1> action)
    {
        var current = new List<T>(); foreach (T1 el1 in array) foreach (T2 el2 in otherlist) current.Add(action(el2, arg3, el1)); return current;
    }
    public static List<T> Execute<T, T1, T2, T3>(this IEnumerable<T1> array, TDelegate<T, T1, T2, T3> action, IEnumerable<T2> otherlist, T3 arg3)
    {
        var current = new List<T>(); foreach (T1 el1 in array) foreach (T2 el2 in otherlist) current.Add(action(el1, el2, arg3)); return current;
    }
    public static List<T> Execute<T, T1, T2, T3>(this IEnumerable<T1> array, IEnumerable<T2> otherlist, TDelegate<T, T2, T1, T3> action, T3 arg3)
    {
        var current = new List<T>(); foreach (T1 el1 in array) foreach (T2 el2 in otherlist) current.Add(action(el2, el1, arg3)); return current;
    }

    /*
     * void [IEnumerable<T1> array].Execute<T1, T {...}>(T{A} arg{A} , VoidDelegate<T{A}, T1, T{B}> action, T{B} arg{B})
     * / static void Execute<T1, T{...}>(IEnumerable<T1> array, T{A} arg{A} , VoidDelegate<T{A}, T1, T{B}> action, T{B} arg{B}):
     *      Terms: {A} and {B} is a set of attributes in a particular order. {A} and {B} are both included in {...} not mattering the order.
     *      Function: For a list, applies a function with each element as parameter.
     *      For functions up to 4 input arguments, the other values can be put (must be constants), but they require to be put in the right order,
     *      with the position where the variable argument would be, it's where the Delegate is.
     *      Usefulness: Quickly apply a function to many elements.
     * */
    public static void Execute<T1>(this IEnumerable<T1> array, VoidDelegate<T1> action)
    {
        foreach (T1 el in array) action(el);
    }
    public static void Execute<T1, T2>(this IEnumerable<T1> array, T2 arg2, VoidDelegate<T2, T1> action)
    {
        foreach (T1 el in array) action(arg2, el);
    }
    public static void Execute<T1, T2>(this IEnumerable<T1> array, VoidDelegate<T1, T2> action, T2 arg2)
    {
        foreach (T1 el in array) action(el, arg2);
    }
    public static void Execute<T1, T2, T3>(this IEnumerable<T1> array, T2 arg2, T3 arg3, VoidDelegate<T2, T3, T1> action)
    {
        foreach (T1 el in array) action(arg2, arg3, el);
    }
    public static void Execute<T1, T2, T3>(this IEnumerable<T1> array, T2 arg2, VoidDelegate<T2, T1, T3> action, T3 arg3)
    {
        foreach (T1 el in array) action(arg2, el, arg3);
    }
    public static void Execute<T1, T2, T3>(this IEnumerable<T1> array, VoidDelegate<T1, T2, T3> action, T2 arg2, T3 arg3)
    {
        foreach (T1 el in array) action(el, arg2, arg3);
    }
    public static void Execute<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, T3 arg3, T4 arg4, VoidDelegate<T2, T3, T4, T1> action)
    {
        foreach (T1 el in array) action(arg2, arg3, arg4, el);
    }
    public static void Execute<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, T3 arg3, VoidDelegate<T2, T3, T1, T4> action, T4 arg4)
    {
        foreach (T1 el in array) action(arg2, arg3, el, arg4);
    }
    public static void Execute<T1, T2, T3, T4>(this IEnumerable<T1> array, T2 arg2, VoidDelegate<T2, T1, T3, T4> action, T3 arg3, T4 arg4)
    {
        foreach (T1 el in array) action(arg2, el, arg3, arg4);
    }
    public static void Execute<T1, T2, T3, T4>(this IEnumerable<T1> array, VoidDelegate<T1, T2, T3, T4> action, T2 arg2, T3 arg3, T4 arg4)
    {
        foreach (T1 el in array) action(el, arg2, arg3, arg4);
    }

    /*
     * void [IEnumerable<T1> array].Execute<T1, T2, T {...}>(T{A} arg{A}, VoidDelegate<T{A}, T1, T{B}, T2, T{C}> action,
     *      T{B} arg{B}, IEnumerable<T2> otherlist, T{C} arg{C})
     * / static void Execute<T1, T2, T{...}>(IEnumerable<T1> array, T{A} arg{A}, VoidDelegate<T{A}, T1, T{B}, T2, T{C}> action,
     *      T{B} arg{B}, IEnumerable<T2> otherlist, T{C} arg{C}):
     *      Terms: {A}, {B} and {C} is a set of attributes in a particular order. {A}, {B} and {C} are all included in {...} not mattering the order.
     *      Function: For a list, applies a function by paring in a function each first parameter with each second parameter.
     *      For functions up to 3 input arguments, the other values can be put (must be constants), but they require to be put in the right order,
     *      with the position where the variable argument would be, it's where the Delegate is, and the position of the 2nd variable argument the IEnumerable.
     *      Usefulness: Quickly apply a function for each pair of elements.
     * */
    public static void Execute<T1, T2>(this IEnumerable<T1> array, VoidDelegate<T1, T2> action, IEnumerable<T2> otherlist)
    {
        foreach (T1 el1 in array) foreach (T2 el2 in otherlist) action(el1, el2);
    }
    public static void Execute<T1, T2>(this IEnumerable<T1> array, IEnumerable<T2> otherlist, VoidDelegate<T2, T1> action)
    {
        foreach (T1 el1 in array) foreach (T2 el2 in otherlist) action(el2, el1);
    }
    public static void Execute<T1, T2, T3>(this IEnumerable<T1> array, T3 arg3, VoidDelegate<T3, T1, T2> action, IEnumerable<T2> otherlist)
    {
        foreach (T1 el1 in array) foreach (T2 el2 in otherlist) action(arg3, el1, el2);
    }
    public static void Execute<T1, T2, T3>(this IEnumerable<T1> array, T3 arg3, IEnumerable<T2> otherlist, VoidDelegate<T3, T2, T1> action)
    {
        foreach (T1 el1 in array) foreach (T2 el2 in otherlist) action(arg3, el2, el1);
    }
    public static void Execute<T1, T2, T3>(this IEnumerable<T1> array, VoidDelegate<T1, T3, T2> action, T3 arg3, IEnumerable<T2> otherlist)
    {
        foreach (T1 el1 in array) foreach (T2 el2 in otherlist) action(el1, arg3, el2);
    }
    public static void Execute<T1, T2, T3>(this IEnumerable<T1> array, IEnumerable<T2> otherlist, T3 arg3, VoidDelegate<T2, T3, T1> action)
    {
        foreach (T1 el1 in array) foreach (T2 el2 in otherlist) action(el2, arg3, el1);
    }
    public static void Execute<T1, T2, T3>(this IEnumerable<T1> array, VoidDelegate<T1, T2, T3> action, IEnumerable<T2> otherlist, T3 arg3)
    {
        foreach (T1 el1 in array) foreach (T2 el2 in otherlist) action(el1, el2, arg3);
    }
    public static void Execute<T1, T2, T3>(this IEnumerable<T1> array, IEnumerable<T2> otherlist, VoidDelegate<T2, T1, T3> action, T3 arg3)
    {
        foreach (T1 el1 in array) foreach (T2 el2 in otherlist) action(el2, el1, arg3);
    }

    /*
     * List<T> [IEnumerable<T1> array].ExecuteDoble<T, T1>(TDelegate<T, T1, T1> action, bool same)
     * / static List<T> ExecuteDoble<T, T1>(IEnumerable<T1> array, TDelegate<T, T1, T1> action, bool same):
     *      Function: For a list, returns a list executing a function with both parameters as the input arguments, and adds it.
     *      "Same" indicates if it's allowed to consider a function with the same element in the two input arguments.
     *      This means that the size of the list will be "array.Length ^ 2" (or if same = false, "array.Length * (array.Length - 1)"),
     *      with the first parameter functions first.
     *      (i.e. "[List<string>].ExecuteDoble(Auxe.Contains, false)" returns a list of bools saying if each string is inside another,
     *      excluding comparisons to oneself)
     *      Usefulness: Quickly apply a function with elements of the same array.
     *      
     * void [IEnumerable<T> array].ExecuteDoble<T>(VoidDelegate<T, T> action, bool same)
     * / static void ExecuteDoble<T>(IEnumerable<T> array, VoidDelegate<T, T> action, bool same):
     *      Function: For a list, returns a list executing a function with both parameters as the input arguments.
     *      "Same" indicates if it's allowed to consider a function with the same element in the two input arguments.
     *      Usefulness: Quickly apply a function with elements of the same array.
     * */
    public static List<T> ExecuteDoble<T,T1>(this IEnumerable<T1> array, TDelegate<T, T1, T1> action, bool same = true)
    {
        var current = new List<T>();
        var list = new List<T1>(array);

        for (int i = 0; i < list.Count; i++)
            for (int j = 0; j < list.Count; j++)
                if (same || i != j)
                    current.Add(action(list[i], list[j]));

        return current;
    }
    public static void ExecuteDoble<T>(this IEnumerable<T> array, VoidDelegate<T, T> action, bool same = true)
    {
        List<T> list = new List<T>(array);

        for (int i = 0; i < list.Count; i++)
            for (int j = 0; j < list.Count; j++)
                if (same || i != j)
                    action(list[i], list[j]);
    }

    /*
     * List<T> [IEnumerable<T1> array].ExecuteDobleDistinct<T, T1>(TDelegate<T, T1, T1> action)
     * / static List<T> ExecuteDobleDistinct<T, T1>(IEnumerable<T1> array, TDelegate<T, T1, T1> action):
     *      Function: For a list, returns a list executing a function with both parameters as the input arguments without repeating two, and adds it.
     *      This means that the size of the list will be a sequential sum from 1 to "array.Length", and the earliest parameter will always go first.
     *      (i.e. "[List<string>].ExecuteDobleDistinct(Auxe.Contains, false)" returns a list of bools saying if each earlier string
     *      contains the ones that come after it)
     *      Usefulness: Quickly apply a function with elements of the same array and being distinct for each one.
     *      
     * void [IEnumerable<T> array].ExecuteDobleDistinct<T>(VoidDelegate<T, T> action)
     * / static void ExecuteDobleDistinct<T>(IEnumerable<T> array, VoidDelegate<T, T> action):
     *      Function: For a list, returns a list executing a function with both parameters as the input arguments without repeating two.
     *      The earliest parameter will always go first in the list of arguments.
     *      Usefulness: Quickly apply a function with elements of the same array and being distinct for each one.
     * */
    public static List<T> ExecuteDobleDistinct<T, T1>(this IEnumerable<T1> array, TDelegate<T, T1, T1> action)
    {
        var current = new List<T>();
        var list = new List<T1>(array);

        for (int i = 0; i < list.Count; i++)
            for (int j = i + 1; j < list.Count; j++)
                current.Add(action(list[i], list[j]));

        return current;
    }
    public static void ExecuteDobleDistinct<T>(this IEnumerable<T> array, VoidDelegate<T, T> action)
    {
        List<T> list = new List<T>(array);

        for (int i = 0; i < list.Count; i++)
            for (int j = i + 1; j < list.Count; j++)
                action(list[i], list[j]);
    }


    /////////////////// ARRAY<T> EXTENSIONS /////////////////////

    /*
     * bool [T[] list].Contains<T>(T value) / static bool Contains<T>(T[] list, T value):
     *      Function: Returns whether "value" is included inside the array.
     *      Usefulness: To apply the useful Contains function to arrays.
     * */
    public static bool Contains<T> (this T[] list, T value)
    {
        return new List<T>(list).Contains(value);
    }

    /*
     * T[] [T[] list].Clone<T>() / static T[] Clone<T>(T[] list):
     *      Function: Returns a copy of "list" with the same size and values.
     *      Usefulness: To be able to clone an array.
     * */
    public static T[] Clone<T>(this T[] list)
    {
        return new List<T>(list).ToArray();
    }

    /*
     * T[] [T[] content].Cut<T>(int cutStart, int cutEnd) / static T[] Clone<T>(T[] content, int cutStart, int cutEnd):
     *      Function: Returns a copy of "content" with the start and end elements cut.
     *      Usefulness: To be able to quickly filter elements from an array.
     * */
    public static T[] Cut<T>(this T[] content, int cutStart, int cutEnd)
    {
        return new List<T>(content).Cut(cutStart, cutEnd).ToArray();
    }

    /*
     * T[] [T[] list].Distinct<T>() / static T[] Distinct<T>(T[] list):
     *      Function: Returns a copy of the "list" with all the repeated elements filtered.
     *      Usefulness: To easily filter repeated elements from an array.
     * */
    public static T[] Distinct<T>(this T[] list)
    {
        return new List<T>(list).Distinct().ToArray();
    }

    /*
     * T[] [T[] list].Sublist<T>(int counter) / static T[] Sublist<T>(T[] list, int counter):
     *      Function: Returns a copy of the "list" from a particular position.
     *      Usefulness: To be able to easily filter elements to arrays.
     * */
    public static T[] Sublist<T>(this T[] list, int counter)
    {
        return new List<T>(list).Sublist(counter).ToArray();
    }

    /*
     * List<T> [T[] list].ToList<T>() / static List<T> ToList<T>(T[] list, int counter):
     *      Function: Returns the array turned into a list.
     *      Usefulness: To apply the useful ToArray function at the inverse.
     * */
    public static List<T> ToList<T> (this T[] list)
    {
        return new List<T>(list);
    }

    /*
     * T [T[] list].Get<T>(int counter) / static T Get<T>(T[] list, int counter) { where T : class }:
     *      Function: Returns the element in a particular position. In case it's not possible, it returns null instead of an exception.
     *      Usefulness: To get an element without fear to an exception.
     *      
     * T [T[] list].Get<T>(int counter, T defValue) / static T Get<T>(T[] list, int counter, T defValue):
     *      Function: Returns the element in a particular position. In case it's not possible, it returns "defValue" instead of an exception.
     *      Usefulness: To get an element without fear to an exception.
     * */
    public static T Get<T>(this T[] list, int counter) where T : class
    {
        return list.Get(counter, null);
    }
    public static T Get<T>(this T[] list, int counter, T defValue)
    {
        return list.Between(counter) ? list[counter] : defValue;
    }


    /////////////////// LIST<T> EXTENSIONS /////////////////////

    //      (Functions):
    /*
     * List<T> [List<List<T>> array].Combine<T>() / static List<T> Combine<T>(List<List<T>> array):
     *      Function: Combines all the list into one with the elements of one list inserted right after the previous one.
     *      Usefulness: To combine lists usefully when in situations they appear in this format.
     * */
    public static List<T> Combine<T>(this List<List<T>> array)
    {
        List<T> list = new List<T>();
        foreach (IEnumerable<T> el in array)
            if (el != null)
                list.AddRange(el);
        return list;
    }

    /*
     * List<T> [List<T> list].Clone<T>() / static List<T> Clone<T>(List<T> list):
     *      Function: Returns a copy of "list" with the same size and values.
     *      Usefulness: To be able to clone a list.
     * */
    public static List<T> Clone<T>(this List<T> list)
    {
        return new List<T>(list);
    }

    /*
     * List<T> [List<T> content].Cut<T>(int cutStart, int cutEnd) / static List<T> Clone<T>(List<T> content, int cutStart, int cutEnd):
     *      Function: Returns a copy of "content" with the start and end elements cut.
     *      Usefulness: To be able to quickly filter elements from a list.
     * */
    public static List<T> Cut<T>(this List<T> content, int cutStart, int cutEnd)
    {
        if (content == null || cutStart < 0 || cutEnd < 0 || content.Count < cutStart + cutEnd)
            return null;

        List<T> t = new List<T> (content);
        if (cutEnd > 0)
            t.RemoveRange(t.Count - cutEnd, cutEnd);
        if (cutStart > 0)
            t.RemoveRange(0, cutStart);
        return t;
    }

    /*
     * List<T> [List<T> list].Distinct<T>() / static List<T> Distinct<T>(List<T> list):
     *      Function: Returns a copy of the "list" with all the repeated elements filtered.
     *      Usefulness: To easily filter repeated elements from a list.
     * */
    public static List<T> Distinct<T>(this List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
            for (int j = i + 1; j < list.Count; j++)
                if (list[i].Equals(list[j]))
                {
                    list.RemoveAt(j);
                    j--;
                }

        return list;
    }

    /*
     * bool [List<T> list].Similar<T>(List<T> ap) / static bool Similar<T>(List<T> list, List<T> ap):
     *      Function: Returns whether the size and contents of the two lists is the same.
     *      Usefulness: To easily check if two list are similar without having the same reference.
     * */
    public static bool Similar<T>(this List<T> list, List<T> ap)
    {
        if (list.Count != ap.Count)
            return false;

        for (int i = 0; i < list.Count; i++)
            if (list[i].Equals(ap[i]))
                return false;
        return true;
    }

    /*
     * List<T> [List<T> list].Sublist<T>(int counter) / static List<T> Sublist<T>(List<T> list, int counter):
     *      Function: Returns a copy of the "list" from a particular position.
     *      Usefulness: To be able to easily filter elements to lists.
     * */
    public static List<T> Sublist<T>(this List<T> list, int counter)
    {
        if (!list.Between(counter))
            return null;

        List<T> newlist = new List<T>(list);
        while (counter > 0)
        {
            newlist.RemoveAt(0);
            counter--;
        }
        return newlist;
    }


    //      (AddReturn):

    /*
     * List<T> [List<T> array].AddReturn<T>(T value) / static List<T> AddReturn<T>(List<T> array, T value):
     *      Function: Returns a copy of the list with the inserted element.
     *      Usefulness: Instead of "Add" being a void function, now it returns a value.
     *      
     * List<T> [List<T> array].AddReturn<T>(List<T> value) / static List<T> AddReturn<T>(List<T> array, List<T> value):
     *      Function: Returns a copy of the list with the inserted elements.
     *      Usefulness: Instead of "AddRange" as a void function, now it returns a value.
     * */
    public static List<T> AddReturn<T>(this List<T> array, T value)
    {
        var list = array.Clone();
        list.Add(value);
        return list;
    }
    public static List<T> AddReturn<T>(this List<T> array, List<T> value)
    {
        if (array == null)
            return null;
        var list = array.Clone();
        if (value == null)
            return list;
        list.AddRange(value);
        return list;
    }


    //      (Get):

    /*
     * T [List<T> list].Get<T>(int counter) / static T Get<T>(List<T> list, int counter) { where T : class }:
     *      Function: Returns the element in a particular position. In case it's not possible, it returns null instead of an exception.
     *      Usefulness: To get an element without fear to an exception.
     *      
     * T [List<T> list].Get<T>(int counter, T defValue) / static T Get<T>(List<T> list, int counter, T defValue):
     *      Function: Returns the element in a particular position. In case it's not possible, it returns "defValue" instead of an exception.
     *      Usefulness: To get an element without fear to an exception.
     * */
    public static T Get<T>(this List<T> list, int counter) where T : class
    {
        return list.Get(counter, null);
    }
    public static T Get<T>(this List<T> list, int counter, T defValue)
    {
        return list.Between(counter) ? list[counter] : defValue;
    }


    //      (Next, Previous):

    /*
     * T [List<T> list].Next<T>(T value) / static T Next<T>(List<T> list, T value) { where T : class }:
     *      Function: Returns the next element of the list after "value". If it's not included, it returns null.
     *      If it's the end, it gets the first one.
     *      Usefulness: To get the next element just with the value.
     *      
     * T [List<T> list].Next<T>(T value, T defValue) / static T Next<T>(List<T> list, T value, T defValue):
     *      Function: Returns the next element of the list after "value". If it's not included, it returns "defValue".
     *      If it's the end, it gets the first one.
     *      Usefulness: To get the next element just with the value.
     * */
    public static T Next<T>(this List<T> list, T value) where T : class
    {
        return list.Next(value, null);
    }
    public static T Next<T>(this List<T> list, T value, T defValue)
    {
        return list.Contains(value)? list[(list.IndexOf(value) + 1) % list.Count] : defValue;
    }

    /*
     * T [List<T> list].Previous<T>(T value) / static T Previous<T>(List<T> list, T value) { where T : class }:
     *      Function: Returns the previous element of the list after "value". If it's not included, it returns null.
     *      If it's the start, it gets the last one.
     *      Usefulness: To get the previous element just with the value.
     *      
     * T [List<T> list].Previous<T>(T value, T defValue) / static T Previous<T>(List<T> list, T value, T defValue):
     *      Function: Returns the previous element of the list after "value". If it's not included, it returns "defValue".
     *      If it's the start, it gets the last one.
     *      Usefulness: To get the previous element just with the value.
     * */
    public static T Previous<T>(this List<T> list, T value) where T : class
    {
        return list.Previous(value, null);
    }
    public static T Previous<T>(this List<T> list, T value, T defValue)
    {
        return list.Contains(value) ? list[(list.IndexOf(value) - 1) % list.Count] : defValue;
    }


    //      (RemoveReturn, RemoveAtReturn, RemoveAllReturn):

    /*
     * List<T> [List<T> array].RemoveReturn<T>(T remove) / static List<T> RemoveReturn<T>(List<T> array, T remove):
     *      Function: Returns a copy of the list with the earliest element removed (if there wasn't, it's the same).
     *      Usefulness: Instead of "Remove" being a void function, now it returns a value.
     *      
     * List<T> [List<T> array].RemoveAtReturn<T>(int remove) / static List<T> RemoveAtReturn<T>(List<T> array, int remove):
     *      Function: Returns a copy of the list with the element in that position removed.
     *      Usefulness: Instead of "RemoveAt" being a void function, now it returns a value.
     *      
     * List<T> [List<T> array].RemoveReturn<T>(List<T> remove) / static List<T> RemoveReturn<T>(List<T> array, List<T> remove):
     *      Function: Returns a copy of the list with the earliest elements removed (if there weren't, it's the same).
     *      Usefulness: Instead of "Remove" as a void function, now it returns a value.
     *      
     * List<T> [List<T> array].RemoveAllReturn<T>(T value) / static List<T> RemoveAllReturn<T>(List<T> array, T value):
     *      Function: Returns a copy of the list with the element removed in all instances (if there weren't, it's the same).
     *      Usefulness: Instead of "Remove" as a void function, now it returns a value.
     * */
    public static List<T> RemoveReturn<T>(this List<T> list, T remove)
    {
        List<T> newlist = list.Clone();
        
        if (newlist.Contains(remove))
            newlist.Remove(remove);
        return newlist;
    }
    public static List<T> RemoveAtReturn<T>(this List<T> list, int remove)
    {
        List<T> newlist = list.Clone();

        if (newlist.Between(remove))
            newlist.RemoveAt(remove);
        return newlist;
    }
    public static List<T> RemoveReturn<T> (this List<T> list, List<T> remove)
    {
        List<T> newlist = list.Clone();

        foreach (T el in remove)
            if (newlist.Contains(el))
                newlist.Remove(el);
        return newlist;
    }
    public static List<T> RemoveAllReturn<T>(this List<T> list, T value)
    {
        List<T> newlist = list.Clone();

        for (int i = newlist.Count - 1; i >= 0; i--)
            if (newlist[i].Equals(value))
                newlist.RemoveAt(i);
        return newlist;
    }


    //      (Set, SetReturn):

    /*
     * void [List<T> list].Set<T>(int index, IEnumerable<T> values) / static void Set<T>(List<T> list, int index, IEnumerable<T> values):
     *      Function: Removes one position and inserts all the values instead. It changes the selected list.
     *      Usefulness: To insert a bunch of elements in a position by replacing another value.
     *      
     * List<T> [List<T> list].SetReturn<T>(int index, IEnumerable<T> values) / static List<T> SetReturn<T>(List<T> list, int index, IEnumerable<T> values):
     *      Function: Removes one position and inserts all the values instead. It returns the value in a new copy.
     *      Usefulness: To insert a bunch of elements in a position by replacing another value.
     * */
    public static void Set<T>(this List<T> array, int index, IEnumerable<T> values)
    {
        array.AddRange(values);
        array.RemoveAt(index);
    }
    public static List<T> SetReturn<T>(this List<T> array, int index, IEnumerable<T> values)
    {
        var list = array.Clone();
        list.AddRange(values);
        list.RemoveAt(index);
        return list;
    }


    /////////////////// DICTIONARY<TKEY, TVALUE> EXTENSIONS /////////////////////

    /*
     * void [Dictionary<TKey, TValue> content].Add<TKey, TValue>(TValue defValue, params TKey[] keys)
     * / static void Add<TKey, TValue>(Dictionary<TKey, TValue> content, TValue defValue, params TKey[] keys):
     *      Function: Adds the new keys in case they don't exist yet with the value "defValue".
     *      Usefulness: To insert a few elements easily while at the same time ignoring if they've been inserted already.
     * */
    public static void Add<TKey, TValue> (this Dictionary<TKey, TValue> content, TValue defValue, params TKey[] keys)
    {
        foreach (TKey key in keys)
            if (!content.ContainsKey(key))
                content.Add(key, defValue);
    }

    /*
     * Dictionary<TKey, TValue> [Dictionary<TKey, TValue> list].Clone<TKey, TValue>()
     * / static Dictionary<TKey, TValue> Clone<TKey, TValue>(Dictionary<TKey, TValue> list):
     *      Function: Creates a clone of the Dictionary with all their keys and values.
     *      Usefulness: To easily create a duplicate of a dictionary.
     * */
    public static Dictionary<TKey, TValue> Clone<TKey, TValue> (this Dictionary<TKey, TValue> list)
    {
        var dict = new Dictionary<TKey, TValue>();
        foreach (TKey key in list.Keys)
            dict.Add(key, list[key]);
        return dict;
    }

    /*
     * TValue [Dictionary<TKey, TValue> list].Get<TKey, TValue>(TKey index)
     * / static TValue Get<TKey, TValue>(Dictionary<TKey, TValue> list, TKey index) { where T : class }:
     *      Function: Returns the element by a particular key. In case it's not possible, it returns null instead of an exception.
     *      Usefulness: To get an element without fear to an exception.
     *      
     * TValue [Dictionary<TKey, TValue> list].Get<TKey, TValue>(TKey index, TValue defValue)
     * / static TValue Get<TKey, TValue>(Dictionary<TKey, TValue> list, TKey index, TValue defValue)):
     *      Function: Returns the element by a particular key. In case it's not possible, it returns "defValue" instead of an exception.
     *      Usefulness: To get an element without fear to an exception.
     * */
    public static TValue Get<TKey, TValue>(this Dictionary<TKey, TValue> list, TKey index) where TValue : class
    {
        return list.Get(index, null);
    }
    public static TValue Get<TKey, TValue>(this Dictionary<TKey, TValue> list, TKey index, TValue defValue)
    {
        return list.ContainsKey(index) ? list[index] : defValue;
    }

    /*
     * List<TKey> [Dictionary<TKey, TValue> list].GetKeys<TKey, TValue>(TValue value)
     * / static List<TKey> GetKeys<TKey, TValue>(Dictionary<TKey, TValue> list, TValue value):
     *      Function: Gets all the keys that have as their value the argument.
     *      Usefulness: To get the opposite way of a Dictionary.
     * */
    public static List<TKey> GetKeys<TKey, TValue> (this Dictionary<TKey, TValue> list, TValue value)
    {
        var newlist = new List<TKey>();
        foreach (TKey key in list.Keys)
            if (list[key].Equals(value))
                newlist.Add(key);
        return newlist;
    }


    /////////////////// XDOCUMENT EXTENSIONS /////////////////////

    /*
     * XElement [XDocument xdoc].SearchByAttribute(string el, string attr, string value)
     * / static XElement SearchByAttribute(XDocument xdoc, string el, string attr, string value):
     *      Function: Gets the earliest XElement from a XDocument whose attribute has a particular value.
     *      Usefulness: To easily obtain the right XElement based on an attribute search.
     * */
    public static XElement SearchByAttribute(this XDocument xdoc, string el, string attr, string value)
    {
        foreach (XElement xel in xdoc.Elements(el))
            if (value.Equals(xel.Attribute(attr).Value))
                return xel;
        return null;
    }


    /////////////////// XELEMENT EXTENSIONS /////////////////////

    /*
     * Dictionary<string, string> [XElement el].Dictionary() / static Dictionary<string, string> Dictionary(XElement el):
     *      Function: Gets a dictionary composed of the type as key and the content as value from the XElement.
     *      Usefulness: To easily obtain a dictionary with the attributes and types inside an XElement.
     * */
    public static Dictionary<string, string> Dictionary(this XElement el)
    {
        Dictionary<string, string> dict = new Dictionary<string, string>();
        dict.Add("type", el.Name.LocalName);
        dict.Add("content", el.IsEmpty ? "" : el.Value.TrimExtense());
        foreach (var attr in el.Attributes())
            dict.Add(attr.Name.LocalName, attr.Value);
        return dict;
    }

    /*
     * XElement [XElement xdoc].SearchByAttribute(string el, string attr, string value)
     * / static XElement SearchByAttribute(XElement xdoc, string el, string attr, string value):
     *      Function: Gets the earliest XElement from another XElement whose attribute has a particular value.
     *      Usefulness: To easily obtain the right XElement based on an attribute search.
     * */
    public static XElement SearchByAttribute(this XElement xdoc, string el, string attr, string value)
    {
        foreach (XElement xel in xdoc.Elements(el))
            if (value.Equals(xel.Attribute(attr).Value))
                return xel;
        return null;
    }
}
