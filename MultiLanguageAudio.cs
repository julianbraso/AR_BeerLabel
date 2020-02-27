using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLanguageAudio : MonoBehaviour {


    public void SetLanguage(SystemLanguage lang)
    {
        MediaPlayerCtrl mediaCtrl = GetComponent<MediaPlayerCtrl>();

        if (!mediaCtrl)
        {
            return;
        }

        switch (lang)
        {
            case SystemLanguage.Spanish:
                Debug.Log("<b>MultiLangAudio Spanish</b>");
                mediaCtrl.SetLangVar(0);
                //mediaCtrl.SwitchAudio();
                break;
            case SystemLanguage.English:
                Debug.Log("<b>MultiLangAudio English</b>");
                //mediaCtrl.SwitchAudio();
                mediaCtrl.SetLangVar(1);
                break;
        }

    }
}
