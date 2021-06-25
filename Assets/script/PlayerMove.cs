using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

    [SerializeField]
    float speed = 15f;
    [SerializeField]
    private float fireRate = 2.5f;
    [SerializeField]
    int hp = 3;
    [SerializeField]
    private GameObject bulletPrefab = null;
    [SerializeField]
    private Transform bulletPosition = null;

    private StopWatch stopwatch;
    private Collider2D col = null;

    private Vector2 targetPosition = Vector2.zero;
    private SpriteRenderer spriteRenderer = null;

    private GameManager gameManager = null;
    void Start()
    {
        stopwatch = FindObjectOfType<StopWatch>();
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        StartCoroutine(Fire());
    }

    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.x = Mathf.Clamp(targetPosition.x, gameManager.MinPosition.x,
                gameManager.MaxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, gameManager.MinPosition.y,
                gameManager.MaxPosition.y);
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, targetPosition, speed * Time.deltaTime);
        }

   

    }

     private IEnumerator Fire()
    {
        GameObject bullet;

            while (true)
            {
                bullet = Instantiate(bulletPrefab, bulletPosition);
                bullet.transform.SetParent(null);
                yield return new WaitForSeconds(fireRate);
            }
    }

    bool isDead = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;
        if (collision.CompareTag("enemy"))
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
    private IEnumerator Dead()
    {
        col.enabled = false;

        yield return new WaitForSeconds(0.5f);
        PlayerPrefs.SetFloat("HIGHSCORE", stopwatch.startTime);
        SceneManager.LoadScene("GameOverScene");
        Destroy(gameObject);
    }
}
