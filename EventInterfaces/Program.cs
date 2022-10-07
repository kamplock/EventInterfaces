using System;


namespace EventInterfaces
{
    //interface 1 - graduations
    public interface IGraduation
    {
        void printEventData();

  
        double eventCode(char c);
    }

    //interface 2 - weddings
    public interface IWedding
    {
        void printEventData();

        double eventCode(char c);
    }

    //interface 3 - birthdays
    public interface IBirthday
    {
        void printEventData();
        double eventCode(char c);


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
            }
            else if (Char.ToLower(code).Equals('l'))
            {
                double lateFee = theEvent.EventCost * .10;
                theEvent.EventCost = theEvent.EventCost + lateFee;
            }
            else if (Char.ToLower(code).Equals('f'))
            {
                return 0;
            }
            else if (Char.ToLower(code).Equals('e'))
            {
                theEvent.EventCost = theEvent.EventCost * .75; //25% discount
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


        

        //main program
        public class Program
        {
            static void Main(string[] args)
            {
                IWedding wed = new Events(1, "Wedding", 3000.00);
                wed.printEventData();
                Console.WriteLine("Enter your discount code.");
                char wedCode = Console.ReadLine()[0];
                Console.Write("Your total is: $" + wed.eventCode(wedCode));

                //buffer
                Console.WriteLine("\n-------------------------------");

                IGraduation grad = new Events(2, "Graduation Party", 500.00);
                grad.printEventData();
                Console.WriteLine("Enter your discount code.");
                char gradCode = Console.ReadLine()[0];
                Console.Write("Your total is: $" + grad.eventCode(gradCode));

                //buffer
                Console.WriteLine("\n-------------------------------");

                IBirthday birth = new Events(3, "Birthday Party", 100.00);
                birth.printEventData();
                Console.WriteLine("Enter your discount code.");
                char bCode = Console.ReadLine()[0];
                Console.Write("Your total is: $" + birth.eventCode(bCode));

                //buffer
                Console.WriteLine("\n-------------------------------");

                IBirthday birth2 = new Events(3, "Birthday Celebration", 300.00);
                birth2.printEventData();
                Console.WriteLine("Enter your discount code.");
                char b2Code = Console.ReadLine()[0];
                Console.Write("Your total is: $" + birth2.eventCode(b2Code));

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