using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class InitialFileCheckManager : MonoBehaviour {
    string device;
    string filename;
    string path;
    [SerializeField]
    private string sceneToLoad;
    [SerializeField]
    private GameObject ageVerif;
    [SerializeField]
    private GameObject sorryMessage;
    [SerializeField]
    private GameObject splashObj;
    
    [SerializeField]
    private GameObject ageVerifiPad;
    [SerializeField]
    private GameObject sorryMessageiPad;
    [SerializeField]
    private GameObject splashObjiPad;

    public void WriteToFile(string str) {
        File.WriteAllText(path, str);
    }

    public void LaunchNextScene()
    {
        if(device == "phone")
        {
            ageVerif.SetActive(false);
            //splashObj.SetActive(true);
        } else
        {
            ageVerifiPad.SetActive(false);
            //splashObjiPad.SetActive(true);
        }
        
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }

    public void ShowSorryMessage(bool b) {
        if(device == "phone")
        {
            ageVerif.SetActive(!b);
            sorryMessage.SetActive(b);
        } else
        {
            ageVerifiPad.SetActive(!b);
            sorryMessageiPad.SetActive(b);
        }
        
    }

    public void ShowAgeVerif(bool b)
    {
        if (device == "phone")
        {
            ageVerif.SetActive(b);
            sorryMessage.SetActive(!b);
        }
        else
        {
            ageVerifiPad.SetActive(b);
            sorryMessageiPad.SetActive(!b);
        }
        
    }
    // Use this for initialization
    void Start() {
        if (Screen.width <= 1440)
        {
            device = "phone";
            ageVerif.SetActive(false);
            splashObj.SetActive(false);
        } else
        {
            device = "tablet";
            ageVerifiPad.SetActive(false);
            splashObjiPad.SetActive(false);
        }
        
        filename = "ageCheck.txt";
        path = Application.persistentDataPath + "/" + filename;
        
        if (File.Exists(path))
        {
            print("file already exists on hdd");
            string buff = File.ReadAllText(path);
            if(buff == "1")
            {
             //   splashObj.SetActive(true);
                SceneManager.LoadScene("SceneVideo",LoadSceneMode.Single);
            } else
            {
                if (device == "phone")
                {
                    splashObj.SetActive(false);
                    ageVerif.SetActive(true);
                }
                else
                {
                    splashObjiPad.SetActive(false);
                    ageVerifiPad.SetActive(true);
                }
            }
        } else
        {
            //Directory.CreateDirectory(Application.persistentDataPath + "/Documents");
            File.OpenWrite(path);
            if (device == "phone")
            {
                splashObj.SetActive(false);
                ageVerif.SetActive(true);
            }
            else
            {
                splashObjiPad.SetActive(false);
                ageVerifiPad.SetActive(true);
            }
            

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
