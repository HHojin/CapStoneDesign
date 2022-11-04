using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    private bool canDodge = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canDodge)
        {
            dodging();
        }
    }
    void dodging()
    {
        canDodge = false;
        GetComponent<Move>().agent.isStopped = true; //이동 중지
        transform.Find("Hit_zone").gameObject.GetComponent<BoxCollider>().enabled = false; //데미지 무시
        //GetComponent<AnimationControl>().DodgeAnim(); //회피 모션 재생   

        //StartCoroutine(CheckDodgeAnim());
    }

    /*
    IEnumerator CheckDodgeAnim()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            if (GetComponent<AnimationControl>().animator.GetCurrentAnimatorStateInfo(0).fullPathHash !=
            Animator.StringToHash("Base Layer.Dodge"))
            {
                transform.Find("Hit_zone").gameObject.GetComponent<BoxCollider>().enabled = true; //데미지 적용
                GetComponent<Move>().agent.isStopped = false; //이동 가능
                canDodge = true;
                break;
            }
        }
    }
    */
}
