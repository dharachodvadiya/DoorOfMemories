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
        SceneChangeManager.Instance.LoadNextScreen(SceneChangeManager.EnumScene.birthday.ToString());

    }

    public void btn_home_help()
    {
        HelpDilog.Instance.openDilog();
    }
    #endregion

    public void btn_go_home()
    {
        SceneChangeManager.Instance.LoadNextScreen(SceneChangeManager.EnumScene.home.ToString());
    }
}
