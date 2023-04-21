using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word {
    
    public string word;
    private int typeIndex;

    public WordDisplay display;
    
    public Word(string word, WordDisplay display) {
        this.word = word;
        this.typeIndex = 0;
        this.display = display;
        this.display.SetWord(this.word);
    }

    public char GetNextLetter() {
        return word[typeIndex];
    }

    public void TypeLetter() {
        typeIndex++;
        display.RemoveLetter();
    }

    public bool WordTyped() {
        bool isWordTyped = (typeIndex >= word.Length);
        if (isWordTyped) {
            display.RemoveWord();
        }
        return isWordTyped;
    }

}
