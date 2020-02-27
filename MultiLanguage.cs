using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiLanguage : MonoBehaviour {

    Text textToChange;

    [TextArea]
    public string textInSPANISH;
    [TextArea]
    public string textInENGLISH;
    
    public void SetLanguage(SystemLanguage lang)
    {
        textToChange = GetComponent<Text>();
        if (!textToChange)
        {
            Debug.Log("Error multilanguage");
            return;
        }

        switch (lang)
        {
            case SystemLanguage.Spanish:
                textInSPANISH = textInSPANISH.Replace("\\n", "\n");
                textToChange.text = textInSPANISH;
                break;
            case SystemLanguage.English:
                textInENGLISH = textInENGLISH.Replace("\\n", "\n");
                textToChange.text = textInENGLISH;
                break;
        }
    }

}
