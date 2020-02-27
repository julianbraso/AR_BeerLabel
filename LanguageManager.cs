using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour {

    //public Text[] textToChange;

    // Use this for initialization
    void Start()
    {

        var a = Resources.FindObjectsOfTypeAll(typeof(MultiLanguage));
        var b = Resources.FindObjectsOfTypeAll(typeof(MultiLanguageAsset));
        var c = Resources.FindObjectsOfTypeAll(typeof(MultiLanguageAudio));
        var d = Resources.FindObjectsOfTypeAll(typeof(MultiLanguageShare));

        var lang = Application.systemLanguage;

        foreach (MultiLanguage m in a)
        {
            m.SetLanguage(lang);
        }
        foreach (MultiLanguageAsset ma in b)
        {
            ma.SetLanguage(lang);
        }
        foreach (MultiLanguageAudio _a in c)
        {
            _a.SetLanguage(lang);
        }
        foreach (MultiLanguageShare _s in d)
        {
            _s.SetLanguage(lang);
        }
        return;
    }	
	// Update is called once per frame
	void Update () {
		
	}
}
