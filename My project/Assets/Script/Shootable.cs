using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] // enforces dependency

public class Shootable : MonoBehaviour
{
    [SerializeField] int startingHealth = 10;
    
    public void TakeDamage(int damage)
    {
        startingHealth -= damage;

        if(startingHealth < 0)
        {
            Destroy(gameObject);
        }
    }
    public void SetRandomColour()
    {
        // create a new random colour
        Color random = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        // set material to the random colour
        GetComponent<Renderer>().material.color = random;
    }

}


