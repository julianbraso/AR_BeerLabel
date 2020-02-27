/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class myTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        bool isTracking;
        IEnumerator ShowCalibrateText()
        {
            yield return new WaitForSeconds(10);
            if (!isTracking)
            {
                //textObj.enabled = true;
                //textObj.text = "Tracking lost, shake to recalibrate...";
                yield return new WaitForSeconds(5);
                //textObj.enabled = false;
                StartCoroutine(ShowCalibrateText());
            }
        }
        IEnumerator RestartCamEveryXSecs()
        {
            yield return new WaitForSeconds(2.0f);
            camSettings.restartCam();
        }

        #region PRIVATE_MEMBER_VARIABLES
 
        private TrackableBehaviour mTrackableBehaviour;
        [SerializeField]
        private CameraSettings camSettings;
        //[SerializeField]
        //private Text textObj;
        [SerializeField]
        private AnimManager animMgr;
        [SerializeField]
        private InteractionMGR interactMGR;
        [SerializeField]
        private cameraFocusController camFocus;
        [SerializeField]
        private TagManager tagManager;
        [SerializeField]
        private string tag;

        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS

        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
            camFocus.setFocus(false);
            //RestartCamEveryXSecs();
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

       

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        /// 

        

        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {

            Debug.Log(tag);


            if (tagManager)
            {
                tagManager.SetTag(tag);
                tagManager.currentAnimMgr = animMgr;
            }

            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            //textObj.enabled = false;
            isTracking = true;
            //StopCoroutine(ShowCalibrateText());
            //animMgr.setAudioVolume(0.25f);
            //animMgr.enabled = true;
            animMgr.isTracking = true;
            animMgr.SetMediaPlayerOnOff(true);
            //animMgr.setVolumeAuto();
            animMgr.play();
            interactMGR._SetActive(true);
            //camFocus.setFocus(true);
            //StopCoroutine(RestartCamEveryXSecs());
        }


        private void OnTrackingLost()
        {

            if (tagManager)
            {
                tagManager.SetTag( "None" );
                if (tagManager.currentAnimMgr)
                {
                    tagManager.currentAnimMgr.setAudioVolume(0.0f);
                    tagManager.currentAnimMgr = null;
                }
            }

            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            
            isTracking = false;
            animMgr.isTracking = false;
            //animMgr.SetMediaPlayerOnOff(false);
            //animMgr.Restart();
            animMgr.pause();
             //animMgr.enabled = false;
            //StartCoroutine(ShowCalibrateText());
            interactMGR._SetActive(false);
            //camFocus.setFocus(false);
            //StartCoroutine(RestartCamEveryXSecs());
        }

        #endregion // PRIVATE_METHODS
    }
}
