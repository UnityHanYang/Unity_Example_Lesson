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

        //string path = Application.dataPath; // �̷��� ȥ��
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
            // �ؽ�Ʈ ������ ����� ���(���ϸ�, Ȯ���� ����)
            string path = $"{Application.streamingAssetsPath}/{data.name}_Data.json";
            // PlayerData�� Json ���ڿ��� ��ȯ
            string json = JsonUtility.ToJson(data);
            // ���� ���(���, ����);
            File.WriteAllText(path, json);
        }
    }

    public void Load()
    {
        readFromJson.Clear();

        string[] names = { "����", "�ü�" };

        foreach (string name in names)
        {
            string path = $"{Application.streamingAssetsPath}/{name}_Data.json";

            // ��ȿ�� �˻�
            if (File.Exists(path))
            {
                // ���Ϸκ��� Json �������� ���ڿ��� ������
                string json = File.ReadAllText(path);
                // Json ������ �����͸� �Ľ��Ͽ� PlayerData �ν��Ͻ� ���� �� �� �Ҵ�.
                PlayerData data = JsonConvert.DeserializeObject<PlayerData>(json);
                //readFromJson.Add(JsonUtility.FromJson<PlayerData>(json));
                readFromJson.Add(data);
            }
        }
    }
}

// �ٸ� ���·� �����͸� ����ϱ� ���� ����ȭ ������ �ʿ���
[Serializable]
public class PlayerData // ������ ȣȯ���� �ʿ��� ������ ��ü�̱� ������ ����ȭ ��
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