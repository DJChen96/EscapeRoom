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
        keywords.Add("thunder", () => { Debug.Log("Thunder"); });
        keywords.Add("ice", () => { Debug.Log("Ice"); });
        keywords.Add("magic mirror on the wall", () => { Debug.Log("magic mirror on the wall"); });
        keywords.Add("who is the fairest one of all?", () => { Debug.Log("who is the fairest one of all?"); });
        keywords.Add("Avada Kedavra", () => { Debug.Log("Avada Kedavra");});
        keywords.Add("Expecto patronum", () => { Debug.Log("Expecto patronum");});
        keywords.Add("Expelliarmus", () => { Debug.Log("Expelliarmus"); });
        

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
