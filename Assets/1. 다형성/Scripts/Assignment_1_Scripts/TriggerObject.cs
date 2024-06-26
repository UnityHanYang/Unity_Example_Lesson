using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerObject : MonoBehaviour
{
    public Text text;
    bool isCollision = false;
    IObject currentObject = null;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.TryGetComponent<IObject>(out IObject iobject))
        {
            text.gameObject.SetActive(true);
            isCollision = true;
            currentObject = iobject;
        }
    }

    private void Update()
    {
        if (isCollision && Input.GetKeyDown(KeyCode.F))
        {
            currentObject?.Trigger_Event();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (currentObject != null)
        {
            text.gameObject.SetActive(false);
            isCollision = false;
            currentObject = null;
        }

        if (collision.collider.gameObject.layer == 11)
        {
            collision.collider.gameObject.GetComponent<Chest>()?.Close_Event();
        }
    }
}


