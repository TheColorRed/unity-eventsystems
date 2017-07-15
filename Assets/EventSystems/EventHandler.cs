using UnityEngine;
using System;

namespace EventSystems {

  [System.Serializable]
  public class EventHandler {
    public string name;
    public string method;
    public MonoBehaviour comp;
    public Action<CustomEvent> action;

    public EventHandler(string name, MonoBehaviour comp, string method) {
      this.name = name;
      this.method = method;
      this.comp = comp;
    }

    public EventHandler(string name, Action<CustomEvent> action) {
      this.name = name;
      this.action = action;
    }
  }

}