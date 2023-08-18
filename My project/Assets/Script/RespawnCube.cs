using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCube : MonoBehaviour
{
    public GameObject toRespawn;
    GameObject cubeInstance;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cubeInstance == null) 
        { 
            cubeInstance = Instantiate(toRespawn, gameObject.transform.position, Quaternion.identity);
        }
    }
}
