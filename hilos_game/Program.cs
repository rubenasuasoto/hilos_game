class Program
{
    static Mutex mutex = new Mutex();

    static void Main()
    {
        Thread thread1 = new Thread(MethodUsingMutex);
        Thread thread2 = new Thread(MethodUsingMutex);
        
        thread1.Start();
        thread2.Start();
        for (int i = 0; i < 1000; i++) Console.Write ("x"); 
    }

    static void MethodUsingMutex()
    {
        int r;
        
        mutex.WaitOne();

        Random rnd = new Random();
        r = rnd.Next(1, 4);
        

        mutex.ReleaseMutex();
        
        
        
    }
}
