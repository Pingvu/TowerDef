using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTower : Tower
{   public GameObject bullet;
public Transform pivot;
public Transform barrel;
    protected override void shoot()
    {
        base.shoot();
        GameObject newbullet = Instantiate(bullet, barrel.position,pivot.rotation);
    
    }
}
