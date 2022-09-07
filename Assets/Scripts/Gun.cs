using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{

    public Transform spawnPoint;
    public GameObject bulletPrefab;
    public float ShootForce;
    public float bulletDestroyDelay;
    public GameObject _tempBullet;
    
    public virtual void Shoot()
    {
        _tempBullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        _tempBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * ShootForce, ForceMode.Force);
        Destroy(_tempBullet, bulletDestroyDelay);
    }
}
