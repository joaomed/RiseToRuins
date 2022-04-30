using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
  public GameObject prefabChampion; //qual campeão a gente vai instanciar no jogo
  private GameObject prefabSprite;
  private bool canCreate = true; //para saber se o campeão pode ser criado no jogo
  public AudioSource[] sounds;

  // Método quando clica com botão esquerdo do mouse
  void OnMouseDown()
  {
    //PARA ATIVAR O PREFAB NO CAMPEÃO QUANDO CLICAR NO MESMO
    var spr = Resources.Load("Prefabs/SpriteCard", typeof(GameObject)) as GameObject;
    //condições para criar o campeão do jogo
    if (canCreate && !GameManager.shovelEnabled && GameManager.currentChampion == null && GameManager.cash >= prefabChampion.GetComponent<Properties>().price)
    {
      sounds[0].Play();
      // DEPOIS DE CLICAR NO CAMPEAO
      prefabSprite = Instantiate(spr, transform.position, Quaternion.identity) as GameObject;
      GameManager.currentCard = gameObject;
      GameManager.currentChampion = prefabChampion;
    }
    else if (!canCreate || GameManager.cash >= prefabChampion.GetComponent<Properties>().price)
    {
      sounds[1].Play();
    }
  }
  void Update()
  {
    if (!canCreate || GameManager.cash < prefabChampion.GetComponent<Properties>().price)
    {
      GetComponent<SpriteRenderer>().material.color = Color.gray;
    }
    else
    {
      GetComponent<SpriteRenderer>().material.color = Color.white;
    }
  }

  public void StartRecharge()
  {
    canCreate = false;
    Destroy(prefabSprite);
    GameManager.currentCard = null;
    StartCoroutine("WaitTime");
  }

  IEnumerator WaitTime()
  {
    yield return new WaitForSeconds(prefabChampion.GetComponent<Properties>().timeRecharhe);
    canCreate = true;
  }

}