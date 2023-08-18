using UnityEngine;

public class Machine_WeaponPickup : MonoBehaviour
{
    public GameObject M1911; // Drag the 'Pistol' that is a child of the player's weaponAttachPoint here and is initially set as inactive
    public GameObject M249; // Drag the 'MachineGun' that is a child of the player's weaponAttachPoint here
    public GameObject M4;
    public GameObject RPG7;
    public GameObject RGD7;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered trigger with: " + other.gameObject.name);

        // Check if the player collided with the 'Pistol' on the ground.
        if (other.CompareTag("Player"))
        {
            // Activate the 'Pistol' in the player's hand/container
            M1911.SetActive(false);
            M249.SetActive(true);
            M4.SetActive(false);
            RPG7.SetActive(false);
            RGD7.SetActive(false);



        }
    }
}
