/*
 * Auxp (Auxiliar Polygon):
 * This file contains a lot of class to do 2D geometric operations with Lines, Segments, Wide Lines, Polygons and Meshes.
 * It needs the library "System.Collections.Generic" and "UnityEngine" to work, so it only works on Unity projects.
 * It also needs the other classes from the pack: "Auxe.cs", "Auxc.cs"
 * 
 * Developed by Alberto León Meaños, 22/07/2018, License GNU General Public License v3.0
 * */


using System.Collections.Generic;
using UnityEngine;


/*
 * Class Auxp
 *      It allows to call normal methods and properties from the upcoming classes as functions with input parameters.
 *      This will allow to use them for Delegate functions with arguments.
 *      
 *      This part won't be commented in detail since their details will go in the other classes. However, a few translation of operations:
 *          - Dot(A, B): A * B
 *          - Substract(A, B): A - B
 * */
public class Auxp
{
    //Singleton:
    private static Auxp m_instance = null;
    public static Auxp i { get { if (m_instance == null) m_instance = new Auxp(); return m_instance; } }
    private Auxp() { }
    

    //AuxLine Extensions:
    public bool Equals(AuxLine def1, AuxLine def2)
    {
        return def1.Equals(def2);
    }
    public bool Intersects(AuxLine def1, AuxLine def2)
    {
        return def1.Intersects(def2);
    }
    public Vector2 Dot(AuxLine def1, AuxLine def2)
    {
        return def1 * def2;
    }

    
    //AuxSegment Extensions:
    public List<Vector2> Points(AuxSegment ap)
    {
        return ap.Points;
    }
    public float Distance(AuxSegment ap, Vector2 vec)
    {
        return ap.Distance(vec);
    }
    public float SqrDistance(AuxSegment ap, Vector2 vec)
    {
        return ap.SqrDistance(vec);
    }
    public float Length(AuxSegment ap)
    {
        return ap.Length;
    }
    public float SqrLength(AuxSegment ap)
    {
        return ap.SqrLength;
    }
    public bool IsExtreme(AuxSegment ap, Vector2 vec)
    {
        return ap.IsExtreme(vec);
    }
    public bool IsExtreme(AuxSegment ap, Vector2 vec, bool exclude)
    {
        return ap.IsExtreme(vec, exclude);
    }
    public bool IsInside(AuxSegment ap, Vector2 vec)
    {
        return ap.IsInside(vec);
    }
    public bool IsInside(AuxSegment ap, Vector2 vec, bool exclude)
    {
        return ap.IsInside(vec, exclude);
    }
    public bool Intersects(AuxSegment seg1, AuxLine def)
    {
        return seg1.Intersects(def);
    }
    public bool Intersects(AuxSegment seg1, AuxSegment seg2)
    {
        return seg1.Intersects(seg2);
    }
    public Vector2 Dot(AuxSegment def1, AuxLine def2)
    {
        return def1 * def2;
    }
    public Vector2 Dot(AuxSegment def1, AuxSegment def2)
    {
        return def1 * def2;
    }
    public List<AuxSegment> Substract(AuxSegment def1, Vector2 def2)
    {
        return def1 - def2;
    }
    public List<AuxSegment> Substract(AuxSegment def1, AuxLine def2)
    {
        return def1 - def2;
    }
    public List<AuxSegment> Substract(AuxSegment def1, AuxSegment def2)
    {
        return def1 - def2;
    }
    public List<AuxSegment> Substract(AuxSegment def1, List<AuxSegment> def2)
    {
        return def1 - def2;
    }


    //AuxPolygon Extensions:
    public float Area(AuxPolygon ap)
    {
        return ap.Area;
    }
    public List<AuxTriangle> Triangulate(AuxPolygon ap)
    {
        return ap.Triangulate;
    }


    //Vector2 Extensions:
    public bool IsInside(Vector2 vec, AuxTriangle aux)
    {
        return aux.IsInside(vec);
    }
    public bool IsInside(Vector2 vec, AuxLine aux)
    {
        return aux.IsInside(vec);
    }
    public bool IsInside(Vector2 vec, AuxSegment aux)
    {
        return aux.IsInside(vec);
    }
    public bool IsInside(Vector2 vec, AuxWideLine aux)
    {
        return aux.IsInside(vec);
    }
    public bool IsInside(Vector2 vec, AuxPolygon aux)
    {
        return aux.IsInside(vec);
    }
    public bool IsInside(Vector2 vec, AuxMesh aux)
    {
        return aux.IsInside(vec);
    }
}


/*
 * Class AuxpStatic
 *      This class applies extensions to Auxp classes that aren't the particular classes to be more comfortable to use them.
 * */
public static class AuxpStatic
{
    //List<AuxSegment> Extensions:

    /*
     * AuxSegment [List<AuxSegment> array].Connection(AuxSegment seg, Vector2 extreme)
     * / static AuxSegment Connection(List<AuxSegment> array, AuxSegment seg, Vector2 extreme):
     *      Function: Given a list of segments connected, a segment included in them and an extreme, it gives the other connected segment.
     *      Usefulness: To get the future connected segment of a list. Needed for private functions in AuxPolygon.
     * */
    public static AuxSegment Connection(this List<AuxSegment> array, AuxSegment seg, Vector2 extreme)
    {
        if (!array.Contains(seg))
            return AuxSegment.NaN;

        int i = array.IndexOf(seg);
        if (seg.p1 == extreme && array[(i - 1) % array.Count].p2 == extreme)
            return array[(i - 1) % array.Count];
        if (seg.p2 == extreme && array[(i + 1) % array.Count].p1 == extreme)
            return array[(i + 1) % array.Count];

        return array.RemoveAtReturn(i).Get(Auxp.i.IsExtreme, extreme, AuxSegment.NaN);
    }

    /*
     * AuxSegment [List<AuxSegment> array].Next(Vector2 extreme) / static AuxSegment Next(List<AuxSegment> array, Vector2 extreme):
     *      Function: Given a list of segments connected, it gives the segment that start with that extreme.
     *      Usefulness: To get the next segment with just the extreme.
     * */
    public static AuxSegment Next(this List<AuxSegment> array, Vector2 extreme)
    {
        return array.Get(Auxp.i.IsExtreme, extreme, true, AuxSegment.NaN);
    }

    /*
     * List<Vector2> [List<AuxSegment> array].Points() / static List<Vector2> Points(List<AuxSegment> array):
     *      Function: Given a list of segments, it gives the list of points that compose it, eliminating repeats.
     *      Usefulness: To get the next segment with just the extreme.
     * */
    public static List<Vector2> Points(this List<AuxSegment> array)
    {
        return array.Execute(Auxp.i.Points).Combine().Distinct();
    }


    //List<AuxMesh> Extensions:

    /*
     * AuxMesh [List<AuxMesh> array].Combine() / static AuxMesh Combine(List<AuxMesh> array):
     *      Function: Given a list of meshes, it combines into one their polygons, but the positive and the negative ones.
     *      Usefulness: To quickly combine them.
     * */
    public static AuxMesh Combine(this List<AuxMesh> array)
    {
        AuxMesh list = new AuxMesh();
        foreach (AuxMesh el in array)
            if (el != null)
            {
                list.AddRange(el);
                list.Negatives.AddRange(el.Negatives);
            }
        return list;
    }

}


/*
 * Struct AuxTriangle
 *      This struct gets the form of a Triangle, composed of 3 points, and a few operations to facilitate their use.
 *      These are used to triangulate polygons and meshes.
 * */
public struct AuxTriangle
{
    //Attributes:
    public Vector3 p1;
    public Vector3 p2;
    public Vector3 p3;


    //Properties:
    public List<Vector3> Points { get { return new List<Vector3>(new Vector3[] { p1, p2, p3 }); } }
    public static AuxTriangle NaN { get { return new AuxTriangle
                (Vector2.negativeInfinity, Vector2.negativeInfinity, Vector2.negativeInfinity); }
    }


    //Constructors:
    public AuxTriangle (Vector3 np1, Vector3 np2, Vector3 np3)
    {
        p1 = np1;
        p2 = np2;
        p3 = np3;
    }


    //Functions:

    /*
     * bool IsInside (Vector3 P)
     *      Function: Returns whether the point is inside the triangle.
     *      Usefulness: To quickly calculate whether a point is inside the triangle.
     * */
    public bool IsInside(Vector3 P)
    {
        float ax, ay, bx, by, cx, cy, apx, apy, bpx, bpy, cpx, cpy;
        float cCROSSap, bCROSScp, aCROSSbp;

        ax = p3.x - p2.x; ay = p3.y - p2.y;
        bx = p1.x - p3.x; by = p1.y - p3.y;
        cx = p2.x - p1.x; cy = p2.y - p1.y;
        apx = P.x - p1.x; apy = P.y - p1.y;
        bpx = P.x - p2.x; bpy = P.y - p2.y;
        cpx = P.x - p3.x; cpy = P.y - p3.y;

        aCROSSbp = ax * bpy - ay * bpx;
        cCROSSap = cx * apy - cy * apx;
        bCROSScp = bx * cpy - by * cpx;

        return ((aCROSSbp >= 0.0f) && (bCROSScp >= 0.0f) && (cCROSSap >= 0.0f));
    }

    /*
     * bool IsExtreme (Vector3 P)
     *      Function: Returns whether the point is one of the extremes of the triangle.
     *      Usefulness: To quickly check that a point is one extreme.
     * */
    public bool IsExtreme(Vector3 P)
    {
        return p1 == P || p2 == P || p3 == P;
    }

    /*
     * bool Equals (AuxTriangle t1)
     *      Function: Returns whether the triangle is equivalent to the other. The other doesn't matter.
     *      Usefulness: To quickly check if two triangles cover the same ground.
     * */
    public bool Equals(AuxTriangle t1)
    {
        return Points.IsAll(t1.IsExtreme);
    }
}

/*
 * Struct AuxLine
 *      This struct simulates the form of a Line with only a position and direction in a 2D environment (ignoring Z).
 *      This Line is defined by two points like it's a segment, but it's only to mark the position and rotation.
 * */
public struct AuxLine
{
    //Attributes:
    public Vector2 p1;
    public Vector2 p2;


    //Properties:
    public Vector2 v { get { return p2 - p1; } }
    public Vector3 Cross { get { return new Vector3(0, 0, p1.x * p2.y - p1.y * p2.x); } }
    public static AuxLine NaN { get { return new AuxLine(AuxeUnity.NaN, AuxeUnity.NaN); } }


    //Constructors:
    public AuxLine(Vector2 vec2) : this(Vector2.zero, vec2) { }
    public AuxLine(Vector2 vec1, Vector2 vec2)
    {
        p1 = vec1;
        p2 = vec2;
    }
    public AuxLine(Vector2 vec1, Vector2 dir, bool Direction) : this(vec1, dir + vec1) { }
    public AuxLine(Vector2 translate, float rotate) : this(translate, translate + rotate.AngleDeg()) { }


    //Public Functions:

    /*
     * bool IsInside (Vector2 vec)
     *      Function: Returns whether the point is inside the line.
     *      Usefulness: To quickly calculate whether a point is inside the line.
     * */
    public bool IsInside(Vector2 vec)
    {
        return v.Cross(vec - p1) < Auxf.i.MINIMUM;
    }

    /*
     * bool Intersects (AuxLine def)
     *      Function: Returns whether those two lines intersect. Parallel lines never intersect regardless of whether they are the same.
     *      Usefulness: To quickly see if two lines intersect.
     * */
    public bool Intersects (AuxLine def)
    {
        return v.Cross(def.v) >= Auxf.i.MINIMUM;
    }
    

