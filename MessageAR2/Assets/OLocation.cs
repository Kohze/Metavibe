
using UnityEngine;

public class OLocation {
    public float lat, lon, alt;

    public OLocation(float la, float lo, float a)
    {
        this.lat = la;
        this.lon = lo;
        this.alt = a;
    }
    
    public Vector3 diff(OLocation other)
    {
        Vector3 rp = Vector3.zero;
        rp.Set(this.lat - other.lat, this.lon - other.lon, this.alt - other.alt);
        return rp;
    }

    public float flatDist(OLocation other)
    {
        return Mathf.Sqrt(Mathf.Pow(this.lat - other.lat, 2) + Mathf.Pow(this.lon - other.lon, 2) + Mathf.Pow(this.alt - other.alt, 2));
    }

    public OLocation copy()
    {
        return new OLocation(lat, lon, alt);
    }

    public bool equals(OLocation other)
    {
        return this.lat == other.lat && this.lon == other.lon && this.alt == other.alt;
    }

    public override string ToString()
    {
        return string.Format("{0:0.0000} {1:0.0000} {2:0.0000}", this.lat, this.lon, this.alt);
    }
}
