using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundmover : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.8f;
    //[SerializeField]
    //private GameManager gameManager = null;

    private Vector2 offset = Vector2.zero;
    private MeshRenderer meshRenderer = null;

    void Start()
    {
        //gameManager = FindObjectOfType<GameManager>();
        //speed = gameManager.Getspeed();
        meshRenderer = GetComponent<MeshRenderer>();
    }


    void Update()
    {
        offset.x += speed * Time.deltaTime;
        meshRenderer.material.SetTextureOffset("_MainTex", offset);
    }
}
