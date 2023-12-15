using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
   [SerializeField] 
   private Canvas settings;

   public void OnOff(){
    if (settings.enabled)   
        settings.enabled = false;
     else 
        settings.enabled = true;
     }
}
