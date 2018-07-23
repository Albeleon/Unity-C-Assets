/*
 * AuxGameObject (Auxiliar GameObject):
 * This file contains a few main functions that affect and are only usable by a GameObject that inherits from MonoBehaviour.
 * It needs the library "System.Collections", "System.Collections.Generic", "UnityEngine", "UnityEngine.UI"
 * and "UnityEngine.UI.Extensions" to work, so it only works on Unity projects that have the Extensions pack.
 * It also needs the other classes from the pack: "Auxe.cs", "Auxp.cs"
 * 
 * Developed by Alberto León Meaños, 22/07/2018, License GNU General Public License v3.0
 * */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;


/*
 * Delegates -> GameObjectDelegate:
 * An empty Delegate with GameObject as result. This delegate is used for the Spawner function and AuxgStatic function
 * to initiate many GameObjects at once after being already defined.
 * */
public delegate GameObject GameObjectDelegate();


/*
 * Class Auxg
 *      It allows to call automatically the GameObject.
 *      It also contains the Spawner function that allows to instantiate an object with any parameter modifiers.
 *      
 *      IMPORTANT: When this function is called, it searches inmediately for the GameObject that has the Auxg tag,
 *      and take its AuxGameObject script.
 * */
public class Auxg
{
    //Singleton  (invoke by calling "Auxg.i"):
    private static Auxg m_instance;
    private static AuxGameObject go_instance;
    public static AuxGameObject i { get { if (m_instance == null) m_instance = new Auxg(); return go_instance; } }
    private Auxg ()
    {
        go_instance = GameObject.FindGameObjectWithTag("Auxg").GetComponent<AuxGameObject>();
    }


    /*
     * Class Auxg.Spawner
     *      This class creates instances of a GameObject Spawner. When it's constructed or set, you can set the different parameters
     *      that modify aspects of the gameObject when it's finally instantiated (its parent, position, rotation, scale or material),
     *      and when it's ready, the Instantiate function is called, applying all of them.
     * */
    public class Spawner
    {
        //Attributes:
        public Object obj;
        public Transform parent;
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;
        public Material material;


        //Constructors:
        public Spawner(Object n_obj, Transform n_parent, Material n_material = null)
            : this(n_obj, n_parent, Vector3.zero, Quaternion.identity, Vector3.zero, n_material) { }
        public Spawner(Object n_obj, Transform n_parent, Vector3 n_position,
            Quaternion n_rotation, Vector3 n_scale, Material n_material = null)
        {
            obj = n_obj;
            parent = n_parent;
            position = n_position;
            rotation = n_rotation;
            scale = n_scale;
            material = n_material;
        }


        //Other Functions:

        /*
         * GameObject Instantiate():
         *      Function: Returns a new GameObject instantiated from the object given, and with all the changes applied.
         *      Usefulness: To quickly instantiate GameObjects with the right parameters without refilling each Instantiate parameters
         *      or changing them after the fact.
         * */
        public GameObject Instantiate()
        {
            return i.InstantiateObject(obj, parent, position, rotation, scale, material);
        }
    }
}


/*
 * Class AuxgStatic
 *      This static class allows to extend some new classes with useful methods.
 * */
public static class AuxgStatic
{
    /*
     * GameObjectDelegate[] [IEnumerable<Auxg.Spawner>].Instantiate() / static GameObjectDelegate[] Instantiate(IEnumerable<Auxg.Spawner>):
     *      Function: Returns the Instantiate delegate of each Spawner object.
     *      Usefulness: To quickly get the Instantiate delegate of a list.
     * */
    public static GameObjectDelegate[] Instantiate(this IEnumerable<Auxg.Spawner> array)
    {
        List<GameObjectDelegate> list = new List<GameObjectDelegate>();

        foreach (var el in array)
            list.Add(el.Instantiate);

        return list.ToArray();
    }

}


/*
 * Class AuxGameObject : MonoBehaviour
 *      GameObject script that allows to do a bunch of GameObject-related operations that need "MonoBehaviour" inherited.
 *      It also allows to configure a few attributes from the Unity Editor.
 * */
public class AuxGameObject : MonoBehaviour
{
    //Attributes -> Material (Function):
    [System.Serializable]
    public struct SMaterial
    {
        public string shortCode;
        public string code;
        public Material sObject;

