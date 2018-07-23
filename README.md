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
This file contains a few main functions to facilitate certain operations in C#. It's composed of the following classes:
- <b>"Auxf":</b> This class is a singleton (called by the attribute "i") that calls generic functions. Quite a few of the functions are thought to be used as delegates:

      - "bool Auxf.i.IsNotNull<T>(T e) where T : class": Returns whether the class is null.
      - "bool Auxf.i.GreaterThan<T>(T v1, T v2) where T: IComparable": Returns whether v1 is greater by being compared than v2.
      - "bool Auxf.i.GreaterEqualThan<T>(T v1, T v2) where T: IComparable": Returns whether v1 is greater or equal by being compared than v2.
      - "bool Auxf.i.LessThan<T>(T v1, T v2) where T: IComparable": Returns whether v1 is less by being compared than v2.
      - "bool Auxf.i.LessEqualThan<T>(T v1, T v2) where T: IComparable": Returns whether v1 is less or equal by being compared than v2.
      - "bool Auxf.i.Disequals<T>(T v1, T v2)": Returns whether v1 is not equal to v2.
      
      - "AuxPolygon IntersectionTwoLines(RectTransform a, RectTrasform b, AuxCoord co)": Returns an AuxPolygon with the point positions of the intersection of the RectTransform in a 0Z plane (ignoring Z coordinate) and using the X or Y coordinate of the objects as the main line/angle.
- <b>"Auxf.SML":</b> This class is a singleton (called by the attribute "i") that calls SML-related functions. SML (Separator Markup Language) is a type of language to write in text files for a type of operations to be parsed.
The structure is:

      Important: Characters '[', ']' and '*' are not part of the name.
                 []* represents it can be repeated from "(0,...)".

      [method_title {
          [word(sub[,sub]*)]*;
      }]*
     
      i.e.:
      a_title {
          element_1 element_2(attr_1,attr_2) element_3;
          element_a(attr_a) element_b;
      }
With this structure, the function works by modifying strings. The functions are the following:

      - "string Auxf.SML.i.GetMethod(string text, string identifier)": Returns the content of a method's name inside the text (brackets and spaces not included).
      - "string[] Auxf.SML.i.SplitLines(string method)": Given a method, separate by lineSeparator (';') each line inside method.
      - "string[] Auxf.SML.i.SplitWords(string line)": Given a line, separate by wordSeparator (' ') each word inside the line. ' ' spaces are no allowed inbetween each word.
      - "string[] Auxf.SML.i.SplitParts(string word)": Given a word, if the word has two parts, returns a string of size 2 with the name and the content in the parenthesis (the parenthesis are excluded from the string already).
      - "string[] Auxf.SML.i.SplitSubs(string part)": Given a parenthesis part, separate by subSeparator (',') the diferent subcode of this part.
      
      - "bool Auxf.SML.i.FormatParts(string word)": Given a word, returns whether it fulfills the "parts" format (name and parenthesis).
      - "bool Auxf.SML.i.FormatName(string word, string name)": Given a word, returns whether it fulfills the "parts" format (name and parenthesis) and it has a particular name.
      - "bool Auxf.SML.i.FormatSubs(string word, params char[] names)": Given a word, returns whether the subs inside the parenthesis code include, at least, one of the chars.
      - "bool Auxf.SML.i.FormatSubs(string word, IEnumerable<char> names)": Given a word, returns whether the subs inside the parenthesis code include, at least, one of the chars.
      - "bool Auxf.SML.i.FormatParts(string word)": Given a word, returns whether it fulfills the "parts" format (name and parenthesis).
      
      - "Dictionary<char, float> Auxf.SML.i.Dictionary(string parameters, string keywords)": Given a sub with this format ([<number><char>]*), it turns the sub into a dictionary where the key it's the char (only valid inside those inside the "keywords" list) and the value is the number.
      - "string Auxf.SML.i.SubsToWords(string word, string keywords, SMLStringDelegate SMLFunction)": Given a word with each sub in this format ([<number><char>]*), it separates each sub into a word where each one's value is calculated with the previous sub marked according to the SMLFunction (variable).

# AuxGameObject.cs (Auxiliar GameObject):
This file contains a few main functions that affect and are only usable by a GameObject that inherits from MonoBehaviour. This means we need to define two different classes:
- <b>"Auxg":</b> Class that allows to call automatically the GameObject in the same way a singleton would call it ("i"). In that case, however, it automatically searches the first time if a GameObject with the AuxGameObject and the tag "Auxg" exists.
- <b>"Auxg.Spawner":</b> This class creates instances of a GameObject Spawner. When it's constructed or set, you can set the different parameters that modify aspects of the gameObject when it's finally instantiated (its parent, position, rotation, scale or material), and when it's ready, the Instantiate function is called, applying all of them. Its main function is (A):

      - "GameObject A.Instantiate()": Returns a new GameObject instantiated from the object given, and with all the changes applied.
