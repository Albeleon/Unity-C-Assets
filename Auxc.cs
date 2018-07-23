/*
 * Auxc (Auxiliar Comparer):
 * This file contains a few main classes for Comparers in C#.
 * It needs the library "System.Collections.Generic" and "UnityEngine" to work, so it only works on Unity projects.
 * 
 * Developed by Alberto León Meaños, 22/07/2018, License GNU General Public License v3.0
 * */


using System.Collections.Generic;
using UnityEngine;


// Dump Class Auxc (so the class can be called Auxc.cs):
public class Auxc { }


/*
 * Class Vector2Comparer : IComparer<Vector2>
 *      It allows to compare Vector2 and order them, first off with the "y" coordinate as priority,
 *      and then the "x" coordinate.
 * */
public class Vector2Comparer : IComparer<Vector2>
{
    public int Compare (Vector2 a, Vector2 b)
    {
        if (Mathf.Approximately(a.y, b.y))
        {
            if (Mathf.Approximately(a.x, b.x))
                return 0;
            if (a.x < b.x)
                return -1;
        }
        if (a.y < b.y)
            return -1;
        return 1;
    }
}


/*
 * Class Vector2Comparer : IComparer<Vector2>
 *      It allows to compare Vector2 and order them, first off with the "z" coordinate as priority,
 *      then the "y" coordinate, and then the "x" coordinate.
 * */
public class Vector3Comparer : IComparer<Vector3>
{
    public int Compare(Vector3 a, Vector3 b)
    {
        if (Mathf.Approximately(a.z, b.z))
        {
            if (Mathf.Approximately(a.y, b.y))
            {
                if (Mathf.Approximately(a.x, b.x))
                    return 0;
                if (a.x < b.x)
                    return -1;
            }
            if (a.y < b.y)
                return -1;
        }
        if (a.z < b.z)
            return -1;
        return 1;
    }
}