    //Reference Functions (to allow distributive calling. These will be defined in their respective original callings):
    public bool Intersects(AuxSegment def)
    {
        return def.Intersects(this);
    }
    public bool Intersects(AuxWideLine def)
    {
        return def.Intersects(this);
    }
    public bool Intersects(AuxPolygon def)
    {
        return def.Intersects(this);
    }
    public bool Intersects(AuxMesh def)
    {
        return def.Intersects(this);
    }

    public Vector2 Dot (AuxLine def2)
    {
        return this * def2;
    }
    public Vector2 Dot(AuxSegment def2)
    {
        return this * def2;
    }
    public AuxSegment Dot(AuxWideLine def2)
    {
        return this * def2;
    }
    public List<AuxSegment> Dot(AuxPolygon def2)
    {
        return this * def2;
    }
    public List<AuxSegment> Dot(AuxMesh def2)
    {
        return this * def2;
    }


    //Operators (Dot):
    
    /*
     * static Vector2 operator *(AuxLine def1, AuxLine def2)
     *      Function: Returns the intersection point between two lines, as long as they intersect.
     *      Otherwise, it returns Vector2.negativeInfinity.
     *      Usefulness: To quickly with an operation get the intersection section.
     * */
    public static Vector2 operator *(AuxLine def1, AuxLine def2)
    {
        return def1.Intersects(def2)?
            (def2.Cross.z * def1.v - def1.Cross.z * def2.v) / def1.v.Cross(def2.v)
            : Vector2.negativeInfinity;
    }
}


/*
 * Struct AuxSegment
 *      This struct simulates the form of a Segment between two positions in a 2D environment (ignoring Z).
 *      While the form is similar to AuxLine, the limit is only in those extremes, so their functions work differently.
 * */
public struct AuxSegment
{
    //Attributes:
    public Vector2 p1;
    public Vector2 p2;


    //Properties:
    public Vector2 v { get { return p2 - p1; } }
    public float Length { get { return v.magnitude; } }
    public float SqrLength { get { return v.sqrMagnitude; } }
    public Vector2 Center { get { return (p1 + p2) / 2f; } }
    public AuxLine Line { get { return new AuxLine(p1, p2); } }
    public List<Vector2> Points { get { return new List<Vector2>(new Vector2[] { p1, p2 }); } }
    public static AuxSegment NaN { get { return new AuxSegment(AuxeUnity.NaN, AuxeUnity.NaN); } }

    /*
     * List<AuxSegment> Pair (List<Vector2> points)
     *      Property: Given a list of points (size multiple of 2), it returns a list of AuxSegments each composed by each par.
     *      Usefulness: To quickly get from a list of points their segments. Used in AuxPolygon intersection operations.
     * */
    public static List<AuxSegment> Pair(List<Vector2> points)
    {
        if (points.Count % 2 != 0)
            return null;

        var list = new List<AuxSegment>();
        points.Sort(new Vector2Comparer());
        for (int i = 0; i < points.Count; i += 2)
            list.Add(new AuxSegment(points[i], points[i + 1]));
        return list;
    }


    //Constructors:
    public AuxSegment (Vector2 nv2) : this(Vector2.zero, nv2) { }
    public AuxSegment (Vector2 vec1, Vector2 vec2)
    {
        p1 = vec1;
        p2 = vec2;
    }


    //Public Functions:

    /*
     * bool IsNaN ()
     *      Function: Returns whether a point of the segment is NaN.
     *      Usefulness: To quickly check if it's an unvalid Segment.
     * */
    public bool IsNaN ()
    {
        return p1.IsNaN() || p2.IsNaN();
    }

    /*
     * bool Equals (AuxSegment seg)
     *      Function: Returns whether the segments are similar. Being both NaN is included, and their extremes on the other side.
     *      Usefulness: To quickly check if two segments are the same.
     * */
    public bool Equals(AuxSegment seg)
    {
        return (p1 == seg.p1 && p2 == seg.p2) || (p2 == seg.p1 && p1 == seg.p2) || (IsNaN() && seg.IsNaN());
    }

    /*
     * bool IsInside (Vector2 vec)
     *      Function: Returns whether the point is inside the segment.
     *      Usefulness: To quickly calculate whether a point is inside the segment.
     *      
     * bool IsInside (Vector2 vec, bool exclude)
     *      Function: Returns whether the point is inside the segment excluding one extreme.
     *      If "exclude" is "false", the extreme excluded is the first one. If "true", it's the second one.
     *      Usefulness: To quickly calculate whether a point is inside the segment but not in a particular extreme.
     *      
     * bool IsInside (AuxSegment vec, bool spin)
     *      Function: Returns whether the input segment is inside the main segment.
     *      If "spin" is true, then it checks whether the main segment is inside the input segment.
     *      Usefulness: To check if a segment is contained inside another quickly, and also do opposites for Delegate functions.
     * */
    public bool IsInside (Vector2 vec)
    {
        return !IsNaN() && ((vec-p1).magnitude + (p2-vec).magnitude - Length).Abs() < Auxf.i.MINIMUM;
    }
    public bool IsInside (Vector2 vec, bool exclude)
    {
        return IsInside(vec) && (exclude? vec != p2 : vec != p1);
    }
    public bool IsInside (AuxSegment vec, bool spin = false)
    {
        if (spin)
            return vec.IsInside(p1) && vec.IsInside(p2);
        else
            return IsInside(vec.p1) && IsInside(vec.p2);
    }

    /*
     * bool IsExtreme (Vector2 vec)
     *      Function: Returns whether the point is one extreme.
     *      Usefulness: To quickly calculate whether a point is the extreme of a segment.
     *      
     * bool IsExtreme (Vector2 vec, bool exclude)
     *      Function: Returns whether the point is one extreme, excluding one of them.
     *      If "exclude" is "false", the extreme excluded is the first one. If "true", it's the second one.
     *      Usefulness: To quickly calculate whether a point is only in a particular extreme.
     * */
    public bool IsExtreme (Vector2 vec)
    {
        return !IsNaN() && (p1 == vec || p2 == vec);
    }
    public bool IsExtreme (Vector2 vec, bool exclude)
    {
        return !IsNaN() && (exclude ? p1 == vec : p2 == vec);
    }

    /*
     * bool Nearest (Vector2 vec)
     *      Function: Returns the nearest extreme to the input point.
     *      Usefulness: To quickly get the nearest extreme to a point.
     *      
     * bool Nearest (Vector2 vec, Vector2 other)
     *      Function: Returns the nearest extreme to the input point in comparison with the other.
     *      This means, if the first point is closer to one extreme than the other, it takes that extreme, with preference to the start extreme.
     *      Usefulness: To quickly get the nearest extreme to a point.
     *      
     * bool Nearest (AuxSegment vec, bool spin)
     *      Function: Returns the nearest extreme of the main segment to the input segment.
     *      If "spin" is true, then it returns the nearest extreme of the input segment to the main segment.
     *      Usefulness: To quickly get the nearest extreme to a segment.
     * */
    public Vector2 Nearest (Vector2 vec)
    {
        return (vec - p1).sqrMagnitude <= (vec - p2).sqrMagnitude ? p1 : p2;
    }
    public Vector2 Nearest (Vector2 vec, Vector2 other)
    {
        return (vec - p1).sqrMagnitude <= (other - p1).sqrMagnitude ? p1 : p2;
    }
    public Vector2 Nearest (AuxSegment vec, bool spin = false)
    {
        if (spin)
            return SqrDistance(vec.p1) <= SqrDistance(vec.p2) ? vec.p1 : vec.p2;
        else
            return vec.SqrDistance(p1) <= vec.SqrDistance(p2) ? p1 : p2;
    }

    /*
     * bool Further (Vector2 vec)
     *      Function: Returns the further extreme to the input point.
     *      Usefulness: To quickly get the further extreme to a point.
     *      
     * bool Further (Vector2 vec, Vector2 other)
     *      Function: Returns the further extreme to the input point in comparison with the other.
     *      This means, if the first point is further to one extreme than the other, it takes that extreme, with preference to the start extreme.
     *      Usefulness: To quickly get the further extreme to a point.
     *      
     * bool Further (AuxSegment vec, bool spin)
     *      Function: Returns the further extreme of the main segment to the input segment.
     *      If "spin" is true, then it returns the further extreme of the input segment to the main segment.
     *      Usefulness: To quickly get the further extreme to a segment.
     * */
    public Vector2 Further (Vector2 vec)
    {
        return (vec - p1).sqrMagnitude >= (vec - p2).sqrMagnitude ? p1 : p2;
    }
    public Vector2 Further (Vector2 vec, Vector2 other)
    {
        return (vec - p1).sqrMagnitude > (other - p1).sqrMagnitude ? p1 : p2;
    }
    public Vector2 Further (AuxSegment vec, bool spin = false)
    {
        if (spin)
            return SqrDistance(vec.p1) >= SqrDistance(vec.p2) ? vec.p1 : vec.p2;
        else
            return vec.SqrDistance(p1) >= vec.SqrDistance(p2) ? p1 : p2;
    }

    /*
     * float Distance (Vector2 vec)
     *      Function: Returns the minimal distance between a point and the segment.
     *      Usefulness: To quickly calculate the distance between a point and a segment.
     *      
     * float SqrDistance (Vector2 vec)
     *      Function: Returns the minimal square distance between a point and the segment.
     *      Usefulness: To quickly calculate the square distance between a point and a segment.
     *      By not doing a square operation, this is more efficient and useful in some cases.
     * */
    public float Distance (Vector2 vec)
    {
        if (IsNaN())
            return float.NaN;
        if (IsInside(vec))
            return 0f;
        else if (Intersects(new AuxLine(vec, vec + v.Perpendicular())))
            return (vec - this * new AuxLine(vec, vec + v.Perpendicular())).magnitude;
        return new float[] { (vec - p1).magnitude, (vec - p2).magnitude }.Min();
    }
    public float SqrDistance (Vector2 vec)
    {
        if (IsNaN())
            return float.NaN;
        if (IsInside(vec))
            return 0f;
        else if (Intersects(new AuxLine(vec, vec + v.Perpendicular())))
            return (vec - this * new AuxLine(vec, vec + v.Perpendicular())).sqrMagnitude;
        return new float[] { (vec - p1).sqrMagnitude, (vec - p2).sqrMagnitude }.Min();
    }

    /*
     * bool Intersects (AuxLine def)
     *      Function: Returns whether the segment and a line intersect. Parallels never intersect.
     *      Usefulness: To quickly see if a line and a segment intersect.
     *      
     * bool Intersects (AuxSegment def)
     *      Function: Returns whether two segments intersect. Parallels never intersect.
     *      Usefulness: To quickly see if two segments intersect.
     * */
    public bool Intersects (AuxLine def)
    {
        return !IsNaN() && Line.Intersects(def) && IsInside(Line * def);
    }
    public bool Intersects (AuxSegment def)
    {
        var point = Line * def.Line;
        return !IsNaN() && !def.Equals(NaN) && Line.Intersects(def.Line) && IsInside(point) && def.IsInside(point);
    }

    /*
     * override string ToString ()
     *      Function: Returns a string with the data of the extreme points that define the segment.
     *      Usefulness: To quickly print the content of the segment.
     * */
    public override string ToString()
    {
        return "" + p1.ToString() + ", " + p2.ToString();
    }


    //Reference Functions (to allow distributive calling. These will be defined in their respective original callings):
    public bool IsInside(AuxWideLine seg)
    {
        return seg.IsInside(this);
    }
    public bool IsInside(AuxPolygon seg)
    {
        return seg.IsInside(this);
    }
    public bool IsInside(AuxMesh seg)
    {
        return seg.IsInside(this);
    }

    public bool Intersects(AuxWideLine def)
    {
        return def.Intersects(this);
    }
    public bool Intersects(AuxPolygon def)
    {
        return def.Intersects(this);
    }
    public bool Intersects(AuxMesh def)
    {
        return def.Intersects(this);
    }

