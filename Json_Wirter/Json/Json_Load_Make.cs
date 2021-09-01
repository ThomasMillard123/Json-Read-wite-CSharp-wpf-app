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
    
    public class CustomDataClass<T>
    {
        //[JsonIgnore]
        //public string PropertyName { get; set; }
        public T data { get; set; }
    
    }
    public class CustomDataContractResolver : DefaultContractResolver
    {
        //public static readonly CustomDataContractResolver Instance = new CustomDataContractResolver();
        public string propertyName { get; set; }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
          
                if (property.PropertyName.Equals("data", StringComparison.OrdinalIgnoreCase))
                {
                    property.PropertyName = propertyName;
                }

          
            return property;
        }
    }



    //singleton only need one 
    public sealed class Json_Load_Make
    {
       //string result;
        public JObject JsonData { get; set; }
        private Json_Load_Make()
        {
        }

        public static Json_Load_Make Instance { get { return Nested.instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly Json_Load_Make instance = new Json_Load_Make();
        }
    
        public void ADDSerliizeData<T>(ref T NewData,string DataName)
        {
            CustomDataClass<T> Data = new CustomDataClass<T>();
            //Data.PropertyName = DataName;
            //set data
            Data.data = NewData;



            //set name
            CustomDataContractResolver customData = new CustomDataContractResolver();
            customData.propertyName = DataName;

            var options = new JsonSerializerSettings
            {
                ContractResolver = customData

            };


            //serialize data
           var result = JsonConvert.SerializeObject(Data, options);
           
            //json object
            JsonData =JObject.Parse(result);

            result = JsonConvert.SerializeObject(Data);
           
        }

        
       //add to data
        public void ADDTOObjectSerliizeData<T>(ref T NewData, string DataName)
        {
            

            if (JsonData != null)
            {

                //json object
                JsonData.Add(new JProperty(DataName, NewData));
                
            }
            else
            {


                ADDSerliizeData<T>(ref NewData, DataName);

             }

        }


        public JObject JsonObjectData { get; set; }

        public void ADDObject<T>(ref T NewData, string DataName, string objectName)
        {
            
            if (JsonData != null)
            {
                CustomDataClass<T> Data = new CustomDataClass<T>();
                //Data.PropertyName = DataName;
                //set data
                Data.data = NewData;

                CustomDataContractResolver customData = new CustomDataContractResolver();
                customData.propertyName = DataName;
                var options = new JsonSerializerSettings
                {
                    ContractResolver = customData

                };


                //serialize data
                var result = JsonConvert.SerializeObject(Data, options);

                //json object
                JsonObjectData = JObject.Parse(result);
              
                //json object
                JsonData.Add(new JProperty(objectName, JsonObjectData));

            }
            else
            {


                ADDSerliizeData<T>(ref NewData, DataName);

            }

        }



        }







}
