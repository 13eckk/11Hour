using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsanityCore : MonoBehaviour
{

    [SerializeField, Range(0, 3)] int sanityLevel;
    [SerializeField, Range(0, 100)] float sanityPercent;
    [SerializeField] bool canSpawnEntity;
    [SerializeField] GameObject entity;
    [SerializeField] int entityNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sanityPercent -= Time.deltaTime;
        //CORE Sanity Effect and Detail
        switch (sanityPercent)
        {

            case < 30:
                sanityLevel = 3;
                SpawnEntity(true);
                break;
            case < 50:
                sanityLevel = 2;
                SpawnEntity(false);
                break;
            case < 70:
                sanityLevel = 1;
                SpawnEntity(false);
                break;
            case > 70:
                sanityLevel = 0;
                SpawnEntity(false);
                break;
        }
    }
    void SpawnEntity(bool canspawn)
    {
        //if (canspawn&&canSpawnEntity&& entityNumber < 6)
        //{

        //        int x = Random.Range(-5, 5);
        //        int z = Random.Range(-5, 5);
        //        GameObject E = Instantiate(entity, new Vector3(x, 1, z), Quaternion.identity);
        //        entityNumber += 1;        
        //}
    }
    void SanityMainEffect()
    {


    }
    void SanitySideEffect()
    {


    }
}
