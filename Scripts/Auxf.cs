/*
 * Auxf (Auxiliar Function):
 * This file contains a few main functions to facilitate certain operations in C#.
 * It needs the library "System", "System.Collections.Generic" and "UnityEngine" to work, so it only works on Unity projects.
 * It also needs the other classes from the pack: "Auxp.cs", "Auxe.cs"
 * 
 * Developed by Alberto León Meaños, 22/07/2018, License GNU General Public License v3.0
 * */


using System.Collections.Generic;
using UnityEngine;
using System;


public class Auxf
{
    //Attributes:
    public readonly float MINIMUM = 0.0001f;


    //Singleton (invoke by calling "Auxf.i"):
    private static Auxf m_instance = null;
    public static Auxf i { get { if (m_instance == null) m_instance = new Auxf(); return m_instance; } }
    private Auxf() { }


    //IComparable Functions:

    /*
     * bool IsNotNull<T>(T e) where T : class:
     *      Function: Returns whether the class is null.
     *      Usefulness: For list extension functions that may need this function as delegate, check if a class is null or not.
     * */
    public bool IsNotNull<T> (T e) where T : class
    {
        return e != null;
    }

    /*
     * bool GreaterThan<T>(T v1, T v2) where T : IComparable:
     *      Function: Returns whether v1 is greater by being compared than v2.
     *      Usefulness: For list extension functions that may need this function as delegate.
     * */
    public bool GreaterThan<T> (T v1, T v2) where T : IComparable
    {
        return v1.CompareTo(v2) > 0;
    }

    /*
     * bool GreaterEqualThan<T>(T v1, T v2) where T : IComparable:
     *      Function: Returns whether v1 is greater or equal by being compared than v2.
     *      Usefulness: For list extension functions that may need this function as delegate.
     * */
    public bool GreaterEqualThan<T>(T v1, T v2) where T : IComparable
    {
        return v1.CompareTo(v2) >= 0;
    }

    /*
     * bool LessThan<T>(T v1, T v2) where T : IComparable:
     *      Function: Returns whether v1 is less by being compared than v2.
     *      Usefulness: For list extension functions that may need this function as delegate.
     * */
    public bool LessThan<T>(T v1, T v2) where T : IComparable
    {
        return v1.CompareTo(v2) < 0;
    }

    /*
     * bool LessEqualThan<T>(T v1, T v2) where T : IComparable:
     *      Function: Returns whether v1 is less or equal by being compared than v2.
     *      Usefulness: For list extension functions that may need this function as delegate.
     * */
    public bool LessEqualThan<T>(T v1, T v2) where T : IComparable
    {
        return v1.CompareTo(v2) <= 0;
    }

    /*
     * bool Disequals<T>(T v1, T v2):
     *      Function: Returns whether v1 is not equal to v2.
     *      Usefulness: For list extension functions that may need this function as delegate.
     * */
    public bool Disequals<T>(T v1, T v2)
    {
        return !v1.Equals(v2);
    }


    //UnityEngine Functions:

    /*
     * AuxPolygon IntersectionTwoLines<T>(RectTransform a, RectTransform b, AuxCoord co):
     *      Function: Returns an AuxPolygon with the point positions of the intersection of the RectTransform in a 0Z plane
     *      (ignoring Z coordinate) and using the X or Y coordinate of the objects as the main line/angle.
     *      Usefulness: To get the area of two RectTransform inmediately.
     *      Based on: Auxp.i.Intersects <Polygon, Polygon>
     *      Dependences: Auxe, Auxp.
     * */
    public AuxPolygon IntersectionTwoLines(RectTransform a, RectTransform b, AuxCoord co)
    {
        if (co == AuxCoord.z)
            return null;
        float o = co == AuxCoord.x? 0f : 90f;

        var awl1 = new AuxWideLine(a.position, a.rotation.Angle(AuxCoord.z, o), co == AuxCoord.x ? a.sizeDelta.y : a.sizeDelta.x);
        var awl2 = new AuxWideLine(b.position, b.rotation.Angle(AuxCoord.z, o), co == AuxCoord.x ? b.sizeDelta.y : b.sizeDelta.x);
        return awl1 * awl2;
    }


