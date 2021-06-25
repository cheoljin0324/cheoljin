using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField]
    float speed = 10f;
    [SerializeField]
    private float fireRate = 0.2f;
    [SerializeField]
    private GameObject bulletPrefab = null;
    [SerializeField]
    private Transform bulletPosition = null;
 
    private Vector2 targetPosition = Vector2.zero;
    private SpriteRenderer spriteRenderer = null;

    private GameManager gameManager = null;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        if (bulletPrefab != null)
        {
            Debug.Log("b");
            while (true)
            {
                bullet = Instantiate(bulletPrefab, bulletPosition);
                bullet.transform.SetParent(null);
                yield return new WaitForSeconds(fireRate);
            }
        }

    }
}
