using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void Start()
    {
        
    }

    #region home

    public void btn_home_StartGame()
    {
        SceneChangeManager.Instance.LoadNextScreen(SceneChangeManager.EnumScene.menu.ToString());
    }
    #endregion
}
