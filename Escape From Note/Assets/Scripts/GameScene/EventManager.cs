using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace EventSystem
{ 
    // define delegate
    public delegate void EventDelegate();
    public class EventManager : MonoBehaviour {
    
        // static field
        public static EventManager instance;
        public static EventManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new EventManager();
                }
                return instance;
            }
        }
        public static event EventDelegate someEvent = delegate(){};
        // public member

        // serialized field

        // private member
        public EventManager(){}

        public static void AddEvent(EventDelegate method)
        {
            someEvent += method;
        }

        public static void DeleteEvent(EventDelegate method)
        {
            someEvent -= method;
        }

        public static void InvokeEvent()
        {
            someEvent();
        }
    }
}