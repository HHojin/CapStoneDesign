using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Move : MonoBehaviour
{


    public float nSpeed;      // 나중에 캐릭터 Status 구조체 만들어서 참조하도록 할 것 
    public NavMeshAgent agent;
    private Vector3 movePoint; // 이동 위치 저장
    public Camera mainCamera; // 메인 카메라
    public Ray ray;
    void Start()
    {
        //기본설정 초기화
        nSpeed = 4.0f;

        mainCamera = Camera.main;
        agent = this.GetComponent<NavMeshAgent>();
        agent.speed = nSpeed;
        agent.angularSpeed = 7600.0f;
        agent.stoppingDistance = 0;
        agent.autoBraking = false;
    }

    void Update()
    {

        mainCamera.transform.position = new Vector3(this.transform.position.x, 25, this.transform.position.z); //test용 카메라 위치 
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(1))
        {
            agent.isStopped = false;
            Move_to(MovePointReturn(ray)); 
            //이동 장소에 이펙트 추가 
        }

    }




    // 추후 아래 함수들 따로 묶어서 기능관리, 유지보수 용이 
    void Move_to(Vector3 movePoint)
    {
        //test 명령어 Dodging func완성 이후 폐기 
        agent.SetDestination(movePoint);
        
    }
   public Vector3 MovePointReturn(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            movePoint = raycastHit.point;
           // Debug.Log("movePoint : " + movePoint.ToString());
           // Debug.Log("맞은 객체 : " + raycastHit.transform.name);

        }
        return movePoint;
    }
    public Ray getRay()
    {
        return ray;
    }

}

