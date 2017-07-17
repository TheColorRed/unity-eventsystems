using UnityEngine;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace EventSystems {

  public abstract class Event {

    public string name;
    public GameObject target;
    public object[] args;

    public Event(string eventName, params object[] args) {
      name = eventName;
    }

  }

  public class CustomEvent : Event {

    public CustomEvent(string eventName, params object[] args) : base(eventName, args) {

    }

  }

}