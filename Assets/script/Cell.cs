using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField]
    private Renderer _renderer;

    private CellStatus _status;

    void Awake()
    {
        this._status = new CellStatus(
            false,
            true,
            false
        );
    }

    void UpdateColor()
    {
        Color color;
        if(this._status.isAlive)
        {
            if(this._status.isFixed)
            {
                color = Color.white;
            }
            else
            {
                color = Color.red;
            }
        }
        else
        {
            if(this._status.isTarget)
            {
                color = Color.green;
            }
            else if(this._status.isFixed)
            {
                color = Color.black;
            }
            else
            {
                color = Color.grey;
            }
        }

        this._renderer.material.SetColor(
            "_Color",
            color
        );
    }

    public void SetStatus(bool isAlive, bool isFixed, bool isTarget)
    {
        this._status.isAlive = isAlive;
        this._status.isFixed = isFixed;
        this._status.isTarget = isTarget;
        this.UpdateColor();
    }

    public void ToggleStatus()
    {
        this._status.isAlive = !this._status.isAlive;
        this.UpdateColor();
    }

    public bool IsAlive()
    {
        return this._status.isAlive;
    }

    public bool IsFixed()
    {
        return this._status.isFixed;
    }

    public bool IsTarget()
    {
        return this._status.isTarget;
    }
}