using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystems;
using System;

public class Sender : MonoBehaviour {

  private Action<CustomEvent> action = (e) => Debug.Log("I was initiated from an action by " + e.initiator.name);

  void Start() {

    gameObject.AddEventListener("Talk", action);
    gameObject.AddEventListener("Talk", this, "SayHello");

    Invoke("RemoveEvent", 2f);
    gameObject.DispatchEvent(new CustomEvent("Talk"));
  }

  public void RemoveEvent() {
    gameObject.RemoveEventListener("Talk", "SayHello");
    gameObject.RemoveEventListener(action);
  }

  public void SayHello(CustomEvent e) {
    Debug.Log("I was initiated from a string by " + e.initiator.name);
  }

}
