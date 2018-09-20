using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class FireWeapon : MonoBehaviour {

    public LaserShot laserShotPrefab;
    public Transform firePoint;

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            Instantiate(laserShotPrefab, firePoint);
        }
    }
}
