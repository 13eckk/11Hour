using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityObj : MonoBehaviour
{
    [SerializeField] Mesh normalMesh, sanityMesh;
    [SerializeField] MeshFilter _meshFilter;
    [SerializeField] InsanityCore _insanityCore;
    // Start is called before the first frame update
    void Start()
    {

        _meshFilter = GetComponent<MeshFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_insanityCore.sanityPercent > 10)
        {
            _meshFilter.mesh = normalMesh;
        }
        else 
        {
            _meshFilter.mesh = sanityMesh;
        }
    }
}
