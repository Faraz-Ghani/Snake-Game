using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score_Controller : MonoBehaviour
{
    public Snake_Movement snake;
    public TMP_Text MyText;
    public int score;

    private void Start() {
     snake = GameObject.FindWithTag("Player").GetComponent<Snake_Movement>();
    }
    // Update is called once per frame
    void Update()
    {
        score=snake.score;
        MyText.text = "Score: " + score;    
    }
}
