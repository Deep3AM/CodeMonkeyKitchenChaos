using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasProgress
{
    public event EventHandler<OnProgressChangeEventArgs> OnProgessChanged;
    public class OnProgressChangeEventArgs : EventArgs
    {
        public float progressNormalized;
    }
}
