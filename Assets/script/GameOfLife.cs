using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{
    [SerializeField]
    private TextAsset _stageTextAsset;

    [SerializeField]
    private GameObject _CellPrefeb;
    private CellStatus[,] _CellStatusArray;
    private Cell[,] _CellArray;
    void LoadCellStatus()
    {
        string[] lines = this._stageTextAsset.text.Split("\n");
        string[] first_words = lines[0].Split(",");

        //for(int i=0; i<lines.GetLength(0); i++)
        //{
        //    string[]words = lines[i].Split(",");
        //    for(int j=0; j<words.GetLength(0); j++)
        //    {
        //        Debug.Log(words[j]);
        //    }
        //}
        this._CellStatusArray = new CellStatus[lines.Length +2,first_words.Length +2];
        for(int j=0; j<this._CellStatusArray.GetLength(1); j++)
        {
            this._CellStatusArray[0, j] = new CellStatus(
                false,
                true,
                false
            );
        }
    
        for(int i=0; i<this._CellStatusArray.GetLength(0) - 2; i++)
        {
            this._CellStatusArray[i + 1, 0] = new CellStatus(
                false,
                true,
                false
            );

        string[] words = lines[i].Split(",");
        for(int j=0; j<this._CellStatusArray.GetLength(1) - 2; j++)
        {
            switch (words[j].Trim())
            {
            case "0":
                this._CellStatusArray[i + 1, j + 1] = new CellStatus(
                false,
                false,
                false 
                );
                break;

            case "1":
                this._CellStatusArray[i + 1, j + 1] = new CellStatus(
                true,
                false,
                false 
                );
                break;

            case "2":
                this._CellStatusArray[i + 1, j + 1] = new CellStatus(
                false,
                true,
                false 
                );
                break;

            case "3":
                this._CellStatusArray[i + 1, j + 1] = new CellStatus(
                true,
                true,
                false 
                );
                break;

            case "4":
                this._CellStatusArray[i + 1, j + 1] = new CellStatus(
                false,
                true,
                false 
                );
                break;
                
            default:
                this._CellStatusArray[i + 1, j + 1] = new CellStatus(
                false,
                true,
                false 
                );
                break;
            }
        }
        this._CellStatusArray[i + 1, this._CellStatusArray.GetLength(1) - 1] = new CellStatus(
            false,
            true,
            false
        );
        }
        for(int j=0; j<this._CellStatusArray.GetLength(1); j++)
        {
            this._CellStatusArray[this._CellStatusArray.GetLength(0) - 1, j] = new CellStatus(
                false,
                true,
                false
            );
        }
    }
    
    void CreateCell()
    {
        this._CellArray = new Cell[this._CellStatusArray.GetLength(0), this._CellStatusArray.GetLength(1)];
        for(int i=0; i<this._CellStatusArray.GetLength(0); i++)
        {
            for(int j=0; j<this._CellStatusArray.GetLength(1); j++)
            {
                GameObject cell = Instantiate(this._CellPrefeb);
                cell.name = string.Format("({0}, {1})", i, j);
                cell.transform.localPosition = new Vector3(j, i, 0);
                this._CellArray[i, j] = cell.GetComponent<Cell>();
                this._CellArray[i, j].SetStatus(
                    this._CellStatusArray[i, j].isAlive,
                    this._CellStatusArray[i, j].isFixed,
                    this._CellStatusArray[i, j].isTarget
                );
            }
        }
    }

    void Start()
    {
        this.LoadCellStatus();
        this.CreateCell();
        
    }

}
