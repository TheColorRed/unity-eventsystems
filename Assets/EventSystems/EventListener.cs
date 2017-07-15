using UnityEngine;
using System.Collections.Generic;

namespace EventSystems {

  [DisallowMultipleComponent]
  public class EventListener : MonoBehaviour {

    public List<EventHandler> events = new List<EventHandler>();

    public void Destroy() {
      Destroy(this);
    }

    void OnEnable() {
      EvtentSystem.Add(this);
    }

    void OnDisable() {
      EvtentSystem.Remove(this);
    }

  }

}