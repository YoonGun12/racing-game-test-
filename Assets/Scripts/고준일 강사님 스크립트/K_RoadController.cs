using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_RoadController : MonoBehaviour
{
    //플레이어 차량이 도로에 진입하면 다음 도로를 생성
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //싱글톤 활용(이미 이 게임 내 있기 때문에 주석처리)
            //K_GameManager.Instance.SpawnRoad(transform.position + new Vector3(0, 0, 10));
        }   
    }

    //플레이어 차량이 도로를 벗어나면 도로를 제거
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //K_GameManager.Instance.DestroyRoad(gameObject);
        } 
    }
}
