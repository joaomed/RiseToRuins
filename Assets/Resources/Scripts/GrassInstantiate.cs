using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassInstantiate : MonoBehaviour
{
  public GameObject prefabGrass; //Saber quem é o prefab para instanciar
  private GameObject grass; //Para ter acesso a instancia
  private float currentX = -5.5f, currentY = 1.0f; // valor da posicao X e Y atual na grama
  private float distanceX, distanceY; //Distância que iremos tomar na hora de instanciar a próxima grama.
  private bool newLine = true; //Para definir quando pular uma linha
  void Start()
  {
    distanceX = prefabGrass.GetComponent<SpriteRenderer>().bounds.size.x;
    distanceY = prefabGrass.GetComponent<SpriteRenderer>().bounds.size.y;

    for (int i = 0; i < 45; i++)
    {
      if (i % 9 == 0 && i != 0)
      {
        newLine = true;
        currentY = grass.transform.position.y - distanceY;
      }
      if (newLine)
      {
        newLine = false;
        grass = Instantiate(prefabGrass, new Vector2(-4.82f, currentY), Quaternion.identity) as GameObject;

      }
      else
      {
        newLine = false;
        grass = Instantiate(prefabGrass, new Vector2(currentX, currentY), Quaternion.identity) as GameObject;
      }

      currentX = grass.transform.position.x + distanceX;
      grass.transform.SetParent(transform);


    }


  }


}
