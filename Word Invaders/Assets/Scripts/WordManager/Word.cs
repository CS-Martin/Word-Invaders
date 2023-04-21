using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word {
    
    public string word;
    private int typeIndex;
    public CursedWord cursedWord;
    
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
        if (isWordTyped) {
            // cursedObject.RemoveWord();
        }
        return isWordTyped;
    }

    public void SetWordToActive() {
        cursedWord.DeactivateIsTrigger();
    }

}