        public SMaterial(string ncode, string nShortCode, Material nSObject)
        {
            code = ncode;
            shortCode = nShortCode;
            sObject = nSObject;
        }
    }
    public List<SMaterial> quickMaterial;
    
    /*
     * Material GetMaterial(string name):
     *      Function: Returns the material with a particular name or short code that was filled in the QuickMaterial list.
     *      Usefulness: To quickly get a Material with just a name without having to reload it either.
     * */
    public Material GetMaterial(string name)
    {
        foreach (SMaterial si in quickMaterial)
            if (si.code == name || si.shortCode == name)
                return si.sObject;
        return null;
    }


    //Attributes -> Object (Function):
    [System.Serializable]
    public struct SIndividual
    {
        public string name;
        public GameObject sObject;

        public SIndividual(string nName, GameObject nSObject)
        {
            name = nName;
            sObject = nSObject;
        }
    }
    public List<SIndividual> quickAccess;

    /*
     * GameObject GetObject(string name):
     *      Function: Returns the GameObject with a particular name that was filled in the QuickAccess list.
     *      Usefulness: To quickly get a GameObject with just a name without having to search for it.
     *      
     * T GetObject<T>(string name) where T : MonoBehaviour:
     *      Function: Returns the MonoBehaviour of a GameObject with a particular name that was filled in the QuickAccess list.
     *      Usefulness: To quickly get a GameObject and a MonoBehaviour with just a name without having to search for it or convert it later.
     * */
    public GameObject GetObject (string name)
    {
        foreach (SIndividual si in quickAccess)
            if (si.name == name)
                return si.sObject;
        return null;
    }
    public T GetObject<T>(string name) where T : MonoBehaviour
    {
        foreach (SIndividual si in quickAccess)
            if (si.name == name)
                return si.sObject.GetComponent<T>();
        return null;
    }


    //Attributes -> Prefabs:
    private string m_UITriangle = "Prefabs/UITriangle";
    private string m_UIShadowLine = "Prefabs/IndividualTransparentLine";
    private string m_UILine = "Prefabs/SimpleLine";
    [HideInInspector] public Object o_UITriangle;
    [HideInInspector] public Object o_UIShadowLine;
    [HideInInspector] public Object o_UILine;

    //Constructors:
    void Awake ()
    {
        o_UITriangle = Resources.Load(m_UITriangle);
        o_UIShadowLine = Resources.Load(m_UIShadowLine);
        o_UILine = Resources.Load(m_UILine);
    }


    //Functions:

    /*
     * GameObject CreateUIMesh(string name, AuxMesh vertices2D, Transform parent, Material material, Material negMaterial):
     *      Function: Returns an empty GameObject full of UITriangles that replicate an AuxMesh (Auxiliar Mesh),
     *      with the particular material to see and the negative Material to negate the other material.
     *      Usefulness: To easily get on screen a representation of a particular Mesh.
     * */
    public GameObject CreateUIMesh(string name, AuxMesh vertices2D, Transform parent, Material material = null, Material negMaterial = null)
    {
        Vector2 a = Vector2.zero, b = Vector2.zero, c = Vector2.zero;
        UIPolygon son;
        List<float> newPoints;
        GameObject tt = new GameObject(name);
        tt.transform.SetParent(parent);
        tt.transform.Reset();
        Material[] mat = new Material[] { material, negMaterial };
        int i = 0;
        List<List<AuxTriangle>> indices = vertices2D.Triangulate;

        foreach (List<AuxTriangle> list in indices)
        {
            foreach (AuxTriangle triangle in list)
            {
                son = (Instantiate(o_UITriangle, tt.transform) as GameObject).GetComponent<UIPolygon>();
                son.thickness = 0f;
                son.fill = true;
                if (mat[i] != null)
                    son.material = mat[i];

                Vector3 angle = new Vector3(
                    Vector2.Angle(triangle.p2 - triangle.p1, triangle.p3 - triangle.p1),
                    Vector2.Angle(triangle.p3 - triangle.p2, triangle.p1 - triangle.p2),
                    Vector2.Angle(triangle.p1 - triangle.p3, triangle.p2 - triangle.p3));
                
                float max = angle.Max();
                if (max == angle.x)
                {
                    a = triangle.p2;
                    b = triangle.p1;
                    c = triangle.p3;
                }
                else if (max == angle.y)
                {
                    a = triangle.p3;
                    b = triangle.p2;
                    c = triangle.p1;
                }
                else if (max == angle.z)
                {
                    a = triangle.p1;
                    b = triangle.p3;
                    c = triangle.p2;
                }
                
                Vector2 centerPoint = new AuxLine(a, c) * new AuxLine(b, (c - a).Perpendicular(), true);
                Vector3 distance = new Vector3((a - centerPoint).magnitude, (b - centerPoint).magnitude, (c - centerPoint).magnitude);
                son.transform.localPosition = centerPoint / 2f;
                son.transform.localScale = Vector3.one * distance.Max();
                distance /= distance.Max();

                newPoints = new List<float>(son.VerticesDistances);
                newPoints[0] = 0f;
                newPoints[1] = distance.x;
                newPoints[2] = distance.y;
                newPoints[3] = distance.z;
                son.VerticesDistances = newPoints.ToArray();
                son.transform.Rotate(Vector3.forward * Vector2.SignedAngle(Vector2.right, b - centerPoint));
            }
            i++;
        }

        tt.transform.localScale *= 2;
        return tt;
    }


