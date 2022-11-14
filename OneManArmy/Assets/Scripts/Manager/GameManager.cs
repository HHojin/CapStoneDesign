using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }
            //싱글턴 오브젝트 반환
            return m_instance;
        }
    }

    private static GameManager m_instance;

    public bool isGameOver { get; set; }

    private void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void LevelUP()
    {
        UIManager.instance.ActiveStatUI(true);
    }

    public void GameOver()
    {
        isGameOver = true;
        UIManager.instance.UpdateGameoverUI(true);
    }
}
