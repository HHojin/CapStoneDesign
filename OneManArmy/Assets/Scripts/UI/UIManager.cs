using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<UIManager>();
            }

            return m_instance;
        }
    }

    private static UIManager m_instance;

    public Text hpText;
    public Image hpBar;
    public Image curHpBar;
    public GameObject gameoverUI;

    public void UpdateHp(float hp)
    {
        hpText.text = hp.ToString();

        curHpBar.fillAmount = hp / 100.0f;
        StartCoroutine(UpdateHpBar());
    }

    IEnumerator UpdateHpBar()
    {
        while (true)
        {
            yield return null;
            if (hpBar.fillAmount != curHpBar.fillAmount)
                hpBar.fillAmount = Mathf.Lerp(hpBar.fillAmount, curHpBar.fillAmount, Time.deltaTime * 2.0f);
        }
    }

    public void UpdateGameoverUI(bool active)
    {
        gameoverUI.SetActive(active); //¹Ì±¸Çö
    }
}