    public Vector2 Dot(AuxSegment def2)
    {
        return this * def2;
    }
    public AuxSegment Dot(AuxWideLine def2)
    {
        return this * def2;
    }
    public List<AuxSegment> Dot(AuxPolygon def2)
    {
        return this * def2;
    }
    public List<AuxSegment> Dot(AuxMesh def2)
    {
        return this * def2;
    }

    public List<AuxSegment> Substract(AuxSegment def2)
    {
        return this - def2;
    }
    public List<AuxSegment> Substract(AuxWideLine def2)
    {
        return this - def2;
    }
    public List<AuxSegment> Substract(AuxPolygon def2)
    {
        return this - def2;
    }
    public List<AuxSegment> Substract(AuxMesh def2)
    {
        return this - def2;
    }


    //Operators (Dot):

    /*
     * static Vector2 operator *(AuxSegment def1, AuxLine def2) / static Vector2 operator *(AuxLine def2, AuxSegment def1)
     *      Function: Returns the intersection point between a segment and a line, as long as they intersect.
     *      Otherwise, it returns Vector2.negativeInfinity.
     *      Usefulness: To quickly with an operation get the intersection section.
     * */
    public static Vector2 operator *(AuxSegment def1, AuxLine def2)
    {
        return def1.Intersects(def2)? def1.Line * def2 : Vector2.negativeInfinity;
    }
    public static Vector2 operator *(AuxLine def2, AuxSegment def1)
    {
        return def1 * def2;
    }

    /*
     * static Vector2 operator *(AuxSegment def1, AuxSegment def2)
     *      Function: Returns the intersection point between two segments, as long as they intersect.
     *      Otherwise, it returns Vector2.negativeInfinity.
     *      Usefulness: To quickly with an operation get the intersection section.
     * */
    public static Vector2 operator *(AuxSegment def1, AuxSegment def2)
    {
        return def1.Intersects(def2)? def1.Line * def2.Line : Vector2.negativeInfinity;
    }


    //Operators (rest):

    /*
     * static List<AuxSegment> operator -(AuxSegment def1, Vector2 def2)
     *      Function: Returns a list with two segments if the vector is inside the segment (aside of the extremes).
     *      Otherwise, it returns a list with only one.
     *      Usefulness: To quickly with an operation get the substracted section.
     *      
     * static List<AuxSegment> operator -(AuxSegment def1, AuxLine def2)
     *      Function: Returns a list with two segments if the line intersects with the segment (aside of the extremes).
     *      Otherwise, it returns a list with only one.
     *      Usefulness: To quickly with an operation get the substracted section.
     *      
     * static List<AuxSegment> operator -(AuxSegment def1, AuxSegment def2)
     *      Function: Returns a list with two segments if the two segments intersect (aside of the extremes).
     *      In case the first segment is inside the second, it returns "null".
     *      In case the second segment is included in the first, it may return one or two depending of whether it cuts a extreme or not.
     *      If they don't intersect, it returns a list with only one.
     *      Usefulness: To quickly with an operation get the substracted section.
     *      
     * static List<AuxSegment> operator -(AuxSegment def1, List<AuxSegment> def2)
     *      Function: Returns a list of segments cut by the list in def2.
     *      Usefulness: To quickly with an operation get the substracted section.
     * */
    public static List<AuxSegment> operator -(AuxSegment def1, Vector2 def2)
    {
        if (!def1.IsInside(def2) || def1.IsExtreme(def2))
            return def1.List();
        return new List<AuxSegment>(new AuxSegment[] { new AuxSegment(def1.p1, def2), new AuxSegment(def1.p2, def2) } );
    }
    public static List<AuxSegment> operator -(AuxSegment def1, AuxLine def2)
    {
        return def1.Intersects(def2)? def1 - def1 * def2 : def1.List();
    }
    public static List<AuxSegment> operator -(AuxSegment def1, AuxSegment def2)
    {
        if (def1.Intersects(def2) && !def1.Points.IsAny(def2.IsInside))
            return def1 - def1 * def2;
        else if (def2.IsInside(def1))
            return null;
        else if (def1.IsInside(def2))
        {
            var list = new List<AuxSegment>();
            if (!def1.IsExtreme(def2.p1))
                list.Add(new AuxSegment(def1.Nearest(def2.p1, def2.p2), def2.p1));
            if (!def1.IsExtreme(def2.p2))
                list.Add(new AuxSegment(def1.Nearest(def2.p2, def2.p1), def2.p2));
            return list;
        }
        else if (def2.IsInside(def1.p1))
            return new AuxSegment(def1.p2, def2.Nearest(def1)).List();
        else if (def2.IsInside(def1.p2))
            return new AuxSegment(def1.p1, def2.Nearest(def1)).List();
        else
            return def1.List();
    }
    public static List<AuxSegment> operator -(AuxSegment def1, List<AuxSegment> def2)
    {
        List<AuxSegment> list = def1.List(), minus;
        for (int i = 0; i < def2.Count; i++)
            for (int j = list.Count - 1; j >= 0; j--)
            {
                minus = list[j] - def2[i];
                if (minus != null)
                    list.Set(j, minus);
            }
        return list;
    }

    /*
     * static AuxSegment operator /(AuxSegment def1, Vector2 def2)
     *      Function: Returns the largest segment out of the list substracted.
     *      Usefulness: To quickly with an operation get the largest substracted section.
     *      
     * static AuxSegment operator /(AuxSegment def1, AuxLine def2)
     *      Function: Returns the largest segment out of the list substracted.
     *      Usefulness: To quickly with an operation get the largest substracted section.
     *      
     * static AuxSegment operator /(AuxSegment def1, AuxSegment def2)
     *      Function: Returns the largest segment out of the list substracted.
     *      Usefulness: To quickly with an operation get the largest substracted section.
     * */
    public static AuxSegment operator /(AuxSegment def1, Vector2 def2)
    {
        return (def1 - def2).Max(Auxp.i.SqrLength, NaN);
    }
    public static AuxSegment operator /(AuxSegment def1, AuxLine def2)
    {
        return (def1 - def2).Max(Auxp.i.SqrLength, NaN);
    }
    public static AuxSegment operator /(AuxSegment def1, AuxSegment def2)
    {
        return (def1 - def2).Max(Auxp.i.SqrLength, NaN);
    }

    /*
     * static AuxSegment operator %(AuxSegment def1, Vector2 def2)
     *      Function: Returns the smallest segment out of the list substracted.
     *      Usefulness: To quickly with an operation get the smallest substracted section.
     *      
     * static AuxSegment operator %(AuxSegment def1, AuxLine def2)
     *      Function: Returns the largest segment out of the list substracted.
     *      Usefulness: To quickly with an operation get the smallest substracted section.
     *      
     * static AuxSegment operator %(AuxSegment def1, AuxSegment def2)
     *      Function: Returns the smallest segment out of the list substracted.
     *      Usefulness: To quickly with an operation get the smallest substracted section.
     * */
    public static AuxSegment operator %(AuxSegment def1, Vector2 def2)
    {
        return (def1 - def2).Min(Auxp.i.SqrLength, NaN);
    }
    public static AuxSegment operator %(AuxSegment def1, AuxLine def2)
    {
        return (def1 - def2).Min(Auxp.i.SqrLength, NaN);
    }
    public static AuxSegment operator %(AuxSegment def1, AuxSegment def2)
    {
        return (def1 - def2).Min(Auxp.i.SqrLength, NaN);
    }

}


/*
 * Struct AuxWideLine
 *      This struct simulates the form of a Line wit a position, direction in a 2D environment (ignoring Z) and a width.
 *      This Line is defined by two points like it's a segment, but it's only to mark the position and rotation; plus the size.
 * */
public struct AuxWideLine
{
    //Attributes:
    public Vector2 p1;
    public Vector2 p2;
    public float size;


    //Properties:
    public Vector2 v { get { return p2 - p1; } }
    public AuxLine Line { get { return new AuxLine(p1, p2); } }
    public AuxLine Border1 { get { return new AuxLine(p1.Offset(v.Perpendicular(), -size / 2), p2.Offset(v.Perpendicular(), -size / 2)); } }
    public AuxLine Border2 { get { return new AuxLine(p1.Offset(v.Perpendicular(), size / 2), p2.Offset(v.Perpendicular(), size / 2)); } }
    public static AuxWideLine NaN { get { return new AuxWideLine(AuxeUnity.NaN, AuxeUnity.NaN, 0f); } }


    //Constructors:
    public AuxWideLine(Vector2 vec2, float nsz) : this(Vector2.zero, vec2, nsz) { }
    public AuxWideLine(Vector2 vec1, Vector2 vec2, float nsz)
    {
        p1 = vec1;
        p2 = vec2;
        size = new float[] { Auxf.i.MINIMUM, nsz }.Max();
    }
    public AuxWideLine(Vector2 translate, float rotate, float nsz) : this(translate, translate + rotate.AngleDeg(), nsz) { }


    //Public Functions:
    
    /*
     * bool Equals (AuxWideLine def)
     *      Function: Returns whether the wide lines are similar (position, rotation and width)
     *      Usefulness: To quickly check if two wide lines are similar.
     * */
    public bool Equals(AuxWideLine def)
    {
        return IsInside(def.p1) && IsInside(def.p2) && size == def.size;
    }

    /*
     * bool IsInside (Vector2 vec)
     *      Function: Returns whether the point is inside the wide line.
     *      Usefulness: To quickly calculate whether a point is inside the wide line.
     *      
     * bool IsInside (AuxSegment seg)
     *      Function: Returns whether the segment is inside the wide line.
     *      Usefulness: To quickly calculate whether a segment is inside the wide line.
     * */
    public bool IsInside(Vector2 vec)
    {
        AuxLine al = new AuxLine(vec, vec + v.Perpendicular());
        AuxSegment seg = new AuxSegment(al * Border1, al * Border2);
        return seg.IsInside(vec);
    }
    public bool IsInside(AuxSegment seg)
    {
        return IsInside(seg.p1) && IsInside(seg.p2);
    }

    /*
     * bool Intersects (AuxLine def)
     *      Function: Returns whether the wide line and a line intersect. Parallels never intersect.
     *      Usefulness: To quickly see if a line and a wide line intersect.
     *      
     * bool Intersects (AuxSegment def)
     *      Function: Returns whether the wide line and a segment intersect. Being inside also counts.
     *      Usefulness: To quickly see if a segment and a wide line intersect
     *      
     * bool Intersects (AuxWideLine def)
     *      Function: Returns whether two wide lines intersect. Parallels never intersect.
     *      Usefulness: To quickly see if two wide lines intersect.
     * */
    public bool Intersects(AuxLine def)
    {
        return Line.Intersects(def);
    }
    public bool Intersects(AuxSegment seg)
    {
        return seg.Intersects(Border1) || seg.Intersects(Border2) || IsInside(seg);
    }
    public bool Intersects(AuxWideLine def)
    {
        return Line.Intersects(def.Line);
    }


    //Reference Functions (to allow distributive calling. These will be defined in their respective original callings):
    public bool Intersects(AuxPolygon def)
    {
        return def.Intersects(this);
    }
    public bool Intersects(AuxMesh def)
    {
        return def.Intersects(this);
    }

    public AuxPolygon Dot(AuxWideLine def2)
    {
        return this * def2;
    }
    public AuxMesh Dot(AuxPolygon def2)
    {
        return this * def2;
    }
    public AuxMesh Dot(AuxMesh def2)
    {
        return this * def2;
    }


    //Operators (Dot):

    /*
     * static AuxSegment operator *(AuxWideLine def1, AuxLine def2) / static Vector2 operator *(AuxLine def2, AuxWideLine def1)
     *      Function: Returns the intersection segment between a wide line and a line, as long as they intersect.
     *      Otherwise, it returns AuxSegment.NaN.
     *      Usefulness: To quickly with an operation get the intersection section.
     * */
    public static AuxSegment operator *(AuxWideLine def1, AuxLine def2)
    {
        return def1.Intersects(def2)? new AuxSegment(def1.Border1 * def2, def1.Border2 * def2) : AuxSegment.NaN;
    }
    public static AuxSegment operator *(AuxLine def2, AuxWideLine def1)
    {
        return def1 * def2;
    }

