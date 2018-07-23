/*
 * AuxeUnity (Auxiliar Extension Unity):
 * This file contains the main method extensions developed to facilitate functions made in Unity C#.
 * It needs the library "UnityEngine" and "System.Collections.Generic" to work, so it only works on Unity projects.
 * It also needs the other classes from the pack: "Complement.cs", "AuxGameObject.cs"
 * 
 * Developed by Alberto León Meaños, 22/07/2018, License GNU General Public License v3.0
 * */


using System.Collections.Generic;
using UnityEngine;


/*
 * Enums -> AuxCoord & AuxColor:
 * AuxCoord: Enumeration used for the coordinates of a Vector up to three dimensions (x, y and z).
 * AuxColor: Enumeration used for the values of a Color parameter in RGB format (r [red], g [green], b [blue], a [alpha]).
 * */
public enum AuxCoord { x, y, z }
public enum AuxColor { r, g, b, a }


public static class AuxeUnity
{
    /////////////////// INT EXTENSIONS /////////////////////

    /*
     * float [int number].Deg2Rad() / static float Deg2Rad(int number):
     *      Function: Returns a number in degrees (angle) to radians (angle).
     *      Usefulness: For functions that need to use radians to work yet the input data is in degrees since it tends to be more intuitive.
     *      Based on: Mathf.Deg2Rad.
     *      
     * float [int number].Rad2Deg() / static float Rad2Deg(int number):
     *      Function: Returns a number in radians (angle) to degrees (angle).
     *      Usefulness: After functions that return a radian value that need to be turned in degrees.
     *      Based on: Mathf.Rad2Deg.
     * */
    public static float Deg2Rad(this int number)
    {
        return number * Mathf.Deg2Rad;
    }
    public static float Rad2Deg(this int number)
    {
        return number * Mathf.Rad2Deg;
    }

    /*
     * Vector2 [int angle].AngleDeg() / static Vector2 AngleDeg(int angle):
     *      Function: Returns a normalized Vector2 (starting from Vector2.right) by passing a degree value.
     *      Usefulness: To quickly turn degree values in a vector/direction without having to convert it to radians.
     *      Based on: Mathf.Deg2Rad, Mathf.Sin, Mathf.Cos.
     *      
     * Vector2 [int angle].AngleRad() / static Vector2 AngleRad(int angle):
     *      Function: Returns a normalized Vector2 (starting from Vector2.right) by passing a radians value.
     *      Usefulness: To quickly turn radian values in a vector/direction.
     *      Based on: Mathf.Sin, Mathf.Cos.
     * */
    public static Vector2 AngleDeg(this int angle)
    {
        return angle.Deg2Rad().AngleRad();
    }
    public static Vector2 AngleRad(this int angle)
    {
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }


    /////////////////// FLOAT EXTENSIONS /////////////////////

    /*
     * float [float number].Deg2Rad() / static float Deg2Rad(float number):
     *      Function: Returns a number in degrees (angle) to radians (angle).
     *      Usefulness: For functions that need to use radians to work yet the input data is in degrees since it tends to be more intuitive.
     *      Based on: Mathf.Deg2Rad.
     *      
     * float [float number].Rad2Deg() / static float Rad2Deg(float number):
     *      Function: Returns a number in radians (angle) to degrees (angle).
     *      Usefulness: After functions that return a radian value that need to be turned in degrees.
     *      Based on: Mathf.Rad2Deg.
     * */
    public static float Deg2Rad(this float number)
    {
        return number * Mathf.Deg2Rad;
    }
    public static float Rad2Deg(this float number)
    {
        return number * Mathf.Rad2Deg;
    }

