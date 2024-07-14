using StateMachineExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stateMachine = new PackageStateMachine("Package", 3,new TimeSpan(0, 0, 3));
            stateMachine.StartTrigger();
        }
    }
}
namespace StateMachineExample
{
    public enum State
    {
        Queue,
        Start,
        Auto,
        Running,
        Fail,
        Finish
    }

    public class PackageStateMachine
    {
        public PackageStateMachine(string name,int maxRetries,TimeSpan maxInterval)
        {
            _name = name;
            MaxRetries = maxRetries;
            MaxInterval = maxInterval;

        }
        private string _name;
        private State _currentState;
        private int _retryCount = 0;
        private int MaxRetries = 3;
        // TimeSpan variable to store when the package current time - start time
        private TimeSpan _startTime = DateTime.Now.TimeOfDay;
        private TimeSpan _intervalTime = DateTime.Now.TimeOfDay;
        // TimeSpan of 5 seconds
        private TimeSpan MaxInterval = new TimeSpan(0, 0, 5);

        public PackageStateMachine()
        {
            _currentState = State.Queue;
        }

        public void StartTrigger()
        {
            if (_currentState == State.Queue)
            {
                _currentState = State.Start;
                ProcessState();
            }
        }

        private void ProcessState()
        {
            switch (_currentState)
            {
                case State.Start:
                    Console.WriteLine($"Starting {_name}...");
                    _startTime = DateTime.Now.TimeOfDay;
                    _currentState = State.Auto;
                    ProcessState();
                    break;

                case State.Auto:
                    _currentState = State.Running;
                    ProcessState();
                    break;

                case State.Running:
                    Console.WriteLine($"Running {_name}...");

                    _intervalTime = DateTime.Now.TimeOfDay - _startTime;
                    Console.WriteLine("Interval Time: " + _intervalTime);
                    if (_retryCount >= MaxRetries)
                    {
                        Console.WriteLine("Max Retries Reached");
                        _currentState = State.Fail;
                        ProcessState();
                    }
                    else if (_intervalTime >= MaxInterval)
                    {
                        Console.WriteLine("Interval Time Reached");
                        if (_retryCount >= MaxRetries)
                        {
                            Console.WriteLine("Max Retries Reached");
                            _currentState = State.Fail;
                            ProcessState();
                        }
                        else
                        {
                            
                            _retryCount++;
                            // print retrying amount of max retries
                            Console.WriteLine($"Retrying... {_retryCount} of {MaxRetries}");
                            _currentState = State.Start;
                            ProcessState();
                        }
                        
                    }
                    else
                    {
                        // Check interval
                        _currentState = GetRandomState();
                        // Print the current state
                        Console.WriteLine("Current State: " + _currentState);
                        // sleep for 1 second
                        System.Threading.Thread.Sleep(1000);
                        ProcessState();
                    }
                    break;


                case State.Fail:
                    if (_retryCount>= MaxRetries)
                    {
                        Console.WriteLine("Process Failed");
                    }
                    else
                    {
                        
                        _retryCount++;
                        // print retrying amount of max retries
                        Console.WriteLine($"Retrying... {_retryCount} of {MaxRetries}");
                        _currentState = State.Start;
                        ProcessState();

                    }
                    
                    break;

                case State.Finish:
                    Console.WriteLine("Process Finished Successfully");
                    //Triggering Artifactory
                    PackageStateMachine packageStateMachine = new PackageStateMachine("Artifactory", 2, new TimeSpan(0, 0, 2));
                    packageStateMachine.StartTrigger();
                    break;
            }
        }


        //Get Random state including only Fail, Running and Finish
        //Make Fail and Finish less likely to select only 1/20 of the time.

        public State GetRandomState()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 21); // Generate a number between 1 and 20

            if (randomNumber == 1)
            {
                return State.Fail; // 1/20 chance
            }
            else if (randomNumber == 2)
            {
                return State.Finish; // 1/20 chance
            }
            else
            {
                return State.Running; // 18/20 chance
            }
        }


    }
}