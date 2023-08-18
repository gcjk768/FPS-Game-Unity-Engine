using System.Collections;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    private Camera cam;
    public float impulseStrength = 5.0f;
    public GameObject particleSysPrefab;
    private float gunHeat; //to control fire rate

    public int pelletCount = 10;  // Number of pellets per shot
    public float spreadAngle = 25;  // Spread angle in degrees

    void Start()
    {
        cam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnGUI()
    {
        int size = 12;
        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    void Update()
    {
        if (gunHeat > 0)
        {
            gunHeat -= Time.deltaTime;
        }

        if (Input.GetButton("Fire1") && gunHeat <= 0)
        {
            gunHeat = 0.5f;  // Shotgun would typically have a longer delay between shots compared to a machine gun
            for (int i = 0; i < pelletCount; i++)
            {
                ShootPellet();
            }
        }
    }

    private void ShootPellet()
    {
        Vector3 shootDirection = cam.transform.forward;
        Vector2 randomCirclePoint = Random.insideUnitCircle * spreadAngle;
        shootDirection += new Vector3(randomCirclePoint.x, randomCirclePoint.y, 0);
        shootDirection.Normalize();

        Ray ray = new Ray(cam.transform.position, shootDirection);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            Shootable target = hitObject.GetComponent<Shootable>();

            if (target != null)
            {
                Vector3 impulse = Vector3.Normalize(hit.point - transform.position) * impulseStrength;
                hit.rigidbody.AddForceAtPosition(impulse, hit.point, ForceMode.Impulse);
                StartCoroutine(GeneratePS(hit));
                target.TakeDamage(1);  // Assuming each pellet causes 1 damage
            }
        }
    }

    private IEnumerator GeneratePS(RaycastHit hit)
    {
        GameObject ps = Instantiate(particleSysPrefab, hit.point, Quaternion.LookRotation(hit.normal));
        yield return new WaitForSeconds(1);
        Destroy(ps);
    }
}


