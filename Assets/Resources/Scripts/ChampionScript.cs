using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionScript : MonoBehaviour
{
  private Animator anim;
  public bool isMultiply;
  public GameObject prefabChampion;
  public GameObject prefabHit;
  private float distance;

  // Start is called before the first frame update
  void Start()
  {
    anim = prefabChampion.GetComponent<Animator>();
    if (isMultiply)
    {
      InvokeRepeating("Shoot", 0f, 1.5f);
      InvokeRepeating("Shoot", 0.2f, 1.5f);
    }
    if (!isMultiply)
    {
      InvokeRepeating("Shoot", 0f, 2f);
    }

    distance = 6.0f - transform.position.x;
  }

  void Shoot()
  {
    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, distance, LayerMask.GetMask("Enemies"));
    if (hit.collider != null)
    {
      anim.SetBool("isShooting", true);
      Instantiate(prefabHit, transform.position, Quaternion.identity);
    }
    else
    {
      anim.SetBool("isShooting", false);
    }

  }
}
