using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions : MonoBehaviour
{
    public string[] questions;
    public bool[] rightAnswers;
    public bool[] alreadyPicked;

    private void Start()
    {
        alreadyPicked = new bool[50];
        for (int i = 0; i < questions.Length; i++)
        {
            alreadyPicked[i] = false;
        }
    }

    public int getQuestion()
    {
        int randQuestion = Random.Range(0, questions.Length);
        while (alreadyPicked[randQuestion] != false)
        {
            randQuestion = Random.Range(0, questions.Length);
        }
        alreadyPicked[randQuestion] = true;
        return randQuestion;
    }
}