    //Extension Functions:

    /*
     * GameObject Duplicate(GameObject go, bool isSibling):
     *      Function: Creates a Duplicate of the GameObject and returns it, either as a son (isSibling false) or as a later sibling (isSibling true).
     *      Usefulness: To quickly make a duplicate of a GameObject either as a son or as a sibling.
     *      
     * Transform Duplicate(Transform go, bool isSibling):
     *      Function: Creates a Duplicate of the GameObject and returns it, either as a son (isSibling false) or as a later sibling (isSibling true).
     *      Usefulness: To quickly make a duplicate of a GameObject either as a son or as a sibling in the same format.
     *      
     * T Duplicate<T>(t go, bool isSibling) where T : MonoBehaviour:
     *      Function: Creates a Duplicate of the GameObject and returns it, either as a son (isSibling false) or as a later sibling (isSibling true).
     *      Usefulness: To quickly make a duplicate of a GameObject either as a son or as a sibling in the same format.
     * */
    public GameObject Duplicate(GameObject go, bool isSibling = false)
    {
        return Duplicate(go.transform, isSibling).gameObject;
    }
    public Transform Duplicate(Transform go, bool isSibling = false)
    {
        if (!isSibling)
            return Instantiate(go, go);
        var gt = Instantiate(go, go.parent);
        gt.Set(go);
        return gt;
    }
    public T Duplicate<T>(T go, bool isSibling = false) where T : MonoBehaviour
    {
        return Duplicate(go.transform, isSibling).GetComponent<T>();
    }

    /*
     * void Set(GameObject go, Material material):
     *      Function: Changes the material of the GameObject, if it's possible, to "material".
     *      Usefulness: To quickly change a material of a GameObject.
     *      
     * void Set(GameObject go, Color color):
     *      Function: Changes the material of the GameObject, if it's possible, to "color".
     *      Usefulness: To quickly change a color of a GameObject.
     * */
    public void Set(GameObject go, Material material)
    {
        if (go.GetComponent<Image>() != null)
            go.GetComponent<Image>().material = material;
        else if (go.GetComponent<UIPolygon>() != null)
            go.GetComponent<UIPolygon>().material = material;
        else if (go.GetComponent<UILineRenderer>() != null)
            go.GetComponent<UILineRenderer>().material = material;
    }
    public void Set(GameObject go, Color color)
    {
        if (go.GetComponent<Image>() != null)
            go.GetComponent<Image>().color = color;
        else if (go.GetComponent<UIPolygon>() != null)
            go.GetComponent<UIPolygon>().color = color;
        else if (go.GetComponent<UILineRenderer>() != null)
            go.GetComponent<UILineRenderer>().color = color;
    }


    //Delay Functions:

