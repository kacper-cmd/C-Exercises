using System;

partial class Group
{
    public delegate void GroupEvent(object zrodlo, System.EventArgs e);
    public event GroupEvent meeting;
    public void CallForMeeting()
    {        
        if (meeting != null) meeting(this, new System.EventArgs());
    }
  
}

