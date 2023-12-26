using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    AudioSource AS1;
    AudioSource AS2;

    public AudioClip Clip1;
    public AudioClip Clip2;

    private void Awake()
    {
        //AS1 = gameObject.AddComponent<AudioSource>();
        //AS1.volume = 0;
        //AS1.maxDistance = 0;
        ////AS1.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
