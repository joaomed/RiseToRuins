using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieScript : MonoBehaviour
{

  public float life, vel;
  private bool canWalk, canEat;
  private Rigidbody2D rb;
  private Animator anim;
  private AudioSource sound;
  private SpriteRenderer sp;

  void Start()
  {
    canEat = true;
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    sound = GetComponent<AudioSource>();
    sp = GetComponent<SpriteRenderer>();
  }

  void Update()
  {
    CheckChampion();
    CheckDeath();
  }

  void FixedUpdate()
  {
    rb.velocity = canWalk ? new Vector2(-vel * Time.deltaTime, 0) : Vector2.zero;

  }
  void CheckDeath()
  {
    if (life <= 0)
    {
      Destroy(gameObject);
      GameManager.enemiesValue -= 1;

    }
  }
  void CheckChampion()
  {
    RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.right, 0.3f, LayerMask.GetMask("Champions"));


    if (hit.collider != null)
    {
      anim.SetBool("isEating", true);
      canWalk = false;
      if (canEat)
        StartCoroutine(Eating(hit.collider));
      if (!sound.isPlaying)
      {
        sound.Play();
      }
    }
    else
    {
      sound.Stop();
      StopCoroutine("Eating");
      canWalk = canEat = true;
      anim.SetBool("isEating", false);

    }
  }

  IEnumerator Eating(Collider2D col)
  {
    canEat = false;
    yield return new WaitForSeconds(2);
    canEat = true;
    if (col != null) { col.gameObject.GetComponent<Properties>().life--; }
  }

  public void WalkSlow()
  {
    StopCoroutine("WalkFast");
    sp.material.color = Color.cyan;
    vel = 5;
    StartCoroutine("WalkFast");
  }

  IEnumerator WalkFast()
  {
    yield return new WaitForSeconds(10);
    sp.material.color = Color.white;
    vel = 6;
  }
}
