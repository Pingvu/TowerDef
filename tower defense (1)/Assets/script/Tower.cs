using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{ //Creating variables
  [SerializeField] private float range;
   [SerializeField]private float damage;
   [SerializeField] private float timeBetweenShots;
   private float nextTimeToShoot;
   public GameObject currentTarget;
   private void Start()
   {
nextTimeToShoot = Time.time;
   }
   private void updateNearestEnemy () //Detect the nearest enemy
   {
       GameObject currentNearestEnemy = null;
       float distance = Mathf.Infinity;
       foreach(GameObject enemy in Enemies.enemies)
       {  if (enemy!=null){
 float _distance = (transform.position - enemy.transform.position).magnitude;
           if (_distance< distance)
           {
               distance = _distance;
               currentNearestEnemy = enemy;
           }
       }
          
       }
       if (distance <= range)
       {
           currentTarget = currentNearestEnemy;
       }
       else {
           currentTarget = null;
       }
   }
   protected virtual void shoot () //the tower will shoot at the enemy, making it take dmg
   {
 
     Enemy enemyScript = currentTarget.GetComponent<Enemy>();
     enemyScript.takeDamage(damage);
 
   }
   private void Update()// Run methods, making the tower shoot at the nearest enemy
   {
     updateNearestEnemy();
     if(Time.time >= nextTimeToShoot)
     {
         if(currentTarget != null)
         {
             shoot();
             nextTimeToShoot = Time.time  + timeBetweenShots;
         }
     }
   }
}