- <b>"AuxgStatic":</b> This static class allows to extend some new classes with useful methods. The main extension it does is for IEnumerable<Auxg.Spawner> (A):

      - "GameObjectDelegate[] A.Instantiate()": Returns the Instantiate delegate of each Spawner object.
- <b>"AuxGameObject":</b> This is a GameObject script that allows to do a bunch of GameObject-related operations that need "MonoBehaviour" inherited. It needs to be inserted in a GameObject with the tag "Auxg" so it can be called with "Auxg.i" and access these functions:

      - "List<SMaterial> Auxg.i.quickMaterial": This attribute allows to define in the GameObject a struct of material of easy access, by putting their code, their short code and the material.
      - "List<SIndividual> Auxg.i.quickAccess": This attribute allows to define in the GameObject a struct of gameobjects of easy access, by putting their name and the GameObject.
      
      - "Material Auxg.i.GetMaterial(string name)": Returns the material with a particular name or short code that was filled in the QuickMaterial list.
      - "GameObject Auxg.i.GetObject(string name)": Returns the GameObject with a particular name that was filled in the QuickAccess list.
      - "T Auxg.i.GetObject<T>(string name) where T : MonoBehaviour": Returns the MonoBehaviour of a GameObject with a particular name that was filled in the QuickAccess list.
      
      - "Object Auxg.i.o_UITriangle": Object defined in "Awake" loading a prefab ("Prefabs/UITriangle"). It allows to create triangles for meshes, and it's used in CreateUIMesh.
      
      - "GameObject Auxg.i.CreateUIMesh(string name, AuxMesh vertices2D, Transform parent, Material material, Material negMaterial)": Returns an empty GameObject full of UITriangles that replicate an AuxMesh (Auxiliar Mesh), with the particular material to see and the negative Material to negate the other material.
      
      - "GameObject Auxg.i.Duplicate(GameObject go, bool isSibling)": Creates a Duplicate of the GameObject and returns it, either as a son (isSibling false) or as a later sibling (isSibling true).
      - "Transform Auxg.i.Duplicate(Transform go, bool isSibling)": Creates a Duplicate of the GameObject and returns it, either as a son (isSibling false) or as a later sibling (isSibling true).
      - "T Auxg.i.Duplicate<T>(t go, bool isSibling) where T : MonoBehaviour": Creates a Duplicate of the GameObject and returns it, either as a son (isSibling false) or as a later sibling (isSibling true).
      
      - "void Auxg.i.Set(GameObject go, Material material): Changes the material of the GameObject, if it's possible, to "material".
      - "void Auxg.i.Set(GameObject go, Color color)": Changes the material of the GameObject, if it's possible, to "color".
      
      - "void Delay<...>(VoidDelegate<...> function, <...> arg{...}, float time)": For a delegate (up to 4 input arguments), it executes that function a particular time later. The "time" value is in seconds. If the value is too small, it executes it the next frame. The arguments of the function must be pust after the Delegate and before the time.
      - "void Delay<T,...>(TDelegate<T,...> function, <...> ..., float time): For a delegate (up to 4 input arguments), it executes that function a particular time later. The "time" value is in seconds. If the value is too small, it executes it the next frame. The arguments of the function must be pust after the Delegate and before the time.
      - "void ExecuteUntilFalse(TDelegate<bool> function, float time)": For a bool delegate with no input arguments, it executes that function until the result is "false". The "time" value shows the frequency by which the function is recalled. If the value is too small, it executes it the next frame.
      - "void DelayUntilFalse<T>(TDelegate<T> function, TDelegate<bool> wait, float time)": For a delegate and bool delegate with no input arguments, it executes the "wait" function until the result is "false". When that happens, it executes the "function". The "time" value shows the frequency by which the function is recalled. If the value is too small, it executes it the next frame.
      - "void DelayUntilFalse(VoidDelegate function, TDelegate<bool> wait, float time)": For a delegate and bool delegate with no input arguments, it executes the "wait" function until the result is "false". When that happens, it executes the "function". The "time" value shows the frequency by which the function is recalled. If the value is too small, it executes it the next frame.
      
      - "GameObject InstantiateEmpty(string name, Transform parent, bool isFirstSibling)": Returns a new empty GameObject with a new name from a parent. It can be the last or first sibling depending of "isFirstSibling".
      - "GameObject InstantiateObject(Object obj, Transform parent, Material material)": Returns a GameObject from a particular Object with a particular parent and material.
      - "GameObject InstantiateObject(Object obj, Transform parent, Vector3 position, Quaternion rotation, Vector3 scale, Material material)": Returns a GameObject from a particular Object with a particular parent, position, rotation, scale and material.