    /*
     * static AuxSegment operator *(AuxWideLine def1, AuxSegment def2) / static Vector2 operator *(AuxSegment def2, AuxWideLine def1)
     *      Function: Returns the intersection segment between a wide line and a segment, as long as they intersect.
     *      Otherwise, it returns AuxSegment.NaN.
     *      Usefulness: To quickly with an operation get the intersection section.
     * */
    public static AuxSegment operator *(AuxWideLine def1, AuxSegment def2)
    {
        if (!def1.Intersects(def2))
            return AuxSegment.NaN;

        if (def1.IsInside(def2))
            return def2;
        else if (def1.IsInside(def2.p1))
            return new AuxSegment(def2.p1, def2.Intersects(def1.Border1) ? def1.Border1 * def2 : def1.Border2 * def2);
        else if (def2.IsInside(def2.p2))
            return new AuxSegment(def2.p2, def2.Intersects(def1.Border1) ? def1.Border1 * def2 : def1.Border2 * def2);
        else
            return def1 * def2.Line;
    }
    public static AuxSegment operator *(AuxSegment def2, AuxWideLine def1)
    {
        return def1 * def2;
    }

    /*
     * static AuxSegment operator *(AuxWideLine def1, AuxWideLine def2)
     *      Function: Returns the intersection polygon between two wide lines, as long as they intersect.
     *      Otherwise, it returns null.
     *      Usefulness: To quickly with an operation get the intersection section.
     * */
    public static AuxPolygon operator *(AuxWideLine def1, AuxWideLine def2)
    {
        if (!def1.Intersects(def2))
            return null;

        AuxPolygon list = new AuxPolygon();
        list.Add(def1.Border1 * def2.Border1);
        list.Add(def1.Border1 * def2.Border2);
        list.Add(def1.Border2 * def2.Border2);
        list.Add(def1.Border2 * def2.Border1);
        return list;
    }


    //Operators (rest):
    /*
     * static List<AuxSegment> operator -(AuxSegment def2, AuxWideLine def1)
     *      Function: Returns a list with one or two segments depending of the wide line position when substracting.
     *      If the segment doesn't intersects, if returns itself in a list. If it's inside the wide line, it returns null.
     *      Usefulness: To quickly with an operation get the substracted section.
     * */
    public static List<AuxSegment> operator -(AuxSegment def2, AuxWideLine def1)
    {
        return def1.Intersects(def2)? def2 - def1 * def2 : def2.List();
    }

    /*
     * static AuxSegment operator /(AuxSegment def1, AuxWideLine def2)
     *      Function: Returns the largest segment out of the list substracted.
     *      Usefulness: To quickly with an operation get the largest substracted section.
     * */
    public static AuxSegment operator /(AuxSegment def1, AuxWideLine def2)
    {
        return (def1 - def2).Max(Auxp.i.SqrLength, AuxSegment.NaN);
    }

    /*
     * static AuxSegment operator %(AuxSegment def1, AuxWideLine def2)
     *      Function: Returns the smallest segment out of the list substracted.
     *      Usefulness: To quickly with an operation get the smallest substracted section.
     * */
    public static AuxSegment operator %(AuxSegment def1, AuxWideLine def2)
    {
        return (def1 - def2).Min(Auxp.i.SqrLength, AuxSegment.NaN);
    }

}


/*
 * Class AuxPolygon : List<Vector2>
 *      This class simulates a polygon, without any hole inside.
 *      It is defined by a list of points that are each one connected to the previous and next one, and the last with the first one (minimum 3).
 * */
public class AuxPolygon : List<Vector2>
{
    //Properties:

    /*
     * float Area:
     *      Property: Returns the area of the polygon in units ^ 2.
     *      Usefulness: To quickly get the area of a polygon.
     * */
    public float Area { get { return p_Area(this).Abs(); } }

    /*
     * List<AuxTriangle> Triangulate:
     *      Property: Returns a list of triangles that compose the polygon's form and their particular size.
     *      Usefulness: To automatically create a mesh to be drawn with the exact form.
     *      This is done so they can be instantiated (i.e. Auxg.i.CreateMesh) and shown onscreen.
     * */
    public List<AuxTriangle> Triangulate { get
        {
            List<int> indices = new List<int>();
            List<Vector2> m_points = new List<Vector2>(this);

            int n = m_points.Count;
            if (n < 3)
                return p_Turn(indices);

            int[] V = new int[n];
            if (p_Area(m_points) > 0)
                for (int v = 0; v < n; v++)
                    V[v] = v;
            else
                for (int v = 0; v < n; v++)
                    V[v] = (n - 1) - v;

            int nv = n;
            int count = 2 * nv;
            for (int m = 0, v = nv - 1; nv > 2;)
            {
                if ((count--) <= 0)
                    return p_Turn(indices);

                int u = v;
                if (nv <= u)
                    u = 0;
                v = u + 1;
                if (nv <= v)
                    v = 0;
                int w = v + 1;
                if (nv <= w)
                    w = 0;

                if (p_Snip(u, v, w, nv, V, m_points))
                {
                    int a, b, c, s, t;
                    a = V[u];
                    b = V[v];
                    c = V[w];
                    indices.Add(a);
                    indices.Add(b);
                    indices.Add(c);
                    m++;
                    for (s = v, t = v + 1; t < nv; s++, t++)
                        V[s] = V[t];
                    nv--;
                    count = 2 * nv;
                }
            }
            indices.Reverse();
            return p_Turn(indices);
        }
    }

    /*
     * List<AuxSegment> Segments:
     *      Property: Returns a list of segments made from the points of the polygon.
     *      Usefulness: To automatically get the segments quickly. It is used for intersections.
     * */
    public List<AuxSegment> Segments { get
        {
            var list = new List<AuxSegment>();
            for (int i=0; i<Count; i++)
                list.Add(new AuxSegment(this[i], this[(i + 1) % Count]));
            return list;
        }
    }

    /*
     * AuxPolygon Everything:
     *      Property: Returns a polygon that contains everything in the space, like a plane.
     *      Usefulness: To operations that require substracting. It is used in the Inverse function in AuxMesh.
     * */
    public static AuxPolygon Everything
    {
        get
        {
            return new AuxPolygon(new Vector2(float.MinValue, float.MinValue), new Vector2(float.MinValue, float.MaxValue),
                new Vector2(float.MaxValue, float.MaxValue), new Vector2(float.MaxValue, float.MinValue));
        }
    }

    /*
     * AuxPolygon RegularPolygon (float size, int faces, Vector2 offset):
     *      Function: Returns a regular polygon with a specific number of faces with the same distance to the center point
     *      to a certain distance (size). The center offset can be moved too.
     *      Usefulness: To quickly create a regular polygon in case that's what's needed.
     * */
    public static AuxPolygon RegularPolygon(float size, int faces, Vector2 offset)
    {
        if (faces < 3)
            return null;

        size = Mathf.Max(Auxf.i.MINIMUM, size);
        AuxPolygon ap = new AuxPolygon();
        for (int i = 0; i < faces; i++)
            ap.Add(offset + (360f * i / faces).AngleDeg() * size);
        return ap;
    }


    //Constructors:
    public AuxPolygon () : base() { }
    public AuxPolygon (IEnumerable<Vector2> enumer) : base(enumer) { }
    public AuxPolygon(params Vector2[] enumer) : this(enumer as IEnumerable<Vector2>) { }


    //Public Functions:
    public int IndexOfBeg(AuxSegment seg)
    {
        return Segments.IndexOf(seg);
    }
    public int IndexOfEnd(AuxSegment seg)
    {
        int i = Segments.IndexOf(seg);
        return i > -1 ? i + 1 : -1;
    }

    /*
     * bool IsInside (Vector2 vec)
     *      Function: Returns whether the point is inside the polygon.
     *      Usefulness: To quickly calculate whether a point is inside the polygon.
     *      
     * bool IsInside (AuxSegment def)
     *      Function: Returns whether the segment is inside the polygon.
     *      Usefulness: To quickly calculate whether a segment is inside the polygon.
     *      
     * bool IsInside (AuxPolygon def, bool spin)
     *      Function: Returns whether the input polygon is inside the main polygon.
     *      If "spin" is true, then it checks whether the main polygon is inside the input polygon.
     *      Usefulness: To check if a polygon is contained inside another quickly, and also do opposites for Delegate functions.
     * */
    public bool IsInside (Vector2 vec)
    {
        return (this * new AuxLine(vec, 0)).IsAny(vec, Auxp.i.IsInside);
    }
    public bool IsInside (AuxSegment def)
    {
        return (this * def.Line).IsAny(def.IsInside, true);
    }
    public bool IsInside(AuxPolygon def, bool spin = false)
    {
        if (spin)
            return Segments.IsAll(def.IsInside);
        else
            return def.Segments.IsAll(IsInside);
    }

    /*
     * bool Intersects (AuxLine def)
     *      Function: Returns whether the polygon and a line intersect.
     *      Usefulness: To quickly see if a line and a polygon intersect.
     *      
     * bool Intersects (AuxSegment def)
     *      Function: Returns whether the polygon and a segment intersect.
     *      Usefulness: To quickly see if a segment and a polygon intersect.
     *      
     * bool Intersects (AuxWideLine def)
     *      Function: Returns whether the polygon and a wide line intersect.
     *      Usefulness: To quickly see if a wide line and a polygon intersect.
     *      
     * bool Intersects (AuxPolygon def)
     *      Function: Returns whether two polygons intersect.
     *      Usefulness: To quickly see if two polygons intersect.
     * */
    public bool Intersects (AuxLine def)
    {
        return Segments.IsAny(def.Intersects);
    }
    public bool Intersects(AuxSegment def)
    {
        return Segments.IsAny(def.Intersects) || IsInside(def);
    }
    public bool Intersects(AuxWideLine def)
    {
        return Segments.IsAny(def.Intersects);
    }
    public bool Intersects(AuxPolygon def)
    {
        return Segments.IsAny<AuxSegment, AuxSegment>(Auxp.i.Intersects, def.Segments.IsAny) || IsInside(def);
    }


    //Reference Functions (to allow distributive calling. These will be defined in their respective original callings):
    public bool IsInside(AuxMesh def)
    {
        return def.IsAll(IsInside, false);
    }

    public bool Intersects(AuxMesh def)
    {
        return def.Intersects(this);
    }

    public List<AuxSegment> Dot(AuxSegment def2)
    {
        return this * def2;
    }
    public AuxMesh Dot(AuxPolygon def2)
    {
        return this * def2;
    }
    public AuxMesh Dot(AuxMesh def2)
    {
        return this * def2;
    }

    public AuxMesh Substract(AuxPolygon def2)
    {
        return this - def2;
    }
    public AuxMesh Substract(AuxMesh def2)
    {
        return this - def2;
    }


    //Operators (Dot):

    /*
     * static List<AuxSegment> operator *(AuxPolygon pol, AuxLine def) / static List<AuxSegment> operator *(AuxLine def, AuxPolygon pol)
     *      Function: Returns the intersection segment list between a polygon and a line, as long as they intersect.
     *      This will correctly create a list of segments depending of the form of the polygon.
     *      Otherwise, it returns null.
     *      Usefulness: To quickly with an operation get the intersection section.
     * */
    public static List<AuxSegment> operator *(AuxPolygon pol, AuxLine def)
    {
        return pol.Intersects(def) ? AuxSegment.Pair(pol.Segments.Execute(def.Dot).RemoveAllReturn(Vector2.negativeInfinity))
            : new List<AuxSegment>();
    }
    public static List<AuxSegment> operator *(AuxLine def, AuxPolygon pol)
    {
        return pol * def;
    }

