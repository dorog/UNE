using System.Collections;
using UnityEngine;

public abstract class CardAbility : MonoBehaviour
{
    public abstract IEnumerator TakeEffect(RoundManager roundManager);
}
