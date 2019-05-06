using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapObject : MonoBehaviour {
    public GameObject metalBall;
    public GameObject flatBall;
    private Dictionary<long, GameObject> messageBalls;
    private Dictionary<long, Message> messages;
    private const float LOC_UPDATE_DELAY = 600;
    private float distThreshold = 200;
    private bool updateLock = false;

    //private LocationInfo loc_origin;
    private OLocation loc_origin;

    // Use this for initialization
    void Start () {
        // load with initialized location
        // and update location periodically
        messages = new Dictionary<long, Message>();
        messageBalls = new Dictionary<long, GameObject>();
        InvokeRepeating("UpdateLocation", 0, LOC_UPDATE_DELAY);
	}

    void UpdateLocation()
    {
        //loc_origin = xxx;
        loc_origin = new OLocation(1, 1, 10);
        print("Update location");
    }

    Message[] GetMessagesFromBlockchain()
    {
        // query the blockchain with current location
        // to find relatively nearby messages

        // NB: currently populated w dummy data
        return new Message[] { new Message(new OLocation(1.301f, 1.001f, 13), "3m up", 101),
                new Message(new OLocation(1.2f, 1.001f, 11), "1m up", 293),
                 new Message(new OLocation(1.001f, 0.891f, 12), "2m up", 338),
                new Message(new OLocation(0.998f, 1.001f, 10), "0m up", 928)
                };
    }

    Dictionary<string, List<long>> UpdateNearbyMessages(float maxDist)
    {

        Message[] msgsFromBC= GetMessagesFromBlockchain();
        List<long> toAdd = new List<long>();
        List<long> toRemove = new List<long>();
        
        foreach (Message m in messages.Values)
        {
            if (m.getLoc().flatDist(loc_origin) > maxDist)
            {
                toRemove.Add(m.id);
            }
        }

        foreach (Message m in msgsFromBC)
        {
            print("Message " + m.id + " dist " + m.getLoc().flatDist(loc_origin));
            print("mess contains? " + messages.ContainsKey(m.id));
            if (!messages.ContainsKey(m.id) && !toRemove.Contains(m.id) && m.getLoc().flatDist(loc_origin) <= maxDist)
            {
                toAdd.Add(m.id);
                messages.Add(m.id, m);
            }
        }

        //print(messages.Count);
        foreach (long mid in toRemove)
        {
            messages.Remove(mid);
        }

        print("toAdd: " + toAdd.Count);
        return new Dictionary<string, List<long>>()
        {
            {"add", toAdd},
            {"remove", toRemove}
        };
    }

    void ClearMessageObjects(List<long> ids)
    {
        foreach (long mid in ids)
        {
            Destroy(messageBalls[mid]);
            messageBalls.Remove(mid);
        }
    }

    void UpdateMessageObjects()
    {
        print("UMO 0");
        Dictionary<string, List<long>> updates = UpdateNearbyMessages(distThreshold);
        print("UMO 1");
        ClearMessageObjects(updates["remove"]);

        this.transform.Find("helperText").GetComponent<TextMesh>().text = "" + messages.Count;
        print("add: " + updates["add"].Count + " remove: " + updates["remove"].Count);
        foreach (long mid in updates["add"])
        {
            print("adding message ball with id " + mid);
            messageBalls[mid] = Instantiate(metalBall, messages[mid].getLoc().diff(loc_origin), Quaternion.identity);
            messageBalls[mid].AddComponent<Message>();
            messageBalls[mid].GetComponent<Message>().message = messages[mid].getMessage();
            messageBalls[mid].GetComponent<Message>().id = mid;
        }

        updateLock = false;
    }

    // Update is called once per frame
    void Update() {

        if (Time.frameCount % 100 == 2 && !updateLock)
        {
            updateLock = true;
            //UpdateNearbyMessages(distThreshold);
            UpdateMessageObjects();
        }


        // dummy activity below to check touch-interactivity is working
        if (Input.touchCount > 0)
        {
            Plane targetPlane = new Plane(transform.up, transform.position);
            this.transform.Find("helperText").GetComponent<TextMesh>().text = "touch";

            Touch touch = Input.touches[0];
            if (touch.phase == TouchPhase.Ended)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                float dist = 0.0f;
                targetPlane.Raycast(ray, out dist);
                Vector3 planePoint = ray.GetPoint(dist);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit, 1000))
                {
                    //this.transform.Find("helperText").GetComponent<TextMesh>().text = "hit";

                    Transform pickedObject = hit.transform;
                    this.transform.Find("helperText").GetComponent<TextMesh>().text = pickedObject.GetComponent<Message>().getMessage();
                    pickedObject.localScale = pickedObject.localScale * 0.9f;
                    print(Input.location.isEnabledByUser + " " + Input.location.status);
                } else
                {
                   // Instantiate(GameObject.Find("dummy0"));
                }
            }
            
        }
	}
}