    /*
     * Vector2 [float angle].AngleDeg() / static Vector2 AngleDeg(float angle):
     *      Function: Returns a normalized Vector2 (starting from Vector2.right) by passing a degree value.
     *      Usefulness: To quickly turn degree values in a vector/direction without having to convert it to radians.
     *      Based on: Mathf.Deg2Rad, Mathf.Sin, Mathf.Cos.
     *      
     * Vector2 [float angle].AngleRad() / static Vector2 AngleRad(float angle):
     *      Function: Returns a normalized Vector2 (starting from Vector2.right) by passing a radians value.
     *      Usefulness: To quickly turn radian values in a vector/direction.
     *      Based on: Mathf.Sin, Mathf.Cos.
     * */
    public static Vector2 AngleDeg(this float angle)
    {
        return angle.Deg2Rad().AngleRad();
    }
    public static Vector2 AngleRad(this float angle)
    {
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }


    /////////////////// COLOR EXTENSIONS /////////////////////

    /*
     * Color [Color vec].Set(float value, AuxColor c) / static Color Set(Color vec, float value, AuxColor c):
     *      Function: Returns a new Color with the same data as "vec" but with the coordinate "c" changed to "value".
     *      Usefulness: To quickly create a new Color that only changes one aspect of another one.
     *      
     * Color [Color vec].Set(float value, string c) / static Color Set(Color vec, float value, string c):
     *      Function: Returns a new Color with the same data as "vec" but with the coordinate "c" changed to "value"
     *      (this string must be a valid coordinate {r, g, b, a}, or else it changes nothing).
     *      Usefulness: To quickly create a new Color that only changes one aspect of another one, and quickly writing the coordinate code.
     * */
    public static Color Set(this Color vec, float value, AuxColor c)
    {
        return new Color(c == AuxColor.r ? value : vec.r, c == AuxColor.g ? value : vec.g,
            c == AuxColor.b ? value : vec.b, c == AuxColor.a ? value : vec.a);
    }
    public static Color Set(this Color vec, float value, string c)
    {
        return new string[] { "r", "g", "b", "a" }.IsAny(c.Equals) ?
            Set(vec, value, c == "r" ? AuxColor.r : c == "g" ? AuxColor.g : c == "b" ? AuxColor.b : AuxColor.a)
            : new Color(vec.r, vec.g, vec.b, vec.a);
    }


    /////////////////// VECTOR2, VECTOR3 EXTENSIONS /////////////////////

    //      (Properties):
    public static readonly Vector3 inverseX = new Vector3(-1, 1, 1);
    public static readonly Vector3 inverseY = new Vector3(1, -1, 1);
    public static readonly Vector3 inverseZ = new Vector3(1, 1, -1);
    public static readonly Vector3 NaN = new Vector3(float.NaN, float.NaN, float.NaN);


    //      (Functions):

    /*
     * Vector2 [Vector2 p].Offset(Vector2 v, float d) / static Vector2 Offset(Vector2 p, Vector2 v, float d):
     *      Function: Returns a new Vector2 based on "p" with its position moved in direction "v" and magnitude "d".
     *      Usefulness: To quickly move a Vector2 from one position to other based on a direction and distance.
     *      Based on: [Vector2].normalized, [Vector2] + [Vector2].
     *      
     * Vector3 [Vector3 p].Offset(Vector3 v, float d) / static Vector3 Offset(Vector3 p, Vector3 v, float d):
     *      Function: Returns a new Vector3 based on "p" with its position moved in direction "v" and magnitude "d".
     *      Usefulness: To quickly move a Vector3 from one position to other based on a direction and distance.
     *      Based on: [Vector3].normalized, [Vector3] + [Vector3].
     * */
    public static Vector2 Offset(this Vector2 p, Vector2 v, float d)
    {
        return p + v.normalized * d;
    }
    public static Vector3 Offset(this Vector3 p, Vector3 v, float d)
    {
        return p + v.normalized * d;
    }

    /*
     * Vector2 [Vector2 v].Perpendicular() / static Vector2 Perpendicular(Vector2 v):
     *      Function: Returns a new Vector2 that is the perpendicular of the vector "v", in format (-y, x).
     *      Usefulness: To quickly have the perpendicular of a Vector2.
     * */
    public static Vector2 Perpendicular(this Vector2 v)
    {
        return new Vector2(-v.y, v.x);
    }

