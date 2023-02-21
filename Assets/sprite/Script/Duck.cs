using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Duck : MonoBehaviour
{
    bool finish = false;
    private Vector3 m_Velocity = Vector3.zero;
    public float speed = 6f;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    Rigidbody2D player;
    float horizontalMove = 0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
            finish = true;
    }
    // Update is called once per frame
    void Update()
    {
        //horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 targetVelocity = new Vector2(4f, player.velocity.y);
            player.velocity = Vector3.SmoothDamp(player.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 targetVelocity = new Vector2(-4f, player.velocity.y);
            player.velocity = Vector3.SmoothDamp(player.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
            //player.AddForce(new Vector2(-speed, 0));
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (finish == true) SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex +1);
    }
}