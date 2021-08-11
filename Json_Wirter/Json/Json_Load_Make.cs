using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
//json inculdes
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace Json_Wirter.Json
{
 
   public class CustomDataClass
    {
      
        public string data { get; set; }
    
    }
    public class CustomDataContractResolver : DefaultContractResolver
    {
        public static readonly CustomDataContractResolver Instance = new CustomDataContractResolver();
        public string propertyName { get; set; }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (property.DeclaringType == typeof(CustomDataClass))
            {
                if (property.PropertyName.Equals("data", StringComparison.OrdinalIgnoreCase))
                {
                    property.PropertyName = propertyName;
                }
            }
           
            return property;
        }
    }
    public class Json_Load_Make
    {
        string FileName;
        string Data;
       
        JObject data1;
        public Json_Load_Make()
        {
        }

        public void SerliizeDataToFile<T>(ref T StringData)
        {
        }

        //
        public void ADDSerliizeData<T>(ref T NewData,string DataName)
        {
            CustomDataClass texs = new CustomDataClass();
            //set data
            texs.data = NewData.ToString();
            //set name
            CustomDataContractResolver.Instance.propertyName = DataName;
            //serialize data
            var result = JsonConvert.SerializeObject(texs,
                 new JsonSerializerSettings { ContractResolver = CustomDataContractResolver.Instance });

         
            //json object
            data1 =JObject.Parse(result);
            
        
        }




        public void DeserlizeData()
        {
            
        }

    }







}
