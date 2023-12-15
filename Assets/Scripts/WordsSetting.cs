using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace WordSet
{
    public struct WordsSetting 
    {
        public string Language {get; set;}
        public List<string> Words {get; set;} 

        public WordsSetting (string language, List<string> words) // Constructor variable declaration structure
        {
            this.Language = language;
            this.Words = words;
        }
    }
}
