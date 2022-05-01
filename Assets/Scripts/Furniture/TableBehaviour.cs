using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TableBehaviour : MonoBehaviour
{
    public Boolean hasClient { get; private set; } = false;

    public GameObject client { get; private set; } = null;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckForClient();
    }


    private void CheckForClient()
    {
        //Draw a Raycast from the table position to the left of it.
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + 1, transform.position.y), Vector2.left,
            distance: 2);
        //If the raycast touch a GameObject with the Tag "Client", then =>
        if (hit.collider != null && hit.collider.tag.Equals("Client"))
        {
            //The table has a client
            hasClient = true;
            //The client is define by the object that has been touched by the raycast
            client = hit.collider.gameObject;
        }
        else
        {
            hasClient = false;
            client = null;
        }

        //Show the Raycast on play mode
        Debug.DrawRay(transform.position, Vector2.left * 5, Color.red);
    }
}