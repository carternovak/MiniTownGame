using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunThrow : MonoBehaviour
{
    // Reference for throwing mechanic: https://www.youtube.com/watch?v=SQUzC5x3fN0
    public GameObject gun;
    public Transform spawnPoint;
    public float speed = 10f;
    bool launched;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
            launched = true;

        if (launched) 
        {
            ThrowGun();
            Destroy(gun);
        }
    }

    void ThrowGun()
    {
        GameObject gunInstance = Instantiate(gun, spawnPoint.position, gun.transform.rotation);
        gunInstance.transform.rotation = Quaternion.LookRotation(-spawnPoint.forward);
        Rigidbody gunRig = gunInstance.GetComponent<Rigidbody>();

        gunRig.AddForce(spawnPoint.forward * speed, ForceMode.Impulse);
        launched = false;
    }
}
