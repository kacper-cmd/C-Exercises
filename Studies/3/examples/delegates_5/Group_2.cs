using System;

partial class Group
{    
    // a declaration of delegate type GroupEvent as nested type of Group class
    // it is define inside Group because only Group class uses it, but, of course, it can be also top level type
    public delegate void GroupEvent(object sender, EventArgs e);

    // a declaration of an event (as instance of GroupEvent) in Group class
    public event GroupEvent meeting;

    // and below method will be use to generating (invoking) the event
    public void CallForMeeting()
    {
        if (meeting != null)
            meeting(this, new EventArgs());
    }


    // add an event to notify about adding a new person to the group

}