    /*
     * static List<AuxSegment> operator *(AuxPolygon pol, AuxSegment def) / static List<AuxSegment> operator *(AuxSegment def, AuxPolygon pol)
     *      Function: Returns the intersection segment list between a polygon and a segment, as long as they intersect.
     *      This will correctly create a list of segments depending of the form of the polygon and the segment's length.
     *      Otherwise, it returns null.
     *      Usefulness: To quickly with an operation get the intersection section.
     * */
    public static List<AuxSegment> operator *(AuxPolygon pol, AuxSegment def)
    {
        return pol.Intersects(def) ?
            (pol.IsInside(def) ? def.List() : AuxSegment.Pair(pol.Segments.Execute(def.Dot).RemoveAllReturn(Vector2.negativeInfinity)))
            : new List<AuxSegment>();
    }
    public static List<AuxSegment> operator *(AuxSegment def, AuxPolygon pol)
    {
        return pol * def;
    }

    /*
     * static AuxMesh operator *(AuxPolygon pol, AuxWideLine def) / static AuxMesh operator *(AuxWideLine def, AuxPolygon pol)
     *      Function: Returns the intersection mesh between a polygon and a wide line, as long as they intersect.
     *      This will correctly create a mesh with different polygons depending of the form of the polygon and the wide line.
     *      Otherwise, it returns null.
     *      Usefulness: To quickly with an operation get the intersection section.
     * */
    public static AuxMesh operator *(AuxPolygon pol, AuxWideLine def)
    {
        var list = (pol * def.Border1).AddReturn(pol * def.Border2);
        var points = pol.Filter(def.IsInside).AddReturn(pol.p_TakeInnerPoints(list.Points(), def.IsInside, true));
        return pol.p_CutPolygon(list, points);
    }
    public static AuxMesh operator *(AuxWideLine def, AuxPolygon pol)
    {
        return pol * def;
    }

    /*
     * static AuxMesh operator *(AuxPolygon pol, AuxPolygon def)
     *      Function: Returns the intersection mesh between two polygons, as long as they intersect.
     *      This will correctly create a mesh with different polygons depending of the form of the polygons to intersect.
     *      Otherwise, it returns null.
     *      Usefulness: To quickly with an operation get the intersection section.
     * */
    public static AuxMesh operator *(AuxPolygon pol, AuxPolygon def)
    {
        var list = def.Segments.Execute(pol.Dot).Combine();
        var points = pol.Filter(def.IsInside).AddReturn(pol.p_TakeInnerPoints(list.Points(), def.IsInside, true));
        return pol.p_CutPolygon(list, points);
    }


    //Operators (rest):

    /*
     * static AuxMesh operator +(AuxPolygon pol, AuxPolygon def)
     *      Function: Returns a mesh by combining two polygons.
     *      If one is inside the other, the result is the largest one.
     *      If they don't intersect, the result is a mesh with both polygons.
     *      If they intersect, it will create one unique polygon. If there are empty holes, those will be inserted as negatives.
     *      Usefulness: To quickly with an operation get the added section.
     * */
    public static AuxMesh operator +(AuxPolygon pol, AuxPolygon def)
    {
        if (pol.Count < 3 || def.Count < 3)
            return pol.Count >= 3 ? pol : (def.Count >= 3 ? def : null);
        if (!pol.Intersects(def))
            return new AuxMesh(pol, def);
        else if (pol.IsInside(def))
            return pol;
        else if (def.IsInside(pol))
            return def;

        var mesh = new AuxMesh();
        var segs = def.Segments.Execute(pol.Dot).Combine();
        var mainPoints = new List<Vector2>(pol).AddReturn(def);
        AuxPolygon ap;
        AuxPolygon[] which = new AuxPolygon[] { pol, def };
        int sel;
        while (mainPoints.Count > 0)
        {
            ap = new AuxPolygon();
            ap.Add(mainPoints[0]);
            Vector2 currentPoint = mainPoints[0];
            sel = which[0].Segments.IsAny(Auxp.i.IsInside, mainPoints[0], true) ? 0 : 1;
            AuxSegment currentSegment = which[sel].Segments.Get(Auxp.i.IsInside, mainPoints[0], true,AuxSegment.NaN);
            
            while (true)
            {
                AuxSegment ptseg = new AuxSegment(currentPoint, currentSegment.p2);

                if (ptseg.p1 != mainPoints[0] && ptseg.IsInside(mainPoints[0]))
                    break;

                var inter = segs.Filter(ptseg.Intersects);
                inter = inter.RemoveReturn(inter.Filter(currentPoint, Auxp.i.IsInside));
                if (inter.Count > 0)
                {
                    int i = inter.Execute(ptseg.Nearest, true).MinIndex(Vector2.Distance, ptseg.p1);
                    currentPoint = inter[i].Nearest(ptseg);
                    ap.Add(currentPoint);
                    sel = (sel + 1) % 2;
                    var part = which[sel].Segments.Get(currentPoint, Auxp.i.IsInside, AuxSegment.NaN) - currentPoint;
                    currentSegment = part[0].IsInside(inter[i]) ? part[1] : part[0];
                }
                else
                {
                    ap.Add(ptseg.p2);
                    if (mainPoints.Contains(ptseg.p2))
                        mainPoints.Remove(ptseg.p2);
                    currentPoint = ptseg.p2;
                    currentSegment = which[sel].Segments.Next(currentPoint);
                }
            }
            mainPoints.RemoveAt(0);
            mesh.Add(ap);
        }
        if (mesh.Count > 0)
        {
            ap = mesh.Max(Auxp.i.Area, null);
            mesh.Remove(ap);
            AuxMesh posMesh = new AuxMesh(ap);
            posMesh.Negatives = mesh;
            return posMesh;
        }
        return null;
    }

    /*
     * static AuxMesh operator -(AuxPolygon pol, AuxLine def)
     *      Function: Returns a mesh with the parts substracted by the line separated and added.
     *      Usefulness: To quickly with an operation get the substracted section.
     *      
     * static AuxMesh operator -(AuxPolygon pol, AuxSegment def)
     *      Function: Returns a mesh with the parts substracted by the segment separated and added.
     *      The segment must cut the entirety of a polygon's part to separate it into two or more parts.
     *      Usefulness: To quickly with an operation get the substracted section.
     *      
     * static List<AuxSegment> operator -(AuxSegment def, AuxPolygon def)
     *      Function: Returns a list of segments with the parts inside the polygon substracted.
     *      If the segment is inside the polygon, it returns null.
     *      Usefulness: To quickly with an operation get the substracted section.
     *      
     * static AuxMesh operator -(AuxPolygon pol, AuxWideLine def)
     *      Function: Returns a mesh with the parts substracted by the wide line cut.
     *      This wide line can eliminate the whole polygon, or at the very least separate big chunks of it and delete area.
     *      Usefulness: To quickly with an operation get the substracted section.
     *      
     * static AuxMesh operator -(AuxPolygon pol, AuxPolygon def)
     *      Function: Returns a mesh with the parts substracted by other polygon.
     *      If they don't intersect, the Mesh will only have the whole polygon.
     *      If the polygon to be cut is inside the substracter, it returns null.
     *      If the substracter is inside the polygon, it is inserted as a negative polygon in the mesh.
     *      Usefulness: To quickly with an operation get the substracted section.
     * */
    public static AuxMesh operator -(AuxPolygon pol, AuxLine def)
    {
        return pol.p_CutPolygon(pol * def, pol);
    }
    public static AuxMesh operator -(AuxPolygon pol, AuxSegment def)
    {
        var list = (pol * def);

        for (int i = list.Count; i >= 0; i--)
            if (!list[i].Points.IsAll<Vector2, AuxSegment>(Auxp.i.IsInside, pol.Segments.IsAny))
                list.RemoveAt(i);
        return list.Count == 0 ? pol : pol.p_CutPolygon(list, pol);
    }
    public static List<AuxSegment> operator -(AuxSegment def, AuxPolygon pol)
    {
        if (pol.IsInside(def))
            return null;
        if (!pol.Intersects(def))
            return def.List();
        return def - def * pol;
    }
    public static AuxMesh operator -(AuxPolygon pol, AuxWideLine def)
    {
        var list = (pol * def.Border1).AddReturn(pol * def.Border2);
        var points = pol.RemoveReturn(pol.Filter(def.IsInside)).AddReturn(pol.p_TakeInnerPoints(list.Points(), def.IsInside, false));
        return pol.p_CutPolygon(list, points);
    }
    public static AuxMesh operator -(AuxPolygon pol, AuxPolygon def)
    {
        AuxMesh mesh = new AuxMesh();
         if (def.IsInside(pol))
            return null;
        else if(pol.IsInside(def))
        {
            mesh.Add(pol);
            mesh.Negatives.Add(def);
        }
        else if (pol.Intersects(def))
        {
            var list = def.Segments.Execute(pol.Dot).Combine();
            var points = pol.RemoveReturn(pol.Filter(def.IsInside)).AddReturn(pol.p_TakeInnerPoints(list.Points(), def.IsInside, false));
            return pol.p_CutPolygon(list, points);
        }
         else
            mesh.Add(pol);
        return mesh;

    }

    /*
     * static AuxPolygon operator /(AuxPolygon pol, AuxLine def)
     *      Function: Returns the biggest polygon out of the list substracted.
     *      Usefulness: To quickly with an operation get the largest substracted section.
     *      
     * static AuxPolygon operator /(AuxPolygon pol, AuxSegment def)
     *      Function: Returns the biggest polygon out of the list substracted.
     *      Usefulness: To quickly with an operation get the largest substracted section.
     *      
     * static AuxSegment operator /(AuxSegment def, AuxPolygon def)
     *      Function: Returns the largest segment out of the list substracted.
     *      Usefulness: To quickly with an operation get the largest substracted section.
     *      
     * static AuxPolygon operator /(AuxPolygon pol, AuxWideLine def)
     *      Function: Returns the biggest polygon out of the list substracted.
     *      Usefulness: To quickly with an operation get the largest substracted section.
     *      
     * static AuxPolygon operator /(AuxPolygon pol, AuxPolygon def)
     *      Function: Returns the biggest polygon out of the list substracted.
     *      Usefulness: To quickly with an operation get the largest substracted section.
     * */
    public static AuxPolygon operator /(AuxPolygon pol, AuxLine def)
    {
        return (pol - def).Max(Auxp.i.Area, null);
    }
    public static AuxPolygon operator /(AuxPolygon pol, AuxSegment def)
    {
        return (pol - def).Max(Auxp.i.Area, null);
    }
    public static AuxSegment operator /(AuxSegment pol, AuxPolygon def)
    {
        return (pol - def).Max(Auxp.i.SqrLength, AuxSegment.NaN);
    }
    public static AuxPolygon operator /(AuxPolygon pol, AuxWideLine def)
    {
        return (pol - def).Max(Auxp.i.Area, null);
    }
    public static AuxPolygon operator /(AuxPolygon pol, AuxPolygon def)
    {
        return (pol - def).Max(Auxp.i.Area, null);
    }

