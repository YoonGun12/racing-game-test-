using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int gasScore;

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
