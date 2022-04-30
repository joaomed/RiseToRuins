using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
  public AudioSource sound;
  void OnMouseDown()
  {
    if (GameManager.currentChampion != null || GameManager.shovelEnabled)
    {
      sound.Play();
      GameManager.currentChampion = null;
      GameManager.currentCard = null;
      GameManager.shovelEnabled = false;
    }

  }
}
