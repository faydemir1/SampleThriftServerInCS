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

namespace APIGateway.Thrift.Generated.BaseTypes
{

  public partial class NetworkException : TException, TBase
  {
    private string _errorCode;
    private string _errorMessage;
    private string _exceptionStr;

    public string ErrorCode
    {
      get
      {
        return _errorCode;
      }
      set
      {
        __isset.errorCode = true;
        this._errorCode = value;
      }
    }

    public string ErrorMessage
    {
      get
      {
        return _errorMessage;
      }
      set
      {
        __isset.errorMessage = true;
        this._errorMessage = value;
      }
    }

    public string ExceptionStr
    {
      get
      {
        return _exceptionStr;
      }
      set
      {
        __isset.exceptionStr = true;
        this._exceptionStr = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool errorCode;
      public bool errorMessage;
      public bool exceptionStr;
    }

    public NetworkException()
    {
    }

    public NetworkException DeepCopy()
    {
      var tmp0 = new NetworkException();
      if((ErrorCode != null) && __isset.errorCode)
      {
        tmp0.ErrorCode = this.ErrorCode;
      }
      tmp0.__isset.errorCode = this.__isset.errorCode;
      if((ErrorMessage != null) && __isset.errorMessage)
      {
        tmp0.ErrorMessage = this.ErrorMessage;
      }
      tmp0.__isset.errorMessage = this.__isset.errorMessage;
      if((ExceptionStr != null) && __isset.exceptionStr)
      {
        tmp0.ExceptionStr = this.ExceptionStr;
      }
      tmp0.__isset.exceptionStr = this.__isset.exceptionStr;
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
                ErrorCode = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.String)
              {
                ErrorMessage = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
              if (field.Type == TType.String)
              {
                ExceptionStr = await iprot.ReadStringAsync(cancellationToken);
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
        var struc = new TStruct("NetworkException");
        await oprot.WriteStructBeginAsync(struc, cancellationToken);
        var field = new TField();
        if((ErrorCode != null) && __isset.errorCode)
        {
          field.Name = "errorCode";
          field.Type = TType.String;
          field.ID = 1;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          await oprot.WriteStringAsync(ErrorCode, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((ErrorMessage != null) && __isset.errorMessage)
        {
          field.Name = "errorMessage";
          field.Type = TType.String;
          field.ID = 2;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          await oprot.WriteStringAsync(ErrorMessage, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((ExceptionStr != null) && __isset.exceptionStr)
        {
          field.Name = "exceptionStr";
          field.Type = TType.String;
          field.ID = 3;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          await oprot.WriteStringAsync(ExceptionStr, cancellationToken);
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
      if (!(that is NetworkException other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.errorCode == other.__isset.errorCode) && ((!__isset.errorCode) || (System.Object.Equals(ErrorCode, other.ErrorCode))))
        && ((__isset.errorMessage == other.__isset.errorMessage) && ((!__isset.errorMessage) || (System.Object.Equals(ErrorMessage, other.ErrorMessage))))
        && ((__isset.exceptionStr == other.__isset.exceptionStr) && ((!__isset.exceptionStr) || (System.Object.Equals(ExceptionStr, other.ExceptionStr))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((ErrorCode != null) && __isset.errorCode)
        {
          hashcode = (hashcode * 397) + ErrorCode.GetHashCode();
        }
        if((ErrorMessage != null) && __isset.errorMessage)
        {
          hashcode = (hashcode * 397) + ErrorMessage.GetHashCode();
        }
        if((ExceptionStr != null) && __isset.exceptionStr)
        {
          hashcode = (hashcode * 397) + ExceptionStr.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var sb = new StringBuilder("NetworkException(");
      int tmp1 = 0;
      if((ErrorCode != null) && __isset.errorCode)
      {
        if(0 < tmp1++) { sb.Append(", "); }
        sb.Append("ErrorCode: ");
        ErrorCode.ToString(sb);
      }
      if((ErrorMessage != null) && __isset.errorMessage)
      {
        if(0 < tmp1++) { sb.Append(", "); }
        sb.Append("ErrorMessage: ");
        ErrorMessage.ToString(sb);
      }
      if((ExceptionStr != null) && __isset.exceptionStr)
      {
        if(0 < tmp1++) { sb.Append(", "); }
        sb.Append("ExceptionStr: ");
        ExceptionStr.ToString(sb);
      }
      sb.Append(')');
      return sb.ToString();
    }
  }

}