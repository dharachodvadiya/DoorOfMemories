using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static jigsaw.GameManager;

namespace jigsaw
{
    public class itemSlice : MonoBehaviour, IPointerDownHandler
    {
        public Image imgbg;
        public SliceInfo sliceInfo;
        SliceClickEvent sliceClickEvent;
        public void setData(SliceInfo info, SliceClickEvent sliceItemClickListener)
        {
            imgbg.sprite = info.sprite;
            this.sliceInfo = info;

            this.sliceClickEvent = sliceItemClickListener;
        }
        // Start is called before the first frame update
        void Start()
        {
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            gameObject.SetActive(false);
            sliceClickEvent.Invoke(sliceInfo, transform.position,false);
        }
    }
}
