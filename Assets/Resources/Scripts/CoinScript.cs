using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
  public float vel;
  public AudioClip clip;
  [HideInInspector]
  public bool newInstance = false;

  private Rigidbody2D rb;
  private Collider2D col;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    col = GetComponent<Collider2D>();
    Destroy(gameObject, 10);
  }
  void Update()
  {
    if (col.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
    {
      OnMouseDown();
    }
  }

  void FixedUpdate()
  {
    if (newInstance == false)
    {
      rb.velocity = new Vector2(0, -vel * Time.deltaTime);
    }
  }
  void OnMouseDown()
  {
    // se o colisor estiver sendo tocado pelo mouse, a gente vai chamar o OnMouseDown
    if (Input.GetMouseButtonDown(0))
    {
      GameManager.cash += 25;
      AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
      Destroy(gameObject);
    }
  }
}
