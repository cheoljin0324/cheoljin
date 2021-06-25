using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class enemy : MonoBehaviour
{

    [SerializeField]
    private int score = 10;
    [SerializeField]
    private int hp = 1;
    [SerializeField]
    protected float speed = 10f;
    [SerializeField]
    private Animator animation = null;

    protected GameManager gameManager = null;
    private Collider2D col = null;
    private SpriteRenderer spriteRenderer = null;

    private bool isDamaged = false;
    private bool isDead = false;

    // Start is called before the first
    void Start()
    {

        gameManager = FindObjectOfType<GameManager>();
        speed = gameManager.Getspeed();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;
        Move();
    
        CheckLimit();
    }

    protected virtual void Move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        
    }

    private void CheckLimit()
    {
        if (transform.position.y < gameManager.MinPosition.y)
        {
            Destroy(gameObject);
            
        }
        if (transform.position.x < gameManager.MinPosition.x - 2f)
        {
            Destroy(gameObject);
            gameManager.Addspeed();
        }
        if (transform.position.x > gameManager.MaxPosition.x + 2f)
        {
            Destroy(gameObject);
            gameManager.Addspeed();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            //if (hp > 1)
            //{
            //    if (isDamaged) return;
            //    isDamaged = true;
            //    StartCoroutine(Damaged());
            //    return;
            //}
            isDead = true;
            //hp--;
            //Destroy(gameObject);
            StartCoroutine(Dead());
        }
    }
    private IEnumerator Damaged()
    {
        hp--;
        isDamaged = false;
        yield return new WaitForSeconds(0.2f);
    }
    private IEnumerator Dead()
    {

        animation.Play("Brick");
        col.enabled = false;
    
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
