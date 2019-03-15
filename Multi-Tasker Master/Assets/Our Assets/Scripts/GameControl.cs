using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Help from Unity Data Persistence Live https://www.youtube.com/watch?v=J6FfcJpbPXE

public class GameControl : MonoBehaviour
{
    public static GameControl control;
    public CursorLockMode myClockScript;
    public Manager myManagerScript;

    public float schoolGPA;
    public int hunger; //Health Wake Up Time and Sleep Night Time depending on Clock Object

    public int hungerValue;
    public float schoolValue;
    public int EnnemyWaveCount;

    // Start is called before the first frame update
    void Awake ()
    {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {

        hunger = 100;
        schoolGPA = 1.50f;

    }

    public void OnGui()
    {

    GUI.Label(new Rect(10, 10, 100, 30), "School:" + schoolGPA);
    GUI.Label(new Rect(10, 10, 100, 30), "Hunger:" + hunger);

    }

    public void DisplayHungerANDschoolGPA()
    {



    }

    public void AssociateCoinValue()
    {

    }

    public void SchoolGPAGoesUp()
    {


    }
}