    /*
     * static AuxPolygon operator %(AuxPolygon pol, AuxLine def)
     *      Function: Returns the smallest polygon out of the list substracted.
     *      Usefulness: To quickly with an operation get the smallest substracted section.
     *      
     * static AuxPolygon operator %(AuxPolygon pol, AuxSegment def)
     *      Function: Returns the smallest polygon out of the list substracted.
     *      Usefulness: To quickly with an operation get the smallest substracted section.
     *      
     * static AuxSegment operator %(AuxSegment def, AuxPolygon def)
     *      Function: Returns the smallest segment out of the list substracted.
     *      Usefulness: To quickly with an operation get the smallest substracted section.
     *      
     * static AuxPolygon operator %(AuxPolygon pol, AuxWideLine def)
     *      Function: Returns the smallest polygon out of the list substracted.
     *      Usefulness: To quickly with an operation get the smallest substracted section.
     *      
     * static AuxPolygon operator %(AuxPolygon pol, AuxPolygon def)
     *      Function: Returns the smallest polygon out of the list substracted.
     *      Usefulness: To quickly with an operation get the smallest substracted section.
     * */
    public static AuxPolygon operator %(AuxPolygon pol, AuxLine def)
    {
        return (pol - def).Min(Auxp.i.Area, null);
    }
    public static AuxPolygon operator %(AuxPolygon pol, AuxSegment def)
    {
        return (pol - def).Min(Auxp.i.Area, null);
    }
    public static AuxSegment operator %(AuxSegment pol, AuxPolygon def)
    {
        return (pol - def).Min(Auxp.i.SqrLength, AuxSegment.NaN);
    }
    public static AuxPolygon operator %(AuxPolygon pol, AuxWideLine def)
    {
        return (pol - def).Min(Auxp.i.Area, null);
    }
    public static AuxPolygon operator %(AuxPolygon pol, AuxPolygon def)
    {
        return (pol - def).Min(Auxp.i.Area, null);
    }
    

    //Private functions:
    private List<AuxTriangle> p_Turn(List<int> hello)
    {
        List<AuxTriangle> list = new List<AuxTriangle>();
        if (hello.Count % 3 != 0)
            return list;

        for (int i = 0; i < hello.Count; i += 3)
            list.Add(new AuxTriangle(this[hello[i]], this[hello[i + 1]], this[hello[i + 2]]));

        return list;
    }
    private float p_Area(List<Vector2> m_points)
    {
        int n = m_points.Count;
        float A = 0.0f;
        for (int p = n - 1, q = 0; q < n; p = q++)
        {
            Vector2 pval = m_points[p];
            Vector2 qval = m_points[q];
            A += pval.x * qval.y - qval.x * pval.y;
        }
        return (A * 0.5f);
    }
    private bool p_Snip(int u, int v, int w, int n, int[] V, List<Vector2> m_points)
    {
        int p;
        Vector2 A = m_points[V[u]];
        Vector2 B = m_points[V[v]];
        Vector2 C = m_points[V[w]];
        if (Mathf.Epsilon > (((B.x - A.x) * (C.y - A.y)) - ((B.y - A.y) * (C.x - A.x))))
            return false;
        for (p = 0; p < n; p++)
        {
            if ((p == u) || (p == v) || (p == w))
                continue;
            Vector2 P = m_points[V[p]];
            if (p_InsideTriangle(A, B, C, P))
                return false;
        }
        return true;
    }
    private bool p_InsideTriangle(Vector2 A, Vector2 B, Vector2 C, Vector2 P)
    {
        float ax, ay, bx, by, cx, cy, apx, apy, bpx, bpy, cpx, cpy;
        float cCROSSap, bCROSScp, aCROSSbp;

        ax = C.x - B.x; ay = C.y - B.y;
        bx = A.x - C.x; by = A.y - C.y;
        cx = B.x - A.x; cy = B.y - A.y;
        apx = P.x - A.x; apy = P.y - A.y;
        bpx = P.x - B.x; bpy = P.y - B.y;
        cpx = P.x - C.x; cpy = P.y - C.y;

        aCROSSbp = ax * bpy - ay * bpx;
        cCROSSap = cx * apy - cy * apx;
        bCROSScp = bx * cpy - by * cpx;

        return ((aCROSSbp >= 0.0f) && (bCROSScp >= 0.0f) && (cCROSSap >= 0.0f));
    }
    private List<Vector2> p_TakeInnerPoints(List<Vector2> referencePoints, TDelegate<bool, Vector2> action, bool inside = true)
    {
        var points = new List<Vector2>();
        foreach (AuxSegment seg in Segments)
        {
            var filt = referencePoints.Filter(seg.IsInside, false);
            if (filt.Count >= 2)
            {
                filt.Sort(new Vector2Comparer());
                for (int i = 0; i < filt.Count - 1; i++)
                    if (action((filt[i] + filt[i + 1]) / 2f) == inside)
                        points.Add((filt[i] + filt[i + 1]) / 2f);
            }
        }
        return points;
    }
    private AuxMesh p_CutPolygon(List<AuxSegment> segs, List<Vector2> points)
    {
        if (segs == null || segs.Count == 0)
            return this;

        var mainPoints = points.Clone();
        if (mainPoints.Count == 0 || !mainPoints.IsAll<Vector2, AuxSegment>(Auxp.i.IsInside, Segments.IsAny))
            return null;
        
        AuxMesh mesh = new AuxMesh();

        int xx = 0;
        while (mainPoints.Count > 0)
        {
            if (mesh.IsInside(mainPoints[0]))
            {
                mainPoints.RemoveAt(0);
                continue;
            }
            AuxPolygon ap = new AuxPolygon();
            ap.Add(mainPoints[0]);
            Vector2 currentPoint = mainPoints[0], begPoint, endPoint;
            AuxSegment currentSegment = Segments.Get(Auxp.i.IsInside, mainPoints[0], true, AuxSegment.NaN);
            int yy = 0;
            while (true)
            {
                AuxSegment ptseg = new AuxSegment(currentPoint, currentSegment.p2);

                if (ptseg.p1 != mainPoints[0] && ptseg.IsInside(mainPoints[0]))
                    break;

                var inter = segs.Filter(ptseg.Intersects);
                inter = inter.RemoveReturn(inter.Filter(currentPoint, Auxp.i.IsInside));
                if (inter.Count > 0)
                {
                    int i = inter.Execute(ptseg.Nearest, true).MinIndex(Vector2.Distance, ptseg.p1);
                    begPoint = inter[i].Nearest(ptseg);
                    endPoint = inter[i].Further(begPoint);
                    ap.Add(begPoint);
                    int zz = 0;
                    while (!(inter = segs.Connection(inter[i], endPoint).List())[0].IsNaN())
                    {
                        i = 0;
                        begPoint = endPoint;
                        endPoint = inter[0].Further(begPoint);
                        ap.Add(begPoint);
                        if (zz > 100)
                        {
                            Debug.Log("zz");
                            return null;
                        }
                    }
                    ap.Add(endPoint);

                    currentPoint = endPoint;
                    currentSegment = Segments.Get(Auxp.i.IsInside, currentPoint, true, AuxSegment.NaN);
                }
                else
                {
                    ap.Add(ptseg.p2);
                    if (mainPoints.Contains(ptseg.p2))
                        mainPoints.Remove(ptseg.p2);
                    currentPoint = ptseg.p2;
                    currentSegment = Segments.Next(currentSegment, AuxSegment.NaN);
                }
                yy++;
                if (yy > 100)
                {
                    Debug.Log("yy");
                    return null;
                }
            }
            mainPoints.RemoveAt(0);
            mesh.Add(ap);
            xx++;
            if (xx > 100)
            {
                Debug.Log("xx");
                return null;
            }
        }
        
        return mesh.Count > 0 ? mesh : null;
    }

}


/*
 * Class AuxMesh : List<AuxPolygon>
 *      This class simulates a set of polygons that together create a complex mesh to be modified and reproduded.
 *      It is defined by a list of polygons that by definition should be separated, otherwise they are combined. At least one is needed.
 *      This class also prepares holes in polygons of the meshes, which are saved in an inner AuxMesh called "Negatives".
 *      These Negative parts will be considered as holes and will be kept in mind in all the operations and restructuring of the mesh's form.
 *      These parts can also have their own filled content again recursively in their Negatives.
 * */
public class AuxMesh : List<AuxPolygon>
{
    //Attributes:
    public AuxMesh Negatives;


    //Properties:

    /*
     * float Area:
     *      Property: Returns the area of the mesh in units ^ 2,
     *      as the summation of all the polygons and substracting the summation of the negatives.
     *      Usefulness: To quickly get the area of a mesh.
     * */
    public float Area { get { return this.Summation(Auxp.i.Area) - Negatives.Summation(Auxp.i.Area); } }

    /*
     * List<List<AuxTriangle>> Triangulate:
     *      Property: Returns a list composed of two list of triangles:
     *      The first one contains the triangles of all the visible polygons, including the parts that should be invisible by negatives.
     *      The second one contains the triangles of all the negative polygons, so when creating the mesh they can hide the visible ones.
     *      Usefulness: To automatically create a mesh to be drawn with the exact form and with the exact parameters to substract.
     *      This is done so they can be instantiated (i.e. Auxg.i.CreateMesh) and shown onscreen.
     * */
    public List<List<AuxTriangle>> Triangulate
    {
        get
        {
            return this.Execute(Auxp.i.Triangulate).Combine().List()
                .AddReturn(Negatives.Execute(Auxp.i.Triangulate).Combine());
        }
    }

    /*
     * float Inverse:
     *      Property: Returns the inverse of the Mesh, with the whole content being visible except the parts of the mesh.
     *      Usefulness: An useful function for some substract operations.
     * */
    public AuxMesh Inverse { get
        {
            AuxMesh copy = new AuxMesh(Negatives);
            copy.Negatives.AddRange(this);
            copy.Insert(0, AuxPolygon.Everything);
            return copy;
        }
    }

    /*
     * static implicit operator AuxMesh (AuxPolygon ap):
     *      Function: Turns a polygon into a mesh with only that polygon inserted.
     *      Usefulness: To not vorry about using the polygon in mesh functions..
     * */
    public static implicit operator AuxMesh (AuxPolygon ap) { return new AuxMesh(ap); }


    //Constructors:
    public AuxMesh() : base() { p_AuxMesh(); }
    public AuxMesh(IEnumerable<AuxPolygon> enumer) : base(enumer) { p_AuxMesh(); }
    public AuxMesh(params AuxPolygon[] enumer) : this(enumer as IEnumerable<AuxPolygon>) { }
    private void p_AuxMesh()
    {
        Negatives = new AuxMesh(false);
    }
    private AuxMesh(bool noNegative) : base() { }


    //Public Functions:

    /*
     * AuxMesh Clone ()
     *      Function: Returns a copy of the mesh.
     *      Usefulness: To quickly get an exact clone of the mesh and its parameters.
     * */
    public AuxMesh Clone()
    {
        AuxMesh clone = new AuxMesh(this);
        clone.Negatives = Negatives;
        return clone;
    }

    /*
     * bool IsInside (Vector2 vec)
     *      Function: Returns whether the point is inside the mesh.
     *      Negative parts are taken in mind.
     *      Usefulness: To quickly calculate whether a point is inside the mesh.
     *      
     * bool IsInside (AuxSegment def)
     *      Function: Returns whether the segment is inside the mesh.
     *      Negative parts are taken in mind.
     *      Usefulness: To quickly calculate whether a segment is inside the mesh.
     *      
     * bool IsInside (AuxPolygon def)
     *      Function: Returns whether polygon is inside the mesh.
     *      Negative parts are taken in mind.
     *      Usefulness: To quickly calculate whether a polygon is inside the mesh.
     *      
     * bool IsInside (AuxMesh def)
     *      Function: Returns whether the input mesh is inside the main mesh.
     *      If "spin" is true, then it checks whether the main mesh is inside the input mesh.
     *      Negative parts are taken in mind.
     *      Usefulness: To check if a mesh is contained inside another quickly, and also do opposites for Delegate functions.
     * */
    public bool IsInside(Vector2 def)
    {
        if (Count == 0)
            return false;
        AuxPolygon ap = this.Filter(def, Auxp.i.IsInside).Min(Auxp.i.Area, null);
        return ap != null && ap.Count > 0 && (Negatives.Count == 0 || !Negatives.Filter(def, Auxp.i.IsInside).IsAny(ap.IsInside, false));
    }
    public bool IsInside(AuxSegment def)
    {
        if (Count == 0)
            return false;
        AuxPolygon ap = this.Filter(def.IsInside).Min(Auxp.i.Area, null);
        return ap != null && ap.Count > 0 && (Negatives.Count == 0 || !Negatives.Filter(def.Intersects).IsAny(ap.IsInside, false));
    }
    public bool IsInside(AuxPolygon pol)
    {
        if (Count == 0)
            return false;
        AuxPolygon ap = this.Filter(pol.IsInside, true).Min(Auxp.i.Area, null);
        return ap != null && ap.Count > 0 && (Negatives.Count == 0 || !Negatives.Filter(pol.Intersects).IsAny(ap.IsInside, false));
    }
    public bool IsInside(AuxMesh pol, bool spin = false)
    {
        if (spin)
            return this.IsAll(pol.IsInside);
        else
            return pol.IsAll(IsInside);
    }