    /*
     * Class SML (Separator Markup Language):
     *      It allows to use functions to treat text based on a new SML format. The format is the following
     *      (characters '[', ']', and '*' are not part of the name: []* represents it can be repeated from "[0,...)" ):
     *      
     *      [method_title {
     *          [word(sub[,sub]*)]*;
     *      }]*
     *      
     *      i.e.:
     *      a_title {
     *          element_1 element_2(attr_1,attr_2) element_3;
     *          element_a(attr_a) element_b;
     *      }
     * */
    public class SML
    {
        //Attributes:
        public readonly char lineSeparator = ';';
        public readonly char wordSeparator = ' ';
        public readonly char subSeparator = ',';
        public readonly char openSub = '(';
        public readonly char closeSub = ')';
        public readonly char openMethod = '{';
        public readonly char closeMethod = '}';
        public readonly string allowableNumbers = "0123456789.-,";
        

        //Singleton:
        private static SML m_instance = null;
        public static SML i { get { if (m_instance == null) m_instance = new SML(); return m_instance; } }
        private SML() { }


        /*
         * Delegates -> SMLStringDelegate:
         * A Delegate that takes two <char, float> dictionaries and returns a string.
         * This is supposed to take the dictionaries of two different sub parts (the content between each ','), and based on their data,
         * returns a string that is the combination of the first and second subpart however it's wished to be changed. 
         * This is done to use each subpart as a possible shortcut to different words with only subs.
         * */
        public delegate string SMLStringDelegate(Dictionary<char, float> dict1, Dictionary<char, float> dict2);


        //Split SML Functions:

        /*
         * string GetMethod(string text, string identifier):
         *      Function: Returns the content of a method's name inside the text (brackets and spaces not included).
         *      Usefulness: To quickly separate the content of each method.
         * */
        public string GetMethod(string text, string identifier)
        {
            if (text == null || identifier == null)
                return null;
            return text.Substring(identifier).SubstringChar(openMethod, closeMethod).Cut(1, 1).TrimExtense();
        }

        /*
         * string[] SplitLines(string method):
         *      Function: Given a method, separate by lineSeparator (';') each line inside method.
         *      Usefulness: To quickly separate the lines of each method.
         * */
        public string[] SplitLines(string method)
        {
            List<string> list = new List<string>(method.TrimExtense().Split(lineSeparator));
            if (list.Last().IsEmpty())
                list = list.Cut(0, 1);
            return list.ToArray();
        }

        /*
         * string[] SplitWords(string line):
         *      Function: Given a line, separate by wordSeparator (' ') each word inside the line.
         *      ' ' spaces are no allowed inbetween each word.
         *      Usefulness: To quickly separate the words of each line.
         * */
        public string[] SplitWords(string line)
        {
            return line.TrimExtense().Split(wordSeparator);
        }

        /*
         * string[] SplitParts(string line):
         *      Function: Given a word, if the word has two parts, returns a string of size 2 with the name and the content in the parenthesis
         *      (the parenthesis are excluded from the string already).
         *      Usefulness: To quickly separate the parts of each word.
         * */
        public string[] SplitParts(string word)
        {
            string parenthesis = word.SubstringChar(openSub, closeSub);
            if (parenthesis == null)
                return null;
            string mainWord = word.Remove(parenthesis);
            if (mainWord.Length == 0)
                return null;

            return new string[] { mainWord, parenthesis.Cut(1, 1) };
        }

        /*
         * string[] SplitSubs(string part):
         *      Function: Given a parenthesis part, separate by subSeparator (',') the diferent subcode of this part.
         *      Usefulness: To quickly separate the subs of each part.
         * */
        public string[] SplitSubs(string part)
        {
            return part.Split(subSeparator);
        }


        //Format Functions:

