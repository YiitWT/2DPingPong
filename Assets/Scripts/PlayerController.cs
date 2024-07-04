using UnityEngine;
public class PlayerController : MonoBehaviour
{

    public GameObject player;
    [Range(0.05f, 0.5f)]
    public float speed = 0.05f;
    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.UpArrow))
        {
            if (gameObject.transform.position.y >= 3.68f) return;
            gameObject.transform.position += new Vector3(0, speed, 0);
        }
        if(Input.GetKey(KeyCode.DownArrow)) 
        {
            if (gameObject.transform.position.y <= -3.68f) return;
            gameObject.transform.position += new Vector3(0, -speed, 0);
        }
      
    }
}
