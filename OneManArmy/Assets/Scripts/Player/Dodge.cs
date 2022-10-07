using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour
{
  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dodging();
        }
    }
    void dodging() 
    {
        //이동 중지
        GetComponent<Move>().agent.isStopped = true;
        //데미지 무시
        GetComponentInChildren<BoxCollider>().enabled = false;
        //회피 루트모션 재생    

        //데미지 적용
        GetComponentInChildren<BoxCollider>().enabled = true;

        /*회피 애니메이션 끝난 이후 이동 가능
            if(isAnimationPlaying == flase)
            GetComponent<Move>().agent.isStopped = false;
        */
    }
}
