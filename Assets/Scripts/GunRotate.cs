using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    public float RotationSpeed = 300f;
    private float RotationTime = 1f;
    public GameObject Gun;
    public GameObject Bullet;
    IEnumerator SpawnBullet;
    private int bulletCount;
    private PoolManager poolManager;
    // Start is called before the first frame update
    void Start()
    {
        poolManager = PoolManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        RotateGun();
    }
    void RotateGun()
    {
        if (Time.time > RotationTime)
        {
            Gun.transform.Rotate(Vector3.forward*RotationSpeed);
            RotationTime = Time.time + 2f;
            //StopCoroutine(SpawnBullet);
            bulletCount = 0;
            StartCoroutine(SpawnBulletMethod());
            //SpawnBulletMethod();
        }
    }
    //void SpawnBulletMethod()
    //{
    //    float spawnBulletTime = 0.8f;
    //    while(bulletCount<3 && (spawnBulletTime>(RotationTime - Time.time)))
    //    {
    //        GameObject bl = Instantiate(Bullet, Gun.transform.position, Gun.transform.rotation);
    //        bl.SetActive(true);
    //        bl.GetComponent<Rigidbody2D>().AddForce(-Gun.transform.up * 400);
    //        Destroy(bl, 2f);
    //        bulletCount++;
    //        spawnBulletTime -= 0.3f;
    //    }
    //}
    IEnumerator SpawnBulletMethod()
    {
        while ((Time.time < RotationTime) && bulletCount < 3)
        {
            //GameObject bl = Instantiate(Bullet, Gun.transform.position, Gun.transform.rotation);
            //bl.SetActive(true);
            //bl.GetComponent<Rigidbody2D>().AddForce(-Gun.transform.up * 400);
            //Destroy(bl, 2f);
            if(bulletCount == 0)
            {
                GameObject bl = poolManager.SpawnPool("Bullet0", Gun.transform.position, Gun.transform.rotation);
                bl.GetComponent<Rigidbody2D>().AddForce(-Gun.transform.up * 400);
                bl.transform.parent = transform;
                yield return new WaitForSeconds(0.3f);
                bulletCount++;
            }
            if (bulletCount == 1)
            {
                GameObject bl = poolManager.SpawnPool("Bullet1", Gun.transform.position, Gun.transform.rotation);
                bl.transform.parent = transform;
                bl.GetComponent<Rigidbody2D>().AddForce(-Gun.transform.up * 400);
                yield return new WaitForSeconds(0.3f);
                bulletCount++;
            }
            if (bulletCount == 2)
            {
                GameObject bl2 = poolManager.SpawnPool("Bullet2", Gun.transform.position, Gun.transform.rotation);
                bl2.GetComponent<Rigidbody2D>().AddForce(-Gun.transform.up * 400);
                bl2.transform.parent = transform;
                yield return new WaitForSeconds(0.3f);
                bulletCount++;
                StopCoroutine(SpawnBulletMethod());
            }
        }
    }

}
