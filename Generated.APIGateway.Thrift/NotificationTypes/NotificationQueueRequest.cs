/**
 * Autogenerated by Thrift Compiler (0.14.1)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Thrift;
using Thrift.Collections;

using Thrift.Protocol;
using Thrift.Protocol.Entities;
using Thrift.Protocol.Utilities;
using Thrift.Transport;
using Thrift.Transport.Client;
using Thrift.Transport.Server;
using Thrift.Processor;


#pragma warning disable IDE0079  // remove unnecessary pragmas
#pragma warning disable IDE1006  // parts of the code use IDL spelling

namespace APIGateway.Thrift.Generated.NotificationTypes
{

  public partial class NotificationQueueRequest : TBase
  {
    private string _uniqueId;
    private string _businessKey;
    private string _data;

    public string UniqueId
    {
      get
      {
        return _uniqueId;
      }
      set
      {
        __isset.uniqueId = true;
        this._uniqueId = value;
      }
    }

    public string BusinessKey
    {
      get
      {
        return _businessKey;
      }
      set
      {
        __isset.businessKey = true;
        this._businessKey = value;
      }
    }

    public string Data
    {
      get
      {
        return _data;
      }
      set
      {
        __isset.data = true;
        this._data = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool uniqueId;
      public bool businessKey;
      public bool data;
    }

    public NotificationQueueRequest()
    {
    }

    public NotificationQueueRequest DeepCopy()
    {
      var tmp0 = new NotificationQueueRequest();
      if((UniqueId != null) && __isset.uniqueId)
      {
        tmp0.UniqueId = this.UniqueId;
      }
      tmp0.__isset.uniqueId = this.__isset.uniqueId;
      if((BusinessKey != null) && __isset.businessKey)
      {
        tmp0.BusinessKey = this.BusinessKey;
      }
      tmp0.__isset.businessKey = this.__isset.businessKey;
      if((Data != null) && __isset.data)
      {
        tmp0.Data = this.Data;
      }
      tmp0.__isset.data = this.__isset.data;
      return tmp0;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        await iprot.ReadStructBeginAsync(cancellationToken);
        while (true)
        {
          field = await iprot.ReadFieldBeginAsync(cancellationToken);
          if (field.Type == TType.Stop)
          {
            break;
          }

          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.String)
              {
                UniqueId = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.String)
              {
                BusinessKey = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
              if (field.Type == TType.String)
              {
                Data = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            default: 
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              break;
          }

          await iprot.ReadFieldEndAsync(cancellationToken);
        }

        await iprot.ReadStructEndAsync(cancellationToken);
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public async global::System.Threading.Tasks.Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
    {
      oprot.IncrementRecursionDepth();
      try
      {
        var struc = new TStruct("NotificationQueueRequest");
        await oprot.WriteStructBeginAsync(struc, cancellationToken);
        var field = new TField();
        if((UniqueId != null) && __isset.uniqueId)
        {
          field.Name = "uniqueId";
          field.Type = TType.String;
          field.ID = 1;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          await oprot.WriteStringAsync(UniqueId, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((BusinessKey != null) && __isset.businessKey)
        {
          field.Name = "businessKey";
          field.Type = TType.String;
          field.ID = 2;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          await oprot.WriteStringAsync(BusinessKey, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Data != null) && __isset.data)
        {
          field.Name = "data";
          field.Type = TType.String;
          field.ID = 3;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          await oprot.WriteStringAsync(Data, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        await oprot.WriteFieldStopAsync(cancellationToken);
        await oprot.WriteStructEndAsync(cancellationToken);
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override bool Equals(object that)
    {
      if (!(that is NotificationQueueRequest other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.uniqueId == other.__isset.uniqueId) && ((!__isset.uniqueId) || (System.Object.Equals(UniqueId, other.UniqueId))))
        && ((__isset.businessKey == other.__isset.businessKey) && ((!__isset.businessKey) || (System.Object.Equals(BusinessKey, other.BusinessKey))))
        && ((__isset.data == other.__isset.data) && ((!__isset.data) || (System.Object.Equals(Data, other.Data))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((UniqueId != null) && __isset.uniqueId)
        {
          hashcode = (hashcode * 397) + UniqueId.GetHashCode();
        }
        if((BusinessKey != null) && __isset.businessKey)
        {
          hashcode = (hashcode * 397) + BusinessKey.GetHashCode();
        }
        if((Data != null) && __isset.data)
        {
          hashcode = (hashcode * 397) + Data.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var sb = new StringBuilder("NotificationQueueRequest(");
      int tmp1 = 0;
      if((UniqueId != null) && __isset.uniqueId)
      {
        if(0 < tmp1++) { sb.Append(", "); }
        sb.Append("UniqueId: ");
        UniqueId.ToString(sb);
      }
      if((BusinessKey != null) && __isset.businessKey)
      {
        if(0 < tmp1++) { sb.Append(", "); }
        sb.Append("BusinessKey: ");
        BusinessKey.ToString(sb);
      }
      if((Data != null) && __isset.data)
      {
        if(0 < tmp1++) { sb.Append(", "); }
        sb.Append("Data: ");
        Data.ToString(sb);
      }
      sb.Append(')');
      return sb.ToString();
    }
  }

}