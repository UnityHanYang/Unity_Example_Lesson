using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class FileTest : MonoBehaviour
{
    public Text text;

    public List<PlayerData> playerDatas;
    public List<PlayerData> readFromJson = new List<PlayerData>();

    private void Start()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("Data Path : ");
        sb.AppendLine(Application.dataPath);
        sb.AppendLine("Pers data path : ");
        sb.AppendLine(Application.persistentDataPath);
        sb.AppendLine("Str data path : ");
        sb.AppendLine(Application.streamingAssetsPath);

        //string path = Application.dataPath; // 이러면 혼남
        //path += "\n";
        //path += Application.persistentDataPath;
        //path += "\n";
        //path += Application.streamingAssetsPath;

        text.text = sb.ToString();

        DirectoryInfo di = new DirectoryInfo(Application.streamingAssetsPath);
        foreach (FileInfo dir in di.GetFiles())
        {
            string[] arr = dir.FullName.Split("json");
            if (File.Exists(dir.FullName) && !arr[1].Equals(".meta"))
            {
                string json = File.ReadAllText(dir.FullName);

                readFromJson.Add(JsonUtility.FromJson<PlayerData>(json));
            }

        }

    }

    public void Save()
    {
        foreach (PlayerData data in playerDatas)
        {
            // 텍스트 파일을 출력할 경로(파일명, 확장자 포함)
            string path = $"{Application.streamingAssetsPath}/{data.name}_Data.json";
            // PlayerData를 Json 문자열로 변환
            string json = JsonUtility.ToJson(data);
            // 파일 출력(경로, 내용);
            File.WriteAllText(path, json);
        }
    }

    public void Load()
    {
        readFromJson.Clear();

        string[] names = { "전사", "궁수" };

        foreach (string name in names)
        {
            string path = $"{Application.streamingAssetsPath}/{name}_Data.json";

            // 유효성 검사
            if (File.Exists(path))
            {
                // 파일로부터 Json 포맷으로 문자열을 가져옴
                string json = File.ReadAllText(path);
                // Json 포맷의 데이터를 파싱하여 PlayerData 인스턴스 생성 후 값 할당.
                PlayerData data = JsonConvert.DeserializeObject<PlayerData>(json);
                //readFromJson.Add(JsonUtility.FromJson<PlayerData>(json));
                readFromJson.Add(data);
            }
        }
    }
}

// 다른 형태로 데이터를 취급하기 위해 직렬화 과정이 필요함
[Serializable]
public class PlayerData // 데이터 호환성이 필요한 데이터 객체이기 때문에 직렬화 함
{
    public string name;
    public int id;
    public int level;
    public int exp;
    public int attack;
    public int[] items;
    public List<SkillData> skill;
}

[Serializable]
public class SkillData
{
    public int id;
    public int level;
    public UpgradeType upgrade;
}

public enum UpgradeType
{
    Attack,
    Defence
}