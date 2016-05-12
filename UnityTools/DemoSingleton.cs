using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityTools
{
    /// <summary>线程安全的单例模式示范</summary>
    /// <summary>使用volatile来修饰,确保instance在被访问之前被赋值实例</summary>
    public class DemoSingleton
    {
        private static volatile DemoSingleton DataInstance = null;
        private static object objLock = new object(); //锁,防止多线程下重复创建实例
        private DateTime dtCreateDate = DateTime.Now;

        private DemoSingleton()
        {
            FillSource();
        }

        private void FillSource()
        {
            //填充数据源dt
        }

        /// <summary> 单例</summary>
        public static DemoSingleton Instance
        {
            get
            {
                lock (objLock)
                {
                    if (DataInstance == null)
                    {
                        DataInstance = new DemoSingleton();
                    }
                    else
                    {
                        if (DateTime.Now.Subtract(DataInstance.dtCreateDate).Minutes >= 10) //此处设置 为10分钟更新一次
                        {
                            DataInstance = null;
                            DataInstance = new DemoSingleton();
                        }
                    }
                }
                return DataInstance;
            }
        }
    }

    /// <summary>双重单例模式</summary>
    /// <summary>对多线程来说是安全的,线程不是每次都加锁,只有判断对象实例没有被创建时它才加锁,无法实现延迟初始化</summary>
    public sealed class SafeSingleton
    {
        private static SafeSingleton _instance = null;
        private static readonly object Padlock = new object();
        private DateTime dtCreateDate = DateTime.Now;

        private SafeSingleton()
        {
        }

        public static SafeSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SafeSingleton();
                        }
                    }
                }
                return _instance;
            }
        }
    }

    /// <summary>延迟初始化单例模式</summary>
    public sealed class DelaySingleton
    {
        private DelaySingleton()
        {
        }

        public static DelaySingleton Instance
        {
            get { return Nested.instance; }
        }

        private class Nested
        {
            static Nested()
            {
            }

            internal static readonly DelaySingleton instance = new DelaySingleton();
        }
    }

    public class LazySingleton
    {
        // 因为构造函数是私有的，所以需要使用lambda
        private static readonly Lazy<LazySingleton> _instance = new Lazy<LazySingleton>(() => new LazySingleton());
        // new Lazy<LazySingleton>(() => new LazySingleton(), LazyThreadSafetyMode.ExecutionAndPublication);//默认会有后面的参数的,也就是说,介个同样是线程安全的
        private LazySingleton()
        {
        }

        public static LazySingleton Instance
        {
            get { return _instance.Value; }
        }
    }
}
