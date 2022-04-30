using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassScript : MonoBehaviour
{
  // Está vazia ou não para plantar
  private bool isEmpty;

  void Update()
  {
    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.1f, LayerMask.GetMask("Champions"));
    isEmpty = hit.collider == null;
  }

  void OnMouseDown()
  {
    if (isEmpty && GameManager.currentChampion != null)
    {
      Instantiate(GameManager.currentChampion, transform.position, Quaternion.identity);
      GameManager.cash -= GameManager.currentChampion.GetComponent<Properties>().price;
      GameManager.currentChampion = null;
      GameManager.currentCard.GetComponent<CardScript>().StartRecharge();

    }
  }
}