    /*
     * void Delay<T{...}>(VoidDelegate<T{...}> function, T{...} arg{...}, float time):
     *      Function: For a delegate (up to 4 input arguments), it executes that function a particular time later.
     *      The "time" value is in seconds. If the value is too small, it executes it the next frame.
     *      The arguments of the function must be pust after the Delegate and before the time.
     *      Usefulness: Easily execute any function later in time.
     * */
    public void Delay(VoidDelegate function, float time)
    {
        if (function != null) StartCoroutine(p_Delay(function, time));
    }
    public void Delay<T1>(VoidDelegate<T1> function, T1 arg1, float time)
    {
        if (function != null) StartCoroutine(p_Delay(function, arg1, time));
    }
    public void Delay<T1, T2>(VoidDelegate<T1, T2> function, T1 arg1, T2 arg2, float time)
    {
        if (function != null) StartCoroutine(p_Delay(function, arg1, arg2, time));
    }
    public void Delay<T1, T2, T3>(VoidDelegate<T1, T2, T3> function, T1 arg1, T2 arg2, T3 arg3, float time)
    {
        if (function != null) StartCoroutine(p_Delay(function, arg1, arg2, arg3, time));
    }
    public void Delay<T1, T2, T3, T4>(VoidDelegate<T1, T2, T3, T4> function, T1 arg1, T2 arg2, T3 arg3, T4 arg4, float time)
    {
        if (function != null) StartCoroutine(p_Delay(function, arg1, arg2, arg3, arg4, time));
    }

    /*
     * void Delay<T, T{...}>(TDelegate<T, T{...}> function, T{...} arg{...}, float time):
     *      Function: For a delegate (up to 4 input arguments), it executes that function a particular time later.
     *      The "time" value is in seconds. If the value is too small, it executes it the next frame.
     *      The arguments of the function must be pust after the Delegate and before the time.
     *      Usefulness: Easily execute any function later in time.
     * */
    public void Delay<T> (TDelegate<T> function, float time)
    {
        if (function != null) StartCoroutine(p_Delay(function, time));
    }
    public void Delay<T,T1> (TDelegate<T,T1> function, T1 arg1, float time)
    {
        if (function != null) StartCoroutine(p_Delay(function, arg1, time));
    }
    public void Delay<T,T1,T2> (TDelegate<T,T1,T2> function, T1 arg1, T2 arg2, float time)
    {
        if (function != null) StartCoroutine(p_Delay(function, arg1, arg2, time));
    }
    public void Delay<T,T1,T2,T3> (TDelegate<T,T1,T2,T3> function, T1 arg1, T2 arg2, T3 arg3, float time)
    {
        if (function != null) StartCoroutine(p_Delay(function, arg1, arg2, arg3, time));
    }
    public void Delay<T,T1,T2,T3,T4> (TDelegate<T,T1,T2,T3,T4> function, T1 arg1, T2 arg2, T3 arg3, T4 arg4, float time)
    {
        if (function != null) StartCoroutine(p_Delay(function, arg1, arg2, arg3, arg4, time));
    }

    /*
     * void ExecuteUntilFalse(TDelegate<bool> function, float time):
     *      Function: For a bool delegate with no input arguments, it executes that function until the result is "false".
     *      The "time" value shows the frequency by which the function is recalled. If the value is too small, it executes it the next frame.
     *      Usefulness: Easily execute a function in parallel until a function is fulfilled.
     * */
    public void ExecuteUntilFalse(TDelegate<bool> function, float time)
    {
        if (function != null) StartCoroutine(p_ExecuteUntilFalse(function, time));
    }

    /*
     * void DelayUntilFalse<T>(TDelegate<T> function, TDelegate<bool> wait, float time):
     *      Function: For a delegate and bool delegate with no input arguments, it executes the "wait" function until the result is "false".
     *      When that happens, it executes the "function".
     *      The "time" value shows the frequency by which the function is recalled. If the value is too small, it executes it the next frame.
     *      Usefulness: Easily execute a function in parallel when a condition is fulfilled (in this case, that the bool delegate is false).
     *      
     * void DelayUntilFalse(VoidDelegate function, TDelegate<bool> wait, float time):
     *      Function: For a delegate and bool delegate with no input arguments, it executes the "wait" function until the result is "false".
     *      When that happens, it executes the "function".
     *      The "time" value shows the frequency by which the function is recalled. If the value is too small, it executes it the next frame.
     *      Usefulness: Easily execute a function in parallel when a condition is fulfilled (in this case, that the bool delegate is false).
     * */
    public void DelayUntilFalse<T>(TDelegate<T> function, TDelegate<bool> wait, float time)
    {
        if (function != null && wait != null) StartCoroutine(p_DelayUntilFalse(function, wait, time));
    }
    public void DelayUntilFalse(VoidDelegate function, TDelegate<bool> wait, float time)
    {
        if (function != null && wait != null) StartCoroutine(p_DelayUntilFalse(function, wait, time));
    }

