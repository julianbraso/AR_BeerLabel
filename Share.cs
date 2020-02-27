using UnityEngine;
using System.Collections;
using VoxelBusters.NativePlugins;
public class Share : MonoBehaviour
{
    string link;
    public string message;
    public void ShareViaShareSheet()
    {   
        // Create new instance and populate fields
        ShareSheet _shareSheet = new ShareSheet();
        //_shareSheet.AttachScreenShot();
        _shareSheet.Text = message;
        // On iPad, popover view is used to show share sheet. So we need to set its position
        NPBinding.UI.SetPopoverPointAtLastTouchPosition();
        // Show composer
        NPBinding.Sharing.ShowView(_shareSheet, OnFinishedSharing);
        
    }
    private void OnFinishedSharing(eShareResult _result)
    {
        // Insert your code
    }

    void Start()
    {
#if UNITY_IOS
        link = "" ;     ////*itmss://itunes.apple.com/us/app/the-owl-the-dust-devil/id1289848896?ls=1&mt=8&ign-mscache=1*/
#endif
#if UNITY_ANDROID
        link = "https://play.google.com/store/apps/details?id=com.kaleidadigital.lc";
#endif
    }
}