using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0.5f;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckOutOfBounds();
    }

    public void Move()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);    
    }

    private void CheckOutOfBounds()
    {
        if (Mathf.Abs(transform.position.y - 6f) < 0.1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("bULLET");
            Destroy(gameObject);
            gameManager.Score();
        }
        if(collision.gameObject.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}