    private IEnumerator p_Delay<T> (TDelegate<T> function, float time)
    {
        yield return TimeIE(time); function();
    }
    private IEnumerator p_Delay<T,T1> (TDelegate<T,T1> function, T1 arg1, float time)
    {
        yield return TimeIE(time); function(arg1);
    }
    private IEnumerator p_Delay<T,T1,T2> (TDelegate<T,T1,T2> function, T1 arg1, T2 arg2, float time)
    {
        yield return TimeIE(time); function(arg1, arg2);
    }
    private IEnumerator p_Delay<T,T1,T2,T3> (TDelegate<T,T1,T2,T3> function, T1 arg1, T2 arg2, T3 arg3, float time)
    {
        yield return TimeIE(time); function(arg1, arg2, arg3);
    }
    private IEnumerator p_Delay<T,T1,T2,T3,T4> (TDelegate<T,T1,T2,T3,T4> function, T1 arg1, T2 arg2, T3 arg3, T4 arg4, float time)
    {
        yield return TimeIE(time); function(arg1, arg2, arg3, arg4);
    }

    private IEnumerator p_Delay(VoidDelegate function, float time)
    {
        yield return TimeIE(time); function();
    }
    private IEnumerator p_Delay<T1>(VoidDelegate<T1> function, T1 arg1, float time)
    {
        yield return TimeIE(time); function(arg1);
    }
    private IEnumerator p_Delay<T1, T2>(VoidDelegate<T1, T2> function, T1 arg1, T2 arg2, float time)
    {
        yield return TimeIE(time); function(arg1, arg2);
    }
    private IEnumerator p_Delay<T1, T2, T3>(VoidDelegate<T1, T2, T3> function, T1 arg1, T2 arg2, T3 arg3, float time)
    {
        yield return TimeIE(time); function(arg1, arg2, arg3);
    }
    private IEnumerator p_Delay<T1, T2, T3, T4>(VoidDelegate<T1, T2, T3, T4> function, T1 arg1, T2 arg2, T3 arg3, T4 arg4, float time)
    {
        yield return TimeIE(time); function(arg1, arg2, arg3, arg4);
    }

    private IEnumerator p_ExecuteUntilFalse (TDelegate<bool> function, float time)
    {
        while (function()) yield return TimeIE(time);
    }
    private IEnumerator p_DelayUntilFalse<T> (TDelegate<T> function, TDelegate<bool> wait, float time)
    {
        while (wait()) yield return TimeIE(time); function();
    }
    private IEnumerator p_DelayUntilFalse(VoidDelegate function, TDelegate<bool> wait, float time)
    {
        while (wait()) yield return TimeIE(time); function();
    }
    private WaitForSeconds TimeIE (float time)
    {
        return time <= 0f ? null : new WaitForSeconds(time);
    }


    //Instantiate Object Functions:

    /*
     * GameObject InstantiateEmpty(string name, Transform parent, bool isFirstSibling):
     *      Function: Returns a new empty GameObject with a new name from a parent.
     *      It can be the last or first sibling depending of "isFirstSibling".
     *      Usefulness: Easily create a new GameObject in a particular position.
     * */
    public GameObject InstantiateEmpty (string name, Transform parent, bool isFirstSibling = false)
    {
        var go = new GameObject(name);
        go.transform.parent = parent;
        if (isFirstSibling)
            go.transform.SetAsFirstSibling();
        go.transform.Reset();
        return go;
    }

    /*
     * GameObject InstantiateObject(Object obj, Transform parent, Material material):
     *      Function: Returns a GameObject from a particular Object with a particular parent and material.
     *      Usefulness: Easily create a new GameObject with all its parameters inmediately changed.
     * */
    public GameObject InstantiateObject (Object obj, Transform parent, Material material = null)
    {
        GameObject go = Instantiate(obj, parent) as GameObject;
        if (material != null)
            go.Set(material);
        return go;
    }

    /*
     * GameObject InstantiateObject(Object obj, Transform parent, Vector3 position, Quaternion rotation, Vector3 scale, Material material):
     *      Function: Returns a GameObject from a particular Object with a particular parent, position, rotation, scale and material.
     *      Usefulness: Easily create a new GameObject with all its parameters inmediately changed.
     * */
    public GameObject InstantiateObject (Object obj, Transform parent, Vector3 position,
        Quaternion rotation, Vector3 scale, Material material = null)
    {
        GameObject go = InstantiateObject(obj, parent, material);
        go.transform.localScale = scale;
        go.transform.localRotation = rotation;
        go.transform.localPosition = position;

        return go;
    }


}
