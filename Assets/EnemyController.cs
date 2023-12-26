using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] Waypoints;
    public GameObject Enemy;
    Animator animator;
    Rigidbody2D rb;
    private int currentWaypoint=0;
    private float speed = 1f;
    public Transform Player;
    public GameObject WayPoint;
    public bool isChasing;
    public Waypoint wp;
    public bool isAttacking;
    void Start()
    {
        rb = Enemy.GetComponent<Rigidbody2D>();
        animator = Enemy.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isAttacking", isAttacking);
        if (isChasing)
        {
            ChasePlayer();
        }
        else if (!isChasing)
        {
            DetectWaypoint();
        }
        Debug.Log(isChasing);
    }
    void ChasePlayer()
    {
        //if(Mathf.Abs(Player.transform.position.x - Enemy.transform.position.x) <= 2.5f)
        //{
        //    animator.SetBool("isAttacking", true);
        //    if (Mathf.Abs(Player.transform.position.x - Enemy.transform.position.x) >= 2.5f)
        //    {
        //        animator.SetBool("isAttacking", false);
        //    }
        //}
        if (Enemy.transform.position.x > (Player.position.x + 2f))
        {
            Enemy.transform.localScale = new Vector3(3f, 3f, 1f);
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if ((Enemy.transform.position.x + 2f) < Player.position.x)
        {
            Enemy.transform.localScale = new Vector3(-3f, 3f, 1f);
            transform.position -= Vector3.left * speed * Time.deltaTime;
        }

    }
    void DetectWaypoint()
    {
        animator.SetFloat("Speed", speed);
        if(currentWaypoint == 0)
        {
            Enemy.transform.localScale = new Vector3(-3f, 3f, 1f);
            rb.transform.position = Vector2.MoveTowards(rb.transform.position, Waypoints[1].transform.position, speed * Time.deltaTime);
            if(Vector2.Distance(Enemy.transform.position, Waypoints[1].transform.position) <.5f)
            {
                currentWaypoint = 1;
            }
        }
        if (currentWaypoint == 1)
        {
            Enemy.transform.localScale = new Vector3(3f, 3f, 1f);
            rb.transform.position = Vector2.MoveTowards(rb.transform.position, Waypoints[0].transform.position, speed * Time.deltaTime);
            if (Vector2.Distance(Enemy.transform.position, Waypoints[0].transform.position) < .5f)
            {
                currentWaypoint = 0;
            }
        }
    }
   

}
