using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DevMode : MonoBehaviour
{

[SerializeField]
 TextMeshProUGUI devWord;

 string gameWord;
public void OnClick(){
if (!devWord.enabled){
gameWord = GameManager.wordToGuess;
devWord.enabled = true;
devWord.text = "The word is " +gameWord;
} else {
devWord.enabled = false;
}
}
}
