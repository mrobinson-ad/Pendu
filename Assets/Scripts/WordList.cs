using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using WordSet;

public class WordList : MonoBehaviour
{
    private List<string> english = new List<string>();
    private List<string> french = new List<string>();
    private List<string> spanish = new List<string>();

    [SerializeField]
    string language;

    [SerializeField]
    private Toggle en_toggle;
    [SerializeField]
    private Toggle es_toggle;

    [SerializeField]
    private Toggle fr_toggle;
    void Awake()
    {
        FillList();
    }

    void FillList()
    {
        // Assuming you have a WordSetting class
        WordsSetting English = new WordsSetting("English", english);

        // Fill English list with words containing at least 5 characters
        AddWordsToUpper(english,
        "APPLE", "BANANA", "ORANGE", "ELEPHANT", "GUITAR",
        "TABLE", "MOUNTAIN", "RIVER", "JACKET", "COMPUTER",
        "HAPPY", "FLOWER", "SUNSET", "OCEAN", "ELEVEN",
        "TWELVE", "NINETY", "TIGER", "LION", "PIANO",
        "VIOLIN", "LIBRARY", "GRAPE", "BICYCLE", "ZEBRA",
        "JOURNEY", "ROCKET", "LANTERN", "WISDOM", "TEACHER",
        "DOCTOR", "UNIVERSE", "HORIZON", "GLASSES", "FESTIVAL",
        "TOMORROW", "BEAUTY", "JUSTICE", "WISDOM", "HARMONY",
        "COWBOY", "DRAGON", "BUTTERFLY", "SPACESHIP", "RAINBOW",
        "ADVENTURE", "MYSTERY", "FANTASY", "SILENCE", "VICTORY",
        "DREAM", "LEGEND", "COURAGE", "HONESTY", "INFINITY",
        "GALAXY", "SERENITY", "CAPTAIN", "JOURNEY", "DESTINY",
        "WONDER", "FANTASTIC", "INSPIRE", "LEGACY", "PASSION",
        "MAGICAL", "ETERNAL", "ENCHANT", "CELESTIAL", "HERO",
        "LEGACY", "DESTINY", "ACHIEVE", "SERENADE", "RAPTURE",
        "VICTORY", "PARADISE", "ECLIPSE", "MAJESTY", "ILLUMINATE",
        "EXCELLENCE", "EUPHORIA", "GLORIOUS", "RESILIENT", "TRIUMPH",
        "ETHEREAL", "ENTHRALL", "RADIANCE", "TRANQUIL", "VIVID",
        "MYSTIFY", "PRODIGY", "EXUBERANT", "INGENIOUS", "JUBILANT",
        "NOURISH", "QUIESCENT", "UTOPIA", "ZESTFUL", "ZEPHYR");

        // Similarly, you can add words to the French and Spanish lists
        WordsSetting French = new WordsSetting("French", french);
        AddWordsToUpper(french,
        "POMME", "BANANE", "ORANGE", "ELEPHANT", "GUITARE",
        "TABLE", "MONTAGNE", "RIVIERE", "VEST", "ORDINATEUR",
        "HEUREUX", "FLEUR", "CIEL", "OCEAN", "ONZE",
        "DOUZE", "QUATRE-VINGT-DIX", "TIGRE", "LION", "PIANO",
        "VIOLON", "BIBLIOTHEQUE", "RAISIN", "BICYCLETTE", "ZEBRE",
        "VOYAGE", "FUSEE", "LANTERNE", "SAGESSE", "MAITRE",
        "DOCTEUR", "UNIVERS", "HORIZON", "LUNETTES", "FESTIVAL",
        "DEMAIN", "BEAUTE", "JUSTICE", "SAGESSE", "HARMONIE",
        "COW-BOY", "DRAGON", "PAPILLON", "VAISSEAU SPATIAL", "ARC-EN-CIEL",
        "AVENTURE", "MYSTERE", "FANTAISIE", "SILENCE", "VICTOIRE",
        "REVE", "LEGENDE", "COURAGE", "HONNETETE", "INFINI",
        "GALAXIE", "SERENITE", "CAPITAINE", "VOYAGE", "DESTIN",
        "ETONNEMENT", "FANTASTIQUE", "INSPIRER", "HERITAGE", "PASSION",
        "MAGIQUE", "ETERNEL", "ENCHANTEMENT", "CELESTE", "HEROS",
        "HERITAGE", "DESTIN", "REUSSIR", "SERENADE", "EXTASE",
        "VICTOIRE", "PARADIS", "ECLIPSE", "MAJESTE", "ILLUMINER",
        "EXCELLENCE", "EUPHORIE", "GLORIEUX", "RESILIENT", "TRIOMPHE",
        "ETHEREE", "ENTHOUSIASMER", "RADIANCE", "TRANQUILLE", "VIVID",
        "MYSTIFIER", "PRODIGE", "EXUBERANT", "INGENIEUX", "JUBILANT",
        "NOURRIR", "QUIESCENT", "UTOPIE", "ZESTE", "ZEPHYR");

        WordsSetting Spanish = new WordsSetting("Spanish", spanish);
        AddWordsToUpper(spanish,
        "MANZANA", "PLATANO", "NARANJA", "ELEFANTE", "GUITARRA",
        "MESA", "MONTANA", "RIO", "CHAQUETA", "COMPUTADORA",
        "FELIZ", "FLOR", "ATARDECER", "OCEANO", "ONCE",
        "DOCE", "NOVENTA", "TIGRE", "LEON", "PIANO",
        "VIOLIN", "BIBLIOTECA", "UVA", "BICICLETA", "CEBRA",
        "VIAJE", "COHETE", "LINTERNA", "SABIDURIA", "MAESTRO",
        "DOCTOR", "UNIVERSO", "HORIZONTE", "GAFAS", "FESTIVAL",
        "MANANA", "BELLEZA", "JUSTICIA", "SABIDURIA", "ARMONIA",
        "VAQUERO", "DRAGON", "MARIPOSA", "NAVE ESPACIAL", "ARCO IRIS",
        "AVENTURA", "MISTERIO", "FANTASIA", "SILENCIO", "VICTORIA",
        "SUEÑO", "LEYENDA", "CORAJE", "HONESTIDAD", "INFINITO",
        "GALAXIA", "SERENIDAD", "CAPITAN", "JORNADA", "DESTINO",
        "MARAVILLA", "FANTASTICO", "INSPIRAR", "LEGADO", "PASION",
        "MAGICO", "ETERNO", "ENAMORAR", "CELESTIAL", "HEROE",
        "LEGADO", "DESTINO", "LOGRAR", "SERENATA", "EXTASIS",
        "VICTORIA", "PARAISO", "ECLIPSE", "MAJESTAD", "ILUMINAR",
        "EXCELENCIA", "EUPHORIA", "GLORIOSO", "RESILIENTE", "TRIUNFO",
        "ETEREO", "ENAMORAR", "RADIANCE", "TRANQUILO", "VIVID",
        "MISTIFICAR", "PRODIGIO", "EXUBERANTE", "INGENIOSO", "JUBILANTE",
        "NUTRIR", "QUIESCENTE", "UTOPIA", "ZESTFUL", "ZEFIRO");
    }