# Auxi.cs (Auxiliar Input):
This file contains a MonoBehaviour class and class functions to structure and expand input operations in Unity C#. The classes are:
- <b>"Auxi : MonoBehaviour":</b> GameObject script that allows to configure a bunch of keys for a particular name instead of for separate with the struct "KeyPar". You configure this from the Unity Editor, and it's needed that this class has the tag "TAuxi" to work (i.e. you can create the string "Down" associated to the keys "downArrow", "S", "Numpad2", "JoystickDown", etc.).
- <b>"AuxInput":</b> It allows to call generic Key functions with a string defined in the Auxi class. This is a singleton function (called with "i"). When this function is called, it searches inmediately for the GameObject that has the TAuxi tag, and take its Auxi script, so there should be one defined. The current functions implemented are:ç

      - "bool AuxInput.i.GetKeyDown(string list)": Returns whether a particular string (and therefore, any KeyCode associated with it) has been pressed down.
      - "bool AuxInput.i.GetKey(string list)": Returns whether a particular string (and therefore, any KeyCode associated with it) is being pressed.
      - "bool AuxInput.i.GetKeyUp(string list)": Returns whether a particular string (and therefore, any KeyCode associated with it) has been pressed up.

# Auxp.cs (Auxiliar Polygons):
This file contains a lot of class to do 2D geometric operations with Lines, Segments, Wide Lines, Polygons and Meshes. Therefore, it has a lot of classes and operations:
- <b>"Auxp"</b>: This is a singleton function ("i") that allows to call normal methods and properties from the upcoming classes as functions with input parameters. This will allow to use them for Delegate functions with arguments. This part won't be commented in detail since their details will go in the other classes. However, a few translation of operations:
  - "Dot(A, B)": "A * B"
  - "Substract(A, B)": "A - B"
- <b>"AuxpStatic":</b> This class applies extensions to Auxp classes that aren't the particular classes to be more comfortable to use them:
  - List[AuxSegment] Extensions (A):

        - "AuxSegment A.Connection(AuxSegment seg, Vector2 extreme)": Given a list of segments connected, a segment included in them and an extreme, it gives the other connected segment.
        - "AuxSegment A.Next(Vector2 extreme)": Given a list of segments connected, it gives the segment that start with that extreme.
        - "List<Vector2> A.Points()": Given a list of segments, it gives the list of points that compose it, eliminating repeats.
  - List[AuxMesh] Extensions (A):
  
        - "AuxMesh A.Combine()": Given a list of meshes, it combines into one their polygons, but the positive and the negative ones.
- <b>"struct AuxTriangle":</b> This struct gets the form of a Triangle, composed of 3 points, and a few operations to facilitate their use. These are used to triangulate polygons and meshes. Its functions are (A):

      - "bool A.IsInside (Vector3 P)": Returns whether the point is inside the triangle.
      - "bool A.IsExtreme (Vector3 P)": Returns whether the point is one of the extremes of the triangle.
      - "bool A.Equals (AuxTriangle t1)": Returns whether the triangle is equivalent to the other. The order doesn't matter.
- <b>"struct AuxLine":</b> This struct simulates the form of a Line with only a position and direction in a 2D environment (ignoring Z). This Line is defined by two points like it's a segment, but it's only to mark the position and rotation. Its functions are (A):

      - "bool A.IsInside (Vector2 vec)": Returns whether the point is inside the line.
      - "bool A.Intersects (AuxLine def)": Returns whether those two lines intersect. Parallel lines never intersect regardless of whether they are the same.
      
      - "static Vector2 operator *(AuxLine def1, AuxLine def2)": Returns the intersection point between two lines, as long as they intersect.
