using UnityEngine;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace EventSystems {

  abstract public class Event {

    public string name;
    public GameObject initiator;
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