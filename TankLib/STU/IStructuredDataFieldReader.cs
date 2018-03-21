﻿using System;
using System.IO;
using System.Reflection;

namespace TankLib.STU {
    /// <summary>STU field reader interface</summary>
    public interface IStructuredDataFieldReader {
        void Deserialize(teStructuredDataMgr manager, teStructuredData data, STUField_Info field, object instance, FieldInfo target);
        void Deserialize_Array(teStructuredDataMgr manager, teStructuredData data, STUField_Info field, Array target, int index);
        //void Serialize();
        //void Serialize_Array();
    }

    /// <summary>Standard STU field reader</summary>
    public class DefaultStructuredDataFieldReader : IStructuredDataFieldReader {
        public virtual void Deserialize(teStructuredDataMgr manager, teStructuredData data, STUField_Info field, object instance, FieldInfo target) {
            target.SetValue(instance, DeserializeInternal(manager, data, field, target));
        }

        protected object DeserializeInternal(teStructuredDataMgr manager, teStructuredData data, STUField_Info field, FieldInfo target) {
            if (manager.Factories.ContainsKey(target.FieldType)) {
                IStructuredDataPrimitiveFactory factory = manager.Factories[target.FieldType];
                return factory.Deserialize(data, field);
            }

            if (typeof(ISerializable_STU).IsAssignableFrom(target.FieldType)) {
                ISerializable_STU ret = (ISerializable_STU)Activator.CreateInstance(target.FieldType);
                ret.Deserialize(data, field);

                return ret;
            }
            
            bool isStruct = target.FieldType.IsValueType && !target.FieldType.IsPrimitive;

            if (isStruct) {
                MethodInfo method = typeof(Extensions).GetMethod(nameof(Extensions.Read))?.MakeGenericMethod(target.FieldType);
                return method?.Invoke(data.Data, new object[] { data.Data });
            }
            
            throw new NotImplementedException();
        }
        
        protected object DeserializeArrayInternal(teStructuredDataMgr manager, teStructuredData data, STUField_Info field, Array target) {
            Type elementType = target.GetType().GetElementType();
            if (elementType == null) throw new InvalidDataException("elementType is null");
            if (manager.Factories.ContainsKey(elementType)) {
                IStructuredDataPrimitiveFactory factory = manager.Factories[elementType];
                return factory.DeserializeArray(data, field);
            }

            if (typeof(ISerializable_STU).IsAssignableFrom(elementType)) {
                ISerializable_STU ret = (ISerializable_STU)Activator.CreateInstance(elementType);
                ret.Deserialize_Array(data, field);

                return ret;
            }
            
            throw new NotImplementedException();
        }

        public virtual void Deserialize_Array(teStructuredDataMgr manager, teStructuredData data, STUField_Info field, Array target, int index) {
            target.SetValue(DeserializeArrayInternal(manager, data, field, target), index);
        }
    }
    
    /// <summary>STU field reader for reading embedded instances</summary>
    public class EmbeddedInstanceFieldReader : IStructuredDataFieldReader {
        public void Deserialize(teStructuredDataMgr manager, teStructuredData data, STUField_Info field, object instance, FieldInfo target) {
            int value = data.Data.ReadInt32();
            if (value == -1) return;
            if (value < data.Instances.Length)  {
                STUInstance embeddedInstance = data.Instances[value];
                if (embeddedInstance != null) {
                    embeddedInstance.Usage = TypeUsage.Embed;
                }
                
                target.SetValue(instance, embeddedInstance);
            }
        }
        
        public void Deserialize_Array(teStructuredDataMgr manager, teStructuredData data, STUField_Info field, Array target, int index) {
            int value = data.DynData.ReadInt32();
            data.DynData.ReadInt32(); // Padding for in-place deserialization
            if (value == -1) return;
            if (value < data.Instances.Length) {
                STUInstance embeddedInstance = data.Instances[value];
                if (embeddedInstance != null) {
                    embeddedInstance.Usage = TypeUsage.EmbedArray;
                }
                
                target.SetValue(embeddedInstance, index);
            } else {
                throw new ArgumentOutOfRangeException($"Instance index is out of range. Id: {value}, Type: EmbeddedInstanceFieldReader, DynData offset: {data.DynData.Position() - 8}");
            }
        }
    }
    
    /// <summary>STU field reader for reading inline instances</summary>
    public class InlineInstanceFieldReader : DefaultStructuredDataFieldReader {
        public override void Deserialize(teStructuredDataMgr manager, teStructuredData data, STUField_Info field, object instance, FieldInfo target) {
            STUInstance instanceObj = (STUInstance) DeserializeInternal(manager, data, field, target);
            instanceObj.Usage = TypeUsage.Inline;
            target.SetValue(instance, instanceObj);
        }
        
        public override void Deserialize_Array(teStructuredDataMgr manager, teStructuredData data, STUField_Info field, Array target, int index) {
            STUInstance instanceObj = (STUInstance) DeserializeArrayInternal(manager, data, field, target);
            instanceObj.Usage = TypeUsage.InlineArray;
            target.SetValue(instanceObj, index);
        }
    }
}