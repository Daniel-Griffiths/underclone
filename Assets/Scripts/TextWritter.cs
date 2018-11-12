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

    // Use this for initialization
    void Start()
    {
        this.voice = GetComponent<AudioSource>();
        this.text = GetComponent<TextMeshPro>().text;
        StartCoroutine(ShowText());
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
        Regex r = new Regex("^[a-zA-Z0-9]*$");
        if (this.voice && r.IsMatch(currentLetter)) {
            this.voice.Play();
        }
    }
}
