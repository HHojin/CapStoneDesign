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

    private void OnTriggerEnter(Collider other) //�̰� �׳� �Ÿ� ���� ���ݸ�� �����°ŷ� �ұ�? ������ ȸ�ǳ���
    {
      
        if (other.gameObject.name == "Main_player")
        {
            Debug.LogWarning("Play Attack motion & stand");// �̵� ���߰� ���ݸ�� ���;��� 
            //���� �ִϸ��̼� ���
            parent.GetComponent<EnemyAnimationControl>().AttackAnim(true);
        
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Main_player")
        {
            parent.GetComponent<EnemyAnimationControl>().AttackAnim(false); // ���� ���� ����� �� ���� ���
        }
    }
}
