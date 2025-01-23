using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class K_GameManager : MonoBehaviour
{
   //프리팹
   [SerializeField] private GameObject carPrefab;
   [SerializeField] private GameObject roadPrefab;
   
   //UI관련 코드
   [SerializeField] private K_MoveButton leftMoveButton;
   [SerializeField] private K_MoveButton rightMoveButton;
   [SerializeField] private TMP_Text gasText;
   
   //자동차
   private K_CarController carController;
   
   //로드 오브젝트 풀
   private Queue<GameObject> roadPool = new Queue<GameObject>();
   private int roadPoolSize = 3;
   
   //도로 이동
   private List<GameObject> activeRoads = new List<GameObject>();
   
   //상태
   public enum State{Start, Play, End}
   public State GameState { get; private set; } = State.Start;
   
   
   //싱글톤
   /*private static K_GameManager instance;
   public static K_GameManager Instance
   {
      get
      {
         if (instance == null)
         {
            instance = FindObjectOfType<GameManager>();
         }

         return instance;
      }
   }

   private void Awake()
   {
      if (instance != null && instance != this)
      {
         Destroy(this.gameObject);
      }
      else
      {
         instance = this;
      }
   }*/

   private void Start()
   {
      //Road 오브젝트 풀 초기화
      InitializeRoadPool();
      
      //게임 시작
      StartGame();
   }

   private void Update()
   {
      //활성화 된 도로를 아래로 서서히 이동
      foreach (var activeRoad in activeRoads)
      {
         activeRoad.transform.Translate(Vector3.back * Time.deltaTime);
      }
      
      //Gas 정보 출력
      if(carController != null) gasText.text = carController.Gas.ToString();
   }

   private void StartGame()
   {
      //도로 생성
      SpawnRoad(Vector3.zero);
      
      //자동차 생성
       carController = Instantiate(carPrefab, new Vector3(0, 0, -3f), Quaternion.identity)
          .GetComponent<K_CarController>();
      
      //left, right move button에 자동차 컨트롤 기능 적용
      leftMoveButton.OnMoveButtonDown += () => { carController.Move(-1f); };
      rightMoveButton.OnMoveButtonDown += () =>{ carController.Move(1f); };
      
   }

   #region 도로 생성 및 관리

   //도로 오브젝트 풀 초기화
   private void InitializeRoadPool()
   {
      for (int i = 0; i < roadPoolSize; i++)
      {
         GameObject road = Instantiate(roadPrefab);
         road.SetActive(false);
         roadPool.Enqueue(road);
      }
   }
   
   //도로 오브젝트 풀어서 불러와 배치하는 함수
   public void SpawnRoad(Vector3 position)
   {
      if (roadPool.Count > 0)
      {
         GameObject road = roadPool.Dequeue();
         road.transform.position = position;
         road.SetActive(true);
         
         //활성화 된 길을 움직이기 위해 List에 저장
         activeRoads.Add(road);
      }
      else
      {
         GameObject road = Instantiate(roadPrefab, position, Quaternion.identity);
         activeRoads.Add(road);
      }
   }

   public void DestroyRoad(GameObject road)
   {
      road.SetActive(false);
      activeRoads.Remove(road);
      roadPool.Enqueue(road);
   }
   #endregion
   
}
