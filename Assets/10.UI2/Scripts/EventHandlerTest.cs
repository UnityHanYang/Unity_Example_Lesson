using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventHandlerTest : MonoBehaviour, IPointerDownHandler {
	public void OnPointerDown(PointerEventData eventData) {
		print("Ŭ��");
		GetComponent<Animator>().SetTrigger("Hit");
	}
}
