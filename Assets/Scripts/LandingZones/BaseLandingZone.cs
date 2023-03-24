using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseLandingZone : MonoBehaviour, ILandingZone
{
    [SerializeField]
    string zoneName;
    public string Name { get; protected set; }

    protected virtual void Awake()
    {
        Name = zoneName;

        if (ILandingZone.landingZones.TryGetValue(gameObject.scene.path, out HashSet<ILandingZone> landingZones))
        {
            landingZones.Add(this);
        }
        else
        {
            landingZones = new HashSet<ILandingZone>();
            landingZones.Add(this);
            ILandingZone.landingZones.Add(gameObject.scene.path, landingZones);
        }
    }

    protected virtual void OnDestroy()
    {
        if(ILandingZone.landingZones.TryGetValue(gameObject.scene.path, out HashSet<ILandingZone> landingZones))
        {
            landingZones.Remove(this);
        }
    }

    public abstract void GetPoint(out Vector3 pos, out Quaternion rot);
}
