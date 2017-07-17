using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

namespace EventSystems {

  public static class EvtentSystem {

    public static void addEventListener(this GameObject obj, string eventName, Action<CustomEvent> action) {
      var listener = obj.GetComponent<EventListener>();
      if (listener == null) {
        listener = obj.AddComponent<EventListener>();
      }
      listener.events.Add(new EventHandler(eventName, action));
    }

    public static void addEventListener(this GameObject obj, string eventName, MonoBehaviour component, string methodName) {
      var listener = obj.GetComponent<EventListener>();
      if (listener == null) {
        listener = obj.AddComponent<EventListener>();
      }
      listener.events.Add(new EventHandler(eventName, component, methodName));
    }

    public static void removeEventListener(this GameObject obj, Action<CustomEvent> action) {
      var listener = obj.GetComponent<EventListener>();
      if (listener == null) { return; }
      for (int i = listener.events.Count - 1; i >= 0; i--) {
        var evt = listener.events[i];
        if (evt.action == action) {
          listener.events.Remove(evt);
        }
      }
    }

    public static void removeEventListener(this GameObject obj, string eventName, string methodName) {
      var listener = obj.GetComponent<EventListener>();
      if (listener == null) { return; }
      for (int i = listener.events.Count - 1; i >= 0; i--) {
        var evt = listener.events[i];
        if (evt.name == eventName && evt.method == methodName) {
          listener.events.Remove(evt);
        }
      }
    }

    public static void dispatchEvent(this GameObject obj, Event theEvent) {
      theEvent.target = obj;
      var listeners = obj.GetComponent<EventListener>();
      if (listeners == null) { return; }
      foreach (var eventHandler in listeners.events) {
        if (eventHandler.name == theEvent.name) {
          if (eventHandler.comp != null) {
            Type thisType = eventHandler.comp.GetType();
            MethodInfo theMethod = thisType.GetMethod(eventHandler.method);
            theMethod.Invoke(eventHandler.comp, new Event[] { theEvent });
          } else if (eventHandler.action != null) {
            eventHandler.action((CustomEvent)theEvent);
          }
        }
      }
    }
  }

}