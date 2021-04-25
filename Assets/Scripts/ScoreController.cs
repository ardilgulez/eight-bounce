using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private Text textElement;

    private void Awake()
    {
        textElement = GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        textElement.text = string.Format("{0:N1}", GameManager.instance.score);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isFinished)
            textElement.text = string.Format("{0:N1}", GameManager.instance.score);
    }
}
