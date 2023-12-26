using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrack : MonoBehaviour
{
    AudioSource AS1;
    AudioSource AS2;

    public AudioClip Clip1;
    public AudioClip Clip2;

    private void Awake()
    {
        AS1 = gameObject.AddComponent<AudioSource>();
        AS1.clip = Clip1;
        //AS1.volume = 1;
        //AS1.maxDistance = 7500;
        //AS1.Play();
        AS1.loop = true;
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
