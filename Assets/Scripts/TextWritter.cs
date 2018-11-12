using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class TextWritter : MonoBehaviour
{

    private float delay = .05f;
    private string text;
    private string currentText = "";
    private AudioSource voice;
    private Regex regex;

    // Use this for initialization
    void Start()
    {
        this.regex = new Regex("^[a-zA-Z0-9]*$");
        this.voice = GetComponent<AudioSource>();
        this.text = GetComponent<TextMeshPro>().text;
        StartCoroutine(ShowText());
    }

    void OnEnable()
    {
        StartCoroutine(ShowText());
    }

    void OnDisable()
    {
        currentText = "";
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < text.Length; i++) {
            string currentLetter = text[i].ToString();
            this.SpeakText(currentLetter);
            this.GetComponent<TextMeshPro>().text = currentText += currentLetter;
            yield return new WaitForSeconds(delay);
        }
    }

    void SpeakText(string currentLetter)
    {
        if (this.voice && regex.IsMatch(currentLetter)) {
            this.voice.Play();
        }
    }
}
