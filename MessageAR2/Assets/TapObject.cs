using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapObject : MonoBehaviour {
    public GameObject metalBall;
    public GameObject flatBall;
    public CanvasGroup uiCanvasGroup;
    private Dictionary<long, GameObject> messageBalls;
    private Dictionary<long, Message> messages;
    //private const float LOC_UPDATE_DELAY = 50;
    private float distThreshold = 5.0f;
    private bool updateLock = false;

    //private LocationInfo loc_origin;
    private OLocation last_loc;
    private OLocation loc_origin;

    // Use this for initialization
    void Start () { 
        // load with initialized location
        // for demo purposes, use dummy locations
        loc_origin = new OLocation(1, 1, 10);
        last_loc = loc_origin.copy();
        // and update location periodically
        messages = new Dictionary<long, Message>();
        messageBalls = new Dictionary<long, GameObject>();
        uiCanvasGroup.alpha = 0f;
        uiCanvasGroup.blocksRaycasts = false;
        //InvokeRepeating("UpdateLocation", 0, LOC_UPDATE_DELAY);
    }

    void UpdateLocation()
    {
        // get updated location
        // dummy method to simulate walking
        //loc_origin.lat *= 1.01f;
        loc_origin.lon += 0.02f;
        loc_origin.alt += 0.02f;
        print("Last pos: " + last_loc.ToString());
        print("Curr pos: " + loc_origin.ToString());

    }

    Message[] GetMessagesFromBlockchain()
    {
        // query the blockchain with current location
        // to find relatively nearby messages

        // NB: currently populated w dummy data
        return new Message[] { new Message(new OLocation(1.4f, 1.2f, 14), "Stroll down Isaac Newton's Secret Passageway - just $0.05 for access info!", 101),
                new Message(new OLocation(1.4f, 1.001f, 13), "Discount for all MetaVibe users on all products", 293),
                 new Message(new OLocation(0.45f, 1.001f, 12), "Great place to sit and relax", 338),
                new Message(new OLocation(1.55f, 1.001f, 11.5f), "Meet up here every Tuesday for free walking tour", 928),
                new Message(new OLocation(1.55f, 1.001f, 15f), "Really rude waiters here - avoid!", 720),
                new Message(new OLocation(1.55f, 1.001f, 16f), "Like my street art here? Leave me a small tip as a thanks!", 888),
                 new Message(new OLocation(0.55f, 1.2f, 14f), "Good food", 123)
                };
    }

    Dictionary<string, List<long>> UpdateNearbyMessages(float maxDist)
    {

        Message[] msgsFromBC= GetMessagesFromBlockchain();
        List<long> toAdd = new List<long>();
        List<long> toRemove = new List<long>();
        
        foreach (Message m in messages.Values)
        {
            print("message " + m.id + " dist " + m.getLoc().flatDist(loc_origin));
            if (m.getLoc().flatDist(loc_origin) > maxDist)
            {
                toRemove.Add(m.id);
            }
        }

        foreach (Message m in msgsFromBC)
        {
            //print("Message " + m.id + " dist " + m.getLoc().flatDist(loc_origin));
            //print("mess contains? " + messages.ContainsKey(m.id));
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

        //print("toAdd: " + toAdd.Count);
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
        Dictionary<string, List<long>> updates = UpdateNearbyMessages(distThreshold);
        ClearMessageObjects(updates["remove"]);

        //this.transform.Find("helperText").GetComponent<TextMesh>().text = "" + messages.Count;
        //print("add: " + updates["add"].Count + " remove: " + updates["remove"].Count);
        foreach (long mid in updates["add"])
        {
            print("adding message ball with id " + mid);
            messageBalls[mid] = Instantiate(metalBall, messages[mid].getLoc().diff(loc_origin), Quaternion.AngleAxis(180, Vector3.up));
            messageBalls[mid].AddComponent<Message>();
            messageBalls[mid].GetComponent<Message>().message = messages[mid].getMessage();
            messageBalls[mid].GetComponent<Message>().id = mid;
        }

        
        if (!last_loc.equals(loc_origin))
        {
            foreach (long mid in messageBalls.Keys)
            {
                messageBalls[mid].transform.position = messages[mid].getLoc().diff(loc_origin);
            }
            last_loc = loc_origin.copy();
        }
        
        updateLock = false;
    }

    // Update is called once per frame
    void Update() {


        if (Time.frameCount % 100 == 0)
        {
            print(Time.frameCount);
        }

        if (Time.frameCount % 100 == 0)
        {
            UpdateLocation();
        }

        // update items every 100 frames
        if (Time.frameCount % 100 == 2 && !updateLock)
        {
            updateLock = true;
            UpdateMessageObjects();
        }

        if (uiCanvasGroup.alpha > 0.1)
        {
            uiCanvasGroup.alpha -= 0.0015f;
        }
        else
        {
            uiCanvasGroup.alpha = 0f;
        }

        // dummy activity below to check touch-interactivity is working
        if (Input.touchCount > 0)
        {
            Plane targetPlane = new Plane(transform.up, transform.position);
            //this.transform.Find("helperText").GetComponent<TextMesh>().text = "touch";

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
                    //this.transform.Find("helperText").GetComponent<TextMesh>().text = "" + pickedObject.GetComponent<Message>().id;
                    uiCanvasGroup.transform.Find("messageTextUI").GetComponent<Text>().text = pickedObject.GetComponent<Message>().message;
                    uiCanvasGroup.alpha = 1f;
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
