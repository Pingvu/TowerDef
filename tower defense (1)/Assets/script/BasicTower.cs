using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTower : Tower //inheritance, this script will now have everything in the Tower script
{   public GameObject bullet;
public Transform pivot;
public Transform barrel;
    protected override void shoot() //the tower will shoot a bullet
    {
        base.shoot();
        GameObject newbullet = Instantiate(bullet, barrel.position,pivot.rotation);
    
    }
}
