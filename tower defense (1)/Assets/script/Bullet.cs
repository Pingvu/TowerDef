using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  private void Start() //delete the bullet after 10s
  {
    Destroy(gameObject, 10f);
  }
  private void OnCollisionEnter2D(Collision2D collision){ // delete the bullet when it collide
    Destroy(gameObject);
  }
  private void Update ()
  {   
    
      transform.position += transform.right * 0.25f; // move the bullet forward
  }
}
