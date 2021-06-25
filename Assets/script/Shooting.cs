using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private float speed = 20f;

    private GameManager gameManager = null;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            CheckLimit();
        }

    private void CheckLimit()
    {
        if (transform.position.x < gameManager.MinPosition.x - 2f)
        {
            Debug.Log("destroy");
            Destroy(gameObject);
        }
        if (transform.position.x > gameManager.MaxPosition.x + 2f)
        {
            Debug.Log("destroy");
            Destroy(gameObject);
        }
        if (transform.position.y < gameManager.MinPosition.y - 5f)
        {
            Debug.Log("destroy");
            Destroy(gameObject);
        }
        if (transform.position.y > gameManager.MaxPosition.y + 5f)
        {
            Debug.Log("destroy");
            Destroy(gameObject);
        }
    }
}

