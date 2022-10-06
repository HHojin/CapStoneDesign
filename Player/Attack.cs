using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            defaultAttack();
        }
    }

    void defaultAttack() 
    {
        this.transform.LookAt(AttackLookatPoint());//마우스 포인터가 있는곳을 향한다 
        GetComponent<Move>().agent.isStopped = true; //이동 중지 
        //기본 공격모션 연결 
    }
    /*
     * 이런 방식으로 공격(스킬)마다 함수 생성
     * 나중에는 함수 포인터화 하여 관리 
     */
    Vector3 AttackLookatPoint()
    {
        
        return GetComponent<Move>().MovePointReturn(Camera.main.ScreenPointToRay(Input.mousePosition));
    }
}
