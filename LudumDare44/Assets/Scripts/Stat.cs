using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
  // Static
  private static Stat m_powerStat;
  private static Stat m_healthStat;

  public static Stat GetStat(Type type)
  {
    if (type == Type.Health)
      return m_healthStat;
    else
      return m_powerStat;
  }

  // Types
  public enum Type
    {
        Health,
        Power
    }

  // Variables
  public Type m_type;
  [Range(0, 100)] public int m_maxValue;
  [Range(0, 100)] public int m_curValue;

  public LineRenderer m_borderLine;
  public LineRenderer m_maxLine;
  public LineRenderer m_currentLine;

  private float m_maxLineStart;
  private float m_maxLineEnd;

  // Scripts
  private void Start()
  {
    if (m_type == Type.Health)
      m_healthStat = this;
    else if (m_type == Type.Power)
      m_powerStat = this;

    m_maxLineStart = m_borderLine.GetPosition(0).x;
    m_maxLineEnd = m_borderLine.GetPosition(1).x;
  }

  private void Update()
  {
    ResizeLines(100);
  }

  private void ResizeLines(float trueMaxValue)
  {
    float maxLength = ((float)m_maxValue / trueMaxValue) * (m_maxLineEnd - m_maxLineStart);
    float curLength = ((float)m_curValue / trueMaxValue) * (m_maxLineEnd - m_maxLineStart);

    m_borderLine.SetPosition(1, new Vector3(maxLength, 0, 0));
    m_maxLine.SetPosition(1, new Vector3(maxLength, 0, 0));
    m_currentLine.SetPosition(1, new Vector3(curLength, 0, 0));
  }

}
