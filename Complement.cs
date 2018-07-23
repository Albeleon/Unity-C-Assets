/*
 * Complement:
 * This file creates a MonoBehaviour to insert in a GameObject in Unity C#, so the functions from AuxeUnity GetRecursive work correctly.
 * It needs the library "System.Collections.Generic" and "UnityEngine" to work, so it only works on Unity projects.
 * 
 * Developed by Alberto León Meaños, 22/07/2018, License GNU General Public License v3.0
 * */


using System.Collections.Generic;
using UnityEngine;


/*
 * Class Complement : MonoBehaviour
 *      It allows to link the GameObject to others, so GetRecursive calls them recursively.
 *      The "Included" function is a parameter that allows options in GetRecursive.
 *      
 *      ERROR: Two GameObjects being linked respectively will generate an endless loop. Needs fix in Auxe.cs
 * */
public class Complement : MonoBehaviour {
    public List<GameObject> complement;
    public bool included = true;
}