- <b>"struct AuxSegment":</b> This struct simulates the form of a Segment between two positions in a 2D environment (ignoring Z). While the form is similar to AuxLine, the limit is only in those extremes, so their functions work differently. Its functions are (A):

      - "static List<AuxSegment> AuxSegment.Pair (List<Vector2> points)": Given a list of points (size multiple of 2), it returns a list of AuxSegments each composed by each par.
      
      - "bool A.IsNaN ()": Function: Returns whether a point of the segment is NaN.
      - "bool A.Equals (AuxSegment seg)":  Returns whether the segments are similar. Being both NaN is included, and their extremes on the other side.
      
      - "bool A.IsInside (Vector2 vec)": Returns whether the point is inside the line.
      - "bool A.IsInside (Vector2 vec, bool exclude)": Returns whether the point is inside the segment excluding one extreme.
      - "bool A.IsInside (AuxSegment vec, bool spin)": Returns whether the input segment is inside the main segment. If "spin" is true, then it checks whether the main segment is inside the input segment.
      
      - "bool A.IsExtreme (Vector2 vec)": Returns whether the point is one extreme.
      - "bool A.IsExtreme (Vector2 vec, bool exclude)": Returns whether the point is one extreme, excluding one of them. If "exclude" is "false", the extreme excluded is the first one. If "true", it's the second one.
      
      - "bool A.Nearest (Vector2 vec)": Returns the nearest extreme to the input point.
      - "bool A.Nearest (Vector2 vec, Vector2 other)": Returns the nearest extreme to the input point in comparison with the other. This means, if the first point is closer to one extreme than the other, it takes that extreme, with preference to the start extreme.
      - "bool A.Nearest (AuxSegment vec, bool spin)": Returns the nearest extreme of the main segment to the input segment. If "spin" is true, then it returns the nearest extreme of the input segment to the main segment.
      
      - "bool A.Further (Vector2 vec)": Returns the further extreme to the input point.
      - "bool A.Further (Vector2 vec, Vector2 other)": Returns the further extreme to the input point in comparison with the other. This means, if the first point is further to one extreme than the other, it takes that extreme, with preference to the start extreme.
      - "bool A.Further (AuxSegment vec, bool spin)": Returns the further extreme of the main segment to the input segment. If "spin" is true, then it returns the further extreme of the input segment to the main segment.
      
      - "float A.Distance (Vector2 vec)": Returns the minimal distance between a point and the segment.
      - "float A.SqrDistance (Vector2 vec)": Returns the minimal square distance between a point and the segment.
      
      - "bool A.Intersects (AuxLine def)": Returns whether the segment and a line intersect. Parallels never intersect.
      - "bool A.Intersects (AuxSegment def)": Returns whether two segments intersect. Parallels never intersect.
      
      - "override string A.ToString ()": Returns a string with the data of the extreme points that define the segment.
      
      - "static Vector2 operator *(AuxSegment def1, AuxLine def2)" (& opposite): Returns the intersection point between a segment and a line, as long as they intersect. Otherwise, it returns Vector2.negativeInfinity.
      - "static Vector2 operator *(AuxSegment def1, AuxSegment def2)": Returns the intersection point between two segments, as long as they intersect. Otherwise, it returns Vector2.negativeInfinity.
      
      - "static List<AuxSegment> operator -(AuxSegment def1, Vector2 def2)": Returns a list with two segments if the vector is inside the segment (aside of the extremes). Otherwise, it returns a list with only one.
      - "static List<AuxSegment> operator -(AuxSegment def1, AuxLine def2)": Returns a list with two segments if the line intersects with the segment (aside of the extremes). Otherwise, it returns a list with only one.
      - "static List<AuxSegment> operator -(AuxSegment def1, AuxSegment def2)": Returns a list with two segments if the two segments intersect (aside of the extremes). In case the first segment is inside the second, it returns "null". In case the second segment is included in the first, it may return one or two depending of whether it cuts a extreme or not. If they don't intersect, it returns a list with only one.
      - "static List<AuxSegment> operator -(AuxSegment def1, List<AuxSegment> def2)": Returns a list of segments cut by the list in def2.
      
      - "static AuxSegment operator /(AuxSegment def1, Vector2 def2)": Returns the largest segment out of the list substracted.
      - "static AuxSegment operator /(AuxSegment def1, AuxLine def2)": Returns the largest segment out of the list substracted.
      - "static AuxSegment operator /(AuxSegment def1, AuxSegment def2)": Returns the largest segment out of the list substracted.
      
      - "static AuxSegment operator %(AuxSegment def1, Vector2 def2)": Returns the smallest segment out of the list substracted.
      - "static AuxSegment operator %(AuxSegment def1, AuxLine def2)": Returns the largest segment out of the list substracted.
      - "static AuxSegment operator %(AuxSegment def1, AuxSegment def2)": Returns the smallest segment out of the list substracted.
- <b>"struct AuxWideLine":</b> This struct simulates the form of a Line wit a position, direction in a 2D environment (ignoring Z) and a width. This Line is defined by two points like it's a segment, but it's only to mark the position and rotation; plus the size. Its functions are (A):
      
      - "bool A.Equals (AuxWideLine def)": Returns whether the wide lines are similar (position, rotation and width)
      
      - "bool A.IsInside (Vector2 vec)": Returns whether the point is inside the wide line.
      - "bool A.IsInside (AuxSegment seg)": Returns whether the segment is inside the wide line.
      
      - "bool A.Intersects (AuxLine def)": Returns whether the wide line and a line intersect. Parallels never intersect.
      - "bool A.Intersects (AuxSegment def)": Returns whether the wide line and a segment intersect. Being inside also counts.
      - "bool A.Intersects (AuxWideLine def)": Returns whether two wide lines intersect. Parallels never intersect.
      
      - "static AuxSegment operator *(AuxWideLine def1, AuxLine def2)" (& opposite): Returns the intersection segment between a wide line and a line, as long as they intersect. Otherwise, it returns AuxSegment.NaN.
      - "static AuxSegment operator *(AuxWideLine def1, AuxSegment def2)" (& opposite): Returns the intersection segment between a wide line and a segment, as long as they intersect. Otherwise, it returns AuxSegment.NaN.
      - "static AuxSegment operator *(AuxWideLine def1, AuxWideLine def2)": Returns the intersection polygon between two wide lines, as long as they intersect. Otherwise, it returns null.
      
      - "static List<AuxSegment> operator -(AuxSegment def2, AuxWideLine def1)": Returns a list with one or two segments depending of the wide line position when substracting. If the segment doesn't intersects, if returns itself in a list. If it's inside the wide line, it returns null.
      - "static AuxSegment operator /(AuxSegment def1, AuxWideLine def2)": Returns the largest segment out of the list substracted.
      - "static AuxSegment operator %(AuxSegment def1, AuxWideLine def2)": Returns the smallest segment out of the list substracted.
