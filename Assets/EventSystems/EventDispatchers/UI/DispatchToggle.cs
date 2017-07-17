using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventSystems {

  [DisallowMultipleComponent]
  [AddComponentMenu("Event Systems/Dispatchers/UI/Toggle")]
  public class DispatchToggle : MonoBehaviour {

    /// <summary>
    /// When the toggle is changed dispatch
    /// </summary>
    /// <param name="eventName"></param>
    public void Change(string eventName) {
      gameObject.dispatchEvent(new CustomEvent(eventName));
    }

  }
}