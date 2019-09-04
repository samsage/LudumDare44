using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopButton : MonoBehaviour
{
  public ObjectPlacer m_objectPlacer;

  public ShopItem m_item;

  public TMP_Text m_title;
  public TMP_Text m_description;
  public TMP_Text m_cost;

  private void Start()
  {
    m_title.text = m_item.m_name;
    m_description.text = m_item.m_description;
    m_cost.text = m_item.m_cost.ToString();
  }

  private void OnMouseDown()
  {
    StartCoroutine(m_objectPlacer.PlaceObject(m_item.m_prefab));
  }

  private void OnMouseEnter()
  {
    GetComponent<SpriteRenderer>().color = Color.red;
  }

  private void OnMouseExit()
  {
    GetComponent<SpriteRenderer>().color = Color.white;
  }
}