    /*
     * bool Intersects (AuxLine def)
     *      Function: Returns whether the mesh and a line intersect.
     *      Usefulness: To quickly see if a line and a mesh intersect.
     *      
     * bool Intersects (AuxSegment def)
     *      Function: Returns whether the mesh and a segment intersect.
     *      Usefulness: To quickly see if a segment and a mesh intersect.
     *      
     * bool Intersects (AuxWideLine def)
     *      Function: Returns whether the mesh and a wide line intersect.
     *      Usefulness: To quickly see if a wide line and a mesh intersect.
     *      
     * bool Intersects (AuxPolygon def)
     *      Function: Returns whether the mesh and a polygon intersect.
     *      Usefulness: To quickly see if a polygon and a mesh intersect.
     *      
     * bool Intersects (AuxMesh def)
     *      Function: Returns whether two meshes intersect.
     *      Usefulness: To quickly see if two meshes intersect.
     * */
    public bool Intersects(AuxLine def)
    {
        return this.IsAny(def.Intersects);
    }
    public bool Intersects(AuxSegment def)
    {
        if (Count == 0)
            return false;
        AuxPolygon ap = this.Filter(def.Intersects).Min(Auxp.i.Area, null);
        return ap != null && ap.Count > 0 && (Negatives.Count == 0 || !Negatives.Filter(def.IsInside).IsAny(ap.IsInside, false));
    }
    public bool Intersects(AuxWideLine def)
    {
        return this.IsAny(def.Intersects);
    }
    public bool Intersects(AuxPolygon pol)
    {
        if (Count == 0)
            return false;
        AuxPolygon ap = this.Filter(pol.Intersects).Min(Auxp.i.Area, null);
        return ap != null && ap.Count > 0 && (Negatives.Count == 0 || !Negatives.Filter(pol.IsInside, true).IsAny(ap.IsInside, false));
    }
    public bool Intersects(AuxMesh pol)
    {
        return pol.IsAny(Intersects);
    }


    //Reference Functions (to allow distributive calling. These will be defined in their respective original callings):
    public AuxMesh Dot(AuxMesh def2)
    {
        return this * def2;
    }
    
    public AuxMesh Substract(AuxMesh def2)
    {
        return this - def2;
    }


    //Operators (Dot):

    /*
     * static List<AuxSegment> operator *(AuxMesh pol, AuxLine def) / static List<AuxSegment> operator *(AuxLine def, AuxMesh pol)
     *      Function: Returns the intersection segment list between a mesh and a line, as long as they intersect.
     *      This will correctly create a list of segments depending of the form of the mesh.
     *      The negative parts are also kept in mind.
     *      Otherwise, it returns null.
     *      Usefulness: To quickly with an operation get the intersection section.
     * */
    public static List<AuxSegment> operator *(AuxMesh pol, AuxLine def)
    {
        return pol.p_CutSegments(pol.Execute(def.Dot).Combine());
    }
    public static List<AuxSegment> operator *(AuxLine def, AuxMesh pol)
    {
        return pol * def;
    }

    /*
     * static List<AuxSegment> operator *(AuxMesh pol, AuxSegment def) / static List<AuxSegment> operator *(AuxSegment def, AuxMesh pol)
     *      Function: Returns the intersection segment list between a mesh and a segment, as long as they intersect.
     *      This will correctly create a list of segments depending of the form of the mesh and the segment's length.
     *      The negative parts are also kept in mind.
     *      Otherwise, it returns null.
     *      Usefulness: To quickly with an operation get the intersection section.
     * */
    public static List<AuxSegment> operator *(AuxMesh pol, AuxSegment def)
    {
        return pol.p_CutSegments(pol.Execute(def.Dot).Combine());
    }
    public static List<AuxSegment> operator *(AuxSegment def, AuxMesh pol)
    {
        return pol * def;
    }

    /*
     * static AuxMesh operator *(AuxMesh pol, AuxWideLine def) / static AuxMesh operator *(AuxWideLine def, AuxMesh pol)
     *      Function: Returns the intersection mesh between a mesh and a wide line, as long as they intersect.
     *      This will correctly create a mesh with different polygons depending of the form of the mesh and the wide line.
     *      The negative parts are also kept in mind.
     *      Otherwise, it returns null.
     *      Usefulness: To quickly with an operation get the intersection section.
     * */
    public static AuxMesh operator *(AuxMesh pol, AuxWideLine def)
    {
        return pol.p_CutSegments(pol.Execute(def.Dot).Combine());
    }
    public static AuxMesh operator *(AuxWideLine def, AuxMesh pol)
    {
        return pol * def;
    }

    /*
     * static AuxMesh operator *(AuxMesh pol, AuxPolygon def) / static AuxMesh operator *(AuxPolygon def, AuxMesh pol)
     *      Function: Returns the intersection mesh between a mesh and a polygon, as long as they intersect.
     *      This will correctly create a mesh with different polygons depending of the form of the mesh and the polygon to intersect.
     *      The negative parts are also kept in mind.
     *      Otherwise, it returns null.
     *      Usefulness: To quickly with an operation get the intersection section.
     * */
    public static AuxMesh operator *(AuxMesh pol, AuxPolygon def)
    {
        return pol.p_CutSegments(pol.Execute(def.Dot).Combine());
    }
    public static AuxMesh operator *(AuxPolygon def, AuxMesh pol)
    {
        return pol * def;
    }

    /*
     * static AuxMesh operator *(AuxMesh pol, AuxMesh def)
     *      Function: Returns the intersection mesh between two meshes, as long as they intersect.
     *      This will correctly create a mesh with different polygons depending of the form of the meshes to intersect.
     *      The negative parts are also kept in mind.
     *      Otherwise, it returns null.
     *      Usefulness: To quickly with an operation get the intersection section.
     * */
    public static AuxMesh operator *(AuxMesh pol, AuxMesh def)
    {
        AuxMesh add = new AuxMesh(), add2 = new AuxMesh(), t;
        add2.Negatives.AddRange(pol.Negatives.AddReturn(def.Negatives));
        
        for (int i = 0; i < pol.Count; i++)
            for (int j = 0; j < def.Count; j++)
            {
                AuxMesh mesh = pol[i] * def[j];
                if (mesh != null)
                    add.AddRange(mesh);
            }

        for (int i = 0; i < add.Count; i++)
        {
            t = new AuxMesh(add[i]);
            foreach (AuxPolygon neg in add2.Negatives)
                if (!neg.IsInside(t))
                    t -= neg;
            add2.AddRange(t);
        }

        for (int i = add2.Negatives.Count - 1; i >= 0; i--)
            if (!add2.IsAny(add2.Negatives[i].IsInside, true))
                add2.Negatives.RemoveAt(i);

        return add2;
    }


    //Operators (rest):

    /*
     * static AuxMesh operator +(AuxMesh pol, AuxPolygon def) / static AuxMesh operator +(AuxPolygon def, AuxMesh pol)
     *      Function: Returns a mesh by combining a mesh and a polygon.
     *      If one is inside the other, the result is the largest one.
     *      If they don't intersect, the result is a mesh with both polygons.
     *      If they intersect, it will create one unique polygon. If there are empty holes, those will be inserted as negatives.
     *      The Polygon section will be substracted from the negatives parts inside.
     *      Usefulness: To quickly with an operation get the added section.
     * */
    public static AuxMesh operator +(AuxMesh pol, AuxPolygon def)
    {
        AuxMesh copy = new AuxMesh(), add;
        AuxPolygon current = def;
        for (int i = 0; i < pol.Count - 1; i++)
        {
            add = current + pol[i];
            if (add != null && add.Count < 2 && !add[0].Equals(pol[i]))
            {
                copy.Negatives.AddRange(add.Negatives);
                current = add[0];
            }
            else if (add != null)
                copy.Add(pol[i]);
        }
        if (!copy.IsAny(current.IsInside, true))
            copy.Add(current);

        for (int j = 0; j < pol.Negatives.Count; j++)
        {
            add = pol.Negatives[j] - def;
            if (add != null)
                copy.Negatives.AddRange(add);
        }

        return copy;
    }
    public static AuxMesh operator +(AuxPolygon def, AuxMesh pol)
    {
        return pol * def;
    }

    /*
     * static AuxMesh operator +(AuxMesh pol, AuxMesh def) 
     *      Function: Returns a mesh by combining two meshes.
     *      If one is inside the other, the result is the largest one.
     *      If they don't intersect, the result is a mesh with both polygons.
     *      If they intersect, it will create one unique polygon. If there are empty holes, those will be inserted as negatives.
     *      Usefulness: To quickly with an operation get the added section.
     * */
    public static AuxMesh operator +(AuxMesh pol, AuxMesh def)
    {
        AuxMesh add = new AuxMesh(), add2 = new AuxMesh();

        //Positives:
        add2 = add2.AddReturn(pol.AddReturn(def)).Distinct() as AuxMesh;
        for (int i = 0; i < add2.Count - 1; i++)
            for (int j = i + 1; j < add2.Count; j++)
            {
                add = add2[i] + add2[j];
                if (add != null && add.Count < 2)
                {
                    add2.RemoveAt(i);
                    add2.RemoveAt(j);
                    add2.Add(add[0]);
                    i = 0;
                    break;
                }
            }

        //Negatives:
        add.Negatives.AddRange(pol.Negatives.AddReturn(def.Negatives));
        foreach (AuxPolygon neg1 in pol.Negatives)
            foreach (AuxPolygon neg2 in pol.Negatives)
                add.Negatives.AddRange(neg1 * neg2);

        for (int i = 0; i < add.Negatives.Count; i++)
            foreach (AuxPolygon ap in pol.AddReturn(def))
                if (ap.IsInside(add[i]))
                    add2.Negatives.AddRange(add[i] - ap);

        return add2;
    }

