using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventSystems {
  [AddComponentMenu("Event Systems/Listeners/Create Random GameObject")]
  public class CreateRandomGameObject : MonoBehaviour {

    public string eventName;
    public GameObject[] randomObjectToCreate;
    public bool atCurrentPosition = false;
    public Vector3 position = Vector3.zero;
    public Vector3 rotation = Vector3.zero;

    void Start() {
      game.addEventListener(eventName, (e) => {
        Debug.Log("Target: " + e.target);
        Vector3 p = atCurrentPosition ? transform.position : position;
        Instantiate(randomObjectToCreate[Random.Range(0, randomObjectToCreate.Length)], p, Quaternion.Euler(rotation));
      });
    }
  }
}