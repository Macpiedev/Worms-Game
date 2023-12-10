using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ChangePlayerDelegate();

public abstract class IWeapon : MonoBehaviour
{
    public abstract IEnumerator activate(ChangePlayerDelegate postAttackCallback);
    public abstract int damage();
    
}
