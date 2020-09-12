using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class JsonManager : MonoBehaviour
{
    // 싱글톤 사용
    public static JsonManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Debug.LogError("JsonManager use only one!!!");
    }

    private void Start()
    {
        //EnemyData enemyData = new EnemyData();
        //string jsonData = JsonUtility.ToJson(enemyData);
        //CreateJsonFile(Application.dataPath + "/JsonData/", "1-StageData",jsonData);

        //var jsonData = LoadJsonFile<EnemyData>(Application.dataPath + "/JsonData/", "1-StageData");

        //jsonData.Print();
    }


    public void CreateJsonFile(string createPath, string fileName, string jsonData)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, fileName), FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }

    public T LoadJsonFile<T>(string loadPath, string fileName)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string jsonData = Encoding.UTF8.GetString(data);
        return JsonUtility.FromJson<T>(jsonData);
    }

    //T LoadJsonFile<T>(string loadPath, string fileName)
    //{
    //    string jsonData = Encoding.
    //    return JsonUtility.FromJson<T>(string a);
    //}
}
