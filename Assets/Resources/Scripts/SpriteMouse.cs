using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMouse : MonoBehaviour
{
  void Start()
  {
    //QUANDO CLICA NA PA
    if (GameManager.currentChampion == null)
    {
      GetComponent<SpriteRenderer>().sprite = Resources.Load("Sprites/General/X", typeof(Sprite)) as Sprite;
    }
    //QUANDO CLICA NO CAMPEAO
    else
    {
      GetComponent<SpriteRenderer>().sprite = GameManager.currentChampion.GetComponent<SpriteRenderer>().sprite;
    }

  }


  void Update()
  {
    var mouseP = Input.mousePosition;
    mouseP.z = transform.position.z - Camera.main.transform.position.z; //reolver o problema no eixo z
    transform.position = Camera.main.ScreenToWorldPoint(mouseP);

    //destruir quando a pá for desativada e quando plantar o srite desaparece.
    if (GameManager.currentChampion == null && !GameManager.shovelEnabled)
    {
      Destroy(gameObject);
    }
  }
}
