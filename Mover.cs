/*
 * Mover:
 * This file contains functions that allow to apply controlled position, rotation and scale movement for GameObjects in a controlled way.
 * It needs the library "System.Collections.Generic" and "UnityEngine" to work, so it only works on Unity projects.
 * It also needs the other classes from the pack: "AuxGameObject.cs", "Auxe.cs", "Auxf.cs"
 * 
 * Developed by Alberto León Meaños, 22/07/2018, License GNU General Public License v3.0
 * */


using System.Collections.Generic;
using UnityEngine;


/*
 * Class Movers : List<Mover>:
 *      This class is a list of Mover with a lot of components useful to manage a lot of them at the same time.
 * */
public class Movers : List<Mover>
{
    private static readonly string allowableCode = "xyzs";
    private static readonly char obligatory = 's';
    private static string restCode { get { return allowableCode.Remove(obligatory.ToString()); } }

    private readonly float MINIMUM;
    public Mover GetLast { get { return this[Count - 1]; } }

    /*
     * List<string> Names:
     *      Property: Returns a list of names of the GameObjects affected by the list of movers. There are no repeats.
     *      Usefulness: To quickly know what GameObjects are affected, to other functions.
     *      Dependences: Auxe.
     * */
    public List<string> Names { get {
            var tr = new List<string>();
            foreach (Mover mv in this)
                tr.Add(mv.name);
            return tr.Distinct();
        }
    }

    /*
     * Dictionary<string, Transform> Dictionary:
     *      Property: Returns a dictionary that associates the names of the GameObjects involved in it with their Transform.
     *      Usefulness: To easily gain access to all the GameObjects affected.
     * */
    public Dictionary<string, Transform> Dictionary { get {
            var dict = new Dictionary<string, Transform>();
            foreach (string name in Names)
                dict.Add(name, GetObject(name));
            return dict;
        } }

    //Constructor:
    public Movers ()
    {
        MINIMUM = Auxf.i.MINIMUM;
    }
    public Movers (Movers movers, bool overload = false) : this()
    {
        if (overload)
            foreach (Mover mv in movers)
                Add(new Mover(mv));
        else
            AddRange(movers);
    }

    //LoadSML Functions:

    /*
     * static Movers LoadSML (string text, string id, params GameObjectDelegate[] template):
     *      Function: From a SML text and a particular id/method, it creates a mover for a particular object.
     *      When the "cr(<number>)" name is called, it automatically instantiates the specific template given its position in the array.
     *      Usefulness: To easily load from a text file the right Mover to an object.
     *      Dependences: AuxGameObject.
     *      
     * static Movers LoadSML (string text, string id, string dictKey, Transform dictValue, params GameObjectDelegate[] template):
     *      Function: From a SML text and a particular id/method, it creates a mover for a particular object.
     *      When the "cr(<number>)" name is called, it automatically instantiates the specific template given its position in the array.
     *      If a name it's put to be associated with a GameObject, it checks the dictionary of string->Transform.
     *      This function allows to initiate the Dictionary with one element without creating a dictionary for it.
     *      Usefulness: To easily load from a text file the right Mover to an object.
     *      Dependences: AuxGameObject.
     *      
     * static Movers LoadSML (string text, string id, Dictionary<string, Transform> vars, params GameObjectDelegate[] template):
     *      Function: From a SML text and a particular id/method, it creates a mover for a particular object.
     *      When the "cr(<number>)" name is called, it automatically instantiates the specific template given its position in the array.
     *      If a name it's put to be associated with a GameObject, it checks the dictionary of string->Transform.
     *      Usefulness: To easily load from a text file the right Mover to an object.
     *      Dependences: AuxGameObject.
     * */
    public static Movers LoadSML(string text, string id, params GameObjectDelegate[] template)
    {
        return LoadSML(text, id, null, template);
    }
    public static Movers LoadSML(string text, string id, string dictKey, Transform dictValue, params GameObjectDelegate[] template)
    {
        var dict = new Dictionary<string, Transform>();
        dict.Add(dictKey, dictValue);
        return LoadSML(text, id, dict, template);
    }
    public static Movers LoadSML(string text, string id, Dictionary<string, Transform> vars, params GameObjectDelegate[] template)
    {
        return p_LoadSML(text, id, vars, template);
    }

