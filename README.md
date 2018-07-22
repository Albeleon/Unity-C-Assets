# Unity-C-Assets
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

      - "int A.CompareTo(string firstParam, string secondParam)": .
      - "bool A.Contains(char format)": .
      - "bool A.Format(char separator, params string[] inside)": .
      - "bool A.IsEmpty()": .
      - "bool A.IsFormat(string format)": .
      - "float A.ParseOperation()": .
      - "string A.TrimExtense()": .
      
      - "string A.Cut(int characterStart, int characterEnd)": .
      - "string A.Cut(params char[] list)": .
      - "string A.Cut(IEnumerable<char> list)": .
      
      - "string A.EndNumber()": .
      - "string A.EndNumberAdd(int offset)": .
      - "string A.EndNumberReplace(int number)": .
      
      - "int[] A.IndexOf(params string[] chars)": .
      - "int A.IndexEndOf(string chars)": .
      - "int A.IndexEndOf(string chars, int startIndex)": .
      - "int[] A.IndexEndOf(params string[] chars)": .

      - "string A.Remove(params char[] chars)": .
      - "string A.Remove(IEnumerable<char> chars)": .
      - "string A.Remove(params string[] strings)": .
      - "string A.Remove(IEnumerable<string> strings)": .

      - "string[] A.Split(string openKey, string closeKey)": .
      - "string[] A.Split(string separator, string openIgnore, string closeIgnore)": .

      - "string A.Substring(string openKey)": .
      - "string A.Substring(int startIndex, string closeKey)": .
      - "string A.Substring(string openKey, string closeKey)": .
      - "string A.Substring(string openKey, string closeKey, string openIgnore, string closeIgnore)": .
      - "string A.SubstringChar(char openKey, char closeKey)": .
      - "string A.SubstringIndex(int startIndex, int endIndex)": .
- <b>IEnumerable<char> Extensions (A):</b>
  
      - "IEnumerable<string> A.ToIEnumerableString()": .
- <b>IEnumerable<string> Extensions (A):</b>
  
      - "string A.Concatenate()": .
      - "string A.Concatenate(string separator)": .
- <b>IEnumerable<int> Extensions (A):</b>
  
      - "int A.Min()": .
      - "int A.MinIndex()": .
      - "int A.Max()": .
      - "int A.MaxIndex()": .
- <b>IEnumerable<float> Extensions (A):</b>
  
      - "float A.Min()": .
      - "float A.MinIndex()": .
      - "float A.Max()": .
      - "float A.MaxIndex()": .
- <b>IEnumerable<T> Extensions (A):</b>
  
      - "bool A.Between(int counter)": .
      - "list<T1> A<T2>.ConstantClone(T1 constantValue)": .
      - "bool A.IsEmpty()": .

      - "T A.First()": .
      - "T A.First(T defaultValue)": .
      - "T A.Last()": .
      - "T A.Last(T defaultValue)": .

      - "bool A.IsAll( ... )": .
      - "bool A.IsAll( ... )": .
      - "bool A.IsAny( ... )": .
      - "bool A.IsAny( ... )": .

      - "List<T1> A<T1>.Filter( ... )": .
      - "T1 A<T1>.Get( ... )": .

      - "T1 A<T1>.Max( ... )": .
      - "T1 A<T1>.Min( ... )": .
      - "int A.MaxIndex( ... )": .
      - "int A.MinIndex( ... )": .
      - "float A.Summation( ... )": .

      - "List<T> A.Execute( ... )": .
      - "List<T> A.Execute( ... )": .
      - "void A.Execute( ... )": .
      - "void A.Execute( ... )": .
      - "List<T> A.ExecuteDoble( ... )": .
      - "void A.ExecuteDoble( ... )": .
      - "List<T> A.ExecuteDobleDistinct( ... )": .
      - "void A.ExecuteDobleDistinct( ... )": .
- <b>T[] Extensions (A):</b>

      - "bool A.Contains(T value)": .
      - "T[] A.Clone()": .
      - "T[] A.Cut(int cutStart, int cutEnd)": .
      - "T[] A.Distinct()": .
      - "T[] A.Sublist(int counter)": .
      - "List<T> A.ToList()": .

      - "T A.Get(int counter)": .
      - "T A.Get(int counter, T defValue)": .
