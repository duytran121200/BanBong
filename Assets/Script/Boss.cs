using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 0.1f;
    private GameManager gameManager;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        damage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.score == 10)
        {
            Move();
        }
    }

    private void Move()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet" && damage == 10)
        {
            Destroy(gameObject);
            damage = 0;
        }else if (collision.gameObject.tag == "Bullet" && damage < 10)
        {
           damage++;
        }
    }
}
