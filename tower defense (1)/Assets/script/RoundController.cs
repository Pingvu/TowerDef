using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{    //Creating variables
    public GameObject basicEnemy;
    public float timeBetweenWaves;
    public float timeBeforeRoundStart;
    public float timeVariable;
    public bool isRoundGoing;
    public bool isIntermission;
    public bool isStartOfRound;
    public int round;
    private void Start() //setting variables value
    {
        isRoundGoing =false;
        isIntermission = false;
        isStartOfRound= true;
        timeVariable= Time.time + timeBeforeRoundStart;
        round = 1;
    }
    private void spawnEnemies() //Run the Coroutine ISpawnEnemies
    {
     StartCoroutine("ISpawnEnemies");
    }
    IEnumerator ISpawnEnemies() //Spawn enemies at the startTile
    {
      for (int i = 0; i< round; i++)
      {
          GameObject newEnemy = Instantiate(basicEnemy, MapGenerator.startTile.transform.position,Quaternion.identity);
          yield return new WaitForSeconds(1f);
      }
    }
    private void Update()
    {
        if(isStartOfRound)//at the start of the round, do the method spawnEnemies
        {
             if (Time.time >= timeVariable)
             {
                 isStartOfRound = false;
                 isRoundGoing = true;
                 spawnEnemies();
                 return;
             }
        }
        else if (isIntermission)
        {
           if (Time.time >= timeVariable){
               isIntermission = false;
               isRoundGoing = true;
               spawnEnemies();
           }
        }
        else if (isRoundGoing){ //check the enemies remaining,if there are still some enemies, do nothing,if the enemies is all dead, go to the next round
             if(Enemies.enemies.Count >0){


             }
             else {
                 isIntermission = true;
                 isRoundGoing = false;
                  timeVariable= Time.time + timeBetweenWaves;
                  round ++;
             }
        }
    }
}
