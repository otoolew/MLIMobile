using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class TankShootMobile : MonoBehaviour {

    public TankBullet bulletPrefab;
    public Transform firePoint;

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, firePoint);
        }
    }
}
