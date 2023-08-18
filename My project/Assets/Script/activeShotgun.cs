using System.Collections;
using UnityEngine;

public class activateShotgun : MonoBehaviour
{
    public GameObject prefab, playerCam;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Equipped Shotgun");
            StartCoroutine(Respawn(prefab, 5.0f)); // wait 5 seconds to respawn sphere

            playerCam.GetComponent<Pistol>().enabled = false;
            playerCam.GetComponent<MachineGun>().enabled = false;
            playerCam.GetComponent<Grenade>().enabled = false;
            playerCam.GetComponent<BallLauncher>().enabled = false;
            playerCam.GetComponent<Shotgun>().enabled = true; // Added this line for the Shotgun script
        }
    }

    IEnumerator Respawn(GameObject go, float delay)
    {
        go.SetActive(false);
        yield return new WaitForSeconds(delay);
        go.SetActive(true);
    }
}
