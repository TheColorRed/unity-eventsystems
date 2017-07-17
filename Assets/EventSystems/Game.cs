using UnityEngine;
using System;

namespace EventSystems {

  public static class game {

    private static GameObject _gameObject;

    public static void initRootGameObject() {
      if (_gameObject == null) {
        _gameObject = new GameObject("game");
        _gameObject.transform.position = Vector3.zero;
        _gameObject.transform.rotation = Quaternion.identity;
        _gameObject.AddComponent<EventListener>();
        GameObject.DontDestroyOnLoad(_gameObject);
      }
    }

    public static void addEventListener(string eventName, Action<CustomEvent> evt) {
      initRootGameObject();
      _gameObject.addEventListener(eventName, evt);
    }

    public static void addEventListener(string eventName, MonoBehaviour component, string methodName) {
      initRootGameObject();
      _gameObject.addEventListener(eventName, component, methodName);
    }

    public static void dispatchEvent(CustomEvent theEvent) {
      initRootGameObject();
      _gameObject.dispatchEvent(theEvent);
    }

  }
}