    private static Movers p_LoadSML(string text, string id, Dictionary<string, Transform> vars, params GameObjectDelegate[] template)
    {
        GameObject tr;
        Movers mv = new Movers();
        string method = Auxf.SML.i.GetMethod(text, id);
        if (method == null)
            return null;
        
        foreach (string str in Auxf.SML.i.SplitLines(method))
        {
            string[] tt;
            List<string> sep = new List<string>(Auxf.SML.i.SplitWords(str));
            if (sep.Count < 2 || !sep.Cut(1, 0).IsAll(Auxf.SML.i.FormatParts))
                return null;

            string nameVariable = sep[0];
            sep = sep.Cut(1, 0);


            //Create Object:
            tt = Auxf.SML.i.SplitParts(sep[0]);
            if (tt[0] == "cr")
            {
                int a = int.Parse(tt[1]);
                if (!a.Between(0, template.Length - 1))
                    return null;
                tr = template[a]();
                tr.name = nameVariable;
                sep = sep.Cut(1, 0);

            }
            else if (vars == null || !vars.ContainsKey(nameVariable))
                return null;
            else
                tr = vars[nameVariable].gameObject;
            
            //Asign Material:
            tt = Auxf.SML.i.SplitParts(sep[0]);
            if (tt[0] == "mt" && (Auxg.i.GetMaterial(tt[1]) != null || "-+".IsAny(tt[1][0].Equals)))
            {
                int a;
                if ("-+".IsAny(tt[1][0].Equals))
                {
                    a = int.Parse(tt[1].Substring(1));
                    if (a < 1)
                        return null;
                    else if (a > 1)
                    {
                        var compl = tr.AddComponent<Complement>().complement;
                        while (a > 1)
                        {
                            Debug.Log(a);
                            compl.Add(tr.Duplicate());
                            a--;
                        }
                    }
                    tt[1] = tt[1].SubstringIndex(0, 0);
                }
                foreach (GameObject go in tr.GetRecursive<GameObject>()) 
                    go.Set(Auxg.i.GetMaterial(tt[1]));
                sep = sep.Cut(1, 0);
            }
            
            if (!sep.IsAll<string, string>(Auxf.SML.i.FormatName, Mover.types.IsAny) || !sep.IsAll(Auxf.SML.i.FormatSubs, allowableCode))
                return null;
            
            foreach (string com in sep)
            {
                mv.Add(nameVariable, tr.transform);
                string[] parts = Auxf.SML.i.SplitParts(com);
                foreach (string sub in Auxf.SML.i.SplitSubs(parts[1]))
                {
                    var dict = Auxf.SML.i.Dictionary(sub, allowableCode);
                    if (dict.ContainsKey(obligatory))
                        if (restCode.IsAny(dict.ContainsKey))
                            mv.GetLast.Add(parts[0], mv.GetVector(dict), dict[obligatory]);
                        else
                            mv.GetLast.Add(Mover.typeNothing, Vector3.zero, dict[obligatory]);
                    else if (restCode.IsAny(dict.ContainsKey))
                        mv.GetLast.Add(parts[0], mv.GetVector(dict), 0f);
                    else
                        return null;
                }
            }
        }
        return mv;
    }

    private Vector3 GetVector(Dictionary<char, float> dict)
    {
        return new Vector3(dict.Get('x', 0f), dict.Get('y', 0f), dict.Get('z', 0f));
    }


    //Other Functions:

    /*
     * void Add(string name, Transform nmoveObject):
     *      Function: Adds a new Mover to the list with their parameters inserted directly.
     *      Usefulness: To easily add a new mover and without having to insert the MINIMUM value.
     * */
    public void Add(string name, Transform nmoveObject)
    {
        this.Add(new Mover(name, nmoveObject, MINIMUM));
    }

