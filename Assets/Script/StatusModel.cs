using System;
using UnityEngine;

[Serializable]
public class StatusModel : MonoBehaviour
{
    public int maxLife;
    public int currentLife;
    public int attack;
    public int deffence;
}

public interface IStatusModelHolder
{
    StatusModel Status { get; }
}
