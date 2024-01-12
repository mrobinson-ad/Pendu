using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LetterClick : MonoBehaviour
{
    public char letterGuess; // The letter the player pressed
    public string WordToDisplay; // The current state of the word to be displayed

    [SerializeField] WrongGuess flower;

    [SerializeField] GameManager gameManager;

    [SerializeField] AudioClip fail;

    [SerializeField] Slider volumeSlider;

    [SerializeField] AudioClip success;

    [SerializeField] AudioClip hover;
    private AudioSource source;

    Button button;

    public char[] Hidden; // Array representing the displayed word with underscores and guessed letters

    [SerializeField]
    private TextMeshProUGUI wordDisplay; 
    void Start()
    {
        source = gameObject.GetComponent<AudioSource> ();
        // Initialize the 'Hidden' array with the characters from the displayed word
        if (GameManager.hiddenWord != null)
        {
            // Set Hidden to the currently displayed hidden word
            Hidden = wordDisplay.text.ToCharArray();
        }

        // Fetch the pressed button corresponding letter
        string buttonName = gameObject.name;
        letterGuess = buttonName[0];
        button = GetComponent<Button>();
    }

    public void OnButtonClick()
    {
        
        Hidden = wordDisplay.text.ToCharArray();

        if (GameManager.wordToGuess.Contains(letterGuess)){
        // Iterate through each character in the wordToGuess
        source.clip = success;
        source.volume = volumeSlider.value*2f;
        source.Play();
         GetComponent<Image>().color = new Color32(0,255,60,255);
        for (int i = 0; i < GameManager.wordToGuess.Length; i++)
        {
            // Check if the guessed letter matches the current letter in wordToGuess
            if (GameManager.wordToGuess[i] == letterGuess)
            {
               
                // Update the Hidden array with the guessed letter at the correct position
                Hidden[i] = letterGuess;

            }
        }
        }
        else 
        {
            source.clip = fail;
            source.volume = volumeSlider.value*2f;
            source.Play();
            GetComponent<Image>().color = new Color32(255,50,0,255);
            flower.lives -= 1;
            flower.PetalFall();
        }
        

        UpdateWordDisplay();

        Debug.Log("You pressed " + letterGuess);
    }

    private void UpdateWordDisplay()
    {
        // Create a new string from the modified Hidden array
        WordToDisplay = new string(Hidden);
        // Display the word on the UI
        wordDisplay.text = WordToDisplay;
        if (WordToDisplay == GameManager.wordToGuess)
        {
            gameManager.Invoke("Win", 1);
        }

    }

    public void ResetLetter()
    {
        GetComponent<Image>().color = new Color32(255,255,255,255);
        button.interactable = true;
        source.clip = hover;
        source.volume = volumeSlider.value;
    }

}