    private static AuxCoord p_CharToAuxCoord(string c)
    {
        return c == "x" ? AuxCoord.x : c == "y" ? AuxCoord.y : AuxCoord.z;
    }


    //      (IsNaN):

    /*
     * bool [Vector2 p].IsNaN() / static bool IsNaN(Vector2 p):
     *      Function: Returns true if any value in the Vector2 is NaN.
     *      Usefulness: To quickly check if a Vector2 is NaN.
     *      Based on: float.NaN
     *      
     * bool [Vector3 p].IsNaN() / static bool IsNaN(Vector3 p):
     *      Function: Returns true if any value in the Vector3 is NaN.
     *      Usefulness: To quickly check if a Vector3 is NaN.
     *      Based on: float.NaN
     * */
    public static bool IsNaN(this Vector2 p)
    {
        return float.IsNaN(p.x) || float.IsNaN(p.y);
    }
    public static bool IsNaN(this Vector3 p)
    {
        return float.IsNaN(p.x) || float.IsNaN(p.y) || float.IsNaN(p.z);
    }


    //      (Cross, Dot, RawMult):

    /*
     * float [Vector2 v1].Cross(Vector2 v2) / static float Cross(Vector2 v1, Vector2 v2):
     *      Function: Returns the Cross Product between the Vector2 v1 and v2 (v1 being the first) as a constant.
     *      Usefulness: To quickly make a Cross product with Vector2, which will be the z value of the result since x and y will be 0.
     *      Based on: Vector3.Cross
     *      
     * Vector3 [Vector3 v1].Cross(Vector3 v2) / static Vector3 Cross(Vector3 v1, Vector3 v2):
     *      Function: Returns the Cross Product between the Vector3 v1 and v2 (v1 being the first) as another Vector3.
     *      Usefulness: To quickly make a Cross product with Vector3.
     *      Based on: Vector3.Cross
     * */
    public static float Cross(this Vector2 v1, Vector2 v2)
    {
        return Vector3.Cross(v1, v2).z;
    }
    public static Vector3 Cross(this Vector3 v1, Vector3 v2)
    {
        return Vector3.Cross(v1, v2);
    }

    /*
     * float [Vector2 v1].Dot(Vector2 v2) / static float Dot(Vector2 v1, Vector2 v2):
     *      Function: Returns the Dot Product between the Vector2 v1 and v2.
     *      Usefulness: To quickly make a Dot product with Vector2.
     *      Based on: Vector3.Dot
     *      
     * float [Vector3 v1].Dot(Vector3 v2) / static float Dot(Vector3 v1, Vector3 v2):
     *      Function: Returns the Dot Product between the Vector3 v1 and v2.
     *      Usefulness: To quickly make a Dot product with Vector3.
     *      Based on: Vector3.Dot
     * */
    public static float Dot(this Vector2 v1, Vector2 v2)
    {
        return Vector3.Dot(v1, v2);
    }
    public static float Dot(this Vector3 v1, Vector3 v2)
    {
        return Vector3.Dot(v1, v2);
    }

    /*
     * Vector2 [Vector2 v1].RawMult(Vector2 v2) / static Vector2 RawMult(Vector2 v1, Vector2 v2):
     *      Function: Returns a Vector2 where each coordinate is the product of the same coordinate of the two vectors.
     *      Usefulness: To quickly make a Raw product with Vector2.
     *      
     * Vector3 [Vector3 v1].RawMult(Vector3 v2) / static Vector3 RawMult(Vector3 v1, Vector3 v2):
     *      Function: Returns a Vector3 where each coordinate is the product of the same coordinate of the two vectors.
     *      Usefulness: To quickly make a Raw product with Vector3.
     * */
    public static Vector2 RawMult(this Vector2 v1, Vector2 v2)
    {
        return ((Vector3)v1).RawMult(v2);
    }
    public static Vector3 RawMult(this Vector3 v1, Vector3 v2)
    {
        return new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
    }


    //      (Set):