- <b>"AuxPolygon":</b> This class simulates a polygon, without any hole inside. It is defined by a list of points that are each one connected to the previous and next one, and the last with the first one (minimum 3). Its functions are (A):
   
      - "float A.Area": Returns the area of the polygon in units ^ 2.
      - "List<AuxTriangle> A.Triangulate": Returns a list of triangles that compose the polygon's form and their particular size.
      - "static AuxPolygon AuxPolygon.Everything": Returns a polygon that contains everything in the space, like a plane.
      - "static AuxPolygon AuxPolygon.RegularPolygon (float size, int faces, Vector2 offset)": Returns a regular polygon with a specific number of faces with the same distance to the center point to a certain distance (size). The center offset can be moved too.
      
      - "bool A.IndexOfBeg (AuxSegment seg)": Returns the index of the beginning point of a segment inside the polygon.
      - "bool A.IndexOfEnd (AuxSegment seg)": Returns the index of the end point of a segment inside the polygon.
      
      - "bool A.IsInside (Vector2 vec)": Returns whether the point is inside the polygon.
      - "bool A.IsInside (AuxSegment def)": Returns whether the segment is inside the polygon.
      - "bool A.IsInside (AuxPolygon def, bool spin)": Returns whether the input polygon is inside the main polygon. If "spin" is true, then it checks whether the main polygon is inside the input polygon.
      
      - "bool A.Intersects (AuxLine def)": Returns whether the polygon and a line intersect.
      - "bool A.Intersects (AuxSegment def)": Returns whether the polygon and a segment intersect.
      - "bool A.Intersects (AuxWideLine def)": Returns whether the polygon and a wide line intersect.
      - "bool A.Intersects (AuxPolygon def)": Returns whether two polygons intersect.
      
      - "static List<AuxSegment> operator *(AuxPolygon pol, AuxLine def)" (& opposite): Returns the intersection segment list between a polygon and a line, as long as they intersect. This will correctly create a list of segments depending of the form of the polygon. Otherwise, it returns null.
      - "static List<AuxSegment> operator *(AuxPolygon pol, AuxSegment def)" (& opposite): Returns the intersection segment list between a polygon and a segment, as long as they intersect. This will correctly create a list of segments depending of the form of the polygon and the segment's length. Otherwise, it returns null.
      - "static AuxMesh operator *(AuxPolygon pol, AuxWideLine def)" (& opposite): Returns the intersection mesh between a polygon and a wide line, as long as they intersect. This will correctly create a mesh with different polygons depending of the form of the polygon and the wide line. Otherwise, it returns null.
      - "static AuxMesh operator *(AuxPolygon pol, AuxPolygon def)": Returns the intersection mesh between two polygons, as long as they intersect. This will correctly create a mesh with different polygons depending of the form of the polygons to intersect. Otherwise, it returns null.

      - "static AuxMesh operator +(AuxPolygon pol, AuxPolygon def)": Returns a mesh by combining two polygons. If one is inside the other, the result is the largest one. If they don't intersect, the result is a mesh with both polygons. If they intersect, it will create one unique polygon. If there are empty holes, those will be inserted as negatives.
      - "static AuxMesh operator -(AuxPolygon pol, AuxLine def)": Returns a mesh with the parts substracted by the line separated and added.   
      - "static AuxMesh operator -(AuxPolygon pol, AuxSegment def)": Returns a mesh with the parts substracted by the segment separated and added. The segment must cut the entirety of a polygon's part to separate it into two or more parts.
      - "static List<AuxSegment> operator -(AuxSegment def, AuxPolygon def)": Returns a list of segments with the parts inside the polygon substracted. If the segment is inside the polygon, it returns null. 
      - "static AuxMesh operator -(AuxPolygon pol, AuxWideLine def)": Returns a mesh with the parts substracted by the wide line cut. This wide line can eliminate the whole polygon, or at the very least separate big chunks of it and delete area.
      - "static AuxMesh operator -(AuxPolygon pol, AuxPolygon def)": Returns a mesh with the parts substracted by other polygon. If they don't intersect, the Mesh will only have the whole polygon. If the polygon to be cut is inside the substracter, it returns null. If the substracter is inside the polygon, it is inserted as a negative polygon in the mesh.
      
      - "static AuxPolygon operator /(AuxPolygon pol, AuxLine def)": Returns the biggest polygon out of the list substracted.
      - "static AuxPolygon operator /(AuxPolygon pol, AuxSegment def)": Returns the biggest polygon out of the list substracted.
      - "static AuxSegment operator /(AuxSegment def, AuxPolygon def)": Returns the largest segment out of the list substracted.
      - "static AuxPolygon operator /(AuxPolygon pol, AuxWideLine def)": Returns the biggest polygon out of the list substracted.
      - "static AuxPolygon operator /(AuxPolygon pol, AuxPolygon def)": Returns the biggest polygon out of the list substracted.
      
      - "static AuxPolygon operator %(AuxPolygon pol, AuxLine def)": Returns the smallest polygon out of the list substracted.
      - "static AuxPolygon operator %(AuxPolygon pol, AuxSegment def)": Returns the smallest polygon out of the list substracted.
      - "static AuxSegment operator %(AuxSegment def, AuxPolygon def)": Returns the smallest segment out of the list substracted.
      - "static AuxPolygon operator %(AuxPolygon pol, AuxWideLine def)": Returns the smallest polygon out of the list substracted.
      - "static AuxPolygon operator %(AuxPolygon pol, AuxPolygon def)": Returns the smallest polygon out of the list substracted.
