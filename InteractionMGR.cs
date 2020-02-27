using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractionMGR : MonoBehaviour {

    //public MicrophoneInput micRef;
    public Text textObj;
   // public Text blowTextObj;
    public GameObject blowMsgObj;
    public GameObject blowMsgObjiPad;
    public float interactionThreshold;
    //public MicrophoneInput micRef;
    AnimManager animMGR;
    public TagManager tagMgr;
    public bool active = false;
    bool started = false;
    public AudioSource windSound;
    public CameraSettings camSettings;
    //public AudioSource micSource;
    bool animStarted;

    [SerializeField]
    private GameObject instructionsObj;
    [SerializeField]
    private GameObject instructionsObjiPad;
    [SerializeField]
    private GameObject hudCanvas;
    [SerializeField]
    private GameObject hudCanvasiPad;
    [SerializeField]
    private GameObject infoCanvas;
    [SerializeField]
    private GameObject infoCanvasiPad;
    [SerializeField]
    private GameObject finishCanvasTag1;
    [SerializeField]
    private GameObject finishCanvasTag2;
    [SerializeField]
    private GameObject finishCanvasTag3;
    [SerializeField]
    private GameObject finishCanvasiPad;
    [SerializeField]
    private GameObject interactBtn;
    [SerializeField]
    private GameObject interactBtniPad;

    string device;

    bool ready = false;
    bool _c = false;
    bool _b = false;

    public bool bResponsive = false;
    public bool bStart = false;

    bool bFlash = false;

    public bool finished = false;

    IEnumerator coroutine()
    {
        yield return new WaitForSeconds(0.0f);
        animStarted = true;
        //animMGR.play();
    }

    public void DisableInteractBtn(bool b)
    {
        if (device == "phone")
        {
            interactBtn.SetActive(!b);
        } else
        {
            interactBtniPad.SetActive(!b);
        }
        camSettings.EnableDisableTracker(!b);
    }

    public void Restart()
    {
        ready = false;
        active = false;
        _c = false;
        _b = false;
        animStarted = false;
        started = false;
        if (tagMgr)
        {
            if (tagMgr.currentAnimMgr)
            {
                tagMgr.currentAnimMgr.Stop();
                tagMgr.currentAnimMgr.Restart();
            }
        }
    }

    public void HideInstructions(bool b)
    {
        if (device == "phone")
        {
            instructionsObj.SetActive(!b);
            hudCanvas.SetActive(b);
        }
        else
        {
            instructionsObjiPad.SetActive(!b);
            hudCanvasiPad.SetActive(b);
        }
        
    }

    public void EnableAnim()
    {
        if (tagMgr)
        {
            if (tagMgr.currentAnimMgr)
            {
                tagMgr.currentAnimMgr.SetMediaPlayerOnOff(true);
            }
        }
    }

    public void LoadScene()
    {
        SceneManager.UnloadSceneAsync("SceneVideo");
        SceneManager.LoadScene("SceneAgeVerification", LoadSceneMode.Single);   
    }

    public void ShowInfo(bool b)
    {
        if (!finished)
        {
            if (!started)
            {
                if (b)
                {
                    if (tagMgr)
                    {
                        if (tagMgr.currentAnimMgr)
                        {
                            tagMgr.currentAnimMgr.pause();
                        }
                    }
                }
                else
                {
                    if (tagMgr)
                    {
                        if (tagMgr.currentAnimMgr)
                        {
                            tagMgr.currentAnimMgr.play();
                        }
                    }
                }
                if (device == "phone")
                {
                    hudCanvas.SetActive(!b);
                    infoCanvas.SetActive(b);
                }
                else
                {
                    hudCanvasiPad.SetActive(!b);
                    infoCanvasiPad.SetActive(b);
                }
            } else
            {
                if (b)
                {
                    if (tagMgr)
                    {
                        if (tagMgr.currentAnimMgr)
                        {
                            tagMgr.currentAnimMgr.pause();
                        }
                    }
                }
                else
                {
                    if (tagMgr)
                    {
                        if (tagMgr.currentAnimMgr)
                        {
                            tagMgr.currentAnimMgr.play();
                        }
                    }
                }
                if (device == "phone")
                {
                    hudCanvas.SetActive(!b);
                    infoCanvas.SetActive(b);
                }
                else
                {
                    hudCanvasiPad.SetActive(!b);
                    infoCanvasiPad.SetActive(b);
                }
            }
        } else
        {
            if (device == "phone")
            {
                if (tagMgr.currentTag == "Atotolin")                            /////para hacer esto mas generico y dinamico habria que declarar un array de int en el que se seleccione cuantos tag ahi, y asi en el codigo linkear eso
                {
                    finishCanvasTag1.SetActive(!b);
                }
                else if (tagMgr.currentTag == "Biguidibela")
                {
                    finishCanvasTag2.SetActive(!b);
                }
                else if (tagMgr.currentTag == "Kumukite")
                {
                    finishCanvasTag3.SetActive(!b);
                }
                infoCanvas.SetActive(b);
            }
            else
            {
                finishCanvasiPad.SetActive(!b);
                infoCanvasiPad.SetActive(b);
            }
            
        }
    }

    public void ShowInfoFinish(bool b)
    {
        if (device == "phone")
        {
            if (tagMgr.currentTag == "Atotolin")                            /////para hacer esto mas generico y dinamico habria que declarar un array de int en el que se seleccione cuantos tag ahi, y asi en el codigo linkear eso
            {
                finishCanvasTag1.SetActive(!b);
            }
            else if (tagMgr.currentTag == "Biguidibela")
            {
                finishCanvasTag2.SetActive(!b);
            }
            else if (tagMgr.currentTag == "Kumukite")
            {
                finishCanvasTag3.SetActive(!b);
            }
            //finishCanvas.SetActive(!b);
            infoCanvas.SetActive(b);
        }
        else
        {
            finishCanvasiPad.SetActive(!b);
            infoCanvasiPad.SetActive(b);
        }
        
    }

    public void ShowFinish(bool b)
    {
        
        if (device == "phone")
        {
            hudCanvas.SetActive(!b);
            if (tagMgr.currentTag == "Atotolin")                            /////para hacer esto mas generico y dinamico habria que declarar un array de int en el que se seleccione cuantos tag ahi, y asi en el codigo linkear eso
            {
                finishCanvasTag1.SetActive(b);
            } else if (tagMgr.currentTag == "Biguidibela")
            {
                finishCanvasTag2.SetActive(b);
            }
            else if (tagMgr.currentTag == "Kumukite")
            {
                finishCanvasTag3.SetActive(b);
            }
            else
            {
                hudCanvas.SetActive(b);
            }
        }
        else
        {
            hudCanvasiPad.SetActive(!b);
            finishCanvasiPad.SetActive(b);
        }
        
    }

    public void _SetActive(bool b)
    {
        sActive(b);
    }

    private void sActive(bool b)
    {
        active = b;
    }

    public void OpenSite()
    {
        Application.OpenURL("http://www.cervecerialoscuentos.com/");    ////http://www.theowlandthedustdevil.com/
    }
    public void OpenRetailers()
    {
        Application.OpenURL("");     ///http://www.theowlandthedustdevil.com/#stockists
    }

    void Start()
    {
        if (Screen.width > 1125 && bResponsive)
        {
            device = "tablet";
        } else
        {
            device = "phone";
        }
        if(device == "phone" && bStart)
        {
            instructionsObj.SetActive(true);
        } else if (device == "tablet" && bStart)
        {
            instructionsObjiPad.SetActive(true);
        }
        //animMGR.StartAnimation();
    }

    public void Tap()
    {
/*        bFlash = !bFlash;
        camSettings.TurnOnFlash(bFlash);*/
        if (active)
        {
            Action();
        }
    }

    void Action()
    {
        StartCoroutine(coroutine());
        if (tagMgr)
        {
            if (tagMgr.currentAnimMgr)
            {
                tagMgr.currentAnimMgr.PlayTransitionAnim();
            }
        }
        started = true;
        //blowTextObj.enabled = false;
        if (device == "phone")
        {
            blowMsgObj.SetActive(false);
        }
        else
        {
            blowMsgObjiPad.SetActive(false);
        }
        
        //micSource.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //textObj.text = micRef.loudness.ToString();
        if (active)
        {
           /* if (!started)
            {*/
                ready = true;
            //textObj.text = micRef.loudness.ToString();
            //blowTextObj.enabled = true;
            if (!started)
            {
                if (device == "phone")
                {
                    blowMsgObj.SetActive(true);
                }
                else
                {
                    blowMsgObjiPad.SetActive(true);
                }
            } else
            {
                if (device == "phone")
                {
                    blowMsgObj.SetActive(false);
                }
                else
                {
                    blowMsgObjiPad.SetActive(false);
                }
            }
                /*if (micRef.loudness > interactionThreshold)
                {
                    if (_c == false)
                    {
                        Action();
                        animStarted = true;
                        _c = true;
                    }
                }*/
            /*} else
            {*/
              
                //if (animStarted)
                //{
                   // animMGR.play();
                //}
            //}
        } else
        {
            //blowTextObj.enabled = false;
            if (tagMgr)
            {
                if (tagMgr.currentAnimMgr)
                {
                    tagMgr.currentAnimMgr.setAudioVolume(0.0f);
                }
            }

            if (device == "phone")
            {
                blowMsgObj.SetActive(false);
            }
            else
            {
                blowMsgObjiPad.SetActive(false);
            }
            
        }
    }
}