    /*
     * bool Execute():
     *      Function: Executes a frame of each Mover, to be used in each Update (Time.deltaTime). Returns "false" if all Movers finished.
     *      Usefulness: To quickly execute the Mover functions to all of them, and also inform whether they finished or not.
     *      It combines very well with Auxg.i.ExecuteUntilFalse.
     * */
    public bool Execute()
    {
        int result = 0;
        foreach (Mover m in this)
            result += m.Execute(Time.deltaTime) ? 1 : 0;
        if (result == 0)
            return false;
        return true;
    }

    /*
     * Transform GetObject(string name):
     *      Function: Gets the object of a Mover whose Mover name is the same.
     *      Usefulness: To quickly get an Object from a list of Movers. For other functions.
     * */
    public Transform GetObject(string name)
    {
        foreach (Mover mv in this)
            if (mv.name.Equals(name))
                return mv.getObject;
        return null;
    }

    /*
     * static Movers operator +(Movers append1, Movers append2):
     *      Function: Returns a List of movers that has the movers of both.
     *      Usefulness: To quickly combine different list of movers into one.
     * */
    public static Movers operator +(Movers append1, Movers append2)
    {
        Movers mv = new Movers(append1);
        mv.AddRange(append2);
        return mv;
    }

    /*
     * void Scale(float number):
     *      Function: Applies a scale for all the movers and all their types.
     *      Usefulness: To quickly change the scale of all the movers.
     *      
     * void Scale(float number, params Mover.MovType[] filter):
     *      Function: Applies a scale for all the movers to the specific Movement Types listed.
     *      Usefulness: To quickly change the scale of a particular type in all the movers.
     *      
     * void Scale(Vector3 number):
     *      Function: Applies a scale for all the movers and all their types, with a Vector3 that uses a RawMultiplication.
     *      Usefulness: To quickly change the scale of all the movers with a greater degree of liberty.
     *      
     * void Scale(Vector3 number):
     *      Function: Applies a scale for all the movers to the specific Movement Types listed, with a Vector3 that uses a RawMultiplication.
     *      Usefulness: To quickly change the scale of a particular type in all the movers with a greater degree of liberty.
     * */
    public void Scale (float number)
    {
        foreach (Mover mv in this)
            mv.Scale(number);
    }
    public void Scale (float number, params Mover.MovType[] filter)
    {
        foreach (Mover mv in this)
            mv.Scale(number, filter);
    }
    public void Scale (Vector3 number)
    {
        foreach (Mover mv in this)
            mv.Scale(number);
    }
    public void Scale(Vector3 number, params Mover.MovType[] filter)
    {
        foreach (Mover mv in this)
            mv.Scale(number, filter);
    }

    /*
     * void Delay(float number):
     *      Function: Applies a multiplier delay to the execution time for all the movers and all their types.
     *      Usefulness: To quickly change the time scale of all the movers.
     *      
     * void Delay(float number, params Mover.MovType[] filter):
     *      Function: Applies a multiplier delay to the execution time for all the movers to the specific Movement Types listed.
     *      Usefulness: To quickly change the time scale of a particular type in all the movers.
     * */
    public void Delay (float number)
    {
        foreach (Mover mv in this)
            mv.Delay(number);
    }
    public void Delay (float number, params Mover.MovType[] filter)
    {
        foreach (Mover mv in this)
            mv.Delay(number, filter);
    }

    /*
     * void AppendString(string first, string last):
     *      Function: Appends to the Mover name and the GameObjects name a string before and after their previous name.
     *      Usefulness: Mostly to help distinguish with a different name Movers that are duplicated so they can be combined.
     * */
    public void AppendString (string first, string last = "")
    {
        foreach (Mover mv in this)
        {
            string name = mv.name;
            mv.name = first + mv.name + last;
            if (name == mv.getObject.name)
                mv.getObject.gameObject.name = mv.name;
        }
    }

