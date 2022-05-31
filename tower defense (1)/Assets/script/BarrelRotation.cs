using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRotation : MonoBehaviour
{  //Creating varialbes
   public Transform pivot;
   public Transform barrel;
   public Tower tower;
   private void Update() //the barrel will rotate according to where the tower shooting at
   {
       if (tower != null)
       {
           if (tower.currentTarget != null)
           {
               Vector2 relative = tower.currentTarget.transform.position - pivot.position;
  
                 float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;
                 Vector3 newRotation = new Vector3 (0,0, angle);
                 pivot.localRotation = Quaternion.Euler(newRotation);
       }
   }
}
}
