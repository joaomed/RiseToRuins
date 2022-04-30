using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties : MonoBehaviour
{
  public int life, price, timeRecharhe;
  private AudioClip sound;

  void Start()
  {
    sound = Resources.Load("Audios/Remove", typeof(AudioClip)) as AudioClip;
  }
  void Update()
  {
    CheckDeath();
    CheckMouse();

  }
  void CheckDeath()
  {
    if (life <= 0)
    {
      Destroy(gameObject);

    }
  }

  //MÉTODO PARA USAR A O PÁ NA PLANTA
  void CheckMouse()
  {
    if (GetComponent<Collider2D>().OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
    {
      OnMouseDown();
    }
  }

  void OnMouseDown()
  {
    //se a pá está ativada e clicando com esquerdo
    if (GameManager.shovelEnabled && Input.GetMouseButtonDown(0))
    {
      GameManager.shovelEnabled = false;
      AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
      Destroy(gameObject);

    }
  }
}



