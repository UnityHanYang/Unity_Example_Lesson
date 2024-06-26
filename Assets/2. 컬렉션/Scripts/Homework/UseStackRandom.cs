using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseStackRandom : MonoBehaviour
{
    public Stack<Vector3> randoStack = new Stack<Vector3>();
    public Stack<Color> randomColorStack = new Stack<Color>();
    public GameObject obj;
    public Renderer objRenderer;

    private void Start()
    {
        objRenderer = obj.GetComponent<Renderer>();
        StartCoroutine("CheckQueue");
    }


    IEnumerator CheckQueue()
    {
        while (true)
        {
            if (randoStack.Count > 0)
            {
                obj.transform.position = randoStack.Pop();
                objRenderer.material.color = randomColorStack.Pop();
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
