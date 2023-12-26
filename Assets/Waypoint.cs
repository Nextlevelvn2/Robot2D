using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public GameObject enm;
    public bool isChasing = false;
    // Start is called before the first frame update
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            isChasing = true;
            enm.GetComponent<EnemyController>().isChasing = isChasing;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        { 
            isChasing = false;
            enm.GetComponent<EnemyController>().isChasing = isChasing;
        }
    }

}
