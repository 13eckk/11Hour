using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;
public class InsanityCore : MonoBehaviour
{

    [SerializeField, Range(0, 3)] int sanityLevel;
    [SerializeField, Range(0, 20)] public float sanityPercent;
    [SerializeField] bool canSpawnEntity;
    [SerializeField] GameObject entity;
    [SerializeField] GameObject entityPrefab;
    [SerializeField] int entityNumber = 0;
    [SerializeField] Volume visionVolume;
    [SerializeField] VolumeProfile normal, sanity;
    [SerializeField] Slider insanityBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        insanityBar.value = sanityPercent;
        sanityPercent -= Time.deltaTime;
        
        //CORE Sanity Effect and Detail
        switch (sanityPercent)
        {

            case < 10:
                sanityLevel = 1;
                
                visionVolume.profile = sanity;
                break;
            case > 10:
                sanityLevel = 0;
                visionVolume.profile = normal;
                break;

        }
    }
    
    void SanityMainEffect()
    {
        

    }
    void SanitySideEffect()
    {


    }
}
