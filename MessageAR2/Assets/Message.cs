using UnityEngine;

public class Message : MonoBehaviour
{
    private OLocation location;
    public string message;
    public long id;
    public Message(OLocation loc, string msg, long ID)
    {
        this.location = loc;
        this.message = msg;
        this.id = ID;
    }

    public string getMessage()
    {
        return this.message;
    }

    public OLocation getLoc()
    {
        return this.location;
    }

}