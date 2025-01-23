using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어는 게임 시작 후 Start에서 Init되기 때문에 ButtonUI를 사용할 수 없어, 버튼 컴포넌트를 제거하고
//별도의 클래스를 만들고 evenet Trigger를 사용
public class K_MoveButton : MonoBehaviour
{
    public delegate void MoveButtonDelegate();
    public event MoveButtonDelegate OnMoveButtonDown;
    
    private bool isDown;

    private void Update()
    {
        if (isDown)
        {
            OnMoveButtonDown?.Invoke();
        }
    }

    public void ButtonDown()
    {
        isDown = true;
    }

    public void ButtonUp()
    {
        isDown = false;
    }
}
