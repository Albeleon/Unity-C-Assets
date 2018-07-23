# Unity-C#-Assets
Assets created for Unity C# to facilitate the work with it.

# Auxc.cs (Auxiliar Comparer):
This file has the Comparer functions to be used in Sort functions.
- <b>Vector2Comparer:</b> It allows to compare Vector2 and order them, first off with the "y" coordinate as priority, and then the "x" coordinate.
- <b>Vector3Comparer:</b> It allows to compare Vector2 and order them, first off with the "z" coordinate as priority, then the "y" coordinate, and then the "x" coordinate.
   
# Auxe.cs (Auxiliar Extension):
This file contains the main method extensions developed to facilitate functions made in C#. These functions are independent of UnityEngine, so they can be used in any C# project. A lot of these functions are implementations of classes functions into extension methods to be more comfortable to use sequentially in code.
- <b>T Extensions (A):</b>

      - "T[] A.Array()":      Turns the element into a one-sized array.
      - "List<T> A.List()":   Turns the element into a one-sized list.
- <b>IComparable Extensions (A):</b>

      - "bool A.Between(T min, T max)": Checks whether the value is between those two.
- <b>Int Extensions (A):</b>

      - "int A.Abs()": Returns the absolute number.
      - "int A.Pow(int potenc)": Returns the number elevated to another.
- <b>Float Extensions (A):</b>

      - "float A.Abs()": Returns the absolute number.
      - "float A.Pow(float potenc)": Returns the number elevated to another.
      
      - "float A.Floor()": Returns the number floored to the unit.
      - "float A.Floor(float chunk)": Returns the number floored to multiples of the "chunk" value.
