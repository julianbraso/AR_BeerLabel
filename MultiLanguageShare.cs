using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiLanguageShare : MonoBehaviour {

    Share textToChange;

    [TextArea]
    public string textInSPANISH;
    [TextArea]
    public string textInENGLISH;
    
    public void SetLanguage(SystemLanguage lang)
    {
        textToChange = GetComponent<Share>();
        if (!textToChange)
        {
            Debug.Log("Error multilanguage");
            return;
        }

        switch (lang)
        {
            case SystemLanguage.Spanish:
                textInSPANISH = textInSPANISH.Replace("\\n", "\n");
                textToChange.message = textInSPANISH;
                break;
            case SystemLanguage.English:
                textInENGLISH = textInENGLISH.Replace("\\n", "\n");
                textToChange.message = textInENGLISH;
                break;
        }
    }

}
