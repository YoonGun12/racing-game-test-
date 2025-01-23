using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_CarController : MonoBehaviour
{
    [SerializeField] private int gas = 100;
    [SerializeField] private float moveSpeed = 1f;
    
    //Gas 정보
    public int Gas { get => gas;}

    private void Start()
    {
        StartCoroutine(GasCoroutine());
    }

    private IEnumerator GasCoroutine()
    {
        while (true)
        {
            gas -= 10;
            if (gas <= 0) break;
            yield return new WaitForSeconds(1f);
        }
        //게임 종료
    }

    //자동차 이동 메서드
    public void Move(float direction)
    {
        transform.Translate(Vector3.right * (direction * moveSpeed * Time.deltaTime));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2f, 2f), 0, transform.position.z);
    }

    //가스 아이템 획득시 호출되는 메서드
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gas"))
        {
            gas += 30;
            
            //가스 아이템 제거
        }
    }
}