    /*
     * Vector2 [Vector2 vec].Set(float value, AuxCoord c) / static Vector2 Set(Vector2 vec, float value, AuxCoord c):
     *      Function: Returns a new Vector2 with the same data as "vec" but with the coordinate "c" changed to "value".
     *      Usefulness: To quickly create a new Color that only changes one aspect of another one.
     *      
     * Vector2 [Vector2 vec].Set(float value, string c) / static Vector2 Set(Vector2 vec, float value, string c):
     *      Function: Returns a new Vector2 with the same data as "vec" but with the coordinate "c" changed to "value"
     *      (this string must be a valid coordinate {x, y}, or else it changes nothing).
     *      Usefulness: To quickly create a new Vector2 that only changes one aspect of another one, and quickly writing the coordinate code.
     * */
    public static Vector2 Set(this Vector2 vec, float value, AuxCoord c)
    {
        return new Vector2(c == AuxCoord.x ? value : vec.x, c == AuxCoord.y ? value : vec.y);
    }
    public static Vector2 Set(this Vector2 vec, float value, string c)
    {
        return Set(vec, value, p_CharToAuxCoord(c));
    }

    /*
     * Vector3 [Vector3 vec].Set(float value, AuxCoord c) / static Vector3 Set(Vector3 vec, float value, AuxCoord c):
     *      Function: Returns a new Vector3 with the same data as "vec" but with the coordinate "c" changed to "value".
     *      Usefulness: To quickly create a new Color that only changes one aspect of another one.
     *      
     * Vector3 [Vector3 vec].Set(float value, string c) / static Vector3 Set(Vector3 vec, float value, string c):
     *      Function: Returns a new Vector3 with the same data as "vec" but with the coordinate "c" changed to "value"
     *      (this string must be a valid coordinate {x, y, z}, or else it changes nothing).
     *      Usefulness: To quickly create a new Vector3 that only changes one aspect of another one, and quickly writing the coordinate code.
     * */
    public static Vector3 Set(this Vector3 vec, float value, AuxCoord c)
    {
        return new Vector3(c == AuxCoord.x ? value : vec.x, c == AuxCoord.y ? value : vec.y, c == AuxCoord.z ? value : vec.z);
    }
    public static Vector3 Set(this Vector3 vec, float value, string c)
    {
        return Set(vec, value, p_CharToAuxCoord(c));
    }


    //      (Max, Min):

    /*
     * float [Vector2 vec].Max() / static float Max(Vector2 vec):
     *      Function: Returns the highest coordinate value of the Vector2.
     *      Usefulness: To quickly calculate the highest value of the Vector2.
     *      Based on: Mathf.Min
     *      
     * float [Vector3 vec].Max() / static float Max(Vector3 vec):
     *      Function: Returns the highest coordinate value of the Vector3.
     *      Usefulness: To quickly calculate the highest value of the Vector3.
     *      Based on: Mathf.Min
     * */
    public static float Max(this Vector2 vec)
    {
        return Mathf.Max(vec.x, vec.y);
    }
    public static float Max(this Vector3 vec)
    {
        return Mathf.Max(vec.x, vec.y, vec.z);
    }

    /*
     * float [Vector2 vec].Min() / static float Min(Vector2 vec):
     *      Function: Returns the lowest coordinate value of the Vector2.
     *      Usefulness: To quickly calculate the lowest value of the Vector2.
     *      Based on: Mathf.Min
     *      
     * float [Vector3 vec].Min() / static float Min(Vector3 vec):
     *      Function: Returns the lowest coordinate value of the Vector3.
     *      Usefulness: To quickly calculate the lowest value of the Vector3.
     *      Based on: Mathf.Min
     * */
    public static float Min(this Vector2 vec)
    {
        return Mathf.Min(vec.x, vec.y);
    }
    public static float Min(this Vector3 vec)
    {
        return Mathf.Min(vec.x, vec.y, vec.z);
    }


    /////////////////// QUATERNION EXTENSIONS /////////////////////

