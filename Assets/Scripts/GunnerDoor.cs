using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerDoor : MonoBehaviour
{
    [SerializeField] private GameObject _gunner;
    [SerializeField] private GameObject _bossAttackManager;
    [SerializeField] private Transform _spawnpoint;

    // Animation Event
    private void Intro()
    {
        GameObject boss = Instantiate(_gunner, _spawnpoint.position, _spawnpoint.rotation);
        GameObject attackManager = Instantiate(_bossAttackManager);
        boss.GetComponent<Gunner>().BossAttackManager = attackManager.GetComponent<BossAttackManager>();

    }
}
