using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{ //creating variables
  [SerializeField] private float enemyHealth;
   [SerializeField]private float movementSpeed;
   

   private GameObject targetTile;
   private void Awake() //setting up the list Enemies
   {
      Enemies.enemies.Add(gameObject);
   }
   private void Start() //spawn the enemy
   {
       initializeEnemy();
   }
   private void initializeEnemy() //Enemy will spawn in the startTile
   {
     targetTile = MapGenerator.startTile;
   }
   public void takeDamage (float amount) //if the enemy health reached 0, do the method die
   {
      enemyHealth -= amount;
      if (enemyHealth <= 0)
      {
        die();
      }

   }
   private void die () { //kill the enemy
      Enemies.enemies.Remove(gameObject);
      Destroy(transform.gameObject);
   }
   

   private void moveEnemy() //enemy will move according to the variable movementSpeed
   {
     transform.position = Vector3.MoveTowards(transform.position, targetTile.transform.position, movementSpeed * Time.deltaTime);
   }
   private void checkPosition()
   { //check the enemy position and ensure it will move along the path
   if (targetTile != null && targetTile != MapGenerator.endTile)
      {
         float distance = (transform.position - targetTile.transform.position).magnitude;
         if (distance<0.001f)
         {
            int CurrentIndex= MapGenerator.PathTiles.IndexOf(targetTile);
            targetTile = MapGenerator.PathTiles[CurrentIndex +1];
         }
      }
   }
   private void Update () //Check enemy position and then move it along the path
   {
   checkPosition();
   moveEnemy();
   }
}