    /*
     * Movers Inverse (params AuxCoord[] inverses):
     *      Function: Creates a duplicate of the List of movers and all their gameObjects,
     *      and then applies a scale that inverts their position for the quoted coordinates. Their names change to be "i<" + name + ">".
     *      Usefulness: To create a mirrored or opposite Mover to combine.
     * */
    public Movers Inverse (params AuxCoord[] inverses)
    {
        Transform tr = null;
        Movers mvs = new Movers(this, true);
        
        Vector3 inverse = new Vector3 (inverses.Contains(AuxCoord.x) ? -1 : 1,
            inverses.Contains(AuxCoord.y) ? -1 : 1, inverses.Contains(AuxCoord.z) ? -1 : 1);
        foreach (string name in mvs.Names)
        {
            tr = null;
            foreach (Mover mv in mvs)
                if (mv.name == name)
                {
                    if (tr == null)
                        tr = mv.getObject.Duplicate(true);
                    mv.getObject = tr;
                }
        }
        mvs.Scale(inverse, Mover.MovType.position);
        mvs.AppendString("i<", ">");
        return mvs;
    }
}


/*
 * Class Mover:
 *      This class saves data of an object and the different moves it should do in each particular moment, one after the other.
 *      It allows for "nothing" (nt, to wait seconds), "position" (tr), "rotation" (rt), "scale" (sc) and "size" (sz).
 *      It also allows local or global modification (a[]).
 *      
 * */
public class Mover
{
    public enum MovType { nothing, position, rotation, scale, size }

    public static readonly string[] types = { "nt", "tr", "rt", "sc", "sz", "atr", "art", "asc", "asz" };
    public static readonly string typeNothing = "nt";

    public string name;

    private Transform moveObject;
    public Transform getObject { get { return moveObject; } set { if (!initiated) moveObject = value; } }

    /*
     * Struct MovementClass:
     *      This struct saves each particular type of movement, the amount to move, if it's local or global, incremental or absolute,
     *      and the time it takes. The order of these MovementClass means they will be applied one after the other.
     * */
    public struct MovementClass
    {
        //Attributes:
        public MovType type;
        public Vector3 movement;
        public bool local;
        public bool incremental;

        public float time;

        //Constructors:
        public MovementClass(MovType ntype, Vector3 nmovement, float ntime, bool nlocal, bool nincremental)
        {
            type = ntype;
            movement = nmovement;
            time = ntime;
            local = nlocal;
            incremental = nincremental;
        }

        //Functions:

        /*
         * MovementClass Scale(float number):
         *      Function: Applies a scale for the MovementClass and returns it.
         *      Usefulness: To quickly change a MovementClass for a float value.
         *      
         * MovementClass Scale(Vector3 number):
         *      Function: Applies a scale for the MovementClass and returns it.
         *      Usefulness: To quickly change a MovementClass for a vector3 value with Raw Multiplication.
         *      Dependences: Auxe.
         * */
        public MovementClass Scale(float number)
        {
            return new MovementClass(type, movement * number, time, local, incremental);
        }
        public MovementClass Scale(Vector3 number)
        {
            return new MovementClass(type, movement.RawMult(number), time, local, incremental);
        }


        /*
         * void Delay(float number):
         *      Function: Applies a proprtional delay for the MovementClass and returns it.
         *      Usefulness: To quickly change the time of a MovementClass.
         * */
        public MovementClass Delay(float number)
        {
            return new MovementClass(type, movement, time * number, local, incremental);
        }
    }
    private List<MovementClass> dict;

    private readonly float MINIMUM;
    private float currentTime;
    private Vector3 currentMovement;
    private Vector3 limit;
    private bool initiated;
    private RectTransform rect;
    private Transform auxt;


    //Constructors:
    public Mover (string nname, Transform nmoveObject, float min)
    {
        name = nname;
        MINIMUM = min;
        currentTime = 0f;
        moveObject = nmoveObject;
        dict = new List<MovementClass>();
        initiated = false;
    }
    public Mover(Mover mv)
    {
        name = mv.name;
        MINIMUM = mv.MINIMUM;
        currentTime = 0f;
        moveObject = mv.moveObject;
        dict = mv.dict.Clone();
        initiated = false;
    }