- <b>String Extensions (A):</b>

      - "int A.CompareTo(string firstParam, string secondParam)": Returns -1 if firstParam is before secondParam inside the string. In the opposite case, it's 1. In any other case, 0.
      - "bool A.Contains(char format)": Returns whether the char "format" is included in the string.
      - "bool A.Format(char separator, params string[] inside)": Returns whether the content contains in each individual part (separated by the separator) the respective element of "inside".
      - "bool A.IsEmpty()": Returns whether the content is empty.
      - "bool A.IsFormat(string format)": Returns whether each character of "content" is inside "format".
      - "float A.ParseOperation()": Returns a number which is the operation of the string parsed according to the normal format and characters { +-/*^() }.
      - "string A.TrimExtense()": Returns a string without the "formatChar" characters at the beginning and end of the string (' ', '\n', '\r').
      
      - "string A.Cut(int characterStart, int characterEnd)": Returns a string with a specific number of characters removed from the beginning and end of the content.
      - "string A.Cut(params char[] list)": Returns a string with the specific chars cut from the beginning and end of the content.
      - "string A.Cut(IEnumerable<char> list)": Returns a string with the specific chars cut from the beginning and end of the content.
      
      - "string A.EndNumber()": Returns the last part of the string that contains numbers (not including decimals {'.'} ).
      - "string A.EndNumberAdd(int offset)": Returns a string whose last number is increased by one.
      - "string A.EndNumberReplace(int number)": Returns a string whose last number is replaced by other.
      
      - "int[] A.IndexOf(params string[] chars)": Returns an array of int with each char's IndexOf value (in case of error, -1).
      - "int A.IndexEndOf(string chars)": Returns the index of a string right after "chars".
      - "int A.IndexEndOf(string chars, int startIndex)": Returns the index of a string right after "chars". It starts looking from one particular index.
      - "int[] A.IndexEndOf(params string[] chars)": Returns an array of int with each char's IndexEndOf value (in case of error, -1).

      - "string A.Remove(params char[] chars)": Returns a string with each char parameter removed from it.
      - "string A.Remove(IEnumerable<char> chars)": Returns a string with each char parameter removed from it.
      - "string A.Remove(params string[] strings)": Returns a string with each string parameter removed from it.
      - "string A.Remove(IEnumerable<string> strings)": Returns a string with each string parameter removed from it.

      - "string[] A.Split(string openKey, string closeKey)": Returns a list of strings with the content inside each openKey and closeKey, ignoring the rest.
      - "string[] A.Split(string separator, string openIgnore, string closeIgnore)": Returns a list of strings separated by the string "separator", ignoring the separators inside openIgnore and closeIgnore.

      - "string A.Substring(string openKey)": Returns a substring of the content starting from the first string subpart found.
      - "string A.Substring(int startIndex, string closeKey)": Returns a substring of the content starting from a number position and ending with the upcoming string found.
      - "string A.Substring(string openKey, string closeKey)": Returns a substring of the content starting from the first string subpart found and ending with the upcoming string found.
      - "string A.Substring(string openKey, string closeKey, string openIgnore, string closeIgnore)": Returns a substring of the content starting from the first string subpart found and ending with the upcoming string found. It ignores the keys inside "openIgnore" and "closeIgnore".
      - "string A.SubstringChar(char openKey, char closeKey)": Returns a substring of the content starting from the first char found and ending with the upcoming char found.
      - "string A.SubstringIndex(int startIndex, int endIndex)": Returns a substring of the content starting from the first and last index position (including that last index).
- <b>IEnumerable[char] Extensions (A):</b>
  
      - "IEnumerable<string> A.ToIEnumerableString()": Returns an IEnumerable where each "char" has been turned into "string".
- <b>IEnumerable[string] Extensions (A):</b>
  
      - "string A.Concatenate()": Returns a string that is composed of all the string of the IEnumerable concatenated one after the other.
      - "string A.Concatenate(string separator)": Returns a string that is composed of all the string of the IEnumerable concatenated one after the other, separated by the separator.
- <b>IEnumerable[int] Extensions (A):</b>
  
      - "int A.Min()": Returns the minimum value of the elements of the array.
      - "int A.MinIndex()": Returns the earliest index of the minimum value of the elements of the array.
      - "int A.Max()": Returns the maximum value of the elements of the array.
      - "int A.MaxIndex()": Returns the earliest index of the maximum value of the elements of the array.
- <b>IEnumerable[float] Extensions (A):</b>
  
      - "float A.Min()": Returns the minimum value of the elements of the array.
      - "float A.MinIndex()": Returns the earliest index of the minimum value of the elements of the array.
      - "float A.Max()": Returns the maximum value of the elements of the array.
      - "float A.MaxIndex()": Returns the earliest index of the maximum value of the elements of the array.
- <b>IEnumerable[T] Extensions (A):</b>
  
      - "bool A.Between(int counter)": Returns whether the "counter" value reflects a valid position inside the IEnumerable.
      - "list<T1> A<T2>.ConstantClone(T1 constantValue)": Returns a list of the same size as the IEnumerable but with possible different type, that has one constant value.
      - "bool A.IsEmpty()": Returns whether the content is empty.

      - "T A.First()": Returns the first element of the IEnumerable. If it's empty, returns "null".
      - "T A.First(T defaultValue)": Returns the first element of the IEnumerable. If it's empty, returns the default value.
      - "T A.Last()": Returns the last element of the IEnumerable. If it's empty, returns "null".
      - "T A.Last(T defaultValue)": Returns the last element of the IEnumerable. If it's empty, returns the default value.

      - "bool A.IsAll( ... )": For a list, checks if a function that returns "bool" is true for all the values inside. Otherwise, it's false. For functions up to 4 input arguments, the other values can be put (must be constants), but they require to be put in the right order, with the position where the variable argument would be, it's where the Delegate is. (i.e. "[List<string>].IsAll(largeString.Contains)" checks if all the strings are contained in "largeString") (i.e. "[List<int>].IsAll(Auxe.Between, min, max);" checks if all the numbers in the list are between "min" and "max") (i.e. "[List<int>].IsAll(value, min, Auxe.Between);" checks if the value number is always between "min" and each number in the list).
      - "bool A.IsAll( ... )": Upgrade of the normal IsAll function. For each element of the function, it summons another IsAll/IsAny for a second list of parameters. This means that, at least, we need a function with 2 input arguments where two will be variable, and each 1st parameter will have its bool value decided after checking with each 2nd parameter. IsAll and IsAny can be combined however they want. For functions up to 3 input arguments, the other values can be put (must be constants), but they require to be put in the right order, with the position where the variable argument would be, it's where the Delegate is, and the position of the 2nd variable argument the IsAny/IsAll. (i.e. "[List<string>].IsAll(Auxe.Contains, [List<string>].IsAny)" checks if all the parameters of the first list have, at least, one of the parameters of the 2nd list inside. Each 1st parameter will return true if at least one. If one 1st parameter fails, returns "false") .
      - "bool A.IsAny( ... )": For a list, checks if a function that returns "bool" is true for any the values inside. Otherwise, it's false. For functions up to 4 input arguments, the other values can be put (must be constants), but they require to be put in the right order, with the position where the variable argument would be, it's where the Delegate is. (i.e. "[List<string>].IsAny(largeString.Contains)" checks if any the strings are contained in "largeString") (i.e. "[List<int>].IsAny(Auxe.Between, min, max);" checks if at least one of the numbers in the list are between "min" and "max") (i.e. "[List<int>].IsAny(value, min, Auxe.Between);" checks if value number is at least once between "min" and each number in the list).
      - "bool A.IsAny( ... )": Upgrade of the normal IsAny function. For each element of the function, it summons another IsAll/IsAny for a second list of parameters. This means that, at least, we need a function with 2 input arguments where two will be variable, and each 1st parameter will have its bool value decided after checking with each 2nd parameter. IsAll and IsAny can be combined however they want. For functions up to 3 input arguments, the other values can be put (must be constants), but they require to be put in the right order, with the position where the variable argument would be, it's where the Delegate is, and the position of the 2nd variable argument the IsAny/IsAll. (i.e. "[List<string>].IsAny(Auxe.Contains, [List<string>].IsAll)" checks if at least one parameter of the first list has all the parameters of the 2nd list inside. Each 1st parameter will return true if all the 2nd parameters are inside. If one 1st parameter succeeds, returns "true").

      - "List<T1> A<T1>.Filter( ... )": For a list, returns a list with all the elemnts that in the bool function returned "false" removed. For functions up to 4 input arguments, the other values can be put (must be constants), but they require to be put in the right order, with the position where the variable argument would be, it's where the Delegate is. (i.e. "[List<string>].Filter(largeString.Contains)" returns a list with only the strings contained in "largeString") (i.e. "[List<int>].Filter(Auxe.Between, min, max);" returns a list with only the numbers between "min" and "max").
      - "T1 A<T1>.Get( ... )": For a list, returns the first element that returned "true" with the bool function. If there's none, returns defValue. For functions up to 4 input arguments, the other values can be put (must be constants), but they require to be put in the right order, with the position where the variable argument would be, it's where the Delegate is. (i.e. "[List<string>].Get(largeString.Contains, null)" returns the first string contained in "largeString". If there's none, returns "null") (i.e. "[List<int>].Get(Auxe.Between, min, max, -24);" returns the first number between "min" and "max". If there's none, returns "-24").

      - "T1 A<T1>.Max( ... )": For a list, returns the earliest element whose result of the float function is the maximum. If there's none, returns defValue. For functions up to 4 input arguments, the other values can be put (must be constants), but they require to be put in the right order, with the position where the variable argument would be, it's where the Delegate is. (i.e. "[List<string>].Max(Auxe.Length, null)" returns the earliest string with the maximum length. If there's none, returns null).
      - "T1 A<T1>.Min( ... )": For a list, returns the earliest element whose result of the float function is the minimum. If there's none, returns defValue. For functions up to 4 input arguments, the other values can be put (must be constants), but they require to be put in the right order, with the position where the variable argument would be, it's where the Delegate is. (i.e. "[List<string>].Min(Auxe.Length, null)" returns the earliest string with the minimum length. If there's none, returns null).
      - "int A.MaxIndex( ... )":For a list, returns the earliest index of an element whose result of the float function is the maximum. If there's none, returns -1. For functions up to 4 input arguments, the other values can be put (must be constants), but they require to be put in the right order, with the position where the variable argument would be, it's where the Delegate is. (i.e. "[List<string>].MaxIndex(Auxe.Length)" returns the earliest index of the element with the maximum length, or -1) .
      - "int A.MinIndex( ... )": For a list, returns the earliest index of an element whose result of the float function is the minimum. If there's none, returns -1. For functions up to 4 input arguments, the other values can be put (must be constants), but they require to be put in the right order, with the position where the variable argument would be, it's where the Delegate is. (i.e. "[List<string>].MinIndex(Auxe.Length)" returns the earliest index of the element with the minimum length, or -1).
      - "float A.Summation( ... )": For a list, returns the summation of the float function for each element. For functions up to 4 input arguments, the other values can be put (must be constants), but they require to be put in the right order, with the position where the variable argument would be, it's where the Delegate is. (i.e. "[List<string>].Max(Auxe.Length, null)" returns the summation of all the strings' length).

      - "List<T> A.Execute( ... )": For a list, returns a list of the same size with the result for each one being the function result by using that element as input. For functions up to 4 input arguments, the other values can be put (must be constants), but they require to be put in the right order, with the position where the variable argument would be, it's where the Delegate is. (i.e. "[List<string>].Execute(Auxe.IsEmpty)" returns a list of bools saying the result of the function) (i.e. "[List<int>].Execute(Auxe.Abs)" returns a list of number that have been applied the Abs function).
      - "List<T> A.Execute( ... )": For a list, applies a function by paring in a function each first parameter with each second parameter, and adds it. This means that the size of the list will be array.Length * otherlist.Length, with the first parameter functions first. For functions up to 3 input arguments, the other values can be put (must be constants), but they require to be put in the right order, with the position where the variable argument would be, it's where the Delegate is, and the position of the 2nd variable argument the IEnumerable. (i.e. "[List<string>].Execute(Auxe.Contains, [List<string>])" returns a list of bools saying whether each string in the 2nd list is contained in each parameter in the 1st list) (i.e. "[List<string>].Execute([List<string>], Auxe.Contains)" returns a list of bools saying whether each string in the 1nd list is contained in each parameter in the 2nd list).
      - "void A.Execute( ... )": For a list, applies a function with each element as parameter. For functions up to 4 input arguments, the other values can be put (must be constants), but they require to be put in the right order, with the position where the variable argument would be, it's where the Delegate is..
      - "void A.Execute( ... )": For a list, applies a function by paring in a function each first parameter with each second parameter. For functions up to 3 input arguments, the other values can be put (must be constants), but they require to be put in the right order, with the position where the variable argument would be, it's where the Delegate is, and the position of the 2nd variable argument the IEnumerable.
      - "List<T> A.ExecuteDoble( ... )": For a list, returns a list executing a function with both parameters as the input arguments, and adds it. "Same" indicates if it's allowed to consider a function with the same element in the two input arguments. This means that the size of the list will be "array.Length ^ 2" (or if same = false, "array.Length * (array.Length - 1)"), with the first parameter functions first. (i.e. "[List<string>].ExecuteDoble(Auxe.Contains, false)" returns a list of bools saying if each string is inside another, excluding comparisons to oneself).
      - "void A.ExecuteDoble( ... )": For a list, returns a list executing a function with both parameters as the input arguments. "Same" indicates if it's allowed to consider a function with the same element in the two input arguments.
      - "List<T> A.ExecuteDobleDistinct( ... )": For a list, returns a list executing a function with both parameters as the input arguments without repeating two, and adds it. This means that the size of the list will be a sequential sum from 1 to "array.Length", and the earliest parameter will always go first. (i.e. "[List<string>].ExecuteDobleDistinct(Auxe.Contains, false)" returns a list of bools saying if each earlier string contains the ones that come after it).
      - "void A.ExecuteDobleDistinct( ... )": For a list, returns a list executing a function with both parameters as the input arguments without repeating two. The earliest parameter will always go first in the list of arguments.
- <b>T[] Extensions (A):</b>

      - "bool A.Contains(T value)": Returns whether "value" is included inside the array.
      - "T[] A.Clone()": Returns a copy of "list" with the same size and values.
      - "T[] A.Cut(int cutStart, int cutEnd)": Returns a copy of "content" with the start and end elements cut.
      - "T[] A.Distinct()": Returns a copy of the "list" with all the repeated elements filtered.
      - "T[] A.Sublist(int counter)": Returns a copy of the "list" from a particular position.
      - "List<T> A.ToList()": Returns the array turned into a list.

      - "T A.Get(int counter)": Returns the element in a particular position. In case it's not possible, it returns null instead of an exception.
      - "T A.Get(int counter, T defValue)": Returns the element in a particular position. In case it's not possible, it returns "defValue" instead of an exception.
- <b>List[T] Extensions (A):</b>
  
      - "bool A.Contains(T value)": Combines all the list into one with the elements of one list inserted right after the previous one.
      - "List<T> A.Clone()": Returns a copy of "list" with the same size and values.
      - "List<T> A.Cut(int cutStart, int cutEnd)": Returns a copy of "content" with the start and end elements cut.
      - "List<T> A.Distinct()": Returns a copy of the "list" with all the repeated elements filtered.
      - "bool A.Similar(List<T> ap)": Returns whether the size and contents of the two lists is the same.
      - "List<T> A.Sublist(int counter)": Returns a copy of the "list" from a particular position.

      - "List<T> A.AddReturn(T value)": Returns a copy of the list with the inserted element.
      - "List<T> A.AddReturn(List<T> value)": Returns a copy of the list with the inserted elements.

      - "T A.Get(int counter)": Returns the element in a particular position. In case it's not possible, it returns null instead of an exception.
      - "T A.Get(int counter, T defValue)": Returns the element in a particular position. In case it's not possible, it returns "defValue" instead of an exception.

      - "T A.Next(T value)": Returns the next element of the list after "value". If it's not included, it returns null. If it's the end, it gets the first one.
      - "T A.Next(T value, T defValue)": Returns the next element of the list after "value". If it's not included, it returns "defValue". If it's the end, it gets the first one.
      - "T A.Previous(T value)": Returns the previous element of the list after "value". If it's not included, it returns null. If it's the start, it gets the last one.
      - "T A.Previous(T defValue)": Returns the previous element of the list after "value". If it's not included, it returns "defValue". If it's the start, it gets the last one.

      - "List<T> A.RemoveReturn(T remove)": Returns a copy of the list with the earliest element removed (if there wasn't, it's the same).
      - "List<T> A.RemoveAtReturn(int remove)": Returns a copy of the list with the element in that position removed.
      - "List<T> A.RemoveReturn(List<T> remove)": Returns a copy of the list with the earliest elements removed (if there weren't, it's the same).
      - "List<T> A.RemoveAllReturn(T value)": Returns a copy of the list with the element removed in all instances (if there weren't, it's the same).

      - "void A.Set(int index, IEnumerable<T> values)": Removes one position and inserts all the values instead. It changes the selected list.
      - "List<T> A.SetReturn(int index, IEnumerable<T> values)": Removes one position and inserts all the values instead. It returns the value in a new copy.
- <b>Dictionary<TKey, TValue> Extensions (A):</b>
  
      - "void A.Add(TValue defValue, params TKey[] keys)": Adds the new keys in case they don't exist yet with the value "defValue".
      - "Dictionary<TKey, TValue> A.Clone()": Creates a clone of the Dictionary with all their keys and values.

      - "TValue A.Get(TKey index)": Returns the element by a particular key. In case it's not possible, it returns null instead of an exception.
      - "TValue A.Get(TKey index, TValue defValue)": Returns the element by a particular key. In case it's not possible, it returns "defValue" instead of an exception.
      - "List<TKey> A.GetKeys(TValue value)": Gets all the keys that have as their value the argument.
- <b>XDocument Extensions (A):</b>

      - "XElement A.SearchByAttribute(string el, string attr, string value)": Gets the earliest XElement from a XDocument whose attribute has a particular value.
- <b>XElement Extensions (A):</b>

      - "Dictionary<string,string> A.Dictionary()": Gets a dictionary composed of the type as key and the content as value from the XElement.
      - "XElement A.SearchByAttribute(string el, string attr, string value)": Gets the earliest XElement from another XElement whose attribute has a particular value.
      
# AuxeUnity.cs (Auxiliar Extension Unity):
This file contains the main method extensions developed to facilitate functions made in Unity C#. These functions are related and dependent of UnityEngine, so they can only be used in Unity C# project. A lot of these functions are implementations of classes functions into extension methods to be more comfortable to use sequentially in code.
- <b>Int Extensions (A):</b>

      - "float A.Deg2Rad()": Returns a number in degrees (angle) to radians (angle).
      - "float A.Rad2Deg()": Returns a number in radians (angle) to degrees (angle).
      
      - "Vector2 A.AngleDeg()": Returns a normalized Vector2 (starting from Vector2.right) by passing a degree value.
      - "Vector2 A.AngleRad()": Returns a normalized Vector2 (starting from Vector2.right) by passing a radians value.
- <b>Float Extensions (A):</b>

      - "float A.Deg2Rad()": Returns a number in degrees (angle) to radians (angle).
      - "float A.Rad2Deg()": Returns a number in radians (angle) to degrees (angle)..
      - "Vector2 A.AngleDeg()": Returns a normalized Vector2 (starting from Vector2.right) by passing a degree value.
      - "Vector2 A.AngleRad()": Returns a normalized Vector2 (starting from Vector2.right) by passing a radians value.
- <b>Color Extensions (A):</b>

      - "Color A.Set(float value, AuxColor c)": Returns a new Color with the same data as "vec" but with the coordinate "c" changed to "value".
      - "Color A.Set(float value, string c)": Returns a new Color with the same data as "vec" but with the coordinate "c" changed to "value".
- <b>Vector2 / Vector3 Extensions (A):</b>

      - "Vector2 A.Offset(Vector2 v, float d)": Returns a new Vector2 based on "p" with its position moved in direction "v" and magnitude "d".
      - "Vector3 A.Offset(Vector3 v, float d)": Returns a new Vector3 based on "p" with its position moved in direction "v" and magnitude "d".
      - "Vector2 A.Perpendicular()": Returns a new Vector2 that is the perpendicular of the vector "v", in format (-y, x).
      
      - "bool A<Vector2>.IsNaN()": Returns true if any value in the Vector2 is NaN.
      - "bool A<Vector3>.IsNaN()": Returns true if any value in the Vector3 is NaN.
      
      - "float A.Cross(Vector2 v2)": Returns the Cross Product between the Vector2 v1 and v2 (v1 being the first) as a constant.
      - "Vector3 A.Cross(Vector3 v2)": Returns the Cross Product between the Vector3 v1 and v2 (v1 being the first) as another Vector3.
      - "float A.Dot(Vector2 v2)": Returns the Dot Product between the Vector2 v1 and v2.
      - "float A.Dot(Vector3 v2)": Returns the Dot Product between the Vector3 v1 and v2.
      - "Vector2 A.RawMult(Vector2 v2)": Returns a Vector2 where each coordinate is the product of the same coordinate of the two vectors.
      - "Vector3 A.RawMult(Vector3 v2)": Returns a Vector3 where each coordinate is the product of the same coordinate of the two vectors.
      
      - "Vector2 A.Set(float value, AuxCoord c)": Returns a new Vector2 with the same data as "vec" but with the coordinate "c" changed to "value".
      - "Vector2 A.Set(float value, string c)": Returns a new Vector2 with the same data as "vec" but with the coordinate "c" changed to "value" (this string must be a valid coordinate {x, y}, or else it changes nothing).
      - "Vector3 A.Set(float value, AuxCoord c)": Returns a new Vector3 with the same data as "vec" but with the coordinate "c" changed to "value".
      - "Vector3 A.Set(float value, string c)": Returns a new Vector3 with the same data as "vec" but with the coordinate "c" changed to "value".
      
      - "float A<Vector2>.Max()": Returns the highest coordinate value of the Vector2.
      - "float A<Vector3>.Max()": Returns the highest coordinate value of the Vector3.
      - "float A<Vector2>.Min()": Returns the lowest coordinate value of the Vector2.
      - "float A<Vector3>.Min()": Returns the lowest coordinate value of the Vector3.
- <b>Quaternion Extensions (A):</b>
      
      - "Vector2 A.Angle(AuxCoord co, float offset)": Returns a Vector2 with the angle of a particular coordinate plus an offset.
      - "Vector2 A.Angle(string co, float offset)": Returns a Vector2 with the angle of a particular coordinate plus an offset (this string must be a valid coordinate {x, y, z}, or else it returns Vector2.zero).
- <b>GameObject Extensions (A):</b>

      - "GameObject A.Duplicate(bool isSibling)": Creates a Duplicate of the GameObject and returns it, either as a son (isSibling false) or as a later sibling (isSibling true).
      
      - "List<T> A.GetRecursive<T>(int depth)": Returns a list of GameObjects or a specific MonoBehaviour (if they have it) linked to the GameObject via the script "Complement" (Complement.cs) recursively, Depth determining the level of depth of the variables that will be taken.
      - "List<T> A.GetRecursive<T>(bool isIncluded, depth)": Returns a list of GameObjects or a specific MonoBehaviour (if they have it) linked to the GameObject via the script "Complement" (Complement.cs) recursively, with isIncluded determining if true whether a particular GameObject should be included or not if its value in its Complement.IsIncluded is true or not, and Depth determining the level of depth of the variables that will be taken.
      
      - "void A.Set(Material material)": Changes the material of the GameObject, if it's possible, to "material".
      - "void A.Set(Color color)": Changes the material of the GameObject, if it's possible, to "color".
- <b>Transform Extensions (A):</b>

      - "void A.Add(Transform go2)": Adds the local position, rotation and scale of the Transform go2 to go1.
      - "Transform A.Duplicate(bool isSibling)": Creates a Duplicate of the Transform and returns it, either as a son (isSibling false) or as a later sibling (isSibling true).
      - "void A.Reset()": Resets the Transform's local position, rotation and scale.
      - "void A.Set(Transform go2)": Sets the local position, rotation and scale of the Transform go2 to go1.
      
      - "List<T> A.GetRecursive<T>(int depth)": Returns a list of GameObjects or a specific MonoBehaviour (if they have it) linked to the GameObject via the script "Complement" (Complement.cs) recursively, Depth determining the level of depth of the variables that will be taken.
      - "List<T> A.GetRecursive<T>(bool isIncluded, depth)": Returns a list of GameObjects or a specific MonoBehaviour (if they have it) linked to the GameObject via the script "Complement" (Complement.cs) recursively, with isIncluded determining if true whether a particular GameObject should be included or not if its value in its Complement.IsIncluded is true or not, and Depth determining the level of depth of the variables that will be taken.
- <b>MonoBehaviour Extensions (A):</b>
      
      - "T A.Duplicate(bool isSibling)": Creates a Duplicate of the MonoBehaviour and returns it, either as a son (isSibling false) or as a later sibling (isSibling true).
      
      - "List<T> A.GetRecursive<T>(int depth)": Returns a list of GameObjects or a specific MonoBehaviour (if they have it) linked to the GameObject via the script "Complement" (Complement.cs) recursively, Depth determining the level of depth of the variables that will be taken.
      - "List<T> A.GetRecursive<T>(bool isIncluded, depth)": Returns a list of GameObjects or a specific MonoBehaviour (if they have it) linked to the GameObject via the script "Complement" (Complement.cs) recursively, with isIncluded determining if true whether a particular GameObject should be included or not if its value in its Complement.IsIncluded is true or not, and Depth determining the level of depth of the variables that will be taken.

# Auxf.cs (Auxiliar Functions):
blabla

# AuxGameObject.cs (Auxiliar GameObject):
blablabla

# Auxi.cs (Auxiliar Input):
blablabla

# Auxp.cs (Auxiliar Polygons):
blablabla

# Complement.cs:
blablabla

# Mover.cs:
