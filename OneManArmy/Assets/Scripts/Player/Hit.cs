using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    // Start is called before the first frame update
     void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            //利 单固瘤 贸府
        }
    }
}
