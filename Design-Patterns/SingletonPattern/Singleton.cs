/// Singleton pattern is one of the simplest design patterns. This pattern ensures that a class has only one instance and provides a global point of access to it.
namespace Design_Patterns.SingletonPattern
{
    /// <summary>
    /// Eager initialization of singleton.
    /// </summary>
    public class SingletonEager
    {
        private static SingletonEager singletonInstance = new SingletonEager();

        /// <summary>
        /// private constructor to prevent external initialization.
        /// </summary>
        private SingletonEager()
        {

        }

        public static SingletonEager GetInstance
        {
            get
            {
                return singletonInstance;
            }
        }
    }

    /// <summary>
    /// Lazy initialization suingleton.
    /// </summary>
    public class SingletonLazy /// Single class whole part
    {
        private static SingletonLazy? singletonLazy = null; /// initialize with null for lazy loading.
        public static readonly object singletonLazyLock = new object(); /// object ofr locking block of code.

        /// <summary>
        /// To prevent external instance creation.
        /// </summary>
        private SingletonLazy()
        {

        }

        public static SingletonLazy GetSingletonInstance
        {
            get
            {
                if (singletonLazy == null) /// Double null check for performance as locking may requires resouces so need to avoid  unecessary locking do only when required.
                {
                    lock (singletonLazyLock) /// lock the block of code used because when multiple thread tries to access same block of code so lock will prevent it.
                    {
                        if (singletonLazy == null) /// Lazy loading create instance obnly when required, avoids creating multiple instance of SingletonLazy class.
                        {
                            singletonLazy = new SingletonLazy(); 
                        }
                    }
                }

                return singletonLazy;
            }
        }
    }
}
