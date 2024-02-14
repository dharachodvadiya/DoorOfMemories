using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace crossWord
{
    public class GridItem : MonoBehaviour
    {
        SpriteRenderer spriteRenderer;

        int SelectCount = 0;

        public string character;
        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            character = GetComponentInChildren<TextMeshPro>().text;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void selectGridTemp()
        {
            spriteRenderer.color = Color.red;
        }
        public void unselectGridTemp()
        {
            if(SelectCount <= 0)
            {
                spriteRenderer.color = Color.white;
            }
            else
            {
                spriteRenderer.color = Color.yellow;
            }
            
        }

        public void selectGridPer()
        {
            SelectCount++;
            spriteRenderer.color = Color.yellow;
        }

        public void unSelectGridPer()
        {
            SelectCount--;
            if (SelectCount <= 0)
            {
                spriteRenderer.color = Color.white;
            }
            else
            {
                spriteRenderer.color = Color.yellow;
            }
            
        }
    }
}