    /*
     * static AuxMesh operator -(AuxMesh pol, AuxLine def)
     *      Function: Returns a mesh with the parts substracted by the line separated and added.
     *      The Negative parts are also kept in mind.
     *      Usefulness: To quickly with an operation get the substracted section.
     *      
     * static AuxMesh operator -(AuxMesh pol, AuxSegment def)
     *      Function: Returns a mesh with the parts substracted by the segment separated and added.
     *      The segment must cut the entirety of a polygon's part to separate it into two or more parts.
     *      The Negative parts are also kept in mind.
     *      Usefulness: To quickly with an operation get the substracted section.
     *      
     * static List<AuxSegment> operator -(AuxSegment def, AuxMesh def)
     *      Function: Returns a list of segments with the parts inside the mesh substracted.
     *      If the segment is inside the polygon, it returns null.
     *      The Negative parts are also kept in mind.
     *      Usefulness: To quickly with an operation get the substracted section.
     *      
     * static AuxMesh operator -(AuxMesh pol, AuxWideLine def)
     *      Function: Returns a mesh with the parts substracted by the wide line cut.
     *      This wide line can eliminate the whole mesh, or at the very least separate big chunks of it and delete area.
     *      The Negative parts are also kept in mind.
     *      Usefulness: To quickly with an operation get the substracted section.
     *      
     * static AuxMesh operator -(AuxMesh pol, AuxPolygon def)
     *      Function: Returns a mesh with the parts substracted by other polygon.
     *      If they don't intersect (inside negatives included), the Mesh will only have the whole previous mesh.
     *      If the mesh to be cut is inside the substracter, it returns null.
     *      If the substracter is inside the mesh (not negatives), it is inserted as a negative polygon in the mesh.
     *      The Negative parts are also kept in mind.
     *      Usefulness: To quickly with an operation get the substracted section.
     *      
     * static AuxMesh operator -(AuxMesh pol, AuxMesh def)
     *      Function: Returns a mesh with the parts substracted by other mesh.
     *      If they don't intersect (inside negatives included), the Mesh will only have the whole previous mesh.
     *      If the mesh to be cut is inside the substracter, it returns null.
     *      If the substracter is inside the mesh (not negatives), it is inserted as a negative (and the negatives parts the opposite).
     *      The Negative parts are also kept in mind.
     *      Usefulness: To quickly with an operation get the substracted section.
     * */
    public static AuxMesh operator -(AuxMesh pol, AuxLine def)
    {
        AuxMesh copy = new AuxMesh();
        for (int i = 0; i < pol.Count; i++)
            if (pol[i].Intersects(def))
                copy.AddRange(pol[i] - def);
            else
                copy.Add(pol[i]);

        for (int j = 0; j < pol.Negatives.Count; j++)
        {
            if (pol.Negatives[j].Intersects(def))
            {
                bool includeIfNothing = true;
                for (int k = 0; k < copy.Count; k++)
                    if (copy[k].Intersects(pol.Negatives[j]) && !pol.Negatives[j].IsInside(copy[k]) && !copy[k].IsInside(pol.Negatives[j]))
                    {
                        copy[k] = (copy[k] - pol.Negatives[j])[0];
                        includeIfNothing = false;
                    }
                if (includeIfNothing)
                    copy.Negatives.Add(pol.Negatives[j]);
            }
            else
                copy.Negatives.Add(pol.Negatives[j]);
        }
        return copy;
    }
    public static AuxMesh operator -(AuxMesh pol, AuxSegment def)
    {
        AuxMesh copy = new AuxMesh();
        for (int i = 0; i < pol.Count; i++)
            if (pol[i].Intersects(def))
                copy.AddRange(pol[i] - def);
            else
                copy.Add(pol[i]);

        for (int j = 0; j < pol.Negatives.Count; j++)
        {
            if (pol.Negatives[j].Intersects(def))
            {
                bool includeIfNothing = true;
                for (int k = 0; k < copy.Count; k++)
                    if (copy[k].Intersects(pol.Negatives[j]) && !pol.Negatives[j].IsInside(copy[k]) && !copy[k].IsInside(pol.Negatives[j]))
                    {
                        copy[k] = (copy[k] - pol.Negatives[j])[0];
                        includeIfNothing = false;
                    }
                if (includeIfNothing)
                    copy.Negatives.Add(pol.Negatives[j]);
            }
            else
                copy.Negatives.Add(pol.Negatives[j]);
        }
        return copy;
    }
    public static List<AuxSegment> operator -(AuxSegment def, AuxMesh pol)
    {
        return def - def * pol;
    }
    public static AuxMesh operator -(AuxMesh pol, AuxWideLine def)
    {
        AuxMesh copy = new AuxMesh();
        for (int i = 0; i < pol.Count; i++)
            if (pol[i].Intersects(def))
                copy.AddRange(pol[i] - def);
            else
                copy.Add(pol[i]);

        for (int j = 0; j < pol.Negatives.Count; j++)
        {
            if (pol.Negatives[j].Intersects(def))
            {
                bool includeIfNothing = true;
                for (int k = 0; k < copy.Count; k++)
                    if (copy[k].Intersects(pol.Negatives[j]) && !pol.Negatives[j].IsInside(copy[k]) && !copy[k].IsInside(pol.Negatives[j]))
                    {
                        copy[k] = (copy[k] - pol.Negatives[j])[0];
                        includeIfNothing = false;
                    }
                if (includeIfNothing)
                    copy.Negatives.Add(pol.Negatives[j]);
            }
            else
                copy.Negatives.Add(pol.Negatives[j]);
        }
        return copy;
    }
    public static AuxMesh operator -(AuxMesh pol, AuxPolygon def)
    {
        AuxMesh copy = new AuxMesh();
        for (int i = 0; i < pol.Count; i++)
            if (pol[i].Intersects(def))
                copy.AddRange(pol[i] - def);
            else
                copy.Add(pol[i]);

        for (int j = 0; j < pol.Negatives.Count; j++)
        {
            if (pol.Negatives[j].Intersects(def))
            {
                bool includeIfNothing = true;
                for (int k = 0; k < copy.Count; k++)
                    if (copy[k].Intersects(pol.Negatives[j]) && !pol.Negatives[j].IsInside(copy[k]) && !copy[k].IsInside(pol.Negatives[j]))
                    {
                        copy[k] = (copy[k] - pol.Negatives[j])[0];
                        includeIfNothing = false;
                    }
                if (includeIfNothing)
                    copy.Negatives.Add((pol.Negatives[j] + def)[0]);
            }
            else
                copy.Negatives.Add(pol.Negatives[j]);
        }
        return copy;
    }
    public static AuxMesh operator -(AuxPolygon def, AuxMesh pol)
    {
        if (pol.IsInside(def))
            return null;
        else if (!def.Intersects(pol))
            return new AuxMesh(def);

        return def * pol.Inverse;
    }
    public static AuxMesh operator -(AuxMesh pol, AuxMesh def)
    {
        if (def.IsInside(pol))
            return null;
        else if (!pol.Intersects(def))
            return pol;

        return pol * def.Inverse;
    }

    /*
     * static AuxPolygon operator /(AuxMesh pol, AuxLine def)
     *      Function: Returns the biggest polygon out of the list substracted.
     *      Usefulness: To quickly with an operation get the largest substracted section.
     *      
     * static AuxPolygon operator /(AuxMesh pol, AuxSegment def)
     *      Function: Returns the biggest polygon out of the list substracted.
     *      Usefulness: To quickly with an operation get the largest substracted section.
     *      
     * static AuxSegment operator /(AuxSegment def, AuxMesh def)
     *      Function: Returns the largest segment out of the list substracted.
     *      Usefulness: To quickly with an operation get the largest substracted section.
     *      
     * static AuxPolygon operator /(AuxMesh pol, AuxWideLine def)
     *      Function: Returns the biggest polygon out of the list substracted.
     *      Usefulness: To quickly biggest an operation get the largest substracted section.
     *      
     * static AuxPolygon operator /(AuxMesh pol, AuxPolygon def)
     *      Function: Returns the biggest polygon out of the list substracted.
     *      Usefulness: To quickly with an operation get the largest substracted section.
     *      
     * static AuxPolygon operator /(AuxMesh pol, AuxMesh def)
     *      Function: Returns the biggest polygon out of the list substracted.
     *      Usefulness: To quickly with an operation get the largest substracted section.
     * */
    public static AuxPolygon operator /(AuxMesh pol, AuxLine def)
    {
        return (pol - def).Max(Auxp.i.Area, null);
    }
    public static AuxPolygon operator /(AuxMesh pol, AuxSegment def)
    {
        return (pol - def).Max(Auxp.i.Area, null);
    }
    public static AuxSegment operator /(AuxSegment def, AuxMesh pol)
    {
        return (def - pol).Max(Auxp.i.SqrLength, AuxSegment.NaN);
    }
    public static AuxPolygon operator /(AuxMesh pol, AuxWideLine def)
    {
        return (pol - def).Max(Auxp.i.Area, null);
    }
    public static AuxPolygon operator /(AuxMesh pol, AuxPolygon def)
    {
        return (pol - def).Max(Auxp.i.Area, null);
    }
    public static AuxPolygon operator /(AuxPolygon def, AuxMesh pol)
    {
        return (pol - def).Max(Auxp.i.Area, null);
    }
    public static AuxPolygon operator /(AuxMesh pol, AuxMesh def)
    {
        return (pol - def).Max(Auxp.i.Area, null);
    }

    /*
     * static AuxPolygon operator %(AuxMesh pol, AuxLine def)
     *      Function: Returns the smallest polygon out of the list substracted.
     *      Usefulness: To quickly with an operation get the smallest substracted section.
     *      
     * static AuxPolygon operator %(AuxMesh pol, AuxSegment def)
     *      Function: Returns the smallest polygon out of the list substracted.
     *      Usefulness: To quickly with an operation get the smallest substracted section.
     *      
     * static AuxSegment operator %(AuxSegment def, AuxMesh def)
     *      Function: Returns the smallest segment out of the list substracted.
     *      Usefulness: To quickly with an operation get the smallest substracted section.
     *      
     * static AuxPolygon operator %(AuxMesh pol, AuxWideLine def)
     *      Function: Returns the smallest polygon out of the list substracted.
     *      Usefulness: To quickly with an operation get the smallest substracted section.
     *      
     * static AuxPolygon operator %(AuxMesh pol, AuxPolygon def)
     *      Function: Returns the smallest polygon out of the list substracted.
     *      Usefulness: To quickly with an operation get the smallest substracted section.
     *      
     * static AuxPolygon operator %(AuxMesh pol, AuxMesh def)
     *      Function: Returns the smallest polygon out of the list substracted.
     *      Usefulness: To quickly with an operation get the smallest substracted section.
     * */
    public static AuxPolygon operator %(AuxMesh pol, AuxLine def)
    {
        return (pol - def).Min(Auxp.i.Area, null);
    }
    public static AuxPolygon operator %(AuxMesh pol, AuxSegment def)
    {
        return (pol - def).Min(Auxp.i.Area, null);
    }
    public static AuxSegment operator %(AuxSegment def, AuxMesh pol)
    {
        return (def - pol).Min(Auxp.i.SqrLength, AuxSegment.NaN);
    }
    public static AuxPolygon operator %(AuxMesh pol, AuxWideLine def)
    {
        return (pol - def).Min(Auxp.i.Area, null);
    }
    public static AuxPolygon operator %(AuxMesh pol, AuxPolygon def)
    {
        return (pol - def).Min(Auxp.i.Area, null);
    }
    public static AuxPolygon operator %(AuxPolygon def, AuxMesh pol)
    {
        return (pol - def).Min(Auxp.i.Area, null);
    }
    public static AuxPolygon operator %(AuxMesh pol, AuxMesh def)
    {
        return (pol - def).Min(Auxp.i.Area, null);
    }


    //Private Functions:
    private List<AuxSegment> p_CutSegments (List<AuxSegment> segs)
    {
        var otherlist = new List<AuxSegment>();
        if (segs == null || segs.Count == 0)
            return null;

        for (int i = 0; i < segs.Count; i++)
        {
            var newlist = segs[i].List();
            for (int j = 0; j < Negatives.Count; j++)
                for (int k = 0; k < newlist.Count; k++)
                    if (!Negatives[j].IsInside(newlist[k]))
                        newlist = newlist.SetReturn(k, newlist[k] - Negatives[j]);

            otherlist.AddRange(newlist);
        }
        return otherlist;
    }
    private AuxMesh p_CutSegments (AuxMesh mesh)
    {
        AuxMesh otherlist = new AuxMesh();
        if (mesh == null || mesh.Count == 0)
            return null;

        for (int i = 0; i < mesh.Count; i++)
        {
            AuxMesh newlist = new AuxMesh(mesh[i]);
            for (int j = 0; j < Negatives.Count; j++)
                for (int k = 0; k < newlist.Count; k++)
                    if (!Negatives[j].IsInside(newlist[k]))
                        newlist.Set(k, newlist[k] - Negatives[j]);

            otherlist.AddRange(newlist);
        }
        return otherlist;
    }
}
