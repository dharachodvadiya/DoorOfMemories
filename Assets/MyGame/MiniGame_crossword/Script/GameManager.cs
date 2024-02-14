using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace crossWord
{

    public class GameManager : MonoBehaviour
    {
        GridItem[ , ] grid = new GridItem[9, 9];

        public List<GridItem> gridItems = new List<GridItem>();

        int startR = -1, startC = -1, endR = -1, endC = -1;

        bool isSelectGrid;

        List<selectData> selectDatas = new List<selectData>();

        string word1 = "PAINT", word2 = "COOK", word3 = "BAKING", word4 = "PLAY";

        public Image objWord1, objWord2, objWord3, objWord4;

        bool isResultDecalre;

        private void Start()
        {
            int count = gridItems.Count;
            for (int i = 0; i < count; i++)
            {
                string name = gridItems[i].name;
                grid[int.Parse(name[6]+""), int.Parse(name[7]+"")] = gridItems[i];
            }
        }
        private void Update()
        {
            if (isResultDecalre)
                return;
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var hits = Physics2D.GetRayIntersectionAll(ray, 1500f);

                foreach (var hit in hits)
                {
                    //print($"Mouse is over {hit.collider.name}");
                    if (hit.collider.tag == "grid")
                    {
                        string name = hit.collider.name;
                        startR = int.Parse(name[6] + "");
                        startC = int.Parse(name[7] + "");

                        isSelectGrid = true;
                       // Debug.Log("start " + name);
                    }

                }

            }

            if (Input.GetMouseButton(0))
            {
                if (isSelectGrid)
                {
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    var hits = Physics2D.GetRayIntersectionAll(ray, 1500f);

                    foreach (var hit in hits)
                    {
                        //print($"Mouse is over {hit.collider.name}");
                        if (hit.collider.tag == "grid")
                        {
                            string name = hit.collider.name;
                            endR = int.Parse(name[6] + "");
                            endC = int.Parse(name[7] + "");

                           // Debug.Log("end " + name);
                        }

                    }

                    drawGrid(false);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if(isSelectGrid)
                {
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    var hits = Physics2D.GetRayIntersectionAll(ray, 1500f);

                    foreach (var hit in hits)
                    {
                        //print($"Mouse is over {hit.collider.name}");
                        if (hit.collider.tag == "grid")
                        {
                            string name = hit.collider.name;
                            endR = int.Parse(name[6] + "");
                            endC = int.Parse(name[7] + "");

                           // Debug.Log("end " + name);
                        }

                    }

                    drawGrid(true);

                    checkResult();
                }

                isSelectGrid = false;
            }
        }

        void drawGrid(bool isFinal)
        {
            if(startC != -1 && startR != -1 && endR != -1 && endC != -1)
            {
                if ((startR == endR && startC != endC) ||
                    (startR != endR && startC == endC))
                {
                    string word = "";
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if ((i >= startR && i <= endR) && (j >= startC && j <= endC) ||
                                (i <= startR && i >= endR) && (j <= startC && j >= endC) ||
                                (i >= startR && i <= endR) && (j <= startC && j >= endC) ||
                                (i <= startR && i >= endR) && (j >= startC && j <= endC))
                            {
                                if(isFinal)
                                {
                                    grid[i, j].selectGridPer();
                                    word += grid[i, j].character;
                                }
                                else
                                {
                                    grid[i, j].selectGridTemp();
                                }
                               
                            }
                            else
                            {
                                grid[i, j].unselectGridTemp();
                            }
                        }
                    }

                    if(isFinal)
                    {
                        selectDatas.Add(new selectData(startR, startC, endR, endC));
                        if (word == word1)
                        {
                            objWord1.color = Color.yellow;
                        }
                        else if (word == word2)
                        {
                            objWord2.color = Color.yellow;
                        }
                        else if (word == word3)
                        {
                            objWord3.color = Color.yellow;
                        }
                        else if (word == word4)
                        {
                            objWord4.color = Color.yellow;
                        }
                        else
                        {
                            undoItem();
                            Debug.Log("wrong");
                        }

                      
                    }
                }
            }
        }

        void undoItem()
        {
            selectData data = selectDatas[selectDatas.Count - 1];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if ((i >= data.startR && i <= data.endR) && (j >= data.startC && j <= data.endC) ||
                        (i <= data.startR && i >= data.endR) && (j <= data.startC && j >= data.endC) ||
                        (i >= data.startR && i <= data.endR) && (j <= data.startC && j >= data.endC) ||
                        (i <= data.startR && i >= data.endR) && (j >= data.startC && j <= data.endC))
                    {
                        grid[i, j].unSelectGridPer();
                    }
                }
            }

            selectDatas.RemoveAt(selectDatas.Count - 1);
        }

        void checkResult()
        {
            if(selectDatas.Count == 4)
            {
                isResultDecalre = true;
                Debug.Log("win");
            }
        }
    }
    public class selectData
    {
        public int startR;
        public int startC;
        public int endR;
        public int endC;

        public selectData(int startR, int startC, int endR, int endC)
        {
            this.startR = startR;
            this.startC = startC;
            this.endR = endR;
            this.endC = endC;
        }
    }



}