    /*
     * Vector2 [Quaternion vec].Angle(AuxCoord co, float offset = 0f) / static Vector2 Angle(Quaternion vec, AuxCoord co, float offset = 0f):
     *      Function: Returns a Vector2 with the angle of a particular coordinate plus an offset.
     *      Usefulness: To quickly calculate the angle of a particular coordinate in a Quaternion (adding an offset number if needed).
     *      Based on: [Quaternion].eulerAngles
     *      
     * Vector2 [Quaternion vec].Angle(string co, float offset = 0f) / static Vector2 Angle(Quaternion vec, string co, float offset = 0f):
     *      Function: Returns a Vector2 with the angle of a particular coordinate plus an offset
     *      (this string must be a valid coordinate {x, y, z}, or else it returns Vector2.zero).
     *      Usefulness: To quickly calculate the angle of a particular coordinate in a Quaternion (adding an offset number if needed),
     *      and quickly writing the coordinate code.
     *      Based on: [Quaternion].eulerAngles
     * */
    public static Vector2 Angle(this Quaternion angle, AuxCoord co, float offset = 0f)
    {
        switch (co)
        {
            case AuxCoord.x: return (angle.eulerAngles.x + offset).AngleDeg();
            case AuxCoord.y: return (angle.eulerAngles.y + offset).AngleDeg();
            case AuxCoord.z: return (angle.eulerAngles.z + offset).AngleDeg();
        }
        return Vector2.zero;
    }
    public static Vector2 Angle(this Quaternion angle, string co, float offset = 0f)
    {
        return angle.Angle(p_CharToAuxCoord(co), offset);
    }


    /////////////////// GAMEOBJECT EXTENSIONS /////////////////////

    /*
     * GameObject [GameObject go].Duplicate(bool isSibling) / static GameObject Duplicate(GameObject go, bool isSibling):
     *      Function: Creates a Duplicate of the GameObject and returns it, either as a son (isSibling false) or as a later sibling (isSibling true).
     *      Usefulness: To quickly make a duplicate of a GameObject either as a son or as a sibling.
     *      Based on: Auxg.i.Duplicate
     * */
    public static GameObject Duplicate(this GameObject go, bool isSibling = false)
    {
        return Auxg.i.Duplicate(go, isSibling);
    }

    /*
     * List<T> [GameObject go].GetRecursive<T>(int depth) / static List<T> GetRecursive<T>(GameObject go, int depth):
     *      Function: Returns a list of GameObjects or a specific MonoBehaviour (if they have it) linked to the GameObject
     *      via the script "Complement" recursively, Depth determining the level of depth of the variables that will be taken
     *      (i.e. if 2, it will only take the original GameObject and his complements, not further).
     *      Usefulness: To link GameObjects with one another manually and getting them all at the same time.
     *      Based on: [GameObject].GetComponent, [Complement].isIncluded, typeof
     *      Error: If two GameObjects are linked respectivelly, it will create an endless loop.
     *      
     * List<T> [GameObject go].GetRecursive<T>(bool isIncluded, int depth) / static List<T> GetRecursive<T>(GameObject go, bool isIncluded, int depth):
     *      Function: Returns a list of GameObjects or a specific MonoBehaviour (if they have it) linked to the GameObject
     *      via the script "Complement" recursively, with isIncluded determining if true whether a particular GameObject should be included or not
     *      if its value in its Complement.IsIncluded is true or not, and Depth determining the level of depth of the variables that will be taken
     *      (i.e. if 2, it will only take the original GameObject and his complements, not further; if left or negative, it will cover all).
     *      Usefulness: To link GameObjects with one another manually and getting them all at the same time, filtering some specifics.
     *      Based on: [GameObject].GetComponent, [Complement].isIncluded, typeof
     *      Error: If two GameObjects are linked respectivelly, it will create an endless loop.
     * */
    public static List<T> GetRecursive<T>(this GameObject go, int depth) where T : class
    {
        return go.GetRecursive<T>(false, depth);
    }
    public static List<T> GetRecursive<T>(this GameObject go, bool isIncluded = false, int depth = -1) where T : class
    {
        List<T> list = new List<T>();
        Complement co = go.GetComponent<Complement>();

        if (co == null || !isIncluded || co.included)
        {
            if (typeof(T).Equals(typeof(GameObject)))
                list.Add(go as T);
            else if (go.GetComponent<T>() != null)
                list.Add(go.GetComponent<T>());
        }

        if (depth != 0 && co != null)
            foreach (GameObject c in co.complement)
                list.AddRange(c.GetRecursive<T>(isIncluded, depth - 1));

        return list;
    }

