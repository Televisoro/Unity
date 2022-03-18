using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(BoxCollider2D))]
public class CameraMotor : MonoBehaviour
{
   public Transform lookAt;
   public float boundX = 0.15f;
   public float boundY = 0.05f;

    private void LateUpdate()
    {
        Vector3 delta = new Vector3.zero;


        // This is to check if we're inside the bounds on the X axis
        float deltaX = lookAt.position.x - trasform.position.x;
        if(deltaX > boundX || deltaX < -boundX)
        {
            if(trasform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        
        // This is to check if we're inside the bounds on the Y axis
        float deltaY = lookAt.position.x - trasform.position.x;
        if(deltaY > boundY || deltaY < -boundY)
        {
            if(trasform.position.y < lookAt.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        trasform.position += new vector3(delta.x, delta.y, 0);
    } 
}
