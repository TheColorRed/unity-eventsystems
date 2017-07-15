using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystems;

public class TestBehaviour1 : MonoBehaviour {

  public void Talk(CustomEvent e) {
    Debug.Log("I was initiated by: " + e.initiator.name);
  }


}
