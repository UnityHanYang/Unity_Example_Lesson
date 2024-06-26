using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    private void Start()
    {
        //IEnumerator someEnum = SomeEnumerator();

        //while(someEnum.MoveNext())
        //{
        //    print(someEnum.Current);
        //}

        //IEnumerator<int> someIntEnum = SomeIntEnumerator();
        // �⺻ Ienumerator�� object Ÿ�� ��ȯ���̶� �ڽ�, ��ڽ� ������ �����Ѵ�.
        // ������ Ienumerator�� ���׸��� ���� ����ϸ� �ڽ�, ��ڽ� ������ �������� -> �޸� ȣ���� �ӵ��� ì�� �� �ִ�.
        //int a = 1000;
        //while(someIntEnum.MoveNext())
        //{
        //    a -= someIntEnum.Current;
        //    print(a);
        //}

        //foreach(Transform child in transform)
        //{
        //    print(child.name);
        //}

        //IEnumerator thisIsCoroutine = ThisIsCoroutine();
        //thisIsCoroutine.MoveNext();
        //print("�ڷ�ƾ�� �ѽ���Ŭ �Ѱ��");

        //StartCoroutine(thisIsCoroutine);

        //StartCoroutine(SecondsCoroutine(10, 0.5f));
        //StartCoroutine(RealtimeSecondsCoroutine(10, 0.5f));

       // StartCoroutine(UntileCoroutine());
    }

    IEnumerator SomeEnumerator()
    {
        yield return "����";

        yield return 1;

        yield return false;

        yield return new object();
    }

    IEnumerator<int> SomeIntEnumerator()
    {
        yield return 6;
        yield return 1;
        yield return 71;
        yield return 50;
        yield return 20;
    }

    IEnumerator ThisIsCoroutine()
    {
        print("�ڷ�ƾ�� �����ߴ�.");
        yield return new WaitForSeconds(1f); // MoveNext()�� ȣ��Ǹ� ���⼭ ���
        print("1�ʰ� ������.");
        yield return new WaitForSeconds(3f);
        print("3�ʰ� �� ������");
        yield return new WaitForSeconds(5f);
        print("5�ʰ� �� ������");
    }

    IEnumerator SecondsCoroutine(int count, float interval)
    {
        float timeTemp = 0;
        for(int i= 0; i<count; i++)
        {
            print($"{i} �� ȣ��, {timeTemp} �� ����");
            timeTemp += interval;
            yield return new WaitForSeconds(interval);
        }
    }

    IEnumerator RealtimeSecondsCoroutine(int count, float interval)
    {
        float timeTemp = 0;
        for(int i = 0; i<count; i++)
        {
            print($"������ {i} �� ȣ��, {timeTemp} �� ����");
            timeTemp += interval;
            yield return new WaitForSecondsRealtime(interval);
        }
    }

    public bool continueKey;

    IEnumerator UntileCoroutine()
    {
        // WaitUntil: �Ű������� �Ѿ �Լ��� Return�� false�� �� ���, true�� �� �Ѿ
        yield return new WaitUntil(()=>continueKey);

        print("��Ƽ�� Ű�� True�� ��");

        // WaitWhile: �Ű������� �Ѿ �Լ��� Return�� true�� �� ���, false�� �� �Ѿ
        yield return new WaitWhile(() => continueKey);
        print("��Ƽ�� Ű�� False�� ��");
    }

}
