using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phil : MonoBehaviour
{
  public int m_healthLostPerClick;
  public int m_powerGainedPerClick;


  private void OnMouseUpAsButton()
  {
    Stat.GetStat(Stat.Type.Health).m_curValue -= m_healthLostPerClick;
    Stat.GetStat(Stat.Type.Power).m_curValue += m_powerGainedPerClick;

  }
}
