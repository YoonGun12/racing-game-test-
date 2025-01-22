using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int gasScore;
    [SerializeField]private Text gasScoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }

    private void Start()
    {
        gasScore = 100;
        StartCoroutine(GasDecrease());
    }

    private void Update()
    {
        if (gasScore <= 0)
            GameLose();
        gasScoreText.text = "Gas : " + gasScore;
    }

    private void GameLose()
    {
        
    }

    IEnumerator GasDecrease()
    {
        while (gasScore > 0)
        {
            yield return new WaitForSeconds(1f);
            gasScore -= 10;
            Debug.Log(gasScore);
        }
    }
}