- <b>"AuxMesh":</b> This class simulates a set of polygons that together create a complex mesh to be modified and reproduded. It is defined by a list of polygons that by definition should be separated, otherwise they are combined. At least one is needed. This class also prepares holes in polygons of the meshes, which are saved in an inner AuxMesh called "Negatives". These Negative parts will be considered as holes and will be kept in mind in all the operations and restructuring of the mesh's form. These parts can also have their own filled content again recursively in their Negatives. Its functions are (A):
      
      - "float Area": Returns the area of the mesh in units ^ 2, as the summation of all the polygons and substracting the summation of the negatives.
      - "List<List<AuxTriangle>> Triangulate": Returns a list composed of two list of triangles: The first one contains the triangles of all the visible polygons, including the parts that should be invisible by negatives. The second one contains the triangles of all the negative polygons, so when creating the mesh they can hide the visible ones.
      - "float Inverse": Returns the inverse of the Mesh, with the whole content being visible except the parts of the mesh.
      - "static implicit operator AuxMesh (AuxPolygon ap)": Turns a polygon into a mesh with only that polygon inserted.
      
      - "AuxMesh Clone ()": Returns a copy of the mesh.
      
      - "bool IsInside (Vector2 vec)": Returns whether the point is inside the mesh. Negative parts are taken in mind.
      - "bool IsInside (AuxSegment def)": Returns whether the segment is inside the mesh. Negative parts are taken in mind.
      - "bool IsInside (AuxPolygon def)": Returns whether polygon is inside the mesh. Negative parts are taken in mind.
      - "bool IsInside (AuxMesh def)": Returns whether the input mesh is inside the main mesh. If "spin" is true, then it checks whether the main mesh is inside the input mesh. Negative parts are taken in mind.
      
      - "bool Intersects (AuxLine def)": Returns whether the mesh and a line intersect.
      - "bool Intersects (AuxSegment def)": Returns whether the mesh and a segment intersect.
      - "bool Intersects (AuxWideLine def)": Returns whether the mesh and a wide line intersect.
      - "bool Intersects (AuxPolygon def)": Returns whether the mesh and a polygon intersect.
      - "bool Intersects (AuxMesh def)": Returns whether two meshes intersect.
      
      - "static List<AuxSegment> operator *(AuxMesh pol, AuxLine def)" (& opposite): Returns the intersection segment list between a mesh and a line, as long as they intersect. This will correctly create a list of segments depending of the form of the mesh. The negative parts are also kept in mind. Otherwise, it returns null.
      - "static List<AuxSegment> operator *(AuxMesh pol, AuxSegment def)" (& opposite): Returns the intersection segment list between a mesh and a segment, as long as they intersect. This will correctly create a list of segments depending of the form of the mesh and the segment's length. The negative parts are also kept in mind. Otherwise, it returns null.
      - "static AuxMesh operator *(AuxMesh pol, AuxWideLine def)" (& opposite): Returns the intersection mesh between a mesh and a wide line, as long as they intersect. This will correctly create a mesh with different polygons depending of the form of the mesh and the wide line. The negative parts are also kept in mind. Otherwise, it returns null.
      - "static AuxMesh operator *(AuxMesh pol, AuxPolygon def)" (& opposite): Returns the intersection mesh between a mesh and a polygon, as long as they intersect. This will correctly create a mesh with different polygons depending of the form of the mesh and the polygon to intersect. The negative parts are also kept in mind. Otherwise, it returns null.
      - "static AuxMesh operator *(AuxMesh pol, AuxMesh def)": Returns the intersection mesh between two meshes, as long as they intersect. This will correctly create a mesh with different polygons depending of the form of the meshes to intersect. The negative parts are also kept in mind. Otherwise, it returns null.
      
      - "static AuxMesh operator +(AuxMesh pol, AuxPolygon def)" (& opposite): Returns a mesh by combining a mesh and a polygon. If one is inside the other, the result is the largest one. If they don't intersect, the result is a mesh with both polygons. If they intersect, it will create one unique polygon. If there are empty holes, those will be inserted as negatives. The Polygon section will be substracted from the negatives parts inside.
      - "static AuxMesh operator +(AuxMesh pol, AuxMesh def) ": Returns a mesh by combining two meshes. If one is inside the other, the result is the largest one. If they don't intersect, the result is a mesh with both polygons. If they intersect, it will create one unique polygon. If there are empty holes, those will be inserted as negatives.
      
      - "static AuxMesh operator -(AuxMesh pol, AuxLine def)": Returns a mesh with the parts substracted by the line separated and added. The Negative parts are also kept in mind.
      - "static AuxMesh operator -(AuxMesh pol, AuxSegment def)": Returns a mesh with the parts substracted by the segment separated and added. The segment must cut the entirety of a polygon's part to separate it into two or more parts. The Negative parts are also kept in mind.
      - "static List<AuxSegment> operator -(AuxSegment def, AuxMesh def)": Returns a list of segments with the parts inside the mesh substracted. If the segment is inside the polygon, it returns null. The Negative parts are also kept in mind.
      - "static AuxMesh operator -(AuxMesh pol, AuxWideLine def)": Returns a mesh with the parts substracted by the wide line cut.  This wide line can eliminate the whole mesh, or at the very least separate big chunks of it and delete area. The Negative parts are also kept in mind.
      - "static AuxMesh operator -(AuxMesh pol, AuxPolygon def)": Returns a mesh with the parts substracted by other polygon. If they don't intersect (inside negatives included), the Mesh will only have the whole previous mesh. If the mesh to be cut is inside the substracter, it returns null. If the substracter is inside the mesh (not negatives), it is inserted as a negative polygon in the mesh. The Negative parts are also kept in mind.
      - "static AuxMesh operator -(AuxMesh pol, AuxMesh def)": Returns a mesh with the parts substracted by other mesh. If they don't intersect (inside negatives included), the Mesh will only have the whole previous mesh. If the mesh to be cut is inside the substracter, it returns null. If the substracter is inside the mesh (not negatives), it is inserted as a negative (and the negatives parts the opposite). The Negative parts are also kept in mind.
      
      - "static AuxPolygon operator /(AuxMesh pol, AuxLine def)": Returns the biggest polygon out of the list substracted.
      - "static AuxPolygon operator /(AuxMesh pol, AuxSegment def)": Returns the biggest polygon out of the list substracted.
      - "static AuxSegment operator /(AuxSegment def, AuxMesh def)": Returns the largest segment out of the list substracted.
      - "static AuxPolygon operator /(AuxMesh pol, AuxWideLine def)": Returns the biggest polygon out of the list substracted.
      - "static AuxPolygon operator /(AuxMesh pol, AuxPolygon def)": Returns the biggest polygon out of the list substracted.
      - "static AuxPolygon operator /(AuxMesh pol, AuxMesh def)": Returns the biggest polygon out of the list substracted.
      
      - "static AuxPolygon operator %(AuxMesh pol, AuxLine def)": Returns the smallest polygon out of the list substracted.
      - "static AuxPolygon operator %(AuxMesh pol, AuxSegment def)": Returns the smallest polygon out of the list substracted.
      - "static AuxSegment operator %(AuxSegment def, AuxMesh def)": Returns the smallest segment out of the list substracted.
      - "static AuxPolygon operator %(AuxMesh pol, AuxWideLine def)": Returns the smallest polygon out of the list substracted.
      - "static AuxPolygon operator %(AuxMesh pol, AuxPolygon def)": Returns the smallest polygon out of the list substracted.
      - "static AuxPolygon operator %(AuxMesh pol, AuxMesh def)": Returns the smallest polygon out of the list substracted.

