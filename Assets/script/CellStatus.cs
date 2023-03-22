using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellStatus 
{
    private bool _isAlive;
    private bool _isFixed;
    private bool _isTarget;

    public bool isAlive
    {
        get { return this._isAlive; }
        set { this._isAlive = value; }
    }
    
    public bool isFixed
    {
        get { return this._isFixed; }
        set { this._isFixed = value; }
    }

     public bool isTarget
    {
        get { return this._isTarget; }
        set { this._isTarget = value; }
    }

    public CellStatus(bool isAlive, bool isFixed, bool isTarget)
    {
        this.isAlive = isAlive;
        this.isFixed = isFixed;
        this.isTarget = isTarget;
    }
}
