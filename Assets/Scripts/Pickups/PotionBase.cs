using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBase : MonoBehaviour
{
    protected void DestroyPotion()
    {
        Destroy(gameObject);
    }
}
