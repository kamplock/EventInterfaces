using System;


namespace EventInterfaces
{
    //interface 1 - graduations
    public interface IGraduation
    {
        void printEventData();

        //trying out this method for fun
        void enterGYear();
        double eventCode(char c);
    }

    //interface 2 - weddings
    public interface IWedding
    {
        void printEventData();

        //just trying out this method
        void enterWDate();
        double eventCode(char c);
    }

    //interface 3 - birthdays
    public interface IBirthday
    {
        void printEventData();
        double eventCode(char c);

        //again, for fun
        void bdayMsg();

    }

    public class EventInfo
    {
        int eventID;
        string eventDesc;
        double eventCost;

        public EventInfo(int theID, string theDesc, double theCost)
        {
            eventID = theID;
            eventDesc = theDesc;
            eventCost = theCost;
        }

        public int ID
        {
            get { return eventID; }
            set { eventID = value; }
        }

        public string EventDescription
        {
            get { return eventDesc; }
            set { eventDesc = value; }
        }

        public double EventCost
        {
            get { return eventCost; }
            set { eventCost = value; }
        }

        public override string ToString()
        {
            return "Event ID: " + ID.ToString() + "\nEvent Description: " + EventDescription + "\nEvent Cost: $" + EventCost.ToString();
        }


    }

    //public event class - implements 3 interfaces
    public class Events : IGraduation, IWedding, IBirthday
    {
        private EventInfo theEvent;

        //constructor for events. calls the EventINFO constructor
        public Events(int myID, string myDesc, double myCost)
        {
            theEvent = new EventInfo(myID, myDesc, myCost);
        }

        //method for the discount code
        public double eventCode(char code)
        {
            if (Char.ToLower(code).Equals('d'))
            {
                theEvent.EventCost = theEvent.EventCost * .9;
                return theEvent.EventCost;
            }
            else if (Char.ToLower(code).Equals('l'))
            {
                double lateFee = theEvent.EventCost * .10;
                theEvent.EventCost = theEvent.EventCost + lateFee;
                return theEvent.EventCost;
            }
            return theEvent.EventCost;


        }



        //Events class "default" print data
        
        void printEventData()
        {
            Console.WriteLine("Event ID: " + theEvent.ID +
                "\nEvent Description: " + theEvent.EventDescription +
                "\nEvent Cost: $" + theEvent.EventCost +
                "\n Default Event");
        }
        
        //printing data for a wedding
        void IWedding.printEventData()
        {
            //we want to print event id, desc, and cost
            //remember that they will be different for each event type
            Console.WriteLine("Event Description: " + theEvent.EventDescription + 
                "\nEvent Cost: $" + theEvent.EventCost +
                "\nWedding Receptions will be held in the Main Hall only.");
        }

        //printing data for a graduation
        void IGraduation.printEventData()
        {
            Console.WriteLine("Event Description: " + theEvent.EventDescription + 
                "\nEvent Cost: $" + theEvent.EventCost +
                "\nGraduation Parties will be held in the Conference Room or the Classroom.");
        }

        //printing data for a birthday
        void IBirthday.printEventData()
        {
            Console.WriteLine("Event Description: " + theEvent.EventDescription + 
                "\nEvent Cost: $" + theEvent.EventCost +
                "\nBirthday Parties can be held in the Dining Room or on the Patio.");
        }

        //printing a congrats msg for wedding - date
        //no error checking, just for fun
        void IWedding.enterWDate()
        {
            Console.WriteLine("What's your wedding date? MM/DD/YYYY");
            string theDate = Console.ReadLine();
            Console.WriteLine("Congrats! We can't wait to celebrate with you. See you " + theDate + "!");

        }

        //printing a congrats msg for graduation - year
        void IGraduation.enterGYear()
        {
            Console.WriteLine("What year is the graduation?");
            string theYear = Console.ReadLine();
            Console.WriteLine("Congrats, class of " + theYear + "!");
        }

        //printing a bday msg for bday - name
        void IBirthday.bdayMsg()
        {
            Console.WriteLine("What is the name of the person celebrating their birthday with us?");
            string name = Console.ReadLine();
            Console.WriteLine("Happy birthday, " + name + "!");
        }

        //main program
        public class Program
        {
            static void Main(string[] args)
            {
                IWedding wed = new Events(1, "Wedding", 3000.00);
                wed.printEventData();
                wed.enterWDate();
                Console.WriteLine("Enter your discount code.");
                char wedCode = Console.ReadLine()[0];
                Console.Write("Your total is: $" + wed.eventCode(wedCode));

                //buffer
                Console.WriteLine("\n-------------------------------");

                IGraduation grad = new Events(2, "Graduation Party", 500.00);
                grad.printEventData();
                grad.enterGYear();
                Console.WriteLine("Enter your discount code.");
                char gradCode = Console.ReadLine()[0];
                Console.Write("Your total is: $" + grad.eventCode(gradCode));

                //buffer
                Console.WriteLine("\n-------------------------------");

                IBirthday birth = new Events(3, "Birthday Party", 100.00);
                birth.printEventData();
                birth.bdayMsg();
                Console.WriteLine("Enter your discount code.");
                char bCode = Console.ReadLine()[0];
                Console.Write("Your total is: $" + birth.eventCode(bCode));

                //buffer
                Console.WriteLine("\n-------------------------------");

                Events myEvent = new Events(4, "Test", 400.00);
                myEvent.printEventData();
                Console.WriteLine("Enter your discount code.");
                char eCode = Console.ReadLine()[0];
                Console.Write("Your total is: $" + myEvent.eventCode(eCode));
            }
        }

    }
}