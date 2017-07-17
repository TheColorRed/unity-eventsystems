using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystems;

public class GameSprite : MonoBehaviour {

  // Use this for initialization
  void Start() {
    var rb = GetComponent<Rigidbody2D>();
    rb.velocity = new Vector2(Random.Range(-10, 10), Random.value * 10);
    GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    Destroy(gameObject, 10f);
  }

}
