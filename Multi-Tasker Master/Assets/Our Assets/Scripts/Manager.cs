using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Help A from : https://unity3d.com/fr/learn/tutorials/projects/survival-shooter/more-enemies
    // Help B from : https://answers.unity.com/questions/1153937/destroy-prefabs-after-theyve-been-instantiated-c.html
    // Help C from : https://forum.unity.com/threads/solved-find-nearest-object-in-array-destroy-it-move-to-next-nearest.328061/
    // Help E from : https://answers.unity.com/questions/1382868/disable-object-and-enable-by-distance-from-player.html

    // Unity Documentation Help
    // https://docs.unity3d.com/Manual/DirectionDistanceFromOneObjectToAnother.html
    // https://unity3d.com/learn/tutorials/topics/scripting/object-pooling

    // Don't forget to go to the CDA lab if you need more help implementing or understanding stuff or ask me.

    // Later Use for Reference to the player's stats. Check Help A for example in the references above.
    // public PlayerHealth playerHealth;

    // List used to store and tag all the enemies spawned

    public List<GameObject> enemies = new List<GameObject>(); // List containing all enemies
    public List<GameObject> spawnPoints = new List<GameObject>(); // List containing all Enemy spawnPoints

    public GameObject enemyPrefab; // The enemy prefab to be spawned.
    public float spawnTime = 3f; // How long between each spawn.

    public int enemyCount; // Number of enemies
    public int maxEnemies = 30; // Maximum number of enemies allowed

    public int maxEnemySpawns = 3; // Maximum number of spawn points
    private float startTime;
    private float timePassed;

    // For Later use for triggering Enemies in a certain distance. Checkp Help C or D

    //public GameObject[] activeEnemies; // Not necessary

    //private GameObject nearestTarget;
    //private float distance;
    //private float curDistance;
    //public Vector3 pos;
    //private Vector3 diff;
    //public bool EnemyIsActivated;

    // public float range = 15; 

    // For Later Use for multiple spawnPoints, check Help A.

    // Potentially for Later Use for Timing (Better scores depending on better timings?)
    // public float TimeLimit;
    // public float Timer;

    //public void Awake()
    //{
    //    Debug.Log("AwakeWorks");
    //    GameObject.FindGameObjectsWithTag("EnemySpawn");
    //}

    // Start is called before the first frame update
    public void Start()
        {
        StartCoroutine(Spawn());
        // Spawn ennemies from Spawn() every spawnTime
        // InvokeRepeating("Spawn", spawnTime, spawnTime);


        //myMovingEnemyScript.EnemyMoves();
    }

    // For Later use for triggering Enemies in a certain distance. Checkp Help C

    //nearestTarget = null;
    //distance = Mathf.Infinity;
    //PlayerPosition = GameObject.Find("Player");
    //FindTarget();


    // Update is called once per frFindTarget()ame
    public void FixedUpdate()
    {
      
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].GetComponent<Moving>().EnemyMoves();
        }
    }

    //if (enemySpawnCount < maxEnemySpawns)
    //{
    //for (int i = 0; i < spawnPoints.Count; i++)
    //{
    //    spawnPoints[i].gameObject.tag = "EnemySpawn";
    //    Debug.Log(GameObject.FindGameObjectsWithTag("EnemySpawn");
    //    foreach (GameObject EnemySpawn in spawnPoints)
    //        {
    //            myMovingEnemyScript.EnemyMoves();
    //            Debug.Log(spawnPoints.Count);
    //        }
    //}

    // For Later use for triggeringFindTarget() Enemies in a certain distance. Checkp Help D
    // float distance = Vector3.Distance(PlayerPosition.transform.position, enemies.transform.position);
    //{
    //    if (distance >= range)
    //    {
    //        for (int i = 0; i < activeEnemies.Length; i++)
    //            activeEnemies[i].SetActive(false);
    //            EnemyIsActivated = false;
    //    }
    //    else
    //    if (distance <= range)
    //    {
    //        for (int i = 0; i < activeEnemies.Length; i++)
    //            activeEnemies[i].SetActive(true);
    //            EnemyIsActivated = true;
    //    }

    // Use Debug.Log("works") to spawn the enemies and keep track of them
    public IEnumerator Spawn()
        {
        while (true)
        {
            // As long as ennemyCount is below max Enemies => Spawn Enemies
            if (enemies.Count < maxEnemies) //&& spawnPoints.Count == maxEnemySpawns)
            {
                for (int i = 0; i < spawnPoints.Count; i++)
                {
                    GameObject newEnemy = Instantiate(enemyPrefab, spawnPoints[i].transform.position, spawnPoints[i].transform.rotation) as GameObject;
                    newEnemy.gameObject.tag = "MovingEnemy";
                    enemies.Add(newEnemy);
                    enemyCount++;
                  
                    StartCoroutine(WaitBetweenSpawn());
                    Debug.Log("addedEnemy");
                    yield return new WaitForSeconds(2f);
                }


                // yield return new WaitForSeconds(3f);
                // For DEBUG Purposes Only

                //if (GameObject.FindGameObjectsWithTag("MovingEnemy").Length > 4)
                //{
                //    //DEBUG logs to keep track if needed

                //    //Debug.Log("it finds all enemies!");
                //    //Debug.Log(enemyCount);
                //    //Debug.Log(enemies.Count);
                //}
                //else if (enemyCount == maxEnemies)
                //{
                //enemyCount = 0;
                //}
                // }

                yield return new WaitForSeconds(5f);



            }
           
        }


    }
    public IEnumerator WaitBetweenSpawn()
    {
        Debug.Log("wait");
        yield return new WaitForSeconds(1f);
    }



}

// For Later use for triggering Enemies in a certain distance. Checkp Help C

//public void FindTarget()
//{
//    foreach (GameObject Enemy in activeEnemies)
//    {
//        diff = Enemy.transform.position - pos;
//        curDistance = diff.sqrMagnitude;
//        if (curDistance < distance)
//        {
//            nearestTarget = Enemy;
//            enemyPrefab = nearestTarget;
//            distance = curDistance;
//        }
//    }
//}

// Experimentation for later use or to be trashed

//foreach (GameObject obj in activeEnemies)
//{
//    float distance = Vector3.Distance(Enemy.transform.position, PlayerPosition.transform.position);

//    if (distance >= range)

//    {
//        EnemyIsActivated = false;
//    }

//    else if (distance <= range)

//    {
//        EnemyIsActivated = false;
//    }

//public void DestroyActiveEnemies()
//{
//    PlayerPosition = GameObject.Find("Player");
//    float distance = Vector3.Distance(PlayerPosition.transform.position, spawnPoint.transform.position);
//    if (distance >= range)
//    {
//        foreach (GameObject Enemy in activeEnemies)
//        {
//            EnemyIsActivated = false;
//        }
//    }
//    else if (distance <= range)
//    {
//        foreach (GameObject Enemy in activeEnemies)
//        {
//            EnemyIsActivated = false;
//        }
//    }
//}

//{
//float lowestDist = Mathf.Infinity;
//    for (int i = 0; i < activeEnemies.Count; i++)
//    {
//        float dist = Vector3.Distance(activeEnemies[i].transform.position, PlayerPosition.transform.position);

//        if (dist < lowestDist)
//        {
//            lowestDist = dist;
//            enemyPrefab = activeEnemies[i];
//        }

//    }
//}


