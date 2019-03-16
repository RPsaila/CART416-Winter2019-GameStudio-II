using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInteractions : MonoBehaviour
{
    //SHOULD IT BE ON THE HEAD ? 
    public static GameControl myGameControlScript;
    public GameObject GameControlObject;

    public GameObject PlayerHead;

    public GameObject[] newSnacks;
    public GameObject[] newFastFoods;
    public GameObject[] newMeals;

    public float hunger;
    private float hungerPlus;

    // Start is called before the first frame update
    void Start()
    {
        hunger = GameControlObject.GetComponent<GameControl>().hunger;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject.FindGameObjectsWithTag("Snacks");
        newSnacks = GameObject.FindGameObjectsWithTag("Snacks");
        GameObject.FindGameObjectsWithTag("FastFoods");
        newFastFoods = GameObject.FindGameObjectsWithTag("FastFoods");
        GameObject.FindGameObjectsWithTag("Meals");
        newMeals = GameObject.FindGameObjectsWithTag("Meals");
        hunger = GameControlObject.GetComponent<GameControl>().hunger;
    }

    // If 
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == PlayerHead && 
        {
            if (GetCom
            hunger = hunger + 

        }
    }
}
