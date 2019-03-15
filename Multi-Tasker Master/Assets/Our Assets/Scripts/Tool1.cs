using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool1 : MonoBehaviour
{
    public GameObject Manager;

    private List<GameObject> enemies;

    // Start is called before the first frame update

    IEnumerator Start()
    {
        enemies = Manager.GetComponent<Manager>().enemies;
        yield return new WaitForEndOfFrame();
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
      
    }

    private void OnCollisionEnter(Collision enemy)
    {
        //Debug.Log("works");
        if (enemy.gameObject.tag == "MovingEnemy")
        {
            //Debug.Log("enemycollision");
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                //Debug.Log(i);
                if (enemies[i].gameObject.Equals(enemy.gameObject))
                {
                    //Debug.Log("enemycollision detected");
                    enemies.Remove(enemies[i].gameObject);
                    Destroy(enemy.gameObject);
                    // You killed my father, prepare to die!
                }
            }
        }
    }
}