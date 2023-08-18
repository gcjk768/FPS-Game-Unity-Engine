using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateMachineGun : MonoBehaviour
{
    public GameObject prefab, playerCam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Equipped Machine Gun");
            StartCoroutine(Respawn(prefab, 5.0f)); // wait 5 seconds to respawn sphere

            playerCam.GetComponent<Pistol>().enabled = false;
            playerCam.GetComponent<MachineGun>().enabled = true;
            playerCam.GetComponent<Grenade>().enabled = false;
            playerCam.GetComponent<BallLauncher>().enabled = false;
            playerCam.GetComponent<Shotgun>().enabled = false;

        }

    }

    IEnumerator Respawn(GameObject go, float delay)
    {
        go.SetActive(false);
        yield return new WaitForSeconds(delay);
        go.SetActive(true);
    }

}
