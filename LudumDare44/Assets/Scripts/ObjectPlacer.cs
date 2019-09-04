using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObjectPlacer : MonoBehaviour
{
  public Tilemap m_groundTileMap;
  public Vector2 m_gridMin;
  public Vector2 m_gridMax;

  public Tile m_activeTile;
  public Tile m_inactiveTile;
  public Tile m_filledTile;

  private bool m_mousePressed;
  
  public IEnumerator PlaceObject(GameObject prefab)
  {
    bool result = false;

    yield return new WaitForSeconds(.2f);

    while(result == false)
    {
      print("In Loop");

      if(m_mousePressed)
      {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPos = m_groundTileMap.WorldToCell(mousePos);
        print(gridPos);

        if(m_groundTileMap.GetTile(gridPos) == m_activeTile)
        {
          print("Tile Good");
          PlacePrefab(gridPos, prefab);
          UpdateAdjacentTiles(gridPos, prefab);
          result = true;
        }
        else if (m_groundTileMap.GetTile(gridPos) == m_inactiveTile)
        {
          print("Tile Bad");
        }
        else if (m_groundTileMap.GetTile(gridPos) == m_filledTile)
        {
          print("Tile Filled");
        }
      }

      yield return new WaitForEndOfFrame();
    }

  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(0))
      m_mousePressed = true;
    else
      m_mousePressed = false;
  }

  private void PlacePrefab(Vector3Int gridPos, GameObject prefab)
  {
    GameObject newObject = Instantiate(prefab);

    newObject.transform.position = m_groundTileMap.GetCellCenterWorld(gridPos);
  }

  private void UpdateAdjacentTiles(Vector3Int gridPos, GameObject prefab)
  {
    Vector3Int[] adjacents = new Vector3Int[4];
      
    adjacents[0] =  gridPos + Vector3Int.left;
    adjacents[1] = gridPos + Vector3Int.right;
    adjacents[2] = gridPos + Vector3Int.up;
    adjacents[3] = gridPos + Vector3Int.down;

    foreach(Vector3Int vec in adjacents)
    {
      if(vec.x >= m_gridMin.x && vec.y >= m_gridMin.y && vec.x <= m_gridMax.x && vec.y <= m_gridMax.y)
      {
        m_groundTileMap.SetTile(vec, m_activeTile);
      }
    }
  }
}
