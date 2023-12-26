using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    public float dis;
    // Start is called before the first frame update
    void Start()
    {
        dis = Mathf.Abs(Player.transform.position.y - transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + dis, transform.position.z);
    }
}
