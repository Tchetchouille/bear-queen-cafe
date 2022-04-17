using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    //Creating the event that will detect if the player presses the "move right" key
    public delegate void RightDown();
    public static event RightDown OnRightDown;
    //Creating the event that will detect if the player releases the "move right" key
    public delegate void RightUp();
    public static event RightUp OnRightUp;
    //Repeat the process for the other directions
    public delegate void LeftDown();
    public static event LeftDown OnLeftDown;
    public delegate void LeftUp();
    public static event LeftUp OnLeftUp;
    public delegate void UpDown();
    public static event UpDown OnUpDown;
    public delegate void UpUp();
    public static event UpUp OnUpUp;
    public delegate void DownDown();
    public static event DownDown OnDownDown;
    public delegate void DownUp();
    public static event DownUp OnDownUp;

    //Same logic for the roll action key
    public delegate void DashDown();
    public static event DashDown OnDashDown;

    //This variable will allow to assign a key to the "move right" action
    public string rightKey;
    //Repeat the process for the other directions
    public string leftKey;
    public string upKey;
    public string downKey;
    //This variable will allow to assign a key to the "roll" action
    public string dashKey;

    // Update is called once per frame
    void OnGUI()
    {
 
        //Those "if" conditions detect wether the directioal keys are pressed and released.
        if (Input.GetKeyDown(rightKey))
        {
            OnRightDown();
        }
        else if (Input.GetKeyUp(rightKey))
        {
            OnRightUp();
        }
        if (Input.GetKeyDown(leftKey))
        {
            OnLeftDown();
        }
        else if (Input.GetKeyUp(leftKey))
        {
            OnLeftUp();
        }

        if (Input.GetKeyDown(upKey))
        {
            OnUpDown();
        }
        else if (Input.GetKeyUp(upKey))
        {
            OnUpUp();
        }
        if (Input.GetKeyDown(downKey))
        {
            OnDownDown();
        }
        else if (Input.GetKeyUp(downKey))
        {
            OnDownUp();
        }

        if (Input.GetKeyDown(dashKey)) 
        {
            OnDashDown();
        }


    }
}
