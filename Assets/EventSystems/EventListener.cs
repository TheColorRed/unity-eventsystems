using UnityEngine;
using System.Collections.Generic;

namespace EventSystems {

  [DisallowMultipleComponent]
  [AddComponentMenu("Event Systems/Listeners/EventListener")]
  public class EventListener : MonoBehaviour {

    public List<EventHandler> events = new List<EventHandler>();

    void Start() {
      game.initRootGameObject();
    }

    public void Destroy() {
      Destroy(this);
    }

  }

}