using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventSystems {
  [DisallowMultipleComponent]
  [AddComponentMenu("Event Systems/Dispatchers/UI/Button")]
  public class DispatchButton : MonoBehaviour {
    public void ButtonClick(string eventName) {
      game.dispatchEvent(new CustomEvent(eventName));
    }
  }
}