    /*
     * void [GameObject go].Set(Material material) / static void Set(GameObject go, Material material):
     *      Function: Changes the material of the GameObject, if it's possible, to "material".
     *      Usefulness: To quickly change a material of a GameObject.
     *      Based on: Auxg.i.Set <Material>
     *      
     * void [GameObject go].Set(Color color) / static void Set(GameObject go, Color color):
     *      Function: Changes the material of the GameObject, if it's possible, to "color".
     *      Usefulness: To quickly change a color of a GameObject.
     *      Based on: Auxg.i.Set <Color>
     * */
    public static void Set(this GameObject go, Material material)
    {
        Auxg.i.Set(go, material);
    }
    public static void Set(this GameObject go, Color color)
    {
        Auxg.i.Set(go, color);
    }


    /////////////////// TRANSFORM EXTENSIONS /////////////////////

    /*
     * void [Transform go1].Add(Transform go2) / static void Add(Transform go1, Transform go2):
     *      Function: Adds the local position, rotation and scale of the Transform go2 to go1.
     *      Usefulness: To quickly add the parameters of one Transform to the other.
     *      Based on: [Transform].localPosition, [Transform].localRotation, [Transform].localScale, Quaternion.Euler 
     * */
    public static void Add(this Transform go1, Transform go2)
    {
        go1.localPosition += go2.localPosition;
        go1.localRotation = Quaternion.Euler(go1.localRotation.eulerAngles + go2.localRotation.eulerAngles);
        go1.localScale += go2.localScale;
    }

    /*
     * Transform [Transform go].Duplicate(bool isSibling) / static Transform Duplicate(Transform go, bool isSibling):
     *      Function: Creates a Duplicate of the Transform and returns it, either as a son (isSibling false) or as a later sibling (isSibling true).
     *      Usefulness: To quickly make a duplicate of a Transform either as a son or as a sibling.
     *      Based on: Auxg.i.Duplicate
     * */
    public static Transform Duplicate(this Transform go, bool isSibling = false)
    {
        return Auxg.i.Duplicate(go, isSibling);
    }

