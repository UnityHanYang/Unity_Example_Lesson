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
        // 기본 Ienumerator는 object 타입 반환값이라 박싱, 언박싱 절차가 존재한다.
        // 하지만 Ienumerator에 제네릭을 같이 사용하면 박싱, 언박싱 절차가 없어진다 -> 메모리 호율과 속도를 챙길 수 있다.
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
        //print("코루틴이 한싸이클 넘겼다");

        //StartCoroutine(thisIsCoroutine);

        //StartCoroutine(SecondsCoroutine(10, 0.5f));
        //StartCoroutine(RealtimeSecondsCoroutine(10, 0.5f));

       // StartCoroutine(UntileCoroutine());
    }

    IEnumerator SomeEnumerator()
    {
        yield return "하이";

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
        print("코루틴이 시작했다.");
        yield return new WaitForSeconds(1f); // MoveNext()가 호출되면 여기서 대기
        print("1초가 지났다.");
        yield return new WaitForSeconds(3f);
        print("3초가 더 지났다");
        yield return new WaitForSeconds(5f);
        print("5초가 더 지났다");
    }

    IEnumerator SecondsCoroutine(int count, float interval)
    {
        float timeTemp = 0;
        for(int i= 0; i<count; i++)
        {
            print($"{i} 번 호출, {timeTemp} 초 지남");
            timeTemp += interval;
            yield return new WaitForSeconds(interval);
        }
    }

    IEnumerator RealtimeSecondsCoroutine(int count, float interval)
    {
        float timeTemp = 0;
        for(int i = 0; i<count; i++)
        {
            print($"실제로 {i} 번 호출, {timeTemp} 초 지남");
            timeTemp += interval;
            yield return new WaitForSecondsRealtime(interval);
        }
    }

    public bool continueKey;

    IEnumerator UntileCoroutine()
    {
        // WaitUntil: 매개변수로 넘어간 함수의 Return이 false일 때 대기, true일 때 넘어감
        yield return new WaitUntil(()=>continueKey);

        print("컨티뉴 키가 True가 됨");

        // WaitWhile: 매개변수로 넘어간 함수의 Return이 true일 때 대기, false일 때 넘어감
        yield return new WaitWhile(() => continueKey);
        print("컨티뉴 키가 False가 됨");
    }

}
