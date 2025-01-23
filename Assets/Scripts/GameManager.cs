using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int gasScore;
    [SerializeField]private Text gasScoreText;
    [SerializeField]private GameObject startUI;
    [SerializeField]private GameObject retryUI;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        startUI.SetActive(true);
        retryUI.SetActive(false);
        gasScoreText.gameObject.SetActive(false);
    }

    private void Start()
    {
        Time.timeScale = 0;
        gasScore = 100;
        StartCoroutine(GasDecrease());
    }

    private void Update()
    {
        if (gasScore <= 0)
            GameLose();
        gasScoreText.text = "Gas : " + gasScore;
    }

    public void GameLose()
    {
        Time.timeScale = 0;
        retryUI.SetActive(true);
    }

    IEnumerator GasDecrease()
    {
        while (gasScore > 0)
        {
            yield return new WaitForSeconds(1f);
            gasScore -= 10;
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        startUI.SetActive(false);
        gasScoreText.gameObject.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
}