# Complement.cs:
This file creates a MonoBehaviour to insert in a GameObject in Unity C#, so the functions from AuxeUnity GetRecursive work correctly. This class allows to:
- Link the GameObject with others, so when the GetRecursive function is called, it will automatically go for them. This is using the "List<GameObject> complement" attribute.
- Check if, in functions where the GameObject to be considered in GetRecursive, if that GameObject should be included or not. This is using the "bool include" attribute. 
- POSSIBLE ERROR: If a GameObject calls itself, or two GameObjects call themselves recursively, it will generate an endless loop irrecoverable.

# Mover.cs:
This file contains functions that allow to apply controlled position, rotation and scale movement for GameObjects in a controlled way. This function is composed of these classes:
- <b>"Mover":</b>
  - A "Mover" is a class that takes a name, a GameObject and different MovevementClasses that execute a certain type of movement, one after another, during a controlled amount of time.
  - The types of movement it allows are "nothing" (nt, to wait seconds), "position" (tr), "rotation" (rt), "scale" (sc) and "size" (sz).
  - It also allows local or global modification (a- => atr, art, asc, asz).
  - The structure to insert components is <b>"MovementClass"</b>, which takes the type of movement, the movement, whether it's local, incremental, and the time it takes. It has a few functions (A):
  
        - "MovementClass A.Scale(float number)": Applies a scale for the MovementClass to all the vector coordinates and returns it.
        - "MovementClass A.Scale(Vector3 number)": Applies a scale for the MovementClass with each coordinate multiplying each movement coordinate (Raw multiplication), and returns it.
        - "MovementClass A.Delay(float number)": Applies a proprtional delay for the MovementClass and returns it.
  - The classes of "Mover" are the following ones (A):
  
        - "void A.Add(MovementClass nclass)": Adds in the Mover a new MovementClass.
        - "void A.Add(float ntime)": Adds in the Mover a "nothing" MovementClass with a particular delay.
        - "void A.Add(MovType ntype, Vector3 nmovement, float ntime, bool nlocal, bool nincremental)": Adds in the Mover a new MovementClass with all their parameters separated.
        - "void A.Add(string ntype, Vector3 nmovement, float ntime)": Adds in the Mover a new MovementClass with all their parameters separated. The string type is identified in the string[] types (nt, tr, rt, sc, sz, atr, art, asc, asz). It assumes it's always local the movement.
        
        - "void A.Execute(float TM)": Executes the Mover, particulary that movement amount (which should be Time.deltaTime). Returns "false" if it ended.
        
        - "void A.Scale(float number)": Applies a scale for the mover and all its types.
        - "void A.Scale(float number, params Mover.MovType[] filter)": Applies a scale for the mover to the specific Movement Types listed.
        - "void A.Scale(Vector3 number)": Applies a scale for the mover and all its types, with a Vector3 that uses a RawMultiplication.
        - "void A.Scale(Vector3 number)": Applies a scale for the mover to the specific Movement Types listed, with a Vector3 that uses a RawMultiplication.
        
        - "void A.Delay(float number)": Applies a multiplier delay to the execution time for the mover and all its types.
        - "void A.Delay(float number, params Mover.MovType[] filter)": Applies a multiplier delay to the execution time for the mover to the specific Movement Types listed.     
