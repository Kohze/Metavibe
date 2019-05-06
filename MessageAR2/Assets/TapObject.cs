using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapObject : MonoBehaviour {
    public GameObject metalBall;  // floating icon -- to be renamed and extended (multiple icon types should be allowed)
    public CanvasGroup uiCanvasGroup;  // CanvasGroup for UI text and text-background-strip

    private Dictionary<long, GameObject> messageBalls; // dict of icons
    private Dictionary<long, Message> messages; // dict of messages

    //private const float LOC_UPDATE_DELAY = 50;
    private float distThreshold = 5.0f;  // threshold distance for displaying icon
    private bool updateLock = false;

    //private LocationInfo loc_origin;
    private OLocation last_loc;   // previous user location
    private OLocation loc_origin; // current user location

    // Use this for initialization
    void Start () { 
        // load with initialized location
        // for demo purposes, use dummy locations
        loc_origin = new OLocation(1, 1, 10);
        last_loc = loc_origin.copy();

        // initialize empty dicts of messages, icons
        messages = new Dictionary<long, Message>();
        messageBalls = new Dictionary<long, GameObject>();

        // hide the UI overlay
        uiCanvasGroup.alpha = 0f;
        uiCanvasGroup.blocksRaycasts = false;

        //InvokeRepeating("UpdateLocation", 0, LOC_UPDATE_DELAY);
    }

    void UpdateLocation()
    {
        // get updated location from user GPS
        // current implementation: 
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

        // future implementation:
        // obtain list of messages in JSON from react native app

        // current implementation:
        // return a fixed list of dummy messages
        return new Message[] {
            new Message(new OLocation(1.4f, 1.2f, 14), "Stroll down Isaac Newton's Secret Passageway - just $0.05 for access info!", 101),
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
        // update the list of messages within range
        // and return a pair of lists containing 
        // message IDs whose icons need to be added / removed from display
        
        Message[] msgsFromBC = GetMessagesFromBlockchain();

        List<long> toAdd = new List<long>();
        List<long> toRemove = new List<long>();
        
        // find existing messages which are now too far away
        foreach (Message m in messages.Values)
        {
            print("message " + m.id + " dist " + m.getLoc().flatDist(loc_origin));
            if (m.getLoc().flatDist(loc_origin) > maxDist)
            {
                toRemove.Add(m.id);
            }
        }

        // add messages from blockchain which are within range
        // and are not alreday present in list of messages
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

        // remove out-of-range messages
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
        // get rid of icons which were determined to be too far away
        foreach (long mid in ids)
        {
            Destroy(messageBalls[mid]);
            messageBalls.Remove(mid);
        }
    }

    void UpdateMessageObjects()
    {
        // add new icons and move all icons if user position has changed

        Dictionary<string, List<long>> updates = UpdateNearbyMessages(distThreshold);
        ClearMessageObjects(updates["remove"]);

        // add icons for new messages within range
        //this.transform.Find("helperText").GetComponent<TextMesh>().text = "" + messages.Count;
        //print("add: " + updates["add"].Count + " remove: " + updates["remove"].Count);
        foreach (long mid in updates["add"])
        {
            print("adding message ball with id " + mid);
            // set location of icon to be the difference between the user and the message's 3-d location
            messageBalls[mid] = Instantiate(metalBall, messages[mid].getLoc().diff(loc_origin), Quaternion.AngleAxis(180, Vector3.up));

            // attache the message info to the icon
            messageBalls[mid].AddComponent<Message>();
            messageBalls[mid].GetComponent<Message>().message = messages[mid].getMessage();
            messageBalls[mid].GetComponent<Message>().id = mid;
        }

        // move all icons if user location changed since last update
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

        // debug
        if (Time.frameCount % 100 == 0)
        {
            print(Time.frameCount);
        }

        // request updated location every 100 frames
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

        // fade away the UI overlay
        if (uiCanvasGroup.alpha > 0.1)
        {
            uiCanvasGroup.alpha -= 0.0015f;
        }
        else
        {
            uiCanvasGroup.alpha = 0f;
        }

        // touch interactivity
        if (Input.touchCount > 0)
        {
            Plane targetPlane = new Plane(transform.up, transform.position);
            //this.transform.Find("helperText").GetComponent<TextMesh>().text = "touch";

            Touch touch = Input.touches[0]; // only handle one touch
            if (touch.phase == TouchPhase.Ended)
            {
                // when touch is over, figure out which icon was touched, if any
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                float dist = 0.0f;
                targetPlane.Raycast(ray, out dist);
                Vector3 planePoint = ray.GetPoint(dist);
                RaycastHit hit = new RaycastHit();

                // icon was touched
                if (Physics.Raycast(ray, out hit, 1000))
                { 
                    Transform pickedObject = hit.transform; // get Transform of touched icon
                    //this.transform.Find("helperText").GetComponent<TextMesh>().text = "" + pickedObject.GetComponent<Message>().id;

                    // load icon's attached message into UI overlay
                    uiCanvasGroup.transform.Find("messageTextUI").GetComponent<Text>().text = pickedObject.GetComponent<Message>().message;
                    uiCanvasGroup.alpha = 1f; // 'un-hide' overlay
                    print(Input.location.isEnabledByUser + " " + Input.location.status);
                }
                else
                {
                    ; // currently, do nothing if user touches outside of icons area
                }
            }
            
        }
	}
}
