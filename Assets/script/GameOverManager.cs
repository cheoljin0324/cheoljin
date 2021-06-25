using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{

    [SerializeField]
    private Text timeText = null;

    public float Starttime;
    // Start is called before the first frame update
    void Start()
    {
        timeText.text = string.Format("Á¡¼ö {0}", PlayerPrefs.GetFloat("HIGHSCORE", Starttime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
