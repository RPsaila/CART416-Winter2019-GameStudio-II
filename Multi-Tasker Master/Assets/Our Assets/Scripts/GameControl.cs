using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem.Sample;

// Help from Unity Data Persistence Live https://www.youtube.com/watch?v=J6FfcJpbPXE

public class GameControl : MonoBehaviour {

    // Main Manager GameObjects
    public GameObject GameControlObject;
    public GameObject Manager;

    // References to other scripts
    public FoodInteractions myInteractionsScript; // Scripts on FoodPrefabs for collision with head and associating Hunger & Money value
    public Tool1 myToolScript;
    public Clock myClockScript; // TO BE USED LATER

    // Define Main Variables
    public float schoolGPA; // Global Variable for overall academic performance linked with hunger (if lower than 50 out of 100...)
    public float hunger; // Global Health/Hunger variable similar to Minecraft (goes down over time)
    public float studentBudget; // Global Student Budget variable used for food interactions, updates after semester (4 enemy waves)

    // Define Main Sub Variables
    public float schoolEnemyValue; // When you hit an enemy, add schoolEnemyValue to SchoolGPA

    // Define Main Hunger Values
    public float hungerSnacksValue; // When a new Food Low prefab is created, assign Snacks tag and hungerSnacksValue
    public float hungerFastFoodsValue;
    public float hungerMealsValue;

    // Define Main Money Values
    public float moneySnacksValue; // When a new Food prefab with Snacks tag is added to the Food objects list, remove snacksMoneyValue from budget
    public float moneyFastFoodsValue; // When a new Food prefab with FastFoods tag is added to the Food objects list, remove moneyFastFoodsValue from budget
    public float moneyMealsValue; // When a new Food prefab with Meals tag is added to the Food objects list, remove moneyMealsValue from budget

    public int enemyWaveCount; //TO BE USED LATER When 30 enemies have spawned stop spawning enemies until link Clock

    // Define Main Arrays of Types of Food Prefabs
    public GameObject[] newSnacks;
    public GameObject[] newFastFoods;
    public GameObject[] newMeals;

    // Define Main List of foodPrefabs & enemy list from Manager Script
    public List<GameObject> foodPrefabs = new List<GameObject>();
    private List<GameObject> enemies;

    // FOR LATER USE Define Main Display Objects
    // public TMPro.TextMeshPro shownSchoolGPA;

    //void Awake ()
    //{
    //    if(GameControlObject == null)
    //    {
    //        DontDestroyOnLoad(gameObject);
    //        GameControlObject = this;
    //    }
    //    else if(GameControlObject != this)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    // Start is called before the first frame update
    IEnumerator Start()
    {
        hunger = 100;
        schoolGPA = 1.50f;

        myInteractionsScript = GetComponent<FoodInteractions>();
        myClockScript = GetComponent<Clock>(); // TO BE USED LATER FOR ENEMY WAVE COUNT AND HUNGER VARIABLE GOING DOWN
        enemies = Manager.GetComponent<Manager>().enemies;
 
        yield return new WaitForEndOfFrame();

    }

    public void FixedUpdate()
    {
        if (foodPrefabs.Count > 0)
        {
        GameObject.FindGameObjectsWithTag("Snacks");
        newSnacks = GameObject.FindGameObjectsWithTag("Snacks");
        GameObject.FindGameObjectsWithTag("FastFoods");
        newFastFoods = GameObject.FindGameObjectsWithTag("FastFoods");
        GameObject.FindGameObjectsWithTag("Meals");
        newMeals = GameObject.FindGameObjectsWithTag("Meals");

        GenerateSnacksCoinandHungerValues();
        GenerateFastFoodCoinandHungerValues();
        GenerateMealsCoinandHungerValues();
            {
            FoodMoneySystem();
            }
        }
    }

    //public void OnGui()
    //{

    //GUI.Label(new Rect(10, 10, 100, 30), "School:" + schoolGPA);
    //GUI.Label(new Rect(10, 10, 100, 30), "Hunger:" + hunger);

    //}

    //public void DisplayHungerANDschoolGPA()
    //{



    //}

    public void FoodMoneySystem()
    {
        Debug.Log(foodPrefabs.Count);
        for (int i = 0; i < foodPrefabs.Count; i++)
            for (int k = 0; k < newSnacks.Length; k++)
                for (int l = 0; l < newFastFoods.Length; l++)
                    for (int m = 0; m < newMeals.Length; m++)
                    {
                        foreach (GameObject newSnacks in foodPrefabs)
                        {
                            hunger = hunger - hungerSnacksValue;
                        }
                        foreach (GameObject newFastFoods in foodPrefabs)
                        {
                            hunger = hunger - hungerFastFoodsValue;
                        }
                        foreach (GameObject newMeals in foodPrefabs)
                        {
                            hunger = hunger - hungerMealsValue;
                        }
                    }
    }

    public void GenerateSnacksCoinandHungerValues()
    {
        if (foodPrefabs.Count > 0 && newSnacks.Length > 0)
        {
            moneySnacksValue = Random.Range(1.00f, 10.00f);
            hungerSnacksValue = moneySnacksValue;
        }
    }

    public void GenerateFastFoodCoinandHungerValues()
    {
        if (foodPrefabs.Count > 0 && newFastFoods.Length > 0)
        {
            moneyFastFoodsValue = Random.Range(7.50f, 20.00f);
            moneyFastFoodsValue = hungerFastFoodsValue;
        }
    }

    public void GenerateMealsCoinandHungerValues()
    {
        if (foodPrefabs.Count > 0 && newMeals.Length > 0)
        {
            moneyMealsValue = Random.Range(15.00f, 40.00f);
            moneyMealsValue = hungerMealsValue;
        }
    }

    public void AddSchoolGPA(float points)
    {
        if (myToolScript.collided == true)
            {
                 points = 0.08f;
                 schoolGPA = schoolGPA + points;
            }
    }
}

// NOT USED CURRENTLY
//public void ResetScore()
//{
//    studentBudget = 1000;
//}

//   void ShuffleArray<T>(T[] array)
//   {
//       int n = array.Length;
//       for (int i = 0; i < n; i++)
//       {
//           // Pick a new index higher than current for each item in the array
//           int r = i + Random.Range(0, n - i);

//           // Swap item into new spot
//           T t = array[r];
//           array[r] = array[i];
//           array[i] = t;
//       }
//   }

//   // Somewhere else
//   // objectList is a List<GameObject>

//   // We don't want to mess up the original list, copy it
//   var objectArray = objectList.ToArray();
//   ShuffleArray(objectArray);  // Call this more to shuffle again
//foreach (var o in objectArray) {
//  // This will be a random order of objectList
//}
