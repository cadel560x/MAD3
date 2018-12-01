using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMortal {
    void Die();

    void TakeDamage(int damage);
}
