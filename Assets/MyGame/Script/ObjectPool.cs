using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private void Start()
    {
        
    }
    List<GameObject> objList = new List<GameObject>();

    GameObject objPrefab, objParent;

    public ObjectPool(GameObject objPrefab, GameObject objParent)
    {
        this.objPrefab = objPrefab;
        this.objParent = objParent;
    }

    public GameObject getObject()
    {
        GameObject currObj = null;
        int count = objList.Count;
        for (int i = 0; i < count; i++)
        {
            if(!objList[i].activeInHierarchy)
            {
                currObj = objList[i];
                currObj.transform.SetParent(null);
                break;
            }
        }

        if(currObj == null)
        {
            currObj = Instantiate(objPrefab);
            objList.Add(currObj);
        }

        currObj.transform.SetParent(objParent.transform);
        currObj.SetActive(true);
        currObj.transform.localScale = Vector3.one;
        return currObj;
    }

}
