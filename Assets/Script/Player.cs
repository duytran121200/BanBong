using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int move;
    public float speed = 0.3f;
    public GameObject bulletPrefab;
    public GameObject gun1;
    public float timeDelay;
    float sum;
    public bool check;
    // Start is called before the first frame update
    void Start()
    {
        timeDelay = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(timeDelay>=0.5f)
        {           
            check = true;
            CreateBullet();
        }
        else
        {
            timeDelay += Time.deltaTime;
            check = false;
        }
    }

    private void Move()
    {
        if(Input.GetKey(KeyCode.RightArrow) && transform.position.x < 8)
        {
            move = 1;
        }
        else if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -8)
        {
            move = -1;
        }
        else
        {
            move = 0;
        }

        transform.Translate(Vector3.right * move * speed); 
    }

    private void CreateBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space) && check == true)
        {
            GameObject bullets = Instantiate(bulletPrefab, gun1.transform.position, Quaternion.identity);
            timeDelay = 0;
        }
    }
}