    //Add Functions:

    /*
     * void Add(MovementClass nclass):
     *      Function: Adds in the Mover a new MovementClass.
     *      Usefulness: To insert a MovementClass in the list.
     *      
     * void Add(float ntime):
     *      Function: Adds in the Mover a "nothing" MovementClass with a particular delay.
     *      Usefulness: To easily insert a wait in the MovementClass.
     *      
     * void Add(MovType ntype, Vector3 nmovement, float ntime, bool nlocal, bool nincremental):
     *      Function: Adds in the Mover a new MovementClass with all their parameters separated.
     *      Usefulness: To insert a MovementClass in the list with their elements separated.
     *      
     * void Add(string ntype, Vector3 nmovement, float ntime):
     *      Function: Adds in the Mover a new MovementClass with all their parameters separated.
     *      The string type is identified in the string[] types (nt, tr, rt, sc, sz, atr, art, asc, asz).
     *      It assumes it's always local the movement.
     *      Usefulness: To insert a MovementClass in the list with their elements separated and the string including local and incremental.
     * */
    public void Add (MovementClass nclass)
    {
        dict.Add(nclass);
    }
    public void Add (float ntime) {
        Add(MovType.nothing, Vector3.zero, ntime, true, true);
    }
    public void Add (MovType ntype, Vector3 nmovement, float ntime, bool nlocal, bool nincremental)
    {
        Add(new MovementClass(ntype, nmovement, ntime, nlocal, nincremental));
    }
    public void Add (string ntype, Vector3 nmovement, float ntime)
    {
        switch (ntype)
        {
            case "nt":
                Add(MovType.nothing, Vector3.zero, ntime, true, true);
                break;
            case "tr":
                Add(MovType.position, nmovement, ntime, true, true);
                break;
            case "rt":
                Add(MovType.rotation, nmovement, ntime, true, true);
                break;
            case "sc":
                Add(MovType.scale, nmovement, ntime, true, true);
                break;
            case "sz":
                Add(MovType.size, nmovement, ntime, true, true);
                break;
            case "atr":
                Add(MovType.position, nmovement, ntime, true, false);
                break;
            case "art":
                Add(MovType.rotation, nmovement, ntime, true, false);
                break;
            case "asc":
                Add(MovType.scale, nmovement, ntime, true, false);
                break;
            case "asz":
                Add(MovType.size, nmovement, ntime, true, false);
                break;
        }
    }


    //Other Functions:

    /*
     * bool Execute(float TM):
     *      Function: Executes the Mover, particulary that movement amount (which should be Time.deltaTime). Returns "false" if it ended.
     *      Usefulness: To execute the Mover function with the right amount, and also inform whether they finished or not.
     * */
    public bool Execute (float TM)
    {
        Vector3 tmov;

        if (!initiated)
        {
            Initialize();
            initiated = true;
        }

        if (dict.Count > 0)
        {
            if (dict[0].time < MINIMUM)
            {
                if (dict[0].incremental)
                    Write(dict[0].movement);
                else
                    Overwrite(dict[0].movement);
                Delete();
                return Execute(TM);
            }
            else
            {
                tmov = (dict[0].incremental ? dict[0].movement : (dict[0].movement - limit)) * TM / dict[0].time;
                Write(tmov);
                currentTime += TM;
                if (dict[0].incremental)
                    currentMovement += tmov;
                if (currentTime >= dict[0].time)
                {
                    if (dict[0].incremental)
                        Write(dict[0].movement - currentMovement);
                    else
                        Overwrite(dict[0].movement);
                    Delete();
                }
            }
            return true;
        }
        return false;
    }

