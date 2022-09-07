using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGun : Gun
{
    public override void Shoot()
    {
        base.Shoot();
        base._tempBullet.GetComponent<Rigidbody>().AddExplosionForce(2f, base.spawnPoint.position, 2f);
    }
}