    /*
     * void [Transform go].Reset() / static void Reset(Transform go):
     *      Function: Resets the Transform's local position, rotation and scale
     *      Usefulness: To quickly reset a Transform's values.
     *      Based on: [Transform].localPosition, [Transform].localRotation, [Transform].localScale
     * */
    public static void Reset(this Transform transform)
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }

    /*
     * void [Transform go1].Set(Transform go2) / static void Set(Transform go1, Transform go2):
     *      Function: Sets the local position, rotation and scale of the Transform go2 to go1.
     *      Usefulness: To quickly set the parameters of one Transform to the other.
     *      Based on: [Transform].localPosition, [Transform].localRotation, [Transform].localScale 
     * */
    public static void Set(this Transform go1, Transform go2)
    {
        go1.localPosition = go2.localPosition;
        go1.localRotation = go2.localRotation;
        go1.localScale = go2.localScale;
    }

    /*
     * List<T> [Transform go].GetRecursive<T>(int depth) / static List<T> GetRecursive<T>(Transform go, int depth):
     *      Function: Returns a list of GameObjects or a specific MonoBehaviour (if they have it) linked to the GameObject
     *      via the script "Complement" recursively, Depth determining the level of depth of the variables that will be taken
     *      (i.e. if 2, it will only take the original GameObject and his complements, not further).
     *      Usefulness: To link GameObjects with one another manually and getting them all at the same time.
     *      Based on: [Transform].GetComponent, [Complement].isIncluded, typeof
     *      Error: If two GameObjects are linked respectivelly, it will create an endless loop.
     *      
     * List<T> [Transform go].GetRecursive<T>(bool isIncluded, int depth) / static List<T> GetRecursive<T>(Transform go, bool isIncluded, int depth):
     *      Function: Returns a list of GameObjects or a specific MonoBehaviour (if they have it) linked to the GameObject
     *      via the script "Complement" recursively, with isIncluded determining if true whether a particular GameObject should be included or not
     *      if its value in its Complement.IsIncluded is true or not, and Depth determining the level of depth of the variables that will be taken
     *      (i.e. if 2, it will only take the original GameObject and his complements, not further; if left or negative, it will cover all).
     *      Usefulness: To link GameObjects with one another manually and getting them all at the same time, filtering some specifics.
     *      Based on: [Transform].GetComponent, [Complement].isIncluded, typeof
     *      Error: If two GameObjects are linked respectivelly, it will create an endless loop.
     * */
    public static List<T> GetRecursive<T>(this Transform go, int depth) where T : class
    {
        return go.GetRecursive<T>(false, depth);
    }
    public static List<T> GetRecursive<T>(this Transform go, bool isIncluded = false, int depth = -1) where T : class
    {
        return go.gameObject.GetRecursive<T>(isIncluded, depth);
    }


    /////////////////// MONOBEHAVIOUR EXTENSIONS /////////////////////

    /*
     * T [T go].Duplicate<T>(bool isSibling) / static T Duplicate<T>(T go, bool isSibling) { where T : MonoBehaviour }:
     *      Function: Creates a Duplicate of the MonoBehaviour and returns it, either as a son (isSibling false) or as a later sibling (isSibling true).
     *      Usefulness: To quickly make a duplicate of a MonoBehaviour either as a son or as a sibling.
     *      Based on: Auxg.i.Duplicate
     * */
    public static T Duplicate<T>(this T go, bool isSibling = false) where T : MonoBehaviour
    {
        return Auxg.i.Duplicate(go, isSibling);
    }

    /*
     * List<T> [MonoBehaviour go].GetRecursive<T>(int depth) / static List<T> GetRecursive<T>(MonoBehaviour go, int depth) { where T : class }:
     *      Function: Returns a list of GameObjects or a specific MonoBehaviour (if they have it) linked to the GameObject
     *      via the script "Complement" recursively, Depth determining the level of depth of the variables that will be taken
     *      (i.e. if 2, it will only take the original GameObject and his complements, not further).
     *      Usefulness: To link GameObjects with one another manually and getting them all at the same time.
     *      Based on: [MonoBehaviour].GetComponent, [Complement].isIncluded, typeof
     *      Error: If two GameObjects are linked respectivelly, it will create an endless loop.
     *      
     * List<T> [MonoBehaviour go].GetRecursive<T>(bool isIncluded, int depth) / static List<T> GetRecursive<T>(MonoBehaviour go, bool isIncluded, int depth) { where T : class }:
     *      Function: Returns a list of GameObjects or a specific MonoBehaviour (if they have it) linked to the GameObject
     *      via the script "Complement" recursively, with isIncluded determining if true whether a particular GameObject should be included or not
     *      if its value in its Complement.IsIncluded is true or not, and Depth determining the level of depth of the variables that will be taken
     *      (i.e. if 2, it will only take the original GameObject and his complements, not further; if left or negative, it will cover all).
     *      Usefulness: To link GameObjects with one another manually and getting them all at the same time, filtering some specifics.
     *      Based on: [MonoBehaviour].GetComponent, [Complement].isIncluded, typeof
     *      Error: If two GameObjects are linked respectively, it will create an endless loop.
     * */
    public static List<T> GetRecursive<T>(this MonoBehaviour go, int depth) where T : class
    {
        return go.GetRecursive<T>(false, depth);
    }
    public static List<T> GetRecursive<T>(this MonoBehaviour go, bool isIncluded = false, int depth = -1) where T : class
    {
        return go.gameObject.GetRecursive<T>(isIncluded, depth);
    }
}
