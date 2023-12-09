using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IWeapon : MonoBehaviour
{
    public abstract void activate(int destroyDelay);
    public abstract int damage();
}
