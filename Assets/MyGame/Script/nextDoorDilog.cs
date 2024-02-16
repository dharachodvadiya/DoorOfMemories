using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SceneChangeManager;

public class nextDoorDilog : MonoBehaviour
{

    public static nextDoorDilog Instance;
    private void Start()
    {
        Instance = this;
        closeDilog();
    }
    public void openDilog()
    {
        gameObject.transform.localScale = Vector3.one;
    }

    public void openDilog(float second)
    {
        Invoke("openInvok", second);
    }

    void openInvok()
    {
        gameObject.transform.localScale = Vector3.one;
    }

    public void closeDilog()
    {
        gameObject.transform.localScale = Vector3.zero;
    }

    public void btnNextClick(int currLevel)
    {
        switch(currLevel)
        {
            case 0:
                SceneChangeManager.Instance.LoadNextScreen(SceneChangeManager.EnumScene.Math.ToString());
                break;
            case 1:
                SceneChangeManager.Instance.LoadNextScreen(SceneChangeManager.EnumScene.hobby.ToString());
                break;
            case 2:
                SceneChangeManager.Instance.LoadNextScreen(SceneChangeManager.EnumScene.Win.ToString());
                break;
        }
       
    }
}
