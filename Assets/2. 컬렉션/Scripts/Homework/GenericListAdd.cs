using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericListAdd : MonoBehaviour
{
    List<Vector3> randomVecList;
    List<Color> randomColorList;

    Color[] colorArr;
    Vector3[] vecArr = new Vector3[5];

    public GameObject[] objArr;

    List<int> checkList = new List<int>();

    void Start()
    {
        RandomPosition(vecArr);
        colorArr = new Color[] { Color.red, Color.yellow, Color.green, Color.blue, Color.black };

        randomVecList = RandomAdd(vecArr);
        randomColorList = RandomAdd(colorArr);

        StartCoroutine("ChangeVecOrColor");
    }


    List<T> RandomAdd<T>(T[] Arr)
    {
        List<T> list = new List<T>();
        for (int i = 0; i < Arr.Length; i++)
        {
            int rand = Random.Range(0, Arr.Length);
            if (!checkList.Contains(rand))
            {
                checkList.Add(rand);
                list.Add(Arr[rand]);
            }
            else
            {
                i--;
            }
        }
        checkList.Clear();
        return list;
    }

    void RandomPosition(Vector3[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            float rand = (float)Random.Range(-2.1f, 2.7f);
            Vector3 vec = new Vector3(rand, rand, rand);
            arr[i] = vec;
        }
    }

    IEnumerator ChangeVecOrColor()
    {
        while (true)
        {
            int rand = Random.Range(0, objArr.Length);
            objArr[rand].SetActive(true);
            objArr[rand].transform.position = randomVecList[rand];
            objArr[rand].GetComponent<Renderer>().material.color = randomColorList[rand];
            yield return new WaitForSeconds(1f);
            objArr[rand].SetActive(false);
        }
    }
}
