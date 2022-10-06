using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Attack: MonoBehaviour
{
    
     private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning(other);
        if (other.gameObject.name == "Main_player")
        {
            Debug.LogWarning("Play Attack motion & stand");// 이동 멈추고 공격모션 나와야함 
            //공격 애니메이션 재생 
        }
    }

    
}
