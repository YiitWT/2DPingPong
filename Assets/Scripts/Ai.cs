using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Ai : MonoBehaviour
{
    [Range(10, 50)]
    public float moveSpeed;
    [Range(1, 3)]
    public double hardness;


    public GameObject ball;
    void Update()
    {
        float distance = Mathf.Abs(ball.transform.position.y - transform.position.y);
        if (distance > hardness)
        {
            if (ball.transform.position.y > transform.position.y)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0.5f) * moveSpeed;
            }

            if (ball.transform.position.y < transform.position.y)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -0.5f) * moveSpeed;
            }
        }

    }

}