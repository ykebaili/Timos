// Data factory type.
// Copyright (C) 2008-2010 Malcolm Crowe, Lex Li, and other contributors.
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

/*
 * Created by SharpDevelop.
 * User: lextm
 * Date: 2008/4/30
 * Time: 19:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Globalization;
using System.IO;
using System.Net;

namespace futurocom.snmp
{
    /// <summary>
    /// Factory that creates <see cref="ISnmpData"/> instances.
    /// </summary>
    public static class DataFactory
    {
        /// <summary>
        /// Creates an <see cref="ISnmpData"/> instance from buffer.
        /// </summary>
        /// <param name="buffer">Buffer</param>
        /// <returns></returns>
        public static ISnmpData CreateSnmpData(EndPoint sourceEndPoint, byte[] buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }

            return CreateSnmpData(sourceEndPoint, buffer, 0, buffer.Length);
        }

        /// <summary>
        /// Creates an <see cref="ISnmpData"/> instance from stream.
        /// </summary>
        /// <param name="stream">Stream.</param>
        /// <param name="type">Type code.</param>
        /// <returns></returns>
        public static ISnmpData CreateSnmpData(EndPoint sourceEndPoint, int type, Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            var length = stream.ReadPayloadLength();
            switch ((SnmpType)type)
            {
                case SnmpType.Counter32:
                    return new Counter32(length, stream);
                case SnmpType.Counter64:
                    return new Counter64(length, stream);
                case SnmpType.Gauge32:
                    return new Gauge32(length, stream);
                case SnmpType.ObjectIdentifier:
                    return new ObjectIdentifier(length, stream);
                case SnmpType.Null:
                    stream.IgnoreBytes(length);
                    return new Null();
                case SnmpType.NoSuchInstance:
                    stream.IgnoreBytes(length);
                    return new NoSuchInstance();
                case SnmpType.NoSuchObject:
                    stream.IgnoreBytes(length);
                    return new NoSuchObject();
                case SnmpType.EndOfMibView:
                    stream.IgnoreBytes(length);
                    return new EndOfMibView();
                case SnmpType.Integer32:
                    return new Integer32(length, stream);
                case SnmpType.OctetString:
                    return new OctetString(length, stream);
                case SnmpType.IPAddress:
                    return new IP(length, stream);
                case SnmpType.TimeTicks:
                    return new TimeTicks(length, stream);
                case SnmpType.Sequence:
                    return new Sequence(sourceEndPoint, length, stream);
                case SnmpType.TrapV1Pdu:
                    return new TrapV1Pdu(sourceEndPoint, stream);
                case SnmpType.TrapV2Pdu:
                    return new TrapV2Pdu(sourceEndPoint, stream);
                case SnmpType.GetRequestPdu:
                    return new GetRequestPdu(sourceEndPoint, stream);
                case SnmpType.ResponsePdu:
                    return new ResponsePdu(sourceEndPoint, stream);
                case SnmpType.GetBulkRequestPdu:
                    return new GetBulkRequestPdu(sourceEndPoint, stream);
                case SnmpType.GetNextRequestPdu:
                    return new GetNextRequestPdu(sourceEndPoint, stream);
                case SnmpType.SetRequestPdu:
                    return new SetRequestPdu(sourceEndPoint, stream);
                case SnmpType.InformRequestPdu:
                    return new InformRequestPdu(sourceEndPoint, stream);
                case SnmpType.ReportPdu:
                    return new ReportPdu(sourceEndPoint, stream);
                case SnmpType.EndMarker:
                    return null;
                default:
                    throw new SnmpException(string.Format(CultureInfo.InvariantCulture, "unsupported data type: {0}", (SnmpType)type));
            }
        }

        /// <summary>
        /// Creates an <see cref="ISnmpData"/> instance from buffer.
        /// </summary>
        /// <param name="buffer">Buffer</param>
        /// <param name="index">Index</param>
        /// <param name="count">Count</param>
        /// <returns></returns>
        public static ISnmpData CreateSnmpData(EndPoint sourceEndPoint, byte[] buffer, int index, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }

            using (var m = new MemoryStream(buffer, index, count, false))
            {
                return CreateSnmpData(sourceEndPoint, m);
            }
        }

        /// <summary>
        /// Creates an <see cref="ISnmpData"/> instance from stream.
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        public static ISnmpData CreateSnmpData(EndPoint sourceEndPoint, Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            return CreateSnmpData(sourceEndPoint, stream.ReadByte(), stream);
        }

        //-----------------------------------------------------------------------------------
        public static ISnmpData CreateSnmpDataFromStringSafe(SnmpType type, string strValeur)
        {
            try
            {
                return CreateSnmpDataFromStringUnsafe(type, strValeur);
            }
            catch { }
            return null;
        }

        //-----------------------------------------------------------------------------------
        public static ISnmpData CreateSnmpDataFromStringUnsafe(SnmpType type, string strValeur)
        {
            ISnmpData data = null;
            switch (type)
            {
                case SnmpType.EndMarker:
                    //Non geré
                    break;
                case SnmpType.Integer32:
                    data = new Integer32(Int32.Parse(strValeur));
                    break;
                case SnmpType.OctetString:
                    data = new OctetString(strValeur);
                    break;
                case SnmpType.Null:
                    data = new Null();
                    break;
                case SnmpType.ObjectIdentifier:
                    data = new ObjectIdentifier(strValeur);
                    break;
                case SnmpType.Sequence:
                    //Non geré
                    break;
                case SnmpType.IPAddress:
                    data = new IP(IPAddress.Parse(strValeur));
                    break;
                case SnmpType.Counter32:
                    data = new Counter32(uint.Parse(strValeur));
                    break;
                case SnmpType.Gauge32:
                    data = new Gauge32(uint.Parse(strValeur));
                    break;
                case SnmpType.TimeTicks:
                    data = new TimeTicks(uint.Parse(strValeur));
                    break;
                case SnmpType.Opaque:
                    //Non geré
                    break;
                case SnmpType.NetAddress:
                    //Non geré
                    break;
                case SnmpType.Counter64:
                    data = new Counter64(ulong.Parse(strValeur));
                    break;
                case SnmpType.UInt32:
                    //Non geré
                    break;
                case SnmpType.NoSuchObject:
                    //Non geré
                    break;
                case SnmpType.NoSuchInstance:
                    //Non geré
                    break;
                case SnmpType.EndOfMibView:
                    //Non geré
                    break;
                case SnmpType.GetRequestPdu:
                    //Non geré
                    break;
                case SnmpType.GetNextRequestPdu:
                    //Non geré
                    break;
                case SnmpType.ResponsePdu:
                    //Non geré
                    break;
                case SnmpType.SetRequestPdu:
                    //Non geré
                    break;
                case SnmpType.TrapV1Pdu:
                    //Non geré
                    break;
                case SnmpType.GetBulkRequestPdu:
                    //Non geré
                    break;
                case SnmpType.InformRequestPdu:
                    //Non geré
                    break;
                case SnmpType.TrapV2Pdu:
                    //Non geré
                    break;
                case SnmpType.ReportPdu:
                    //Non geré
                    break;
                case SnmpType.Unknown:
                    //Non geré
                    break;
                default:
                    break;
            }

            return data;
        }
   
    }
}
