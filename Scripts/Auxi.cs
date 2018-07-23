/*
 * Auxi (Auxiliar Input):
 * This file contains a gameObject and functions to structure and expand input operations in Unity C#.
 * It needs the library "System.Collections.Generic" and "UnityEngine" to work, so it only works on Unity projects.
 * 
 * Developed by Alberto León Meaños, 22/07/2018, License GNU General Public License v3.0
 * */


using System.Collections.Generic;
using UnityEngine;


/*
 * Class Auxi : MonoBehaviour
 *      GameObject script that allows to configure a bunch of keys for a particular name instead of for separate with the struct "KeyPar".
 *      You configure this from the Unity Editor, and it's needed that this class has the tag "TAuxi" to work.
 *      (i.e. you can create the string "Down" associated to the keys "downArrow", "S", "Numpad2", "JoystickDown", etc.)
 * */
public class Auxi : MonoBehaviour
{
    [System.Serializable]
    public struct KeyPar
    {
        public string name;
        public List<KeyCode> keys;

        public KeyPar(string name, params KeyCode[] keys) : this(name, (IEnumerable<KeyCode>)keys) { }
        public KeyPar(string name, IEnumerable<KeyCode> keys)
        {
            this.keys = new List<KeyCode>(keys);
            this.name = name;
        }
    }
    public List<KeyPar> keys;
}


/*
 * Class AuxInput
 *      It allows to call generic Key functions with a string defined in the Auxi class.
 *      
 *      IMPORTANT: When this function is called, it searches inmediately for the GameObject that has the TAuxi tag, and take its Auxi script.
 * */
public class AuxInput
{
    //Singleton (invoke by calling "Auxi.i"):
    private static AuxInput m_instance = null;
    public static AuxInput i { get { if (m_instance == null) m_instance = new AuxInput(); return m_instance; } }
    private AuxInput () { auxi = GameObject.FindGameObjectWithTag("TAuxi").GetComponent<Auxi>(); }
    private Auxi auxi;


    //Public Functions:

    /*
     * bool GetKeyDown(string list):
     *      Function: Returns whether a particular string (and therefore, any KeyCode associated with it) has been pressed down.
     *      Usefulness: To use Input.GetKeyDown for any KeyPar.
     * */
    public bool GetKeyDown (string list)
    {
        return GetKeyX(list, "down");
    }

    /*
     * bool GetKeyDown(string list):
     *      Function: Returns whether a particular string (and therefore, any KeyCode associated with it) is being pressed.
     *      Usefulness: To use Input.GetKey for any KeyPar.
     * */
    public bool GetKey(string list)
    {
        return GetKeyX(list, "hold");
    }

    /*
     * bool GetKeyUp(string list):
     *      Function: Returns whether a particular string (and therefore, any KeyCode associated with it) has been pressed up.
     *      Usefulness: To use Input.GetKeyUp for any KeyPar.
     * */
    public bool GetKeyUp(string list)
    {
        return GetKeyX(list, "up");
    }


    //Private Functions:
    private bool GetKeyX (string list, string type)
    {
        foreach (var key in auxi.keys)
            if (key.name == list)
                foreach (var keycode in key.keys)
                    if (Press(keycode, type))
                        return true;
        return false;
    }
    private bool Press(KeyCode kc, string type)
    {
        switch (type)
        {
            case "down":
                return Input.GetKeyDown(kc);
            case "hold":
                return Input.GetKey(kc);
            case "up":
                return Input.GetKeyUp(kc);
        }
        return false;
    }
}
