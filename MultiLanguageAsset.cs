using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiLanguageAsset : MonoBehaviour {

    Image imageToChange;

    public Sprite spanishSprite;
    public Sprite englishSprite; 

    public void SetLanguage(SystemLanguage lang)
    {

        imageToChange = GetComponent<Image>();
        if (!imageToChange)
        {
            Debug.Log("Error multilangasset");
            return;
        }

        switch (lang)
        {
            case SystemLanguage.Spanish:
                imageToChange.sprite = spanishSprite;
                break;
            case SystemLanguage.English:
                imageToChange.sprite = englishSprite;
                break;
        }
    }
}
