using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jigsaw
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public SpriteRenderer pickSlideSprite;

        public Sprite spriteGridDefault;

        public List<SliceInfo> sliceInfos;
        public List<GridItem> gridItem;

        public GameObject objPrefab;

        public GameObject objSliceParent;

        public ObjectPool objectPool;

        public delegate void SliceClickEvent(SliceInfo slice,Vector3 pos,bool isSelectFromGrid);

        SliceClickEvent sliceClickEvent;

        bool isSliceSelect = false;
        SliceInfo currSelectedItemSlice;
        GridItem currGridItem;
        GridItem prevGridItem;

        GameObject prevSelectedSlicePos;
        bool isSelectFromGrid;

        Vector3 mousePos;

        String answer = "-1_0_1_-1_2_3_4_5_6_7_8_9_10_11_12_13_";

        bool isResultDecalre = false;
        // Start is called before the first frame update
        void Start()
        {
            isResultDecalre = false;
            Instance = this;
            sliceClickEvent += setOnSlickClick;
            objectPool = new ObjectPool(objPrefab, objSliceParent);
            int count = sliceInfos.Count;
            for (int i = 0; i < count; i++)
            {
                GameObject obj = objectPool.getObject();
                obj.GetComponent<itemSlice>().setData(sliceInfos[i], sliceClickEvent);
            }
        }

      

        // Update is called once per frame
        void Update()
        {
            if (isResultDecalre)
                return;
            if(isSliceSelect)
            {
                pickSlideSprite.gameObject.SetActive(true);
            }else
            {
                pickSlideSprite.gameObject.SetActive(false);
            }
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var hits = Physics2D.GetRayIntersectionAll(ray, 1500f);

                foreach (var hit in hits)
                {
                    //print($"Mouse is over {hit.collider.name}");
                    if (hit.collider.tag == "grid")
                    {
                        GridItem gridItem = hit.collider.GetComponent<GridItem>();

                        if (gridItem.getPerItemSlice() != null)
                        {
                            prevSelectedSlicePos = gridItem.gameObject;
                            sliceClickEvent.Invoke(gridItem.getPerItemSlice(), gridItem.transform.position,true);
                            gridItem.removeSlicePer();
                        }
                    }

                }

            }
            if (Input.GetMouseButton(0))
            {
               

                if(isSliceSelect)
                {
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    var hits = Physics2D.GetRayIntersectionAll(ray, 1500f);

                    prevGridItem = currGridItem;
                    currGridItem = null;
                    foreach (var hit in hits)
                    {
                        //print($"Mouse is over {hit.collider.name}");
                        if (hit.collider.tag == "grid")
                            currGridItem = hit.collider.GetComponent<GridItem>();

                    }

                    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mousePos.z = -2;
                    pickSlideSprite.transform.position = mousePos;

                   
                    if(prevGridItem != currGridItem)
                    {
                        if (prevGridItem != null)
                        {
                            prevGridItem.removeSliceTemp();
                        }
                        if (currGridItem != null)
                        {
                            currGridItem.addSliceTemp(currSelectedItemSlice);
                        }
                    }
                    else
                    {
                        if (currGridItem == null)
                        {
                            if (prevGridItem != null)
                            {
                                prevGridItem.removeSliceTemp();
                            }
                        }
                    }
                }
              
            }

            if (Input.GetMouseButtonUp(0))
            {
              
                if(currGridItem != null)
                {
                    SliceInfo slice = currGridItem.getPerItemSlice();
                    if (slice != null)
                    {
                        // isRemoveSlice = true;
                        // Vector3 pos = currGridItem.gameObject.transform.position;
                        //  pos.z = -2;
                        //  removeSlideSprite.gameObject.transform.position = pos;
                        //  removeSlideSprite.sprite = slice.img.sprite;
                        //  currRemovedItemSlice = slice;

                        // GameObject obj = objectPool.getObject();
                        // obj.GetComponent<itemSlice>().setData(slice, sliceClickEvent);
                        sliceBackPos(slice);
                    }
                    currGridItem.removeSliceTemp();
                    currGridItem.addSlicePer(currSelectedItemSlice);

                    checkResult();
                }else if(currSelectedItemSlice != null)
                {
                   
                    sliceBackPos(currSelectedItemSlice);
                }

                currGridItem = null;
                prevGridItem = null;
                currSelectedItemSlice = null;
                isSliceSelect = false;


            }
        }

        void checkResult()
        {
            int count = gridItem.Count;
            string userSolution = "";

            for (int i = 0; i < count; i++)
            {
                if(gridItem[i].getPerItemSlice() != null)
                {
                    userSolution += $"{gridItem[i].getPerItemSlice().id}_";
                }
                else
                {
                    userSolution += "-1_";
                }
            }

            if(answer == userSolution)
            {
                isResultDecalre = true;
                Debug.Log("win");
                nextDoorDilog.Instance.openDilog(0.3f);
            }
        }

        void sliceBackPos(SliceInfo slice)
        {
            if(isSelectFromGrid)
            {
                prevSelectedSlicePos.GetComponent<GridItem>().addSlicePer(slice);
            }
            else
            {
                GameObject obj = objectPool.getObject();
                obj.GetComponent<itemSlice>().setData(slice, sliceClickEvent);
            }
        }

        private void setOnSlickClick(SliceInfo slice,Vector3 currPos,bool isSelectFromGrid)
        {
            this.isSelectFromGrid = isSelectFromGrid;
            isSliceSelect = true;
            Vector3 pos = currPos;
            pos.z = -2;
            pickSlideSprite.gameObject.transform.position = pos;
            pickSlideSprite.sprite = slice.sprite;
            currSelectedItemSlice = slice;
        }
        [System.Serializable]
        public class SliceInfo
        {
            public int id;
            public Sprite sprite;
        }
    }

}
