using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    public float speed = 3.0f;
    public float maxZ = 16.0f;
    public float minZ = -16.0f;

    private int direction = 1;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.Move();
        if (transform.position.z > maxZ || transform.position.z < minZ)
        {
            direction = -direction;
            this.Move();
        }
    }

    private void Move()
    {
        transform.Translate(0, 0, direction * speed * Time.deltaTime);
    }
}
