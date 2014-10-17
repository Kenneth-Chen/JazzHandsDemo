/*============================================================================== 
 * Copyright (c) 2012-2013 Qualcomm Connected Experiences, Inc. All Rights Reserved. 
 * ==============================================================================*/

using UnityEngine;
using System.Collections;

/// <summary>
/// Displays splash image with appropriate size for different device resolutions
/// </summary>
public class SplashScreenView : UIView
{
    #region PRIVATE_MEMBER_VARIABLES
	private const bool skipSplashScreen = false;
    private Texture mAndroidPortrait;
	private Texture mAndroidLandscape;
	#endregion PRIVATE_MEMBER_VARIABLES
    
    #region UIView implementation
    public void LoadView ()
    {
		if(skipSplashScreen) {
			return;
		}
		mAndroidPortrait = Resources.Load("SplashScreen/AndroidPortrait") as Texture;
		mAndroidLandscape = Resources.Load("SplashScreen/AndroidLandscape") as Texture;
	}

    public void UnLoadView ()
    {
		if(mAndroidPortrait != null) {
			Resources.UnloadAsset(mAndroidPortrait);
		}
		if(mAndroidLandscape != null) {
			Resources.UnloadAsset(mAndroidLandscape);
		}
    }

    public void UpdateUI (bool tf)
    {
        if(!tf)return;
		if(skipSplashScreen) {
			return;
		}
		if(Screen.width > Screen.height) {
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), mAndroidLandscape, ScaleMode.ScaleAndCrop);
		} else {
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), mAndroidPortrait, ScaleMode.ScaleAndCrop);
		}
    }
    #endregion UIView implementation
}

