using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour {
    
    // Array that contains all the cursed words
    private static string[] wordList = {
        "bribery", "fraud", "embezzlement", "nepotism", "collusion", "kickbacks", "extortion", "graft", "patronage", "payoffs", 
        "racketeering", "blackmail", "skimming", "favors", "bribes", "cronyism", "lobbying", "favoritism", "smuggling", "kleptocracy", 
        "oligarchy", "clientelism", "drugs", "debt"
    };
    
    // A function that will return a random word from wordList
    public static string GetRandomWord() {
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];
        return randomWord;
    }
}
