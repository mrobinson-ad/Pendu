using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class GameManager : MonoBehaviour
{
   public static String wordToGuess;
   public static String hiddenWord; // Word to guess converted to "_"
   private WordList wordList;

   [SerializeField]
   private AudioSource winMusic;

   [SerializeField]
   private AudioSource loseMusic;

   private AudioSource bgm;

   [SerializeField] WrongGuess flower;

   private Petal[] petals;
   private LetterClick[] letters;

   [SerializeField] 
   private Canvas loseScreen;

   [SerializeField] 
   private Canvas winScreen;

    [SerializeField]
    private TextMeshProUGUI wordDisplay ;

     public static GameManager instance;
    void Start()
    {
        wordList = FindObjectOfType<WordList>();

        instance = this;

        DisplayWord();

        petals = FindObjectsOfType<Petal>();
        letters = FindObjectsOfType<LetterClick>();
        bgm = gameObject.GetComponent<AudioSource> ();
    }

    public void DisplayWord() // Creates hiddenWord string with "_" corresponding to the amount of letters in the word to guess
    {
        hiddenWord = "";
         wordToGuess = wordList.GetWord();
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            hiddenWord = hiddenWord + "_";
        }
        Debug.Log(hiddenWord);
        Debug.Log(wordToGuess);
        instance.wordDisplay.text = hiddenWord;
    }

    public void Reset()
    {
        foreach (Petal petal in petals)
        {

            petal.ResetPetal();
            flower.lives = 7;
        }

        foreach (LetterClick letter in letters)
        {

            letter.ResetLetter();
        }
        winScreen.enabled = false;
        winMusic.Stop();
        loseScreen.enabled = false;
        loseMusic.Stop();
        bgm.Play();
        DisplayWord();
    }

    public void Win()
    {
        instance.winScreen.enabled = true;
        winMusic.Play();
        bgm.Stop();
    }

    public void Lose()
    {
        instance.loseScreen.enabled = true;
        loseMusic.Play();
        bgm.Stop();
    }
    
}
