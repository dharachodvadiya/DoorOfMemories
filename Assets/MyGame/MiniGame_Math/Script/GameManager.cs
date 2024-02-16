using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace math
{
    public class GameManager : MonoBehaviour
    {
        public TMP_InputField inputField;
        public GameObject objError;
        // Start is called before the first frame update
        void Start()
        {
            objError.SetActive(false);
        }

        public void btn_sendMessage()
        {
            if(inputField.text.Trim().Length >0)
            {
                if(inputField.text.Trim() == "40")
                {
                    Debug.Log("win");
                    nextDoorDilog.Instance.openDilog();
                    objError.SetActive(false);
                }
                else
                {
                    objError.SetActive(true);
                }
            }
            else
            {
                objError.SetActive(true);
            }
        }
    }

}
