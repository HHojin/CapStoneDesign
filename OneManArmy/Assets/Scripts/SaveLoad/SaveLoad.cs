using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SaveLoad : MonoBehaviour
{

    //���θ޴��� �ɾ��ֱ�
    public static SaveLoad instance;
    PlayerStat ps;
    Data_set saveData;
    string SLdata; // save Load data
    string path; // ���
    const string FILENAME = "SaveFile.json";
   

    private void Awake()
    {
        if (instance == null)
            instance = this;

        //�ٸ� �������� ��� �����ϵ��� ����, �ʿ������ ����  
        //����ȭ�鿡���� Load ��ɸ�, Data_set�� static���� �� �ϴ� ��Ļ��
        DontDestroyOnLoad(this.gameObject);
        
    }
    private void Start()
    {
        ps = GameObject.FindObjectOfType<PlayerStat>();
        saveData = new Data_set();
        path = Application.persistentDataPath + "/"; //����Ƽ �⺻��� // C:\Users\----\AppData\LocalLow\DefaultCompany\...
    }
    //test Code �Դϴ�. �׽�Ʈ ���� ����
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Alpha1)) //savePoint�� ������ Save, Load ��ư�� ������ Load
        {
            SaveData();
            
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            
            LoadData();//�̺κ��� ���� �б� + ���� 
        }
    }
    public void SaveData()
    {  //�ð��� ������ �÷��̾� ������ �ٸ� Ŭ������ ���ҽ��� �ϵ��ڵ���� ����..

        saveData.MaxHP = ps.MaxHP.GetStat();
        saveData.Current_HP = ps.Current_HP;
        saveData.Move_speed = ps.Move_speed;
        saveData.Attack_power = ps.Attack_power.GetStat();
        saveData.Stealth = ps.Stealth.GetStat();
        saveData.Armor = ps.Armor.GetStat();
        saveData.EXP = ps.EXP;
        saveData.Level = ps.Level;
        saveData.SceneNumber = SceneManager.GetActiveScene().buildIndex;//���� �� 
        saveData.Pos = ps.transform.GetChild(0).position; //!!!

        SLdata = JsonUtility.ToJson(saveData);
        File.WriteAllText(path + FILENAME, SLdata);// �̺κ��� ���� ���� 
    }
    public void LoadData()
    {
        SLdata = File.ReadAllText(path + FILENAME);
        Data_set Load = JsonUtility.FromJson<Data_set>(SLdata); // �о���� �κ� 

        //Player ã�Ƽ� Stat ���� 
        ps = GameObject.FindObjectOfType<PlayerStat>();
        ps.MaxHP.SetStat(Load.MaxHP);
        ps.Current_HP = Load.Current_HP;
        ps.Move_speed = Load.Move_speed;
        ps.Attack_power.SetStat(Load.Attack_power);
        ps.Stealth.SetStat(Load.Stealth);
        ps.Armor.SetStat(Load.Armor);
        ps.EXP = Load.EXP;
        ps.Level = Load.Level;
        ps.transform.GetChild(0).position = Load.Pos;//!!!
        ps.transform.GetChild(0).GetComponent<Move>().MoveStop();//�̵� ���߱�
    }

    public void LoadScene() //����ȭ�鿡�� �̾��ϱ� ������ �� ��� �� LoadData�Լ� ȣ�� 
    {
        SceneManager.LoadScene(saveData.SceneNumber);
    }

}