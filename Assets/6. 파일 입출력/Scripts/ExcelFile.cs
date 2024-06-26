using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using OfficeOpenXml;
using System.Text;

public class ExcelFile : MonoBehaviour
{
    public List<PersonInfo> personDatas;
    public List<PersonInfo> readFromExcel = new List<PersonInfo>();

    public string filePath;
    private int index1 = 2;

    public void Load()
    {
        string filePath = Path.Combine(Application.dataPath, "example.xlsx");
        LoadDataFromExcel(filePath);
    }

    public void LoadDataFromExcel(string filePath)
    {
        FileInfo fileInfo = new FileInfo(filePath);
        using (ExcelPackage package = new ExcelPackage(fileInfo))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

            int rowCount = worksheet.Dimension.Rows;
            for (int row = 2; row <= rowCount; row++)
            {
                PersonInfo person = new PersonInfo
                {
                    name = worksheet.Cells[row, 1].Text,
                    age = int.Parse(worksheet.Cells[row, 2].Text),
                    height = float.Parse(worksheet.Cells[row, 3].Text),
                    weight = float.Parse(worksheet.Cells[row, 4].Text),
                    childInfo = new List<ChildInfo>()
                };

                string[] childGenders = worksheet.Cells[row, 6].Text.Split(',');
                string[] childAges = worksheet.Cells[row, 7].Text.Split(',');

                for (int i = 0; i < childGenders.Length; i++)
                {
                    if (!string.IsNullOrEmpty(childGenders[i]) && !string.IsNullOrEmpty(childAges[i]))
                    {
                        ChildInfo child = new ChildInfo
                        {
                            gen = (ChildInfo.gender)Enum.Parse(typeof(ChildInfo.gender), childGenders[i]),
                            age = int.Parse(childAges[i])
                        };
                        person.childInfo.Add(child);
                    }
                }

                readFromExcel.Add(person);
            }
        }
    }

    public void Click_To_Save()
    {
        filePath = Path.Combine(Application.dataPath, "example.xlsx");
        SaveToExcel(filePath);
    }


    void SaveToExcel(string filePath)
    {
        StringBuilder childGender = new StringBuilder();
        StringBuilder childAge = new StringBuilder();
        using (ExcelPackage package = new ExcelPackage())
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

            worksheet.Cells[1, 1].Value = "이름";
            worksheet.Cells[1, 2].Value = "나이";
            worksheet.Cells[1, 3].Value = "키";
            worksheet.Cells[1, 4].Value = "몸무게";
            worksheet.Cells[1, 5].Value = "자식 수";
            worksheet.Cells[1, 6].Value = "모든 자식 성별";
            worksheet.Cells[1, 7].Value = "모든 자식 나이";

            for (int i = 0; i < personDatas.Count; i++)
            {
                PersonInfo personInfo = personDatas[i];
                worksheet.Cells[index1 + i, 1].Value = personInfo.name;
                worksheet.Cells[index1 + i, 2].Value = personInfo.age;
                worksheet.Cells[index1 + i, 3].Value = personInfo.height;
                worksheet.Cells[index1 + i, 4].Value = personInfo.weight;
                worksheet.Cells[index1 + i, 5].Value = personInfo.childInfo.Count;
                childGender.Clear();
                childAge.Clear();
                for (int j = 0; j < personInfo.childInfo.Count; j++)
                {
                    childGender.Append((j == personInfo.childInfo.Count - 1) ? personInfo.childInfo[j].gen : personInfo.childInfo[j].gen + ",");
                    childAge.Append((j == personInfo.childInfo.Count - 1) ? personInfo.childInfo[j].age : personInfo.childInfo[j].age + ",");
                }
                worksheet.Cells[index1 + i, 6].Value = childGender.ToString();
                worksheet.Cells[index1 + i, 7].Value = childAge.ToString();
            }

            FileInfo fileInfo = new FileInfo(filePath);
            package.SaveAs(fileInfo);

            Debug.Log("엑셀 파일 저장 완료: " + filePath);
        }
    }
}

[Serializable]
public class PersonInfo
{
    public string name;
    public int age;
    public float height;
    public float weight;
    public List<ChildInfo> childInfo;
}

[Serializable]
public class ChildInfo
{
    public enum gender
    {
        female,
        male
    }
    public gender gen;
    public int age;
}
