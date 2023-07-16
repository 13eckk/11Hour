using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanitySound : MonoBehaviour
{
    [SerializeField] InsanityCore _insanityCore;
    [SerializeField] AudioClip audioClip;
    AudioSource _AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_insanityCore.sanityPercent <= 10)
        {

            _AudioSource.clip = audioClip;
            _AudioSource.Play();
        }
       
            
       
    }
}
