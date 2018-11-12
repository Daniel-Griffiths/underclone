using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class TextWritter : MonoBehaviour
{

    private float delay = .05f;
    public string text;
    private string currentText = "";

    // Use this for initialization
    void Start()
    {
        this.text = GetComponent<TextMeshPro>().text;
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < text.Length; i++) {
            currentText = text.Substring(0, i+1);
            this.GetComponent<TextMeshPro>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