        /*
         * bool FormatParts(string word):
         *      Function: Given a word, returns whether it fulfills the "parts" format (name and parenthesis).
         *      Usefulness: To quickly check if a particular word has the parenthesis format or not.
         * */
        public bool FormatParts(string word)
        {
            return SplitParts(word) != null;
        }

        /*
         * bool FormatName(string word, string name):
         *      Function: Given a word, returns whether it fulfills the "parts" format (name and parenthesis) and it has a particular name.
         *      Usefulness: To quickly check if a particular word has the parenthesis format or not and it has a particular name.
         * */
        public bool FormatName(string word, string name)
        {
            return FormatParts(word) && SplitParts(word)[0].Equals(name);
        }

        /*
         * bool FormatSubs(string word, params char[] names):
         *      Function: Given a word, returns whether the subs inside the parenthesis code include, at least, one of the chars.
         *      Usefulness: To quickly check if the subs fulfill a particular format.
         *      The chars can be just put as params.
         *      
         * bool FormatSubs(string word, IEnumerable<char> names):
         *      Function: Given a word, returns whether the subs inside the parenthesis code include, at least, one of the chars.
         *      Usefulness: To quickly check if the subs fulfill a particular format.
         *      Any IEnumerable<char> (lists, strings) are valid.
         * */
        public bool FormatSubs(string word, params char[] names)
        {
            return FormatSubs(word, names as IEnumerable<char>);
        }
        public bool FormatSubs(string word, IEnumerable<char> names)
        {
            if (SplitParts(word) == null)
                return false;
            names = (names as string).Remove(
                new char[] { lineSeparator, wordSeparator, subSeparator, openSub, closeSub });
            word = SplitParts(word)[1];

            return word.IsFormat(allowableNumbers + names)
                && SplitSubs(word).IsAll<string, string>(Auxe.Contains, (names.ToIEnumerableString()).IsAny);
        }


        //Other Functions:

        /*
         * Dictionary<char, float> Dictionary(string parameters, string keywords):
         *      Function: Given a sub with this format ([<number><char>]*), it turns the sub into a dictionary where the key it's the char
         *      (only valid inside those inside the "keywords" list) and the value is the number.
         *      Usefulness: To quickly create a dictionary separating each char and its value.
         * */
        public Dictionary<char, float> Dictionary(string parameters, string keywords)
        {
            int firstIndex = 0;
            var dict = new Dictionary<char, float>();
            for (int i = 0; i < parameters.Length; i++)
                if (keywords.Contains(parameters[i]))
                {
                    dict.Add(parameters[i], float.Parse(parameters.Substring(firstIndex, i - firstIndex)));
                    firstIndex = i + 1;
                }

            return dict;
        }

        /*
         * string SubsToWords(string word, string keywords, SMLStringDelegate SMLFunction):
         *      Function: Given a word with each sub in this format ([<number><char>]*), it separates each sub into a word
         *      where each one's value is calculated with the previous sub marked according to the SMLFunction (variable).
         *      Usefulness: To add a meaning to different subs in relation with one another
         *      (for example, simplify code instead of writing a new exact word with the right parameters everytime).
         * */
        public string SubsToWords(string word, string keywords, SMLStringDelegate SMLFunction)
        {
            string[] list;
            string result = "", medium;
            Dictionary<char, float> dict1 = null, dict2 = null;

            if ((list = SplitParts(word)) == null)
                return null;

            foreach (string sub in SplitSubs(list[1]))
            {
                if (dict1 == null)
                {
                    result += list[0] + openSub + sub + closeSub + wordSeparator;
                    dict1 = Dictionary(sub, keywords);
                }
                else
                {
                    dict2 = Dictionary(sub, keywords);
                    medium = SMLFunction(dict1, dict2);
                    result += list[0] + openSub + medium + closeSub + wordSeparator;
                    dict1 = Dictionary(medium, keywords);
                }
            }

            return result.Cut(wordSeparator);
        }
    }
    
}
