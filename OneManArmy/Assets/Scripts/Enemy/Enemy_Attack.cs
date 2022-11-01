using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Attack: MonoBehaviour
{
    Transform parent;
   

    void Start()
    {
        parent = this.transform.parent;
       
    }

    private void OnTriggerEnter(Collider other) //이거 그냥 거리 따라서 공격모션 나오는거로 할까? 다음주 회의내용
    {
      
        if (other.gameObject.name == "Main_player")
        {
            Debug.LogWarning("Play Attack motion & stand");// 이동 멈추고 공격모션 나와야함 
            //공격 애니메이션 재생
            parent.GetComponent<EnemyAnimationControl>().AttackAnim(true);
        
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Main_player")
        {
            parent.GetComponent<EnemyAnimationControl>().AttackAnim(false); // 공격 범위 벗어났을 때 공격 취소
        }
    }
}
