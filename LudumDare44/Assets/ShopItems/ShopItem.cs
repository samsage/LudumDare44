using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Item", menuName = "Shop Item")]
public class ShopItem : ScriptableObject
{
  public string m_name;
  public string m_description;
  public int m_cost;

  public GameObject m_prefab;
}
