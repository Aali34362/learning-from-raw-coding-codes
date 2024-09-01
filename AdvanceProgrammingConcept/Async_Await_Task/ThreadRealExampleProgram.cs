using Dumpify;

namespace Async_Await_Task;

public static class ThreadRealExampleProgram
{
    public static async Task ThreadRealExampleProgramMain()
    {
        Thread.CurrentThread.ManagedThreadId.Dump("1");
        var client = new HttpClient();
        Thread.CurrentThread.ManagedThreadId.Dump("2");
        var task = client.GetStringAsync("http://google.com");
        Thread.CurrentThread.ManagedThreadId.Dump("3");
        int a = 0;
        for (int i = 0; i < 1_000_00; i++) { a += i; }
        Thread.CurrentThread.ManagedThreadId.Dump("4");
        var page = await task;
        Thread.CurrentThread.ManagedThreadId.Dump("5");
    }
}
/*
Execution Flow and Thread Management
Thread ID Dump 1: 
The program starts on the main thread. The Thread.CurrentThread.ManagedThreadId.Dump("1"); line dumps the thread ID.

HttpClient Creation: 
A new HttpClient object is created. 
This operation is synchronous, so it runs on the main thread. 
The thread ID is dumped again with Dump("2").

Start of Asynchronous Operation: 
The program starts the asynchronous operation client.GetStringAsync("http://google.com");, 
which sends an HTTP GET request to the specified URL.
At this point, GetStringAsync will internally create and schedule the task to run asynchronously. 
The Dump("3") line dumps the thread ID before the task starts executing.
Note: The request starts asynchronously, but it hasn’t awaited the result yet, so the thread is still executing.

Synchronous Loop Execution: 
The program enters a loop that performs some synchronous computation (for (int i = 0; i < 1_000_00; i++) { a += i; }). 
This loop runs on the same thread that started the operation (most likely the main thread), and the thread ID is dumped again with Dump("4").

Awaiting the Task: 
The line var page = await task; awaits the completion of the HTTP request.
Checkpoint 1 (State Machine Created): When the await keyword is encountered, the state machine is created if not already done. 
The current state (right before await) is saved, and the program is paused until the asynchronous task is complete.
Continuation: 
Once the HTTP request completes, the state machine will resume execution from where it left off, 
but this could be on the same or a different thread. The final Dump("5") will dump the thread ID after the task completion.

State Machine Mechanism
    State 0: Initial State
        Execution starts at Dump("1").
        The state machine is not yet created.

    State 1: After GetStringAsync is called
        The state machine captures the current state when await task is encountered.
        The current thread is released, allowing other operations to run while waiting for the HTTP response.
        The state machine moves to the next state once the task completes.

    State 2: After await task
        The state machine resumes execution after the await point.
        It retrieves the result from task and proceeds with the next line of code (Dump("5")).

Important Points:
State Machine Generation: 
The async keyword triggers the compiler to generate a state machine to manage the program's execution flow. 
The state machine records the position before each await, allowing the method to pause and resume execution.

Thread Switching: 
The code that runs after await task; (from Dump("5")) might execute on a different thread, depending on the synchronization context. 
If the synchronization context is not captured (e.g., in a console application without a UI context), it might run on a thread pool thread.

Efficiency: 
The state machine ensures that while the program waits for the HTTP request to complete, the thread is free to perform other tasks. 
This non-blocking behavior is a key advantage of asynchronous programming.

Conclusion
This code showcases how async/await works with a state machine to handle asynchronous operations efficiently.
The state machine behind the scenes manages the states between the synchronous parts of the code and the await points, 
allowing the program to execute smoothly without blocking threads during asynchronous operations.
 */