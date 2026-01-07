/*
==========================================================
SINGLETON DESIGN PATTERN – QUICK INTERVIEW REVISION
==========================================================

Definition:
-----------
Singleton Pattern ensures that a class has ONLY ONE instance
and provides a GLOBAL POINT OF ACCESS to that instance.

Why we use it:
--------------
- Logger
- Configuration settings
- Cache
- Database connection manager
- Application-wide shared resources

Key Rules:
----------
1. Private constructor → prevents external object creation
2. Static instance → stored at class level
3. Public static accessor → global access point
4. Thread safety (important in multi-threaded apps)

Types shown below:
------------------
1. Eager Initialization
   - Instance created at class load time
   - Simple & thread-safe
   - May waste memory if never used

2. Lazy Initialization (with lock)
   - Instance created only when requested
   - Thread-safe using locking
   - Slight performance cost due to lock

3. Lazy<T> based Singleton (BEST PRACTICE)
   - Cleanest & modern approach
   - Thread-safe by default
   - Lazy-loaded
   - Preferred in real-world .NET applications

==========================================================
*/

using System;

namespace CreationalDesignPatterns.Singleton
{
    // ==================================================
    // 1. EAGER INITIALIZATION SINGLETON
    // ==================================================
    public class SingletonDesignPatternEager
    {
        // Static instance is created immediately
        // when the class is loaded into memory
        private static SingletonDesignPatternEager singletonEagerInstance =
            new SingletonDesignPatternEager();

        // Private constructor ensures
        // no external class can create an instance
        private SingletonDesignPatternEager()
        {
        }

        // Public static property provides
        // global access to the single instance
        public static SingletonDesignPatternEager GetInstance
        {
            get
            {
                return singletonEagerInstance;
            }
        }
    }

    // ==================================================
    // 2. LAZY INITIALIZATION SINGLETON (THREAD-SAFE)
    // ==================================================
    public class SingletonDesignPatternLazy
    {
        // Initially null → object will be created lazily
        private static SingletonDesignPatternLazy singletonDesignPatternLazy = null;

        // Lock object used to synchronize threads
        private static readonly object singletonlazyLock = new object();

        // Private constructor prevents external instantiation
        private SingletonDesignPatternLazy()
        {
        }

        // Public static property for global access
        public static SingletonDesignPatternLazy GetInstance
        {
            get
            {
                // First check (no lock for performance)
                if (singletonDesignPatternLazy == null)
                {
                    // Lock ensures only one thread
                    // can enter this block at a time
                    lock (singletonlazyLock)
                    {
                        // Second check (double-checked locking)
                        if (singletonDesignPatternLazy == null)
                        {
                            // IMPORTANT:
                            // Assigning the instance ensures
                            // only ONE object is ever created
                            singletonDesignPatternLazy =
                                new SingletonDesignPatternLazy();
                        }
                    }
                }

                // Always return the same instance
                return singletonDesignPatternLazy;
            }
        }
    }

    // ==================================================
    // 3. SINGLETON USING Lazy<T> (RECOMMENDED APPROACH)
    // ==================================================
    public class SingletonUsingLazy
    {
        // Lazy<T> handles:
        // - Lazy initialization
        // - Thread safety
        // - Exception handling
        private static readonly Lazy<SingletonUsingLazy> _singletonUsingLazyInstance =
            new Lazy<SingletonUsingLazy>(() => new SingletonUsingLazy());

        // Private constructor
        private SingletonUsingLazy()
        {
        }

        // Accessing .Value creates the object
        // only on first access
        public static SingletonUsingLazy SingletonUsingLazyInstance =>
            _singletonUsingLazyInstance.Value;
    }
}
