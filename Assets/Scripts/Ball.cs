using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    public float speed = 100f;
    public TextMeshProUGUI scoreTextPlayer;
    public TextMeshProUGUI scoreTextAI;
    void Start()
    {
        rb.AddForce(new Vector2(-speed, speed));
    }

    // Update is called once per frame
    void Update()
    {
        float maxSpeed = 20;
        GetComponent<Rigidbody2D>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody2D>().velocity, maxSpeed);

        //if (player.transform.position.y >= 3.68f) rb.AddForce(new Vector2(0,10));
        //if (player.transform.position.y <= -3.68f) rb.AddForce(new Vector2(0,-10));


        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(-speed,0));
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.AddForce(new Vector2(speed, 0));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("LeftWall"))
        {
            wayBall(collision, 1);

        }
        if (collision.gameObject.CompareTag("RightWall"))
        {
            wayBall(collision, -1);

        }
        if (collision.gameObject.CompareTag("AiWin"))
        {
            scoreTextAI.text = (int.Parse(scoreTextAI.text) + 1).ToString();
            Debug.Log("Collided with the playerWin!");

            player.transform.position = new Vector3(0, 0, 0);
            rb.WakeUp(); // Optional: Wakes the Rigidbody2D up
            rb.AddForce(new Vector2(speed, speed));
            Debug.Log("Ai win");
        }
        if (collision.gameObject.CompareTag("PlayerWin"))
        {
            scoreTextPlayer.text = (int.Parse(scoreTextPlayer.text) + 1).ToString();
            // Additional logic for player collision
            Debug.Log("Collided with the playerWin!");
            rb.Sleep(); // Optional: Puts the Rigidbody2D to sleep

            player.transform.position = new Vector3(0, 0, 0);
            rb.WakeUp(); // Optional: Wakes the Rigidbody2D up

            rb.AddForce(new Vector2(-speed, -speed));
        }
    }
    private void wayBall(Collision2D collision, int x)
    {
        float a = transform.position.y - collision.gameObject.transform.position.y;
        float b = collision.collider.bounds.size.y;
        float y = a / b;
        rb.velocity = new Vector2(x, y) * speed;
    }
}
