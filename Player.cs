using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    private void Start()
    {
        boxCollider = Getcomponent<BoxCollider2D>();
    }

//Update method
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        //Reset move Delta
        moveDelta = new Vector3(x,y,0);

        //Swap Sprite direction, wether you're going right or left
        if(moveDelta.x>0)
        {
             transform.localScale = Vector3.one
        }
        else if(moveDelta.x<0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }

        //make sure we can move in this direction, by casting a box there, if the box returns null, we're free to move
        hit = Physics2D.BoxCast(transform.position,boxCollider.size, 0,new Vector2(0,moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor","Blocking"));
        if(hit.collider == null)
        {
            //make this thing move
            transform.Traslate(0,moveDelta.y  * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position,boxCollider.size, 0,new Vector2(moveDelta.x,0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor","Blocking"));
        if(hit.collider == null)
        {
            //make this thing move
            transform.Traslate(moveDelta.x  * Time.deltaTime,0 , 0);
        }

    }

}
