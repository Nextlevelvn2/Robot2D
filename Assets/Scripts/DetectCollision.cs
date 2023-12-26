using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public bool StatusNen;
    public int JumbCount;
    [SerializeField]
    LayerMask whatIsGround;
    bool grounded = false;
    float groundedRadius = 0.4f;
    public Transform groundCheck;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jumb();
    }
    private void Jumb()
    {
        StatusNen = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
        Debug.Log(StatusNen);
        if(StatusNen)
        {
            JumbCount = 0;
            Debug.Log("ok");
        }
    }
}
