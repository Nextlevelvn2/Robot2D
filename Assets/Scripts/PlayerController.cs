using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public float Speed;
    public float MaxSpeed = 13.5f;
    public float JumpSpeed = 20f;
    public bool StatusNen;
    public int JumbCount=0;
    [SerializeField]
    LayerMask whatIsGround;
    float groundedRadius = 0.6f;
    public Transform groundCheck;
    private float timeHoldBtn;
    private bool btnPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        AddForce(Speed);
        Jumb();
    }
    public void PreviousDown_click()
    {
        Speed = -MaxSpeed;
        Vector3 scale = transform.localScale;
        scale.x = -1.5f;
        transform.localScale = scale;
    }
    public void PreviousUp_click()
    {
        Speed = 0;
    }
    public void NextDown_click()
    {
        btnPressed = true;
        Speed = MaxSpeed;
        Vector3 scale = transform.localScale;
        scale.x = 1.5f;
       transform.localScale = scale;
        timeHoldBtn = Time.time + 1.5f;
    }
    public void NextHold_Enter()
    {
        
    }
    public void NextUp_click()
    {
        Speed = 0;
        btnPressed = false;
    }
    public void ADown_click()
    {
        if (StatusNen)
        {
            JumbCount = 0;
        }
        if (JumbCount <= 1)
        {
            JumbCount += 1;
            rb.AddForce(new Vector2(0f, 2000f));
        }
    }
    public void AUp_click()
    {
    }
    public void BDown_click()
    {
        Speed = 12f;
    }
    public void BUp_click()
    {
        Speed = 0f;
    }
    public void AddForce(float speed)
    {
        float sp = Mathf.Abs(Speed);
        rb.AddForce(new Vector2(speed,0));
        animator.SetFloat("Speed", sp);
        animator.SetBool("IsGround", StatusNen);
    }
    private void Jumb()
    {
        StatusNen = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
        if (Time.time > timeHoldBtn && btnPressed == true)
        {
            Speed = 14f;
        }
    }
}
