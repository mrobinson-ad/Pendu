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
   private Keyboard keyboard;

   [SerializeField] 
   private Canvas loseScreen;

   [SerializeField] 
   private ParticleSystem conffettiRight;

   [SerializeField] 
   private ParticleSystem conffettiLeft;

    [SerializeField] 
   private ParticleSystem rain;

   [SerializeField] 
   private Canvas winScreen;

    [SerializeField]
    private TextMeshProUGUI wordDisplay ;

    [SerializeField]
    private TextMeshProUGUI wordDev ;

     public static GameManager instance;
    void Start()
    {
        wordList = FindObjectOfType<WordList>();

        instance = this;

        DisplayWord();

        petals = FindObjectsOfType<Petal>();
        letters = FindObjectsOfType<LetterClick>();
        bgm = gameObject.GetComponent<AudioSource> ();
        foreach (LetterClick letter in letters)
            {
                letter.ResetLetter();
            }
    }

    public void DisplayWord() // Creates hiddenWord string with "_" corresponding to the amount of letters in the word to guess
    {
        hiddenWord = "";
         wordToGuess = wordList.GetWord();
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            hiddenWord = hiddenWord + "_";
        }
        wordDev.text = "The word is " + wordToGuess;
        Debug.Log(hiddenWord);
        Debug.Log(wordToGuess);
        instance.wordDisplay.text = hiddenWord;
    }

    public void DisplayOnlineWord() // Same as DisplayWord but takes the online word
    {

        if (wordList.GetOnlineWord() != null){
        hiddenWord = "";
         wordToGuess = wordList.GetOnlineWord();
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            hiddenWord = hiddenWord + "_";
        }
        wordDev.text = "The word is " + wordToGuess;
        Debug.Log(hiddenWord);
        Debug.Log(wordToGuess);
        instance.wordDisplay.text = hiddenWord;
        } else {
            DisplayWord();
        }
    }

    public void Reset() //resets the flower and keyboard, stops the particles and restarts the music if called after a game over state
    {
        foreach (Petal petal in petals)
        {

            petal.ResetPetal();
            flower.lives = 7;
        }

        keyboard.KeyboardOn();

        foreach (LetterClick letter in letters)
        {

            letter.ResetLetter();
        }
        winScreen.enabled = false;
        winMusic.Stop();
        loseScreen.enabled = false;
        loseMusic.Stop();
        conffettiLeft.Stop(true,ParticleSystemStopBehavior.StopEmittingAndClear);
        conffettiRight.Stop(true,ParticleSystemStopBehavior.StopEmittingAndClear);
        if (bgm.isPlaying != true)
        {
           bgm.Play(); 
        }    
        rain.Stop(true,ParticleSystemStopBehavior.StopEmittingAndClear);

        DisplayWord();
    }

    public void Win() // shows the win screen and conffetti particles along with the win music
    {
        instance.winScreen.enabled = true;
        winMusic.Play();
        bgm.Stop();
        conffettiLeft.Play();
        conffettiRight.Play();
        keyboard.KeyboardOff();
    }

    public void Lose() // shows the lose screen and rain particles along with the lose music
    {
        instance.loseScreen.enabled = true;
        loseMusic.Play();
        bgm.Stop();
        rain.Play();
        keyboard.KeyboardOff();
    }
    
}
