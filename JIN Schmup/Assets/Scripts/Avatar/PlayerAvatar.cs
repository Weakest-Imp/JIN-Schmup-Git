using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAvatar : BaseAvatar
{
    protected override void Die()
    {
        base.Die();
        GameManager.Instance.GameOver();
    }
}
