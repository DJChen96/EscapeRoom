using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class Recognizer : MonoBehaviour {

    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
	// Use this for initialization
	void Start () {
        keywords.Add("fire", () => { Debug.Log("Fire"); });
        keywords.Add("water", () => { Debug.Log("Water"); });
        keywords.Add("growth", () => { Debug.Log("Growth"); });
        keywords.Add("time stop", () => { Debug.Log("Time stop"); });
        keywords.Add("time start", () => { Debug.Log("Time start"); });
        keywords.Add("magic mirror on the wall", () => { Debug.Log("magic mirror on the wall"); });
        keywords.Add("mirror mirror on the wall", () => { Debug.Log("magic mirror on the wall"); });

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}
