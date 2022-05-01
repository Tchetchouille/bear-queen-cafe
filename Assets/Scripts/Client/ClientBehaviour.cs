using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientBehaviour : MonoBehaviour
{
    public float moveSpeed = 1f;

    //if there'is no available table, then the client will wait.
    private Boolean isWaitingForATable = false;

    //refers to all tables on the scene
    private GameObject[] tables;

    //Target is the Position that the client should go
    private Vector2 target;

    //This is the script of the table that the client will be next to
    private TableBehaviour targetedTable;

    //If there isn't any available table, then the position of the waitingZone will be used as a target.
    private GameObject waitingZone;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize all tables from the scene
        tables = GameObject.FindGameObjectsWithTag("Table");
        //Initialize the WaintingZone
        waitingZone = GameObject.FindGameObjectWithTag("WaitingZone");
        DefineTargetTable();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWaitingForATable)
        {
            DefineTargetTable();
        }

        //We're checking if the table doesn't have any other client while the client is moving toward it.
        IsTableStillFree();
        transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }

    private void IsTableStillFree()
    {
        //If the targetTable has client and it's not equals to himself then it should define a new table to target.
        if (targetedTable.hasClient)
        {
            GameObject clientToTable = targetedTable.client;
            if (clientToTable.name != this.name)
            {
                DefineTargetTable();
            }
        }
    }

    private void DefineTargetTable()
    {
        //For each table on the scene, we'll check if any of them are available, If it's not the case, then the client should wait.
        foreach (GameObject table in tables)
        {
            TableBehaviour tableScript = table.GetComponent<TableBehaviour>();
            if (tableScript.hasClient == false)
            {
                isWaitingForATable = false;
                targetedTable = table.GetComponent<TableBehaviour>();
                target = new Vector2(
                    transform.position.x > 0 ? table.transform.position.x + 1 : table.transform.position.x - 1,
                    table.transform.position.y);
                break;
            }
            else
            {
                target = waitingZone.transform.position;
                isWaitingForATable = true;
            }
        }
    }
}