    /*
     * void Scale(float number):
     *      Function: Applies a scale for the mover and all its types.
     *      Usefulness: To quickly change the scale of the mover.
     *      
     * void Scale(float number, params Mover.MovType[] filter):
     *      Function: Applies a scale for the mover to the specific Movement Types listed.
     *      Usefulness: To quickly change the scale of a particular type in the mover.
     *      
     * void Scale(Vector3 number):
     *      Function: Applies a scale for the mover and all its types, with a Vector3 that uses a RawMultiplication.
     *      Usefulness: To quickly change the scale of the mover with a greater degree of liberty.
     *      
     * void Scale(Vector3 number):
     *      Function: Applies a scale for the mover to the specific Movement Types listed, with a Vector3 that uses a RawMultiplication.
     *      Usefulness: To quickly change the scale of a particular type in the mover with a greater degree of liberty.
     * */
    public void Scale(float number)
    {
        for (int i=0; i<dict.Count; i++)
            dict[i] = dict[i].Scale(number);
    }
    public void Scale(float number, params MovType[] filter)
    {
        for (int i = 0; i < dict.Count; i++)
            if (filter.Contains(dict[i].type))
                dict[i] = dict[i].Scale(number);
    }
    public void Scale(Vector3 number)
    {
        for (int i = 0; i < dict.Count; i++)
            dict[i] = dict[i].Scale(number);
    }
    public void Scale(Vector3 number, params MovType[] filter)
    {
        for (int i = 0; i < dict.Count; i++)
            if (filter.Contains(dict[i].type))
                dict[i] = dict[i].Scale(number);
    }

    /*
     * void Delay(float number):
     *      Function: Applies a multiplier delay to the execution time for the mover and all its types.
     *      Usefulness: To quickly change the time scale of the mover.
     *      
     * void Delay(float number, params Mover.MovType[] filter):
     *      Function: Applies a multiplier delay to the execution time for the mover to the specific Movement Types listed.
     *      Usefulness: To quickly change the time scale of a particular type in the mover.
     * */
    public void Delay (float number)
    {
        for (int i = 0; i < dict.Count; i++)
            dict[i] = dict[i].Delay(number);
    }
    public void Delay (float number, params MovType[] filter)
    {
        for (int i = 0; i < dict.Count; i++)
            if (filter.Contains(dict[i].type))
                dict[i] = dict[i].Delay(number);
    }


    //Private Functions:
    
    private void Initialize()
    {
        if (dict.Count > 0)
        {
            currentTime = 0f;
            currentMovement = Vector3.zero;
            limit = Read();
        }
    }
    private void Delete ()
    {
        dict.RemoveAt(0);
        Initialize();
    }
    private void Write (Vector3 amount)
    {
        switch (dict[0].type)
        {
            case MovType.position:
                moveObject.Translate(amount, dict[0].local? Space.Self: Space.World);
                break;
            case MovType.rotation:
                moveObject.Rotate(amount, dict[0].local ? Space.Self : Space.World);
                break;
            case MovType.scale:
                moveObject.localScale += amount;
                break;
            case MovType.size:
                Rect(moveObject).sizeDelta += (Vector2) amount;
                break;
        }
    }
    private void Overwrite(Vector3 amount)
    {
        switch (dict[0].type)
        {
            case MovType.position:
                Debug.Log(amount);
                Write(amount - (dict[0].local ? moveObject.localPosition : moveObject.position));
                break;
            case MovType.scale:
                Write(amount - moveObject.localScale);
                break;
            case MovType.size:
                Write(amount - (Vector3) Rect(moveObject).sizeDelta);
                break;
        }
    }
    private Vector3 Read ()
    {
        switch (dict[0].type)
        {
            case MovType.position:
                return dict[0].local ? moveObject.localPosition : moveObject.position;
            case MovType.rotation:
                return dict[0].local ? moveObject.localRotation.eulerAngles : moveObject.rotation.eulerAngles;
            case MovType.scale:
                return dict[0].local ? moveObject.localScale : moveObject.lossyScale;
            case MovType.size:
                return Rect(moveObject).sizeDelta;
            default:
                return Vector3.zero;
        }
    }
    private RectTransform Rect(Transform t)
    {
        if (t == null)
            rect = null;
        else if (rect == null || t != auxt)
            rect = t.GetComponent<RectTransform>();
        auxt = t;
        return rect;
    }
}
