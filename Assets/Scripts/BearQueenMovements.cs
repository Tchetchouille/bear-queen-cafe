using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearQueenMovements : MonoBehaviour
{
    //Allows to access the moveSpeed from the Editor.
    public float moveSpeed;

    //Will hold the character Rigidbody2D
    private Rigidbody2D bearRigidbody;

    //Will be used to check wether or not the right key is pressed.
    bool rightDown;
    //Repeat the same logic for the other directions
    bool leftDown;
    bool upDown;
    bool downDown;



    // OnEnable is called whenever the object this script is attached to is created or enabled in a scene.
    void OnEnable()
    {


        //Adding the methods that will allow movement to the EventManager script
        EventManager.OnRightDown += StartMovingRight;
        EventManager.OnRightUp += StopMovingRight;
        //Repeat for the other directions
        EventManager.OnLeftDown += StartMovingLeft;
        EventManager.OnLeftUp += StopMovingLeft;
        EventManager.OnUpDown += StartMovingUp;
        EventManager.OnUpUp += StopMovingUp;
        EventManager.OnDownDown += StartMovingDown;
        EventManager.OnDownUp += StopMovingDown;

    }



    void Start()
    {
        //Assign the Rigidbody2D as the variable's value
        bearRigidbody = GetComponent<Rigidbody2D>();
    }



    //This method is called through the EventManager and will make the character move right whenever the right key is pressed.
    void StartMovingRight()
    {
        //For some unknown reason, the method can sometimes be triggered several times in on key press.
        //This if condition will make sure the speed is only changed once.
        if (rightDown == false) 
        {
            bearRigidbody.velocity += new Vector2(moveSpeed, 0);
        }
        
        //We then change the value of the rightDown variable to show it is held down.
        rightDown = true;
    }

    //This method is called through the EventManager and will make the character stop moving right whenever the right key is released.
    void StopMovingRight()
    {
        //For some unknown reason, the method can sometimes be triggered several times in on key release.
        //This if condition will make sure the speed is only changed once.
        if (rightDown == true)
        {
            bearRigidbody.velocity += new Vector2(-moveSpeed, 0);
        }

        rightDown = false;
    }

    //Repeat the same logic as above for the other directions.
    void StartMovingLeft()
    {
        //For some unknown reason, the method can sometimes be triggered several times in on key press.
        //This if condition will make sure the speed is only changed once.
        if (leftDown == false)
        {
            bearRigidbody.velocity += new Vector2(-moveSpeed, 0);
        }
        leftDown = true;
    }

    void StopMovingLeft()
    {
        //For some unknown reason, the method can sometimes be triggered several times in on key release.
        //This if condition will make sure the speed is only changed once.
        if (leftDown == true)
        {
            bearRigidbody.velocity += new Vector2(moveSpeed, 0);
        }
        leftDown = false;
    }

    void StartMovingUp()
    {
        //For some unknown reason, the method can sometimes be triggered several times in on key press.
        //This if condition will make sure the speed is only changed once.
        if (upDown == false)
        {
            bearRigidbody.velocity += new Vector2(0, moveSpeed);
        }
        upDown = true;
    }

    void StopMovingUp()
    {
        //For some unknown reason, the method can sometimes be triggered several times in on key release.
        //This if condition will make sure the speed is only changed once.
        if (upDown == true)
        {
            bearRigidbody.velocity += new Vector2(0, -moveSpeed);
        }
        upDown = false;
    }
    void StartMovingDown()
    {
        //For some unknown reason, the method can sometimes be triggered several times in on key press.
        //This if condition will make sure the speed is only changed once.
        if (downDown == false)
        {
            bearRigidbody.velocity += new Vector2(0, -moveSpeed);
        }
        downDown = true;
    }
    void StopMovingDown()
    {
        //For some unknown reason, the method can sometimes be triggered several times in on key release.
        //This if condition will make sure the speed is only changed once.
        if (downDown == true)
        {
            bearRigidbody.velocity += new Vector2(0, moveSpeed);
        }
        downDown = false;
    }

}