- <b>List<T> Extensions (A):</b>
  
      - "bool A.Contains(T value)": .
      - "List<T> A.Clone()": .
      - "List<T> A.Cut(int cutStart, int cutEnd)": .
      - "List<T> A.Distinct()": .
      - "bool A.Similar(List<T> ap)": .
      - "List<T> A.Sublist(int counter)": .

      - "List<T> A.AddReturn(T value)": .
      - "List<T> A.AddReturn(List<T> value)": .

      - "T A.Get(int counter)": .
      - "T A.Get(int counter, T defValue)": .

      - "T A.Next(T value)": .
      - "T A.Next(T value, T defValue)": .
      - "T A.Previous(T value)": .
      - "T A.Previous(T defValue)": .

      - "List<T> A.RemoveReturn(T remove)": .
      - "List<T> A.RemoveAtReturn(int remove)": .
      - "List<T> A.RemoveReturn(List<T> remove)": .
      - "List<T> A.RemoveAllReturn(T value)": .

      - "void A.Set(int index, IEnumerable<T> values)": .
      - "List<T> A.SetReturn(int index, IEnumerable<T> values)": .
- <b>Dictionary<TKey, TValue> Extensions (A):</b>
  
      - "void A.Add(TValue defValue, params TKey[] keys)": .
      - "Dictionary<TKey, TValue> A.Clone()": .

      - "TValue A.Get(TKey index)": .
      - "TValue A.Get(TKey index, TValue defValue)": .
      - "List<TKey> A.GetKeys(TValue value)": .
- <b>XDocument Extensions (A):</b>

      - "XElement A.SearchByAttribute(string el, string attr, string value)": .
- <b>XElement Extensions (A):</b>

      - "Dictionary<string,string> A.Dictionary()": .
      - "XElement A.SearchByAttribute(string el, string attr, string value)": .
      
# AuxeUnity.cs (Auxiliar Extension Unity):
blalblab
- <b>Int Extensions (A):</b>

      - "float A.Deg2Rad()": .
      - "float A.Rad2Deg()": .
      
      - "Vector2 A.AngleDeg()": .
      - "Vector2 A.AngleRad()": .
- <b>Float Extensions (A):</b>

      - "float A.Deg2Rad()": .
      - "float A.Rad2Deg()": .
      - "Vector2 A.AngleDeg()": .
      - "Vector2 A.AngleRad()": .
- <b>Color Extensions (A):</b>

      - "Color A.Set(float value, AuxColor c)": .
      - "Color A.Set(float value, string c)": .
- <b>Vector2 / Vector3 Extensions (A):</b>

      - "Vector2 A.Offset(Vector2 v, float d)": .
      - "Vector3 A.Offset(Vector3 v, float d)": .
      - "Vector2 A.Perpendicular()": .
      
      - "bool A<Vector2>.IsNaN()": .
      - "bool A<Vector3>.IsNaN()": .
      
      - "float A.Cross(Vector2 v2)": .
      - "Vector3 A.Cross(Vector3 v2)": .
      - "float A.Dot(Vector2 v2)": .
      - "float A.Dot(Vector3 v2)": .
      - "Vector2 A.RawMult(Vector2 v2)": .
      - "Vector3 A.RawMult(Vector3 v2)": .
      
      - "Vector2 A.Set(float value, AuxCoord c)": .
      - "Vector2 A.Set(float value, string c)": .
      - "Vector3 A.Set(float value, AuxCoord c)": .
      - "Vector3 A.Set(float value, string c)": .
      
      - "float A<Vector2>.Max()": .
      - "float A<Vector3>.Max()": .
      - "float A<Vector2>.Min()": .
      - "float A<Vector3>.Min()": .
- <b>Quaternion Extensions (A):</b>
      
      - "Vector2 A.Angle(AuxCoord co, float offset)": .
      - "Vector2 A.Angle(string co, float offset)": .
- <b>GameObject Extensions (A):</b>

      - "GameObject A.Duplicate(bool isSibling)": .
      
      - "List<T> A.GetRecursive<T>(int depth)": .
      - "List<T> A.GetRecursive<T>(bool isIncluded, depth)": .
      
      - "void A.Set(Material material)": .
      - "void A.Set(Color color)": .
- <b>Transform Extensions (A):</b>

      - "void A.Add(Transform go2)": .
      - "Transform A.Duplicate(bool isSibling)": .
      - "void A.Reset()": .
      - "void A.Set(Transform go2)": .
      
      - "List<T> A.GetRecursive<T>(int depth)": .
      - "List<T> A.GetRecursive<T>(bool isIncluded, depth)": .
- <b>MonoBehaviour Extensions (A):</b>
      
      - "T A.Duplicate(bool isSibling)": .
      
      - "List<T> A.GetRecursive<T>(int depth)": .
      - "List<T> A.GetRecursive<T>(bool isIncluded, depth)": .

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
