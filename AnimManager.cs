using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimManager : MonoBehaviour {

    private MediaPlayerCtrl mediaPlayerRef;
    [SerializeField]
    private MediaPlayerCtrl loopPlayerRef;
    [SerializeField]
    private MediaPlayerCtrl transitionPlayerRef;
    [SerializeField]
    private string loopAnimName;
    [SerializeField]
    private string transitionAnimName;
    [SerializeField]
    private InteractionMGR interactRef;
    bool _b = false;
    bool _c = false;
    bool _d = false;
    bool _f = false;
    bool loop = false;
    bool main = false;
    bool transition=false;
    public float loopVolume;
    public float videoVolume;
    public bool isTracking = false;

    public MediaPlayerCtrl.VideoEnd OnEnd;

    private MediaPlayerCtrl.MEDIAPLAYER_STATE m_CurrentState;
    public Text textObj;

    [SerializeField]
    private AudioSource audioSource;
    private bool bEnd;

    public void VideoLoaded()
    {
        transitionPlayerRef.Pause();
        transitionPlayerRef.OnVideoFirstFrameReady -= VideoLoaded;
        transitionPlayerRef.enabled = false;
    }

    public void LoopVideoLoaded()
    {
        loopPlayerRef.Pause();
        loopPlayerRef.OnVideoFirstFrameReady -= LoopVideoLoaded;
        loopPlayerRef.enabled = false;
      /*  transitionPlayerRef.enabled = true;
        transitionPlayerRef.OnVideoFirstFrameReady += VideoLoaded;
        transitionPlayerRef.Stop();
        transitionPlayerRef.Load(transitionAnimName);
        transitionPlayerRef.Play();*/
    }

    IEnumerator coroutine()
    {
        yield return new WaitForSeconds(4.0f);
        _b = true;
    }

    IEnumerator coroutine2()
    {
        yield return new WaitForSeconds(0.01f);
        _b = true;
    }

    IEnumerator coroutine3(float f)
    {
        yield return new WaitForSeconds(f);
        _d = false;
    }

    IEnumerator videoCoroutine() {
        yield return new WaitForSeconds(1);
        //mediaPlayerRef.Pause();
        //   mediaPlayerRef.SetVolume(1f);
        //mediaPlayerRef.enabled = false;
        if (transitionPlayerRef.GetCurrentState() == MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING) {
            transitionPlayerRef.Pause();
            transitionPlayerRef.enabled = false;
        } else
        {
            StartCoroutine("videoCoroutine");
        }
    }

    IEnumerator loopAnimFunct()
    {
        while (mediaPlayerRef.m_strFileName == loopAnimName) { 
            
            if (mediaPlayerRef.GetSeekPosition() > (mediaPlayerRef.GetDuration() - 100))
            {
                mediaPlayerRef.Stop();
                mediaPlayerRef.Play();
            }
        }
            StopCoroutine("loopAnimFunct");
        yield return new WaitForSeconds(0); 
    }

    public void play()
    {
        if (mediaPlayerRef)
        {
            Debug.Log("Play function called! " + mediaPlayerRef.m_strFileName);
            mediaPlayerRef.Play();
        }
        if (audioSource)
        {
            if (transition && isTracking && !bEnd)
            {
                Debug.Log("SOUND Play function called!");
                audioSource.Play();
            }
        }
    }

    public void Restart()
    {
        _b = false;
        _c = false;
        mediaPlayerRef.m_strFileName = loopAnimName;
        mediaPlayerRef.Load(loopAnimName);
        loop = true;
        main = false;
        transition = false;
        audioSource.Stop();
    }

    public void pause()
    {
        if (mediaPlayerRef) {
            mediaPlayerRef.Pause();
        }
        if (audioSource)
        {
            audioSource.Pause();
        }

    }

    public void StartAnimation() {
      //mediaPlayerRef.m_strFileName = loopAnimName;
//      mediaPlayerRef.enabled = true;
        //mediaPlayerRef.m_bLoop = true;
        //mediaPlayerRef.Stop();
        //StartCoroutine(loopAnimFunct());
        loop = true;
        //loopPlayerRef.Play();
    }

    public void PlayTransitionAnim() {
        loopPlayerRef.Stop();/*
        mediaPlayerRef = transitionPlayerRef;
        loopPlayerRef.enabled = false;*/
       
        //transitionPlayerRef.enabled = true;
        loop = false;
        transition = true;
        //mediaPlayerRef.m_bLoop = false;
    }

    void Transition()
    {
        //loopPlayerRef.Stop();
        loopPlayerRef.Pause();
        mediaPlayerRef = transitionPlayerRef;
        mediaPlayerRef.enabled = true;
        mediaPlayerRef.Play();
        audioSource.Play();
        if (Application.platform == RuntimePlatform.Android)
        {
            loopPlayerRef.UnLoad();
        }
        loopPlayerRef.enabled = false;
        //mediaPlayerRef.m_bLoop = false;
        //mediaPlayerRef.m_bAutoPlay = true;
        //mediaPlayerRef.Stop();
        
        //mediaPlayerRef.Load(transitionAnimName);
        //mediaPlayerRef.m_strFileName = transitionAnimName;
        
        //mediaPlayerRef.Load(transitionAnimName);
       // mediaPlayerRef.Stop();
       // mediaPlayerRef.Play();
    }

    public void Stop()
    {
        mediaPlayerRef.Stop();
    }

    public void SetMediaPlayerOnOff(bool b)
    {
        if (!mediaPlayerRef)
        {
            return;
        }
        mediaPlayerRef.enabled = b;
    }

    // Use this for initialization
    void Start() {
        mediaPlayerRef = loopPlayerRef;
        mediaPlayerRef.enabled = true;
        loopPlayerRef.OnVideoFirstFrameReady += LoopVideoLoaded;
        mediaPlayerRef.Stop();
        mediaPlayerRef.Load(loopAnimName);
        if (mediaPlayerRef.m_bAutoPlay)
            mediaPlayerRef.Play();
        else
            mediaPlayerRef.Stop();
        // mediaPlayerRef.Play();
        //mediaPlayerRef.Stop();
        //mediaPlayerRef.SetVolume(0f);
        //loopPlayerRef.SetVolume(0f);
        transitionPlayerRef.enabled = true;
        //transitionPlayerRef.SetVolume(0f);
        //transitionPlayerRef.OnVideoFirstFrameReady = VideoLoaded;
        //transitionPlayerRef.Stop();
        transitionPlayerRef.Load(transitionAnimName);
        //transitionPlayerRef.Play();
//        transitionPlayerRef.Pause();
        //StartCoroutine("videoCoroutine");
        //transitionPlayerRef.Stop();
  //      transitionPlayerRef.enabled = false;
        //transitionPlayerRef.Stop();
        // mediaPlayerRef.enabled = false;
        StartAnimation();
        mediaPlayerRef.Pause();
        mediaPlayerRef.OnEnd += OnEnd;
        
        //textObj.enabled = false;
    }
	
    public void setAudioVolume(float f)
    {
        if (!mediaPlayerRef)
        {
            return;
        }
        mediaPlayerRef.SetVolume(f);
    }

    public void setVolumeAuto()
    {
        if (loop) { 
            mediaPlayerRef.SetVolume(loopVolume);
        } 
        if (transition)
        {
            mediaPlayerRef.SetVolume(videoVolume);
        }
    }

    // Update is called once per frame
    void Update () {
        /* if (Input.GetKey("f"))
         {
             PlayTransitionAnim();
         }
        */

        if (!isTracking)
        {
           
        }
            m_CurrentState = mediaPlayerRef.GetCurrentState();
        if (textObj)
        {

                //textObj.text = m_CurrentState.ToString() + " " + loop + " " + transition ;//m_CurrentState.ToString(); //mediaPlayerRef.GetSeekPosition().ToString()
                textObj.text = loopPlayerRef.GetCurrentState().ToString() + " loop: " +loopPlayerRef.enabled+" "+ loop + " / " + transitionPlayerRef.GetCurrentState().ToString() + " video: " + transitionPlayerRef.enabled + " "  + transition;//m_CurrentState.ToString(); //mediaPlayerRef.GetSeekPosition().ToString()
            
        }
        
        //print(m_CurrentState);
       // Debug.Log(m_CurrentState.ToString());
        if (loop)
        {
            if (!isTracking)
            {
                if (loopPlayerRef.GetCurrentState() == MediaPlayerCtrl.MEDIAPLAYER_STATE.END)
                {
                    loopPlayerRef.Stop();
                    //   mediaPlayerRef.SetVolume(1f);
                    loopPlayerRef.enabled = false;
                    //    transitionPlayerRef.Play();
                }

                if (transitionPlayerRef.GetCurrentState() == MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING)   //&& transitionPlayerRef.GetSeekPosition() >= 5
                {
                       transitionPlayerRef.Pause();
                    //   transitionPlayerRef.SetVolume(1f);
                   // transitionPlayerRef.enabled = false;
                }
                //loopPlayerRef.enabled = false;
                //transitionPlayerRef.enabled = false;
                return;
            }
            if (loopAnimName == "")
            {
                return;
            }

            if (!loopPlayerRef.enabled)
            {
                //loopPlayerRef.enabled = true;
            }

          /*  if (!_f)
            {
                transitionPlayerRef.enabled = true;
                //transitionPlayerRef.OnVideoFirstFrameReady += VideoLoaded;
                transitionPlayerRef.Load(transitionAnimName);
                transitionPlayerRef.Play();
                //StartCoroutine("videoCoroutine");
                //transitionPlayerRef.enabled = false;
                _f = true;
            }*/

            if (transitionPlayerRef.GetCurrentState() == MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING)
            {
                transitionPlayerRef.Pause();
                transitionPlayerRef.enabled = false;
            }
            //mediaPlayerRef.SetVolume(loopVolume);
            if (mediaPlayerRef.m_strFileName == loopAnimName)
            {
                if (mediaPlayerRef.GetCurrentState() != MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING)
                {
                    Debug.Log("Not playing...");
                    if (mediaPlayerRef.GetCurrentState() != MediaPlayerCtrl.MEDIAPLAYER_STATE.ERROR || mediaPlayerRef.GetCurrentState() != MediaPlayerCtrl.MEDIAPLAYER_STATE.NOT_READY || mediaPlayerRef.GetCurrentState() != MediaPlayerCtrl.MEDIAPLAYER_STATE.END)
                    {
                        mediaPlayerRef.Stop();
                        Debug.Log("LOOP: ERROREEEEEEEEEEEEED");
                    }
                    mediaPlayerRef.Stop();
                    mediaPlayerRef.Play();
                } else
                {
                    if (mediaPlayerRef.GetSeekPosition() == (mediaPlayerRef.GetDuration()))     //* -100 *//
                    {
                        //mediaPlayerRef.SeekTo(50);
                        mediaPlayerRef.Stop();
                        mediaPlayerRef.Play();
                    }
                }
            }

            //mediaPlayerRef.SetVolume(loopVolume);
            /*if (mediaPlayerRef.m_strFileName == loopAnimName)
            {
               /* if (mediaPlayerRef.GetSeekPosition() >= mediaPlayerRef.GetDuration()-10)     // -100 /
                {
                    //mediaPlayerRef.SeekTo(0);
                    //Debug.Log("Rebooted anim " + mediaPlayerRef.m_strFileName);
                    //mediaPlayerRef.Stop();
                    //mediaPlayerRef.Play();
                }*/
            /*  if (m_CurrentState != MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING)
              {
                  if (m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.END)
                  {
                      //_d = false;
                      if (!_d)
                      {
                          Debug.Log("End of movie reached");
                          mediaPlayerRef.Stop();
                          //mediaPlayerRef.Load(loopAnimName);
                          //mediaPlayerRef.SeekTo(0);
                          mediaPlayerRef.Play();
                          _d = true;
                          //StartCoroutine(coroutine3(3.0f));
                      }
                  }
                  else if (m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.READY)
                  {
                      if (isTracking)
                      {
                          mediaPlayerRef.Play();
                      }
                      // mediaPlayerRef.Play();
                      //mediaPlayerRef.Pause();
                  } else if (m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.NOT_READY || m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.ERROR)
                  {
                      if (isTracking)
                      {
                          if (!_d)
                          {
                              mediaPlayerRef.Stop();
                              //mediaPlayerRef.Load(loopAnimName);
                              mediaPlayerRef.Play();
                              _d = true;
                              Debug.Log("Not ready maaaaaafk");
                          }
                          Debug.Log(mediaPlayerRef.ToString());
                      }
                  }
              }
              else
              {
                  _d = false;
              }
          }*/
        }
        if (transition)
        {

            if (!isTracking)
            {
                if (loopPlayerRef.m_strFileName != "")
                {
                    loopPlayerRef.enabled = true;
                    loopPlayerRef.UnLoad();
                    loopPlayerRef.enabled = false;
                }
                loopPlayerRef.enabled = false;
                transitionPlayerRef.enabled = false;
                return;
            }

            loop = false;
            if (!transitionPlayerRef.enabled)
            {
                transitionPlayerRef.enabled = true;
            }
            //mediaPlayerRef.SetVolume(videoVolume);
            // m_CurrentState = mediaPlayerRef.GetCurrentState();
            if (!_c)
            {
                Debug.Log("AHRELOCO");
                //textObj.text = "Pasamo.";
                 Transition();
                //transition = false;
                _c = true;
                //main = true;
            }

            if (m_CurrentState != MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING)
            {
                if (m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.READY)
                {
                    mediaPlayerRef.Play();
                    _d = false;
                }
                else if (m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.ERROR)
                {
                    if (!_d)
                    {
                        Debug.Log("Errored my dude...");
                        mediaPlayerRef.Stop();
                        //mediaPlayerRef.UnLoad();
                        //mediaPlayerRef.Load(transitionAnimName);
                        mediaPlayerRef.Play();
                        _d = true;
                    } else
                    {
                        //mediaPlayerRef.Stop();
                        mediaPlayerRef.Play();
                    }
                }
                else if (m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.NOT_READY)
                {
                    if (!_d)
                    {
                        Debug.Log("not ready my dude...");
                        //mediaPlayerRef.Stop();
                        //mediaPlayerRef.UnLoad();
                        //mediaPlayerRef.Load(transitionAnimName);
                        mediaPlayerRef.Play();
                        _d = true;
                    }
                }
                else if (m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.END)
                {
                    mediaPlayerRef.Stop();
                    mediaPlayerRef.UnLoad();
                    interactRef.ShowFinish(true);             //////////////////////ACA SE MUESTRA EL FINISH CANVAS CUANDO TERMINA LA PELICULA
                    interactRef.finished = true;
                    bEnd = true;
                }
                //mediaPlayerRef.Stop();
                /*if (!_d)
                {
                   // mediaPlayerRef.Load(transitionAnimName);
                    mediaPlayerRef.Play();
                    _d = true;
                }*/

            } else if (m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING)
            {
                _d = false;
                
            } 

            if (mediaPlayerRef.m_strFileName == transitionAnimName)
            {
                /*if (m_CurrentState != MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING)
                {

                    if (m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.READY)
                    {
                        if (!_d)
                        {
                            _d = true;
                            mediaPlayerRef.Play();
                        }
                    }*/
                    
                    StartCoroutine("coroutine");
                   /* if (_b)
                    {
                        if (!_d)
                        {
                            _d = true;
                            
                        }
                    }*/
            }
        }
 
    }
}
