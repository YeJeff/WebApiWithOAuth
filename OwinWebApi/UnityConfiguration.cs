using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace OwinWebApi
{
    /// <summary>
    /// unityy config 映射服务接口和具体实现
    /// </summary>
    public class UnityConfig : ConfigurationSection
    {
        /// <summary>
        /// 构造器
        /// </summary>
        public UnityConfig()
        {
        }

        /// <summary>
        /// 配置节串行化方法
        /// </summary>
        /// <param name="parentElement"></param>
        /// <param name="name"></param>
        /// <param name="saveMode"></param>
        /// <returns></returns>
        public new string SerializeSection(ConfigurationElement parentElement, string name,
                                           ConfigurationSaveMode saveMode)
        {
            return base.SerializeSection(parentElement, name, saveMode);
        }

        /// <summary>
        /// 程序集（命名空间）配置集
        /// </summary>
        [ConfigurationProperty("serverAssemblies", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ServiceAssemblyCollection), AddItemName = "add", RemoveItemName = "remove",
            ClearItemsName = "clear")]
        public ServiceAssemblyCollection ServerAssemblies
        {
            get { return (ServiceAssemblyCollection)this["serverAssemblies"]; }
        }
    }

    public class ServiceAssemblyCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ServiceAssembly();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ServiceAssembly)element).Contract;
        }

        public ServiceAssembly this[int index]
        {
            get
            {
                return (ServiceAssembly)BaseGet(index);
            }
        }

        new public ServiceAssembly this[string name]
        {
            get
            {
                return (ServiceAssembly)BaseGet(name);
            }
        }

        public void Add(ServiceAssembly bind)
        {
            BaseAdd(bind);
        }


        public void RemoveAt(int ind)
        {
            BaseRemoveAt(ind);
        }

        public void Remove(ServiceAssembly bind)
        {
            BaseRemove(bind);
        }

        public void Clear()
        {
            BaseClear();
        }
    }


    public class ServiceAssembly : ConfigurationElement
    {
        /// <summary>
        /// Contract
        /// </summary>
        [ConfigurationProperty("contract", IsRequired = true, IsKey = true)]
        public string Contract
        {
            get
            {
                return (string)this["contract"];
            }
            set
            {
                this["contract"] = value;
            }
        }

        [ConfigurationProperty("mapto", IsRequired = true, IsKey = false)]
        public string MapTo
        {
            get
            {
                return (string)this["mapto"];
            }
            set
            {
                this["mapto"] = value;
            }
        }

        /// <summary>
        /// 参数配置集
        /// </summary>
        [ConfigurationProperty("params", IsDefaultCollection = false, IsRequired = false)]
        [ConfigurationCollection(typeof(ParamCollection), AddItemName = "param")]
        public ParamCollection Parameters
        {
            get { return (ParamCollection)this["params"]; }
        }
    }

    public class Param : ConfigurationElement
    {
        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name { get; set; }

        [ConfigurationProperty("type", IsRequired = true, IsKey = false)]
        public string Type { get; set; }

        [ConfigurationProperty("mapto", IsRequired = false, IsKey = false)]
        public string MapTo { get; set; }
    }


    public class ParamCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Param();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Param)element).Name;
        }

        public Param this[int index]
        {
            get
            {
                return (Param)BaseGet(index);
            }
        }

        new public Param this[string name]
        {
            get
            {
                return (Param)BaseGet(name);
            }
        }

        public void Add(Param bind)
        {
            BaseAdd(bind);
        }


        public void RemoveAt(int ind)
        {
            BaseRemoveAt(ind);
        }

        public void Remove(Param bind)
        {
            BaseRemove(bind);
        }

        public void Clear()
        {
            BaseClear();
        }
    }

}