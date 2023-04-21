using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBCursedWords : MonoBehaviour
{
    // Array of cursed words for endless battle
    private static string[] EBCursedWordsList = {
        "sample", "sample2", "sample3", "sample"
    };
    
    public static string EBGetRandomWord() {
        int randomIndex = Random.Range(0, EBCursedWordsList.Length);
        string randomWord = EBCursedWordsList[randomIndex];
        return randomWord;
    }
}
