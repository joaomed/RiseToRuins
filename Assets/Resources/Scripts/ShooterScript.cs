using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
  public float vel, damageHit;
  public bool isSlow;
  public AudioClip clip;

  private Rigidbody2D rb;
  private SpriteRenderer sr;
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    sr = GetComponent<SpriteRenderer>();
  }

  // Update is called once per frame
  void Update()
  {
    // destruir quando projetil sair da camera
    if (!sr.isVisible)
    {
      Destroy(gameObject);
    }


  }

  void FixedUpdate()
  {
    rb.velocity = new Vector2(vel * Time.deltaTime, 0);
  }

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.CompareTag("Enemy"))
    {
      if (isSlow == true)
      {
        col.gameObject.GetComponent<EnemieScript>().WalkSlow();
      }
      AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
      col.gameObject.GetComponent<EnemieScript>().life -= damageHit;
      Destroy(gameObject);
    }

  }
}
