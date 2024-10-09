using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemy : MonoBehaviour
{

    Rigidbody2D rb;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = -3;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(1*speed,rb.velocity.y);
    }
}
