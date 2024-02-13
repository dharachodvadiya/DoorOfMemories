using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static jigsaw.GameManager;

namespace jigsaw
{
    public class GridItem : MonoBehaviour, IPointerDownHandler
    {
        SpriteRenderer renderer;
        SliceInfo sliceInfoTemp;
        SliceInfo sliceInfoPer;

        private void Start()
        {
            renderer = GetComponent<SpriteRenderer>();
        }
        public void addSliceTemp(SliceInfo sliceInfo)
        {
            this.sliceInfoTemp = sliceInfo;
            renderer.sprite = this.sliceInfoTemp.sprite;
        }

        public void removeSliceTemp()
        {
            this.sliceInfoTemp = null;
            if(sliceInfoPer == null)
            {
                renderer.sprite = GameManager.Instance.spriteGridDefault;
            }
            else
            {
                renderer.sprite = sliceInfoPer.sprite;
            }
            
        }

        public void addSlicePer(SliceInfo itemSlice)
        {
            this.sliceInfoPer = itemSlice;
            renderer.sprite = this.sliceInfoPer.sprite;
        }

        public void removeSlicePer()
        {
            this.sliceInfoPer = null;
            renderer.sprite = GameManager.Instance.spriteGridDefault;
        }

        public SliceInfo getPerItemSlice()
        {
            return sliceInfoPer;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}