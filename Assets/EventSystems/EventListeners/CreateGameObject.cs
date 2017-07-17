using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventSystems {
  [AddComponentMenu("Event Systems/Listeners/Create GameObject")]
  public class CreateGameObject : MonoBehaviour {

    public string eventName;
    public GameObject gameObjectToCreate;
    public bool atCurrentPosition = false;
    public Vector3 position = Vector3.zero;
    public Vector3 rotation = Vector3.zero;

    void Start() {
      game.addEventListener(eventName, (e) => {
        Vector3 p = atCurrentPosition ? transform.position : position;
        Instantiate(gameObjectToCreate, p, Quaternion.Euler(rotation));
      });
    }
  }
}