using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
  [SerializeField]
  private GameObject keyboard;

  public void KeyboardOff()
  {
    keyboard.SetActive(false);
  }
  public void KeyboardOn()
  {
    keyboard.SetActive(true);
  }
}