        // Helper function to add words to a list and convert them to uppercase
    private void AddWordsToUpper(List<string> list, params string[] words)
    {
        foreach (string word in words)
        {
            // Remove accents and "-" characters
            string cleanedWord = RemoveAccentsAndHyphens(word);
            list.Add(cleanedWord.ToUpper());
        }
    }

    // Function to remove accents and "-" characters from a string
    private string RemoveAccentsAndHyphens(string input)
    {
        string normalizedString = input.Normalize(NormalizationForm.FormD);
        StringBuilder stringBuilder = new StringBuilder();

        foreach (char c in normalizedString)
        {
            UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark && c != '-')
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }

    // Function to get a random word in the list corresponding to the selected language
    public string GetWord(){
           
            string setting;
            int index = Random.Range(0, 100);
            if (language == "spanish"){
            setting = this.spanish[index];            
            return setting;
            } else if (language == "english"){
            setting = this.english[index];            
            return setting;
            } else if (language == "french"){
            setting = this.french[index];            
            return setting;
            } else {
            setting = this.english[index];            
            return setting;
            }
        }

    public void SetLanguage(){
        if (en_toggle.isOn == true)
        {
            language = "english";
        } if (fr_toggle.isOn == true)
        {
            language = "french";
        } if (es_toggle.isOn == true)
        {
            language = "spanish";
        }
    } 
}