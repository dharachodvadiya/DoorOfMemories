using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpDilog : MonoBehaviour
{
    public static HelpDilog Instance;
    private void Start()
    {
        Instance = this;
        closeDilog();
    }
    public void openDilog()
    {
        gameObject.transform.localScale = Vector3.one;
    }

    public void closeDilog()
    {
        gameObject.transform.localScale = Vector3.zero;
    }

    public void btnCloseClick()
    {
        closeDilog();
    }
}