- <b>"Movers : List[Mover]":</b> This class is a list of movers with a lot of components useful to manage a lot of them at the same time. Its functions are (A):
   
      - "List<string> A.Names": Returns a list of names of the GameObjects affected by the list of movers. There are no repeats.
      - "Dictionary<string, Transform> A.Dictionary": Returns a dictionary that associates the names of the GameObjects involved in it with their Transform.
      
      - "static Movers LoadSML (string text, string id, params GameObjectDelegate[] template)": From a SML text and a particular id/method, it creates a mover for a particular object. When the "cr(<number>)" name is called, it automatically instantiates the specific template given its position in the array.
      - "static Movers LoadSML (string text, string id, string dictKey, Transform dictValue, params GameObjectDelegate[] template)": From a SML text and a particular id/method, it creates a mover for a particular object. When the "cr(<number>)" name is called, it automatically instantiates the specific template given its position in the array. If a name it's put to be associated with a GameObject, it checks the dictionary of string->Transform. This function allows to initiate the Dictionary with one element without creating a dictionary for it.
      - "static Movers LoadSML (string text, string id, Dictionary<string, Transform> vars, params GameObjectDelegate[] template)": From a SML text and a particular id/method, it creates a mover for a particular object. When the "cr(<number>)" name is called, it automatically instantiates the specific template given its position in the array. If a name it's put to be associated with a GameObject, it checks the dictionary of string->Transform.
      
      - "void A.Add(string text, Transform nmoveObject)": Adds a new Mover to the list with their parameters inserted directly.
      - "bool A.Execute()": Executes a frame of each Mover, to be used in each Update (Time.deltaTime). Returns "false" if all Movers finished.
      - "Transform A.GetObject(string name)": Gets the object of a Mover whose Mover name is the same.
      
      - "static Movers operator +(Movers append1, Movers append2)": Returns a List of movers that has the movers of both.
      
      - "void A.Scale(float number)": Applies a scale for all the movers and all their types.    
      - "void A.Scale(float number, params Mover.MovType[] filter)": Applies a scale for all the movers to the specific Movement Types listed.
      - "void A.Scale(Vector3 number)": Applies a scale for all the movers and all their types, with a Vector3 that uses a RawMultiplication.
      - "void A.Scale(Vector3 number, params Mover.MovType[] filter)": Applies a scale for all the movers to the specific Movement Types listed, with a Vector3 that uses a RawMultiplication.
      
      - "void A.Delay(float number)": Applies a multiplier delay to the execution time for all the movers and all their types.
      - "void A.Delay(float number, params Mover.MovType[] filter)": Applies a multiplier delay to the execution time for all the movers to the specific Movement Types listed.
      
      - "void A.AppendString(string first, string last)": Appends to the Mover name and the GameObjects name a string before and after their previous name.
      - "Movers A.Inverse (params AuxCoord[] inverses)": Creates a duplicate of the List of movers and all their gameObjects, and then applies a scale that inverts their position for the quoted coordinates. Their names change to be "i<" + name + ">".
