using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientBehaviour : MonoBehaviour
{
    public float moveSpeed = 1f;

    private GameObject table;

    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        table = GameObject.Find("Table");
        target = new Vector2(table.transform.position.x, table.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }
}