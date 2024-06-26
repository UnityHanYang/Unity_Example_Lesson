using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseQueueRandom : MonoBehaviour
{
    public Queue<Vector3> randoQueue = new Queue<Vector3>();
    public Queue<Color> randomColorQueue = new Queue<Color>();
    public GameObject obj;
    public Renderer objRenderer;

    private void Start()
    {
        objRenderer = obj.GetComponent<Renderer>();
        StartCoroutine("CheckQueue");
    }


    IEnumerator CheckQueue()
    {
        while(true)
        {
            if(randoQueue.Count > 0)
            {
                obj.transform.position = randoQueue.Dequeue();
                objRenderer.material.color = randomColorQueue.Dequeue();
            }
            yield return new WaitForSeconds(1f);
        }
    }

}