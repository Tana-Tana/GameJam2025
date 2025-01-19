using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool
{
    private List<Bullet> _bullets = new List<Bullet>();

    public void AddBullet(Bullet bullet)
    {
        _bullets.Add(bullet);
    }

    public Bullet GetBullet()
    {
        if ( _bullets.Count > 0 )
        {
            return _bullets[0];
        }

        Debug.Log("Hết đạn");
        return null;
    }

    public void RemoveBullet()
    {
        if (_bullets.Count > 0)
        {
            _bullets.RemoveAt(0);
        }
    }

}
