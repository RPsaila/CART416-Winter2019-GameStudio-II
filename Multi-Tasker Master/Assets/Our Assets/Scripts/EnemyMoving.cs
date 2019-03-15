//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyMoving : MonoBehaviour
//{
//    Enemy myEnemyScript;
//    public List<GameObject> enemies;
//    public List<GameObject> spawnPoints;

//    public float Speed;

//    // Start is called before the first frame update
//    IEnumerator Start()
//    {
//        for (int i = 0; i < spawnPoints.Count; i++)
//        {
//            myEnemyScript = spawnPoints[i].GetComponent<Enemy>();
//        }
//        enemies = myEnemyScript.enemies;
//        spawnPoints = myEnemyScript.spawnPoints;

//        yield return new WaitForEndOfFrame();
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    public void EnemyMoves()
//    {
//            for (int i = 0; i < enemies.Count; i++)
//            {
//            enemies[i].transform.Translate(-Vector3.forward * Speed);
//        }
//    }
//}
