using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_TraceControl : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //���ڽ� �ɷ�ġ�� ���� Collider ũ�� ����, �̺�Ʈ �ڵ鷯 �Ǵ� �ٸ� ��� �����غ� �� 

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponentInParent<Enemy_move>().trace = true;
        }

    }
}
