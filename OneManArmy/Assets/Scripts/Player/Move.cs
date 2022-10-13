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

        
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        //우클릭 이동 
        if (Input.GetMouseButton(1))
        {
            agent.isStopped = false;
            Move_to(MovePointReturn(ray));
            //이동 장소에 이펙트 추가 
            if (Input.GetMouseButtonUp(1))
            {

            }
        }

    }




    // 추후 기능관리, 유지보수 용이 하도록 변경
    void Move_to(Vector3 movePoint)
    {
        agent.SetDestination(movePoint);
    }
   public Vector3 MovePointReturn(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            movePoint = raycastHit.point;
            Debug.Log("movePoint : " + movePoint.ToString());
            Debug.Log("맞은 객체 : " + raycastHit.transform.name);

        }
        return movePoint;
    }
    public Ray getRay()
    {
        return ray;
    }

}

