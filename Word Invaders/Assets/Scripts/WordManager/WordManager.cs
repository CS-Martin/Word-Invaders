using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {

    /// <Note> A list of words to keep track of
    public List<Word> words;

    /// <Note> A reference to the WordSpawner script
    public WordSpawner wordSpawner;

    /// <Note> A boolean flag to check if there is an active word being typed
    public bool hasActiveWord;

    /// <Note> The active word that the player is typing
    public Word activeWord;

    /// <Note> A reference to the ScoreDisplay script
    public ScoreDisplay scoreDisplay;

    /// <Note> A reference to the PlayerController script
    public PlayerController playerController;

    /// <Note> A reference to the Shooting script
    public Shooting shooting;

    /// <Brief> Find the player object and get the Shooting script attached to it
    void Start() {
        GameObject playerObject = GameObject.Find("Juan");
        shooting = playerObject.GetComponent<Shooting>();
    }

    void Update() {
        // Remove any words that have reached the bottom of the screen
        RemoveWordsNotTyped();

        // Check if the active word is still being typed
        IsActiveWordNotTyped();
    }

    public void AddWord() {
        // Generate a new word and spawn it
        Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());

        // Add the generated word to the list of words
        words.Add(word);
    }

    public void TypeLetter(char letter) {
        // Check if there is an active word being typed
        if (hasActiveWord) {
            // Call the WordTyped function in the PlayerController script
            playerController.WordTyped(activeWord);

            // If the letter typed matches the next letter in the active word, shoot a bullet and continue typing
            if (activeWord.GetNextLetter() == letter) {
                shooting.Shoot();
                activeWord.TypeLetter();
            }
        }
        else {
            // If there is no active word being typed, check if any of the existing words match the letter typed
            foreach(Word word in words) {
                if (word.GetNextLetter() == letter) {
                    // If a word matches, make it the active word and start typing it
                    activeWord = word;
                    hasActiveWord = true;
                    shooting.Shoot();
                    word.TypeLetter();
                    break;
                }
            }
        }

        // If the active word has been completely typed, remove it and update the score
        if (hasActiveWord && activeWord.WordTyped()) {
            RemoveActiveWord();
            scoreDisplay.UpdateScore();
        } 
    }

    public void IsActiveWordNotTyped() {
        // Check if there is an active word being typed
        if(hasActiveWord) {
            // If the active word has reached the bottom of the screen, remove it
            if(activeWord.display.text.transform.position.y <= -7.5) {
                Debug.Log("Active Word Removed");
                activeWord.display.RemoveWord();
                RemoveActiveWord();
            }
        }
    }

    public void RemoveWordsNotTyped() {
        // Keep track of the word to be removed
        Word wordToRemove = null;
        
        // Check if any of the existing words have reached the bottom of the screen
        foreach(Word word in words) {
            if(word.display.text.transform.position.y <= -7.5) {
                Debug.Log("Word Removed");
                word.display.RemoveWord();
                wordToRemove = word;
            }
        }

        // If a word has been found to be removed, remove it from the list of words
        if (wordToRemove != null)
            words.Remove(wordToRemove);
    }

    public void RemoveActiveWord() {
        hasActiveWord = false;
        words.Remove(activeWord);
    }
}
