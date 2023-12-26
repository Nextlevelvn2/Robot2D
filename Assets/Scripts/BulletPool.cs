using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public float timeDestroy = 1f;
    private void OnEnable()
    {
        transform.GetComponent<Rigidbody2D>().WakeUp();
        Invoke("hideBullet", timeDestroy);
    }
    void hideBullet()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        transform.GetComponent<Rigidbody2D>().Sleep();
        CancelInvoke();
    }
}
