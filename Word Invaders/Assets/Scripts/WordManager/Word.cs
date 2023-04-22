using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word {
    
    public string word;
    public CursedWord cursedWord;
    private int typeIndex;
    
    public Word(string word, CursedWord cursedWord) {
        this.word = word;
        this.typeIndex = 0;
        this.cursedWord = cursedWord;
        this.cursedWord.SetWord(this.word);
    }

    public char GetNextLetter() {
        return word[typeIndex];
    }

    public void TypeLetter() {
        typeIndex++;
        cursedWord.RemoveLetter();
    }

    public bool WordTyped() {
        bool isWordTyped = (typeIndex >= word.Length);
        return isWordTyped;
    }

    public void SetWordToActive() {
        cursedWord.DeactivateIsTrigger();
    }

}
