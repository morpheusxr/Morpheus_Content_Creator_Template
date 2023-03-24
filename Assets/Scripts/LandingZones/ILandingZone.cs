using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILandingZone
{
    string Name { get; }
    void GetPoint(out Vector3 pos, out Quaternion rot);

    static readonly protected Dictionary<string, HashSet<ILandingZone>> landingZones = new();
    public static IReadOnlyDictionary<string, HashSet<ILandingZone>> LandingZones { get { return landingZones; } }
}
