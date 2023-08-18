using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private Camera cam;     // stores camera component
    public GameObject grenadePrefab;
    public float grenadeImpulse = 5.0f;
    private float holdDownStartTime;
    private const float MAX_FORCE = 200f;

    // Start is called before the first frame update
    void Start()
    {
        // gets the GameObject's camera component
        cam = GetComponent<Camera>();

        // hide the mouse cursor at the centre of screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnGUI()
    {
        int size = 12;

        // centre of screen and caters for font size
        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 2;

        // displays "*" on screen
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            holdDownStartTime = Time.time;
        }

        // on left mouse button release
        if (Input.GetMouseButtonUp(0))
        {
            float holdDownTime = Time.time - holdDownStartTime;
            grenadeImpulse += holdDownForce(holdDownTime);

            // instantiate grenade object prefab
            GameObject grenade = Instantiate(grenadePrefab, transform);
            grenade.transform.position = cam.transform.position + cam.transform.forward * 2;
            // get the object's rigidbody component
            Rigidbody target = grenade.GetComponent<Rigidbody>();
            // calculate impulse strength
            Vector3 impulse = cam.transform.forward * grenadeImpulse;
            // apply impulse
            target.AddForceAtPosition(impulse, cam.transform.position, ForceMode.Impulse);

            grenadeImpulse -= holdDownForce(holdDownTime);

        }


    }

    private float holdDownForce(float holdTime)
    {
        float maxForceHoldDownTime = 3.0f;
        float holdTimeNormalized = Mathf.Clamp01(holdTime / maxForceHoldDownTime);
        float force = holdTimeNormalized * MAX_FORCE;
        return force;

    }
}

