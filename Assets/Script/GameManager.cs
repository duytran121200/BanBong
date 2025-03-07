using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bossPrefab;
    public float timeDelay;
    public int score;
    public Text textScore;
    // Start is called before the first frame update
    void Start()
    {
        timeDelay = 2;
        score = 0;
        textScore.text = "Diem: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeDelay >=2 && score <10)
        {
            CreateEnemy();           
        }
        else
        {
            timeDelay += Time.deltaTime;
        }
    }

    private void CreateEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-7.9f, 7.9f), 6, 0), Quaternion.identity);
        timeDelay = 0;     
    }

    private void CreateBoss()
    {
        GameObject boss = Instantiate(bossPrefab, new Vector3(0, 6, 0), Quaternion.identity);
    }

    public void Score()
    {
        score++;
        textScore.text = "Diem: " + score.ToString();
    }
}
