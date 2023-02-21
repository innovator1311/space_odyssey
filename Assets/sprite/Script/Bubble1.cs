using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble1 : MonoBehaviour
{
    // Start is called before the first frame update
    bool explode = false;
    bool top = false;
    public float speed = 1;
    private float x;
    private float y;
    private Vector2 pos;
    public int maxSpeed;
    public int minSpeed;
    public float maxX;
    public float minX;
    void bubble()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        x = Random.Range(minX, maxX);
        y = -3;
        pos = new Vector2(x, y);
        transform.position = pos;
        explode = false;
        GetComponent<Animator>().SetBool("expl", false);
    }
    void Start()
    {
        bubble();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player"){
            explode = true;
            Score.scoreValue += 1;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.y > 3) top = true;
        if (top == false)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
        else
        {
            bubble();
            top = false;
        }
        if (explode == true)
        {
            GetComponent<Animator>().SetBool("expl", true);
            bubble();
            
        }
    }
}
