using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_TraceControl : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //스텔스 능력치에 따라 Collider 크기 변경, 이벤트 핸들러 또는 다른 방법 강구해볼 것 

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main_player")
        {
            GetComponentInParent<Enemy_move>().trace = true;
        }

    }
}
