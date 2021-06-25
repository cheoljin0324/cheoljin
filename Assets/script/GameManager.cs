using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyPrefab = null;
    [SerializeField]
    private float speed = 10f;

    public PlayerMove player { get; private set;}
    public Vector2 MinPosition { get; private set; }
    public Vector2 MaxPosition { get; private set; }

    public PoolManager Pool { get; private set; }

    private int num;

    public void Addspeed()
    {
        speed += 0.5f;
        Getspeed();
    }
    public float Getspeed()
    {
        return speed;
    }

    void Start()
    {
        player = FindObjectOfType<PlayerMove>();
        Pool = FindObjectOfType<PoolManager>();
        MinPosition = new Vector2(-15f, -7f);
        MaxPosition = new Vector2(15f, 7f);
        StartCoroutine(Spawnenemy());
    }

    private IEnumerator Spawnenemy()
    {
        float delay = 0f;


        while (true)
        {
            delay = Random.Range(1f, 2f);
            num = Random.Range(0, 5);

            if (num == 0)
            {
                Instantiate(enemyPrefab, new Vector2(15f, 3.6f), Quaternion.identity);
                Instantiate(enemyPrefab, new Vector2(15f, 0f), Quaternion.identity);
                Instantiate(enemyPrefab, new Vector2(15f, -3.9f), Quaternion.identity);
            }
             
            if(num == 1)
            {
                Instantiate(enemyPrefab, new Vector2(15f, 0f), Quaternion.identity);
                Instantiate(enemyPrefab, new Vector2(15f, -3.9f), Quaternion.identity);
            }

            if (num == 2)
            {
                Instantiate(enemyPrefab, new Vector2(15f, -3.9f), Quaternion.identity);
                Instantiate(enemyPrefab, new Vector2(15f, 3.6f), Quaternion.identity);
            }
            if (num == 3)
            {
                Instantiate(enemyPrefab, new Vector2(15f, 3.6f), Quaternion.identity);
            }
            if(num == 4)
            {
                Instantiate(enemyPrefab, new Vector2(15f, 0f), Quaternion.identity);
            }
            if (num == 5)
            {
                Instantiate(enemyPrefab, new Vector2(15f, -3.9f), Quaternion.identity);
            }
           
            yield return new WaitForSeconds(delay);

        }
    }
}