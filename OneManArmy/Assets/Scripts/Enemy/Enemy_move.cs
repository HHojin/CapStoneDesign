using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy_move : MonoBehaviour
{

    NavMeshAgent NVagent;
    
    public GameObject GOplayer = null;

    private void Awake()
    {
        GOplayer = GameObject.Find("Main_player");
    }

    // Start is called before the first frame update
    void Start()
    {
         NVagent = this.GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        NVagent.SetDestination(GOplayer.transform.position);
    }
  
}
