using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientBehaviour : MonoBehaviour
{
    public float moveSpeed = 1f;

    private GameObject[] tables;
    private Vector2 target;

    private TableBehaviour targetedTable;

    // Start is called before the first frame update
    void Start()
    {
        tables = GameObject.FindGameObjectsWithTag("Table");
        DefineTargetTable();
    }

    // Update is called once per frame
    void Update()
    {
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
        foreach (GameObject table in tables)
        {
            TableBehaviour tableScript = table.GetComponent<TableBehaviour>();
            if (tableScript.hasClient == false)
            {
                targetedTable = table.GetComponent<TableBehaviour>();
                target = new Vector2(table.transform.position.x - 1, table.transform.position.y);
            }
        }
    }
}